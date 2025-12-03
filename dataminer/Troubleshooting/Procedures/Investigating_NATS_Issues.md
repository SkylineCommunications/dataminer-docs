---
uid: Investigating_NATS_Issues
keywords: VerifyNatsIsRunning, troubleshooting NATS, investigating NATS issues
description: If you encounter issues with a BrokerGateway-managed NATS architecture, these steps will help you troubleshoot your system.
---

# Troubleshooting – NATS (BrokerGateway-managed NAS/NATS architecture)

> [!NOTE]
> The information on this page applies for systems that use the BrokerGateway-managed NATS solution. This includes all systems using DataMiner 10.6.0/10.6.1 or higher as well as systems with lower DataMiner versions that have been [migrated to the BrokerGateway‑managed NATS solution](xref:BrokerGateway_Migration). For systems using the legacy SLNet-managed NATS architecture, refer to [Legacy NAS/NATS troubleshooting](xref:Investigating_Legacy_NATS_Issues).

To investigate NATS issues in a BrokerGateway-managed system, follow the actions detailed below, in the specified order:

1. [Confirm the system uses BrokerGateway-managed NATS](#confirm-the-system-uses-brokergateway-managed-nats)
1. [Check if ClusterEndpointsManager is enabled](#check-if-clusterendpointsmanager-is-enabled)
1. [Run the NATS cluster verification BPA test](#run-the-nats-cluster-verification-bpa-test)
1. [Inspect the logging](#inspect-the-logging)
1. [Check the configuration files](#check-the-configuration-files)
1. [Test connectivity between nodes](#test-connectivity-between-nodes)
1. [Reset or repair the NATS cluster](#resettingrepairing-the-brokergateway-nats-cluster)

> [!NOTE]
> These are advanced procedures that are only meant for administrators. If you do not feel confident applying any of these procedures, contact Skyline Communications.

## Confirm the system uses BrokerGateway-managed NATS

If you are using a DataMiner version **below DataMiner 10.6.0/10.6.1**, you need to confirm whether the system has been [migrated to the BrokerGateway‑managed NATS solution](xref:BrokerGateway_Migration).

From DataMiner 10.6.0/10.6.1 onwards, BrokerGateway is always used, so you can skip this step.

### How to verify

1. Check `C:\Skyline DataMiner\MaintenanceSettings.xml` for the following configuration:

   ```xml
   <BrokerGateway>true</BrokerGateway>
   ```

1. Open *services.msc* and verify the following:

   - The legacy NATS/NAS services are stopped or removed.
   - The `nats-server` service exists and is running.

If the system has not yet been migrated to BrokerGateway, refer to [Legacy NAS/NATS troubleshooting](xref:Investigating_Legacy_NATS_Issues).

## Check if ClusterEndpointsManager is enabled

The ClusterEndpointsManager soft-launch option must be enabled for BrokerGateway to manage NATS clustering properly.

### How to verify and fix

1. Open `C:\Skyline DataMiner\SoftLaunchOptions.xml`.

1. Check that it does **not** contain the configuration `<ClusterEndpointsManager>false</ClusterEndpointsManager>`.

1. If it does contain this configuration:

   1. Change it to `<ClusterEndpointsManager>true</ClusterEndpointsManager>`.

   1. Restart the DataMiner Agent.

   1. Do this on all DataMiner Agents in the system.

   1. When all DataMiner are fully started up, run [NATSRepair.exe](#resettingrepairing-the-brokergateway-nats-cluster) on a singular DataMiner agent.

For more information about soft-launch options, see [Activating Soft-Launch Options](xref:Activating_Soft_Launch_Options).

## Run the NATS cluster verification BPA test

The [NATS cluster verification BPA test](xref:BPA_Check_Agent_Presence) can quickly identify common configuration and connectivity issues.

### How to run the test

1. In DataMiner Cube, go to *Apps* > *System Center* > *Agents* > *BPA*.

1. Select the **Check Agent Presence** test.

1. Click *Run*.

1. Review the results for any errors or warnings.

The BPA test will verify:

- Whether all Agents in the cluster are reachable
- Whether the NATS configuration is correct on each Agent
- Whether the necessary credentials and certificates are present

## Inspect the logging

Examine the relevant log files to identify error messages or patterns that indicate the root cause of the issue.

### Log files to check

Check the following log files in the order listed:

1. **BrokerGateway logging**: `C:\ProgramData\Skyline Communications\DataMiner BrokerGateway\Logs`

   This contains information about BrokerGateway's management of NATS, including credential distribution and cluster configuration changes.

1. **NATS server logging**: `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server\nats-server.log`

   This contains information about NATS server startup, connection attempts, and any errors during operation.

1. **General SLError logging**: `C:\Skyline DataMiner\Logging\SLErrors.txt`

   This may contain errors from DataMiner processes attempting to connect to NATS.

### Common error patterns

- **Authorization violations**: Indicate credential mismatches or missing credential files.
- **Connection refused errors**: Suggest firewall or antivirus issues. It can also mean that the NATS service is not running.
- **Cluster formation errors**: Point to configuration mismatches between nodes.

## Check the configuration files

Verify that the key configuration files contain the correct information for your cluster setup.

### ClusterEndpoints.json

Location: `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json`

This file defines the endpoints for each agent in the cluster.

**Things to check:**

- For each agent entry, an IP must be present with a non-null `IgnitionValue`.
- `AdditionalEndpoints` must list any VIPs (Virtual IP addresses) if applicable.

**Example:**

```json
{
  "Endpoints": [
    {
      "IP": "172.0.0.1",
      "IgnitionValue": "SomeHashString",
      "AdditionalEndpoints": ["172.0.1.10"]
    },
    {
      "IP": "172.0.0.2",
      "IgnitionValue": "SomeHashString2",
      "AdditionalEndpoints": ["172.0.1.10"]
    }
  ]
}
```

### MessageBrokerConfig.json

Location: `C:\ProgramData\Skyline Communications\DataMiner\MessageBrokerConfig.json`

This file configures how DataMiner processes connect to BrokerGateway to obtain NATS credentials.

**Things to check:**

- `CredentialsUrl` typically points to the local Agent (using loopback or FQDN). This is the default setting unless it has been manually changed.
- If the HTTPS certificate CN/SAN does not match the hostname used in the URL, clients may fail with TLS validation errors.
- appsettings.runtime.json must be present at the path specified in `APIKeyPath`.

**Example:**

```json
{
  "BrokerGatewayConfig": {
    "CredentialsUrl": "https://hostname.domainname/BrokerGateway/api/natsconnection/getnatsconnectiondetails",
    "APIKeyPath": "C:\\Program Files\\Skyline Communications\\DataMiner BrokerGateway\\appsettings.runtime.json"
  }
}
```

### appsettings.runtime.json

Location: `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json`

This file contains the API key used for authentication between DataMiner processes and BrokerGateway. It is automatically generated during NATS installation and cluster configuration.

**Things to check:**

- The file must contain a valid `APIKey` value.
- All IP addresses of the cluster nodes must be listed under `ClusterInfo`. No extraneous or missing entries should be present.

**Example structure:**

```json
{
  "APIKeys": [
    ...
  ],
  "ClusterInfo": [
    {
      "Ip": "172.0.0.1",
      "ApiKey": "SomeHashString"
    },
    {
      "Ip": "172.0.0.2",
      "ApiKey": "SomeHashString"
    }
  ],
  "HasManualConfig": false
}
```

**Common issues:**

- **File missing**: If the file is missing, this indicates that the BrokerGateway installation or NATS configuration is incomplete.
- **ClusterInfo mismatch**: If the `ClusterInfo` section does not match the actual cluster nodes, it can lead to authentication failures.

**How to fix:**

If this file is missing, corrupted, or contains invalid data, run [NATSRepair.exe](#resettingrepairing-the-brokergateway-nats-cluster) to regenerate the NATS configuration and credentials. This will recreate the `appsettings.runtime.json` file.

## Test connectivity between nodes

Network connectivity issues between DataMiner Agents can prevent NATS clustering from functioning correctly.

### How to test

On each DataMiner Agent, execute the following PowerShell command to check if *nats-server* is reachable:

```powershell
Test-NetConnection <peerIP> -Port 4222
```

Replace `<peerIP>` with:

- The IP address of the local Agent (to test local connectivity)
- The IP addresses of other Agents in the cluster (to test cluster connectivity)

**Expected output for successful connection:**

```txt
ComputerName     : 172.16.0.1
RemoteAddress    : 172.16.0.1
RemotePort       : 4222
InterfaceAlias   : Ethernet
SourceAddress    : 172.16.0.1
TcpTestSucceeded : True
```

If `TcpTestSucceeded` is `False`, this indicates a firewall issue or that the NATS service is not running on the target Agent.

### Required ports

Ensure the following ports are open between all DataMiner Agents:

- **Port 4222**: NATS client connections
- **Port 6222**: NATS cluster communication (not required in a standalone agent setup)

## Resetting/repairing the BrokerGateway NATS cluster

To reset or repair a NATS cluster, use the tool `C:\Skyline DataMiner\Tools\NATSRepair.exe`, as detailed below.

Only do this if you are sure that the system uses the BrokerGateway‑managed NATS solution (see [Confirm the system uses BrokerGateway-managed NATS](#confirm-the-system-uses-brokergateway-managed-nats) for info on how to check this).

> [!NOTE]
> This will not work if [automatic NATS configuration is disabled](xref:Disabling_automatic_NATS_config).<!-- RN 44061 -->

### How to run NATSRepair.exe

1. Run `C:\Skyline DataMiner\Tools\NATSRepair.exe` on one DMA in the system.

   When executed, the tool returns a list of known DataMiner endpoints that will be used to configure the NATS cluster. For example:

   ```cmd
   The current known agents are the following:
   172.16.0.1
   172.16.0.2
   172.16.0.3

   This structure will be applied to the NATS cluster.
   If agents are missing or incorrect, do not continue and change C:\Skyline DataMiner\Configurations\ClusterEndpoints.json.
   Do you want to continue? (y/n):
   ```

   This list of endpoints is derived from `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json`. All IP addresses listed in that file must accurately reflect the complete set of DMAs in the cluster.

1. Before proceeding, validate the endpoint list:

   - If all displayed endpoints are correct, continue with the repair by entering `y`.

   - If any endpoints are missing or incorrect, enter `n` to stop, and manually update `ClusterEndpoints.json` by adding or removing entries as appropriate. Then rerun `NATSRepair.exe`.

   Only proceed when the list of IPs shown by NATSRepair matches the intended cluster composition.

1. The tool will reconfigure NATS on all Agents and restart the necessary services.
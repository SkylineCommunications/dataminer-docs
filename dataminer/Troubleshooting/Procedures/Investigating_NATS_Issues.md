---
uid: Investigating_NATS_Issues
keywords: VerifyNatsIsRunning, troubleshooting NATS, investigating NATS issues
description: If you encounter issues with a BrokerGateway-managed NATS architecture, these steps will help you troubleshoot your system.
---

# Troubleshooting – NATS (BrokerGateway-managed NAS/NATS architecture)

> [!NOTE]
> The information on this page applies for systems that use the BrokerGateway-managed NATS solution. This includes all systems using DataMiner 10.6.0/10.6.1 or higher as well as systems with lower DataMiner versions that have been [migrated to the BrokerGateway‑managed NATS solution](xref:BrokerGateway_Migration). For systems using the legacy SLNet-managed NATS architecture, refer to [Legacy NAS/NATS troubleshooting](xref:Investigating_Legacy_NATS_Issues).

## Typical diagnostic flow

1. If you are using a DataMiner version **below DataMiner 10.6.0/10.6.1**, confirm whether the system has been [migrated to the BrokerGateway‑managed NATS solution](xref:BrokerGateway_Migration):

   - Check `C:\Skyline DataMiner\MaintenanceSettings.xml` for `<BrokerGateway>true</BrokerGateway>`.

   - Verify whether the legacy NATS/NAS services are stopped or removed and ensure that the `nats-server` service exists (services.msc).

   Note that from DataMiner 10.6.0/10.6.1 onwards, this check is no longer needed, as BrokerGateway is always used from then onwards.

   If the system has not yet been migrated, refer to [Legacy NAS/NATS troubleshooting](xref:Investigating_Legacy_NATS_Issues).

1. Check the *SoftLaunchOptions.xml* [soft-launch options](xref:Activating_Soft_Launch_Options) file to ensure that it does **not** contain the configuration `<ClusterEndpointsManager>false</ClusterEndpointsManager>`.

   If it does contain this configuration:

   1. Change this to `<ClusterEndpointsManager>true</ClusterEndpointsManager>`.

   1. Restart the DataMiner Agent.

   1. When DataMiner has fully started up, run [NATSRepair.exe](#resettingrepairing-the-brokergateway-nats-cluster).

1. Run the [NATS cluster verification](xref:BPA_Check_Agent_Presence) BPA test.

1. Inspect the following logging:

   - BrokerGateway logging: `C:\ProgramData\Skyline Communications\DataMiner BrokerGateway\Logs`.

   - NATS logging: `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server\nats-server.log`.

   - General SLError logging: `C:\Skyline DataMiner\Logging\SLErrors.txt`.

1. Check the following configuration files:

   - `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json`: For each Agent, an IP must be present with a non-null `IgnitionValue`. `AdditionalEndpoints` must list its VIPs, if any.

   - `C:\ProgramData\Skyline Communications\DataMiner\MessageBrokerConfig.json`: `CredentialsUrl` must point to the local BrokerGateway with a reachable hostname or IP.

     Example `MessageBrokerConfig.json`:

     ```json
     {
       "BrokerGatewayConfig": {
         "CredentialsUrl": "https://hostname.domainname/BrokerGateway/api/natsconnection/getnatsconnectiondetails",
         "APIKeyPath": "C:\\Program Files\\Skyline Communications\\DataMiner BrokerGateway\\appsettings.runtime.json"
       }
     }
     ```

     > [!NOTE]
     > - `CredentialsUrl` is usually the local Agent (loopback or FQDN).
     > - If HTTPS cert CN/SAN does not match the host used here, clients may fail with TLS validation errors.

1. To test connectivity, on each DMA, execute the following PowerShell command to check if *nats-server* is reachable:

   ```txt
   Test-NetConnection <peerIP> -Port 4222
   ```

   `PeerIP` can be the IP of the local Agent or any other Agent in the cluster.

## Resetting/repairing the BrokerGateway NATS cluster

To reset or repair a NATS cluster, use the tool `C:\Skyline DataMiner\Tools\NATSRepair.exe`, as detailed below.

Only do this if you are sure that the system uses the BrokerGateway‑managed NATS solution (see [Typical diagnostic flow](#typical-diagnostic-flow) for info on how to check this).

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
   
   If all displayed endpoints are correct, continue with the repair.

   If any endpoints are missing or incorrect, stop, and manually update `ClusterEndpoints.json` by adding or removing entries as appropriate. Then rerun `NATSRepair.exe`.

   Only proceed when the list op IPs shown by NATSRepair matches the intended cluster composition.


## Rollback considerations

- ≥ DataMiner 10.6.0: Rollback unsupported.
- < DataMiner 10.6.0: Run [NATSMigrationRollback.dmupgrade](https://community.dataminer.services/download/natsmigrationrollback-dmupgrade/)

## Quick checklist

- The `nats-server` service is running on all DataMiner Agents.
- The soft-launch option [ClusterEndpointsManager](xref:Overview_of_Soft_Launch_Options) is enabled everywhere.
- The endpoints are reachable (ports 4222/6222).
- ClusterEndpoints.json is valid.
- The BPA tests succeed.
- There are no recurring auth/cluster errors.
- The clients connect without issues.

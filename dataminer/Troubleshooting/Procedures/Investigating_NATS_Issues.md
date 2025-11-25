---
uid: Investigating_NATS_Issues
keywords: VerifyNatsIsRunning, troubleshooting NATS, investigating NATS issues
description: Start by checking the logging, then check your installation and SLCloud.xml configuration, check if NAS and NATs are running, check the configs, …
---

# Troubleshooting – NATS (BrokerGateway-managed NAS/NATS architecture)

## BrokerGateway-managed NATS (nats-server service) troubleshooting

> [!NOTE]
> From DataMiner 10.5.0 [CU2]/10.5.5 onwards you can [migrate](xref:BrokerGateway_Migration) to the BrokerGateway‑managed NATS solution. The guidance below applies AFTER migration (legacy NAS/NATS services replaced by the single `nats-server` service managed via BrokerGateway). 
> If you still use the legacy SLNet-managed NATS architecture, refer to [Legacy NAS/NATS troubleshooting](xref:Investigating_Legacy_NATS_Issues).

### Typical diagnostic flow

1. Confirm migration state:
   - This check only applies for DataMiner 10.5.12 or lower. From 10.6.0 onwards, BrokerGateway-managed NATS is the only option.
   - Check `C:\Skyline DataMiner\MaintenanceSettings.xml` for `<BrokerGateway>true</BrokerGateway>`.
   - Verify legacy NATS/NAS services are stopped or removed; ensure `nats-server` service exists (services.msc).
1. Verify `ClusterEndpointsManager` soft‑launch option is enabled on every DMA:
   - Ensure there is **no** `<ClusterEndpointsManager>false</ClusterEndpointsManager>` in `SoftLaunchOptions.xml`.
   - If this is disabled on any node: enable it. Restart the Agent and after a full startup run [NATSRepair.exe](##resetting--repairing-the-brokergateway-nats-cluster).
1. Validate BPAs:
   - Run BPA test: [NATS cluster verification](xref:BPA_Check_Agent_Presence).
1. Inspect logs:
   - BrokerGateway logs: `C:\ProgramData\Skyline Communications\DataMiner BrokerGateway\Logs`.
   - NATS logs: `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server\nats-server.log`.
   - General SLError logs: `C:\Skyline DataMiner\Logging\SLErrors.txt`.
1. Check configuration files:
   - `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json`: For each agent, an IP must be present with a non-null IgnitionValue. AdditionalEndpoints must list its VIPs, if any.
   - `C:\ProgramData\Skyline Communications\DataMiner\MessageBrokerConfig.json`: CredentialsUrl must point to the local BrokerGateway with a reachable hostname/IP.

     Example `MessageBrokerConfig.json`:
     ```json
     {
       "BrokerGatewayConfig": {
         "CredentialsUrl": "https://hostname.domainname/BrokerGateway/api/natsconnection/getnatsconnectiondetails",
         "APIKeyPath": "C:\\Program Files\\Skyline Communications\\DataMiner BrokerGateway\\appsettings.runtime.json"
       }
     }
     ```
     Notes:
     - `CredentialsUrl` should normally be the local agent (loopback or FQDN).
     - If HTTPS cert CN/SAN does not match the host used here, clients may fail with TLS validation errors.
1. Test connectivity:
   - From each DMA, PowerShell: `Test-NetConnection <peerIP> -Port 4222` to check if nats-server is reachable. PeerIP can be the IP of the local agent or any other agent in the cluster.

### Resetting / repairing the BrokerGateway NATS cluster

Use `C:\Skyline DataMiner\Tools\NATSRepair.exe`. This is only allowed if the cluster already has migrated:
1. Run tool on one DMA.
1. Confirm that all endpoints are used by NATSRepair. If not, manually fix `ClusterEndpoints.json` first.

### Rollback considerations

- ≥ DataMiner 10.6.0: Rollback unsupported.
- < DataMiner 10.6.0: Run [NATSMigrationRollback.dmupgrade](https://community.dataminer.services/download/natsmigrationrollback-dmupgrade/)

### Quick checklist

- The `nats-server` service is running on all DataMiner Agents
- The soft-launch option [ClusterEndpointsManager](xref:Overview_of_Soft_Launch_Options) is enabled everywhere
- The endpoints are reachable (ports 4222/6222)
- ClusterEndpoints.json is valid
- The BPA tests succeed
- There are no recurring auth/cluster errors
- The clients (re)connect cleanly

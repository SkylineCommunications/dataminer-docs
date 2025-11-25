---
uid: BrokerGateway_Migration
---

# Migrating to BrokerGateway

From DataMiner 10.5.0 [CU2]/10.5.5 onwards<!-- RN 42573 -->, you can migrate from the SLNet-managed NATS solution (NAS and NATS services) to the BrokerGateway-managed NATS solution (nats-server service) using the "NATSMigration" tool. Prior to this, starting from DataMiner 10.5.0/10.5.2, this feature is available in [soft launch](xref:SoftLaunchOptions).

> [!IMPORTANT]
> This migration is **mandatory to be able to upgrade to DataMiner 10.6.0/10.6.1** or higher. If you try to upgrade to such a DataMiner version when this migration has not yet been completed, the upgrade will be blocked. From DataMiner 10.6.0/10.6.1 onwards, the legacy SLNet‑managed NATS solution (NAS and NATS services) is no longer supported.<!-- RN 43861 -->

> [!NOTE]
> To start the migration, the [ClusterEndpointsManager](xref:Overview_of_Soft_Launch_Options#clusterendpointsmanager) soft‑launch option must not be disabled on any DataMiner Agent in the cluster. In DataMiner 10.5.0 [CU5]/10.5.8<!-- RN 43370 --> this option can be disabled when no migration is planned.

Once the [prerequisites](#prerequisites) are met, you can either [run an automatic migration](#automatic-migration-using-dmupgrade-package-recommended) or [run the migration manually](#manual-migration).

Note that prior to DataMiner 10.5.0 [CU4]/10.5.7 the migration requires a DataMiner restart.<!-- RN 42930 -->

After the migration you may need to [update your Data Aggregator configuration](#updating-the-data-aggregator-configuration).

### Technical key differences versus legacy SLNet-managed NATS

| Aspect | Legacy SLNet-managed NATS/NAS services | BrokerGateway-managed NATS service |
|--------|------------------------------|-----------------------|
| Services | Windows services: NAS, NATS | Windows service: `nats-server`; BrokerGateway service (IIS/Kestrel hosted) supplies credentials & clustering |
| Config source | `SLCloud.xml`, NAS/NATS config files | `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json` (endpoints), `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json` (BrokerGateway) |
| Credentials | `.creds` files under `C:\Skyline DataMiner\NATS\nsc` | dynamic credentials via BrokerGateway API. Saved on disk in `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server\.data\nats\nsc` |
| Cluster formation | NATSCustodian recalculates NAS/NATS configs | BrokerGateway API builds cluster |
| Repair tool | [Manual reset / reinstall](xref:Investigating_Legacy_NATS_Issues#remaining-steps) | `C:\Skyline DataMiner\Tools\NATSRepair.exe` tool |

## Prerequisites

Before initiating the migration, ensure that the entire cluster has been operating in a stable state for an extended period. All DataMiner Agents in the cluster must be online and functioning together for at least 15 minutes. To verify that the DMS meets the required conditions, run the [Verify NATS Migration Prerequisites](xref:BPA_NATS_Migration_Prerequisites) and [Check Deprecated DLL Usage](xref:BPA_Check_Deprecated_DLL_Usage) BPA.

Additionally, check whether any protocols reference DataMinerMessageBroker.API.dll with a version earlier than 3.0.0. Update any such references prior to migration and remove the outdated DLL from the `C:\Skyline DataMiner\ProtocolScripts` folder.
From DataMiner 10.5.0 [CU9]/10.5.12 onward, the presence of such an outdated DLL in the ProtocolScripts directory will block the migration.

## Automatic migration using .dmupgrade package (recommended)

If you are using a DataMiner 10.5.x version starting from 10.5.0 [CU4] or 10.5.7, the recommended way to run the migration is by means of an upgrade package available on our Dojo Community platform:

1. Ensure the [prerequisites](#prerequisites) are met.

1. Download and run the [NATSMigration.dmupgrade](https://community.dataminer.services/download/natsmigration-dmupgrade/) package.

This will automatically run `C:\Skyline DataMiner\Tools\NATSMigration.exe` with default settings on all Agents. The DataMiner Agents will not be restarted.
The output similar to [manual migration log](#full-example-migration-log-sanitized) can only be seen when issues occur during migration.
The logs will be visible in `C:\Skyline DataMiner\Upgrades\Packages\NATSMigration.dmupgrade-XXX\progress.log` and in the upgrade utility UI.

## Manual migration

For DataMiner versions prior to 10.5.0 [CU4]/10.5.7, the migration needs to be run manually:

1. Ensure the [prerequisites](#prerequisites) are met.

1. Open a **remote desktop connection** to **all** DataMiner Agents at the same time.

1. On each Agent, open an elevated command prompt and run `C:\Skyline DataMiner\Tools\NATSMigration.exe`, with the optional argument `-r` to keep the script from restarting DataMiner.

1. Enter the `install` command on every Agent (including Failover Agents) within 10 minutes.

> [!IMPORTANT]
> This must happen on **each DMA** in the cluster **within a 10-minute time frame**. It is very important that this happens for **each individual DataMiner Agent, including Failover DMAs**. Prior to DataMiner 10.5.0 [CU4]/10.5.7, this also involves a restart of each DataMiner Agent.

### Full example migration log (sanitized)

Below is a full sample output of a successful manual migration run. The machine name has been replaced by `HOSTNAME` and the IP addresses by `IP1`, `IP2`, and virtual IP `VIP1`. Timestamps have been removed as well.
This can only be seen if `C:\Skyline DataMiner\ToolsNATSMigration.exe` is manually executed from console.

```cmd
C:\Skyline DataMiner\Tools>NATSMigration.exe
Warning: This will alter DataMiner NATS configuration.
This will also restart DataMiner. Continue? (y/n):y
HOSTNAME - Stopping DataMiner.
************  Stopping the DataMiner software   *************

...

(un)install BrokerGateway managed NATS server? (install/uninstall):install
HOSTNAME - Running prerequisite check before switching to BrokerGateway...
HOSTNAME - All prerequisites ran successfully. No issues detected.
HOSTNAME - Migrating to BrokerGateway managed nats-server.
HOSTNAME - BrokerGateway maintenance flag is set to True.
SLKill called for "nats" with force=False
   *** Stop services ***
   Service (NATS) has been stopped.
   *** Kill processes ***
   Process (nats-account-server : 55500) has been killed.
   SLKill called for "nas" with force=False
   *** Stop services ***
   Service (NAS) has been stopped.
   *** Kill processes ***
HOSTNAME - DataMiner BrokerGateway is already running.
HOSTNAME - DataMiner BrokerGateway is reachable.
HOSTNAME - Agent that will set up the cluster: IP1
HOSTNAME - This agent is setting up the cluster...
HOSTNAME - checking if BGW of IP1 is running...
HOSTNAME - BGW of IP1 is running.
HOSTNAME - checking if BGW of IP2 is running...
HOSTNAME - BGW of IP2 is running.
HOSTNAME - Cluster consists of following endpoints: IP1 (VIP1), IP2 (VIP1)
HOSTNAME - Calling ResetCluster endpoint.
HOSTNAME - Contacted nats-server and BrokerGateway successfully!
HOSTNAME - Setting the MessageBrokerConfig.json...
HOSTNAME - Starting DataMiner.
*************************************************************
***********  Starting the DataMiner software   ************
*************************************************************
--
-- This tool restarts the DataMiner software, including SLNet
--


-- Starting SLNet
The SLNet Service service is starting.
The SLNet Service service was started successfully.

-- Starting DataMiner
************  Starting the DataMiner software   *************


The SLDataMiner service is starting.
The SLDataMiner service was started successfully.


--
-- The DataMiner software is starting
--
*************************************************************
(c) Skyline Communications                     www.skyline.be
HOSTNAME - Migration successful!
```

> [!NOTE]
> If you run this executable on a recent DataMiner version (DataMiner 10.5.0 [CU4]/10.5.7 or higher<!-- RN 42930 -->), no restart will be mentioned. If you run this executable prior to DataMiner 10.5.0 [CU2]/10.5.5 as a soft-launch feature, the output will indicate the "BrokerGateway SoftLaunch flag" instead of the "BrokerGateway maintenance flag".

## Actions during the migration

The following actions will be executed automatically during the migration, in the indicated order:

1. Prerequisites for the migration are checked.

   This includes the [Verify NATS Migration Prerequisites](xref:BPA_NATS_Migration_Prerequisites) BPA test and (from DataMiner 10.5.0 [CU9]/10.5.12 onwards) a check for outdated DLLs in the *ProtocolScripts* folder. If any of the prerequisites are not met or if an outdated DLL is found, you will first need to solve the issue before you can start the migration again.

1. If you are using a DataMiner version prior to 10.5.0 [CU4]/10.5.7, DataMiner is stopped.

1. The *BrokerGateway* flag in `C:\Skyline DataMiner\MaintenanceSettings.xml` is set to true, or, if you are using a DataMiner version prior to 10.5.0 [CU2]/10.5.5, a *BrokerGateway* soft-launch flag is set instead.

   ```xml
   <MaintenanceSettings xmlns="http://www.skyline.be/config/maintenancesettings">
      <SLNet>
         <BrokerGateway>true</BrokerGateway>
      </SLNet>
   </MaintenanceSettings>
   ```

1. The SLNet-managed NAS and NATS services are stopped and their startup type is set to "Manual".

1. The *ResetCluster* API (`https://<ip>/BrokerGateway/api/clusteringapi/resetcluster`) is called on BrokerGateway to create a new BrokerGateway-managed NATS cluster, and the NATS binaries are installed at `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server` and started as a service called "nats-server".

   The *ResetCluster* API call is only executed by one of the NATSMigration instances, if a cluster is migrated. The node that will execute this command is the one with the lowest IP alphabetically. The other nodes will wait until a NATS session using BrokerGateway can be created.

1. The *MessageBrokerConfig.json* file is written at `C:\ProgramData\Skyline Communications\DataMiner\MessageBrokerConfig.json`.

   This file is used when initializing default sessions for DataMiner processes using the NATS communication channel. During system migration, the file is automatically overwritten to include the correct BrokerGateway URL and the path to the associated API key.

A typical example of this file’s contents is shown below:

   ```json
   {
     "BrokerGatewayConfig": {
       "CredentialsUrl": "https://HOST/BrokerGateway/api/natsconnection/getnatsconnectiondetails",
       "APIKeyPath": "C:\\Program Files\\Skyline Communications\\DataMiner BrokerGateway\\appsettings.runtime.json"
     }
   }
   ```

> [!NOTE]
> The NATSMigration tool has a hard‑coded 10‑minute timeout for completing the *ResetCluster* operation. If for some reason the migration cannot be completed within 10 minutes, or if something goes wrong during the migration, all Agents will revert back to using the SLNet-managed NATS solution.<!-- RN 41115 -->

> [!IMPORTANT]
> The NATS configuration (*nats-server.config*) of the NATS instance before the migration is not transferrable to the NATS instance after the migration, so it should **never be copied over**.

## Migrating back to the old system

> [!IMPORTANT]
> This is no longer possible from DataMiner 10.6.0/10.6.1 onwards.

On versions prior to 10.6.0/10.6.1, there are two different ways you can go back to the SLNet-managed NATS:

- Download and run the package [NATSMigrationRollback.dmupgrade](https://community.dataminer.services/download/natsmigrationrollback-dmupgrade/).

- Follow the same procedure as when you [run the migration manually](#manual-migration), but use the `uninstall` command instead of the `install` command. In this case, the same restrictions apply as for the migration: this must happen on all DataMiner Agents in the cluster at the same time.

## Updating the Data Aggregator configuration

[Data Aggregator](xref:Data_Aggregator_DxM) can connect to multiple DataMiner Systems. When a specific DMS is migrated to BrokerGateway, any Data Aggregator configuration that connects to this DMS must be [manually updated](xref:Data_Aggregator_settings#dms-with-brokergateway).

## FAQ

### Can I run a cluster with both SLNet‑managed NATS and BrokerGateway‑managed NATS?

This is not possible. Both NATS installations use the same network ports, so the services cannot run at the same time on a machine. The credentials these installations use are also different and not compatible with each other, so running SLNet-managed NATS on DMA1 and BrokerGateway-managed NATS on DMA2 will also not function.

### Why should I migrate to BrokerGateway? What are the advantages?

BrokerGateway will manage NATS communication based on a single source of truth that has the complete knowledge of the cluster, resulting in more robust, carefree NATS communication. In addition, TLS will be configured automatically, and a newer version of NATS will be used that has better performance and is easier to upgrade.

In addition, starting from DataMiner 10.6.0/10.6.1, the SLNet‑managed NATS solution is no longer supported, so the migration to BrokerGateway will have to be done before you can upgrade to these DataMiner versions and beyond.

## Troubleshooting

### ERROR: {machineName} was not able to remove itself from its current cluster in order to join the new cluster

When calling *ResetCluster*, BrokerGateway will first try to remove itself from any cluster it is part of, in order to set up a new cluster with all the endpoints specified in `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json`.

The endpoints BrokerGateway is currently clustered with are listed in the ClusterInfo in `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json`. If one of those IPs cannot be reached, the error message above is generated.

You will be asked if the node may be forcibly removed. If you agree to this, the current machine can free itself from the cluster to cluster with the new setup instead. However, because it forcibly removes itself, it no longer informs any of the unreachable endpoints of its removal. These may still attempt to contact the current machine, which will no longer be reachable for them. If you choose to not allow the forcible removal, this will cancel the migration process and revert back to the previous configuration.<!-- RN 40991 -->

If you do want to migrate to BrokerGateway but you do not want this forced removal, make sure all endpoints specified in *appsettings.runtime.json* can be reached by the current machine.

When using automatic migration with the .dmupgrade package, forced removal is always performed automatically when regular removal does not succeed.

### NATSRepair.exe

If you encounter any issues with your NATS cluster related to credentials or misconfigured nodes and you have migrated to BrokerGateway, you can run the *NATSRepair.exe* tool from the `C:\Skyline DataMiner\Tools\` folder. 
This tool needs to be run on just one agent of the cluster. It will perform a repair on the cluster.<!-- RN 42328 -->

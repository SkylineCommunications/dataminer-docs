---
uid: BrokerGateway_Migration
---

# Migrating to BrokerGateway

From DataMiner 10.5.0 [CU2]/10.5.5 onwards<!-- RN 42573 -->, you can migrate from the SLNet-managed NATS solution (NAS and NATS services) to the BrokerGateway-managed NATS solution (nats-server service) using the "NATSMigration" tool. Prior to this, starting from DataMiner 10.5.0/10.5.2, this feature is available in [soft launch](xref:SoftLaunchOptions).

> [!IMPORTANT]
> From DataMiner 10.6.0 onwards, the legacy SLNet‑managed NATS solution (NAS and NATS services) is no longer available. You must migrate manually to the BrokerGateway‑managed NATS solution before upgrading to 10.6.0 or higher. The upgrade does not perform the migration automatically, and rollback to the SLNet‑managed solution is no longer possible after upgrading to 10.6.0.
> To start the migration, the [ClusterEndpointsManager](xref:Overview_of_Soft_Launch_Options#clusterendpointsmanager) soft‑launch option may not be disabled on any DataMiner Agent in the cluster. In DataMiner 10.5.0 [CU5]/10.5.8<!-- RN 43370 --> this option can be disabled when no migration is planned.

Once the [prerequisites](#prerequisites) are met choose one of two methods: [dmupgrade package migration (recommended)](#dmupgrade-package-migration-recommended) or [manual migration (per node)](#manual-migration-per-node).

Note that prior to DataMiner 10.5.0 [CU4]/10.5.7 the migration requires a DataMiner restart.<!-- RN 42930 -->

After the migration you may need to [update your Data Aggregator configuration](#updating-the-data-aggregator-configuration).

## Prerequisites

Before you start the migration the entire cluster must have been running smoothly for at least 15 minutes (all Agents online and communicating). Run the [Verify NATS Migration Prerequisites](xref:BPA_NATS_Migration_Prerequisites) BPA to confirm readiness.

Also verify no protocols reference the `DataMinerMessageBroker.API.dll` with a version older than `3.0.0`. Update such protocols and remove the old DLL from the `ProtocolScripts` folder. From DataMiner 10.5.0 [CU9]/10.5.12 onwards presence of this DLL blocks the migration.

## dmupgrade package migration (recommended)

If you are using DataMiner 10.5.0 [CU4]/10.5.7 or higher (but lower than 10.6.0) use the upgrade package:

1. Ensure the [prerequisites](#prerequisites) are met.
2. Download and run the [NATSMigration.dmupgrade](https://community.dataminer.services/download/natsmigration-dmupgrade/) package.

This centrally runs `C:\Skyline DataMiner\Tools\NATSMigration.exe` with default settings on all Agents. No per‑Agent interaction is required and Agents are not restarted.

## Manual migration (per node)

For versions prior to 10.5.0 [CU4]/10.5.7 or when manual control is preferred:

1. Ensure the [prerequisites](#prerequisites) are met.
2. Open a remote desktop session to all DataMiner Agents.
3. On each Agent open an elevated command prompt and run `C:\Skyline DataMiner\Tools\NATSMigration.exe`. with the optional argument `-r` to not restart DataMiner automatically by the script.
4. Enter the `install` command on every Agent (including Failover partners) within 10 minutes.

> [!IMPORTANT]
   > This must happen on **each DMA** in the cluster **within a 10-minute time frame**. It is very important that this happens for **each individual DataMiner Agent, including Failover DMAs**. Prior to DataMiner 10.5.0 [CU4]/10.5.7, this also involves a restart of each DataMiner Agent.

### Full example migration log (sanitized)

Below is a full sample output of a successful migration run. The machine name has been replaced by `HOSTNAME` and IP addresses by `IP1`, `IP2`, and virtual IP `VIP1`. Timestamps have been removed as well.

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

## Actions performed by the migration

The following actions will be executed during the migration, in the indicated order:

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

1. The NAS and NATS services are stopped and their startup type is set to "Manual".

1. The *ResetCluster* API (`https://<ip>/BrokerGateway/api/clusteringapi/resetcluster`) is called on BrokerGateway to create a new NATS cluster, and the NATS binaries are installed at `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server` and started as a service called "nats-server".

   The *ResetCluster* API call is only executed by one of the NATSMigration instances, if a cluster is migrated. The node that will execute this command is the one with the lowest IP alphabetically. The other nodes will wait until a NATS session using BrokerGateway can be created.

1. The *MessageBrokerConfig.json* file is written at `C:\ProgramData\Skyline Communications\DataMiner\MessageBrokerConfig.json`.

   This file is used when creating default sessions using the *DataMinerMessageBroker.API(.Native)* library. The file will be rewritten to reference the BrokerGateway URL and API key path. The content of this file can for example look like this:

```json
{
  "BrokerGatewayConfig": {
    "CredentialsUrl": "https://HOST/BrokerGateway/api/natsconnection/getnatsconnectiondetails",
    "APIKeyPath": "C:\\Program Files\\Skyline Communications\\DataMiner BrokerGateway\\appsettings.runtime.json"
  }
}
```

> [!NOTE]
> NATSMigration has a hard‑coded 10‑minute timeout for completing `ResetCluster`. Timeout or failure reverts Agents to the SLNet‑managed NATS (if supported by the version).<!-- RN 41115 -->

> [!IMPORTANT]
> Never copy the old `nats-server.config` into the new BrokerGateway‑managed installation.

## Migrating back to the old system

> [!IMPORTANT]
> From DataMiner 10.6.0 onwards rollback to the SLNet‑managed NATS solution is not supported.

On versions prior to 10.6.0 you can revert by:

- Running [NATSMigrationRollback.dmupgrade](https://community.dataminer.services/download/natsmigrationrollback-dmupgrade/), or
- Running `NATSMigration.exe` with `uninstall` on every Agent within 10 minutes (same coordination as install).

## Updating the Data Aggregator configuration

[Data Aggregator](xref:Data_Aggregator_DxM) configurations pointing at a migrated DMS must be updated (BrokerGateway settings).

## FAQ

### Can I run a cluster with both SLNet‑managed NATS and BrokerGateway‑managed NATS?

No. Ports conflict and credentials differ; mixed setups do not function.

### Why should I migrate to BrokerGateway?

It provides a single authoritative cluster view, automatic TLS, simplified lifecycle management and improved performance vs the legacy SLNet‑managed setup.
From DataMiner 10.6.0 onwards the SLNet‑managed NATS solution is no longer available and migration before upgrading is mandatory.

## Troubleshooting

### ERROR: {machineName} was not able to remove itself from its current cluster in order to join the new cluster

BrokerGateway attempts to detach from any existing cluster (endpoints in `ClusterEndpoints.json`). If an endpoint is unreachable a prompt for forced removal appears. Forced removal proceeds without informing unreachable peers. Declining cancels and reverts.<!-- RN 40991 -->

Ensure all endpoints listed in `appsettings.runtime.json` are reachable before retrying.

### NATSRepair.exe

If issues occur after migration run `NATSRepair.exe` from `C:\Skyline DataMiner\Tools\` to repair the cluster.<!-- RN 42328 -->

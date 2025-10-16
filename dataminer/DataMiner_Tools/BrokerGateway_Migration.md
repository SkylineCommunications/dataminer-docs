---
uid: BrokerGateway_Migration
---

# Migrating to BrokerGateway

From DataMiner 10.5.0 [CU2]/10.5.5 onwards<!-- RN 42573 -->, you can migrate from the SLNet-managed NATS solution (NAS and NATS services) to the BrokerGateway-managed NATS solution (nats-server service) using the "NATSMigration" tool. Prior to this, starting from DataMiner 10.5.0/10.5.2, this feature is available in [soft launch](xref:SoftLaunchOptions).

> [!IMPORTANT]
> To be able to start this migration, the [ClusterEndpointsManager](xref:Overview_of_Soft_Launch_Options#clusterendpointsmanager) soft-launch option may not be disabled on any DataMiner Agent in the cluster. In DataMiner 10.5.0 [CU5]/10.5.8<!-- RN 43370 -->, this option can be disabled to prevent possible issues on systems where no migration is planned.

Once the [prerequisites](#prerequisites) are met, you can either [run an automatic migration](#running-an-automatic-migration) or [run the migration manually](#running-the-migration-manually).

Note that prior to DataMiner 10.5.0 [CU4]/10.5.7, this migration requires a DataMiner restart.<!-- RN 42930 -->

From DataMiner 10.6.0 onwards, this migration will happen automatically during a DataMiner upgrade.

After the migration, you may need to [update your Data Aggregator configuration](#updating-the-data-aggregator-configuration).

## Prerequisites

Before you start the migration, the entire cluster must have been running smoothly for some time. This means that all DataMiner Agents in the cluster must be online and function together for at least 15 minutes. To confirm that the DMS is ready to be migrated, run the [Verify NATS Migration Prerequisites](xref:BPA_NATS_Migration_Prerequisites) BPA.

If the BPA succeeds, the system is all set to migrate.

## Running an automatic migration

If you are using DataMiner 10.5.0 [CU4]/10.5.7 or higher, the easiest way to run the migration is by means of an upgrade package available on our Dojo Community platform:

1. Make sure the [prerequisites](#prerequisites) are met.

1. Download and run the [NATSMigration.dmupgrade](https://community.dataminer.services/download/natsmigration-dmupgrade/) package.

   This will automatically run `C:\Skyline DataMiner\Tools\NATSMigration.exe` with the default settings on all Agents in the cluster. The DataMiner Agents will not be restarted.

## Running the migration manually

For DataMiner versions prior to DataMiner 10.5.0 [CU4]/10.5.7, we recommend running the migration manually:

1. Make sure the [prerequisites](#prerequisites) are met.

1. Open a **remote desktop connection** to **all** DataMiner Agents at the same time.

1. On each of the machines, open a **command prompt** as administrator, and run the executable `C:\Skyline DataMiner\Tools\NATSMigration.exe`.

   It is important that you use a command prompt to run executable, so its output is not lost when the process finishes.

1. On each machine, enter the `install` command and confirm.

   > [!IMPORTANT]
   > This must happen on **each DMA** in the cluster **within a 10-minute time frame**. It is very important that this happens for **each individual DataMiner Agent, including Failover DMAs**. Prior to DataMiner 10.5.0 [CU4]/10.5.7, this also involves a restart of each DataMiner Agent.

   Successful installation output might look like this (depending on your DataMiner version):

   ```cmd
   C:\Skyline DataMiner\Tools>NATSMigration.exe
   Warning: This will alter DataMiner NATS configuration.
   This will also restart DataMiner. Continue? (y/n):y
   LAURENSVG.skyline.local - Stopping DataMiner.
   ************  Stopping the DataMiner software   *************

   ...

   (un)install BrokerGateway managed NATS server? (install/uninstall):install
   LAURENSVG.skyline.local - BrokerGateway maintenance flag is set to True.
   LAURENSVG.skyline.local - Setting the MessageBrokerConfig.json...
   SLKill called for "nats" with force=False
   *** Stop services ***
   Service (NATS) has been stopped.
   *** Kill processes ***
   Process (nats-account-server : 55500) has been killed.
   SLKill called for "nas" with force=False
   *** Stop services ***
   Service (NAS) has been stopped.
   *** Kill processes ***
   LAURENSVG.skyline.local - DataMiner BrokerGateway is already running.
   LAURENSVG.skyline.local - DataMiner BrokerGateway is reachable.
   LAURENSVG.skyline.local - Agent that will set up the cluster: 10.3.1.54
   LAURENSVG.skyline.local - This agent is resetting the cluster...
   LAURENSVG.skyline.local - checking if BGW of 10.3.1.54 is running...
   LAURENSVG.skyline.local - BGW of 10.3.1.54 is running.
   LAURENSVG.skyline.local - Calling ResetCluster endpoint.
   LAURENSVG.skyline.local - Contacted nats-server and BrokerGateway successfully!
   LAURENSVG.skyline.local - Starting DataMiner.
   *************************************************************
   ***********  Starting the DataMiner software   ************
   *************************************************************
   --
   -- This tool restarts the DataMiner software, including SLNet
   --
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
   ```

   > [!NOTE]
   > If you run this executable on a recent DataMiner version (DataMiner 10.5.0 [CU4]/10.5.7 or higher<!-- RN 42930 -->), no restart will be mentioned. If you run this executable prior to DataMiner 10.5.0 [CU2]/10.5.5 as a soft-launch feature, the output will indicate the "BrokerGateway SoftLaunch flag" instead of the "BrokerGateway maintenance flag".

## Actions during the migration

The following actions will be executed during the migration, in the indicated order:

1. If you are using a DataMiner version prior to 10.5.0 [CU4]/10.5.7, DataMiner is stopped.

1. The *BrokerGateway* flag in `C:\Skyline DataMiner\MaintenanceSettings.xml` is set to true, or, if you are using a DataMiner version prior to 10.5.5/10.5.0 [CU2], a *BrokerGateway* soft-launch flag is set instead.

   ```xml
   <MaintenanceSettings xmlns="http://www.skyline.be/config/maintenancesettings">
      <SLNet>
         <BrokerGateway>true</BrokerGateway>
      </SLNet>
   </MaintenanceSettings>
   ```

1. The NAS and NATS services are stopped and their startup type is set to "Manual".

   At a later stage, the migration tool might delete the services instead.

1. The *ResetCluster* API (`https://<ip>/BrokerGateway/api/clusteringapi/resetcluster`) is called on BrokerGateway to create a new NATS cluster, and the NATS binaries are installed at `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server` and started as a service called "nats-server".

   The *ResetCluster* API call is only executed by one of the NATSMigration instances, if a cluster is migrated. The node that will execute this command is the one with the lowest IP alphabetically. The other nodes will wait until a NATS session using BrokerGateway can be created.

1. The *MessageBrokerConfig.json* file is written at `C:\ProgramData\Skyline Communications\DataMiner\MessageBrokerConfig.json`.

   This file is used when creating default sessions using the *DataMinerMessageBroker.API(.Native)* library. The file will be rewritten to reference the BrokerGateway URL and API key path. The content of this file can for example look like this:

   ```json
   {
     "BrokerGatewayConfig": {
       "CredentialsUrl": "https://LAURENSVG.skyline.local/BrokerGateway/api/natsconnection/getnatsconnectiondetails",
       "APIKeyPath": "C:\\Program Files\\Skyline Communications\\DataMiner BrokerGateway\\appsettings.runtime.json"
     }
   }
   ```

> [!NOTE]
> The NATSMigration tool has a **hard-coded 10-minute timeout** during which the *ResetCluster* operation has to be finished. This is the same time frame you have to start the migration (i.e. enter the "install" command in the tool) on all nodes in the cluster. If for some reason the migration cannot be completed within 10 minutes, or if something goes wrong during the migration, all Agents will revert back to using the SLNet-managed NATS solution.<!-- RN 41115 -->

> [!IMPORTANT]
> The NATS configuration (*nats-server.config*) of the NATS instance before the migration is not transferrable to the NATS instance after the migration, so it should **never be copied over**.

## Migrating back to the old system

After you have migrated to BrokerGateway, there are two different ways you can go back to the old system:

- Download and run the package [NATSMigrationRollback.dmupgrade](https://community.dataminer.services/download/natsmigrationrollback-dmupgrade/).

- Follow the same procedure as when you [run the migration manually](#running-the-migration-manually), but use the `uninstall` command instead of the `install` command. In this case, the same restrictions apply as for the migration: this must happen on all DataMiner Agents in the cluster at the same time.

## Updating the Data Aggregator configuration

[Data Aggregator](xref:Data_Aggregator_DxM) can connect to multiple DataMiner Systems. When a specific DMS is migrated to BrokerGateway, any Data Aggregator configuration that connects to this DMS must be [manually updated](xref:Data_Aggregator_settings#dms-with-brokergateway).

## FAQ

### Can I run a cluster with both SLNet-managed NATS and BrokerGateway-managed NATS?

This is not possible. Both NATS installations use the same network ports, so the services cannot run at the same time on a machine. The credentials these installations use are also different and not compatible with each other, so running SLNet-managed NATS on DMA1 and BrokerGateway-managed NATS on DMA2 will also not function.

### Why should I migrate to BrokerGateway? What are the advantages?

BrokerGateway will manage NATS communication based on a single source of truth that has the complete knowledge of the cluster, resulting in more robust, carefree NATS communication. In addition, TLS will be configured automatically, and a newer version of NATS will be used that has better performance and is easier to upgrade.

## Troubleshooting

### ERROR: {machineName} was not able to remove itself from its current cluster in order to join the new cluster

When calling *ResetCluster*, BrokerGateway will first try to remove itself from any cluster it is part of, in order to set up a new cluster with all the endpoints specified in `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json`.

The endpoints BrokerGateway is currently clustered with are listed in the ClusterInfo in `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json`. If one of those IPs cannot be reached, the error message above is generated.

You will be asked if the node may be forcibly removed. If you agree to this, the current machine can free itself from the cluster to cluster with the new setup instead. However, because it forcibly removes itself, it no longer informs any of the unreachable endpoints of its removal. These may still attempt to contact the current machine, which will no longer be reachable for them. If you choose to not allow the forcible removal, this will cancel the migration process and revert back to the previous configuration.<!-- RN 40991 -->

If you do want to migrate to BrokerGateway but you do not want this forced removal, make sure all endpoints specified in *appsettings.runtime.json* can be reached by the current machine.

### NATSRepair.exe

If you encounter issues with your NATS cluster and you have migrated to BrokerGateway, you can run the *NATSRepair.exe* tool from the `C:\Skyline DataMiner\Tools\` folder. This will perform a repair on the cluster.<!-- RN 42328 -->

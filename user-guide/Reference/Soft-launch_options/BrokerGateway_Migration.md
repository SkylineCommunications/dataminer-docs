---
uid: BrokerGateway_Migration
---

# Migrating to BrokerGateway

Starting from DataMiner 10.5.0/10.5.2, migrating from the SLNet-managed NATS solution (NAS and NATS services) to the BrokerGateway-managed NATS solution (nats-server service) is possible as a [soft-launch feature](xref:SoftLaunchOptions), if the [BrokerGateway](xref:Overview_of_Soft_Launch_Options#brokergateway) soft-launch option is enabled.

From DataMiner 10.6.0 onwards, this migration will be done automatically during a DataMiner upgrade.

## Prerequisites

Before you start the migration, the entire cluster must have been running smoothly for some time. This means that all DataMiner Agents in the cluster must be online and function together for some time. To confirm that the DMS is ready to be migrated, run the [Verify NATS Migration Prerequisites](xref:BPA_NATS_Migration_Prerequisites) BPA.

If the BPA succeeds, the system is all set to migrate.

## Running the migration

Currently, this migration is a manual action, which should be done as follows:

1. Make sure the [prerequisites](#prerequisites) are met.

1. Open a **remote desktop connection** to **all** DataMiner Agents at the same time.

1. On each of the machines, open a **command prompt** as administrator, and run the executable **C:\Skyline DataMiner\Tools\NATSMigration.exe**.

   It is important that you use a command prompt to run executable, so its output is not lost when the process finishes.

1. On each machine, enter the `install` command and confirm.

   > [!IMPORTANT]
   > This must happen on **each DMA** in the cluster **within a 10-minute time frame**. It is very important that this happens for **all DataMiner Agents, including Failover DMAs**. The migration needs to write files and restart DataMiner, because a soft-launch flag is adjusted that changes SLNet behavior at startup. As a single instance cannot remotely shut down and restart a DataMiner Agent, this action must be done on each separate Agent in the cluster.

   Successful installation output might look like this:

   ```cmd
   C:\Skyline DataMiner\Tools>NATSMigration.exe
   Warning: This will alter DataMiner NATS configuration.
   This will also restart DataMiner. Continue? (y/n):y
   LAURENSVG.skyline.local - Stopping DataMiner.
   ************  Stopping the DataMiner software   *************

   ...

   (un)install BrokerGateway managed NATS server? (install/uninstall):install
   LAURENSVG.skyline.local - BrokerGateway SoftLaunch flag is set to True.
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

## Actions during the migration

The following actions will be executed during the migration, in the indicated order:

1. DataMiner is stopped.

1. The *BrokerGateway* soft-launch flag in *C:\Skyline DataMiner\SoftLaunchOptions.xml* is set to true.

   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <SLNet>
       <BrokerGateway>true</BrokerGateway>
   </SLNet>
   ```

1. The NAS and NATS services are stopped and their startup type is set to "Manual".

   At a later stage, the Migration tool might delete the services instead.

1. The *ResetCluster* API (*https://\<ip\>/BrokerGateway/api/clusteringapi/resetcluster*) is called on BrokerGateway to create a new NATS cluster, and the NATS binaries are installed at **C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server** and started as a service called "nats-server".

   The *ResetCluster* API call is only executed by one of the NATSMigration instances, if a cluster is migrated. The node that will execute this command is the one with the lowest IP alphabetically. The other nodes will wait until a NATS session using BrokerGateway can be created.

1. The *MessageBrokerConfig.json* file is written at **C:\ProgramData\Skyline Communications\DataMiner\MessageBrokerConfig.json**.

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
> The NATSMigration tool has a **hard-coded 10-minute timeout** during which the *ResetCluster* operation has to be finished. This is the same time frame you have to start the migration (i.e. enter the "install" command in the tool) on all nodes in the cluster.

> [!IMPORTANT]
> The NATS configuration (*nats-server.config*) of the NATS instance before the migration is not transferrable to the NATS instance after the migration, to it should **never be copied over**.

## Migrating back to the old system

After you have migrated to BrokerGateway, to go back ot the old system, follow the same procedure as when you run the migration, but use the `uninstall` command instead of the `install` command.

The same restrictions apply as for the migration: this must happen on all DataMiner Agents in the cluster at the same time.

## FAQ

### Can I run a cluster with both SLNet-managed NATS and BrokerGateway-managed NATS?

This is not possible. Both NATS installations use the same network ports, so the services cannot run at the same time on a machine. The credentials these installations use are also different and not compatible with each other, so running SLNet-managed NATS on DMA1 and BrokerGateway-managed NATS on DMA2 will also not function.

### Why should I migrate to BrokerGateway? What are the advantages of this?

Careless NATS communications managed by a decoupled and robust BrokerGateway based on a Single Source of Truth that has the complete knowledge of the cluster. A newer and more performant NATS version is also used and is easier than ever to upgrade.

## Troubleshooting

### ERROR: {machineName} was not able to remove itself from its current cluster in order to join the new cluster

When calling *ResetCluster*, BrokerGateway will first try to remove itself from any cluster it is part of, in order to set up a new cluster with all the endpoints specified in *ClusterEndpoints.json*.

The endpoints BrokerGateway is currently clustered with are listed in the ClusterInfo in *C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json*. If one of those IPs cannot be reached, the error message above is generated.

By agreeing to forcibly remove itself from this cluster, the current machine can free itself to cluster with the new setup. However, because it forcibly removes itself, it no longer informs any of these unreachable endpoints of its removal. These may still attempt to contact the current machine, which will no longer be reachable for them.

If you do not want this forced removal, make sure all endpoints specified in *appsettings.runtime.json* can be reached by the current machine.

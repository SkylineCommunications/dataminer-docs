---
uid: BrokerGateway_Migration
---

# Migrating to BrokerGateway

Starting from DataMiner 10.5.0, migrating from the SLNet-managed NATS solution (NAS and NATS services) to the BrokerGateway-managed NATS solution (nats-server service) is possible as a soft-launch feature.

From DataMiner 10.6.0 onwards, this migration will be automatically done during upgrade.



## Prerequisites

Before starting the migration, ensure that the entire cluster has been running smoothly for some time. This means that all DMAs (DataMiner Agents) in the DMS (DataMiner System) should have been online and functioning together. To confirm that the DMS is ready to be migrated, run the [Verify NATS Migration Prerequisites](xref:BPA_NATS_Migration_Prerequisites) BPA.

If the BPA succeeds, the system is all set to migrate.

## Migration

Currently this migration is a manual action and can be started by running the executable at **C:\Skyline DataMiner\Tools\NATSMigration.exe** on **ALL** machines in the cluster **at the same time**. This includes all failover agents as well.

> [!NOTE]
> NATSMigration.exe has to be run as administrator and ideally called from command prompt so its output is not lost when the process finishes.

It will ask for some basic input (install/uninstall) and confirmation.

In order to run this tool on all machines in the cluster at the same time, it is recommended to open a remote desktop connection to all machines and have the tool opened and ready on all of them. Then go over them one by one and order the "install" or "uninstall" command to the command line tool. There is a 10 minute timeframe in which this has to happen.

**Q: Why does NATSMigration have to run on all systems at the same time?**

**A:** The migration needs to write files and restart DataMiner since we are enabling/disabling a softlaunch flag which enables/disables behavior in SLNet at startup. A single instance can't remotely shut down and restart a DataMiner, so we need to run on each agent of the cluster.

A successful installation output might look like this:

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

## What does migration do?

First, it will stop DataMiner.

Secondly, it will set the BrokerGateway softlaunch flag to true. This flag can be found in the **C:\Skyline DataMiner\SoftLaunchOptions.xml** file. Content might look like this:

```xml
<?xml version="1.0" encoding="utf-8"?>
<SLNet>
    <BrokerGateway>true</BrokerGateway>
</SLNet>
```

Afterwards, it will write the MessageBrokerConfig.json file at **C:\ProgramData\Skyline Communications\DataMiner\MessageBrokerConfig.json**. This file is used when creating default Sessions using the DataMinerMessageBroker.API(.Native) library. The file will be rewritten to reference the BrokerGateway url and api key path. Content might look similar to this:

```json
{
  "BrokerGatewayConfig": {
    "CredentialsUrl": "https://LAURENSVG.skyline.local/BrokerGateway/api/natsconnection/getnatsconnectiondetails",
    "APIKeyPath": "C:\\Program Files\\Skyline Communications\\DataMiner BrokerGateway\\appsettings.runtime.json"
  }
}
```

Then, the NAS and NATS services will be stopped and their startup type set to "Manual".
At a later stage, the Migration tool might delete the services instead.
The ResetCluster API (https://\<ip\>/BrokerGateway/api/clusteringapi/resetcluster) is called on BrokerGateway to create a new NATS cluster. The NATS binaries will be installed at **C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server** and started as a service called "nats-server".

The ResetCluster API call is only executed by one of the NATSMigration instances, if migrating a cluster.
The node chosen to execute this command is the one with the lowest alphabetical IP. The other nodes will simply wait until a nats session using BrokerGateway can be created.

The NATSMigration tool has a hardcoded 10 minute timeout in which the ResetCluster operation has to finish. This is the same time frame you have to start the migration (enter the "install" command in the tool) on all nodes in the cluster.

> [!NOTE]
> The NATS configuration (nats-server.config) between the 2 instances of NATS (before and after migration) are not transferrable so should never be copied over.

## Migrating back to the old system

After migrating to BrokerGateway, going back is as easy as running **C:\Skyline DataMiner\Tools\NATSMigration.exe** again, but this time selecting "uninstall" when prompted.

Again, this should be run on all agents in the cluster at the same time.

## FAQ

**Q: Can I run a cluster with both SLNet-managed NATS and BrokerGateway-managed NATS?**

**A:** No. Both NATS installations use the same network ports, so the services cannot run at the same time on a machine. The credentials these installations use are also different and not compatible with each other, so running SLNet-managed NATS on DMA1 and BrokerGateway-managed NATS on DMA2 will also not function.

**Q: Why should one go to BrokerGateway? What is the value?**

**A:** Careless NATS communications managed by a decoupled & robust BrokerGateway based on a Single Source of Truth that has the complete knowledge of the cluster. A newer and more performant NATS version is also used and is easier than ever to upgrade.

## Troubleshooting

**ERROR: {machineName} was not able to remove itself from its current cluster in order to join the new cluster.**

When calling ResetCluster, BrokerGateway will first try to remove itself from any cluster it is part of, in order to set up a new cluster with all the endpoints specified in ClusterEndpoints.json.
The current endpoints BrokerGateway is currently clustered with are listed in the ClusterInfo in **C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json**. If one of those IPs cannot be reached, the error message above is thrown.
By agreeing to forcibly remove itself from this cluster, the current machine can free itself to cluster with the new setup, but by forcibly removing itself, it no longer informs any of these unreachable endpoints of its removal. These may still attempt to contact the current machine, which will no longer be reachable for them.
If force removing is not wanted, then all endpoints specified in appsettings.runtime.json need to be made reachable by the current machine.

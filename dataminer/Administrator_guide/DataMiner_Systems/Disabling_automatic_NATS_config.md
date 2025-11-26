---
uid: Disabling_automatic_NATS_config
---

# Disabling automatic NATS configuration

## BrokerGateway-managed NATS

> [!IMPORTANT]
> Automatic NATS configuration must either be consistently enabled in the entire cluster or disabled in the entire cluster. You cannot have part of the cluster rely on automatic NATS configuration and the other part on manual configuration.

> [!CAUTION]
> If you disable automatic NATS configuration, this means **you become responsible for maintaining the configuration** of the `appsettings.runtime.json` and `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server\nats-server.config` files, and you will need to ensure the synchronization of the credentials in the system.

Starting from DataMiner 10.5.0 [CU1]/10.5.4<!-- RN 41948 -->, it is possible to apply a manual NATS configuration when required. This is intended for scenarios where specific system characteristics, like high latency between nodes or geographically dispersed DataMiner Agents, necessitate a custom NATS layout.

Setting up BrokerGateway with a custom manual config will allow you to create superclusters and/or leaf nodes:

- A **cluster** consists of all the nodes that are closely related by location. They should have low latency and high bandwidth between each other.

- A **supercluster** is a collection of different clusters that can communicate with each other. It consists of two or more clusters. Clusters communicate with other clusters using gateway connections (port 7222). Each cluster consists of two or more nodes. These nodes communicate with each other using cluster connections (port 6222).

- A **leaf node** is a node that is related to a specific cluster, but has a higher latency and/or lower bandwidth to the nodes of the actual cluster. Optionally, a cluster can have one or more leaf nodes attached to it. A leaf node communicates with the rest of the cluster using a specific leaf node connection (port 7422).

### Setting up a manual config

1. Enable manual configuration by sending a POST request to `https://[ip]/BrokerGateway/api/clusteringapi/setmanualconfigflag` with the following request body:

   ```json
   {
     "distribute_in_cluster": true,
     "has_manual_config": true
   }
   ```

   Make sure the request includes a **valid BrokerGateway API key** in the `BrokerGateway-Api-Key` HTTP header. This Administrator key can be found in `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json`.

   Note that `distribute_in_cluster` must be set to *true* to ensure that the configuration flag is automatically propagated to all nodes in the cluster.

1. Apply a custom config by sending a POST request to `https://[ip]/BrokerGateway/api/clusteringapi/applymanualconfig` using a request body that contains the full cluster config.

   Below is an example for a supercluster consisting of two clusters with leaf nodes:

   ```json
   {
     "regions": [
     {
       "name": "Cluster1",
       "nodes": [
       {
         "endpoint": "DMA1",
         "bgw_api_key": "BGW_API_KEY_1",
         "is_leaf": false,
         "should_run_nats_node": true,
         "additional_endpoints": []
       },
       {
         "endpoint": "DMA2",
         "bgw_api_key": "BGW_API_KEY_2",
         "is_leaf": false,
         "should_run_nats_node": true,
         "additional_endpoints": []
       },
       {
         "endpoint": "DMA3",
         "bgw_api_key": "BGW_API_KEY_3",
         "is_leaf": false,
         "should_run_nats_node": true,
         "additional_endpoints": []
       },
       {
         "endpoint": "LeafNode1",
         "bgw_api_key": "LeafNode_BGW_API_KEY_1",
         "is_leaf": true,
         "should_run_nats_node": true,
         "additional_endpoints": []
       },
       {
         "endpoint": "LeafNode2",
         "bgw_api_key": "LeafNode_BGW_API_KEY_2",
         "is_leaf": true,
         "should_run_nats_node": true,
         "additional_endpoints": []
       }
       ]
     },
     {
       "name": "Cluster2",
       "nodes": [
       {
         "endpoint": "DMA4",
         "bgw_api_key": "BGW_API_KEY_4",
         "is_leaf": false,
         "should_run_nats_node": true,
         "additional_endpoints": []
       },
       {
         "endpoint": "DMA5",
         "bgw_api_key": "BGW_API_KEY_5",
         "is_leaf": false,
         "should_run_nats_node": true,
         "additional_endpoints": []
       },
       {
         "endpoint": "DMA6",
         "bgw_api_key": "BGW_API_KEY_6",
         "is_leaf": false,
         "should_run_nats_node": true,
         "additional_endpoints": []
       },
       {
         "endpoint": "LeafNode3",
         "bgw_api_key": "LeafNode_BGW_API_KEY_3",
         "is_leaf": true,
         "should_run_nats_node": true,
         "additional_endpoints": []
       }
       ]
     }
     ]
   }
   ```

   Each node requires the *bgw_api_key* of that BrokerGateway node. This can be found on that server in `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json`. Use the API key with the role "BrokerGateway" on the specific node.

   The `additional_endpoints` property allows you to specify extra endpoints that BrokerGateway must include when generating NATS certificates. This is required when adding nodes that are part of a Failover pair; in such cases, the Failover VIP or shared hostname should be listed here.

   The `should_run_nats_node` property is currently non-functional but may be used in future releases.

### Deconstructing the manual config

1. Look up the BrokerGateway API key in `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json`.

   You will need to use this Administrator key in the *BrokerGateway-Api-Key* HTTP header of the request mentioned below.

1. Disable manual configuration by sending a POST request to `https://[ip]/BrokerGateway/api/clusteringapi/setmanualconfigflag` with the following request body:

   ```json
   {
     "distribute_in_cluster": true,
     "has_manual_config": false
   }
   ```

1. Run [NATSRepair.exe](xref:Investigating_NATS_Issues#resetting--repairing-the-brokergateway-nats-cluster) to reset your NATS cluster to the default state.

## Legacy SLNet-managed NAS/NATS

From DataMiner 10.2.0 [CU6]/10.2.8 onwards, you can enable the *NATSForceManualConfig* option so that NATS is not automatically configured in your DataMiner System. When you do so, you will need to configure a NATS cluster manually. There are two distinct methods to enable *NATSForceManualConfig*:

- For all DMAs in the cluster [via SLNetClientTestTool](#disabling-automatic-nats-configuration-via-slnetclienttesttool) (recommended).
- For one DMA at a time [by changing *MaintenanceSettings.xml*](#disabling-automatic-nats-configuration-via-maintenancesettingsxml).

> [!IMPORTANT]
> Automatic NATS configuration must either be consistently enabled in the entire cluster or disabled in the entire cluster. You cannot have part of the cluster rely on automatic NATS configuration and the other part on manual configuration.

> [!CAUTION]
> If you disable automatic NATS configuration, this means **you become responsible for maintaining the configuration** of the [*SLCloud.xml*](xref:SLCloud_xml), [*nas.config*](xref:Investigating_Legacy_NATS_Issues#nasconfig), and [*nats-server.config*](xref:Investigating_Legacy_NATS_Issues#nats-serverconfig) files as well as ensuring the synchronization of the credentials in the system. From DataMiner 10.3.11/10.3.0 [CU8] onwards<!--RN 37401-->, when DataMiner makes changes to any of these files, the old version of that file is saved in the `C:\Skyline DataMiner\Recycle Bin`folder.

> [!NOTE]
> Changes to the *NATSForceManualConfig* option are included in a DataMiner backup to make sure that the automatic NATS configuration status remains consistent after a backup is restored. From DataMiner 10.4.11/10.5.0 onwards<!--RN 40812-->, any changes made to the *nats-server.config* file after disabling automatic NATS configuration will also be included in DataMiner backups. Prior to this, you need to manually back up the *nats-server.config* file, located in the `C:\Skyline DataMiner\NATS\nats-streaming-server\` folder. See [nats-server.config file not included in DataMiner backups](xref:KI_nats-server_config_file_not_included_in_backups).

### Disabling automatic NATS configuration via SLNetClientTestTool

To disable automatic NATS configuration for the entire cluster in one go when legacy SLNet-managed NAS/NATS is used:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. In the dropdown box, select *NATSForceManualConfig*.

1. Configure the option as follows for each DMA in the cluster:

   1. Right-click the DMA and select *Edit value*.

   1. Specify *true* and click *OK*.

1. Click *OK* to close the *SLNet Options* window.

The entire cluster should now be configured, **except for offline Failover Agents**. In case you are configuring a DMS with Failover, also configure the offline Agents one by one by [changing *MaintenanceSettings.xml*](#disabling-automatic-nats-configuration-via-maintenancesettingsxml)

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

### Disabling automatic NATS configuration via MaintenanceSettings.xml

If legacy SLNet-managed NAS/NATS is used, you can disable the automatic NATS configuration for one Agent at a time (or on offline Agents of a Failover pair) as follows:

1. Stop the DataMiner Agent in question.

1. Navigate to `C:\Skyline DataMiner\MaintenanceSettings.xml` and add the *NATSForceManualConfig* tag within the *SLNet* tag.

   Create the SLNet tag if it does not exist yet.

   ```xml
   <SLNet>
   <NATSForceManualConfig>true</NATSForceManualConfig>
   </SLNet>
   ```

1. Start DataMiner.

1. Repeat this process for every Agent in the cluster (or every offline Failover Agent in the DMS in case you have already disabled automatic NATS configuration for the other Agents using SLNetClientTestTool).

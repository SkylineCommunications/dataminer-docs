---
uid: Changing_the_IP_of_a_DMA
keywords: hardware migration
---

# Changing the IP of a DMA

The way you can change the IP of a DMA depends on how your DataMiner System is set up. It is different for a standalone DMA, a DMA in a DMS, a Failover DMA in a DMS, and a DMA in a DMS using a Cassandra cluster.

## Standalone DMA

For a standalone DMA, i.e. a DMA that is not combined with other DMAs in a cluster:

1. Stop the DataMiner software on the DMA.

1. Change the IP address of the DMA server in Windows.

1. Go to the folder `C:\Skyline DataMiner\` and open the file *DMS.xml*.

1. Locate the old IP address in this file, replace it with the newly configured one if and wherever necessary, and save the file.

1. Go to the folder `C:\Skyline DataMiner\Configurations`. If the file *ClusterEndpoints.json* exists, open it. Otherwise, skip the next step.

1. Locate the old IP address in this file, replace it with the newly configured one if and wherever necessary, and save the file.

1. If you are not using [Storage as a Service (STaaS)](xref:STaaS), and one or more of the databases used by DataMiner is hosted on the same server as DataMiner itself:

   1. Go to the folder `C:\Skyline DataMiner\` and open the file *DB.xml*.

   1. Locate all occurrences of the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

   1. If the server hosts a Cassandra database:

      1. Open the cassandra.yaml file (typically located in the folder `C:\Program Files\Cassandra\conf\`).

      1. Replace any references to the old IP address with the new IP address, and save the file.

      1. Restart the cassandra service.

   1. If the server hosts an OpenSearch database:

      1. Open the opensearch.yml file (typically located in the folder `C:\Program Files\opensearch\config\`).

      1. Replace any references to the old IP address with the new IP address, and save the file.

      1. Restart the Java.exe service located under the *Details* tab in the Task Manager.

   1. If the server hosts an Elasticsearch database:

      1. Open the elasticsearch.yml file (typically located in the folder `C:\Program Files\Elasticsearch\config\`).

      1. Replace any references to the old IP address with the new IP address, and save the file.

      1. Restart the elasticsearch-service-x64 service.

1. In the *Windows Services* app, if the **NATS** service is installed and *Running*, perform the following steps.

   If instead the **nats-server** service is installed and *Running*, skip these steps.

   1. Open the file *SLCloud.xml*, located in the folder `C:\Skyline DataMiner\`.

   1. Replace any references to the old IP address with the new IP address, and save the file.

   1. Uninstall NAS and NATS:

      1. Go to `C:\Skyline DataMiner\Files\` and double-click *SLEndpointTool_Console.exe*.

      1. Press U to confirm that you want to uninstall NAS and NATS.

      1. Press Enter twice, enter NAS, and press Y.

   1. Install NAS and NATS again:

      1. Go to `C:\Skyline DataMiner\Files\` and double-click *SLEndpointTool_Console.exe*.

      1. Press I to confirm that you want to install NAS and NATS

      1. Press Enter twice, enter NATS, and press Y.

1. In the "Windows Services" app, if the "nats-server" service is installed and *Running*, perform the following steps. If, on the contrary the "NATS" service is installed and *Running*, skip this step.

   1. Open the *appsettings.runtime.json* file, located in the folder `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\`.

   1. Replace any references to the old IP address with the new IP address, and save the file.
  
   1. Open the *nats-server.config* file, located in the folder `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server\`.

   1. Replace any references to the old IP address with the new IP address, and save the file.

   1. Restart the nats-server service.

   1. Restart the DataMiner BrokerGateway service.

1. Uninstall and then re-install the [APIGateway Extension Module](xref:DataMinerExtensionModules##apigateway), found in `C:\Skyline DataMiner\Tools\ModuleInstallers\` to regenerate the SSL certificate.

1. If your DataMiner Agent is connected to dataminer.services, restart all [DataMiner Extension Modules](xref:DataMinerExtensionModules).

1. Restart DataMiner.

> [!NOTE]
> If the DataMiner System uses a remote database, the database configuration changes detailed above are not needed. In such a case, the IPs are not affected, because the remote server remains the same in the .yml file and in DB.xml. However, you must make sure that all the necessary ports are open and accessible. See [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

## Single DMA in a DMS

For a single DMA within a cluster that either uses [Storage as a Service (STaaS)](xref:STaaS) or makes use of a [Cassandra database per DMA](xref:Configuring_storage_per_DMA#cassandra-database-per-dma):

1. Stop the DataMiner software on the DMA for which you want to change the IP.

1. Change the IP address of the DMA server in Windows.

1. Go to the folder `C:\Skyline DataMiner\` and open the file *DMS.xml*.

1. Locate the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

1. Go to the folder `C:\Skyline DataMiner\Configurations`. If the file *ClusterEndpoints.json* exists, open it. Otherwise, skip the next step.

1. Locate the old IP address in this file, replace it with the newly configured one if and wherever necessary, and save the file.

   This action will need to be repeated for all Agents in the cluster, including offline Failover Agents.

1. If you are not using [Storage as a Service (STaaS)](xref:STaaS), and one or more of the databases used by DataMiner is hosted on the same server as DataMiner itself:

   1. Go to the folder `C:\Skyline DataMiner\` and open the file *DB.xml*.

   1. Locate all occurrences of the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

   1. If the server hosts a Cassandra database:

      1. Open the cassandra.yaml file (typically located in the folder `C:\Program Files\Cassandra\conf\`).

      1. Replace any references to the old IP address with the new IP address, and save the file.

      1. Restart the cassandra service.

   1. If the server hosts an OpenSearch database:

      1. Open the opensearch.yml file (typically located in the folder `C:\Program Files\opensearch\config\`).

      1. Replace any references to the old IP address with the new IP address, and save the file.

      1. Restart the Java.exe service located under the *Details* tab in the Task Manager.

   1. If the server hosts an Elasticsearch database:

      1. Open the elasticsearch.yml file (typically located in the folder `C:\Program Files\Elasticsearch\config\`).

      1. Replace any references to the old IP address with the new IP address, and save the file.

      1. Restart the elasticsearch-service-x64 service.

1. In the *Windows Services* app, if the **NATS** service is installed and *Running*, perform the following steps on the DMA where you wish to swap IPs.

   If instead the **nats-server** service is installed and *Running*, skip these steps.

   1. Open the file *SLCloud.xml*, located in the folder `C:\Skyline DataMiner\`.

   1. Replace any references to the old IP address with the new IP address, and save the file.

   1. Uninstall NAS and NATS:

      1. Go to `C:\Skyline DataMiner\Files\` and double-click *SLEndpointTool_Console.exe*.

      1. Press U to confirm that you want to uninstall NAS and NATS.

      1. Press Enter twice, enter NAS, and press Y. (This will uninstall both NATS and NAS)

   1. Install NAS and NATS again:

      1. Go to `C:\Skyline DataMiner\Files\` and double-click *SLEndpointTool_Console.exe*.

      1. Press I to confirm that you want to install NAS and NATS.

      1. Press Enter twice, enter NATS, and press Y.

         This will install both NAS and NATS.

1. In the "Windows Services" app, if the "nats-server" service is installed and *Running*, perform the following steps on all **DataMiner agents in the DMS**. If, on the contrary the "NATS" service is installed and *Running*, skip this step.

   1. Open the *appsettings.runtime.json* file, located in the folder `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\`.

   1. Replace any references to the old IP address with the new IP address, and save the file.

   1. Open the *nats-server.config* file, located in the folder `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server\`.

   1. Replace any references to the old IP address with the new IP address, and save the file.

      The IP address will need to be replaced in the following places in the file:

      - cluster.routes
      - cluster.advertise (only on the server where the IP was changed)
      - client_advertise (only on the server where the IP was changed)

   1. Restart the nats-server service.

   1. Restart the DataMiner BrokerGateway service.

1. Uninstall and then re-install the [APIGateway Extension Module](xref:DataMinerExtensionModules##apigateway), found in `C:\Skyline DataMiner\Tools\ModuleInstallers\` to regenerate the SSL certificate.

1. If your DataMiner Agent is connected to dataminer.services, restart all [DataMiner Extension Modules](xref:DataMinerExtensionModules).

1. Restart DataMiner.

1. In System Center, go to the Agents page and remove the old IP address from the list of DMAs in the cluster.

1. In the *Windows Services* app, if the **NATS** service is installed and *Running*, perform the following steps on the DMA where you wish to swap IPs.

   If instead the **nats-server** service is installed and *Running*, skip these steps.

   1. Open the SLNetClientTest tool. See [Opening the SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

      > [!WARNING]
      > Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

   1. Connect to the DMA with the changed IP address. See [Connecting to a DMA with the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

   1. Go to the *Build Message* tab of the main window of the SLNetClientTest tool.

   1. In the *Message Type* dropdown list, select *Skyline.DataMiner.Net.Apps.NATSCustodian.NATSCustodianResetNatsRequest* and click *Send Message*.

      > [!NOTE]
      > Do not send this message if automatic NATS configuration is disabled (with the [NATSForceManualConfig option](xref:Disabling_automatic_NATS_config)). Instead, you will need to reset NATS manually. From DataMiner 10.5.0 [CU1]/10.5.4 onwards, sending this message while automatic NATS configuration is disabled is impossible.<!-- RN 42074 -->

   1. Close the SLNetClientTest tool.
  
   1. On all DMAs in the cluster, navigate to *C:\Skyline DataMiner\SLCloud.xml*, and check if the previous IP address has been replaced by the new IP address.

     Note that it can take up to an hour before this happens. If for any reason the old IP address is still visible in the file after that time, [contact Support](xref:Contacting_tech_support).

> [!NOTE]
> If the DataMiner System uses a remote database, the database configuration changes detailed above are not needed. In such a case, the IPs are not affected, because the remote server remains the same in the .yml file and in DB.xml. However, you must make sure that all the necessary ports are open and accessible. See [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

## Failover DMA in a DMS

For a Failover DMA within a cluster that either uses [Storage as a Service (STaaS)](xref:STaaS) or makes use of a [Cassandra database per DMA](xref:Configuring_storage_per_DMA#cassandra-database-per-dma):

1. Stop the DataMiner software on **both** Failover DMAs.

1. Change the IP address of the DMA server in Windows.

1. If you are not using [Storage as a Service (STaaS)](xref:STaaS), and one or more of the databases used by DataMiner is hosted on the same server as DataMiner itself:

   1. On the DMA of which you have changed the IP, go to the folder `C:\Skyline DataMiner\` and open the file *DB.xml*.

   1. Locate all occurrences of the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

1. On the DMA of which you have changed the IP, go to the folder `C:\Skyline DataMiner\` and open the file *DMS.xml*.

1. Locate the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

1. On the other DMA of the Failover pair, go to the folder `C:\Skyline DataMiner\` and open the file *DMS.xml*.

1. Locate the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

1. Go to the folder `C:\Skyline DataMiner\Configurations`. If the file *ClusterEndpoints.json* exists, open it. Otherwise, skip the next step.

1. Locate the old IP address in this file, replace it with the newly configured one if and wherever necessary, and save the file.

   This action will need to be repeated for all Agents in the cluster, including offline Failover Agents.

1. If the DMAs host a Cassandra database, do the following **on both DMAs**:

   1. Open the cassandra.yaml file (typically located in the folder `C:\Program Files\Cassandra\conf\`).

   1. Replace any references to the old IP address with the new IP address, and save the file.

   1. Restart the cassandra service.

   > [!NOTE]
   > If the IP of both DMAs in the Failover pair is changed, replace both IP addresses in both cassandra.yaml files.

1. If the DMAs host an OpenSearch database, do the following **on both DMAs**:

   1. Open the opensearch.yml file (typically located in the folder `C:\Program Files\opensearch\config\`).

   1. Replace any references to the old IP address with the new IP address, and save the file.

   1. Restart the Java.exe service located under the *Details* tab in the Task Manager.

1. If the DMAs host an Elasticsearch database, do the following **on both DMAs**:

   1. Open the elasticsearch.yml file (typically located in the folder `C:\Program Files\Elasticsearch\config\`).

   1. Replace any references to the old IP address with the new IP address, and save the file.

   1. Restart the elasticsearch-service-x64 service.

1. In the *Windows Services* app, if the **NATS** service is installed and *Running*, perform the following steps on the DMA where you wish to swap IPs.

   If instead the **nats-server** service is installed and *Running*, skip these steps.

   1. Open the file *SLCloud.xml*, located in the folder `C:\Skyline DataMiner\`.

   1. Replace any references to the old IP address with the new IP address, and save the file.

   1. Uninstall NAS and NATS:

      1. Go to `C:\Skyline DataMiner\Files\` and double-click *SLEndpointTool_Console.exe*.

      1. Press U to confirm that you want to uninstall NAS and NATS.

      1. Press Enter twice, enter NAS, and press Y. (This will uninstall both NATS and NAS)

   1. Install NAS and NATS again:

      1. Go to `C:\Skyline DataMiner\Files\` and double-click *SLEndpointTool_Console.exe*.

      1. Press I to confirm that you want to install NAS and NATS.

      1. Press Enter twice, enter NATS, and press Y.

         This will install both NAS and NATS.

1. In the *Windows Services* app, if the **nats-server** service is installed and *Running*, perform the following steps **on all DMAs in the DMS**.

   If instead the **NATS** service is installed and *Running*, skip these steps.

   1. Open the *appsettings.runtime.json* file, located in the folder `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\`.

   1. Replace any references to the old IP address with the new IP address, and save the file.
  
   1. Open the *nats-server.config* file, located in the folder `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server\`.

   1. Replace any references to the old IP address with the new IP address, and save the file.

      The IP address will need to be replaced in the following places in the file:

      - cluster.routes
      - cluster.advertise (only on the server where the IP was changed)
      - client_advertise (only on the server where the IP was changed)

   1. Restart the nats-server service.

   1. Restart the DataMiner BrokerGateway service.

1. Uninstall and then re-install the [APIGateway Extension Module](xref:DataMinerExtensionModules##apigateway), found in `C:\Skyline DataMiner\Tools\ModuleInstallers\` to regenerate the SSL certificate.

1. If your DataMiner Agent is connected to dataminer.services, restart all [DataMiner Extension Modules](xref:DataMinerExtensionModules).

1. Restart DataMiner on the DMA with the changed IP address.

1. Restart DataMiner on the other Failover DMA. It should start up in offline mode.

1. On the online DMA, go to System Center \> Agents, and remove the old IP address from the list of DMAs in the cluster.

1. Still on the *Agents* page in System Center, make sure the online Failover DMA is selected in the list on the left, and click the *Failover* button in the lower-right corner to check the Failover status. For more information, see [Viewing the current Failover DMA status](xref:Viewing_the_current_Failover_DMA_status).

1. In case the Failover status is not green and there are heartbeat errors, stop DataMiner, and double-check the DMS.xml files of both DMAs to make sure all references to the old IP address have been correctly replaced.

1. In the *Windows Services* app, if the **NATS** service is installed and *Running*, perform the following steps on the DMA where you wish to swap IPs.

   If instead the **nats-server** service is installed and *Running*, skip these steps.

   1. Open the SLNetClientTest tool. See [Opening the SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

      > [!WARNING]
      > Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

   1. Connect to the DMA with the changed IP address. See [Connecting to a DMA with the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

   1. Go to the *Build Message* tab of the main window of the SLNetClientTest tool.

   1. In the *Message Type* dropdown list, select *Skyline.DataMiner.Net.Apps.NATSCustodian.NATSCustodianResetNatsRequest* and click *Send Message*.

      > [!NOTE]
      > > Do not send this message if automatic NATS configuration is disabled (with the [NATSForceManualConfig option](xref:Disabling_automatic_NATS_config)). Instead, you will need to reset NATS manually. From DataMiner 10.5.0 [CU1]/10.5.4 onwards, sending this message while automatic NATS configuration is disabled is impossible.<!-- RN 42074 -->

   1. Close the SLNetClientTest tool.

   1. On all DMAs in the cluster, navigate to `C:\Skyline DataMiner\SLCloud.xml` and check if the previous IP address has been replaced by the new IP address.

      Note that it can take up to an hour before this happens. If for any reason the old IP address is still visible in the file after that time, [contact Support](xref:Contacting_tech_support).

> [!NOTE]
> If the DataMiner System uses a remote database, the database configuration changes detailed above are not needed. In such a case, the IPs are not affected, because the remote server remains the same in the .yml file and in DB.xml. However, you must make sure that all the necessary ports are open and accessible. See [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

## DMA in a DMS using a Cassandra cluster locally

If your DataMiner System uses the Cassandra cluster feature for its general database (i.e. one Cassandra cluster for the entire DMS), but Cassandra is hosted on the same machine as DataMiner (which is not recommended), follow the procedure below to alter both the IP address of the DMA and the databases.

1. Stop the Cassandra and OpenSearch/Elasticsearch services on the DMA server.

1. Continue the IP migration by following one of the following procedures, but substitute the step starting with "If you are not using Storage as a Service (STaaS), and one or more of the databases used by DataMiner is hosted on the same server as DataMiner itself:" with the steps outlined below. Make sure you pick the correct procedure for your situation.

    - [Standalone DMA](#standalone-dma)
    - [Single DMA in a DMS](#single-dma-in-a-dms)
    - [Failover DMA in a DMS](#failover-dma-in-a-dms)

1. Locate the file *cassandra.yaml* on the DMA. By default, it is located in the folder `C:\Program Files\Cassandra\conf\`.

1. Open *cassandra.yaml* in a text editor (as Administrator) and replace the IP address in the following lines with the IP of the server:

   ```txt
   listen_address: new IP
   - seeds: "new IP (, IP Cassandra node 2, IP Cassandra node 3, ...)"
    broadcast_rpc_address: new IP
   ```

1. Restart the Cassandra service.

1. In a command window, execute *nodetool status* (from the directory `C:\Program Files\Cassandra\bin\`), in order to check the status of the cluster. this should result in a list with your new IP, your old IP and all other Cassandra nodes on the server. For example:

   ![Example of the nodetool status resuls](~/dataminer/images/nodetoolstatus.png)

1. In the same command window, execute *nodetool removenode \[host ID of the old IP\]*, e.g. *nodetool removenode 35506039-0f03-4a1e-8642-94484d440116*.

1. Locate the *cassandra.yaml* files on the other DMAs in the DMS, as described above, and replace any occurrences of the old IP address in the seeds list in these files with the new IP address.

1. If OpenSearch is used as the indexing database:

   1. Locate the file *opensearch.yml* on the DMA of which you have changed the IP. By default, it is located in the folder `C:\Program Files\opensearch\conf\`.

   1. Open *opensearch.yml* in a text editor (as Administrator) and replace the IP address in the following lines with the IP of the server:

      ```txt
      discovery.zen.ping.unicast.hosts: ["new IP (, IP Cassandra node 2, IP Cassandra node 3, ...)"]
      network.publish_host: new IP
      ```

   1. Restart the Java.exe service located under the *Details* tab in the Task Manager.

   1. Locate the *opensearch.yml* files on the other DMAs in the DMS, as described above, and replace any occurrences of the old IP address in the *discovery.zen.ping.unicast.hosts* field of these files with the new IP address.

1. If Elasticsearch is used as the indexing database:

   1. Locate the file *Elasticsearch.yml* on the DMA of which you have changed the IP. By default, it is located in the folder `C:\Program Files\Elasticsearch\conf\`.

   1. Open *Elasticsearch.yml* in a text editor (as Administrator) and replace the IP address in the following lines with the IP of the server:

      ```txt
      discovery.zen.ping.unicast.hosts: ["new IP (, IP Cassandra node 2, IP Cassandra node 3, ...)"]
      network.publish_host: new IP
      ```

   1. Restart the Elasticsearch service.

   1. Locate the *Elasticsearch.yml* files on the other DMAs in the DMS, as described above, and replace any occurrences of the old IP address in the *discovery.zen.ping.unicast.hosts* field of these files with the new IP address.

1. Open the file *DB.xml* from the `C:\Skyline DataMiner\` folder of the DMA with the new IP, and replace the old IP in the DB tags for the Cassandra and OpenSearch/Elasticsearch databases with the new IP address.

   > [!TIP]
   > See also: [DB.xml](xref:DB_xml#dbxml)

1. Open the file *DB.xml* for all other DMAs in the DMS, and replace the old IP address with the new IP address for both Cassandra and OpenSearch/Elasticsearch.

1. Continue the procedure relevant for you, i.e. [Standalone DMA](#standalone-dma), [Single DMA in a DMS](#single-dma-in-a-dms), or [Failover DMA in a DMS](#failover-dma-in-a-dms), starting from the step after "If you are not using Storage as a Service (STaaS), and one or more of the databases used by DataMiner is hosted on the same server as DataMiner itself:".

> [!TIP]
> See also: [Migrating the general database to a DMS Cassandra cluster](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster)

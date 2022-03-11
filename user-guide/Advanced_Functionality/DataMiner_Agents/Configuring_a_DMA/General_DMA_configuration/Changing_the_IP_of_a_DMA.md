---
uid: Changing_the_IP_of_a_DMA
---

# Changing the IP of a DMA

The way you can change the IP of a DMA depends on how your DataMiner System is set up. It is different for a standalone DMA, a DMA in a DMS, a Failover DMA in a DMS, and a DMA in a DMS using a Cassandra cluster.

## Standalone DMA

For a standalone DMA, i.e. a DMA that is not combined with other DMAs in a cluster:

1. Stop the DataMiner software on the DMA.

2. Change the IP address of the DMA server in Windows.

3. Go to the folder *C:\\Skyline DataMiner* and open the file *DB.xml*.

4. Locate the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

5. If the server hosts a Cassandra database:

   1. Open the cassandra.yaml file (typically located in the folder *C:\\Program Files\\Cassandra\\conf\\*).

   2. Replace any references to the old IP address with the new IP address, and save the file.

   3. Restart the cassandra service.

6. If the server hosts an Elasticsearch database:

   1. Open the elasticsearch.yml file (typically located in the folder *C:\\Program Files\\Elasticsearch\\config\\*).

   2. Replace any references to the old IP address with the new IP address, and save the file.

   3. Restart the elasticsearch-service-x64 service.

7. If the server has NATS installed:

   1.  Open the SLCloud.xml, located in the folder *C:\\Skyline DataMiner\\*.

   2.  Replace any references to the old IP address with the new IP address, and save the file.

8. Restart DataMiner.

## Single DMA in a DMS

For a single DMA within a cluster that does not use the Cassandra cluster feature (i.e. one Cassandra cluster for the entire DMS):

1. Stop the DataMiner software on the DMA for which you want to change the IP.

2. Change the IP address of the DMA server in Windows.

3. Go to the folder *C:\\Skyline DataMiner* and open the file *DMS.xml*.

4. Locate the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

5. Go to the folder *C:\\Skyline DataMiner* and open the file *DB.xml*.

6. Locate the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

7. If the server hosts a Cassandra database:

   1. Open the cassandra.yaml file (typically located in the folder *C:\\Program Files\\Cassandra\\conf\\*).

   2. Replace any references to the old IP address with the new IP address, and save the file.

   3. Restart the cassandra service.

8. If the server hosts an Elasticsearch database:

   1. Open the elasticsearch.yml file (typically located in the folder *C:\\Program Files\\Elasticsearch\\config\\*).

   2. Replace any references to the old IP address with the new IP address, and save the file.

   3. Restart the elasticsearch-service-x64 service.

9. If the server has NATS installed:

   1.  Open the SLCloud.xml, located in the folder *C:\\Skyline DataMiner\\*.

   2.  Replace any references to the old IP address with the new IP address, and save the file.

10. Restart DataMiner.

11. In System Center, go to the Agents page and remove the old IP address from the list of DMAs in the cluster.

12. From DataMiner 10.1.1 onwards, the following additional step is required in order to reset NATS:

   1. Open the SLNetClientTest tool. See [Opening the SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

      > [!WARNING]
      > Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

   2. Connect to the DMA with the changed IP address. See [Connecting to a DMA with the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

   3. Go to the *Build Message* tab of the main window of the SLNetClientTest tool.

   4. In the *Message Type* drop-down list, select *Skyline.DataMiner.Net.Apps.NATSCustodian.NATSCustodianResetNatsRequest* and click *Send Message*.

   5. Close the SLNetClientTest tool.

## Failover DMA in a DMS

For a Failover DMA within a cluster that does not use the Cassandra cluster feature (i.e. one Cassandra cluster for the entire DMS):

1. Stop the DataMiner software on **both** Failover DMAs.

2. Change the IP address of the DMA server in Windows.

3. On the DMA of which you have changed the IP, go to the folder *C:\\Skyline DataMiner* and open the file *DB.xml*.

4. Locate the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

5. On the DMA of which you have changed the IP, go to the folder *C:\\Skyline DataMiner* and open the file *DMS.xml*.

6. Locate the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

7. On the other DMA of the Failover pair, go to the folder *C:\\Skyline DataMiner* and open the file *DMS.xml*.

8. Locate the old IP address in this file, replace it with the newly configured one wherever necessary, and save the file.

9. If the DMAs hosts a Cassandra database, do the following on both DMAs:

   1. Open the cassandra.yaml file (typically located in the folder *C:\\Program Files\\Cassandra\\conf\\*).

   2. Replace any references to the old IP address with the new IP address, and save the file.

   3. Restart the cassandra service.

10. If the DMAs hosts an Elasticsearch database, do the following on both DMAs:

   1. Open the elasticsearch.yml file (typically located in the folder *C:\\Program Files\\Elasticsearch\\config\\*).

   2. Replace any references to the old IP address with the new IP address, and save the file.

   3. Restart the elasticsearch-service-x64 service.

11. Restart DataMiner on the DMA with the changed IP address.

12. Restart DataMiner on the other Failover DMA. It should start up in offline mode.

13. On the online DMA, go to System Center \> Agents, and remove the old IP address from the list of DMAs in the cluster.

14. Still on the *Agents* page in System Center, make sure the online Failover DMA is selected in the list on the left, and click the *Failover* button in the lower right corner to check the Failover status. For more information, see [Viewing the current Failover DMA status](xref:Viewing_the_current_Failover_DMA_status).

15. In case the Failover status is not green and there are heartbeat errors, stop DataMiner, and double-check the DMS.xml files of both DMAs to make sure all references to the old IP address have been correctly replaced.

16. From DataMiner 10.1.1 onwards, the following additional step is required in order to reset NATS:

   1. Open the SLNetClientTest tool. See [Opening the SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

      > [!WARNING]
      > Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

   2. Connect to the DMA with the changed IP address. See [Connecting to a DMA with the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

   3. Go to the *Build Message* tab of the main window of the SLNetClientTest tool.

   4. In the *Message Type* drop-down list, select *Skyline.DataMiner.Net.Apps.NATSCustodian.NATSCustodianResetNatsRequest* and click *Send Message*.

   5. Close the SLNetClientTest tool.

## DMA in a DMS using a Cassandra cluster

If your DataMiner System uses the Cassandra cluster feature for its general database (i.e. one Cassandra cluster for the entire DMS), follow the procedure below to change the IP of one of the DMAs in the DMS:

1. Stop the DMA of which you want to change the IP.

2. Stop the Cassandra and Elasticsearch services on the DMA server.

3. Change the IP address of the DMA server in Windows.

4. Locate the file *cassandra.yaml* on the DMA. By default, it is located in the folder *C:\\Program Files\\Cassandra\\conf*.

5. Open *cassandra.yaml* in a text editor (as Administrator) and replace the IP address in the following lines with the IP of the server:

   ```txt
   listen_address: new IP
   - seeds: "new IP (, IP Cassandra node 2, IP Cassandra node 3, ...)"
    broadcast_rpc_address: new IP
   ```

6. Restart the Cassandra service.

7. In a command window, execute *nodetool status* (from the directory *C:\\Program Files\\Cassandra\\bin*), in order to check the status of the cluster. this should result in a list with your new IP, your old IP and all other Cassandra nodes on the server. For example:

   ![Example of the nodetool status resuls](~/user-guide/images/nodetoolstatus.png)

8. In the same command window, execute *nodetool removenode \[host ID of the old IP\]*, e.g. *nodetool removenode 35506039-0f03-4a1e-8642-94484d440116*.

9. Locate the *cassandra.yaml* files on the other DMAs in the DMS, as described above, and replace any occurrences of the old IP address in the seeds list in these files with the new IP address.

10. Locate the file *Elasticsearch.yml* on the DMA of which you have changed the IP. By default, it is located in the folder *C:\\Program Files\\Elasticsearch\\conf*.

11. Open *Elasticsearch.yml* in a text editor (as Administrator) and replace the IP address in the following lines with the IP of the server:

   ```txt
   discovery.zen.ping.unicast.hosts: ["new IP (, IP Cassandra node 2, IP Cassandra node 3, ...)"]
   network.publish_host: new IP
   ```

12. Restart the Elasticsearch service.

13. Locate the *Elasticsearch.yml* files on the other DMAs in the DMS, as described above, and replace any occurrences of the old IP address in the *discovery.zen.ping.unicast.hosts* field of these files with the new IP address.

14. Open the file *DB.xml* from the Skyline DataMiner folder of the DMA with the new IP, and replace the old IP in the DB tags for the Cassandra and Elasticsearch databases with the new IP address.

   > [!TIP]
   > See also: [DB.xml](xref:DB_xml#dbxml)

15. Open the file DB.xml for all other DMAs in the DMS, and replace the old IP address with the new IP address for both Cassandra and Elasticsearch.

16. Restart DataMiner.

17. Reset NATS:

   1. Open the SLNetClientTest tool. See [Opening the SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

      > [!WARNING]
      > Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

   2. Connect to the DMA with the changed IP address. See [Connecting to a DMA with the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

   3. Go to the *Build Message* tab of the main window of the SLNetClientTest tool.

   4. In the *Message Type* drop-down list, select *Skyline.DataMiner.Net.Apps.NATSCustodian.NATSCustodianResetNatsRequest* and click *Send Message*.

   5. Close the SLNetClientTest tool.

> [!TIP]
> See also: [Migrating the general database to a DMS Cassandra cluster](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster)

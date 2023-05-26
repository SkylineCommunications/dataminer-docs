---
uid: Installing_Elasticsearch_on_Linux
---

# Installing Elasticsearch on a Linux machine

If you want to use an Elasticsearch cluster for your DMS (which is required to use the [Cassandra Cluster](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster) feature), install Elasticsearch on a Linux machine as detailed below.

> [!NOTE]
> We promote the use of Ubuntu LTS as the preferred Linux distribution. As such, the commands mentioned below will work on any Debian-based system, including Ubuntu.

1. Install the Elasticsearch software on  the Linux machine as described under [Installing Elasticsearch with Debian Package](https://www.elastic.co/guide/en/elasticsearch/reference/current/deb.html) in the official Elasticsearch documentation.

1. Mount the data folder to the data disk.

   > [!NOTE]
   >
   > - The folder where the Elasticsearch data is stored is configured in *elasticsearch.yaml*, in the property *path.data*.
   > - To verify on which disk the data is mounted, execute the "df" command.

1. Configure the user rights for the Elasticsearch user/group in the data folder.

   You can do this with the following command:

   `$ chown -R elasticsearch:elasticsearch /directoryname_from_path.data`

1. Configure the *elasticsearch.yml* files.

   - Make sure the Elasticsearch service is stopped. To stop the Elasticsearch service, use the following command:

     `$ sudo systemctl stop elasticsearch.service`

   - To change *elasticsearch.yml* files, you can use the following command:

     `$ vi /etc/elasticsearch/elasticsearch.yml`
     
> [!TIP]
> To know more about vi editor visit What is vi(https://www.cs.colostate.edu/helpdocs/vi.html).

   - Make the following adjustments in the *elasticsearch.yml* file based on your setup:

     - **cluster.name**: This needs to be the same for all nodes in your Elasticsearch cluster.

     - **node.name**: The name of the Elasticsearch node.

     - **path.data**: The location(s) where you want to store the data.

     - **path.repo**: The location(s) where you want to store the Snapshots.
     
     > [!TIP]
     > For information about taking and restoring snapshots, refer to Taking and Restoring Snapshots(xref:Configuring_Elasticsearch_backups_Windows_Linux)

     - **bootstrap.memory_lock**: Set this to *true*.

     - **network.host**: The IP address of the node.

     - **http.port**: Set this to *9200*.

     - **discovery.zen.ping.unicast.hosts**: The IP addresses of all the nodes in your Elasticsearch cluster. Elasticsearch nodes use this list of hosts to find each other and learn the topology of the ring.

       > [!NOTE]
       >
       > - We recommend a cluster of minimum three nodes, preferably in different racks.
       > - To add a node to an existing cluster, see [Adding an Elasticsearch cluster node](xref:Configuring_Elasticsearch_node_add).

     - **discovery.zen.minimum_master_nodes**: see [Configuring the master nodes](xref:Configuring_master_Elasticsearch_nodes).

     - **gateway.recover_after_nodes**: See [Configuring the master nodes](xref:Configuring_master_Elasticsearch_nodes).

     - **node.master**: See [Configuring the master nodes](xref:Configuring_master_Elasticsearch_nodes).

1. Make the following adjustments in */etc/sysconfig/elasticsearch*:

   - **MAX_LOCKED_MEMORY**: Set this to *unlimited*.

   - **JAVA_HOME**: Set this to the custom Java path to be used for Elasticsearch, e.g. *java-11-openjdk-11.0.14.0.9-1.el7_9.x86_64*.

1. Make the following adjustment in */usr/lib/systemd/system/elasticsearch.service*:

   - **LimitMEMLOCK**: Set this to *infinity*. This must be set under the *Service* tag.

1. Set the maximum Java Heap Size under */etc/elasticsearch/jvm.options*. For more information, see [Setting the heap size](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/heap-size.html).

       > [!NOTE]
       >
       > - Elasticsearch uses quite a bit of memory and atleat 8Gb of Heap size should be specified, more could be required depending on the system demands. 

1. Start Elasticsearch and evaluate if the service is up and running.

   - To start Elasticsearch, use the following command:

     `$ systemctl start elasticsearch.service`

   - To check if the Elasticsearch service is running, check the logs under */var/log/elasticsearch/* or send an HTTP request to **NodeIP:9200**.

     The HTTP request response should be as follows:

     ![Elasticsearch example](~/user-guide/images/Elasticsearch_example.png)

   - Connect to one of the nodes using a web browser, and check the cluster status by going to `http://<NodeIP>:9200/_cluster/state?pretty`.

     The response should be as follows:

     ![Elasticsearch example1](~/user-guide/images/Elasticsearch_example1.png)

   - To check the cluster health status, go to `http://<NodeIP>:9200/_cluster/health?pretty`.

     The response should be as follows:

     ![Elasticsearch example2](~/user-guide/images/Elasticsearch_example2.png)

1. Configure the Elasticsearch cluster database in System Center. See [Configuring Elasticsearch in System Center](xref:Configuring_DataMiner_Indexing).

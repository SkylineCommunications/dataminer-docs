---
uid: Installing_Elasticsearch_on_Linux
---

# Installing Elasticsearch on a Linux machine

If you want to use an Elasticsearch cluster for your DMS (which is required to use the [Cassandra Cluster](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster) feature), install Elasticsearch on a Linux machine as detailed below.

1. Install the Elasticsearch software on  the Linux machine as described under [Installing from the RPM repository](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/rpm.html#rpm-repo) in the official Elasticsearch documentation.

1. Make sure the firewall ports are open for Elasticsearch. Elasticsearch operates on TCP port 9200 and TCP port 9300.

   - There is a default firewall on Linux, but this is disabled by default. To enable the firewall, use the following command:

     `$ systemctl start firewalld.service`

     > [!IMPORTANT]
     > Please note following commands could be different depending on the linux distrubution you are using. To use the correct guide for your preffered linux distribution please visit [Installing Elasticsearch](https://www.elastic.co/guide/en/elasticsearch/reference/current/install-elasticsearch.html).
     >
     > If you connect to your Linux server with SSH, you must immediately exclude port 22, or you will be locked out of the session.
     >
     > For this, use the following command: `$ firewall-cmd --zone=public --add-port=22/tcp`

   - To add the correct ports to the firewall, you can for example use the following commands:

     - `$ firewall-cmd --add-port=9200/tcp --permanent`

     - `$ firewall-cmd --add-port=9300/tcp --permanent`

     - `$ firewall-cmd --reload`

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

   - Make the following adjustments in the *elasticsearch.yml* file based on your setup:

     - **cluster.name**: This needs to be the same for all nodes in your Elasticsearch cluster.

     - **node.name**: The name of the Elasticsearch node.

     - **path.data**: The location(s) where you want to store the data.

     - **bootstrap.memory_lock**: Set this to *true*.

     - **network.host**: The IP address of the node.

     - **http.port**: Set this to *9200*.

     - **discovery.zen.ping.unicast.hosts**: The IP addresses of all the nodes in your Elasticsearch cluster. Elasticsearch nodes use this list of hosts to find each other and learn the topology of the ring.

       > [!NOTE]
       >
       > - We recommend a cluster of three nodes, preferably in different racks.
       > - To add a node to an existing cluster, see [Adding an Elasticsearch cluster node](xref:Configuring_Elasticsearch_node_add).

     - **discovery.zen.minimum_master_nodes**: Set this to *2*. For more information on master nodes, see [Configuring the master nodes](xref:Configuring_master_Elasticsearch_nodes).

     - **gateway.recover_after_nodes**: Set this to *1*.

     - **node.master**: Set this to *true*. For more information on master nodes, see [Configuring the master nodes](xref:Configuring_master_Elasticsearch_nodes).

1. Make the following adjustments in */etc/sysconfig/elasticsearch*:

   - **MAX_LOCKED_MEMORY**: Set this to *unlimited*.

   - **JAVA_HOME**: Set this to custom java path to be used for Elasticsearch. As an example you can set this to *java-11-openjdk-11.0.14.0.9-1.el7_9.x86_64*.

1. Make the following adjustment in */usr/lib/systemd/system/elasticsearch.service*:

   - **LimitMEMLOCK**: Set this to *infinity*. This must be set under the *Service* tag.

1. Set the maximum Java Heap Size under */etc/elasticsearch/jvm.options*. For more information, see [Setting the heap size](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/heap-size.html).

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

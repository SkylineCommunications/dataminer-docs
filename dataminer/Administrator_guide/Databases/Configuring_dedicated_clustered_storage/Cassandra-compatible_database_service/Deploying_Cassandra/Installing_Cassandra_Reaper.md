---
uid: Installing_Cassandra_Reaper
---

# Installing Cassandra Reaper

Cassandra Reaper is an application that can manage Cassandra cluster repairs on its own without the need of extra external management.

> [!NOTE]
> As setting up the remote JMX communication port in a secure way can be very challenging on the Cassandra nodes, we advise that you deploy the Cassandra reaper application on all the Cassandra nodes and configure it to run in SIDECAR mode. This will allow Cassandra Reaper to work without relying on the JMX communication ports on the Cassandra nodes.

1. Install the Cassandra Reaper software by following the installation steps on the [Cassandra Reaper installation page](http://cassandra-reaper.io/docs/download/install/).

   > [!IMPORTANT]
   > Reaper version 3.4.0 has a known issue with the web UI logon (see [webui login not working in docker #1450](https://github.com/thelastpickle/cassandra-reaper/issues/1450)). As a workaround, you can install [version 3.3.4](https://github.com/thelastpickle/cassandra-reaper/releases/tag/3.3.4) from a DEB package using the dpkg command: `sudo dpkg -i reaper_3.3.4_all.deb`

1. Create a keyspace in Cassandra for Reaper to use by running a CQL command adjusted to match the [keyspace replication strategy](https://docs.datastax.com/en/cassandra-oss/3.x/cassandra/architecture/archDataDistributeReplication.html) of your choice.

   - Example where all nodes in the Cassandra cluster reside in a **single data center**:

     ```txt
     CREATE KEYSPACE "reaper_db"
     WITH durable_writes = true
     AND replication =
     {
      'class' : 'SimpleStrategy',
      'replication_factor' : 2
     };
     ```

   - Example where the nodes in the Cassandra cluster have been divided over **multiple data centers**:

     ```txt
     CREATE KEYSPACE "reaper_db"
     WITH durable_writes = true
     AND replication =
     {
      'class' : 'NetworkTopologyStrategy',
      'datacenter1' : 3,
      'datacenter2' : 3,
      'datacenter3' : 3
     };
     ```

   > [!NOTE]
   > We advise that you always use a replication factor greater than "1" in the newly created keyspace, as this will provide robustness when data is requested from nodes in the Cassandra cluster.
   >
   > If the replication factor is smaller than 2, data requests may fail if the node hosting the data is not available to serve the request. In that case, Cassandra Reaper will no longer function properly, and it will generate errors in its logging such as:
   >
   > ```txt
   > Caused by: com.datastax.driver.core.exceptions.NoHostAvailableException: All host(s) tried for query failed (tried: /10.66.117.69:9042 (com.datastax.driver.core.exceptions.UnavailableException: Not enough replicas available for query at consistency LOCAL_ONE (1 required but only 0 alive)), /10.66.117.67:9042 (com.datastax.driver.core.exceptions.UnavailableException: Not enough replicas available for query at consistency LOCAL_ONE (1 required but only 0 alive)))
   > ```

1. Make sure the firewall ports are open for the webpage.

   The default ports used for the webpage are ports 8080 and 8081.

   > [!NOTE]
   > All ports can be customized in the *cassandra-reaper.yaml* file.

1. Configure the *cassandra-reaper.yaml* file.

   You can find this file in the */etc/cassandra-reaper* folder.

   We suggest that you start from the example file *cassandra-reaper-cassandra-sidecar.yaml* located in the */etc/cassandra-reaper/configs* folder and adjust it to your system:

   - Enable autoscheduling to let reaper schedule the repairs automatically.

   - Under the Cassandra configuration, add the authProvider tag to provide credential for Cassandra.

   - From Reaper v1.4.0 onwards, make sure the blacklistTwcsTables tag is set to *true*. This will disable repairs on TimeWindowCompactionStrategy (TWCS) tables. For more information, see [Maintaining a Cassandra cluster](xref:Maintain_Cassandra_Cluster#keeping-your-nodes-repaired). Prior to Reaper v1.4.0, make sure to exclude the keyspaces that contain these tables.

   - To limit the log file size, use the following configuration:

      - `maxFileSize: 1MB`
      - `archivedLogFilenamePattern: /var/log/cassandra-reaper/reaper-%d{yyyy-MM-dd}_%i.log.gz`

   - For a sidecar-based configuration, to configure the connection with the Cassandra cluster, use the following configuration:

      - `contactPoints: ["<local IP address>"]`
      - `enableDynamicSeedList: true`

   For more information on the different options, refer to the [Reaper documentation](http://cassandra-reaper.io/docs/configuration/).
  
   > [!NOTE]
   > By default, Reaper logs do not contain timestamps. To add timestamps to the log output, add *%date{ISO8601}* to the *logFormat* setting in *cassandra-reaper.yaml*. For example: `logFormat: "%date{ISO8601} %-6level [%t] %logger{5} - %msg %n"`

1. Run the following command to enable automatic startup of the Reaper service:

   `$ systemctl enable cassandra-reaper.service`

1. Start the service by running the following command:

   `$ systemctl start cassandra-reaper.service`

1. Check if Reaper is running by going to the webpage `http://[cassandra_node_ip]:8080/webui`. The default credentials are admin/admin.

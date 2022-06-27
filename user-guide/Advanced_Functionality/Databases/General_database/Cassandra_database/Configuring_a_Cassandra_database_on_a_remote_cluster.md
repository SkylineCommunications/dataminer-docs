---
uid: Configuring_a_Cassandra_database_on_a_remote_cluster
---

# Configuring a Cassandra database on a remote cluster

Different setups are possible where the Cassandra general database runs entirely on one or more external nodes (see [Supported data storage architectures](https://community.dataminer.services/supported-system-data-storage-architectures/)). However, these require an advanced procedure with manual adjustments of the Cassandra settings.

> [!NOTE]
>
> - This procedure requires that the DMA is already using Cassandra. However, it is not limited to newly installed DMAs.
> - It is not supported to have an external program do queries on the general database, regardless of the setup. Instead, the external program should retrieve the data from the offload database. See [Offload database](xref:Offload_database).
> - In this setup, the Cassandra databases are not managed by DataMiner, so it is important that you manage the database yourself (e.g. by running compaction). Keep in mind that the database will not be included in DataMiner backups and there will be no forced compaction. In a Failover setup, the forced repair will not be executed, and it will not be possible to check the status.

To create a setup where the Cassandra database runs entirely on one or more remote servers, follow the procedure below.

To link a DMA to a remote server with a Cassandra database:

1. Install Cassandra on the remote server.

   1. Download the package containing the Cassandra binaries from [DataMiner Dojo](https://community.dataminer.services/downloads/), and extract it on the first server where Cassandra will be installed.

   1. Locate the file *cassandra.yaml*. By default, it is located in the folder *C:\\Program Files\\Cassandra\\conf*.

   1. Open *cassandra.yaml* in a text editor (as Administrator) and replace the IP address in the following lines with the IP of the server:

      ```txt
      listen_address: 127.0.0.1
      - seeds: "127.0.0.1"
      broadcast_rpc_address: 127.0.0.1
      ```

   1. Open TCP port 9042 and 7000 in the firewall.

      > [!NOTE]
      > From DataMiner 10.1.3 onwards, TLS can be enabled on the database connection. In that case port 7001 should be opened instead of 7000. See [Enabling TLS on the Cassandra database connection](xref:DB_xml#enabling-tls-on-the-cassandra-database-connection)

   1. Open a Command Prompt window with administrator rights, and execute the file *Install.bat*.

      Cassandra will now be installed as a seed node, i.e. the node responsible for cluster discovery.

1. Install any additional Cassandra nodes if necessary:

   1. Download the package containing the Cassandra binaries from [DataMiner Dojo](https://community.dataminer.services/downloads/), and extract it on the first server where Cassandra will be installed.

   1. Open the file *cassandra.yaml* in a text editor and replace the following IP addresses:

      - Replace the IP address in the listen_address and broadcast_rpc_address lines with the IP of the server

      - Replace the IP address in the seeds line with that of the first Cassandra node that was installed.

      ```txt
        listen_address: 127.0.0.1
      - seeds: "127.0.0.1"
      broadcast_rpc_address: 127.0.0.1
      ```

   1. Open TCP port 9042 and 7000 in the firewall.

      > [!NOTE]
      > From DataMiner 10.1.3 onwards, TLS can be enabled on the database connection. In that case port 7001 should be opened instead of 7000. See [Enabling TLS on the Cassandra database connection](xref:DB_xml#enabling-tls-on-the-cassandra-database-connection)

   1. Open a Command Prompt window with administrator rights, and execute the file *Install.bat*.

   1. Repeat this for each Cassandra node.

   1. Once Cassandra has been installed on all servers, verify the status of the cluster with Nodetool:

      - In a command window, execute *nodetool status* (from the directory *C:\\Program Files\\Cassandra\\bin*).

    > [!TIP]
    > See also: <http://docs.datastax.com/en/cassandra/3.0/cassandra/operations/opsAddNodeToCluster.html?hl=add%2Cnode>

1. On the first Cassandra server, change the default credentials:

   1. Open DevCenter, by going to *C:\\Program Files\\Cassandra\\DevCenter\\Run DevCenter.lnk*.

   1. Connect with localhost, using the user credentials *cassandra:cassandra*.

   1. Execute the following command:

      ```txt
      CREATE ROLE root WITH SUPERUSER = true AND PASSWORD = '<STRONG PASSWORD>' AND LOGIN = true;
      ```

   1. If necessary, to replicate these credentials to other nodes in the cluster, execute the following command, using a replication factor corresponding to the number of nodes in your cluster:

      ```txt
      ALTER KEYSPACE "system_auth" WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor' : 3 };
      ```

      > [!NOTE]
      >
      > - If you have any trouble executing this command, reconnect using the credentials `root:<STRONG PASSWORD>`, e.g. *root:YourStrongPassword*.
      > - If a notice appears saying *Create, Alter or Drop in system keyspaces is not allowed*, this can be ignored.

1. In DataMiner Cube, change the IP of the Cassandra node.

   1. Go to *System Center* > *Database*.

   1. Make sure the right DMA is selected in the column on the left.

   1. In the *Server* box, specify the IP address or addresses of the remote servers, using a comma as a separator. E.g. *10.11.1.12,10.11.2.1*.

   1. Click the *Save* button in the lower right corner.

1. Configure the database settings in *DB.xml*:

   1. Shut down the DMA.

   1. Open the file *DB.xml* from the directory *C:\\Skyline DataMiner* in a text editor.

   1. In the \<Database> tag, add the *consistencyLevel="x"* attribute, and set it to the consistency level you want, e.g. *two*.

      > [!NOTE]
      >
      > - The following possible consistency levels are supported: Any, One, Two, Three, Quorum, All, LocalQuorum, EachQuorum, Serial, LocalSerial, LocalOn. For more information, see [https://docs.datastax.com/en/cassandra-oss/3.0/cassandra/dml/dmlConfigConsistency.html](https://docs.datastax.com/en/cassandra-oss/3.0/cassandra/dml/dmlConfigConsistency.html).
      > - The *consistencyLevel* attribute should only be changed in case the Cassandra cluster feature is used or a remote Cassandra server is used. If the standard configuration of one Cassandra cluster per DMA is used, changing this attribute can cause the DMA to fail to start up.

   1. Optionally, to adjust the timeout time to read from the database, adjust the value (in milliseconds) in the readTimeOut tag. By default, this is set to five minutes. For example:

      ```xml
      <DataBase type ="Cassandra">
        ...
        <readTimeOut>300000</readTimeOut>
        ...
      </DataBase>
      ```

   1. Restart DataMiner.

1. If Cassandra is no longer used on the DMA servers themselves, disable the Cassandra service:

   1. Run *services.msc*.

   1. In the *Services* window, right-click the *cassandra* service and select *Properties*.

   1. If the service is currently running, click the *Stop* button.

   1. In the *Startup type* box, select *Disabled*.

   1. Click *OK*.

1. Once you are sure you no longer need the old database data as a backup (e.g. a few months after the migration), remove the old database data folders (by default *C:\\ProgramData\\Cassandra\\SLDMADB* and *C:\\ProgramData\\Cassandra\\sldmadb_ticketing*).

## Configuring a Failover setup with remote Cassandra databases

To configure a Failover setup with remote Cassandra databases:

1. Set up both DMAs with a separate remote database, as mentioned above.

1. Add the DMAs to a Failover setup. See [Failover configuration in Cube](xref:Failover_configuration_in_Cube).

1. Configure the *cassandra.yaml* file for the main DMA as follows:

    ```txt
    listen_address: [IP of the main DMA]
    seeds: [IP of the main DMA],[IP of the backup DMA]
    rpc_address: 0.0.0.0
    broadcast_rpc_address: [IP of the main DMA]
    ```

1. Configure the *cassandra.yaml* file for the backup DMA as follows:

    ```txt
    listen_address: [IP of the backup DMA]
    seeds: [IP of the main DMA],[IP of the backup DMA]
    rpc_address: 0.0.0.0
    broadcast_rpc_address: [IP of the backup DMA]
    ```

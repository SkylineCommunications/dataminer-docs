---
uid: General_Main_Release_10.1.0
---

# General Main Release 10.1.0

**Internet Explorer Support**

Though DataMiner Cube is available as a desktop application, many users still like to use the DataMiner browser application that requires Internet Explorer. However, Microsoft no longer recommends using Internet Explorer, and support for Internet Explorer is expected to cease in 2025, though currently the program is still maintained as part of the support policy for the versions of Windows it is included in. For more information, see <https://docs.microsoft.com/en-us/lifecycle/faq/internet-explorer-microsoft-edge>.

The preferred way to use DataMiner Cube is as a desktop application, which can be downloaded from each DMA’s landing page in any other browser than Internet Explorer. From DataMiner 10.0.9 onwards, this application also comes with a new start window for increased ease of use.

However, if you do wish to use DataMiner Cube in a browser, this remains possible:

- Microsoft Edge can be configured to open specific URLs in IE compatibility mode. If you configure Edge to open the DataMiner Cube URLs of DMAs in this mode, you will be able to access the DMAs with DataMiner Cube in Edge. However, make sure you only do this for the exact URLs of DataMiner Cube, as other DataMiner apps will not function optimally in IE compatibility mode. For more information see, <https://docs.microsoft.com/en-us/DeployEdge/edge-ie-mode-policies>.

- You can still continue to use Internet Explorer to access DataMiner Cube as long as Microsoft support continues. However, in this case we highly recommend to use a different browser to access any other websites on the internet.

## New features

### DMS core functionality

#### New SLNet setting “ClusterTransitionStateTimeout” in MaintenanceSettings.xml \[ID_22136\]

In the *MaintenanceSettings.xml* file, you can now specify a cluster transition state timeout (in seconds).

If you do so, DataMiner Agents leaving the DataMiner System (i.e. cluster) will leave the transition state after the above-mentioned timeout delay, starting from the last received notification from any of the DataMiner processes. This will prevent DataMiner Agents from getting stuck in the transition state.

```xml
<SLNet>
  <ClusterTransitionStateTimeout>5</ClusterTransitionStateTimeout>
</SLNet>
```

#### New Cassandra cluster feature \[ID_23210\]\[ID_23975\]\[ID_25945\]\[ID_26144\]\[ID_26475\] \[ID_27080\]\[ID_27520\]\[ID_27615\]\[ID_27648\]\[ID_27694\]\[ID_28406\]

A Cassandra cluster is now supported as the general database for a DataMiner System. While previously it was already possible to use a separate Cassandra cluster for each DataMiner node, this new feature allows all DataMiner nodes in a cluster to connect to the same Cassandra cluster.

##### Installation and configuration

To switch to using one Cassandra cluster for your DMS, follow the procedure below:

1. Make sure the Cassandra cluster software is installed on each DMA. A [standalone installer](https://community.dataminer.services/documentation/standalone-cassandra-cluster-installer/) is available for this on DataMiner Dojo.

2. [Install DataMiner Indexing](https://help.dataminer.services/dataminer/) on each DMA in the cluster if you have not done so already.

3. Migrate the database data to the Cassandra cluster. See [Migrating the general database to a DMS Cassandra cluster](https://docs.dataminer.services/user-guide/Advanced_Functionality/Databases/Supported_System_Data_Storage_Architectures/Migrating_the_general_database_to_a_DMS_Cassandra_cluster.html).

    > [!NOTE]
    > We recommend that DataMiner is stopped before the migration is started. While it is possible to run the migration while DataMiner is run­ning, any data that is stored in the source database during the migra­tion may not be migrated to the target database.

4. In DataMiner Cube, go to System Center \> Database and select *CassandraCluster* in the Database box. Then specify the name, DB server and credentials to connect to the Cassan­dra cluster.

##### DB.xml changes

In the file DB.xml, the new database type “CassandraCluster” is now supported for the general (previously known as local) database. While previously, information in this file related to the general database was not synced in a cluster, if this database type is used, DB.xml is now completely synchronized throughout the cluster.

**Cassandra cluster support in the DataMiner installer**

If you want to use a Cassandra cluster for a new DMS, the DataMiner installer can be run in unattended mode with the necessary commands to install both Elasticsearch and Cassandra, and configure a Cassandra Cluster.

Below, you can find a list of new or updated settings that can be specified in the configuration file InstallConfiguration.xml.

*DMA tag:*

| Subtag                   | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
|--------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Database                 | Indicates the database type to use (*Cassandra*, *CassandraCluster*, *MySQL* or *MSSQL*) using the type attribute. This tag must contain the following subtags, detailing the configuration for the *Db.xml* file: *DB*, *DBServer*,* DBDrive*, *ConnectString*, *UID* (user), *PWD* (password) and *Maintenance*. It is possible to leave some of these tags empty, in which case the default configuration will be applied. In addition, any other tags that can be configured in *Db.xml* can also be specified here, e.g. in the *Maintenance* tag.<br> Note that for a non-Cassandra database, the drive specified in *DBDrive* must be C. |
| CassandraClusterSettings | Used in case a database of type *CassandraCluster* is installed. See “CassandraClusterSettings tag” below.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| ElasticClusterSettings   | Used in case a database of type *CassandraCluster* is installed. See “ElasticClusterSettings tag” below.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| SearchDataBase           | Used in case a database of type *CassandraCluster* is installed. This tag must contain the following subtags, detailing the configuration for the Elasticsearch database in the Db.xml file: *DBServer*, *UID* (user) and *PWD* (password).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |

*CassandraClusterSettings tag:*

| Subtag                            | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
|-----------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ListenAddress                     | The IP address that should be filled in for the *listen_address* setting in the cassandra.yaml file.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| Seeds                             | The IP addresses of the different Cassandra nodes in the system, which will be filled in for the *seed_provider* setting in the cassandra.yaml file. It is recommended to configure at most 3 seed IP addresses per data center;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| ClusterName                       | The name of the Cassandra cluster, which will be filled in for the *cluster_name* setting in the cassandra.yaml file. This must be the same for all DMAs.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| ClusterSize                       | The size of the cluster. When installing Cassandra, the installer will wait until this number of nodes are online before it continues.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| Port                              | The CQL native transport port, which will be filled in for the *native_transport_port* setting in the cassandra.yaml file.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| SystemAuthReplication­Factor      | The replication factor for the system_auth keyspace. This keyspace contains the data required to log in to Cassandra. The replication factor determines how many replicas will exist for each row of this keyspace.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| DefaultKeyspace­ReplicationFactor | The replication factor of the default keyspace.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| RpcAddress                        | The IP address that Cassandra will use for client-based communication, such as through the CQL protocol. <br> If this is left empty, it will not be defined in the cassandra.yaml.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| BroadCastRpcAddress               | The address that Cassandra nodes will publish to connected clients.<br> If most clients are outside the cluster's local network, this is typically the public address. Otherwise, it is typically the local network address.<br> If this is left empty, it will not be defined in the cassandra.yaml.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
| TargetInstallationDirectory       | The location where Cassandra will be installed.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| DataPath                          | The location where Cassandra data will be stored.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| Snitch                            | The value that should be filled in for the *endpoint_snitch* setting in the cassandra.yaml file. The following values are supported: *SimpleSnitch*, *GossipingPropertyFileSnitch*, *PropertyFileSnitch*, *Ec2Snitch*, *Ec2MultiRegionSnitch*, *RackInferringSnitch*.<br> Cassandra uses this setting to figure out the network topology, so that it can route requests efficiently and optimize the way data replicas are spread around the cluster. The recommended value is *GossipingPropertyFileSnitch.* Other values are commonly used when the Cassandra nodes are hosted in the cloud. |
| IsResponsibleFor­Configuration    | Determines whether this DMA will be responsible for configuring the Cassandra cluster after it has been created. This includes creating the defined user as well as setting the “system auth” replication factor. <br> This should only be set to true for 1 DMA. Possible values: true, false.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |

*ElasticClusterSettings tag:*

| Subtag                      | Description                                                                                                                                        |
|-----------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------|
| DiscoveryHosts              | The IP addresses of the other nodes in the cluster. Not all IP addresses are needed, but ideally, the master node IP addresses should be included. |
| NetworkHost                 | The IP address Elasticsearch should be bound to. This corresponds with the NetworkHost setting in the elasticsearch.yaml file.                     |
| NetworkPublishHost          | The IP address Elasticsearch should publish to. If virtual IPs are configured, this should not be set to 0.0.0.0.                                  |
| ClusterName                 | The name of the Elasticsearch cluster. This must be the same for all DMAs.                                                                         |
| NodeName                    | The name of the Elasticsearch node.                                                                                                                |
| MinimumMasterNodes          | The minimum number of master nodes for the Elasticsearch cluster. Set this to 1 for a single node and to 2 for a cluster.                          |
| MasterNode                  | Determines whether this node is a master node. Possible values: true, false                                                                        |
| DataNode                    | Determines whether this node is a data node. Possible values: true, false. Recommended value: true.                                                |
| DataPath                    | The location where Elasticsearch data will be stored.                                                                                              |
| TargetInstallationDirectory | The location where Elasticsearch will be installed.                                                                                                |

The example below is used to create a cluster of three DMAs, all using the same Cassandra cluster as their general database.

```xml
<DMS>
   <!-- DataMiner version -->
    <DataMinerVersion>DataMiner 10.0.12.0-9536 Full Upgrade (rc)</DataMinerVersion>
   <!-- Name of the DataMiner cluster -->
    <ClusterName>CassandraClusterDMS</ClusterName>
    <!-- timeout in minutes -->
    <Timeout>15</Timeout>
   <!-- Configuration belonging to a DataMiner agent -->
    <DMA>
      <!-- The DataMiner ID -->
        <ID>101</ID>
        <!-- The name of the machine -->
      <MachineName>SLC-H70-G01</MachineName>
      <Location>Local</Location>
      <!-- The IP of this agent -->
        <IP1>10.11.1.70</IP1>
      <!-- DB.xml settings -->
        <DataBase type="CassandraCluster">
         <!-- The name of the Cassandra database. Keyspaces will be prefixed using this value -->
            <DB>SLDMADB</DB>
         <!-- IP of the Cassandra database -->
            <DBServer>10.11.1.70,10.11.2.70,10.11.3.70</DBServer>
            <ConnectString/>
         <!-- Cassandra username -->
            <UID>root</UID>
         <!-- Cassandra password -->
            <PWD>root</PWD>
            <Maintenance>
            <!-- Any tag that also exists in the DB.xml for local DB -->
            </Maintenance>
        </DataBase>
      <SearchDataBase>
         <!-- IP of the Elastic database -->
            <DBServer>127.0.0.1</DBServer>
         <!-- Elastic username -->
            <UID>elastic</UID>
         <!-- Elastic password -->
            <PWD>root123</PWD>
        </SearchDataBase>
      <!-- Settings used to install and configure Cassandra with -->
        <CassandraClusterSettings>
         <!-- cassandra.yaml setting 'listen_adress' -->
            <ListenAddress>10.11.1.70</ListenAddress>
         <!-- cassandra.yaml setting 'seed_provider': The seeds which will be used to connect to Cassandra with. -->
            <Seeds>10.11.1.70,10.11.2.70,10.11.3.70</Seeds>
         <!-- cassandra.yaml setting 'cluster_name': The name of the Cassandra cluster. Should be the same for all agents. -->
            <ClusterName>DMS</ClusterName>
         <!-- The size of the cluster. When installing Cassandra, the installer will wait till it sees this number of nodes before continuing -->
            <ClusterSize>3</ClusterSize>
         <!-- cassandra.yaml setting 'native_transport_port': CQL Native transport port -->
            <Port>9042</Port>
         <!-- Configuration setting after Cassandra has been installed. The system auth replication factor will be set to this value -->
            <SystemAuthReplicationFactor>3</SystemAuthReplicationFactor>
         <!-- The replication factor of the default keyspace. -->
            <DefaultKeyspaceReplicationFactor>3</DefaultKeyspaceReplicationFactor>
         <!-- cassandra.yaml setting 'rpc_address': If left empty, will not be defined in the yaml. -->
            <RpcAddress>0.0.0.0</RpcAddress>
         <!-- cassandra.yaml setting 'broadcast_rpc_address': If left empty, will not be defined in the yaml. -->
            <BroadCastRpcAddress>10.11.1.70</BroadCastRpcAddress>
         <!-- The location where Cassandra will be installed. -->
            <TargetInstallationDirectory>C:\Program Files\Cassandra</TargetInstallationDirectory>
         <!-- cassandra.yaml setting 'data_file_directories' Directory where Cassandra data will be stored. -->
            <DataPath>C:\ProgramData\Cassandra</DataPath>
         <!-- cassandra.yaml setting 'endpoint_snitch': possible values: SimpleSnitch, GossipingPropertyFileSnitch, PropertyFileSnitch, Ec2Snitch, Ec2MultiRegionSnitch, RackInferringSnitch -->
            <Snitch>GossipingPropertyFileSnitch</Snitch>
         <!-- Whether or not this DMA is responsible for configuring the Cassandra cluster after it has been created.
              This includes creating the defined user as well as setting the system auth replication factor.
             This value should be true for only 1 DMA.
         -->
            <IsResponsibleForConfiguration>true</IsResponsibleForConfiguration>
        </CassandraClusterSettings>
        <!-- Settings used to install and configure Elastic with -->
        <ElasticClusterSettings>
            <!--The Ip's of the other cluster, one is enough. Best to fill in with master node ip's-->
            <DiscoveryHosts>127.0.0.1</DiscoveryHosts>
            <!-- elasticsearch.yaml setting 'NetworkHost': The IP you want to bind elastic to. -->
            <NetworkHost>0.0.0.0</NetworkHost>
            <!-- The IP you want elastic to publish to. Should not be set to 0.0.0.0 when there are virtual IP's configured-->
            <NetworkPublishHost>0.0.0.0</NetworkPublishHost>
            <!-- elasticsearch.yaml setting 'cluster_name': The name of the Elastic cluster. Should be the same for all agents. -->
            <ClusterName>DMS</ClusterName>
            <!-- The name that the Elastic node should have. -->
            <NodeName>NodeName</NodeName>
            <!-- The minimum master nodes for the Elastic cluster. Should be set to 1 in case of single node and to 2 in case of a cluster. -->
            <MinimumMasterNodes>1</MinimumMasterNodes>
            <!-- Define whether or not this node is a master node. -->
            <MasterNode>true</MasterNode>
            <!-- Define whether or not this node is a data node. Best to set this to true-->
            <DataNode>true</DataNode>
            <!-- The location the data will be saved on. -->
            <DataPath>C:\ProgramData\Elasticsearch</DataPath>
            <!-- The location where Elastic will be installed. -->
            <TargetInstallationDirectory>C:\Program Files\Elasticsearch</TargetInstallationDirectory>
        </ElasticClusterSettings>
    </DMA>
   <!-- Configuration belonging to a DataMiner agent -->
    <DMA>
      <!-- The DataMiner ID -->
        <ID>102</ID>
        <!-- The name of the machine -->
      <MachineName>SLC-H70-G02</MachineName>
      <Location>Local</Location>
      <!-- The IP of this agent -->
        <IP1>10.11.2.70</IP1>
      <!-- DB.xml settings -->
        <DataBase type="CassandraCluster">
         <!-- The name of the Cassandra database. Keyspaces will be prefixed using this value -->
            <DB>SLDMADB</DB>
         <!-- IP of the Cassandra database -->
            <DBServer>10.11.1.70,10.11.2.70,10.11.3.70</DBServer>
            <ConnectString/>
         <!-- Cassandra username -->
            <UID>root</UID>
         <!-- Cassandra password -->
            <PWD>root</PWD>
            <Maintenance>
            <!-- Any tag that also exists in the DB.xml for local DB -->
            </Maintenance>
        </DataBase>
      <SearchDataBase>
         <!-- IP of the Elastic database -->
            <DBServer>127.0.0.1</DBServer>
         <!-- Elastic username -->
            <UID>elastic</UID>
         <!-- Elastic password -->
            <PWD>root123</PWD>
        </SearchDataBase>
      <!-- Settings used to install and configure Cassandra with -->
        <CassandraClusterSettings>
         <!-- cassandra.yaml setting 'listen_adress' -->
            <ListenAddress>10.11.2.70</ListenAddress>
         <!-- cassandra.yaml setting 'seed_provider': The seeds which will be used to connect to Cassandra with. -->
            <Seeds>10.11.1.70,10.11.2.70,10.11.3.70</Seeds>
         <!-- cassandra.yaml setting 'cluster_name': The name of the Cassandra cluster. Should be the same for all agents. -->
            <ClusterName>DMS</ClusterName>
         <!-- The size of the cluster. When installing Cassandra, the installer will wait till it sees this number of nodes before continuing -->
            <ClusterSize>3</ClusterSize>
         <!-- cassandra.yaml setting 'native_transport_port': CQL Native transport port -->
            <Port>9042</Port>
         <!-- Configuration setting after Cassandra has been installed. The system auth replication factor will be set to this value -->
            <SystemAuthReplicationFactor>3</SystemAuthReplicationFactor>
         <!-- The replication factor of the default keyspace used. -->
            <DefaultKeyspaceReplicationFactor>3</DefaultKeyspaceReplicationFactor>
         <!-- cassandra.yaml setting 'rpc_address': If left empty, will not be defined in the yaml. -->
            <RpcAddress>0.0.0.0</RpcAddress>
         <!-- cassandra.yaml setting 'broadcast_rpc_address': If left empty, will not be defined in the yaml. -->
            <BroadCastRpcAddress>10.11.2.70</BroadCastRpcAddress>
         <!-- The location where Cassandra will be installed. -->
            <TargetInstallationDirectory>C:\Program Files\Cassandra</TargetInstallationDirectory>
         <!-- cassandra.yaml setting 'data_file_directories' Directory where Cassandra data will be stored. -->
            <DataPath>C:\ProgramData\Cassandra</DataPath>
         <!-- cassandra.yaml setting 'endpoint_snitch': possible values: SimpleSnitch, GossipingPropertyFileSnitch, PropertyFileSnitch, Ec2Snitch, Ec2MultiRegionSnitch, RackInferringSnitch -->
            <Snitch>GossipingPropertyFileSnitch</Snitch>
         <!-- Whether or not this DMA is responsible for configuring the Cassandra cluster after it has been created.
              This includes creating the defined user as well as setting the system auth replication factor.
             This value should be true for only 1 DMA.
         -->
            <IsResponsibleForConfiguration>false</IsResponsibleForConfiguration>
        </CassandraClusterSettings>
        <!-- Settings used to install and configure Elastic with -->
        <ElasticClusterSettings>
            <!--The Ip's of the other cluster, one is enough. Best to fill in with master node ip's-->
            <DiscoveryHosts>127.0.0.1</DiscoveryHosts>
            <!-- elasticsearch.yaml setting 'NetworkHost': The IP you want to bind elastic to. -->
            <NetworkHost>0.0.0.0</NetworkHost>
            <!-- The IP you want elastic to publish to. Should not be set to 0.0.0.0 when there are virtual IP's configured-->
            <NetworkPublishHost>0.0.0.0</NetworkPublishHost>
            <!-- elasticsearch.yaml setting 'cluster_name': The name of the Elastic cluster. Should be the same for all agents. -->
            <ClusterName>DMS</ClusterName>
            <!-- The name that the Elastic node should have-->
            <NodeName>NodeName</NodeName>
            <!-- The minimum master nodes for the Elastic cluster. Should be set to 1 in case of single node and to 2 in case of a cluster. -->
            <MinimumMasterNodes>1</MinimumMasterNodes>
            <!-- Define whether or not this node is a master node. -->
            <MasterNode>true</MasterNode>
            <!-- Define whether or not this node is a data node. Best to set this to true-->
            <DataNode>true</DataNode>
            <!-- The location the data will be saved on. -->
            <DataPath>C:\ProgramData\Elasticsearch</DataPath>
            <!-- The location where Elastic will be installed. -->
            <TargetInstallationDirectory>C:\Program Files\Elasticsearch</TargetInstallationDirectory>
        </ElasticClusterSettings>
    </DMA>
   <!-- Configuration belonging to a DataMiner agent -->
    <DMA>
      <!-- The DataMiner ID -->
        <ID>103</ID>
        <!-- The name of the machine -->
      <MachineName>SLC-H70-G03</MachineName>
      <Location>Local</Location>
      <!-- The IP of this agent -->
        <IP1>10.11.3.70</IP1>
      <!-- DB.xml settings -->
        <DataBase type="CassandraCluster">
         <!-- The name of the Cassandra database. Keyspaces will be prefixed using this value -->
            <DB>SLDMADB</DB>
         <!-- IP of the Cassandra database -->
            <DBServer>10.11.1.70,10.11.2.70,10.11.3.70</DBServer>
            <ConnectString/>
         <!-- Cassandra username -->
            <UID>root</UID>
         <!-- Cassandra password -->
            <PWD>root</PWD>
            <Maintenance>
            <!-- Any tag that also exists in the DB.xml for local DB -->
            </Maintenance>
        </DataBase>
      <SearchDataBase>
         <!-- IP of the Elastic database -->
            <DBServer>127.0.0.1</DBServer>
         <!-- Elastic username -->
            <UID>elastic</UID>
         <!-- Elastic password -->
            <PWD>root123</PWD>
        </SearchDataBase>
      <!-- Settings used to install and configure Cassandra with -->
        <CassandraClusterSettings>
         <!-- cassandra.yaml setting 'listen_adress' -->
            <ListenAddress>10.11.3.70</ListenAddress>
         <!-- cassandra.yaml setting 'seed_provider': The seeds which will be used to connect to Cassandra with. -->
            <Seeds>10.11.1.70,10.11.2.70,10.11.3.70</Seeds>
         <!-- cassandra.yaml setting 'cluster_name': The name of the Cassandra cluster. Should be the same for all agents. -->
            <ClusterName>DMS</ClusterName>
         <!-- The size of the cluster. When installing Cassandra, the installer will wait till it sees this number of nodes before continuing -->
            <ClusterSize>3</ClusterSize>
         <!-- cassandra.yaml setting 'native_transport_port': CQL Native transport port -->
            <Port>9042</Port>
         <!-- Configuration setting after Cassandra has been installed. The system auth replication factor will be set to this value -->
            <SystemAuthReplicationFactor>3</SystemAuthReplicationFactor>
         <!-- The replication factor of the default keyspace used. -->
            <DefaultKeyspaceReplicationFactor>3</DefaultKeyspaceReplicationFactor>
         <!-- cassandra.yaml setting 'rpc_address': If left empty, will not be defined in the yaml. -->
            <RpcAddress>0.0.0.0</RpcAddress>
         <!-- cassandra.yaml setting 'broadcast_rpc_address': If left empty, will not be defined in the yaml. -->
            <BroadCastRpcAddress>10.11.3.70</BroadCastRpcAddress>
         <!-- The location where Cassandra will be installed. -->
            <TargetInstallationDirectory>C:\Program Files\Cassandra</TargetInstallationDirectory>
         <!-- cassandra.yaml setting 'data_file_directories' Directory where Cassandra data will be stored. -->
            <DataPath>C:\ProgramData\Cassandra</DataPath>
         <!-- cassandra.yaml setting 'endpoint_snitch': possible values: SimpleSnitch, GossipingPropertyFileSnitch, PropertyFileSnitch, Ec2Snitch, Ec2MultiRegionSnitch, RackInferringSnitch -->
            <Snitch>GossipingPropertyFileSnitch</Snitch>
         <!-- Whether or not this DMA is responsible for configuring the Cassandra cluster after it has been created.
              This includes creating the defined user as well as setting the system auth replication factor.
             This value should be true for only 1 DMA.
         -->
            <IsResponsibleForConfiguration>false</IsResponsibleForConfiguration>
        </CassandraClusterSettings>
        <!-- Settings used to install and configure Elastic with -->
        <ElasticClusterSettings>
            <!--The Ip's of the other cluster, one is enough. Best to fill in with master node ip's-->
            <DiscoveryHosts>127.0.0.1</DiscoveryHosts>
            <!-- elasticsearch.yaml setting 'NetworkHost': The IP you want to bind elastic to. -->
            <NetworkHost>0.0.0.0</NetworkHost>
            <!-- The IP you want elastic to publish to. Should not be set to 0.0.0.0 when there are virtual IP's configured-->
            <NetworkPublishHost>0.0.0.0</NetworkPublishHost>
            <!-- elasticsearch.yaml setting 'cluster_name': The name of the Elastic cluster. Should be the same for all agents. -->
            <ClusterName>DMS</ClusterName>
            <!-- The name that the Elastic node should have-->
            <NodeName>NodeName</NodeName>
            <!-- The minimum master nodes for the Elastic cluster. Should be set to 1 in case of single node and to 2 in case of a cluster. -->
            <MinimumMasterNodes>1</MinimumMasterNodes>
            <!-- Define whether or not this node is a master node. -->
            <MasterNode>true</MasterNode>
            <!-- Define whether or not this node is a data node. Best to set this to true-->
            <DataNode>true</DataNode>
            <!-- The location the data will be saved on. -->
            <DataPath>C:\ProgramData\Elasticsearch</DataPath>
            <!-- The location where Elastic will be installed. -->
            <TargetInstallationDirectory>C:\Program Files\Elasticsearch</TargetInstallationDirectory>
        </ElasticClusterSettings>
    </DMA>
</DMS>
```

##### Cluster health monitoring

If a Cassandra node goes down or when a node is down when DataMiner starts up, an alarm will be generated in the Alarm Console. This alarm also indicates how much the health of the cluster is affected by the node being down, as this depends on multiple factors, including the cluster size and replication factor.

##### Limitations

- .dmimport packages created on a DMS using a Cassandra Cluster do not contain any database data, and it is not possible to import database data from such packages in such a DMS.

- If the Cassandra cluster feature is used, alarm and information event information is always migrated to Elasticsearch. It is not possible to use this feature without enabling indexing on alarms.

> [!NOTE]
> If a database of type Cassandra cluster is used, the soft-launch feature NewAverageTrending is automatically enabled. For more information, see <https://community.dataminer.services/documentation/average-trending-calculation/>.

#### Dynamic table filters: New component type “recursivefullfilter” \[ID_24672\]<br>\[ID_24676\]

When configuring a dynamic table filter, you can now add a filter component of type “recursivefullfilter”.

This type of component will allow you to filter keys when using the recursive option. It follows the same syntax as the “fullfilter” component, and is applied to all keys found through recursive links when requesting a table with the recursive option.

Example:

```txt
recursivefullfilter=(1002 > 0)
```

> [!NOTE]
> This new filter component can also be used in table filters specified in a DataMiner Maps configuration file.

#### Support for icons in SVG format \[ID_24841\]

In function protocols and the *C:\\Skyline DataMiner\\Icons\\CustomIcons.xml* file, icons can now also be defined in SVG format.

Also, the default function icon has been updated.

#### SLAnalytics: Trend data prediction now also available for direct view table parameters \[ID_25013\]

Trend data prediction is now also available for direct view table parameters.

#### All DataMiner server DLLs now target Microsoft .NET Framework 4.6.2 \[ID_25269\]

All DataMiner server DLLs now target Microsoft .NET Framework 4.6.2.

#### Less open IP ports needed when installing DataMiner with a Cassandra database \[ID_25833\]

When installing DataMiner with a Cassandra database, up to now, IP ports 7000, 7001, 7199, 9042, 9142 and 9160 needed to be open. From now on, only ports 7000 and 9042 will need to be open.

#### A notice will now be generated when elements or services with identical names are found in the DMS \[ID_25899\]

When elements or services are created on agents of the same DMS while those are not able to synchronize due to connection issues, it can happen that elements or services are created with identical names. From now on, as soon as the connection between disconnected agents is restored, the agent with the lowest DMA ID will generate a notice when it finds elements or services with identical names.

#### DataMiner Application packages \[ID_25911\]\[ID_26027\]\[ID_26169\]\[ID_26243\]\[ID_26271\]\[ID_26338\]<br>\[ID_26351\]\[ID_26371\]\[ID_27257\]

It is now possible to install a DataMiner application or solution on an existing DataMiner system by uploading and installing a so-called “application package”.

**Creating an application package**

To create an application package, create the following files and folders, and compress them into a zip file (e.g. AppPackage.zip):

AppInfo.xml

Scripts

- Install.xml

- Config.xml

- InstallDependencies

    - ...

- ConfigureDependencies

    - ...

AppInstallContent

- ...

| File/Folder        | Contents                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
|--------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| AppInfo.xml        | General information about the application:<br> -  Name<br> -  Version<br> -  Description<br> -  Minimum DataMiner version<br>Format: x.x.x.x-xxxx (e.g 10.0.11.0-9451)<br> -  Configuration parameters<br> -  …                                      |
| Scripts            | \-  Install.xml: a script containing all installation instructions<br> -  Config.xml: a script that will be launched when the application or solution is configured or reconfigured<br> -  InstallDependencies: a folder containing all DLL files used by the installation script<br> -  ConfigureDependencies: a folder containing all DLL files used by the configuration script |
| AppInstallContents | All auxiliary files needed by the installation script.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |

> [!NOTE]
> - The Install.xml script, which must be able to access all data stored in the AppInstallContents folder, should check whether the system contains an earlier version of the application or solution in question and upgrade it. A full installation from scratch is to be avoided.
> - All configuration parameters used by the Config.xml script can be specified in the AppInfo.xml file.

**Structure of the AppInfo.xml file**

```xml
<AppInfo>
  <Name>...</Name>
  <DisplayName>...</DisplayName>
  <Version>1.0.0</Version>
  <Description>...</Description>
  <LastModifiedAt>...</LastModifiedAt>
  <MinDmaVersion>...</MinDmaVersion>
  <AllowMultipleInstalledVersions>...</AllowMultipleInstalledVersions>
  <Configuration>
    <Entries>
      <Entry>
        <ID>...</ID>
        <Name>...</Name>
      </Entry>
      ...
    </Entries>
  </Configuration>
</AppInfo>
```

**Script entry points**

In both the Install.xml and Config.xml scripts, an entry point has to be defined.

- In the Install.xml script, define the following entry point:

    ```txt
    public class Script
    {
        [AutomationEntryPoint(AutomationEntryPointType.Types.InstallAppPackage)]
        public void Run(Engine engine, AppInstallContext context)
        {
            ...
        }
    }
    ```

    AppInstallContext has to contain the path to the extracted application package folder “AppInstallContents” as well as the version of the application package.

- In the Config.xml script, define the following entry point:

    ```txt
    public class Script
    {
        [AutomationEntryPoint(AutomationEntryPointType.Types.ConfigureApp)]
        public void Run(Engine engine, AppConfigurationContext context)
        {
            ...
        }
    }
    ```

    AppConfigurationContext has to contain the configuration entry values.

**Installing an application package**

Application packages can be uploaded, viewed, installed and configured using the DataMiner SLNetClientTest tool. All commands related to application packages can be found under Advanced \> Apps \> AppPackages.

> [!NOTE]
> To be allowed to install application packages, you must be granted the following user permission:
> - Modules \> System configuration \> Agents \> Install App packages

Although the above-mentioned method is to be preferred, it is also possible to embed an application package into a .dmupgrade package. To install an application package this way, do the following:

1. Create a .dmupgrade package.

2. In the UpdateContent.txt file of that package, add an “InstallApp” instruction, followed by the path to the application package you created earlier:

    ```txt
    InstallApp ./Path/To/AppPackage/AppPackage.zip
    ```

3. Install the .dmupgrade package on a DataMiner Agent that is running.

> [!NOTE]
> - Make sure the .dmupgrade package does not contain any instructions to stop the DataMiner Agent.
> - If you intend to install the .dmupgrade package using the DataMiner Taskbar Utility, make sure the DataMiner Agent is running.
> - If you install the .dmupgrade package onto a DataMiner System, the DataMiner Agent on which the upgrade is launched will run the installation script found in the application package. If the upgrade is launched from a DataMiner Agent that is not a member of the DataMiner System, then the DataMiner Agent with the first IP address (in alphabetical order) will run the installation script.
> - It is not possible to install an application package on multiple Agents of the same DataMiner System by adding their IP addresses to the “external IPs” list in DataMiner Cube. This would cause the installation script to be launched on each of the Agents in that list. If you want to install an application package on multiple Agents, you can select the Agents to be upgraded while connected to one of the Agents in the DataMiner System (which makes it unnecessary to have an external IPs list) or you can install it using the DataMiner Taskbar Utility.

**AppPackageHelper**

An AppPackageHelper class has been made available, containing a series of methods to manage application packages. The current methods include:

- UploadAppPackage

- GetUploadedAppPackages

- RemoveUploadedAppPackage

- InstallApp

- GetInstalledApps

- ConfigureInstalledApp

- GetCurrentAppConfiguration

#### LoggerUtil: RepositoryLoggerProvider & LogEntry API \[ID_26289\]\[ID_26291\]

The LoggerUtil tool now provides

- a RepositoryLoggerProvider that allows client applications to write log entries to an ElasticSearch database, and

- a LogEntry API that allows client applications to retrieve those entries.

A LogEntry object contains the following fields:

- Timestamp

- Message

- LogLevel

- Category (e.g. SRM.Reservations)

- Name (e.g. a specific booking ID)

- FullName (Category.Name)

- DmaId (ID of the DataMiner Agent to which the user was connected)

- ProcessId

- ProcessName

- ThreadId

- UserName

#### LogHelper API \[ID_26434\]

The new LogHelper API, which combines the SLLoggerUtil API and the LogEntry repository API, can be used in Automation scripts and in QActions to manage log entries stored in Indexing Engine:

- ILogHelper#Log can be used to add new log entries to the database.

- ILogHelper#LogEntries can be used to retrieve log entries from the database.

- LogEntries.Exposers can be used to create filters used when retrieving entries.

**Using statement**

LogHelper should always be created within a using statement. See the following examples.

Automation script example:

```txt
using(var logHelper = LogHelper.Create(engine.GetUserConnection()))
{
    // ...
 }
```

QAction example:

```txt
using(var logHelper = LogHelper.Create(protocol.GetUserConnection()))
{
    // ...
 }
```

**Automation**

A new method was added to Engine and IEngine:

- Engine#GetUserConnection() : IConnection

It returns a connection that impersonates the user who ran the script based on Engine#UserCookie. If no user cookie is present on the script, the returned IConnection will act as the SLManagedAutomation connection.

**QActions**

A new method was added on SLProtocol interface:

- SLProtocol#GetUserConnection() : IConnection

It returns a connection that impersonates the user who triggered the QAction based on SLProtocol#UserCookie. If no user cookie is present within the QAction context, the returned IConnection will act as the SLManagedScripting connection.

**Script and QAction compilation**

Automation scripts and QActions will now by default be compiled with a reference to SLLoggerUtil.dll (C:\\Skyline DataMiner\\Files\\SLLoggerUtil.dll).

#### Proactive cap detection \[ID_26637\]\[ID_27132\]\[ID_27241\]\[ID_27355\]\[ID_27393\]

To further enhance the proactive monitoring capabilities of DataMiner, proactive cap detection is now available. This DataMiner Analytics feature predicts future issues based on trend data in the Cassandra database, using advanced techniques that consider repeating patterns, information on the rate at which a parameter value increases or decreases, etc. However, note that some events simply cannot be predicted. For example, a spike in a trend graph caused by randomly pulling out a cable can never be predicted by looking at historical trend data, so proactive cap detection will not know about this in advance.

**Specifications**

For the best results, both real-time and average trending should be activated on a parameter for which you want proactive cap detection to be available. To calculate its predictions, DataMiner Analytics will make use of the available real-time data, 5-minute average data, 1-hour average data and daily average data. It can predict at most 200 data points into the future. This is further limited by the available data: if there is a data set of a specific number of points, DataMiner Analytics can never predict further than that number of points divided by ten. For example, if the database contains one year of hourly averages and no daily averages, then DataMiner Analytics computes 365 daily averages and is able to predict issues 36 days into the future.

This feature is currently only available for trended parameters with numeric values, and not for partial table parameters. Because of memory constraints, proactive cap detection is also only possible for up to 100 000 parameters per DMA. If there are more parameters for which proactive cap detection would be possible, no predictions will be available for these and the Analytics log file will mention that the number of tracked parameters exceeded the maximum.

in addition, proactive cap detection is currently only supported for parameters for which there are explicitly specified value bounds. It will predict when a parameter will cross one of these bounds:

- A high and/or low data range value specified in the protocol, or,

- A (by default) critical alarm limit of type normal (i.e. not rate or baseline) specified in the alarm template, or,

- A data range indirectly derived from the protocol info. Currently this is limited to the values 0 and 100 for percentage data for which no historical values were encountered outside the \[0,100\] interval.

However, note that in case there is both a data range in the protocol and an alarm threshold in an alarm template, the alarm template will get precedence.

**Configuration in DataMiner Cube**

In DataMiner Cube, you can enable this feature in System Center, via *System settings* > *analytics config*. There you can also configure the lowest alarm threshold severity that will be taken into account for proactive cap detection. If this is for example set to *Major*, proactive cap detection will alert the operator whenever a parameter is predicted to go out of range or is predicted to trigger a major or critical alarm.

**Suggestion events**

The notifications generated by the proactive cap detection feature are displayed in the suggestion events tab of the Alarm Console, along with the notifications for behavioral anomaly detection. These are alarms with severity "Information" and source "Suggestion Engine”.

The value of the suggestion event mentions what kind of issue is expected, e.g. a critical high or low alarm or an above or below range violation. The value also mentions between which times the issue is expected to occur. The closer to the predicted time, the more accurate this prediction will be, so the suggestion event will be automatically updated with more accurate information when appropriate. As soon as the predicted time of the incident has passed, the suggestion event will be cleared.

#### A notice will now be generated at DataMiner startup when duplicate properties are found for views, elements or services \[ID_26705\]

When, at DataMiner startup, duplicate properties are found for views, elements or services, from now on, one agent in the DataMiner System will generate a notice.

If an Administrator clears the notice manually, it will re-appear at the next DataMiner restart if the issue has not yet been resolved.

#### Custom prefix configuration for Elasticsearch indices \[ID_27091\]

To support the possibility to have two independent DataMiner Systems using the same Elasticsearch cluster, in the DB.xml file, you can now specify a custom prefix in the \<DB> tag for the Elasticsearch database, so that the Elasticsearch indices are updated with this prefix instead of the default "dms" prefix. Note that only regular alphanumeric characters are supported for the prefix, not symbols.

#### Support for FileCache tag in DB.xml \[ID_27314\]

To support the offload of files to a file cache instead of to a MySQL, MSSQL or Oracle central database, a new *FileCache* tag is now supported in the file DB.xml. for example:

```xml
<DataBase active="True" local = "false">
    <FileCache enabled="true">
        <MaxSizeKB>10000</MaxSizeKB>
    </FileCache>
</DataBase>
```

If the *enabled* attribute of this tag is set to *true*, files will still be offloaded to the system cache folder but not forwarded to the central database.

The *MaxSizeKb* subtag determines the maximum size of the offloaded files (by default 10 GB). If this limit is reached, the oldest files will be removed until the total size is again less than the defined limit.

#### Gradual introduction of inter-process communication via NATS \[ID_27496\]\[ID_28082\]\[ID_28131\] \[ID_28233\]\[ID_28660\]

From now on, more and more DataMiner processes will start to communicate with each other using NATS, an open-source messaging system.

The NATS and NAS services will automatically be installed on each NATS-enabled DataMiner Agent, and if NATS is enabled on every agent in a DataMiner System, all NATS installations in that system will be consolidated into a single NATS cluster.

> [!NOTE]
> - When NATS is enabled on a DataMiner Agent, firewall rules will automatically be added for ports 4222, 6222, 8222 and 9090.
> - Automatic detection and triggering of NATS cluster self healing can be activated or deactivated by setting the \<NATSDisasterCheck> option to true of false in the MaintenanceSettings.xml file.<br>Default setting: deactivated
> - Only users who have been granted the *Admin tools* permission (Modules \> System configuration \> Tools) are allowed to reset the NATS service.

#### SLSNMPAgent will now also use the SNMP++ library to forward SNMPv2 traps and inform mes­sages \[ID_27590\]

From now on, SLSNMPAgent will also use the SNMP++ library to forward SNMPv2 traps and inform messages. This means that it will now use the same library to send SNMPv1 traps, SNMPv2 traps and inform messages and SNMPv3 traps and inform messages.

> [!NOTE]
> - Due to limitations of the SNMP++ library, the inform message resend time cannot be set to a value less than 10ms. If you set it to a value less than 10ms, the default setting will be used instead (i.e. 30 ms).
> - From now on, all SNMPv2 traps and inform messages will by default include the “1.3.6.1.2.1.1.3.0” (sysUpTime) and “1.3.6.1.6.3.1.1.4.1.0” (snmpTrapOID) bindings.

### DMS Security

#### Jobs and ReservationInstances now have a SecurityViewID property to control access to them \[ID_24800\]

Jobs and ReservationInstances now have a SecurityViewID property.

If, for a particular job or ReservationInstance, this property contains a view ID, then the job or ReservationInstance will only be accessible to users who have access to the specified view.

- Users who display a list of jobs or ReservationInstances will only see the jobs or ReservationInstances associated with a view to which they have Read access.

- Users who try to create, update or delete a job or a ReservationInstance will only be able to do so if they have Write access to the view associated with that job or ReservationInstance.

> [!NOTE]
> - In case of ReservationInstances, it will still be possible to put other ReservationInstances (by updating a ReservationInstance, Resource or ProfileInstance) into quarantine to which you do not have access.
> - When performing scheduling checks, the ReservationInstances to which a user does not have access will still be taken into account.
> - All ReservationInstances in a particular tree must have the same SecurityViewID.
> - If a view specified in the SecurityViewID property of a job or ReservationInstance is deleted, then only Administrators or users with access to all views will have access to that job or ReservationInstance.

#### User management: Domain attribute of DataMiner users will now be filled in with the NETBIOS name if it can be found in the LDAP \[ID_25876\]

From now on, DataMiner users will have their domain attribute filled in with the domain's NETBIOS name if found in the LDAP. If this NETBIOS name cannot be found, the domain name will be used instead.

> [!NOTE]
> If a NETBIOS name can be found, it will also replace the domain name in Cube user names.

#### DataMiner Cube - System Center: New user permissions \[ID_26437\]

In the Users/Groups section of Cube’s System Center, the following user permissions have been added:

- Service profiles (UI available, Edit definitions, Edit instances)

- BPA tests (Create/Update, Delete, Read, Execute, Get test results)

#### Elasticsearch: Security now by default enabled on new installations \[ID_27026\]

From now on, when you install an Elasticsearch database, security will be enabled by default (basic authentication and TLS).

In the Db.xml file, it will now also be possible to configure an Elasticsearch user name and password. This will enable remote installations or current installations to also use basic Elasticsearch authentication features.

#### DataMiner Cube - System Center: Renamed user permissions \[ID_28439\]

In the *Users/Groups* section of *System Center*, the following has been changed:

- The *Allow access to Mobile UI* permission has been renamed to *DataMiner Cube mobile access*, and has been moved from the *Modules \> System configuration \> Mobile Gateway* section to the *General* section.

- All “local database” references have been renamed to “general database”.

#### Elasticsearch: Security now by default disabled on new installations \[ID_28598\]

From now on, when you install an Elasticsearch database, security will be disabled by default (basic authentication and TLS).

### DMS Protocols

#### Serial clients can now parse data past the trailer of a response of which the length is defined in a parameter of type “next param” \[ID_24442\]

From now on, when serial clients receive a response with a variable length (specified in a parameter of type “next param”), they will be able to parse it correctly when the trailer is not at the very end, but only if the following conditions apply:

- The response has to contain a trailer that is set before the data parameter. It does not have to contain a header.

- A length parameter should be located before the data parameter. It should be of length type “next param” and raw type “numeric text”.

- The length parameter has to be located either between two fixed parameters (e.g. “header before” and “trailer after”) or at the beginning of the response.

Up to now, when a response like the one in the example below was received, the data at the end would only be read after the command had timed out.

```txt
[header][length parameter (next param)][fixed-length parameter][another parameter of any type][trailer][data with length defined in length parameter]
```

#### NT_DELETE_FOLDER (182): Option added to bypass DataMiner recycle bin \[ID_24639\]

The NotifyDataMiner function “NT_DELETE_FOLDER” is now able to bypass the DataMiner recycle bin.

- If the function is called with its second argument set to true, the item specified in the first argument will be moved to the DataMiner recycle bin (default behavior if no second argument is passed).

- If the function is called with its second argument set to false, the item specified in the first argument will not be moved to the DataMiner recycle bin. Instead, it will physically be deleted.

Example:

```txt
string folderName = "Configurations";
bool bRecycle = true;
protocol.NotifyDataMiner(182 /*NT_DELETE_FOLDER*/, folderName, bRecycle);
```

> [!NOTE]
> If a relative path is passed to the NT_DELETE_FOLDER function, it will assume it to be relative to the *C:\\Skyline DataMiner\\Documents\\* folder. So, in the example above, the function will try to delete the *C:\\Skyline DataMiner\\Documents\\Configurations* folder. If you want it to delete the *C:\\Skyline DataMiner\\Configurations* folder, then you have to specify the full path.

#### Authentication via a client certificate when polling an HTTPS server \[ID_25243\]

When configuring an HTTPS session in a DataMiner protocol, you can now specify that authentication should be performed using a client certificate. To do so, in the \<Session> tag, set the loginMethod attribute to “certificate”.

```xml
<Session loginMethod="certificate">
  ...
</Session>
```

If, for a particular session, loginMethod is set to “certificate”, DataMiner will look for the Skyline DataMiner certificate in the Windows personal certificate store of the local machine and will use that certificate to authenticate all requests within that session.

> [!NOTE]
> As some web servers accept certificates even when they do not require them, DataMiner will not send a client certificate by default. It will send an empty certificate list instead. This will prevent any ERROR_WINHTTP-\_CLIENT_AUTH_CERT_NEEDED errors from being thrown.

#### Configuring the layout of a matrix \[ID_25456\]\[ID_25892\]

A typical matrix layout shows the inputs on the left and the outputs at the top. However, in certain circumstances, it can be useful to visualize a matrix in an alternative way.

In a protocol.xml file, it is now possible to configure the following matrix layouts:

- InputLeftOutputTop (default)

- InputTopOutputLeft

See the following example:

```xml
<Type link="labels.xml" options="matrix=64,64,0,1,0,64,pages">matrix</Type>
<Discreets matrixLayout="InputTopOutputLeft">
```

Per matrix, the layout can then be overridden using the NotifyDataMiner call NT_UPDATE_PORTS. See the examples below:

```txt
NotifyDataMiner(128 /* NT_UPDATE_PORTS */,"10;[ELEMENT_ID];[MATRIX_PARAM_ID];[DMA_ID]","InputLeftOutputTop");
```

```txt
NotifyDataMiner(128 /* NT_UPDATE_PORTS */,"10;[ELEMENT_ID];[MATRIX_PARAM_ID];[DMA_ID]","InputTopOutputLeft");
```

```txt
NotifyDataMiner(128 /* NT_UPDATE_PORTS */,"10;[ELEMENT_ID];[MATRIX_PARAM_ID];[DMA_ID]",MatrixLayoutOptions.INPUT_LEFT_OUTPUT_TOP);
```

```txt
NotifyDataMiner(128 /* NT_UPDATE_PORTS */,"10;[ELEMENT_ID];[MATRIX_PARAM_ID];[DMA_ID]",MatrixLayoutOptions.INPUT_TOP_OUTPUT_LEFT);
```

> [!NOTE]
> To change the layout of a matrix in DataMiner Cube, right-click the matrix and select the layout in the *Edit* window.
>
> Note that, in the alarm template, the default layout (e.g. inputs on the left, outputs at the top) will always be used. Although the layout of a matrix can be defined per element, an alarm template is not linked to a single element.

#### Socket buffer of a serial interface will now be flushed before a command is sent \[ID_26513\]

From now on, each time a command is sent via a serial interface, the socket buffer of that serial interface will be flushed in advance.

#### Replacing QAction DLL dependencies \[ID_26605\]

It is now possible to replace QAction DLL dependencies by installing a .dmprotocol package that contains an Assemblies folder with new DLL dependencies.

By default, the DLL files in the package will be copied to the C:\\Skyline DataMiner\\ ProtocolScripts\\dllImport folder. All DLL files in this folder will be synchronized among all agents in the DMS.

- When you upload a .dmprotocol containing a protocol identical to one that is already present on the system, the elements using that protocol will be restarted if the package contains at least one DLL file.

- If any QActions in protocols other than the one uploaded in the .dmprotocol package use a DLL file that was replaced, the elements using those protocols will not be restarted. QActions of those elements triggered before the .dmprotocol package was uploaded will continue to use the old dependency. Only after restarting DataMiner will the new dependency be used.

- If you want a DLL file to be placed in a subfolder of the dllImport folder, then add a subfolder in the .dmprotocol package. In that case, also specify that subfolder in the dllImport attribute of the QAction. For example, the C:\\Skyline DataMiner\\ProtocolScripts\\ dllImport\\subfolder\\example.dll file will only be found if the QAction references it using the following syntax: \<Qaction id="1" dllImport="subfolder\\example.dll" encoding="csharp" triggers="1">

    > [!NOTE]
    > When a DLL file is referenced using the dllImport attribute of a QAction (e.g. \<QAction id="5" dllImport="somedll.dll" encoding="csharp" triggers="1">), then the dllImport folder will be checked first. If the DLL file cannot be found in that folder, then the ProtocolScripts folder will be checked.

> [!NOTE]
> - If an uploaded DLL dependency would break existing QActions, no errors will be returned.
> - It is advised to strong-name DLL files when referring to multiple versions of the same file in different QActions. Not strong-naming DLL files could lead to unexpected behavior.

#### NT_SNMP_RAW_GET, NT_SNMP_RAW_SET, NT_SNMP_GET and NT_SNMP_SET requests now sup­port the credential library \[ID_27275\]

The NT_SNMP_RAW_GET, NT_SNMP_RAW_SET, NT_SNMP_GET and NT_SNMP_SET requests now support the credential library.

- If you pass a GUID, you do not need to pass any credentials.

- If you do not pass a GUID or you pass an empty string instead of a GUID, you must pass credentials in plain text. When you pass neither a GUID nor plain-text credentials, the request will be considered invalid.

> [!NOTE]
> - Library credentials take precedence over plain-text credentials.
> - If you pass an invalid GUID (either a non-existing GUID or a GUID of an incorrect type), the request will be considered invalid. There will be no fall-back to plain-text credentials.

See the examples below.

**GET**

```txt
// NotifyDataMiner NT_SNMP_RAW_GET
object[] oTableElementInfo = new object[10];
...
oTableElementInfo[9] = "665d680e-4097-455c-9ffc-0e4a06fa63c1";
result = (object[])protocol.NotifyDataMiner(424 /*NT_SNMP_RAW_GET*/,         oTableElementInfo, oRequestInfo);

// NotifyProtocol NT_SNMP_GET
object[] oTableElementInfo = new object[15];
...
oTableElementInfo[14] = "665d680e-4097-455c-9ffc-0e4a06fa63c1";
result = (object[])protocol.NotifyProtocol(295 /*NT_SNMP_GET*/,         oTableElementInfo, oRequestInfo);
```

**SET**

```txt
// NotifyDataMiner NT_SNMP_RAW_SET
object[] oTableElementInfo = new object[8];
...
oTableElementInfo[7] = "665d680e-4097-455c-9ffc-0e4a06fa63c1";
result = (object[])protocol.NotifyDataMiner(425 /*NT_SNMP_RAW_SET*/,         oTableElementInfo, oRequestInfo);

// NotifyProtocol NT_SNMP_SET
object[] oTableElementInfo = new object[12];
...
oTableElementInfo[11] = "665d680e-4097-455c-9ffc-0e4a06fa63c1";
result = (object[])protocol.NotifyProtocol(292 /*NT_SNMP_SET*/,         oTableElementInfo, oRequestInfo);
```

#### A message body can now be added to raw HTTP requests \[ID_27438\]

In a QAction, it is now possible to add a message body to raw HTTP requests sent in a multi-threaded timer.

Old syntax:

```txt
object[] httpRequestInfo = new object[3] { "http", new string[6] { sVerb, sURL, sUser, sPass, httpHeaders, "200" }, new string[1] { httpCommand } };
```

New syntax:

```txt
object[] httpRequestInfo = new object[3] { "http", new string[6] { sVerb, sURL, sUser, sPass, httpHeaders, "200" }, new object[1] { new string[2] { httpCommand, dataToSend } } };
```

> [!NOTE]
> - The old syntax can still be used. If you use the old syntax, no message bodies will be sent. If you use the new syntax for a single resource, no message body needs to be added. In that case, you should define an empty string instead.
> - By adding the message bodies to the last array in the request, the new syntax allows you to send a different message body to each of the different subpages.
> - Using the new syntax, the last array can be an object array of string arrays of size 2:
>     - The first part of each string array is the subpage to which the request needs to be sent.
>     - The second part of each string array is the message body that needs to be sent to that specific subpage.
> - DataMiner does not format the given message body in any way. It is forwarded as received from within the QAction. It is up to the user to correctly format the message body.

#### Updating direct views showing data from elements on remote DMAs \[ID_27547\]

From now on, DirectView updates are supported in the following scenarios:

- DirectView based on a view of the same protocol

    Example:

    ```txt
    Protocol: view=200;directView=905 table config;view=201 column config or view=211:305
    ```

- DirectView based on a view of the same protocol with a single element source.

    Example:

    ```txt
    directView=6298 Pointing to a standalone parameter rather than a column parameter
    ```

- onlyFilteredDirectView based on a view of the same protocol

    > [!NOTE]
    > onlyFilteredDirectView will only return data when a filtered subscription is made on the directView.

- DirectView based on a different protocol

    Example:

    ```txt
    filterChange=DirectViewColumnID A-RemoteDataColumnID A, DirectViewColumnID B-RemoteDataColumnID B, ...
    ```

- DirectView based on a different protocol with a filter specifying the element sources to be included.

    Example:

    ```txt
    directView=6505 => FILTER: value=6501 == REMOTE-DATA-1
    ```

#### Values displayed using scientific notation will now use a dot as separator \[ID_27690\]

Values set to be displayed using scientific notation will now use a dot instead of a comma as separator.

### DMS Cube

#### Visual Overview: Number groups in numeric parameter values displayed on element shapes will now be separated by a thin space / New DynamicUnits option \[ID_18321\]\[ID_26318\]\[ID_26330\]<br>\[ID_26697\]\[ID_27544\]

In Visual Overview, three-digit number groups in numeric parameter values displayed on shapes with an *Element* and/or *Parameter* data field and a “\*” in the shape text will now by default be separated by a thin space. This will make large numbers more legible.

Also, a new *DynamicUnits* option will now allow you to enable the use of dynamic units, i.e. units that can be converted to other units according to rules configured in the protocol. You may decide to enable this feature if you want to have large values converted to more legible values (e.g. to convert 1000 Mb to 1 Gb, 1000 m to 1 km, etc.).

To enable this feature, add an *Options* data field and set its value to “DynamicUnits=true”. By default, this option is disabled (i.e. false). See the following example:

| Shape data field | Value             |
|------------------|-------------------|
| Element          | MyElement         |
| Parameter        | 25                |
| Options          | DynamicUnits=true |

If you enable the *DynamicUnits* option, the following units will be converted out of the box:

- bytes (B)

- bits (b)

- bits per second (bps)

- bytes per second (Bps)

- Kibibytes (kiB)

- no unit (\<empty>)

If you want other units to be converted when you enable the *DynamicUnits* option, you can define this in the element protocol. See the example below.

Suppose you want to apply the following unit conversion rule:

- Display value in mm if value \< 1 cm.

- Display value in cm if value \> 1 cm.

- Display value in m if value \> 1 m.

- Display value in km if value \> 1 km.

Then, in the protocol, add the following configuration:

```xml
<Display>
  <RTDisplay>true</RTDisplay>
  <Units>m</Units>
  <DynamicUnits>
    <Unit>mm</Unit>
    <Unit>cm</Unit>
    <Unit>km</Unit>
  </DynamicUnits>
  <Decimals>2</Decimals>
  ..
</Display>
```

It is also possible to factor in decimals defined in the dynamic units of a protocol parameter when using the *DynamicUnits* option. With a configuration like the following, a value of 0.15 m will be shown as 15.0 cm (i.e. with 1 decimal).

```xml
<Display>
  <RTDisplay>true</RTDisplay>
  <Units>m</Units>
  <DynamicUnits>
    <Unit>mm</Unit>
    <Unit decimals=”1”>cm</Unit>
    <Unit decimals=”3”>km</Unit>
  </DynamicUnits>
  <Decimals>2</Decimals>
  ..
</Display>
```

> [!NOTE]
> If parameter values of parameters with “decimals” set to 1 or less are converted to a bigger unit, these will be displayed with such a number of decimals that there are at least 3 significant figures. For example, 1320 MB will be displayed as 1.32 GB, even if the parameter has 0 decimals defined.

#### Data Display: Table column layout can now be customized and saved per table \[ID_22866\]

It is now possible to save the layout of a table column after having customized it.

After changing the width, the position and/or the visibility of a column, right-click its header, and select *Save layout*. To reset the column layout to the default settings, select *Reset layout*.

#### Alarm Console: Alarm events without a severity change can now be consolidated in the preced­ing event in the alarm tree \[ID_23234\]\[ID_23526\]\[ID_24462\]\[ID_27413\]

From now on, when an alarm tree contains alarm events that did not change the severity, these events can be consolidated in the previous event.

When you open an alarm card that shows an alarm tree containing consolidated events, you can click *Show all alarm updates* to have the tree expanded to show all events.

> [!NOTE]
> - The maximum alarm limit is calculated after alarm event consolidation.
> - Alarm consolidation is disabled by default. To enable it, add an *AlarmSettings.MustSquashAlarms* element to the *MaintenanceSettings.xml* file, and set its value to True.

#### Possibility to enable SSL/TLS encryption when creating or editing TCP/IP elements \[ID_23262\]\[ID_23617\]\[ID_23836\]\[ID_23947\]

When creating or editing a TCP/IP element, you can now enable SSL/TLS encryption.

To enable TLS, do the following on every DataMiner Agent in a DataMiner System containing elements that use TLS encryption:

1. In the C:\\Skyline DataMiner\\Certificates folder, place a PKCS12 file with (default) name “server.pfx”, containing the certificates and the private key.

2. Send a ConfigureTLSMessage with the following arguments:

    | Argument        | Description                                                                                                                                                       |
    |-------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | DataMinerID       | ID of the DataMiner Agent ID.                                                                                                                                     |
    | EncryptedPassword | Encrypted\* password that will be used with the certificate in question.<br> *\*Encrypted using the public key of the connection.* |
    | Certificate       | Name of the certificate for which the password is set.<br> Default: server.pfx                                                                                    |
    | ID                | ID of the certificate for which the password is set.<br> Currently, DataMiner will always use the certificate with ID 0.                                          |

> [!NOTE]
> - DataMiner currently supports all TLS versions up to TLS 1.3 (i.e. all TLS versions supported by OpenSSL 1.1.1). It will negotiate the highest supported TLS version with the client. If the client supports TLS up to version 1.2, DataMiner will use version 1.2.
> - PFX files are not synchronized among the agents in a cluster.
> - When, on a DataMiner Agent, you replace a PKCS12 file, then all elements using the TCP/IP port in question have to be stopped and restarted for the changes to take effect.
> - TLS elements and non-TLS elements sharing the same TCP/IP port is not supported.

#### Visual Overview - Trend component: Filtering the legend’s element list and collapsing or expanding the legend by default \[ID_24349\]

When a shape is showing a trend component, it is now possible to

- filter the list of elements in the legend based on the value of a property of the Visio shape (see the *Filter* data item in the example below), and

- collapse or expand the legend by default (see the *ParametersOptions* data item in the example below).

Example:

| Shape data field  | Value                                                                |
|-------------------|----------------------------------------------------------------------|
| Component         | Trending                                                             |
| Parameters        | *DmaID:ElementID:ParameterID*         |
| ParametersOptions | CollapseLegend:true                                                  |
| Filter            | Property:*PropertyName=PropertyValue* |

#### Visual Overview: Linking a shape to an alarm via the root alarm ID \[ID_24367\]

From now on, a shape can also be linked to an alarm via the root alarm ID.

To do so, add a shape data field of type “Alarm” to the shape, and set its value to DmaID/RootAlarmID. If the alarm cannot be found, the shape will not be displayed.

If you want a shape linked to an alarm to visualize the root alarm ID, you can add a shape data field of type “Info”, and set its value to “ROOT ALARM ID”.

Example:

| Shape data field | Value             |
|------------------|-------------------|
| Alarm            | DmaID/RootAlarmID |
| Info             | ROOT ALARM ID     |

> [!NOTE]
> - If a shape is linked to an alarm, you can now also use the Info keywords in the shape text (enclosed in square brackets). For example: “The value of the alarm is \[value\].”
> - Note that, when you link shapes to alarms, only active alarms can currently be shown.

#### Visual Overview: Filtering an alarm tab by clicking an AlarmSummary shape \[ID_24380\]

By linking a shape to an alarm filter using an *AlarmSummary* data item, you can show statistical information about the alarms that match the filter. From now on, it is also possible to have the alarms displayed in an alarm tab, filtered according to the filter specified in the shape.

To do so, add a data item of type *AlarmTab*, and set its value to “Name=”, followed by the name of an alarm tab. See the example below.

When you click the shape, Cube will open the specified alarm tab (if it has a filter applied) and apply the alarm filter specified in the *AlarmSummary* data item. If the alarm tab specified in the *AlarmTab* data item has no alarm filter applied or if no alarm tab exists with that name, one will first be created.

| Shape data field | Value                                                                |
|------------------|----------------------------------------------------------------------|
| AlarmSummary     | type\|sharedfiltername\|ApplyLinkedViewServiceOrElementFilter\|Alarm |
| AlarmTab         | Name=AlarmTabName                                                    |

#### Visual Overview: Adding a search box to a SetVar selection box control \[ID_24448\]

Using a *SetVar* data field, you can turn a shape or a page into a selection box control that allows users to update a session variable. From now on, it is possible to add a search box to such a selection box.

To do so, specify “Control=FilterComboBox” in a *SetVarOptions* data field. See the following example:

| Shape data field | Value                                             |
|------------------|---------------------------------------------------|
| SetVar           | \[Sep::;\]MySessionVariable;\[Param:25/1245,568\] |
| SetVarOptions    | Control=FilterComboBox                            |

> [!NOTE]
> HTML5 mobile apps do not support selection boxes with a search box. Selection boxes that have a search box configured will be displayed as regular selection boxes without search box.

#### Elements that request data from a device via a serial port of type TCP/IP now support SSL/TLS encryption \[ID_23462\]

Elements that request data from a device via a serial port of type TCP/IP now support SSL/TLS encryption.

If you want such an element to use SSL/TLS encryption, then do the following:

1. Right-click the element, and select *Edit*.

2. In the *Edit* tab, go to the *Serial connection* section containing the settings of the port in question, and select the *SSL/TLS* check box.

> [!NOTE]
> DataMiner currently supports all TLS versions up to TLS 1.3 (i.e. all TLS versions supported by OpenSSL 1.1.1).
>
> Elements acting as SSL/TLS client will negotiate the highest supported SSL/TLS version with the server. If the server supports TLS up to version 1.2, the element will use version 1.2.

#### Service & Resource Management: Clearer warning messages will now appear when trying to delete resources linked to bookings or elements linked to resources \[ID_24435\]\[ID_25085\]

From now on, clearer warning messages will appear when you try to delete

- a resource linked to a booking, or

- an element linked to one or more resources.

#### Visual Overview: Using “info keywords” in all data items of a shape linked to an alarm \[ID_24485\]

Up to now, there were two ways to have a shape linked to an alarm show information about that alarm:

- Add an *Info* data item and set its value to a particular alarm keyword, and type a “\*” character in the shape text. The “\*” character will then be replaced by the value of the keyword you specified in the *Info* data item.

- Enter one or more alarm keywords (wrapped in square brackets) in the shape text. Those will then be replaced by their corresponding value.

From now on, it is also possible to specify alarm keywords in shape data items other than *Info*.

Example:

| Shape data field | Value                        |
|------------------|------------------------------|
| Alarm            | 10/20/500                    |
| SetVar           | MyVariable:\[root alarm id\] |

> [!NOTE]
> - To prevent infinite loops, do not specify alarm keywords in a shape data item of type *Alarm*.
> - Currently, it is not yet possible to use these keywords inside other keywords.

#### Visual Overview: Displaying a Visio page when the shape is not linked to an element, a view or a service \[ID_24507\]

Up to now, it was only possible to display a page of a Visio file associated with an object linked to a shape. To have a page named “Details” of a Visio file associated with an element named “MyElement” displayed in a separate window, for example, you had to add two data items to a shape: one of type *Element* set to “MyElement”, and one of type *VdxPage* set to “Details\|Window”.

From now on, it is also possible to display a page from the current Visio file by only adding a single data item of type *VdxPage* to a shape, without any reference to an element, view or service. This will allow you to also display Visio pages when a shape is linked to e.g. an alarm. See the following example:

| Shape data field | Value           |
|------------------|-----------------|
| VdxPage          | Details\|Window |

> [!NOTE]
> If you do not specify a window type suffix (“Window”, “Popup” or “ToolTip”), the Visio page will be displayed inside the shape.

#### Visual Overview: New option to disable path highlighting when clicking a connection line \[ID_24544\]

Up to now, when you clicked a connection line between shapes, the path connected to that line was highlighted by default.

This default behavior can now be changed by adding a *SelectionHighlighting* option to the shape that represents the connection and setting it to “False”. See the following example.

| Shape data field | Value                       |
|------------------|-----------------------------|
| Connection       | Connectivity                |
| Options          | SelectionHighlighting=False |

#### Visual Overview: New FilterContext option for shape linked to alarm filter \[ID_24577\]

When a shape is linked to an alarm filter, you can now add an additional element, service or view filter to the *AlarmSummary* shape data, using a pipe symbol ("\|") as separator. The syntax of this filter is "*FilterContext=*" followed by the name or ID of the element, service or view.

If you have configured the shape to open an alarm tab in the Alarm Console when it is clicked, this filter will also be taken into account for the alarm tab. For example:

| Shape data field | Value                                                       |
|------------------|-------------------------------------------------------------|
| AlarmSummary     | active\|MyFilterName\|false\|Alarm\|FilterContext=MyService |
| AlarmTab         | Name=MyFilteredTab                                          |

#### Anomaly detection configuration in alarm templates \[ID_24578\]

It is now possible to enable specific anomaly detection options for parameters in an alarm template. To do so, select the *Advanced configuration of anomaly detection* option via the cogwheel button in the alarm template editor. Three additional columns will then be displayed in the alarm template, where you can enable or disable trend monitor, variance monitor and level shift anomaly detection for each monitored parameter.

#### Visual Overview: New Set option “SetTrigger=Event” & additional IOClicked event arguments \[ID_24582\]

**New Set option “SetTrigger=Event”**

Up to now, in a page-level shape data field of type *Execute*, you could specify the “SetTrigger=ValueChanged” option in a *Set* command to have parameters or session variables updated on an open Visual Overview page when a specific value changes.

From now on, it is also possible to have a *Set* command update parameters or session variables on an open Visual Overview page when an event occurs on that page. To do so, you have to specify the “SetTrigger=Event” option.

In the following example, every time the event is triggered from the router control, the set command will be executed with the label of the clicked matrix. Clicking the same input or output multiple times will each time cause the set command to be executed. Note that, if you would specify “SetTrigger=ValueChanged” instead of “SetTrigger=Event”, clicking the same input or output multiple times would cause the set command to be executed only once.

| Shape data field | Value                                                      |
|------------------|------------------------------------------------------------|
| Execute          | Set\|1/1\|350\|\[Event:IOClicked,Label\]\|SetTrigger=Event |

> [!NOTE]
> All *Set* commands with a “SetTrigger=Event” option will be triggered when an event occurs, even those that do not contain an \[Event:\] placeholder.

**Additional IOClicked event arguments**

The following additional arguments can now be specified when configuring the router control event “IOClicked” in an \[Event:\] placeholder:

| Argument | Description                                                       |
|----------|-------------------------------------------------------------------|
| Type     | “input” or “output”, depending on the type of the interface.      |
| Matrix   | The name of the matrix that contains the clicked input or output. |

#### Service & Resource Management - ListView: Alarm count column can now indicate the number of alarms as a colored icon \[ID_24598\]

In the ListView component, which is used in the Bookings and Services apps as well as in Visual Overview, the *Alarm count* column can now be configured to indicate the number of alarms as an icon taking the color of the most severe alarm.

#### Visual Overview: New MinChartHeight parameter option for trend component \[ID_24706\]

It is now possible to configure the minimum height of the chart area of a trend component. Previously, this was always set to 200 pixels. To make sure this height is reached, the legend of the trend component will become smaller when necessary, or it may even be hidden.

To configure the minimum height of a trend component, add the option *MinChartHeight* to the *ParametersOptions* shape data.

For example, with the configuration below, the minimum height of the chart area will be 400 pixels.

| Shape data field  | Value                               |
|-------------------|-------------------------------------|
| Component         | Trending                            |
| ParametersOptions | ShowLegend:true\|MinChartHeight=400 |
| Parameters        | 1/20:500:\*                         |

#### New setting to display a Forward button in card header bar menus \[ID_24844\]

In the new Cube X layout, by default, cards no longer have a Forward button in their header bar menu.

If you want card header bar menus to contain a Forward button, then open the *C:\\Skyline DataMiner\\Users\\ClientSettings.json* file, and set the *commonServer.card.DisplayForwardButton* option to true.

#### Alarm Console now fully compliant with the new Cube X style \[ID_24859\]

The Alarm Console has been redesigned and is now fully compliant with the new Cube X style.

#### Alarm templates: Conditional monitoring based on a cell value from either the same table or another table \[ID_24867\]\[ID_24933\]

In an alarm template, it is now possible to configure a condition on a column parameter based on the value of a cell in either the same table or a different table.

> [!NOTE]
> This feature does not support view tables.

You can define the following:

- A condition on a column parameter receiving its data from an unrelated table.

    In this case, the primary keys of both tables will be matched, and the condition will apply when, in the column used in the condition, the row with the same key is changed.

- A condition on a specific cell of a column parameter.

    - If the two tables are unrelated, the condition will apply to all cells in the monitored column, but only when the cell specified in the condition has changed.

        When any other cell in the same column as the cell specified in the condition changes, it will not have any impact on the monitoring.

    - If the two tables are related, the condition will apply to all cells in the monitored column linked to the row containing the cell specified in the condition.

        All other cells in the monitored column will not be impacted by the condition as they are not linked to the cell specified in the condition.

> [!NOTE]
> When the cell specified in the condition is located in a column of the same table, the behavior will be identical to that of unrelated tables. In other words, the entire monitored column will be impacted.

**New rule attributes: keyType and keyValue**

This new feature relies on two new rule attributes: *keyType* and *keyValue*.

- The *keyType* attribute can have two values: “PK” (primary key) or “DK” (display key).

- The *keyValue* attribute has to contain the value that will be used in the condition.

In the example below, parameter 203 is a column of table 200, and the cell in column 203 that matches the corresponding key will be used in the condition.

```xml
<Condition id="5" name="Condition3">
  <Rule pid="203" comparer="eq" value="4" next="or" keyType="DK"      keyValue="DisplayKey3"/>
  <Rule pid="203" comparer="eq" value="3" keyType="PK"      keyValue="2"/>
</Condition>
```

> [!NOTE]
> Inside a rule, both the *keyType* and *keyValue* have to be filled in for this feature to work.
>
> The *keyValue* attribute will always refer to the key (primary key or display key) of the table containing the column parameter used in the condition, not the key in the column parameter being monitored.

#### Trending: Automatic pattern matching \[ID_24893\]\[ID_25708\]

On systems with a Cassandra database and an Indexing Engine, from now on, DataMiner will be able to automatically recognize recurring patterns in trend data called “tags”.

To define a tag:

1. In a trend graph showing trend information for one single parameter, select the portion of the graph that you identify as being a recurring pattern.

2. Enter a tag name and click the check mark to save.

Any matching patterns in the current trend graph will immediately be highlighted in orange. Matches found for the same element/parameter as the one for which a tag was defined will appear in bright orange, whereas matches associated with tags created for another element/parameter will appear in a slightly lighter hue.

> [!NOTE]
> If automatic pattern matching is enabled, each time you open a trend graph of a parameter for which patterns have been defined, all trend graph portions that match one of the saved patterns will be highlighted.

To edit a tag:

1. Click the tag button above the (highlighted) pattern you want to edit.

2. To edit the tag name, click the pencil icon and change the name.

3. To redefine the pattern, adjust its boundaries.

4. To save any modifications, click the check mark.

> [!NOTE]
> If you edit a tag, the pattern will always be overwritten, even if you did not redefine the pattern in any way.

To delete a tag:

1. Click the tag button above the (highlighted) pattern you want to delete.

2. Click the delete icon.

3. In the confirmation box, click *Yes*.

> [!NOTE]
> - If you delete a tag, all pattern matches associated with that tag will also be deleted.
> - If a protocol is deleted, all patterns defined for parameters of that protocol will also be deleted the first time the SLAnalytics service restarts.

**Current limitations**

Currently, automatic pattern matching has the following limitations:

- Patterns must have a size between 8 and 50,000 data points and should not have more than 5 percent missing values.

- Pattern matching can only be performed on trended parameters containing numeric val­ues.

- If pattern matching is performed on a trend graph showing more than 100,000 data points, an aggregated level of detail will be used to improve performance at the cost of accuracy. If, at the most aggregated level, the number of data points exceeds 100,000 data points, no pattern matching will be performed.

**Changes as to trend graph mouse button actions**

In the *User \> Trending* section of the *Settings* window, the *Left mouse button action on graph* and *Right mouse button action on graph* settings can now be set to one of four values:

- Select (new option, allowing you to select part of a trend graph)

- Zoom (former “Select” option, default right mouse button action)

- Pan (default left mouse button action)

- None

In case of the (new) “Select” option, a quick menu will appear, allowing you to either zoom to the part of the trend graph you selected or to create a tag (see above). On both sides of the selection, thumb draggers will also appear to allow you to resize the area you selected.

Also, apart from the *Left mouse button action on graph* and *Right mouse button action on graph* settings, two new settings have been added:

| Setting                                    | Description                                                                                                                                |
|--------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------|
| Hotkey for mouse button action on graph    | The key that, when pressed while clicking the left mouse button, will cause the “hotkey + left mouse button action” to be performed.       |
| Hotkey + left mouse button action on graph | Action to be performed when you press the “hotkey for mouse button action” while clicking the left mouse button: Select, Zoom, Pan or None |

#### Alarm Console: Severity duration column in history alarm tabs \[ID_24942\]

Next to active alarm tab pages, history tab pages now also allow you to display a severity duration column.

On history tab pages, a severity duration column will be available either when no filter is applied or when a filter based on Element ID, DMA ID, Element Type, Parameter ID, Protocol and/or Source ID is applied.

DataMiner Cube will calculate severity durations based on the alarms listed on the history tab page in question. If the duration of an alarm cannot be calculated (e.g. because the next alarm is not listed on the history tab page, or because the alarm has not been cleared while the element is stopped), the severity duration column will show “N/A”.

Additionally, a number of enhancements have been made with respect to severity durations. For instance, it is now also possible to display the severity duration when history tracking is disabled.

#### Visual Overview: Shapes linked to views can now have an “AlarmLevel” shape data field \[ID_24952\]

To a shape linked to a view, you can now add a shape data field of type “AlarmLevel” to configure which of the view’s alarm levels you want the shape’s background color to display.

| Shape data field | Value                                                                                                                                                                                                                                                                                                                                                                                                                                           |
|------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| AlarmLevel       | Instance/BubbleUp/Summary<br> -  Instance: Alarm level of the monitored aggregation rules on the view.<br> -  BubbleUp: Highest alarm level of any child element or child view.<br> -  Summary: Highest of the Instance and BubbleUp alarm levels. |

#### Exporting element data to CSV: Fields added to export file \[ID_25049\]\[ID_25239\]

When you export element data to a CSV file, from now on, the export file will include the following additional fields:

| Array index | Field name           | Description                                                                                            |
|-------------|----------------------|--------------------------------------------------------------------------------------------------------|
| \[49\]      | ReplicationMaxBuffer | *(for future use, currently empty)*                                     |
| \[50\]      | ReplicationMinBuffer | *(for future use, currently empty)*                                     |
| \[51\]      | ProtocolType         | Protocol type per port<br> (can be a list of tab-separated values)                                     |
| \[52\]      | CredentialGUID       | Credential GUID per port<br> (can be a list of tab-separated values)                                   |
| \[53\]      | TLS                  | SSL TLS setting per port<br> (can be a list of tab-separated values)                                   |
| \[54\]      | AllowedIpAddresses   | Comma-separated list of allowed IP addresses per interface<br> (can be a list of tab-separated values) |

#### Visual Overview - ListView: Enhanced filter capabilities \[ID_25114\]

**View filters**

When specifying view filters using the view name instead of the view ID, an alternative syntax can now be used: *ViewName=\<name>*

Also, you can now use the "==" operator instead of the "=" operator. If the *ViewName* syntax is used, DataMiner will first try to filter by name, and then by ID in case the name cannot be found. If the *View* syntax is used, DataMiner will first try to filter by ID ,and then by name if the ID cannot be found. The filter can contain only one *View* or *ViewName* part.

**Element/service filters**

From now on, if you set the *Source* shape data field to “Elements” or “Services”, additional possibilities are available to add an element or service filter in the *Filter* shape data field:

- The following operators are supported: “*==*” (equals), “*!=*” (does not equal), “*contains*”, “*notContains*”, “*startswith*”, “*notStartswith*”, “*endsWith*", “*notEndsWith*", "*\<*" (smaller than, only usable with numbers) and "*\>*" (greater than, only usable with numbers). The value that is being compared with should always be included in single quotes.

- The following terms can be used to filter on:

    | Filter term                                                  | Description                                                                                                                                                                                                                                                                                                              |
    |----------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Element.ID                                                     | The ID of an element.                                                                                                                                                                                                                                                                                                    |
    | Element.Name                                                   | The name of an element.                                                                                                                                                                                                                                                                                                  |
    | Element.Description                                            | The description of an element.                                                                                                                                                                                                                                                                                           |
    | Element.DataMiner                                              | The name of the DMA on which an element is located.                                                                                                                                                                                                                                                                      |
    | Element.AlarmLevel                                             | The technical alarm level of the element. This is the non-localized, DataMiner-internal equivalent of the alarm state. For example, the alarm level "Undefined" is the same as the alarm state "Not monitored, the alarm level "Normal" is equivalent to the alarm state "Normaal" if the Dutch version of Cube is used. |
    | Element.AlarmState                                             | The alarm state of the element. For the difference with the alarm level, see "Element.AlarmLevel".                                                                                                                                                                                                                       |
    | Element.AlarmCount                                             | The number of alarms of the element.                                                                                                                                                                                                                                                                                     |
    | Element.Type                                                   | The type of element as defined in the protocol.                                                                                                                                                                                                                                                                          |
    | Element.DisplayType                                            | The display type of the element as defined in the protocol, e.g. *spectrum analyzer*, *element manager*.                                                                                                                                                           |
    | Element.IP                                                     | The IP of the element.                                                                                                                                                                                                                                                                                                   |
    | Element.State                                                  | The current state of the element, e.g. Paused, Stopped.                                                                                                                                                                                                                                                                  |
    | Element.Protocol                                               | The protocol used by the element.                                                                                                                                                                                                                                                                                        |
    | Element.ProtocolVersion                                        | The protocol version used by the element.                                                                                                                                                                                                                                                                                |
    | Element.ProtocolType                                           | The protocol type used by the element.                                                                                                                                                                                                                                                                                   |
    | Element.AlarmTemplate                                          | The alarm template used by the element.                                                                                                                                                                                                                                                                                  |
    | Element.TrendTemplate                                          | The trend template used by the element.                                                                                                                                                                                                                                                                                  |
    | Element.Property.*PropertyName* | The property of the element with the specified property name.                                                                                                                                                                                                                                                            |
    | Service.ID                                                     | The ID of a service.                                                                                                                                                                                                                                                                                                     |
    | Service.Name                                                   | The name of a service.                                                                                                                                                                                                                                                                                                   |
    | Service.Description                                            | The description of a service.                                                                                                                                                                                                                                                                                            |
    | Service.DataMiner                                              | The name of the DMA on which a service is located.                                                                                                                                                                                                                                                                       |
    | Service.AlarmLevel                                             | The technical alarm level of the service. This is the non-localized, DataMiner-internal equivalent of the alarm state. For example, the alarm level "Undefined" is the same as the alarm state "Not monitored, the alarm level "Normal" is equivalent to the alarm state "Normaal" if the Dutch version of Cube is used. |
    | Service.AlarmState                                             | The alarm state of the service. For the difference with the alarm level, see "Service.AlarmLevel".                                                                                                                                                                                                                       |
    | Service.AlarmCount                                             | The number of alarms of the service.                                                                                                                                                                                                                                                                                     |
    | Service.Property.*PropertyName* | The property of the service with the specified property name.                                                                                                                                                                                                                                                            |

- You can combine different search terms with each other and with one view filter, using pipe characters ("\|"). The pipe character is used as an AND operator.

- Session variables can also be used in these filters.

- Examples:

    - To filter on all elements of which the name contains the word "function" and the element property IDP is set to "Source":

        ```txt
        Element.Name contains 'function'|Element.Property.IDP == 'Source'
        ```

    - To filter on all services of which the name contains the word "\_booking" and that are hosted by the DataMiner Agent "MyDMA":

        ```txt
        Service.DataMiner == 'MyDMA'|Service.Name contains '_booking'
        ```

    - To filter on all elements using the protocol "MyProtocol" with the protocol type "serial" which are not of element type "Relay":

        ```txt
        Element.Protocol == 'MyProtocol'|Element.ProtocolType == 'serial'|Element.Type notContains 'Relay'
        ```

    - To filter on all element using the property IDP with a property value equal to that of the session variable "MySelectedValue":

        ```txt
        Element.Property.IDP == [var:MySelectedValue]
        ```

> [!NOTE]
> The filters are not case-sensitive. For example, a service with the name "MyName" will be found when the filter *Service.Name == 'myname'* is used

#### System Center: New “Analytics config” system settings section \[ID_25124\]\[ID_26388\]\[ID_26912\]

In *System Center*, the *System settings* section now contains a new *Analytics config* page, which allows you to configure a number of SLAnalytics settings.

> [!NOTE]
> If you take a DMA out of a cluster, we strongly recommend to restart it in order to prevent issues with the analytics configuration in case the DMA is added to the cluster again later.

#### Alarm Console: Automatic incident tracking \[ID_25162\]\[ID_25802\]\[ID_25905\]\[ID_26592\]\[ID_27027\]<br>\[ID_27299\]\[ID_27336\]\[ID_27877\]

This new DataMiner Analytics feature groups active alarms that are related to the same incident, so that the Alarm Console provides a better overview of the current issues in the system. Unlike *Correlation tracking*, this happens completely automatically, without any configuration by the user. Based on what it has learned from past alarm activity in your system and based on a broad range of auxiliary data, DataMiner Analytics automatically detects which alarms share a common trait and groups them as one incident.

To activate this feature, in the Alarm Console hamburger menu, select *Automatic incident tracking*. However, note that the feature must also be activated in System Center (see “Configuration in System Center” below).

Several factors are taken into account for the grouping:

- The polling IP (for timeout alarms only)

- Service information

- The IDP location (only in case the IDP Solution is deployed)

- Element information

- Parameter information

- Time

- Alarm focus information

If no suitable match is found, alarms will not be grouped. Note that, since only alarms with a focus score are taken into account, automatic incident tracking does not apply to information events, suggestion events or notice messages. In addition, if the alarm focus feature is disabled on one or more DMAs in the DataMiner System, only partial results will be available.

The grouping of alarms into incidents is updated in real time whenever appropriate:

- New alarms are added to existing groups if they match.

- A group is cleared if its base alarms are cleared or if the reason for its original creation comes to an end.

- If a group is cleared, any alarms in the group that are still active may be regrouped if other matching alarms exist, either in a new group or in an existing one.

In the Alarm Console, alarm groups are displayed as a special kind of alarm entries:

- The icon of an alarm group is similar to that of a correlated alarm.

- The alarm color of an alarm group entry reflects the highest severity of the alarms within the group, but the severity of the group itself is *Suggestion*.

- The parameter description of the entry is *Alarm Group*.

- The value of the entry is the reason why the alarms are grouped. If there is no single obvious reason, the value will be *Group with multiple reasons*.

- The root time of the group is the root time of the most recent alarm in the group at the time when the group was created.

- If alarms are added to a group or removed from a group, the alarm type will be updated from *New alarm* to *Base alarms changed*.

- You can expand the group to view all alarms within it.

- If all alarm entries within an alarm group are masked, the group is automatically masked as well. However, as soon as one of the entries is unmasked, the group is also unmasked.

> [!NOTE]
> - Using automatic incident tracking with history sets is supported; however, keep in mind that this may trigger the creation and immediate clearing of a large number of alarm groups.
> - When an element is stopped or paused, the alarms associated with that element will not be taken into account when grouping alarms. Also, alarms associated with elements that are stopped or paused will be removed from any existing alarm group.

**Configuration in System Center**

In DataMiner Cube, you can enable this feature in *System Center*, via *System settings \> analytics config \> automatic incident tracking*. The following settings are available there:

| Setting               | Description                                                                                                                                                                                                           |
|-----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Leader DataMiner ID   | The DMA performing all incident tracking calculations.<br> By default, this is the DMA with the lowest DataMiner ID at the time when alarm grouping is enabled.                                                       |
| Enabled               | Allows you to activate or deactivate this feature.<br> Note that when you upgrade to DataMiner 10.0.11, the feature is automatically disabled, unless it had been previously been activated as a soft-launch feature. |
| Maximum time interval | The maximum time interval between alarms that can be grouped as one incident.<br> If the root times of alarms are further apart than the configured interval, the alarms will not be grouped.                         |

#### Alarm hyperlinks: \[DisplayValue\] keywords now allows to display the value of a discreet param­eter \[ID_25294\]

In second-generation alarm hyperlinks, you can now use the \[DISPLAYVALUE\] keyword to display the value of a discreet parameter.

#### Client machines running Cube now require Microsoft .NET Framework v4.6.2 \[ID_25309\]

Client machines running DataMiner Cube now require Microsoft .NET Framework 4.6.2.

#### Profiles app: Support for capability parameters of type “text” \[ID_25345\]

The *Profiles* app now also allows you to create and edit profile parameters of category “Capability” and type “Text”.

#### DataMiner Cube - Alarm templates: Conditional monitoring now support checking whether a parameter value is equal or not equal to “Not Initialized” \[ID_25352\]\[ID_25644\]

In an alarm template, it is now possible to configure monitoring conditions that check whether a parameter value is equal or not equal to “Not Initialized”.

A drop-down box now allows you to choose between “Value” (default) and “Not initialized”. Note that, when you choose “Value” and enter a parameter value, that value will not be cleared when you later select “Not initialized”.

#### Creating an element simulation file \[ID_25353\]

On a DataMiner System, you can create simulated elements. These elements behave as if they are communicating with a physical device, but in fact they are merely displaying data from a simulation file.

From now on, in Cube, you can not only enable a simulation file, but also create one. To do so, in the navigation pane on the left, right-click the element for which you want to create a simulation file, and select *Actions \> Create simulation*.

When you open an element card, you can also access this same command via the card’s hamburger menu.

The simulation file will be stored on the DataMiner Agent, in the protocol folder of the element in question: *C:\\Skyline DataMiner\\Protocols\\NAME\\VERSION\\Simulation_ELEMENTNAME.xml*

#### Resources app: Time-dependent capabilities \[ID_25409\]

When, in the *Resources* app, you assign a capability parameter to a resource, instead of specifying a fixed value for that parameter, you can now indicate that its value will be time-dependent, i.e. that the capability of the resource can change over time.

#### Alarm Console: Special Indexing Engine search tab is now available without enabling the “Sys­tem configuration \> Indexing Engine \> UI Available” user permission \[ID_25429\]

On systems on which the alarms were migrated to an Indexing Engine, up to now the special Indexing Engine search tab would only be available in the Alarm Console of users who had been granted the “System configuration \> Indexing Engine \> UI Available” user permission. From now on, that search tab will be available to all users, regardless of whether they were granted the above-mentioned user permission.

#### Visual Overview: SetVar controls “ListBox” and “FilterComboBox” now use virtualization \[ID_25436\]

The SetVar controls “ListBox” and “FilterComboBox” now both use virtualization. This will allow those controls to load large data sets without major performance loss.

#### Visual Overview: Retrieving a booking ID using the \[Reservation:\] placeholder \[ID_25447\]

Using the following syntax, it is now possible to retrieve the ID of a booking by means of a \[Reservation:\] placeholder.

```txt
[reservation:<bookingID/service>,ID]
```

#### Analytics tables in Elasticsearch database can now be included or excluded in custom Data­Miner backup \[ID_25572\]

When you configure a custom backup in Cube, you can now select whether the Analytics tables in the Elasticsearch database, which are used for pattern matching, should be included. To do so, in System Center, go to the *content* tab of the *Backup* page, select the *Use custom backup* option, select *Create a backup of the database*, and either select or clear the selection of the check box *Include analytics tables in backup*. By default, this option is selected.

#### View cards: New columns added to view card list view \[ID_25715\]

On view cards, the list view now has two additional columns:

- *Element timeout time*: The total timeout time for each of the element’s connections (in milliseconds). This is the timeout time that corresponds with the element setting *The element goes into timeout state when \[...\]*. For multiple connections, the values are separated by commas.

- *Host ID*: The ID of the DMA hosting the element, service, SLA or redundancy group.

#### SNMP Managers: New alarm storm prevention option “Group alarms with the same parameter name” \[ID_25717\]\[ID_25984\]

When you have enabled alarm storm prevention while configuring an SNMP manager, you can now choose to select the “Group alarms with the same parameter name” option.

If this option is selected, alarm storm prevention will happen based on the number of alarms occurring per parameter; otherwise, it will happen based on the number of alarms across parameters.

By default, this option is selected.

#### Services app: New “Profiles” tab page \[ID_26111\]

The Services app now has a new “Profiles” tab page, which will allow you to manage Service Profile Definitions and Service Profile Instances.

#### Services app: Profile can now be referred to by value or by reference when configuring a service definition node \[ID_26118\]

When you configure a node in a service definition, a toggle button now allows you to specify whether the selected profile will be assigned by value or by reference.

#### Service & Resource Management - Visual Overview: Dynamically generating booking shapes \[ID_26154\]

It is now possible to automatically generate booking shapes. To implement this feature, do the following:

1. Create a shape representing the booking items, add a *ChildType* data field to that shape, and set its value to “Booking”.

2. Create a shape group containing the shape you made in step 1, add a *Children* data field to the shape group, and set its value to “Booking”.

By default, all bookings in the Cube cache will be shown. If that cache does not contain any bookings, then a default set of bookings will be retrieved (i.e. from 1 day in the past to 2 days in the future).

- If you want to retrieve all bookings within a specific time range from the server, then add a *ChildrenSource* data field to the shape group and set its value to a specific time range (e.g. “StartTime=\<dateTime>; EndTime=\<dateTime>”).

    > [!NOTE]
    > If you retrieve a specific set of bookings by using a *ChildrenSource* data field set to a specific time range, the retrieved bookings will be added to the ones already present in the cache. If, by specifying a time range, you only want to filter the bookings currently in the cache, then use a *ChildrenFilter* data field instead.

- If you want to filter the bookings, then add a *ChildrenFilter* data field to the shape group and set its value to a booking filter, using the same filter format that is used when specifying a ListView filter.

- If you want to sort the bookings, then add a *ChildrenSort* data field to the shape group and set its value to “Name” (i.e. the default setting), “Property\|Start time” or “Property\|End time”, optionally followed by “,asc” (i.e. the default order) or “,desc”.

> [!NOTE]
> Dynamically generated booking shapes are functionally identical to shapes linked to bookings using a *Reservation* data field. For example, they support the same placeholders.

#### Visual Overview: New parameter control option “ClientSidePollingInterval” \[ID_26223\]

When you have turned a shape into a table control that displays a direct view table, you can now use the *ClientSidePollingInterval* option to specify that this table should be refreshed at regular intervals.

| Shape data field        | Value                                                                                                                                       |
|-------------------------|---------------------------------------------------------------------------------------------------------------------------------------------|
| ParameterControlOptions | ClientSidePollingInterval:\<interval><br> Example: To configure a polling interval of 1 minute, specify ClientSidePollingInterval:00:01:00. |

Minimum interval: 1 second

#### Data Display: Number groups in numeric values will now be separated by a thin space \[ID_26251\]

In Data Display, three-digit number groups in numeric values will now by default be separated by a thin space. This will make large numbers more legible.

> [!NOTE]
> This so-called thousands separator will only be used to display numbers. Numbers that are copied, edited or exported will not contain any number group separators.

#### Services app: New and updated booking state icons \[ID_26270\]

In the *Overview* tab of the *Services* app, the booking state of a service is indicated by an icon in the *Booking state* column.

- A new icon has been added to indicate service permanent bookings that start somewhere in the future:

![](~/release-notes/images/BookingOngoingPermanentFuture.png)



- The icons used to indicate the state of one or more bookings linked to a service will now be displayed in the following order:

    - Permanent ongoing

    - Ongoing

    - Permanent in future

    - Future

    - Past/None

#### DataMiner Cube start window: New method to install a DataMiner Cube desktop application \[ID_26282\]\[ID_26381\]\[ID_26725\]\[ID_26752\]\[ID_26788\]\[ID_26986\]

From now on, you can use the DataMiner Cube start window to install DataMiner Cube as a desktop application.

This offers a number of advantages. It allows you to deploy multiple Cube versions side by side, and it will automatically select the correct Cube version when you connect to a DMA.

1. Browse to your DMA using a different browser than Internet Explorer.

2. Enter your username and password to log in.

3. Select *Desktop installation* and run the downloaded file.

4. In the installation window, open the *Options* section and adjust the options depending on whether you want a shortcut to be added to the desktop and/or start menu and on whether you want DataMiner Cube to start with Microsoft Windows.

5. Click *Install*.

**Host name validation**

When you add a new DataMiner Agent or DataMiner System to the start window, the host name you enter will be validated:

- Is it a valid IP address or host name?

    > [!NOTE]
    > If the host name cannot be validated, you will be able to add it, but a warning message will appear.

- Is it accessible over HTTP and/or HTTPS?

    > [!NOTE]
    > If the DMA is accessible over HTTPS, the configuration will be modified to make sure Cube will always connect to that agent over HTTPS. However, if there are any issues with the HTTPS certificate, those issues will be indicated and HTTP will be used instead.

- Is it a DataMiner Agent?

> [!NOTE]
> - Although it is still possible to install a DataMiner Cube desktop application using an MSI installation package, it is strongly advised to use the new installation method instead.

**Periodic updates of DataMiner Cube**

The first time you open the start window, a task named “Update DataMiner Cube” will be added to Windows Task Scheduler. Every 3 days, that task will open the start window with the /Update argument. The /Update argument combines the /UpdateClients and /UpdateLauncher arguments. See below.

| Argument        | Function                                                                                                                                                                                                                                                                                                                   |
|-----------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| /UpdateClients  | Checks, for all the DataMiner Systems to which you have connected in the last 100 days, whether a new Cube version is available. If so, it will immediately be downloaded.                                                                                                                                                 |
| /UpdateLauncher | Checks for a newer version of DataMiner Cube on https://dataminer.services. If a newer version is found, it will immediately be downloaded and installed.<br> If no newer version can be found on https://dataminer.services, then the 10 DataMiner Systems to which you connected last will be checked for a new version. |

The scheduled task is checked each time you open the start window, and is removed when you uninstall DataMiner Cube. Periodic updates can be suspended by disabling the task in Windows Task Scheduler.

#### SNMP Managers: Polling IP address can now be added as a custom trap binding \[ID_26339\]

When configuring an SNMP manager, you can now add the polling IP address as a custom trap binding.

#### Profiles app: Display value configuration possible for capability profile parameters of type dis­crete \[ID_26379\]

Previously, when you configured a capability profile parameter of type discrete, it was not possible to specify display values for the raw values of the parameter. Now, with the *Discrete type* drop-down box, you can specify whether the display values are text or a number. Depending on this selection, the selection box for the discrete parameter will be either a text box or a spin box. When you specify the possible values for the parameter, there is now also an additional *Display value* column where you can specify the display value corresponding with each raw value. Both a raw value and a display value always need to be specified. The raw values always have to be unique, but this limitation does not apply for the display values.

Capability profile parameters of type discrete that were configured before this change will have no discrete type selected. For these parameters, the display value will remain equal to the raw value, unless they are reconfigured.

#### Export: Selecting multiple items to be exported / New option to export data as displayed in view card \[ID_26450\]

From now on, it is possible to select multiple objects in a list and export them together in one file.

Also, when indicating which data to export, it is now possible to select the *Data as displayed in view card* option.

#### Service & Resource Management - Profiles app: Value of a capability of type “text” can now be changed regardless of the “User time-dependent" option \[ID_26538\]

Up to now, when you configured a profile instance, the value of a capability of type “text” could only be changed when the “Use time-dependent" option was selected. From now on, it will be possible to change the value of a capability of type “text” regardless of the “User time-dependent" option.

#### System Center - SNMP forwarding: Generate MIB file \[ID_26591\]

When an SNMP manager is configured to forward SNMPv2 or SNMPv3 traps with custom bindings, then you can now generate a MIB file containing those custom bindings.

To do so, go to the *Notification* tab of the SNMP manager in question, open the pane listing the custom bindings and click the *Generate MIB file...* button.

> [!NOTE]
> The *Generate MIB file...* button will only be enabled when
> - *Notification OID* is set to “Use custom bindings”,
> - the list of custom bindings contains at least one entry, and
> - all changes to the SNMP manager in question have been saved.

#### Visual Overview: Element-level Visio files \[ID_26648\]\[ID_27376\]

Up to now, when you assigned a Visio file to an element, it was assigned on protocol-level, i.e. to all elements sharing the same protocol. Now, it is also possible to assign a Visio file to one particular element. If you do so, the element-level Visio file will override the element’s protocol-level Visio file.

In the header bar menu of an element card, you will now have two “set as active Visio file” commands:

- Set as active *‘protocol name’* protocol Visio file

- Set as active *‘element name’* element Visio file

If you pick the protocol Visio file option, the following options are available:

| Option           | Function                                                                                                                                                                   |
|------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Custom           | Assigns the available custom protocol drawing to all elements using this protocol.                                                                                         |
| Protocol default | Assigns the protocol default drawing to all elements using this protocol.<br> Protocol default drawings are Visio drawings that are included in certain protocol packages. |
| General default  | Assigns the general default drawing to all elements using this protocol.<br> This is the drawing shipped with the DataMiner software.                                      |

If you pick the element Visio file option, the following options are available:

| Option     | Function                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
|------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| New blank  | Opens a new, blank drawing in Microsoft Visio, which will automatically be assigned to the current element.                                                                                                                                                                                                                                                                                                                                                                                |
| New upload | Opens the *Open* dialog box, which allows you to upload a new drawing to the DMS and automatically assign it to the current element.                                                                                                                                                                                                                                                                                                                        |
| Existing   | Opens the *Custom* dialog box, which allows you to assign a previously uploaded drawing to the current element:<br> -  Click a drawing in the list, set the default page, and click *OK*.<br> -  Click *Other File...* to upload additional drawings to the DMS |

#### Default browser engine is now Chromium \[ID_26662\]

From now on, Cube will use Chromium as the default browser engine. When that engine is not installed, it will fall back to the first installed browser (currently, on most systems, this will be Microsoft Internet Explorer).

Although it will remain possible to configure that a different browser should be used for specific protocols, it will no longer be possible to configure that a different browser should be used for apps like Dashboards or Ticketing. Those apps will now always use the default browser engine.

When, on a Visio page, you configured a shape to display a web page, that web page will now also by default be rendered using the Chromium browser engine. However, if you want to explicitly specify the browser engine to be used, then add a shape data field of type *Options* to the shape and set its value to either “UseChrome” or “UseIE”.

> [!NOTE]
> Cube also use the default browser engine when displaying annotations.

#### Visual Overview / Service & Resource Management: Reservation placeholder now supports Sta­tus field \[ID_26859\]

Using the syntax “\[Reservation:\<id>,\<fieldName>\]”, it is possible to resolve a booking field based on the ID and the name of that field.

The Status field has now been added to the list of possible fields. This field indicates the current status of the booking (e.g. “Ended”, “Pending”, “Ongoing”, etc.).

#### Alarm Console: “Show in banner” option can now also be set in the Settings window \[ID_26993\]

The *Show in banner* option, which up to now could only be set in the hamburger menu of the Alarm Console, can now also be set in *Alarm Console* section of the *Settings* window, both as a user setting and a group setting.

> [!NOTE]
> This option can only be set for one alarm tab page. When you activate the option for a particular tab page, it will automatically be deactivated for all other tab pages.

#### Visual Overview: New AllowInheritance option to keep child shape from automatically inheriting parent shape data \[ID_27084\]

It is now possible to configure a child shape of a *View* or *Element* shape to not automatically inherit the *View* or *Element* shape data of the parent shape. To do so, add the option *AllowInheritance=False*. Note that this renders the existing option *NoCopyElementProperty* obsolete, since this did the same thing for *Element* shapes only.

#### DataMiner Cube desktop app: Update release tracks \[ID_27086\]\[ID_27121\]

To allow a phased rollout of new versions of the DataMiner Cube desktop app, multiple release tracks have now been introduced: a release track with the latest version, and 3 phased release tracks.

To update to the release track with the latest version, you can use the *Check for updates* option, which is now available via the cogwheel button in the DataMiner Cube start window.

Updates to the phased release tracks happen automatically through periodic updates. The update track used for these updates is randomly selected and saved in the configuration of the app.

New versions are first made available in the release track with the latest version and in one of the phased release tracks. If no issues are detected, the other phased release tracks are also updated one by one.

The updates are retrieved from dataminer.services or from the most recently connected DataMiner Systems if dataminer.services cannot be reached.

#### Profiles app: Converters \[ID_27264\]

In the *Profiles* app, it is now possible to configure a converter (i.e. a mediation snippet) for a parameter linked to a profile parameter.

To configure a converter, do the following:

1. Open the *Profiles* app and go to the *Parameters* tab.

2. Open a parameter (or create a new one).

3. In the *Linked with* table at the bottom, add, edit or duplicate an entry.

4. In the *Edit link with protocol* box, activate the *Converter* setting, enter the converter code in the code window, and click *OK*.

    In the *Linked with* table, the *Converter* column will now show either the class name of the converter or, if no class name could be found, the first line of the converter code.

5. Click *Save* to apply the changes you made.

> [!NOTE]
> When you edit a linked parameter with a converter, the *Converter* setting will automatically be activated.

#### Trending: Full-term trend prediction \[ID_27281\]\[ID_27320\]

On a system with a Cassandra database, trend graphs can show how the value of a parameter in the graph is most likely to evolve in the future. Up to now, three types of trend prediction could be displayed: short-term, mid-term and long-term prediction. From now on, you can also choose to display full-term prediction, which is based on either daily data points or a server-side aggregated set of one-hour data points.

#### DataMiner Cube will now display more detailed information when you try to connect to a Data­Miner Agent that is starting up \[ID_27308\]\[ID_27770\]

When you try to connect to a DataMiner Agent that is starting up or that is being restarted, DataMiner Cube will now display more detailed information regarding the startup process.

Examples of messages that will be displayed:

- Offloaded files are currently being restored to Cassandra

- Starting element X

#### Elements, services and redundancy groups hosted by a disconnected DMA will now be indicated as being disconnected \[ID_27313\]\[ID_27611\]\[ID_27613\]\[ID_27760\]

Up to now, when a DataMiner Agent disconnected from the DataMiner System, the elements, services and redundancy groups hosted by it would disappear from the Cube’s Surveyor. From now on, they will remain visible (read-only), and will be indicated as being disconnected by means of a special icon.

> [!NOTE]
> - The cache is not persistent.
>     - When the disconnected DMA restarts, its elements, services and redundancy groups will no longer be available to the other DMAs in the DMS.
>     - When another DMA joins the DMS, the elements, services and redundancy groups of the disconnected DMA will not be available to the new DMA.
> - Any messages sent to the disconnected DMA (e.g. to retrieve or update information) will result in an exception being thrown.

#### Trending: Renaming of trend prediction types \[ID_27435\]

On a system with a Cassandra database, trend graphs can show how the value of a parameter in the graph is most likely to evolve in the future. Four types of trend prediction can be displayed. Those types have now been renamed.

| Old name   | New name       |
|------------|----------------|
| Short-term | High precision |
| Mid-term   | Short-term     |
| Long-term  | Mid-term       |
| Full-term  | Long-term      |

Also, the behavior of the “auto” setting has been enhanced.

#### DataMiner Cube is now able to detect table columns containing MAC addresses \[ID_27503\]

DataMiner Cube is now able to detect table columns containing MAC addresses and to sort them appropriately.

#### Trending: Exclude gaps option in export window \[ID_27506\]\[ID_28067\]

When you export a trend graph to CSV, a new *Exclude gaps* option is now available. If you select this option, the export will skip any gaps in the trend data.

#### Correlation/Automation/Scheduler: Email report configuration \[ID_27521\]\[ID_27812\]\[ID_27878\] \[ID_28032\] \[ID_28038\]\[ID_28081\]

In an *Email* action of a Correlation rule, an Automation script or a scheduled task, as well as in the *Upload report to FTP* and *Upload report to shared folder* actions in an Automation script, if you add a report based on a dashboard, you can now click a *Configure* button to open an embedded browser window where you can configure the necessary data feed selections as well as the following options:

- *Add DMS info*: Determines whether company details are displayed in the report.

- *Add DMS logo*: Determines whether the company logo is displayed in the report.

- *Include feeds*: Determines whether feed components are included in the report. By default, this option is not enabled.

- *Stack components*: Select this option if you want all components to be displayed below one another. This can be especially useful for dashboards containing large components (e.g. pivot tables) in order to make sure all data is displayed.

- *Dashboard width*: Allows you to select a custom width for the report.

#### Trending: Percentile line \[ID_27533\]

It is now possible to visualize a percentile line on a trend graph in DataMiner Cube. To do so, right-click the graph and select *Show percentile*. By default, the 95th percentile for the data in the current range will then be calculated and visualized with a line on the graph. To the right of the line, you will see the percentile that was calculated and the value of the percentile.

If the range of the graph is adapted, the percentile is not automatically updated, so that you can compare the percentile for a certain range with the data for a larger or smaller time frame. The percentile line will be displayed as a full line over the range for which it was originally displayed, and as a dashed line over the rest of the graph.

When you click the percentile line, a refresh option is displayed that allows you to refresh the percentile to the currently displayed data. Clicking the line also displays the option to adjust the percentile, so that you can e.g. display the 90th percentile instead.

Finally, in the *Trending* tab of the Cube user settings, a new *Show percentile* setting is now available, which can be used to have the percentile line displayed by default whenever a trend graph is opened. If this option is selected, you can also select which percentile should be calculated by default.

#### Visual Overview: Conditional shape manipulation actions no longer require the shape to be linked to an element, service or view \[ID_27569\]

Up to now, the following conditional shape manipulation actions could only be configured on shapes linked to an element, service or view. From now on, these actions will no longer require the shape to be linked to an element, service or view.

- Show

- Hide

- FlipX

- FlipY

- Enabled

> [!NOTE]
> In case of “Enabled”, the shape in question needs to be clickable.

#### Visual Overview: New icons added to DataMiner stencils \[ID_27571\]

**New icons**

The following additional icons are now available in the DataMiner stencils:

- General input

- General output

- OT

- OR

- Multiplexer

- Demultiplexer

- Modulator

- Demodulator

- North-south deployment

- Augmented

- East-west LSO

- Virtual machine

- MPLS

- Bespoke

- DNS

- Platform services

- OS

- AWS Direct Connect

- Kubernetes

- Elastic

- Paas

- Iaas

- Saas

- Infrastructure

- Applications.2

- Single source of truth

- Consistency

- Dynamics

- File management

- Synchronized

- Easy access

- End-to-End View

- User-definable

- Intuitive UI

- Full support

- Single sign-on

- Advanced access control

- Simplify Processes

- Sophisticated services

- Level up your service quality

- Graphical user interface

- Access information

- Plug ’n play creation

- Inspect

- OTT

- Encoder

- Close Caption Encoder

**Renamed icons**

In the DataMiner stencils, the following existing icons have been renamed:

| Old name            | New name          |
|---------------------|-------------------|
| no Acces            | No Access.2       |
| dmcube_cubemobile   | DM Cube Mobile    |
| IP alt              | IP.2              |
| Rotate 2            | Rotate            |
| Rotate alt          | Rotate.2          |
| service manager.262 | Service Manager.2 |
| SLA alt             | SLA.2             |
| th                  | Apps              |
| Virtual-Machine     | Virtual Machine   |

**Capital Case**

All icon names are now in capital case.

#### Alarm Console: FilterElement property of an alarm hyperlink can now include a filter that checks the existence of a dictionary key \[ID_27675\]

A new exposer will now allow filters to check whether a certain key exists in a dictionary.

```txt
// Filter to check if a key exists
var keyFilter = AlarmEventMessageExposers.PropertiesDict.KeyExists("KeyName").Equal(true);
// Filter to check if a key does not exist
var keyFilter = AlarmEventMessageExposers.PropertiesDict.KeyExists("KeyName").Equal(false);
```

In Alarm Console hyperlinks, these filters can be used in the FilterElement property. See the following example.

```xml
<HyperLink id="1"
           version="2"
           name="Issue_ID blank"
           type="script"
           alarmColumn="true"
           menu="root/JIRA"
           combineParameters="true"
           filterElement=             "(AlarmEventMessage.PropertiesDict.KeyExists:Issue_ID[Bool] == False) OR             (AlarmEventMessage.PropertiesDict.Issue_ID[String]=='')">
  Script:dummy script||||Tooltips|NoConfirmation,CloseWhenFinished
</HyperLink>
```

> [!NOTE]
> - This type of filters will be applied after the data has been retrieved from the database.
> - It is not recommended to use these filters when retrieving data from Cassandra or ElasticSearch.

#### Name of the DataMiner System can now be displayed in Cube’s header bar \[ID_27714\]

In DataMiner Cube, the name of the DataMiner System can now be displayed in the header bar.

- Open the header bar’s quick menu, and activate or deactivate the *Show cluster name* setting.

    or

- Open the *Settings* window, go to *Computer \> Cube*, and select or clear the *Display cluster name in header* setting.

#### Visual Overview: Linking the view range of a trend graph component to session variables & specifying a custom view range \[ID_27779\]

A Visio shape showing a trend graph component can now be made to update session variables with its view range (i.e. start time and end time). To do so, add a shape data field of type SetVar, and set its value to “RangeStart:\<VariableA>\|RangeEnd:\<VariableB>”

Example:

| Shape data field | Value                                        |
|------------------|----------------------------------------------|
| SetVar           | RangeStart:MyRangeVar1\|RangeEnd:MyRangeVar1 |

> [!NOTE]
> The values set in the session variables will be datetime text strings formatted according to the current culture.

Also, to have a trend graph component show a custom range, you can now add “Range:Start=\<dateTimeTextA>,End=\<dateTimeTextB>” to a shape data field of type ParametersOptions.

Example:

| Shape data field  | Value                                             |
|-------------------|---------------------------------------------------|
| ParametersOptions | Range:Start=\<dateTimeTextA>,End=\<dateTimeTextB> |

> [!NOTE]
> - You do not have to specify two time values. You can specify a start time, an end time or both (separated by a comma).
> - The datetime text strings need to be formatted according to the current or invariant culture.

#### DataMiner Cube desktop app: Silent installation, modification and uninstallation of Cube \[ID_27795\]

Using the following command-line arguments, it is now possible to silently install, modify and uninstall the DataMiner Cube desktop app without any user interface.

**General syntax**

```txt
PathToCubeExe.exe <arguments>
```

> [!NOTE]
> All arguments and options are case insensitive.

**Arguments to install DataMiner Cube**

| Argument         | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
|------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| /Install         | Check whether DataMiner is installed, and if not, open the installation wizard.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| /Install /Silent | Check whether DataMiner is installed, and if not, install DataMiner Cube and exit when done.<br> If no options are specified using an /InstallOptions argument, the default installation options will be used.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| /InstallOptions  | Comma-separated list of additional installation options:<br> -  DesktopShortcut (add a desktop shortcut)<br> -  NoDesktopShortcut (do not add a desktop shortcut)<br> -  StartMenuShortcut (add a start menu shortcut)<br> -  NoStartMenuShortcut (do not add a start menu shortcut)<br> -  StartOnLogin (start Cube in the system tray after login)<br> -  NoStartOnLogin (do not start Cube in the system tray after login)<br> -  OpenAfterInstall (open the start window after installation)<br> -  NoOpenAfterInstall\* (do not open the start window after installa-tion)<br> \* Default option for silent installs |

Example of a silent command to install DataMiner Cube when no installation could be found:

```txt
PathToCubeExe.exe /Install /Silent /InstallOptions:StartOnLogin
```

**Arguments to modify DataMiner Cube after installation**

| Argument        | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
|-----------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| /Modify         | Open the “Modify installation” window.<br> If there is a /ModifyOptions argument, the options specified in that argument will be preselected.                                                                                                                                                                                                                                                                                                                                                     |
| /Modify /Silent | Silently modify the DataMiner Cube installation using the options specified in the /ModifyOptions argument.                                                                                                                                                                                                                                                                                                                                                                                       |
| /ModifyOptions  | Comma-separated list of modification options:<br> -  ClearProtocolCache<br> -  ClearVisioCache<br> -  ClearVersionCache (remove all cached versions)<br> -  RemoveVersion:versionnumber (remove the specified version from the cache) |

Example of a silent command that will clear the protocol cache, clear the Visio cache and remove two versions from the cache:

```txt
PathToCubeExe.exe /Modify /Silent /ModifyOptions:ClearProtocolCache,ClearVisioCache,RemoveVersion:9.5.1638.4080,RemoveVersion:10.0.2042.1636
```

**Arguments to uninstall DataMiner Cube**

| Argument          | Description                        |
|-------------------|------------------------------------|
| /Uninstall        | Open the uninstall window.         |
| /Uninstall/Silent | Silently uninstall DataMiner Cube. |

#### Protocols & Templates: Information template editor now also allows you to configure parame­ters of type Button and ToggleButton \[ID_27823\]

As to button parameters, up to now, the information template editor only allowed you to configure parameters of type PageButton. From now, it will also be possible to configure parameters of type Button and ToggleButton.

#### DataMiner Cube: Buttons to join and leave cluster renamed \[ID_27863\]

On the *Agents* > *Manage* page in System Center, the *Add cluster* and *Delete cluster* buttons have been renamed to *Join cluster* and *Leave cluster*, respectively.

#### New EPM card settings \[ID_27874\]

In the DataMiner Cube user settings, you can now configure the following EPM card settings:

- Default EPM card page

- How to show EPM card Visual pages

#### Visual Overview: Info keywords can now be used as dynamic placeholders in other shape data fields \[ID_27880\]

All keywords that can be specified in shape data fields of type “Info” can now also be used as dynamic placeholders in shape data fields of other types.

When using one of those keywords in a shape data field of type other that “Info”, make sure to enclose it in square brackets similar to other placeholders.

Example: \[var:\[NAME\]\]

#### Visual Overview: Automation script session variables & OnClosing shape data field \[ID_27895\]

In Visual Overview, it is now possible to pass Automation script output to session variables. Also, you can now use the page-level shape data field OnClosing to configure whether a Visual Overview window should automatically be closed or not.

**Passing Automation script output to session variables**

When an Automation script executed in Visual Overview finishes successfully, it is now possible to pass the output values of that script to session variables in Visual Overview using the new CreateKey(string variablename) method (namespace: Skyline.DataMiner.Automation, class name: UIVariables.VisualOverview).

In the following example, a session variable named “MyOutput” will be created and will receive the value “MyValue”.

```txt
engine.AddScriptOutput(UIVariables.VisualOverview.CreateKey("MyOutput"), "MyValue");
```

- If you execute the same Automation script on different pages, then you can use the SessionVariablePrefix option to make sure the output is saved in separate session variables.

    If, for example, you use prefix “One\_” on one page and prefix “Two\_” on another page, and the Automation scripts pass their output to a session variable named “MyPage”, then the output will end up in two separate session variables named “One_MyPage” and “Two_MyPage” respectively.

- When you set the SetVarOnFail option to true (either on page level or shape level), then the session variables in question will always be created, regardless of whether the script finishes successfully or not.

**New “OnClosing” shape data field**

From now on, you can use the page-level shape data field OnClosing to configure whether a Visual Overview window should automatically be closed or not.

In a shape data field of type OnClosing, specify a script (example: Script:MyScript), and make sure the script contains an instruction like the following one:

```txt
engine.AddScriptOutput(UIVariables.VisualOverview.ClosingWindow_Result, ClosingMode.Continue.ToString());
```

The session variable named ClosingWindow_Result can be set to “Continue”, “Stop” or “Abort”. In the example above, it is set to “Continue”.

If ClosingWindow_Result is set to “Stop”, a message box of type “Yes/No” will appear. If the user then clicks “Yes”, the window will be closed.

Note that, in the session variable named ClosingWindow_Message, you can specify a custom message to be displayed. If you specify such a message, then it will be shown in a message box of type “OK”, regardless of the value of the ClosingWindow_Result variable. However, if ClosingWindow_Result is set to “Stop”, then this custom message will be displayed in the message box of type “Yes/No” mentioned above.

> [!NOTE]
> - The OnClosing shape data field only works for windows. It does not work for popups or tooltips.
> - The OnClosing and OnClose shape data fields do not influence each other. Both function independently from each other.
> - If you want to combine OnClosing and OnClose, then in Visual Overview, you can pass session variable X to the OnClosing script and make it return session variable Y. That variable can then be passed to the OnClose script, which can optionally be made to return session variable Z.

#### Visual Overview: New AutoIgnoreExternalChanges option when embedding a Service Manager component \[ID_27899\]

Up to now, when embedding a Service Manager component in Visual Overview, you could specify the AutoLoadExternalChanges option if you wanted external changes to be loaded automatically when there were no local changes. From now on, you can also specify the AutoIgnoreExternalChanges option if you want external changes to be discarded automatically.

Both options will keep the information bar from being displayed at the bottom of the Visual Overview, asking the user to load or discard the external changes.

> [!NOTE]
> If you specify both options, then AutoLoadExternalChanges will take precedence over AutoIgnoreExternalChanges:
> - As long as there are no (unsaved) client-side changes, external changes will be loaded automatically.
> - As soon as there are (unsaved) client-side changes, external changes will be discarded.

#### Trending - Pattern matching: New options when adding or editing a tag \[ID_27954\]

When adding or editing a tag, you can now select the following additional options:

| Option                       | Description                                                                                                  |
|------------------------------|--------------------------------------------------------------------------------------------------------------|
| '\<instanceName>' only       | Select this option if you want the tag to only match one specific display key and parameter.                 |
| Generate alarm when detected | Select this option if you want suggestion events to be generated when a match is detected in the trend data. |

> [!NOTE]
> When you save a tag after selecting the *Generate alarm when detected* option, a message box may appear, saying that suggestion events cannot be generated for that tag. This is due to the range of the tag being too large. The tag itself will be saved and detected.

#### Trending: Trend percentile will now be calculated using either average or real-time trend data \[ID_27965\]

Up to now, the trend percentile was calculated using the most detailed data set that was available. In cases where the trend window contained both real-time and average trend data, it would be calculated using both types of data.

From now on, from the moment the trend window contains average data points in its most detailed set, only average data will be used for the calculation. This is also be reflected in the percentile menu, where a warning icon will be shown. A tool tip on the warning icon will indicate when only average data will be used.

#### DataMiner Cube start window: Aliases \[ID_27975\]\[ID_27999\]\[ID_28161\]

When defining a DataMiner Agent in the start window, apart from the host name or IP address, you can now also specify an alias.

By default, the alias will be identical to the cluster name. If you specify a custom alias, it will replace the cluster name in the Cube header and the Windows task bar.

Command-line arguments: /Alias=Xyz /Host=hostname

> [!NOTE]
> Always use the /Alias argument in conjunction with the /Host argument.
>
> The alias will be used as long as the client is connected to the host specified in the Host argument.

#### System Center: Enhanced Database section \[ID_27976\]\[ID_28196\]

The *Database* section of *System Center* now has three main tab pages.

- In the *General* tab page, you can select “Database per agent” or “Database per cluster”.

    - When you select “Database per agent”, you can configure the local databases per agent.

    - When you select “Database per cluster”, you can configure a Cassandra cluster acting as a shared local database.

- In the *Offload* tab page, you can configure the data offloads to a central database.

- In the *Other* tab page, you can configure an additional database.

> [!NOTE]
> Throughout DataMiner Cube, the term “central database” has now been replaced by “offload database”.

#### Trending: Real-time pattern matching \[ID_28054\]

Up to now, pattern matching happened on the fly when a trend graph was opened. Now, apart from this so-called static pattern matching, DataMiner is also able to perform real-time pattern matching and generate an alarm as soon as a pattern is detected.

When you create a pattern in DataMiner Cube, you can now select the following new options:

- When you select the *Generate an alarm when detected* option, DataMiner will track the pattern in real time and trigger a suggestion event each time it detects the pattern.

    When you do not select this option, DataMiner will behave as before and use static pattern matching instead.

- When specifying the parameter, in case of a table parameter, you can now also add the display key.

    > [!NOTE]
    > This option is not linked to the type of pattern matching that is being used (static or real-time).

**Limitations**

- If you tag a pattern for a parameter of which the polling time is specified in the protocol, then the pattern must have less than 5000 real-time points. If the polling time is not specified in the protocol, then the pattern must be shorter than 24 hours. When you select a longer pattern, DataMiner Cube will display a warning and revert to static pattern matching for that specific pattern.

- For real-time pattern matching, DataMiner will only use a maximum of 2 GB of internal memory.

    - As soon as DataMiner uses more than 1.5 GB of internal memory for real-time pattern matching, the following notice will appear in the Alarm Console:

        *Pattern matching memory high, adding more patterns or parameters might reduce matching accuracy.*

        This notice will appear at most every 2 weeks or after a DataMiner restart.
        In order to reduce memory usage, users can either remove patterns that are being tracked in real time or restrict the number of parameters for which patterns are being tracked in real time (e.g. by specifying a display key in case of table parameters).

    - As soon as DataMiner uses more than 2 GB of internal memory for real-time pattern matching, the following notice will appear in the Alarm Console:

        *Pattern matching memory critical, patterns with suggestion events enabled may not match properly.*

        This notice will appear at most every 2 weeks or after a DataMiner restart.
        Also, when users create a pattern, DataMiner will now always revert to static pattern matching, even if they selected the *Generate an alarm when detected* option.

    - DataMiner checks all changes made to parameters for which patterns are being tracked in real time. If there are more than 6000 parameter changes per second, the following notice will appear in the Alarm Console:

        *High load on pattern matching functionality: reduced pattern match accuracy.*

**Suggestion events**

In case of real-time pattern matching, pattern occurrences are communicated to the user by means of suggestion events in the Alarm Console, i.e. alarms with severity “Information” and source “Suggestion Engine”. These events can be displayed in a separate *Suggestion events* alarm tab.

#### Visual Overview: KPI stencil and Button stencil have been restyled \[ID_28691\]

The KPI stencil and the Button stencil have been restyled.

**KPI stencil**

- Apart from being restyled, the following shapes have also been renamed:

    | Old name           | New name           |
    |----------------------|--------------------|
    | kpi-noIcon-v         | kpi-noIconV        |
    | kpi-noIcon-h         | kpi-noIconH        |
    | param-normal         | list-normal        |
    | param-normal-compact | list-compact       |
    | param-combi-compact  | list-combi-compact |
    | param-multi          | list-multi         |
    | param-combi          | list-combi-compact |

- A KPI and its associated icon can now be displayed in two different ways:

    | Shape   | Description                                                    |
    |-----------|----------------------------------------------------------------|
    | kpi-icon  | Focus on the parameter alarm state, with an icon on top of it. |
    | kpi-icon2 | Fixed background (dark blue), with an icon on top of it.       |

    > [!NOTE]
    > Make sure to replace the icon by one that suits the requirements.
    >
    > All available icons can be found in the Icons stencil.

- The master shapes of which the name starts with “kpi-” can now show the element icon with the alarm state (\_showElement) and an icon that can be clicked to navigate to the alarm overview of the linked element (\_showAlarm).

- The write icon in the top-right corner of a shape has been changed from a black triangle to a cogwheel.

**Button stencil**

- The style of the toggle buttons now matches the style of the toggle button in DataMiner Cube.

- All other buttons have had their rounding style adapted in order to match that of the buttons found on the Data pages of element cards.

    > [!NOTE]
    > It is advised to add an ellipsis (...) to the text on a button if user interaction is required after clicking the button in question.

> [!NOTE]
> The toggle buttons now use the theme accent color. This means that you will need an additional Options shape data field on page level with, for example, the following value:
> *#000000=ThemeForeground\|#FF0000=ThemeAccentColor\|<br>#FFFFFF=ThemeBackground*

#### Visual Overview: New icon added to Icons stencils \[ID_28696\]

The following icon has been added to the Icons stencil:

- Alarms

### DMS Reports & Dashboards

#### Dashboards app: Quick-pick buttons added to time range feed \[ID_23133\]

The time range feed can now be configured to show a list of quick-pick buttons that will allow users to enter a preset time range by clicking a single button.

To configure the list of quick-pick buttons to be shown when users click a time range feed, go to edit mode, select the time range feed, open the *Layout* tab, select *Use quick picks*, and select the buttons to be shown.

#### Dashboards app: Enhanced theme configuration \[ID_23258\]

In the dashboard settings page, which is now named “*Dashboards settings*”, the dashboard theme configuration has been enhanced. On this page, you can create, copy and delete themes. When editing a theme, you can now also mark it as the default theme.

Also, there are now two system themes: “Light” and “Dark”. These are fixed themes that cannot be edited or deleted.

Per dashboard, a theme can be selected in the *Layout* tab, which has now also been restyled. From now on, this tab will only allow you to change the layout of a dashboard after selecting the *Override* option.

> [!NOTE]
> When you save a customized dashboard layout as a new theme, you will be asked to confirm this save operation as this will undo all changes you made to the layout of the dashboard you are editing.

#### Dashboards app: Line chart component can now visualize resource capacity \[ID_23901\]

When you add a line chart component to a dashboard and drag resources onto it, it will display the resource capacity parameters as a stacked trend chart.

If you then click the chart and select a point in time, the legend will list all bookings for that specific point in time. To clear the list, right-click the chart or close the legend.

The resource capacity parameters displayed in the chart can be grouped by parameter or by resource.

#### Dashboards app: Generic Query Interface \[ID_24048\]\[ID_24548\]\[ID_25898\]\[ID_25921\]\[ID_26050\] \[ID_26153\]\[ID_26448\]\[ID_26477\]\[ID_26793\]\[ID_27616\]\[ID_27678\]\[ID_27949\]\[ID_27987\]\[ID_28010\] \[ID_28071\]\[ID_28158\]\[ID_28761\]\[ID_28791\]\[ID_28831\]

The Generic Query Interface allows you to efficiently tap into the wealth of data available in your DataMiner System. In this release, the interface is available via the *Queries* data input for Bar chart and State visualizations, as well as in the new Table and Pie Chart visualizations, which were especially created for this feature. In future releases, additional functionality using the Generic Query Interface will become available. Note that this feature is only available if DataMiner uses a Cassandra database. For some queries, an Elasticsearch database is also required.

##### Using the Queries data input

You can construct a query to use as data input for a component by following these steps:

1. In edit mode, select the dashboard component for which you want to use a query as a data input. At present, this is support for Bar chart, State and Table components.

2. In the data pane, select *Queries* and click the + icon to add a new query.

3. Specify a name for the query.

4. In the drop-down box below this, select the data source you want to use. At present, the following options are available:

    - *Get elements*: The elements in the DataMiner System.

    - *Get parameter table by alias*: The parameter table using the specified alias in the Elasticsearch database.

    - *Get parameter table by ID*: The selected parameter table from the element with the specified DataMiner ID and element ID.

    - *Get parameters for elements where*: The selected parameters for the specified protocol or the parameters linked to the specified profile definition. Note that if parameters are displayed based on a specific protocol, it is not possible to combine a table parameter with other parameters, and only column parameters from the same table can be displayed in the same query.

    - *Get services*: The services in the DataMiner System.

5. Select an operator. This step is optional; if you do not select an operator, the entire data set will be used. The following operators are available:

    - *Aggregate*: Allows you to aggregate data from the data source. After you have selected this option, first select the aggregation column, and the method that should be used. Depending on the type of data available in the selected column, different methods are available, e.g. Average, Count, Distinct Count, Maximum, Median, Minimum, Percentile 90/95/98 or Standard deviation.

        You can then further filter the result by applying another operator. An additional *Group by* operator is available for this, which will display the result of the aggregation operation for each different item in the column selected in the *Group by column* box.

    - *Column manipulations*: Creates a new column based on existing columns. When you select this option, you also need to select a manipulation method.

        If you choose the *Concatenate* method, you will need to select several columns and then specify the format that should be used to concatenate the content of those columns, using placeholders in the format {0}, {1}, etc. to refer to those columns.

        If you choose the *Regexmatch* method, you will need to select a column and specify a regular expression, so that the new column will only contain the items from the selected column that match the regular expression.

        For both manipulation methods, you will also need to specify the name for the new column. When the column manipulation operation is fully configured, you can further fine-tune the result by applying another operator.

    - *Filter*: Filters the data set. When you select this option, select the column to filter, specify the filter method (e.g. equals, greater than, etc.) and the value to use as a filter. The available filter methods depend on the type of data in the selected column. Once the filter has been fully configured, you can refine the results by applying another operator, e.g. an additional filter.

    - *Join*: Joins two tables together. When you select this option, in the *Type* drop-down box, you will first need to select how the tables should be joined. Then you will need to select another data source (optionally refined with one or more operators) in order to specify the table you want the first table to be joined with. Optionally, you can also specify a condition to determine when rows should be joined. For instance, if one table contains elements with a custom property that details a booking ID and the other lists bookings, you could add the condition that the property in the first table must match the ID in the second table.

        The *Inner* type of join only includes rows if they match the condition. *Left* displays all rows from the first table (i.e. the table on the left) and only the matching rows from the other table. *Right* does the opposite. *Outer* displays first the non-matching rows from the left table, then the matching rows from both tables, then the non-matching rows from the right table.

    - *Select*: Displays the selected columns only. When you have selected the columns to display, you can apply another operator to refine the query.

    - *Top X*: Displays the top or bottom items of a specific column, with X being the number of items to display. When you select this option, you will need to specify the column from which items should be displayed and the number of items that should be displayed. By default, the top items are displayed. To display the bottom items instead, select the *Ascending* check box.

6. Drag the configured query to the component in order to use it.

> [!NOTE]
> - It is possible to refer to a query in the dashboard URL, using the following format: *?queries=\[***alias***\]\\x1F\[***queryJsonString***\] <br>*In this format, \[alias\] is the name of the query and \[queryJsonString\] is the query in the format of a JSON string, for example: <br>*?queries=Get Elements/{"ID": "Elements"}*.
> - When a query has been created, the columns from the table that results from the query are available as individual data items in the data pane, so that you can use them to filter or group a component.
> - It is not possible to retrieve data from a stopped element.
> - When retrieving profile parameter values, configured converters (i.e. mediation snippets) will be taken into account.
> - A GQI query is not saved in a separate file but in the dashboard itself.
> - A GQI query based on the *Get parameter table by ID* or *Get parameters for elements where* data sources will, by default, inherit the dashboard’s *Use dynamic units* setting. If necessary, you can override this automatic inheritance by selecting the component’s *Override dynamic units* setting.
>
>    When a GQI query does not use dynamic units, by default, parameter values will be displayed using a thin space as thousand separator.

##### Table visualization

This new visualization was especially designed to be able to display the results of queries in a table format. It only supports query data input. It displays the different data sources as follows:

- Elements are represented with a row for each element, with each column detailing different information for that element.

- Services are displayed in the same way as elements.

- Table parameters are displayed as they are, as determined by the applied operators.

- If parameters are retrieved by protocol or profile definition, each row will represent a matching element, and for each parameter a column will show the corresponding values.

You can resize the columns of the table by dragging the column edges. Clicking on a column header will sort the table by that column. To toggle between ascending and descending order, click the column header again. To sort by multiple columns, keep the Ctrl key pressed while clicking the column headers. The first column will then be used for the initial sorting, the next one to sort equal values of the first column, and so on.

In the *Layout* tab for this component, the *Column filters* option is available, which allows you to highlight cells based on a condition. To do so, select the parameter you want to use for highlighting, indicate a range to be highlighted, select the range and then click the color icon on the right to specify a highlight color. Multiple ranges can be indicated for one parameter, each with a color of its own.

##### Pie Chart visualization

This new visualization was designed to display the results of queries in a chart shaped like a pie or donut. It only supports query data input.

The following layout options are available for this visualization:

- *Chart shape*: Can be set to *Pie* or *Donut*.

- *Legend*: The legend can be hidden. If it is set to be displayed, you can select whether it should be displayed on the left, on the right, at the top or at the bottom of the visualization.

- *Tooltips*: Tooltips can be hidden. If they are set to be displayed, you can select whether these should include the label, dimension, value and/or percentage.

In addition, the following settings are available for this visualization:

- *Label*: Allows you to select which data should be used as a label.

- *Segment size*: Allows you to select which data should determine the size of segments in the chart.

##### Bar chart visualization changes

A number of changes have been implement to the bar chart visualization, in order to optimize this visualization to display queries.

If the visualization displays a query, in the *Settings* tab, the following options are available instead of the usual options for a bar chart:

- *Label*: Allows you to select which data should be used as a label.

- *Bars*: Allows you to select which data should determine the size of bars.

In addition, the following layout options can now be configured for this visualization:

- *Chart layout*: Can be set to *Relative* or *Absolute*. *Relative* means that the dimension of each bar is shown as a relative percentage. *Absolute* means that the dimension of each bar is shown as an absolute numeric value.

- *Chart orientation*: Determines how the chart is displayed, i.e. from left to right, from right to left, from top to bottom or from bottom to top.

- *Legend*: The legend can be hidden. If it is set to be displayed, you can select whether it should be displayed on the left, on the right, at the top or at the bottom of the visualization.

- *Tooltips*: Tooltips can be hidden. If they are set to be displayed, you can select whether these should include the label, dimension and/or value.

#### Dashboards app: New “Clear all” action + settings to pin actions \[ID_24356\]

In the dashboard settings, you can now "pin" actions to the header bar. When they are pinned, actions will be displayed as full buttons in the dashboard header bar, e.g. the *Start editing* button. When they are not pinned, the actions can be accessed via an arrow button in the top-right corner of the dashboard.

If a dashboard contains at least one feed, a new *Clear all* action is now available in the dashboard header, which can be used to clear the selection of the feeds in the dashboard.

It is possible to view this new action even when the dashboard is embedded, if "subheader=true" is added to the URL. However, not that this is only the case for the *Clear all* action.<br>For example: *http://**\[DMA IP\]**/dashboard/#/MyDashboards/dashboard.dmadb?embed=true&subheader=true*

#### Dashboards app: Parameter feed now has a “Selected only” toggle button \[ID_24446\]

The parameter feed allows you to select multiple parameters from a predefined list. At the top of the list, a box allows you to select or deselect all items in the list at once and, from now on, a “Selected only” toggle button will also allow you to show or hide items that are not selected.

#### Dashboards app: New Auto-expand parameters setting for parameter feed \[ID_24682\]

A new setting, *Auto-expand parameters*, is now available for the parameter feed component. If this setting is selected, all tables and groups in the component will by default be expanded.

#### Legacy Reporter app will now also use the CSV separator specified in Cube’s CSV separator set­ting \[ID_24855\]

Similar to the new Dashboards app, the legacy Reporter app will now also use the CSV separator specified in Cube’s “CSV separator” setting when generating CSV reports.

If this setting cannot be retrieved, the system will fall back to the Windows regional settings on the DataMiner Agent.

#### Dashboards app: Service definition visualization and SRM data feeds \[ID_24433\]\[ID_24480\] \[ID_25056\]\[ID_25151\]\[ID_25169\]\[ID_25178\]

A new *Service definition* visualization is now available in the *Other* category in the Dashboards app. This visualization can be used to display a service definition as a node edge graph.

To support this new visualization, two new data sets are available:

- A bookings data set: This data set can be filtered on a specific time range. It can be used as the data feed for a *Service definition* component or to add booking data to a *Drop-down*, *List* or *Tree* feed component. If the entire booking data set is added, a time range feed should also be added as a filter. To specify a booking data feed in a URL, specify *bookings=bookingsID*

- A service definition data set: This data set can be used as the data feed for a *Service definition* component. Alternatively, in case a feed component is used to provide a booking feed to the *Service definition* component, it is possible to use a service definition filter feed on this feed component, so that a booking is only included in the feed if it is based on one the service definitions in the filter. To specify a service definition data feed in a URL, use the argument “service definitions”, and specify the service definition ID(s), for example: <br>*service definitions=serviceDefinitionID1%2FserviceDefinitionID2*

Note that if you add a data feed directly instead of via feed component, the *Service definition* component can be used either with a bookings data feed or with a service definition data feed, but not with a combination of both.

Several options are available to fine-tune the layout of the component. You can select whether node IDs and/or interfaces should be displayed, whether zooming is enabled, and which edge style is used.

When the service definition component displays nodes that are linked to particular resources, alarm and element info will now be displayed for these nodes in the graph. The alarm state will be displayed with a colored border at the top of the node, and in the node icon in case the default icon is shown. In addition, a link icon in the node will open the corresponding element card in the Monitoring app when clicked.

In the settings for the *Service definition* component, one or more actions can be defined. For each action, an Automation script and an icon need to be defined, and you need to specify to which node or nodes the action must be added. The icon will then be displayed on the specified node or nodes. When the icon is clicked, the script is launched. The booking ID or service definition ID used in the component and the node ID of the node for which the icon was clicked will be passed to the script as parameter ID 1 and parameter ID 2, respectively. The order of the specified actions can be modified in the *Settings* pane. In case there are too many actions on a node to display them all, clicking the action bar at the bottom of the node will expand the bar to display all the actions.

#### Dashboards app: CPE feed component now uses element data feed \[ID_25216\]

To configure the data input of the *CPE feed* component in the Dashboards app, you now have to use a regular element data feed instead of specifying the element in the component settings. This change makes it possible to provide the data input of the *CPE feed* component dynamically using another feed component.

#### Dashboards app: CPE feed will only pass along the deepest selected field \[ID_25304\]

From now on, a CPE feed will no longer pass along all selected fields. Instead, it will only pass along the deepest selected field.

#### Dashboards app: Image component now supports more image formats \[ID_25488\]

From now on, the image component supports the following image formats:

- apng

- gif

- jpeg

- png

- svg

- webp

> [!NOTE]
> As images in bmp format should be avoided in web content, this format is not supported.

#### Dashboards app: Component themes \[ID_25634\]

Within a particular dashboard theme, you can now define specific themes per component.

In a component theme, you can currently configure the following properties:

- Component title text styles

- Component background and font color

- Component margin and padding

- Component border styles

- Component shadows

You can change a component’s theme in the following ways:

- Select one of the existing component themes defined in the current dashboard theme.

- Customize the component’s current theme.

You can create new component themes in the following ways:

- Define a new component theme when creating or editing a dashboard theme.

- Save a component’s theme after having customized it.

> [!NOTE]
> - By default, a component will use the read-only default theme from the dashboard on which it is placed.
> - For backwards compatibility, components that previously inherited their styles from the dashboard theme will now use the default component theme instead.

#### Dashboards app: Linking a component to URL data without using a feed \[ID_25705\]

In the Dashboards app, it is now possible to link a component to data in the URL without using any feeds on the dashboard.

To do so, after selecting the component, open the *Data* tab, go to *Feeds \> URL*, and drag the necessary data onto the component.

> [!NOTE]
> When the dashboard has a feed that contains the same data as the URL, the feed will overwrite the data found in the URL.

#### Dashboards app - Service definition component: Options to show/hide nodes \[ID_25763\]

On the *Layout* tab of the service definition component, two new options now allow you to specify which nodes you want the component to show or hide:

- **Visible nodes**

    In this tree, which lists all available nodes grouped per parent system function and function definition, you can select the nodes to be displayed. The nodes that are not selected will be hidden.

- **Show nodes without a resource assigned**

    When you select this check box, the component will also show the nodes that have no resource assigned. By default, this check box will not be selected.

> [!NOTE]
> - When the service definition component does not show any node, an animation will indicate the reason why none are shown.
> - When actions are defined on a certain node, the group labels will now be moved to the top of that node.

#### Dashboards app: Embedding a single component into Visual Overview or a web page \[ID_25804\]

It is now possible to embed an individual Dashboards app component into Visual Overview or a web page.

Do the following:

1. In the Dashboards app, open the dashboard that contains the component you want to embed.

2. Right-click the component and select *Copy embed URL*.

3. Use the URL of the component in either a Visio page (e.g. in a shape with a data field of type “Link”) or a web page (e.g. in an \<img> tag).

A component URL has the following syntax:

```txt
http://<DMA>/embed?component=<SERIALIZED-COMPONENT>
```

> [!NOTE]
> - “SERIALIZED-COMPONENT” is a serialized representation of the component in JSON format.
> - If the component contains data, that data will automatically be included into the URL.

#### Dashboards app: Minimum and maximum values shown on line chart component \[ID_26063\]

When you hover the mouse pointer over a line chart component in the new Dashboards app, now the minimum and maximum values will be shown in addition to the average value that was already shown previously.

#### Dashboards app - Parameter feed: New option to automatically select a specified number of indices \[ID_26080\]

In the *Settings* tab of the parameter feed component, next to the *Auto-select all indices* option, there is now a new *Auto-select number of indices* option.

This new option will allow you to specify the number of indices that should be selected by default.

If the number of indices specified is greater than the number of indices that are being displayed, they will not be shown but selected in memory.

#### Dashboards app - Line chart component: New “Hide parameters without trend data in the leg­end” option \[ID_26133\]

The line chart component has a new setting: Layout \> Styling and information \> Hide parameters without trend data in the legend.

When you enable this setting, the legend of the line chart component will no longer show items for which no trend data is available.

Default: enabled

#### Dashboards app - Parameter feed: Index filter separator \[ID_26136\]

The parameter feed component has a new (optional) setting: Index filter separator.

This setting allows you to specify the separator to be used when retrieving a filtered list of indices.

For example, if only the indices with a primary key equal to “X” have to be retrieved, and the index filter separator is set to “Y”, then the indices will be retrieved using the following filter: PK == X OR PK == \*YXY\*.

#### Dashboards app - Parameter page: New data/filter feed combinations \[ID_26143\]

The parameter page component can now be configured to use the following data feeds and filters:

| Data feeds                  | Possible data filter feeds                                                                                                                                                                                                                                       |
|-----------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Element                     | \-  Data page based on element (legacy option - if possible, use a data page based on protocol)<br> -  Data page based on protocol |
| Data page based on element  | \<No additional data filter feeds required>                                                                                                                                                                                                                      |
| Data page based on protocol | Element feed                                                                                                                                                                                                                                                     |

#### Dashboards app - Pivot table component: Enhancements \[ID_26316\]

A number of enhancements have been made to the pivot table component, including the following:

- Elements are now ordered by element name.

- When using mediation protocol parameters, the data will now be shown per mediation parameter.

- Server-side exceptions will now be handled more gracefully.

#### Dashboards app: Enhanced border configuration \[ID_26346\]

When configuring a dashboard theme or a component layout, up to now, it was only possible to specify whether borders had to be displayed or hidden. From now on, it is possible to specify on which of the four sides a border has to be displayed or hidden: top, right, bottom and/or left.

#### Dashboards app: New style layout options for State components \[ID_26454\]\[ID_26498\]

In the Dashboards app, the layout options for the State component have been adjusted. The options that were previously available in the *Style* section are replaced with the following options:

- *Design*: Allows you to choose one of the following options:

    - *Small:* The component displays a single line containing a label and value.

    - *Large*: The component displays multiple lines with one value and up to three labels.

    - *Auto size*: Similar to the *Large* option, but automatically adjusts the content to fill the entire component.

- *Alarm state coloring*: Allows you to select one of the following options to determine how alarm coloring is displayed:

    - *LED*: The alarm color is displayed by a circular LED to the left of the first label.

    - *Line*: The alarm color is displayed by a bar along the left side of the component.

    - *Text*: The text color of the value matches the alarm color.

    - *Background*: The background of the component displays the alarm color. If this option is selected, an additional option, *Automatically adjust text color to alarm color*, can be selected to make sure the text color is adapted if necessary.

    - *None*: No alarm color is displayed.

#### Dashboard app: New setting to configure number of dashboard columns \[ID_26530\]

It is now possible to configure in how many columns components can be displayed in a dashboard. You can do so via the new *Number of columns* option in the settings of a dashboard. The maximum number of columns is 50. If you change the number of columns to a lower number and the columns currently contain components, a warning will be displayed, saying that components may be relocated.

In addition, when a dashboard is being edited, a new button is now available in the dashboard header bar that allows you to show or hide the grid lines in the dashboard while you are in edit mode.

#### Dashboards app: New Spectrum Analyzer component \[ID_26606\]\[ID_26675\]\[ID_26734\]\[ID_26820\] \[ID_26927\]\[ID_26970\]\[ID_27031\]\[ID_27150\]

When you create or update a dashboard, you can now add Spectrum Analyzer components.

A Spectrum Analyzer component, linked to a Spectrum Analyzer element, will open a new session based on the last session that was closed by the user in DataMiner Cube.

Also, in the DATA pane, you can select a spectrum preset and, for example, have it act as a filter. It is even possible to link a drop-down feed component to a Spectrum Analyzer component and use it to select the preset to be used in the latter.

> [!NOTE]
> Spectrum parameters dynamically added by spectrum monitors will automatically be available in the Dashboards app.

The Spectrum Analyzer component can also be used to visualize and toggle measurement points.

To visualize all measurement points for a particular spectrum session, do the following:

1. Add a Spectrum Analyzer component to the dashboard and, in the Data pane of the component, select a Spectrum Analyzer element (and, optionally, a Spectrum preset).

2. Add a List feed to the dashboard and, in the Data pane of the feed, select the Spectrum session feed of the Spectrum Analyzer component.

    > [!NOTE]
    > A Spectrum Analyzer component can be used as a feed for a Spectrum session. The session created by a Spectrum Analyzer component can be used as input for other components.

By selecting and unselecting measurement points in this measurement point visualization, you can control which measurement points will be used by the Spectrum Analyzer component.

> [!NOTE]
> - The Dashboards app and the Monitoring app also support combining measurement points. In DataMiner Cube, you can create spectrum presets in which you combine measurement points to have them shown together.
> - Measurement point traces will inherit their colors from the dashboard theme.

#### Dashboards app: Advanced settings \[ID_26659\]

Component settings can now be marked as advanced. When marked as such, they will only be displayed when you opened the Dashboards app with the following URL argument:

- “showAdvancedSettings=true”

#### Dashboards app: Optimalization of component visualizations \[ID_26751\]

After adding a component to a dashboard, you can apply a specific visualization. The list of available visualizations has now been optimized.

Up to now, the list of available visualizations depended on the type of component. From now on, that list will instead depend on the type of data linked to the component. In other words, the list will contain all visualizations that are capable of visualizing the type of data currently linked to the component.

The order of the listed visualization has also been optimized. First in the list will be the most obvious ones to visualize the data in question, followed by all other available visualizations sorted alphabetically by name.

Hovering over a visualization will preview the component.

#### Dashboards app: State timeline component \[ID_26772\]

The state timeline component visualizes the alarm state changes over time of a parameter, element or service. By default, it shows a timeline for the last 24 hours, but a time range feed can be added to set the component to a different time range.

To configure the component:

1. Apply an element, service, or protocol/element parameter data feed.

2. Add a filter if necessary:

    - If the component uses a protocol parameter data feed, add an element filter feed.

    - If the component uses a table or column parameter data feed, add an index filter feed.

3. Optionally, add a Time range component to the dashboard and configure the state timeline component to use it as a filter feed.

#### State/Gauge/Ring components now able to show multiple items for several types of feeds \[ID_26780\]

In the Dashboards app, it is now possible to show multiple states with the same *State*, *Ring* or *Gauge* component, even if elements, services, views or redundancy groups are used as the data feed. Previously, this was only supported for parameter feeds.

For the *State* component, the *Layout flow* options in the *Layout* panel allow you to select whether the different states should be displayed in rows or columns. If they are displayed in rows, they will displayed next to each other until there is no more space and a new row is started. If they are displayed as columns, they will be displayed below each other until there is no more space and a new column is started.

For the *Ring* and *Gauge* component, if parameter feeds are used, additional options in the layout panel allow you to configure whether the differeynt parameters are displayed next to each other or below each other, and how many rows and columns of parameters can be displayed at the same time. These options are not available for other types of feeds; for those only one item is displayed at the same time and you need to scroll to see the next item.

#### Dashboards app: Dashboards created by users will now be included in DataMiner backup pack­ages \[ID_26836\]

When, in DataMiner Cube, you take a backup, all dashboards created by users (i.e. all files stored in C:\\Skyline DataMiner\\Dashboards) will now be included in the backup package if you selected either “full backup” or “full backup without database”.

#### Dashboards app: New Image size option for Image component \[ID_27040\]

In the Dashboards app, a new *Image size* option is now available for *Image* components. This option allows you to determine how the image is scaled, with the following three possibilities:

- *Fit*: Scales the image to the maximum possible size without stretching or cropping.

- *Fill*: Scales the image to the maximum possible size without stretching.

- *Stretch*: Scales the image to the maximum possible size without preserving the aspect ratio.

#### Dashboards app: State component now supports dynamic units \[ID_27066\]

The State component in the Dashboards app now supports dynamic units, i.e. units that can be converted to other units according to rules configured in the protocol.

For this purpose, 2 new methods have been added to the web services API v1: *GetParameterWithDynamicUnits* and *GetParameterForServiceWithDynamicUnits*, which are similar to the *GetParameter* and *GetParameterForService* methods, respectively.

#### Dashboards app: Spectrum buffer feeds \[ID_27092\]\[ID_27154\]

It is now possible to use spectrum buffers as input for a Spectrum Analyzer visualization. These are available in the new *Spectrum Buffers* section in the *Data* pane. To select a spectrum buffer, first specify the name of a spectrum element in the box at the top if this section. The buffers are then listed in the format *MonitorName: TraceName \[MeasptName\] \[PresetName\]*.

You can link a Spectrum Analyzer visualization to spectrum buffer input directly, or use feed components (e.g. drop-down or list), by adding an individual spectrum buffer to a feed component or by adding the spectrum buffers as a collection and then adding a spectrum element as a filter.

#### Dashboards app: Line chart component now exposes timespan feed \[ID_27128\]

If a line chart component is used in a dashboard, a timespan feed now becomes available in the data pane, which can be used to apply the timespan of the line chart to other components as a feed. This timespan feed is updated whenever the timespan displayed by the trend graph is adjusted, e.g. because you zoom in on a specific timespan.

#### Dashboards app: Threshold state visualization in spectrum analyzer components \[ID_27169\]<br>\[ID_27273\]

If a spectrum analyzer component in the Dashboards app uses a spectrum buffer feed, it is now possible to color the threshold lines from the preset based on the state of a spectrum monitor parameter. Threshold lines are now also displayed as distinct line segments, and can be hidden or shown depending on the preset.

To be able to link a threshold line to a spectrum monitor parameter, the spectrum script used by the monitor must contain variables referring to the thresholds. Each threshold line has a threshold ID, which is an index ranging from 1 to the total number of thresholds in the preset. To refer to the first threshold, the script variable should be *$threshold1*, for the second threshold, it should be *$threshold2*, etc. This format is case-sensitive. When you configure the spectrum monitor in DataMiner Cube, you can then select these variables to create a parameter with alarm monitoring.

Note that it does not matter in which preset the threshold is defined. For example, each threshold in a preset with index 3 will be linked to the state of script variable *$threshold3* in a monitor.

> [!NOTE]
> - Similar to DataMiner Cube, threshold lines will appear in front of the spectrum trace.
> - In case of a buffered trace, a time stamp will be shown in the top-right corner, indicating when the buffer was last updated.
> - When the background color is changed, the marker labels and the time stamp will be updated accordingly.
> - Changing the spectrum buffer or switching to normal mode will reset any threshold line that was linked to a monitor parameter state to its default width. Linked threshold lines are slightly thicker.

#### Dashboards app: New “Enable pinning as quick pick” option + support for timespans as input for time range feed \[ID_27357\]

In the Dashboards app, if the layout option *Use quick picks* is selected for a time range component, you can now enable the additional option *Enable pinning as quick pick*. When you do so, a pin icon is displayed next to the time summary in the component. Clicking the icon will add the current time selection as a custom quick pick button. If the current time selection matches the custom quick pick button, clicking the pin icon again will remove the button. You can also remove the button using the garbage can icon on the button itself.

The custom quick pick button is saved on component level, which means it will remain displayed when the dashboard is refreshed, until it is manually removed.

As an additional change, the time range feed has been updated to also accept timespans as input data now. Adding a timespan as input will set the active time range in the feed.

#### Dashboards app: Selecting an empty folder will now cause a “Create dashboard” button and a “Import dashboard” button to appear \[ID_27362\]\[ID_27579\]\[ID_27844\]

When, in the sidebar of the Dashboards app, you select an empty folder, two large buttons will now appear in the large pane on the right.

| Click...         | to...                                                           |
|------------------|-----------------------------------------------------------------|
| Create dashboard | create a new dashboard from scratch in the folder you selected. |
| Import dashboard | import an example dashboard in the folder you selected.         |

> [!NOTE]
> The two above-mentioned options will also be available in the context menu when you right-click a folder in the navigation pane.

#### Dashboards app: Support for table column parameter as input for State component \[ID_27463\]

When you use a table column parameter as input for a State component in the Dashboards app, it will now display the state for all indices of the column. Optionally, you can add an indices filter in order to display specific indices only.

#### Ordering of data entries used in a dashboard component \[ID_27486\]

For dashboard components that can display multiple data entries and for which it makes sense to modify the order in which these entries are displayed (e.g. State components, Parameter table components, etc.), in the *Data* pane, a new *Data used in component* section is available. This section lists the different data entries used by the selected component, with arrow icons on the right that can be used to change the order in which the entries are displayed.

#### Dashboards app: Support for quick filters of tables in visual overview components \[ID_27517\]

Quick filters are now supported for tables within a visual overview component of a dashboard. The following (case-insensitive) syntax is supported for the filters:

- {column name}{operator}{value}

- {column name}{operator}regex{operator}{regex value}

- {column name}{operator}severity{operator}{alarmstate}

- regex{operator}{regex value}

- severity{operator}{alarmstate}

The following operators are supported in this syntax:

- : (contains)

- !:

- =

- !=

- ==

- !==

- \<=

- \>=

- \>

- \<

#### Dashboard theme configuration improvements \[ID_27553\]

The following improvements have been implemented to dashboard themes:

- It is now possible to customize the colors for the lines displayed in a trend graph. You can do so on dashboard level, by customizing the theme, or on component level, by customizing the component theme. In either case, the colors can be configured under *Color* > *Color palette*.

- While previously, customizing the dashboard theme within a dashboard only provided limited options compared to the theme configuration in the settings of the Dashboards app, now a *New theme* button is available in the dashboard *Layout* pane, which will open a pop-up window where you can fully configure a new theme.

#### Dashboard Gateway \[ID_27558\]

A new Dashboard Gateway now gives users access to the Dashboards app as well as to all other DataMiner web applications (Monitoring, Ticketing, Jobs, etc.) even if they do not have access to DataMiner.

There are two main reasons to consider a Dashboard Gateway setup:

- Security

    Users are allowed to connect to the Dashboard Gateway, but not to the DataMiner Agents directly. Also, it is possible to install only the web applications on the Dashboard Gateway web server(s) to which you want users to have access. If you only install the Dashboards and the Monitoring app, users will not be able to access the Jobs app, the Ticketing or any other app.

- Performance

    Allowing multiple users to connect to the web applications increases the overall load on the DataMiner Agents. When using a Dashboard Gateway, the direct load of the web applications and the HTTP requests shifts to a separate web server, leaving more resources available on the DataMiner Agents. Also, if more performance is needed, multiple Dashboard Gateway web servers can be used in combination with a load balancer.

Requirements:

- At least one web server (running Windows Server)

- A valid SSL certificate signed by a public certificate authority for the FQDN of the Dashboard Gateway (e.g. “gateway.mycompany.com”)

- A DataMiner user account with

    - access to all views, elements and alarms,

    - permission to access the Alarm Console and Data Display, and

    - permission to create, edit and delete dashboards.

- The Dashboard Gateway web server(s) should be able to communicate with a DMA using both a .NET Remoting connection and an HTTP(S) connection (using port 80 or 443, depending on the HTTP(S) configuration of the DataMiner Agent)

Configuration:

1. On the Dashboard Gateway web server(s), install IIS and the URL Rewrite module.

    For IIS, make sure to install Classic ASP, ASP.NET 4.6+, and the WebSocket protocol.

2. In IIS Manager, import the certificate, and update the site binding to use HTTPS with this certificate.

3. Configure URL Rewrite to forward all HTTP traffic to HTTPS

4. From a DataMiner Agent, copy the C:\\Skyline DataMiner\\Webpages\\API folder to the web root folder of the Dashboard Gateway web server (default: C:\\inetpub\\wwwroot) and, in IIS Manager, convert the API into an application.

5. From a DataMiner Agent, copy over the web application(s) (e.g. C:\\Skyline DataMiner\\Webpages\\Dashboard, C:\\Skyline DataMiner\\Webpages\\Monitoring, C:\\Skyline DataMiner\\Webpages\\Jobs, C:\\Skyline DataMiner\\Webpages\\Ticketing, etc.) to the web root folder of the Dashboard Gateway web server.

6. On the Dashboard Gateway web server, edit the web.config in the API folder, and specify the following settings:

    | Setting          | Description                                                                                                              |
    |--------------------|--------------------------------------------------------------------------------------------------------------------------|
    | connectionString   | Host name or IP address of the DataMiner Agent to which the Dashboard Gateway has to connect.                            |
    | connectionUser     | DataMiner user account that the Dashboard Gateway has to use to connect to the DataMiner Agent (user name and password). |
    | connectionPassword |                                                                                                                          |

Known limitations:

- The URL folder structure of the web applications should remain the same as on a DataMiner Agent. The applications have to be accessed using the following URL:

    - https://gateway.somecompany.com/dashboard

    - https://gateway.somecompany.com/monitoring

    - https://gateway.somecompany.com/ticketing

    - https://gateway.somecompany.com/jobs

- The DataMiner user account used by the Dashboard Gateway web server should not have multi-factor authentication enabled.

#### Dashboards app: Default themes updated \[ID_27636\]

In the Dashboards app, the default themes have all been updated.

#### Dashboards app - Line chart component: Value range \[ID_27774\]

When configuring a line chart component, you can now specify a value range for the trend graph by entering a minimum limit and/or a maximum limit.

The value range you specify will apply to all trend lines displayed on the graph.

#### Dashboards app - Line chart component: Show minimum, maximum and/or average trend lines \[ID_27815\]

When configuring a line chart component that does not show real-time trend data, you can now make the trend graph show a minimum, a maximum and/or an average trend line by switching on the following options:

- Show average (default setting: switched on)

- Show minimum (default setting: switched off)

- Show maximum (default setting: switched off)

#### Dashboards app - Parameter feed: “Auto-select all” option \[ID_27816\]\[ID_28033\]

When configuring the Parameter feed, up to now, it was possible to either have a specific number of indices selected automatically or have all indices selected automatically.

- Auto-select number of indices

- Auto-select all indices

Now, the above-mentioned options have been replaced by the “Auto-select all” option. When this option is selected, all items will be selected according to the "Select all behavior" settings below it:

- If you select the “Select all items” option, "Select all" will select all items. For a partial table, only the items from the first page will be selected.

- If you select the “Select specific number of items” option, a box is displayed below it. In this box, you should specify how many items "Select all" should select. For a partial table, these items will be selected across different pages.

#### Dashboards app - Line chart component: New “Chart limit behavior” setting \[ID_27841\]

When configuring a line chart component, you can now use the *Chart limit behavior* setting to indicate what needs to happen when the number of parameters in the chart exceeds the defined chart limit:

| Option                       | Behavior                                                                                                                                                                             |
|------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Disable parameters in legend | The excess parameters are disabled in the chart but remain available in the chart legend, so that they can be enabled again manually. <br> This option is selected by default.       |
| Create additional charts     | Additional charts are displayed that include the parameters that exceed the limit. If necessary, multiple additional charts will be displayed, each respecting the configured limit. |

#### Dashboards app - Pivot table component: Sort ascending/descending \[ID_27862\]

When configuring a pivot table component, you can now find the following settings in the Sort section of the Settings tab:

| Setting        | Description                                                                                                                           |
|----------------|---------------------------------------------------------------------------------------------------------------------------------------|
| Sort           | Allows you to select a protocol (if the pivot table contains multiple protocols) and a parameter by which the table should be sorted. |
| Sort ascending | Determines the order in which the pivot table is sorted.<br> If you clear this check box, it is sorted in descending order.           |

> [!NOTE]
> Using these sort settings in conjunction with the *Limit* setting in the *Configure indices* section, you can produce a top X or bottom X list.

#### Dashboards app - GQI: Queries will now be saved in a separate JSON file and will be referred to using a GUID \[ID_28088\]

From now on, queries will no longer be saved in a dashboard, but in a separate file named Queries.json, located in C:\\Skyline DataMiner\\Generic Interface. Dashboards using a query will then link to it using a GUID.

#### Dashboards app - GQI: Existing queries can now be reused \[ID_28102\]

When building a query, instead of having to start a new query from scratch, it is now possible to select an existing query in the *Start from* box, and then start building a query based on the one you selected.

Current limitations:

- Changing a query will not trigger a revalidation of the queries that are using the updated query. A component will only re-fetch a query when the dashboard is refreshed or when the final query is changed.

- If queries are running in a loop, a circular dependency error will be displayed.

#### Dashboards app - GQI: Datasources now have a default column set \[ID_28103\]

Each of the different datasources now has a default column set, which, if necessary, can be extended with every possible column in that datasource by adding column selector nodes to the query.

| Datasource         | Default column set                                                 |
|--------------------|--------------------------------------------------------------------|
| Alarms             | Visible columns in the Alarm Console of the Monitoring app.        |
| Parameter tables   | Visible columns of the table definition in the protocol (max. 10). |
| Profile definition | Parameters in the profile definition (max. 10).                    |
| Ticketing          | Fields displayed in the Ticketing app’s list view (max. 10).       |

> [!NOTE]
> All columns, even those that are not visible in the current data table, can be used by the operators. For example, you can filter data by a column that is not visible in the data table.

#### Dashboards app - Bar chart component: Enhancements \[ID_28461\]

A number of enhancements have been made to the bar chart component.

**Two additional chart layouts**

There are now four chart layouts to choose from:

| Chart layout                                             | Description                                                                |
|----------------------------------------------------------|----------------------------------------------------------------------------|
| Absolute                                                 | Shows the absolute value.                                                  |
| Relative per category<br> (new)                          | Shows the value as a percentage of all the variables within that category. |
| Relative per variable<br> (previously called “Relative”) | Shows the value as a percentage of the variable across all categories.     |
| Relative total                                           | Shows the value as a percentage of the total sum of all values.            |

**Stacked bars**

If you select the *Stack bars* option, the bars in the graph will be displayed one on top of the other instead of one next to the other.

> [!NOTE]
> This option will be especially useful in combination with the “Relative per category” chart layout.

**Additional highlighting possibilities**

Apart from highlighting all bars belonging to a specific variable, you can now also highlight a single category by hovering over the label of the category or by hovering over empty space in a stacked bar chart.

#### Dashboards app - GQI: Exception values will now be processed as discrete values \[ID_28570\]

In GQI operators, up to now, exception values were processed as regular values. From now on, they will be processed as discrete values. As a result, the TopX operator and the following aggregation methods will no longer take them into account:

- Average

- Max

- Min

- Percentile

- Standard deviation

- Sum

> [!NOTE]
> - The *Count* and *Distinct count* aggregation methods will take exception values into account.
> - Exception values will not be taken into account when calculating the minimum and maximum value for columns using GenIfColumnFetch-Requests.

#### Dashboards app - Bar chart component: Negative values & Dynamic axis labels \[ID_28617\]

The bar chart component now supports negative values.

Also, the number of axis labels displayed will now depend on the size of the chart. Up to now, a fixed number of axis labels would be displayed.

#### Dashboards app - State component: Alignment setting \[ID_28633\]

The layout pane of a State component now has an additional setting that allows you to align its contents (left/center/right).

Also, in the components pane on the left, the *States* section has now been renamed to *States and values*.

#### Dashboards app - GQI: Availability of the database will first be checked before querying an Elasticsearch database \[ID_28742\]

From now on, when GQI queries are about to fetch data from an Elasticsearch database, the availability of that database will first be checked.

### DMS Automation

#### Possibility to add, update or clear the script output \[ID_23936\]

Up to now, when a parent script added keys to the script output and then ran a subscript that also added keys to the script output, the keys added by the parent script would be deleted. From now on, the keys added by the parent script will by default no longer be deleted. If you want those keys to be deleted, then have the parent script call the engine.ClearScriptResult() method before starting the subscript.

Up to now, the following engine objects could be used to manipulate the script output:

- engine.AddScriptOutput(string key, string value)

    Adds a key to the script output if it has not yet been added. If the key already exists, an exception will be thrown.

- subScriptOptions.GetScriptResult()

    Returns a copy of the script output of the current script and, if the InheritScriptOutput option is set to “true”, the child scripts. For more information, see below.

From now on, you can also use the following new engine objects:

- engine.AddOrUpdateScriptOutput(string Key, string Value)

    Adds a key to the script output if it has not yet been added. If the key already exists, it will update it with the specified value.

- engine.ClearScriptResult()

    Clears the script output.

- engine.ClearScriptOutput(string key)

    Removes a key from the script output. Returns NULL when the specified key cannot be found.

- engine.GetScriptResult()

    Returns a copy of the script output of the current script and, if the InheritScriptOutput option is set to “true”, the child scripts. For more information, see below.

- engine.GetScriptOutput(string key)

    Returns the script output of the specified key. Returns NULL when the specified key cannot be found.

> [!NOTE]
> When a subscript fails or throws an exception, its script output will still be filled in.

Also, a new InheritScriptOutput script option will now allow you to control whether a parent script will inherit the script output of its subscripts. Default value: true

Example:

```txt
var scriptOptions = engine.PrepareSubScript("MyScript");
scriptOptions.InheritScriptOutput = true;
scriptOptions.StartScript();
```

#### New methods to allows QActions to execute Automation scripts \[ID_24475\]

Two new SLProtocol methods now allow QActions to execute Automation scripts:

- ExecuteScript(string scriptName)

- ExecuteScript(ExecuteScriptMessage message)

Also, the Engine object has a new UserCookie property.

**ExecuteScript(string scriptName)**

This method will execute an Automation script of which the name is passed in the “scriptName” argument.

The script will be executed by the user who is performing the QAction. It will return an “ExecuteScriptResponseMessage”, containing information about the execution of the script.

If you execute a script using this method, it will be executed with all script execution settings set to the default values. If more control is needed, then use the E*xecuteScript<br>(ExecuteScriptMessage message)* method described below.

Example:

```txt
public static void Run(SLProtocol protocol)
{
    protocol.ExecuteScript("MyScriptName");
}
```

**ExecuteScript(ExecuteScriptMessage message)**

This method will execute an Automation script of which all details and execution settings are passed in the “ExecuteScriptMessage”.

The script will be executed by the user who is performing the QAction. It will return an “ExecuteScriptResponseMessage”, containing information about the execution of the script.

Using this method to execute an Automation script is particularly useful when the script in question needs a dummy or protocol information to run.

Code Example:

```txt
ExecuteScriptMessage esm = new ExecuteScriptMessage("RT_AUTOMATION_ExecuteAutomationByProtocol_AutomationScriptCode")
{
    Options = new SA(new[]
    {
        "OPTIONS:0",
        "CHECKSETS:TRUE",
        "EXTENDED_ERROR_INFO",
        "DEFER:FALSE"
    })
};
protocol.ExecuteScript(esm);
```

When you execute an Automation script using the “DEFER:FALSE” option, be aware that this will lock any further processing of the protocol. If, for example, the Automation script that is being executed by a QAction sets a parameter of the element containing that same QAction, the parameter will be locked until the Automation script times out. This default behavior can be bypassed in two ways:

- In the protocol, add the “queued” option to the QAction tag, or

- Use “DEFER:TRUE” instead of “DEFER:FALSE”.

    | If you use... | then...                                                                                                                              |
    |-----------------|--------------------------------------------------------------------------------------------------------------------------------------|
    | DEFER:FALSE     | the QAction will halt while the Automation script is being executed, and will only continue once the Automation script has finished. |
    | DEFER:TRUE      | the QAction will continue while the Automation script is being executed asynchronously.                                              |

**New property on Engine object: UserCookie**

```txt
string Engine.UserCookie;
```

#### Injecting a DLL into an Automation script \[ID_24945\]

It is now possible to inject DLL files into an Automation script.

**To inject a DLL**

1. Create an *AutomationDllInjectionItem* object that contains the following data:

    | Item     | Description                                                                                              |
    |------------|----------------------------------------------------------------------------------------------------------|
    | ScriptName | The name of the script into which the DLL will be injected.                                              |
    | ExeId      | The ID of the script action that will be replaced.<br> Note: This script action must be a C# code block. |
    | Path       | The path to the DLL that will be injected.<br> Note: This file must have the extension “.dll”.           |

2. Send the object to the server using an *InjectAutomationDllRequestMessage*.

The server will send back an *InjectAutomationDllResponseMessage*. If any errors would have occurred, they will be included as errors of type *AutomationErrorData* in the message’s *TraceData* object. Possible errors include:

| Value           | Description                                                                                                                                       |
|-----------------|---------------------------------------------------------------------------------------------------------------------------------------------------|
| Unknown         | An unknown error occurred.                                                                                                                        |
| NotAllowed      | The user who sent the message does not have the correct permissions.                                                                              |
| DllPathInvalid  | The DLL path is invalid. The file does not exist or does not have the extension “.dll”.                                                           |
| NotLicensed     | The DataMiner Agent is not licensed to use the Automation module.                                                                                 |
| InjectionFailed | The injection operation failed in SLAutomation.<br> For more information, check the *SLAutomationErrors* property. |

To determine whether the injection was successful, you can check TraceData.HasSucceeded.

**To request an overview of the injected DLLs**

Send a *GetAutomationDllOverviewRequestMessage* to the server. This message does not have any properties.

The server will send back a *GetAutomationDllOverviewResponseMessage* containing a list of *AutomationDllInjectionItem* objects.

**To eject a DLL**

If you eject a previously injected DLL from an Automation script, this will cause the script to behave as it did before the injection. To do so, send an *EjectAutomationDllRequestMessage* containing the name of the script and the Exe ID (i.e. the ID of the script action).

The server will send back a EjectAutomationDllResponseMessage. If any errors would have occurred, they will be included as errors of type *AutomationErrorData* in the message’s *TraceData* object. Possible errors include:

| Value          | Description                                                                                                                                                                                                                                     |
|----------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Unknown        | An unknown error occurred.                                                                                                                                                                                                                      |
| NotAllowed     | The user who sent the message does not have the correct permissions.                                                                                                                                                                            |
| NotLicensed    | The DataMiner Agent is not licensed to use the Automation module.                                                                                                                                                                               |
| EjectionFailed | The ejection operation failed in SLAutomation.<br> For more information, check the *SLAutomationErrors* property.<br> Note: This error will never be returned after injecting a DLL. See “To eject a DLL” below. |

**To execute a script**

Send an ExecuteScriptMessage to the server.

> [!NOTE]
> - Users who send the above-mentioned messages must have the “Automation \> Edit” permission to be able to inject or eject DLLs.
> - DLLs can be injected in scripts that have not yet been run.
> - When you restart the DataMiner Agent, the injected DLL will no longer be applied.

#### New method to link ReservationInstances to a ticket \[ID_25154\]

In a C# block of an Automation script, you can now link ReservationInstances to a ticket.

See the following example:

```txt
// Create a ReservationInstanceID object
var reservationInstanceId = new ReservationInstanceID(reservationInstance.ID);
// Create a TicketLink using the static 'Create' method
var ticketLink = TicketLink.Create(reservationInstanceId);
// Add the TicketLink to the ticket
ticket.AddTicketLink("KeyForThisLink", ticketLink);
```

Note that you can use lists of TicketLink objects to retrieve a filtered list of tickets. See the following example:

```txt
// TicketLink filters are lists of TicketLink objects
var ticketLinkFilter = new[] {ticketLink};
// Use a list of TicketList objects to retrieve tickets by means of the 'GetTickets' method
var tickets = ticketingGatewayHelper.GetTickets(ticketLinkFilter);
```

#### Interactive Automation scripts: Properties added to UIBlockDefinition class \[ID_25183\]<br>\[ID_25253\]

The following properties have been added to the UIBlockDefinition class:

| Property        | Description                                                                                                                                                                                                                                                                                                                                                                                                                               |
|-----------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| IsRequired      | Indicates whether the input control requires a value.<br> Possible value:<br> -  true<br> -  false<br> If “true”, the control will be marked “Invalid” when empty.                                                                                                                                          |
| PlaceholderText | Text that will be displayed as long as the control is empty.<br> (e.g. “In this box, enter...”)                                                                                                                                                                                                                                                                                                                                           |
| ValidationState | Indicates whether the value was validated and whether that value is valid.<br> Possible values:<br> -  NotValidated<br> -  Valid<br> -  Invalid<br> Note: This property can be used to indicate to users that they entered an invalid value. |
| ValidationText  | Text that will be displayed when ValidationState is “Invalid”.                                                                                                                                                                                                                                                                                                                                                                            |

**Using the ValidationState and ValidationText properties**

The ValidationState and ValidationText properties should be used in combination with the WantsOnChange property.

If WantsOnChange is true, the interactive Automation script will have its Engine#ShowUI(...) method return each time the user input changes. This will also be indicated by the \_ONCHANGE key, which is returned in the UIResults.

This functionality will allow you to offer clear feedback on user input.

**Which input controls support which properties?**

|              | IsRequired | Placeholder | ValidationText |
|--------------|------------|-------------|----------------|
| TextBox      | X          | X           | X              |
| PasswordBox  | X          | X           | X              |
| DropDown     | X          | X           | X              |
| Numeric      | X          | X           | X              |
| Calendar     | X          |             | X              |
| FileSelector |            |             | X              |

#### Possibility to add Attachments to tickets \[ID_25612\]

In a C# block of an Automation script, you can now add attachments to tickets.

In the TicketingHelper class and TicketingGatewayHelper, the “AttachmentsHelper Attachments” property will allow to manage ticket attachments using the following methods:

| Method                                                      | Function                                                                                     |
|-------------------------------------------------------------|----------------------------------------------------------------------------------------------|
| Add(TicketID ticketID, string fileName, byte\[\] fileBytes) | Add an attachment to a ticket                                                                |
| List\<string> GetFileNames(TicketID ticketID)               | Retrieve the names of all the attachments added to the ticket with the specified ticket ID.  |
| Delete(TicketID ticketID, string attachmentName)            | Deletes the attachment with the specified name from the ticket with the specified ticket ID. |
| byte\[\] Get(TicketID ticketID, string attachmentName)      | Retrieves the content of the attachment with the specified name as a byte array.             |

> [!NOTE]
> - The maximum size of ticket attachments is determined by the Documents.MaxSize setting, located in the MaintenanceSettings.xml file. Default: 20 Mb. Trying to upload a larger file will result in a DataMinerException.
> - Manipulating ticket attachments requires the same user permissions as normal ticket management operations: Read permission to view and download attachments and Edit permission to add and delete attachments.
> - If a ticket is deleted, all its attachments will physically be deleted from disk. They will not be recoverable.
> - All ticket attachments are synchronized throughout the DataMiner System. To include them in a backup, select the “All documents located on this DMA” backup option.
> - The Documents API can also be used to manage ticket attachments. Instead of using the above-mentioned methods, you can also use AddDocumentMessage, DeleteDocumentMessage, GetBinaryFileMessage and GetDocumentMessage. If you do so, specify the directory as “TICKET_ATTACHMENTS\\{DataminerID}\_{TicketId}” and make sure the property ID of type DMAObjectRef contains the ticket ID.

#### Run-time flag “NoCheckingSets” now allows the “After executing a SET command” option to be changed while a script is being run \[ID_25847\]

When you launch an Automation script, you can choose to select the “After executing a SET command” option. If you do so, every time the script performs a parameter or property update, it will wait for a return value indicating whether or not the update was successful.

From now on, the “NoCheckingSets” run-time flag will allow this option to be changed while a script is being run.

#### Connecting a DMS to a remote ElasticSearch cluster from an Automation script \[ID_26569\]

It is now possible to have a DMS connect to the nodes of a remote ElasticSearch cluster from an Automation script by sending an InstallElasticAndMigrateRequest message.

This message will add the IP addresses of the remote ElasticSearch nodes to the db.xml file.

#### Replacing Automation script DLL dependencies \[ID_26605\]

It is now possible to replace an Automation script DLL dependency from an Automation script by sending an UploadScriptDependencyMessage.

By default, the DLL file will be uploaded to the C:\\Skyline DataMiner\\scripts\\dllImport folder, but it is possible to specify a subfolder if required. The uploaded DLL file will be synchronized among all agents in the DMS.

- The name of the new DLL file in the UploadScriptDependencyMessage must be identical to the name of the old DLL file. If not, the file will no longer be found after a DataMiner restart.

- Automation scripts using a DLL file should always refer to that file using its full path. If you upload a DLL file named “MyDependency.dll”, the scripts using it should refer to it using “C:\\Skyline DataMiner\\Scripts\\DllImport\\MyDependency.dll”.

- DLL files in the C:\\Skyline DataMiner\\Scripts\\DllImport folder are loaded from bytes rather than from file. They will not be locked by SLAutomation after being loaded. Note that, in some rare cases, DLL files loaded from bytes will not work properly. An example of a file that will not work when loaded from bytes is Microsoft.Exchange.WebServices.

- When a script dependency is uploaded using an UploadScriptDependencyMessage

    - all scripts that directly reference the file will be recompiled when executed, and

    - all libraries that reference the file (and all libraries that use those libraries) will be recompiled immediately.

- When you reference a DLL file stored in C:\\Skyline DataMiner\\Scripts\\DllImport while a DLL file with the same name is present in C:\\Skyline DataMiner\\Files, the former will take precedence.

- Users need the *Modules \> Automation \> Edit* permission to be able to upload Automation script dependencies.

> [!NOTE]
> - If an uploaded DLL dependency would break existing scripts and/or libraries, no errors will be returned.
> - It is advised to strong-name DLL files when referring to multiple versions of the same file in different scripts. Not strong-naming DLL files could lead to unexpected behavior.

#### Uninstalling app packages \[ID_26643\]

App packages can now be uninstalled using the new AppPackageHelper method UninstallApp.

```txt
/// <summary>
/// Uninstalls the app with ID <paramref name="appId"/>
///
/// <param name="appId">The ID of the app to be uninstalled.</param>
/// <param name="force">
///    If true:
///    - The app will be forcefully uninstalled, even if the uninstall script         fails.
///    - If the uninstall script exits with an exception or could not be run,         no exceptions will be thrown.
/// </param>
/// <exception cref="AppUninstallationFailedException">
///    This exception will be thrown in the following cases:
///    - When the specified app is not installed.
///    - When the uninstall script could not be run due to syntax errors.
///    - When the uninstall script exited with an exception.
/// </exception>
/// <exception cref="DataMinerException">
///    This exception will be thrown in all other cases when something goes wrong.
/// </exception>
/// </summary>
///
public void UninstallApp(AppID appId, bool force)
```

**Uninstall script**

Inside every app package, an uninstall script named *uninstall.xml* should be available in the Scripts folder.

An uninstall script has to be triggered using the UninstallApp entrypoint (see below for an example). As soon as the uninstall script has finished, the installation folder of the app in question will be removed on all agents in the DMS.

```txt
[AutomationEntryPoint(AutomationEntryPointType.Types.UninstallApp)]
public void Uninstall(Engine engine, AppUninstallContext context)
{
    ...
}
```

**Remarks**

- When an app package does not contain an uninstall script (or when the uninstall script is not a valid XML file), triggering the non-existing uninstall script will cause the installation folder of the app in question to be removed on all agents in the DMS.

- Only users with “Install App Packages” permission will be able to trigger an uninstall script.

- It is up to the creator of an app package to provide an uninstall script that properly cleans up the installed app. DataMiner does not keep track of the objects that are installed when installing an app and will not do any cleanup except removing the installation folder.

- If the uninstall script contains syntax errors it will still be installed.

- When you install an app with the *AllowMultipleInstalledVersions* option set to false, the uninstall script of that app (if present) will automatically be triggered. Also, the uninstall will be executed forcefully, meaning that the app will be removed even when the script fails.

- When an app is being uninstalled, its AppInstallState will be set to BUSY_UNINSTALLING, and if anything goes wrong during the uninstall (and the uninstall was not executed forcefully), its AppInstallState will be set to CORRUPTED.

- An app of which the AppInstallState is set to BUSY_INSTALLING can only be uninstalled forcefully.

- If an uninstall script requires any external DLL files, those can be placed in the C:\\Skyline DataMiner\\Scripts\\UninstallDependencies folder. During an uninstall operation, the dependencies will then automatically be referenced in the uninstall script.

> [!NOTE]
> The DataMiner SLNetClientTest tool now also supports uninstalling app packages. See *Advanced \> Apps \> App Packages*.

#### Automation: Tree view control for interactive Automation scripts \[ID_26840\]\[ID_27041\]\[ID_27756\]

It is now possible to add a tree view control in an interactive Automation script. However, note that Automation scripts with tree view controls are currently only supported in the DataMiner mobile apps. These are not yet supported in DataMiner Cube.

To define a tree view control, create a UIBlockDefinition of type TreeView and add each item of the tree view as a TreeViewItem to the TreeViewItems property. It is not required to fill in the InitialValue or Value of the UIBlockDefinition, as that value is determined based on the TreeViewItem collection.

Each TreeViewItem has the following properties:

- *DisplayValue*: The string value displayed for this item in the UI.

- *KeyValue*: The string value that is used as a key to retrieve the selected state of the item. This is the value that will be used in the destination variable.

- *IsChecked*: Boolean that allows you to have an item selected by default. Do not fill in this property for TreeViewItems that have child items. The selection of such a parent item depends on the selected child items. If some of the child items are selected, the parent item is only partially selected and its value will not be included in the destination variable. If all child items are selected, the parent item is automatically also selected.

- IsCollapsed: Boolean that allows you to indicate whether the item should be collapsed or expanded.

    > [!NOTE]
    > This property will not be updated when you collapse or expand tree view items in the UI.

- *ItemType*: Determines the type of item in the tree view. The following values are possible:

    - *Empty*: Only the DisplayValue will be displayed for this item.

    - *CheckBox*: A check box will be shown next to the DisplayValue.

- *ChildItems*: List of TreeViewItems that are child items of this item.

Optionally, you can enable the WantsOnChange option for the tree view control, in which case it will send an update each time the selected state of a TreeViewItem changes.

To retrieve the results:

- The UIResult, which can be returned using *engine.ShowUI()*, contains the KeyValue of the selected items.

- The GetString(UIBlockDefinition *destvar*) method to retrieve a semicolon-separated string of the KeyValues.

- The GetChecked(UIBlockDefinition *destvar*, KeyValue *value*) method can be used to check if a specific KeyValue was selected.

Example:

```txt
{
   UIBuilder uib = new UIBuilder();
   uib.Title = "Treeview - default";
   uib.RequireResponse = true;
   uib.RowDefs = "*,*";
   uib.ColumnDefs = "*";

   UIBlockDefinition tree = new UIBlockDefinition();
   tree.Type = UIBlockType.TreeView;
   tree.Row = 0;
   tree.Column = 0;
   tree.DestVar = "treevar";
   tree.TreeViewItems = new List<TreeViewItem>
   {
      new TreeViewItem("Core Teams", "1", new List<TreeViewItem>
      {
         new TreeViewItem("Team A", "1/1", new List<TreeViewItem>
         {
            new TreeViewItem("Brian", "1/1/1", true) { ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("John", "1/1/2"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("Kevin", "1/1/3", true){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("David", "1/1/4"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("Joe", "1/1/5", true){ ItemType = TreeViewItem.TreeViewItemType.CheckBox }
         }){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
         new TreeViewItem("Team B", "1/2", new List<TreeViewItem>
         {
            new TreeViewItem("Jane", "1/2/1"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("Sarah", "1/2/2"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("Emily", "1/2/3"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("Anne", "1/2/4"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
            new TreeViewItem("Florence", "1/2/5"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox }
         }) { ItemType = TreeViewItem.TreeViewItemType.CheckBox }
      }){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
      new TreeViewItem("Team C", "2") { ItemType = TreeViewItem.TreeViewItemType.CheckBox }
   };
   uib.AppendBlock(tree);

   UIBlockDefinition next = new UIBlockDefinition();
   next.Type = UIBlockType.Button;
   next.Row = 1;
   next.Column = 0;
   next.Text = "Next";
   next.DestVar = "Next";
   uib.AppendBlock(next);

   _treeResults = _engine.ShowUI(uib);
} while (!_treeResults.WasButtonPressed("Next"));

ShowResult();
```

#### Interactive Automation scripts: Support for datetime values in ISO 8601 format \[ID_27565\]

The UIResults.GetDateTime method now also supports datetime values in ISO 8601 format.

Up to now, only datetime values in “dd/MM/yyyy HH:mm:ss” were supported.

#### Interactive Automation scripts: TreeViewItem now has an “IsCollapsed” property \[ID_27567\]

Each TreeViewItem in a TreeView component now has an “IsCollapsed” property.

This will allow clients to determine the initial state of each TreeViewItem when displaying a TreeView

### DMS Maps

#### Open Street Maps can now be accessed offline \[ID_25928\]

It is now possible to access Open Street Maps offline when, in the server configuration file, you set AppVersion to “1” and MapsProvider to “OSM”.

See the following example of a ServerConfig.xml file.

```xml
<MapsServerConfig>
  <VirtualHosts>
    <VirtualHost hostname="*">
      <AppVersion>1</AppVersion>
      <MapsProvider>OSM</MapsProvider>
      <TilesServer>
        <BaseLayers>
          <BaseLayer key="..." name="..." url="..."/>
          <BaseLayer key="..." name="..." url="..."/>
          <BaseLayer key="..." name="..." url="..."/>
        </BaseLayers>
      </TilesServer>
      <GoogleMaps key="..."/>
      <MapQuest key="..."/>
      <OWM key="..."/>
    </VirtualHost>
  </VirtualHosts>
</MapsServerConfig>
```

Custom base layers can be defined in TilesServer.BaseLayers.BaseLayer tags. Those have the following attributes:

| Attribute | Description                                                                                               |
|-----------|-----------------------------------------------------------------------------------------------------------|
| key       | Key used to refer to a base layer acting as default map (in the MapType tag of a map configuration file). |
| name      | The name of the base layer that will be displayed in the base map selection box.                          |
| url       | The URL of the layer tiles exposed by the offline maps server.                                            |

### DMS EPM

#### DataMiner Cube: Term “CPE” replaced by “EPM” \[ID_24568\]

In DataMiner Cube, the term “CPE” (Customer Premises Equipment) has been replaced by “EPM” (Experience and Performance Management).

#### Discreet parameters now supported in EPM search chains \[ID_25862\]

When a filter in an EPM search chain refers to a column parameter of type discreet, the filter will be displayed as a drop-down box rather than a text box.

If the filter is used for multiple tables, it will be displayed as a drop-down box as soon as one of the columns represents a discreet parameter.

When multiple columns have different discreet values, all these values will be displayed as long as they have a unique value and display string.

> [!NOTE]
> Dynamic discreet parameters are currently not supported.

#### CPECollectorHelper API: Timeout parameters can now be configured in the SLNetClientTest tool \[ID_26247\]

When a call is performed via the CPECollectorHelper API, a timeout is calculated based on the amount of requested items using the following formula:

*Total Timeout = ((requested number of items / EPMBulkCount) + 1) \* EPMASyncTimeout*

In the SLNetClientTest tool, it is now possible to configure the following parameters:

| Parameter       | Description                                                                                |
|-----------------|--------------------------------------------------------------------------------------------|
| EPMAsyncTimeout | The base value for a timeout when the CPECollector contacts another DataMiner Agent.       |
| EPMBulkCount    | The maximum number of items that can be requested in bulk before the timeout is increased. |

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).

#### DataMiner Cube: Long selection box content in EPM filters will automatically wrap to the next line \[ID_27660\]

From now on, long selection box content in EPM filters will automatically wrap to the next line.

### DMS Web Services

#### Web Services API v1 - New and updated methods to manage job data \[ID_26006\]

In the Web Services API v1, the job management methods have all been modified to support job domains.

**Changes to classes**

The DMAJobDomain class, which now extends from the newly added DMAJobDomainLite class, contains a new SectionDefinitions property. That property will contain an array of DMASectionDefinitions that are linked to the JobDomain.

> [!NOTE]
> - Configuration has been marked obsolete. All client information will be available in the Info property of each SectionDefinition.
> - In DMASectionDefinitionInfo, the CustomSectionDefinitionExtensionID property has been marked obsolete.

**Methods to manage job domains**

- CreateJobsDomain(string connection, string name)

    Creates a job domain with a unique name, containing a default section definition. If the job domain was created successfully, the ID of the created job domain will be returned.

- GetJobsDomains(string connection)

    Retrieves all available job domains and sorts them naturally by name. Returns an array of JobDomainLite objects.

- GetJobsDomain(string connection, string domainID)

    Retrieves a job domain by ID. If no ID is provided, then the first domain found will be returned. Also, the method will migrate the client information in the user’s VisualData to JobDomain.VisualStructure.

- UpdateJobsDomain(string connection, string id, string name)

    Updates a job domain. If the job domain was updated successfully, the ID of the updated job domain will be returned.

- DeleteJobsDomain(string connection, string id)

    Deletes a job domain. If the job domain was deleted successfully, the method will return TRUE.

- UpdateDomainSectionDefinitionConfiguration(string connection, string domainID, DMASectionDomainConfig\[\] configuration)

    This method, which was formerly named SaveJobsSectionDomainConfig, updates all client information of each section definition in JobDomain.VisualStructure.

**Methods to manage job section definitions**

- CreateJobsSectionDefinition(string connection, string domainID, string name, DMABookingLink bookingLinkInfo, DMASectionDefinitionInfo info)

    This method, which now includes a domain ID, now creates a section definition in the specified domain. If the section definition was created successfully, the section definition ID will be returned.

- GetJobsSectionDefinitions(string connection)

    Retrieves all section definitions.

    > [!NOTE]
    > This method will only work as long as there is only one domain. As soon as there are multiple domains, the method will return an error indicating that you should use the new GetJobsSectionDefinitionsV2 method instead (see below).

- GetJobsSectionDefinitionsV2(string connection, string domainID)

    Retrieves all section definitions from the specified domain and parses them using the client information in the VisualStructure of the domain in question.

- GetJobsSectionDefinition(string connection)

    Retrieves a specific section definition.

    > [!NOTE]
    > This method will only work as long as there is only one domain. As soon as there are multiple domains, the method will return an error indicating that you should use the new GetJobsSectionDefinitionV2 method instead (see below).

- GetJobsSectionDefinitionV2(string connection, string domainID. string sectionDefinitionID)

    Retrieves a specific section definition from the specified domain and parses it using the client information in the VisualStructure of the domain in question.

- UpdateJobsSectionDefinition(string connection, string domainID, string sectionDefinitionID, string name, DMABookingLink bookingLinkInfo, DMASectionDefinitionInfo info)

    This method, which now includes a domain ID, now updates the specified section definition in the specified domain. If the section definition was updated successfully, the section definition ID will be returned.

- DeleteJobsSectionDefinition(string connection string sectionDefinitionID)

    > [!NOTE]
    > This method is no longer supported. It will return an error indicating that you should use the new DeleteJobsSectionDefinitionFromDomain method instead (see below).

- DeleteJobsSectionDefinitionFromDomain(string connection, string domainID, string sectionDefinitionID)

    Removes the specified section definition from the specified domain and the client information for that domain from the VisualStructure.

    > [!NOTE]
    > This method does not physically delete a section definition. It only removes the link between the section definition and the job domain.

- UnhideJobsSectionDefinition(string connection, string domainID, string sectionDefinitionID)

    Unhides the specified section definition of the specified domain.

- UpdateSectionDefinitionFieldOrder(string connection, string domainID, string sectionDefinitionID, string\[\] fieldOrder)

    Updates the field order in the specified section definition of the specified domain.

**Methods to manage job section definition fields**

- AddOrUpdateJobsSectionDefinitionField(string connection, string domainID, string sectionDefinitionID, DMASectionDefinitionField field, DMAJobFieldPossibleValueUpdate\[\] possibleValueUpdates)

    Adds or updates a section definition field in the specified section definition of the specified domain.

- DeleteJobsSectionDefinitionField(string connection, string sectionDefinitionID, string fieldID)

    Removes a section definition field from the specified section definition of the specified domain.

- UnhideJobSectionDefinitionField(string connection, string domainID, string sectionDefinitionID, string fieldID)

    Unhides the specified section definition field in the specified section definition of the specified domain.

**Methods to manage jobs**

- DeleteJobs(string connection, string domainID, string\[\] jobIDs)

    Deletes the specified jobs and returns an DMARemoveInfo object containing an array with all successful and failed removals.

**Methods to manage job templates**

- GetJobTemplates(string connection)

    Retrieves all job templates.

    > [!NOTE]
    > This method will only work as long as there is only one domain. As soon as there are multiple domains, the method will return an error indicating that you should use the new GetJobTemplatesV2 method instead (see below).

- GetJobTemplatesV2(string connection, string domainID)

    Retrieves all job templates for the specified domain.

#### Web Services API v1: DMASpectrumBuffer object now contains VariableID property instead of Name property \[ID_27092\]

In the web services API, the web method *GetSpectrumBuffersByMonitorId* will now return *DMASpectrumBuffer* results containing a *VariableID* property instead of a *Name* property.

#### Web Services API v1: New GetServicesForFilter method \[ID_27412\]

In the web services API v1, the new method *GetServicesForFilter* is now available. It can be used to retrieve a list of services matching a property filter.

### DMS Mobile apps

#### Jobs app: Filtering on auto-increment fields \[ID_24047\]\[ID_24857\]\[ID_25057\]

Up to now, a job’s auto-increment field was of type Long and could not be used to filter on. Now, that field will be of type String, containing an ID with a prefix and a suffix. As a result, it will now be possible to filter on it.

> [!NOTE]
> This change requires all existing job data to be converted. This data will automatically be converted the first time you start a DataMiner Agent after upgrading it. However, note that this means that data may be lost if you downgrade to earlier DataMiner versions.

#### Ticketing app: Move to Elasticsearch database and other improvements \[ID_24667\]\[ID_25539\] \[ID_25713\]\[ID_26644\]\[ID_26676\]\[ID_26677\]\[ID_26911\]\[ID_26982\]\[ID_27974\]\[ID_28016\]\[ID_28043\] \[ID_28079\]\[ID_28153\]

Multiple changes and improvements have been implemented to the Ticketing app. The most important change is that the app will now use the Elasticsearch database instead of the Cassandra database.

When you install DataMiner 10.0.13 and you already use an Elasticsearch database, all ticketing data will be migrated automatically. If you do not have an Elasticsearch database and you have installed DataMiner 10.0.13, the ticketing data will be migrated automatically as soon as you add an Elasticsearch database to you DataMiner System. However, until you do so, you will no longer be able to use the Ticketing app. A run-time error in the Alarm Console will indicate that Ticketing Manager could not be initialized because there is no Elasticsearch database.

When you interact with the Ticketing Manager in scripts, keep the following changes in mind:

- A ticket now has a *UID* property of type GUID, which is always unique and which replaces the *TicketID* object. This object was used with the Cassandra database and consisted of a DataMiner ID and ticket ID. However, in Elasticsearch, the DataMiner ID is no longer needed. While tickets will still have a unique ticket ID, new implementations should make use of the *UID* instead.

- A new *TicketingHelper* is available that should be used to read, create, update and delete tickets, ticket field resolvers and ticket history in scripts. The existing *TicketingGatewayHelper* remains backwards compatible, but should not be used for new implementations or to update existing code. Below you can find an example of how to use this helper:

    ```txt
    public void Run(Engine engine)
    {
        // Create the helper
        var helper = new TicketingHelper(engine.SendSLNetMessages);

        // helper.[OBJECT TYPE].[ACTION]
        // helper.Tickets.Update();
        // helper.TicketFieldResolvers.Delete();
        // helper.TicketHistories.Read();

        // Create a TicketFieldResolver
        var ticketFieldResolver = TicketFieldResolver.Factory.CreateDefaultResolver();
        var createdResolver = helper.TicketFieldResolvers.Create(ticketFieldResolver);

        // Create a Ticket
        var newTicket = new Ticket()
        {
            CustomFieldResolverID =  createdResolver.ID
        };
        var createdTicket = helper.Tickets.Create(newTicket);

        // Read the TicketHistory
        var historyFilter = TicketHistoryExposers.UniqueID.Equal(createdTicket.UID);
        var history = helper.TicketHistories.Read(historyFilter);

        // Read all Tickets linked to a TicketFieldResolver
        var ticketFilter = TicketingExposers.ResolverID.Equal(createdTicket.CustomFieldResolverID);
        var tickets = helper.Tickets.Read(ticketFilter);

        // Delete Tickets
        foreach (var ticket in tickets)
        {
            helper.Tickets.Delete(ticket);
        }

        // Check if the last Ticket request failed
        var traceData = helper.Tickets.GetTraceDataLastCall();
        if (!traceData.HasSucceeded())
        {
            engine.GenerateInformation($"Previous action failed! {traceData}");
        }
    }
    ```

- To check if a request was successful, you can now retrieve the *TraceData* using the *GetTraceDataLastCall()* method on the *CrudComponentHelper* type used for the request. This returns the TraceData object, which can contain TicketingManagerError objects, each containing a reason for the error and extra data on what caused it. These are the possible errors:

    - *TicketFieldResolverInUseByTickets*: The ticket field resolver still has tickets linked to it. (The property *RelatedTickets* contains the IDs of the tickets.)

    - *NotInitialized*: The Ticketing Manager is not initialized.

    - *LegacyError*: A legacy error has occurred. (The property *LegacyErrorMessage* contains the error message.)

    - *TicketLinkedToNonExistingTicketFieldResolver*: The created/updated ticket has a link to a ticket field resolver that does not exist. (The property *TicketFieldResolverId* contains the ID of that ticket field resolver.)

    -  *TicketFieldResolverIsUnknownOrNotMasked*: The ticket field resolver is unknown or not masked.

    - *UnexpectedException*: An unexpected exception occurred. (The property *Exception* contains the exception.)

    - *TicketLinkedToMaskedTicketFieldResolver*: The created/updated ticket has a link to a ticket field resolver that is masked. (The property *TicketFieldResolverId* contains the ID of that ticket field resolver.

    Calling *ToString()* on the *TraceData* object will return a formatted string that shows all errors and associated data.

- When paging is started using *TicketingGatewayHelper.NewPagingRequest()*, the out parameter will no longer return the total number of tickets.

- When an invalid page size or page number is used in a request, an empty list will now be returned, while previously the ticketing helper returned all tickets matching the filter.

- Subscribing to *TicketingGatewayEventMessage* will no longer return an initial bulk. Instead tickets and ticket field resolvers should be retrieved via paging with the new *TicketingHelper*.

- Previously, when the Cassandra database was used, all open tickets were stored in the cache as well as the database. It was therefore possible to use the *CacheOnly* boolean in requests to retrieve only open tickets. This cache is no longer used, so using the *CacheOnly* boolean will no longer work when you use *NewPagedTicketsWithFilterMessage*. To resolve this, concatenate the filter with an open tickets filter, which you can retrieve using the new method *GetTicketStateFilter(TicketState ticketState)*. An exception was made for the *GetTickets* method of the existing *TicketingGatewayHelper*, which will still only return the open tickets.

- "Null" values of ticket fields will no longer be saved or returned.

- The open state of a ticket can no longer be linked to the state of an alarm.

- If *GenericEnumEntry\<int>* is used in *VisualData* on a* TicketFieldResolver*, this will now always be returned as a long integer instead of an integer.

- If the ticket field resolver defines a state *TicketFieldDescriptor*, tickets must now always contain a field indicating their state. When tickets are initially migrated to Elasticsearch, a state will automatically be defined for any tickets where this was not yet the case.

The following changes have been implemented in the web services API v1:

- The *DMATicket*, *DMATicketSelection* and *DMATicketUpdate* objects have a new *UID* property which contains the new GUID identifier of a ticket.

- The *PageSessionID* and *TotalTicketsCount* properties of the *DMATicketsPage* object are now obsolete.

- The *DMATicketsPage* object now has a new *HasNextPage* property, which indicates if there is another page after the currently requested page.

- The new methods *GetTicketV2*, *RemoveTicketV2*, *GetActiveTicketsV2* and *GetHistoryTicketsV2* are now available, to be used instead of *GetTicket*, *RemoveTicket*, *GetActiveTickets* and *GetHistoryTickets*.

Finally, the following changes have also been implemented:

- To include tickets in a custom backup, the backup option *Create a backup of the database* > *Include Ticketing in backup* must be selected.

- When you embed the Ticketing app in another page, you can now add *embed=true* to its URL in order to hide the side bar and header bar of the app.

- You can now add a filter in the Ticketing URL to only show tickets affecting a specific element, service, view or redundancy groups. To do so, add a filter in the following format: *affecting=**\[type\]**/**\[DataMiner ID\]**/**\[object ID\]*, where \[type\] can be *element*, *service*, *view* or *redundancy group*. For example: *affecting=element/299/31*

- When you view or edit a ticket in the app, the URL has now changed; while previously, it contained the DMA ID and ticket ID, it now contains the ticket UID. If you use an old URL, the Ticketing app will automatically try to adjust this to the new URL.

- The default page size for the ticket list in the Ticketing app has been increased to 50.

- Instead of AngularJS, the Ticketing app now uses Angular.

- The log file SLTicketingGateway.txt has now been replaced by SLTicketingManager.txt.

    > [!NOTE]
    > The Ticketing Gateway entry in the Cube Logging app now refers to the new file.

#### Jobs app: New methods to manage job attachments \[ID_24791\]\[ID_25961\]

The *JobManagerHelper* has been expanded with new methods that can be used to manage attachments to jobs:

- *AddJobAttachment(JobID **jobID**, string **fileName**,byte\[\] **fileBytes**)*: Adds an attachment to the specified job.

- *GetJobAttachmentFileNames(JobID **jobID**)*: Retrieves the names of the attachments of the specified job.

- *DeleteJobAttachment(JobID **jobID**, string **attachmentName**)*: Deletes the attachment with the specified name from the specified job.

- *GetJobAttachment(JobID **jobID**, string **attachmentName**)*: Retrieves the content of the specified attachment of the specified job as an array of bytes.

Please note the following regarding job attachments:

- The size limit of job attachments depends on the *Documents.MaxSize* setting in the file* MaintenanceSettings.xml*. By default, this is set to 20 MB.

- Deleting a job will remove all attachments of this job from the system. These cannot be recovered afterwards.

- Managing job attachments requires the *Jobs \> UI available* and *Jobs \> Add/Edit* user permissions.

- Job attachments are backed up with the backup option *All documented located on this DMA*.

- Job attachments are synced in a cluster.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Jobs app: Format of auto-increment fields can now be changed even when those fields are being used in existing jobs \[ID_24917\]\[ID_24973\]

From now on, it is allowed to change the format of auto-increment fields even when those fields are being used in existing jobs. However, you will receive a notice, saying that existing jobs will keep using the old format.

#### Monitoring app: Spectrum Analyzer elements now have a Spectrum Analyzer page \[ID_24925\] \[ID_25028\]\[ID_25059\]

In the Monitoring app, Spectrum Analyzer elements now have a spectrum page that shows the spectrum trace, using a new monitor with the last preset.

The following tabs are available:

| Tab         | Content                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
|-------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Information | Shows basic information regarding measurement points, markers, thresholds and parameters.                                                                                                                                                                                                                                                                                                                                                                                                    |
| Traces      | Allows you to display or hide the current trace, the minimum trace, the maximum trace and the average trace.                                                                                                                                                                                                                                                                                                                                                                                 |
| Presets     | Lists the available presets.<br> By default, only the private presets are listed (i.e. the presets that are only available to the current user). To also have the shared presets listed, select the *Show shared presets* option. Those will be indicated with a *Shared* tag.<br> When you select a preset, below the list, a *Load preset* button will allow you to load the selected preset. |

#### Monitoring app: Alarm history now also available \[ID_25002\]

In the Monitoring app, alarm history is now also available.

#### Ticketing app: Selection box values can now be assigned a color \[ID_25175\]

The VisualizationHints on the TicketFieldResolver can now store colors for every value listed in a selection box.

These colors can be specified by using the following property:

- TicketFieldResolver#VisualizationHints#VisualFieldEnums (of type List\<VisualFieldEnum>)

For every color linked to a selection box value, a VisualFieldEnum object should be added with the following properties:

| Property  | Description                                                          |
|-----------|----------------------------------------------------------------------|
| FieldName | The name of the selection box (i.e. enum field).                     |
| EnumValue | The selection box value (i.e. the discreet value in the enum field). |
| Color     | The color associated with the selection box value.                   |

#### On mobile devices, the sidebar will now appear at the bottom of the screen \[ID_25225\]

When using a mobile app (Monitoring, Dashboards, Jobs, etc.) on a mobile device, the sidebar, which on a desktop device appears by default on the left-hand side of the screen, will now appear at the bottom of the screen.

#### User picture in top-right corner \[ID_25257\]

The mobile apps (Monitoring, Dashboards, Jobs, etc.) will now show a picture of the user in the top-right corner. If no picture is available, then the user’s initials will be shown instead.

#### Monitoring app: On mobile devices, a redesigned footer will now group all card controls \[ID_25267\]

When using the Monitoring app on a mobile device, all card controls will now be grouped on a redesigned footer.

#### Web applications updated to Microsoft .NET Framework 4.6.2 \[ID_25422\]

Web applications (Web Services API, legacy dashboards, Maps, etc.) have been updated to Microsoft .NET Framework 4.6.2.

#### Jobs app: Job domains \[ID_25889\]\[ID_26428\]\[ID_26813\]\[ID_26814\]\[ID_27025\]\[ID_26844\]

In the Jobs app, it is now possible to have different job domains, each with their own set of job section descriptions.

- If, in the top-left corner of the jobs list, you select a job domain from the list, the jobs list will be filtered and will list only the jobs associated with the selected job domain.

- In configuration mode, you can select the job domain in the top-left corner of the screen, and then configure the job sections within the selected domain. The *New*, *Edit*, *Duplicate* and *Delete* buttons on the right of the job domain selection box allow you to add a new domain, edit the selected domain (change its name and/or hide it), duplicate a domain or delete the selected domain.

**Duplicating job domains**

Clicking the *Duplicate* button will allow you to select one of the following options:

| Option                           | Function                                                                                                                                                                                                                                                                                                                                                                                       |
|----------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Share sections<br>across domains | Creates a new domain that shares its sections with the original domain.<br> Note: Changes made to the sections of the new domain will also be applied to the sections of the original domain (except changes made to the *Color*, *Icon* and *Allow multiple instances* properties of a section). |
| Create copies of<br>the sections | Creates a new domain by duplicating the entire original domain, including its sections.<br> Note: Changes made to the sections of the new domain will not be applied to the sections of the original domain.                                                                                                                                                                                   |

When the duplication operation has finished, you will automatically be redirected to the newly created domain.

As a result of the above-mentioned changes, adding a new section to a domain has also been changed. The *Add section definition* window now has a *New* tab and an *Existing* tab.

| Tab      | Function                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
|----------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| New      | Use this tab if you want to create a new section from scratch.                                                                                                                                                                                                                                                                                                                                                                                                                 |
| Existing | Use this tab if you want to add an existing section to the domain in question. In this case, apart from having to select the section to be added, you will also have to indicate whether you want to<br> -  share the section with the other domain(s) containing that section, or<br> -  make a separate copy of the section (with a new name). |

**New web methods to be used when duplicating job domains**

- **DuplicateJobsDomain(string connection, DMAJobDomain domain, string domainID, bool byRef)**

    This method will duplicate a job domain, either by reference or by hard copy, and return the ID of the new job domain if the duplication operation was successful.

    - If the *byRef* parameter is set to false, the method will create an entire new job domain that is in no way linked to the original job domain.

    - If the *byRef* parameter is set to true, the method will create a new job domain that shares its sections with the original job domain.

- **DuplicateJobsSectionDefinition(string connection, string domainID, string sourceDomainID, DMASectionDefinition sectionDefinition, bool byRef)**

    This method will duplicate a job section definition, either by reference or by hard copy.

    - If the *byRef* parameter is set to false, the method will add an entire new job section definition to the job domain specified by *domainID*. This job section definition will no way be linked to the original job section definition in the domain specified by *sourceDomainID*.

    - If the *byRef* parameter is set to true, the method will link the existing job section definition specified by *sectionDefinition* to the job domain specified by *domainID*. This same job section definition will then be shared between the two job domains.

- **GetAffectedJobDomains(string connection, string sectionDefinitionID)**

    This method will return the names of all the job domains that contain the job section definition specified by *sectionDefinitionID*.

> [!NOTE]
> - When you upgrade from a DataMiner system without job domains, all existing job section definitions will be stored in a job domain named “DefaultJobDomain”. If necessary, you can rename this default job domain.
> - When you delete a job section definition, a dialog box is displayed allowing you to choose whether to delete it completely, or only sever the link between the section definition and the domain.
> - When a job domain is deleted, all its section definitions are removed as well, unless these are linked to other domains as well.

#### Interactive Automation scripts: UI components now have a TooltipText property \[ID_25609\] \[ID_25978\]

UI components in interactive Automation scripts launched from a mobile app can now have a tool tip configured by means of the UIBlockDefinition class property “TooltipText”.

#### Jobs app: Enhanced job section configuration \[ID_25977\]

In the Jobs app, job section configuration has been enhanced.

When you add a new job section (by clicking a black or purple dot) or edit an existing job section (by clicking the edit button in the section’s header), a pop-up window will now appear, allowing you to enter or modify the properties of that section.

#### Jobs app: Tracking the history of job field values \[ID_26016\]

All changes made to job field values will now be logged by means of HistoryChange records, stored in Indexing Engine (index “chistory-job”).

A HistoryChange record associated with a job field value change will contain SectionChange objects and FieldValueChange objects.

A SectionChange object has the following properties:

| Field             | Description                                                                                    |
|-------------------|------------------------------------------------------------------------------------------------|
| SectionID         | The ID of the section in which fields were created, updated or deleted.                        |
| FieldValueChanges | A list of FieldValueChange objects (one for every field that was created, updated or deleted). |

A FieldValueChange object has the following properties:

| Field             | Description                                                                              |
|-------------------|------------------------------------------------------------------------------------------|
| FieldDescriptorID | The ID of the FieldDescriptor.                                                           |
| CrudType          | The type of change, indicating whether the field was added, updated or deleted.          |
| ValueBefore       | The value before the change.<br> When CrudType is “Created”, this property will be Null. |
| ValueAfter        | The value after the change.<br> When CrudType is “Deleted”, this property will be Null.  |

> [!NOTE]
> - If, for some reason, tracking changes to jobs would fail, an error will be logged in SLHistoryManager.txt each time a HistoryChange record could not be saved. To prevent users from receiving too many notices, a notice will only be generated every hour.
> - When a job is deleted, all HistoryChange records associated with this job will also be deleted, and a new HistoryChange record will be added to indicate when the job was deleted and by whom.

#### Enhanced visualization of disabled text boxes \[ID_26193\]

Disabled text boxes in e.g. interactive Automation scripts will now automatically be optimized as to size and will have a scrollbar when needed.

#### Visual Overview: HTML5 table controls can now have a filter box \[ID_26228\]\[ID_26235\]

Similar to Cube, visual overviews in HTML5 apps now also support table controls that include a filter box. In other words, when a parameter control shape with a table and a filter box defined in child shapes is passed to an HTML5 app, that shape will be rendered in the same way as it is rendered in Cube.

The child shapes (filter box and table) will have their coordinates defined relative to the parent shape.

- The filter box will contain an additional ExtraData item named VisualOverviewFilterBoxData with an optional CustomTextBoxInfo property.

- The table will contain an additional ExtraData item named VisualOverviewTableData.

If a table has been defined without a filter box, the parameter control will be passed to the HTML app without child regions.

#### User menu now has a “Sign out” command \[ID_26254\]

In all mobile apps (Monitoring, Dashboards, Jobs, etc.), the user menu in the top-right corner of the screen now has a “Sign out” command.

#### Monitoring & Dashboards apps: Number groups in numeric parameter values will now be sepa­rated by a thin space \[ID_26394\]

In the Monitoring app and the Dashboards app, three-digit number groups in numeric parameter values will now by default be separated by a thin space. This will make large numbers more legible.

#### HTML5 apps: Sidebar settings will now be stored per user account in the browser’s local storage \[ID_26719\]

For each of the HTML5 apps (Monitoring, Jobs, etc.), the size and expand/collapse state of the sidebar will now be stored per user account in the browser’s local storage.

#### Jobs app: History pane \[ID_27113\]

When you are viewing a job, you can now open a *History* pane on the right. That pane will list all changes made to that particular job. At the bottom of the pane, you will also find the time at which the job was created and the time at which it was last edited.

Also, the following web method has been made available to retrieve the change history of a particular job:

- GetJobsHistory(string connection, string jobID)

#### Monitoring & Dashboards apps: Enhancements made with regard to shared spectrum analysis functionality \[ID_27378\]

In both the Monitoring app and the Dashboards apps, a number of performance improvements have been made with regard to shared spectrum analysis functionality.

Also, the following spectrum preset display settings will now be applied:

- Background color

- Grid line color

- Text color (axis labels and timestamp label)

- Show/hide axis labels

- Show/hide grid

#### Monitoring app: Visualizing view properties in the Surveyor \[ID_27411\]

Similar to DataMiner Cube, the Monitoring app now also allows you to visualize view properties in the Surveyor.

#### Loading screen of embedded apps will now show a loading indicator instead of the app icon \[ID_27594\]

The loading screen of all mobile apps (Monitoring, Dashboards, Jobs, etc.) will now show a loading indicator instead of the app icon when opened in embedded mode (i.e. using a URL that contains either the embed=true or embedded=true argument).

#### HTML5 apps: Loading indicator of selection boxes will now be displayed on the right \[ID_27871\]

When values are being loaded into a selection box, from now on, the loading indicator will be displayed on the right instead of on the left.

#### Jobs app & Ticketing app: Column widths can now be saved \[ID_28254\]

When, in the Jobs app or the Ticketing app, you change the widths of the columns in the jobs list or the ticket list, those widths will now be saved per domain in the user settings.

#### Jobs app: Jobs will now be retrieved via web sockets \[ID_28285\]

In the Jobs app, jobs will now be retrieved via web sockets.

As a result, all updates and deletions will now be received automatically.

### DMS Service & Resource Management

#### Service profiles \[ID_24552\]

Up to now, when users wanted to configure a service reservation, they each time had to select profiles for every node and interface of the service definition. From now on, when configuring a service reservation, users will in most cases only have to select a single predefined service profile. That profile will then automatically configure most of the nodes and interfaces necessary for the service reservation in question.

> [!NOTE]
> - You can define a single service profile for a series of almost identical service definitions.
> - Service profile logging is stored in SLProfileManager.txt.
> - To make sure service profile data is included in DataMiner backup packages, select *Profile Manager objects and configuration* when configuring backups in System Center.

#### Improvements ResourceManagerHelper class for deletion of resources \[ID_24002\]\[ID_24563\]

If there is an error deleting resources using the *ResourceManagerHelper* class, additional feedback is now returned:

- If one or more resources are deleted using the *ResourceManagerHelper* class, and at least one of the resources fails to be deleted, a single error, *ResourceDeleteFailed*, is returned, which now contains a *UsingIDs* property with all the IDs of the resources that failed. Any possible other resources are still successfully deleted.

- If a resource is deleted that is in use or in maintenance mode, the error *ResourceDeleteInUseOrMaintenanceMode* is returned. If the resource is included in scheduled, ongoing or quarantined bookings, the IDs of these bookings are now returned in the *FutureOrOngoingReservationIds* property.

If a resource that is used in past bookings is deleted, the deletion now fails by default, returning the error *ResourceDeleteInUseOrMaintenanceMode* with the boolean property *HasPastBookings* set to true.

In addition, the following new method is now available in the *ResourceManagerHelper* class: <br>*Resource\[\] RemoveResources(Resource\[\] resources, bool ignorePastReservations);*

If *ignorePastReservations* is false, this method works in the same way as existing calls to remove resources. If it is set to true, past bookings will be ignored during the deletion checks. This can be used to delete resources that are only used in past bookings; however, note that these bookings may then contain invalid references to resources.

#### Mediation snippets \[ID_24610\]

Mediation snippets are pieces of code that will convert a parameter value from the format defined in a protocol to the format defined in a profile parameter (and vice versa).

MediationSnippet objects, defined on profile parameter level, consist of an ID and a string containing the actual snippet code (C#). They can be managed by means of the ProfileManagerHelper#MediationSnippets API.

To a particular profile parameter, you can add only one mediation snippet per protocol version. In other words, linking to both parameter 10 and parameter 20 in version 1.0.0.0 of Protocol X in the same profile parameter is not allowed. However, it is possible to specify a single wildcard character at the end of a protocol version (e.g. “1.0.0.\*”). When there are multiple matches, the most specific entry will be chosen (i.e. “1.0.0.\*” will take precedence over “1.\*”).

> [!NOTE]
> - Inside a snippet, it is possible to
>     - mediate multiple device parameters to a single profile parameter, and
>     - mediate a single profile parameter to multiple device parameters.
> - When a mediation snippet is updated or deleted, all DataMiner Agents in the DMS will unload that snippet. In case of a snippet update, the next mediation request will trigger a re-load of the updated version.
> - When an attempt is made to delete a mediation snippet used by a profile parameter, a MediationSnippetError will be thrown (with reason ExistingProfileParameters).
> - When a profile parameter is deleted, all the mediation snippets linked to that profile parameter will also be deleted.
> - When a profile parameter is updated, all the mediation snippets that got unlinked due to that update will be deleted.

To use a mediation snippet, you can send one of the following requests:

- MediateDeviceToProfileRequest (with response MediateDeviceToProfileResponse)

- MediateProfileToDeviceRequest (with response MediateProfileToDeviceResponse)

Both requests require the profile parameter ID, the element ID and the parameter value to be passed along, and will return either the mediated value(s) or a MediationError (which will also be logged in SLProfileManager.txt).

> [!NOTE]
> - Using mediation snippets requires a ServiceManager license and requires Indexing Engine to be installed.
> - In Indexing Engine, all mediation snippets are stored under the “cmediationsnippet” index. The compiled snippets are stored in C:\\Skyline DataMiner\\MediationSnippets\\Compiled.
>     - All DLL files are deleted from this folder when the DataMiner Agent starts up.
>     - Snippets are compiled per DataMiner Agent. Snippet DLLs are not synchronized among the agents in a DMS.
> - If you want the mediation snippets to be included in DataMiner backups, make sure to select the “Include the ProfileManager in backup” option.

#### Exporting and importing profile parameters \[ID_24641\]

It is now possible to export and import profile parameters to and from a file.

The following methods have been added to the ProfileManagerHelper:

**export(IEnumerable\<Guid> ids)**

This method returns an object of type “ProfileParameterExportResult”, which contains the bytes of the export file. These bytes can then be saved to a file. To view the contents of that file, first unzip it.

When you export profile parameters to a file, the following exceptions can be thrown:

| Exception                         | Description                                                                                                            |
|-----------------------------------|------------------------------------------------------------------------------------------------------------------------|
| ProfileParameterNotFoundException | The ID of one of the profile parameters that was passed to the method could not be found.                              |
| MediationSnippetNotFoundException | One of the profile parameters that was passed to the method has a link to a mediation snippet that could not be found. |

**import(byte\[\] file)**

This method returns an object of type “ProfileParameterImportResult”, which contains the imported profile parameters and mediation snippets.

When you import profile parameters from a file, the following exceptions can be thrown:

| Exception                        | Description                                                                    |
|----------------------------------|--------------------------------------------------------------------------------|
| InvalidDataException             | The file to be imported does not have the correct format.                      |
| InvalidProfileParameterException | One of the profile parameters to be imported does not have the correct format. |
| InvalidMediationSnippetException | One of the mediation snippets to be imported does not have the correct format. |

> [!NOTE]
> - If you export a profile parameter, all the mediation snippets linked to that parameter will also be exported.
> - When you import profile parameters and their mediation snippets, all existing profile parameters and mediation snippets with the same ID will be overwritten.

#### Mediated virtual functions \[ID_24657\]\[ID_25046\]\[ID_25193\]\[ID_25271\]\[ID_25401\]\[ID_25651\]<br>\[ID_26078\]

Server-side support has been added for mediated virtual functions.

To configure mediated virtual functions, do the following:

1. For every parameter, every column and/or every cell you want to see in the virtual function element, create a profile parameter.

2. If, in the virtual function element, the value of a profile parameter should be transformed, then add a mediation snippet to that profile parameter.

3. Create a profile definition for the node of the function and a profile definition for every interface of the function.

    - In a profile definition, you can group profile parameters in tables if you want them to be shown as tables in the virtual function element.

4. Create a virtual function definition. In it, you can define the following:

    - The profile definition for the node.

    - The amount and type of interfaces and their profile definition.

    - The protocols supported. For every supported protocol, the following can to be defined:

        | Items           | Description                                                                               |
        |-------------------|-------------------------------------------------------------------------------------------|
        | Entry-point table | The (optional) table that holds the multiple instances of a function in a single element. |
        | Interface filters | The (optional) additional table filters that have to be used for the interface tables.    |

    Next to that, you can also define how the virtual protocol should look like:

    - Define the pages you want to see in the protocol.

    - Define which profile parameters from the profile definitions of the node/interfaces should be on each page.

    - Define which tables from the profile definitions of the node/interfaces should be on each page.

    When you save the virtual function definition, a virtual function protocol is generated (with type “virtual-function”) and the metadata associated with that protocol is stored in an automatically created “virtual function protocol meta” object. That object will contain the following information:

    - The IDs of the read/write parameters that were generated for the different profile parameters and nodes/interfaces.

    - The tables that were generated.

    - Profile parameter information (type, ...)

    This protocol metadata will be used:

    - to resolve IDs of generated parameters when binding a resource

    - to be able to re-use parameter IDs when a new version of the protocol is generated

    - to validate the new versions of the generated protocol

5. Create a virtual function resource with a specific virtual function definition.

    The virtual function element with automatically be created using the generated virtual function protocol.

6. Bind the virtual element to an element by updating the virtual resource:

    - Specify the element ID.

    - Specify the entry point table index (if an entry point table was defined).

    All the parameters and tables of the virtual function element, which were set to “not-initialized/empty”, will now be set to the replicated/mediated values of the bound element.

**Virtual function definitions**

Virtual function definitions can be used on service definition nodes. They can be managed by means of the ProtocolFunctionHelper.VirtualFunctionDefinitions API.

Virtual function definitions are stored in Indexing Engine under the cvirtualfunctiondefinition index. When you create a database backup, they will automatically be included in the package when the *Include SRM in backup* option is enabled.

All logging with regard to virtual function definitions will be added to SLFunctionManager.txt.

**Virtual function protocol metadata**

Virtual function protocol metadata is stored in Indexing Engine under the cvirtualfunctionprotocolmeta index. When you create a database backup, this metadata will automatically be included in the package when the *Include SRM in backup* option is enabled.

**Virtual function resources**

A virtual function resource is an extension of a normal resource. It has the following additional properties:

| Property                | Content                                                                                                                             |
|-------------------------|-------------------------------------------------------------------------------------------------------------------------------------|
| VirtualFunctionID       | The ID of the VirtualFunctionDefinition of which it is an instance.                                                                 |
| PhysicalDeviceDmaId     | The ID of the element that is currently bound to the VirtualFunctionElement.                                                        |
| PhysicalDeviceElementId |                                                                                                                                     |
| ElementName             | The name of the VirtualFunctionElement that will be created.<br> If none is specified, then the resource name will be used instead. |

Virtual function resources can be used on ReservationInstances and ServiceReservation-Instances, and can be managed by means of the ResourceManagerHelper API. They are saved in Resources.xml.

All logging with regard to virtual function resources will be added to SLResourceManager.txt.

**Logging with regard to element binding**

Logging with regard to element binding will be added to the following log files:

- SLResourceManager.txt can contain information about errors that occurred during the element orchestration or during binding/unbinding operations.

- SLFunctionManager.txt can contain information about errors that occurred during binding/unbinding operations. If the resource update request was sent from another agent than the one hosting the virtual function element, then the log file of the hosting agent might contain the error. You might also have to check SLDataMiner.txt.

- SLProfileManager.txt can contain information about errors that occurred during the mediation step of the parameter replication.

- The log file of the virtual function element can contain information about errors that occurred during binding, unbinding or replication operations in general.

#### OnStartActionsFailureEvent will now be executed when the start actions of a ReservationIn­stance fail \[ID_24790\]

From now on, an OnStartActionsFailureEvent will be executed when the start actions of a ReservationInstance fail.

If you want to use this event to trigger an Automation script, then make sure to add a custom entry point method to that script. See the example below.

```txt
[AutomationEntryPoint(AutomationEntryPointType.Types.OnSrmStartActionsFailure)]
public void OnSrmStartActionsFailure(Engine engine, List<StartActionsFailureErrorData> errorData)
{
}
```

A StartActionsFailureErrorData instance contains an ErrorReason, which explains what went wrong with the start actions. These are the possible error reasons:

| ErrorReason                 | Description                                                                                                                                                                                                                       |
|-----------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ResourceElementNotActive    | The element linked to the resource was not active when the booking was started.<br> Note: The resource (as well as the element ID) can be retrieved from the Resource property. The ReservationInstanceId will also be filled in. |
| ReservationInstanceNotFound | The ReservationInstance could not be retrieved when the start actions were launched.                                                                                                                                              |
| UnexpectedException         | An exception was thrown while executing the start actions.<br> Note: This exception can be retrieved from the Exception property. The ReservationInstanceId is available in the ErrorData object.                                 |

**Assigning an Automation script to the OnStartActionsFailureEvent**

The following example shows how to assign an Automation script to the OnStartActionsFailureEvent.

```txt
reservationInstance.OnStartActionsFailureEvent = new ReservationEvent("OnStartActionsFailureEvent", $"Script:StartActionsFailedScript");
```

Although the event name can be chosen randomly, it should be a meaningful name, as it can appear in log entries.

Notes:

- From now on, the elements linked to the resource must be active when the booking is started.

- The start actions will only be started after the ResourceManager has tried to activate the function resources.

- A notice will be generated when the start actions fail and no OnStartActionsFailureEvent was configured. See the following example:

    ```txt
    The start actions for the ReservationInstance 'c3c6df39-bf28-4860-b426-a6dcb2d2306f - RT_SRM_OnStartActionsFailureEvent_08_59_20' have failed, but no OnStartActionsFailure event was configured.
    ```

- A notice will be generated when the start actions fail and no OnStartActionsFailureEvent script has been configured. See the following example:

    ```txt
    The script Script:THIS_SCRIPT_DOES_NOT_EXIST_d03c6ec0-3274-4d01-8b28-e4d12459520d could not be correctly parsed to an existing automation script. The event OnStartActionsFailureEvent of reservation '4ce12a06-55f4-4c7c-a746-7874b23ecd8d - RT_SRM_OnStartActionsFailureEvent_08_59_00' will not be executed.
    ```

#### Tracking the history of ReservationInstances \[ID_25006\]

All changes made to ReservationInstances will now be logged by means of HistoryChange records, stored in Indexing Engine (index “chistory-reservationinstance”).

A HistoryChange records contains the following fields:

| Field        | Description                                                                                                                          |
|--------------|--------------------------------------------------------------------------------------------------------------------------------------|
| ID           | ID of the HistoryChange record.                                                                                                      |
| SubjectId    | ID of the ReservationInstance that was changed.                                                                                      |
| Time         | Time at which the change was made.                                                                                                   |
| FullUsername | Full user name of the person who made the change.<br> If the change was triggered by the DataMiner system, this will be “DataMiner”. |
| DmaId        | ID of the DataMiner Agent on which the change was triggered.                                                                         |
| Changes      | List of changes that were made. In case of a ReservationInstance, this can be a resource usage change or a status change.            |

> [!NOTE]
> - If, for some reason, tracking changes to ReservationInstances would fail, an error will be logged in SLHistoryManager.txt each time a HistoryChange record could not be saved. To prevent users from receiving too many notices, a notice will only be generated every hour.
> - When a backup is configured to include the Service & Resource Management module, this will also include the chistory-reservationinstance table.
> - When a ReservationInstance is deleted, all HistoryChange records associated with this ReservationInstance will also be deleted, and a new HistoryChange record will be added to indicate when the ReservationInstance was deleted and by whom.
> - When a ReservationInstance is deleted, all HistoryChange records associated with this ReservationInstance will also be deleted.

#### Linking an ID of a contributing resource to a ServiceReservationInstance \[ID_25186\]

It is now possible to link an ID of a contributing resource to a ServiceReservationInstance.

#### Support for capabilities of type string and for time-dynamic capabilities \[ID_25217\]

Service & Resource Management now supports

- capabilities of type string, and

- time-dependent capabilities.

**Capabilities of type string**

It is now possible to define capabilities of type string:

- The CapabilityParameterValue class has a new property named “ProvidedString”. This can be used to define a string capability on a resource.

- The ResourceCapabilityUsage class has a new property named “RequiredString”. This can be used to define a string capability on a ReservationInstance.

- The CapabilityUsageParameterValue class has a new property named “RequiredString”. This can be used to define default capability values of type string for profile parameters and capability values of type string on profile instance parameters.

> [!NOTE]
> From now on, three types of capabilities can be defined: discreet, rangepoint and string. Up to now, when the value provided/required was a number, a rangepoint capability was used, and if it was not a number, a discreet capability was used. String capabilities will now be used when the value provided/required for a rangepoint capability is not a number and the value provided/required for a discreet capability is NULL or an empty string.

**Time-dynamic capabilities**

Time-dynamic capabilities are capabilities of which the value can differ over time, depending on the reservations that are using the capability. Currently, only capabilities of type string can be turned into time-dynamic capabilities (by setting their “IsTimeDynamic” property to true).

As a time-dynamic capability will be treated as a string capability that can have any value, the CapabilityParameterValue property “ProvidedString” will be disregarded.

When a time-dynamic capability is booked by a ReservationInstance that requires a specific value, the Resource capability will keep that value for the entire duration of the ReservationInstance. This means that overlapping ReservationInstances will be able to use the same time-dynamic capability on the same resource, as long as they require the same string capability.

> [!NOTE]
> - It is not possible to schedule multiple overlapping ReservationInstances using the same time-dynamic capability on the same resource with a different required string. This would cause quarantine conflicts. When you try to save a ReservationInstance that conflicts with existing ReservationInstances, the software will resolve the conflict by comparing the quarantine priority of all existing ReservationInstances to the one of the ReservationInstance you are trying to save. If the quarantine priority of the ReservationInstance you are trying to save is higher than that of all existing ones, then all existing ones will go into quarantine. Otherwise, the new ReservationInstance will go into quarantine.
> - Whether a capability is time-dynamic is defined on resource level.

**New ResourceManagerHelper methods**

In the context of time-dynamic capabilities, two new methods have been added to the ResourceManagerHelper:

- GetEligibleResourcesWithUsageInfo

- GetEligibleResourcesForServiceNodeWithUsageInfo

These methods correspond with GetEligibleResources and GetEligibleResourcesForService-Node, but the return value of the new methods contains information about the currently booked usage of each eligible Resource, along with all eligible Resources.

This usage info currently only contains information about the already booked capabilities for each resource. For each capability requested in the call, the usage info will contain a “CapabilityUsageDetails” property, which contains a “HasExistingBookings” property indicating whether the capability of that resource is:

- Not time-dynamic (which means the resource has the requested capability regardless of the time range the booking is in).

    In this case, “HasExistingBookings” will be NULL.

- Time-dynamic (without a booking in the requested time range).

    In this case, “HasExistingBookings” will be false.

- Time-dynamic (with a booking in the requested time range).

    In this case, “HasExistingBookings” will be true.

> [!NOTE]
> The GetEligibleResources and GetEligibleResourcesForServiceNode methods will continue to work correctly, but they will only return the eligible Resources without the extra information.

#### Service & Resource Management: New EmptyResourceInReservation property for Reservation­Instance/ServiceReservationInstance \[ID_25220\]

In Service & Resource Management scripts, you can now configure nodes on a reservation instance while the resource is not known yet, by using the new *EmptyResourceInReservation* property.

#### Tracking the rebinding history of VirtualFunctionResources \[ID_25307\]

The rebinding history of VirtualFunctionResources will now be logged by means of HistoryChange records, stored in Indexing Engine (index “chistory-resource”).

A HistoryChange records contains the following fields:

| Field        | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
|--------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ID           | ID of the HistoryChange record.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
| SubjectId    | ID of the VirtualFunctionResource that was changed.                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| Time         | Time at which the change was made.                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| FullUsername | Full user name of the person who made the change.<br> If the change was triggered by the DataMiner system, this will be “DataMiner”.                                                                                                                                                                                                                                                                                                                                                                           |
| DmaId        | ID of the DataMiner Agent on which the change was triggered.                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| Changes      | List of changes that were made. In case of a VirtualFunctionResource, this can be a RebindChange containing the following information about the binding:<br> -  BindBefore (the element ID before the rebind)<br> -  BindAfter (the element ID after the rebind)<br> -  the type of change (Create/Update/Delete) |

Using the HistoryHelper#Resources API you can read all the history objects for resources. See the following example:

```txt
ResourceID myResourceID = …
var query =HistoryChangeExposers.SubjectID.Equal(someResourceID.ToFileFriendlyString()).OrderBy(HistoryChangeExposers.Time);
```

> [!NOTE]
> - If, for some reason, tracking changes to VirtualFunctionResources would fail, an error will be logged in SLHistoryManager.txt each time a HistoryChange record could not be saved. To prevent users from receiving too many notices, a notice will only be generated every hour.
> - When a backup is configured to include the Service & Resource Management module, this will also include the chistory-resource table.
> - When a VirtualFunctionResource is deleted, all HistoryChange records associated with this VirtualFunctionResource will also be deleted.

#### Profile data can now also be stored in Indexing Engine \[ID_25515\]\[ID_25758\]\[ID_26081\]

From now on, the following profile data can be stored either in XML format on the DataMiner Agents (default) or in Indexing Engine:

- ProfileDefinitions

- ProfileInstances

- ProfileParameters

#### Missing interfaces on the parent function will now automatically be added when generating a contributing function \[ID_25587\]

When a contributing function had to be generated, up to now, it was assumed the given collection of interfaces to expose would match the interfaces on the parent system function. In fact, any interfaces on the parent system function that do not have a matching interface on the underlying service definition of the contributing function can simply be omitted from the request.

The software will therefore automatically create the interfaces on the contributing function and link them to a parameter group on the contributing protocol. The parameter group in the protocol will not contain any parameters and the name of the interface will be that of the matching interface in the system function definition (or “DefaultInterfaceName” if the interface in the parent system function does not have a name).

#### A profile assignment mode can now be configured on service definition nodes and on the resource usages of a ServiceReservationInstance \[ID_25616\]

Up to now, a profile assignment mode could already be configured on the capacity and capability usages of a ServiceReservationInstance. Now, a profile assignment mode can also be configured on service definition nodes and on the resource usages of a ServiceReservationInstance. For that purpose, a “ByProfileInstanceReference” property has now been added to the ObjectConfiguration class.

#### The full capacity will now always be quarantined when a capacity with a reference string must be quarantined \[ID_25637\]

When a capacity with a reference string has to be quarantined, from now on, the full capacity will always be quarantined.

#### New notice will now appear when a DMA that is not using Indexing Engine has an IDP license but no ServiceManager license \[ID_25762\]

The following notice will now appear when a DataMiner Agent that is not using Indexing Engine has an IDP license but no ServiceManager license:

```txt
DataMiner IDP is licensed, but no Elasticsearch database is active on the system. Therefore, scheduled workflows are not available.
```

This same notice will also be added to the ResourceManager log file.

#### GetEligibleResources: New ResourceFilter and RequiredCapabilitiesOrFiltered arguments \[ID_25786\]

The GetEligibleResources call has been extended with two new arguments:

| Argument                       | Description                                                                                                                                                                                                                |
|--------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ResourceFilter                 | New (optional) argument to filter the eligible resources.<br> Resources that do not match the specified filter will not be returned as eligible resource.                                                                  |
| RequiredCapabilitiesOrFiltered | Apart from the RequiredCapabilities argument, which can be used to specify an “AND” list of capabilities, this new (optional) RequiredCapabilitiesOrFiltered argument can be used to specify an “OR” list of capabilities. |

> [!NOTE]
> The following new API call has been added to the ResourceManager-Helper:
> - public EligibleResourceResult GetEligibleResources(EligibleResourceContext context)
>
> This new call allows you to combine all existing and new parameters of the GetEligibleResources calls. The legacy GetEligibleResources and GetEligibleResourceForServiceNodeWithUsageInfo calls will now link to this new call.

#### LockLifeCycle property added to ServiceReservationInstance objects \[ID_26635\]

ServiceReservationInstance objects now have a LockLifeCycle property, which can be set to either “Unlocked” (default) or “Locked”.

- When this property is set to “Unlocked”, the ServiceReservationInstance will behave like a normal ServiceReservationInstance.

- When this property is set to “Locked”, an additional check will be performed during the Concurrency License check.

> [!NOTE]
> When checking whether the concurrency limit set in the DataMiner License has been reached, a booking will not be taken into account when
> - it is a ServiceReservationInstance,
> - the ContributingResourceID is filled in,
> - the Contributing Resource exists, and
> - the Contributing Resource is used in an overlapping booking.
>
> A booking that is not taken into account when checking the concurrency limit will not be taken into account for the entire duration of the booking, even if the overlapping booking (see above) has already ended.

#### Possibility to add attachments to booking instances \[ID_26784\]

To support adding attachments to booking instances (i.e. ReservationInstance objects), a new ReservationInstanceAttachments property is now available in the ResourceManagerHelper. This property allows you to manage booking attachments using the following methods:

| Method                                                                                | Function                                                                         |
|---------------------------------------------------------------------------------------|----------------------------------------------------------------------------------|
| Add(ReservationInstanceID reservationInstanceID, string fileName, byte\[\] fileBytes) | Add an attachment to a booking                                                   |
| List\<string> GetFileNames(ReservationInstanceID reservationInstanceID)               | Retrieve the names of all the attachments added to the specified booking.        |
| Delete(ReservationInstanceID reservationInstanceID, string attachmentName)            | Deletes the attachment with the specified name from the specified booking.       |
| byte\[\] Get(ReservationInstanceID reservationInstanceID, string attachmentName)      | Retrieves the content of the attachment with the specified name as a byte array. |

> [!NOTE]
> - If a booking is deleted, all its attachments will be deleted as well. They will not be recoverable.
> - The maximum size of booking attachments is determined by the Documents.MaxSize setting, located in the MaintenanceSettings.xml file. Default: 20 Mb. Trying to upload a larger file will result in a DataMinerException.
> - Manipulating booking attachments requires security permissions on the ReservationInstance. If a SecurityViewId is specified, the view permission on the view is required to retrieve or download attachments, and the write permission on the view is required to add or delete attachments.
> - All booking attachments are synchronized throughout the DataMiner System. To include them in a backup, select the “All documents located on this DMA” backup option.

#### Element of a virtual function resource will now be updated when the resource changes \[ID_27043\]

Up to now, when a VirtualFunctionResource object was updated, in some cases, the virtual function element would not be updated corrected. When, for example, the VirtualFunctionDefinitionID of a VirtualFunctionResource was changed, in some cases, the element would not be set to use the protocol of the new virtual function definition, even when the resource update was successful.

From now on, the following resource updates will be taken into account:

- When the name of the resource is updated, the name of the element will also be updated.

- When the virtual function definition of the resource is updated, the protocol of the element will also be updated.

> [!NOTE]
> When the virtual function definition of a resource is updated while it is bound, the binding must still be valid after the update. Otherwise, the update will be blocked.
>
> It is possible to change both the binding and the virtual function definition in a single update by simultaneously updating the VirtualFunctionDefinitionID, the PhysicalDeviceDmaID and the PhysicalDeviceElementID.

#### Binding between a VirtualFunctionResource and a physical device element will now automati­cally be updated when the protocol of the device element changes \[ID_27466\]

When a virtual function resource is bound to a physical device element, that binding will now automatically be updated when the protocol of the physical device element changes.

- When the updated protocol of the physical device element is no longer supported by the VirtualFunctionDefinition of the resource, the resource will automatically become unbound and a notice will be generated for all such resources, stating that the new protocol no longer supports the binding.

- When the updated protocol of the physical device element is still supported by the VirtualFunctionDefinition but now uses an entry point table, the resource will be unbound as the row in the entry point table that needs to be bound to is unknown.

- When the updated protocol of the physical device element is still supported but no longer uses an entry point table, the resource will be unbound as the protocol used to support multiple resources binding and now only supports one resource binding.

- When the protocol of the physical device element is changed to a different protocol, which is also supported by the VirtualFunctionDefinition used by the resource and which uses the same binding method (entry point table or not), the resource binding will automatically be updated.

#### New helper method: GetEligibleResources \[ID_27609\]

The ResourceManagerHelper now contains a new method that allows you to simultaneously execute multiple eligible resource queries.

```txt
/// <summary>
/// Returns the eligible resources for all given contexts. A result can be matched
/// with its context by matching the <see cref="EligibleResourceResult.ForContextId"/>
/// property on the <see cref="EligibleResourceResult"/> with the
/// <see cref="EligibleResourceContext.ContextId"/> of the
/// <see cref="EligibleResourceContext"/>.
/// </summary>
/// <exception cref="ArgumentNullException"><paramref name="contexts"/> is null
/// </exception>
/// <exception cref="ArgumentException"><paramref name="contexts"/> is empty
/// </exception>
/// <param name="contexts">The contexts to calculate the resources for</param>
/// <returns>
/// The result with additional info for all requested contexts that were valid.
/// If one or more contexts were invalid the results for the valid contexts are still
/// returned
/// </returns>
public List<EligibleResourceResult> GetEligibleResources(List<EligibleResourceContext> contexts)
{
    if (contexts == null)
        throw new ArgumentNullException(nameof(contexts));
    if(contexts.Count == 0)
        throw new ArgumentException("At least one context should be provided", nameof(contexts));
    var reqMsg = new GetEligibleResourcesMessage(contexts);
    return InnerGetEligibleResources(reqMsg)?.MultipleResults;
}
```

Also, a number of minor changes were done to make sure that the EligibleResourceResults can be matched to the requested contexts:

- An EligibleResourceContext now has a ContextId, which will automatically be filled in by any constructor.

- When the GetEligibleResources method returns a ReservationInstanceNotFound error or a ServiceNodeResourceUsageNotFound error, the error data will now have an additional  EligibleResourceContextId property. This will allow you to pinpoint any context will faulty data.

### DMS Spectrum Analysis

#### DataMiner Cube - Spectrum Analysis: Button to apply all settings at once \[ID_25242\]

On a spectrum analyzer element card, an "Apply all" button is now available in the settings pane, so that you can configure several settings and then apply them all at the same time.

#### DataMiner Cube - Spectrum Analysis: Y axis of spectrum graph will no longer show values with 3 decimals if the reference level is shown in dBm and no decimal accuracy is being used \[ID_25250\]

If the reference level is shown in dBm and no decimal accuracy is being used, from now on, the Y axis of a spectrum graph will no longer show values with 3 decimals.

#### DataMiner Cube - Spectrum Analysis: A preset will now also include the decimals to be used when displaying DBm values in spectrum graphs \[ID_25871\]

When you save a spectrum preset, from now on, that preset will also include the amount of decimals to be used when displaying DBm values on the Y axis of a spectrum graph.

### DMS tools

#### SLLogCollector: New tool to collect log files and memory dumps and send them to Skyline sup­port \[ID_25346\]\[ID_25631\]

From now on, the SLLogCollector tool will be available on all DataMiner Agents.

In case of problems, Skyline support may ask you to use this tool to compress the necessary log files and memory dumps into a zip file, which you can then store in a folder on the DataMiner Agent or upload to Skyline.

On the DataMiner Agent, the tool itself can be found at the following location:

- C:\\Skyline DataMiner\\Tools\\SLLogCollector\\SL_LogCollector.exe

When you launch the tool, the following options will be selected by default:

- Include memory dump (when run-time errors have been found on the system)

- Save to SLLogCollector folder on desktop

#### SLReset: Factory reset tool \[ID_26026\]\[ID_26408\]\[ID_27227\]

SLReset.exe is a new tool that can be used to fully reset a DataMiner Agent to its state immediately after installation. It is located in the C:\\Skyline DataMiner\\Files\\ folder.

**Optional argument**

| Argument | Description                                                         |
|----------|---------------------------------------------------------------------|
| -y       | Skip any prompts that ask you whether to run online/offline actions |

**Online actions (i.e. actions that are only run when the DMA being reset is running)**

- ResetFailoverOnline

    Deletes the Failover configuration of the DMA if one is present.

- ResetClusterOnline

    Removes the DMA from the DMS if it is part of one.

**Offline actions (i.e. actions that are always run whether or not the DMA being reset is running)**

- StopTaskbarUtility

- StopDataMiner

- UndoIISConfig

- UndoFirewallConfig

- Unregister

- UninstallEndpoints

- DeleteTaskbarAppSettings

- FileCleanup

    > [!NOTE]
    > Deletes any unnecessary files in the C:\\Skyline DataMiner\\ folder.
    >
    > This action uses a whitelist to determine what to keep.
    >
    > On first execution, the default whitelist is added to the C:\\Skyline DataMiner\\Files\\ResetConfig.txt file. Subsequent executions will then check the whitelist found in that text file, to which you can add any file you want to keep.
    >
    > If you delete ResetConfig.txt, SLReset will again use the default whitelist.

- ResetDataMinerXml

- ResetNotifyMail

- ResetDoNotRemoveFiles

- ResetSLNetExeConfig

- ResetProtocolsIconXml

- ResetReportTemplatesXml

- ResetWebpagesWebConfigs

- DeleteExecutableEvents

- DBReset

    > [!NOTE]
    > This action runs the SLDataGateway.Tools.Database.exe located in the C:\\Skyline DataMiner\\Files\\x64\\ folder, and uses the input arguments harvested from DataMiner (DB.xml, credentials,...).
    >
    > For more information on SLDataGateway.Tools.Database.exe, see below.

- Register

- DcomConfig

- ConfigureServices

- FirewallConfig

- IISConfig

- StartSLTaskbarUtility

- StartDataMiner

**SLDataGateway.Tools.Database.exe**

This tool, when run with the factory-reset argument, resets the currently active MySQL, Cassandra or ElasticSearch database(s). When running this tool, you can specify the following arguments:

| Argument      |                         | Mandatory | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
|---------------|-------------------------|-----------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| factory-reset |                         | X         | Argument specifying that a factory reset must be done.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| -t            | --database-type \<type> | X         | Type of database:<br> -  SQL (i.e. MySQL)<br> -  Cassandra<br> -  Elastic (i.e. ElasticSearch)                                                                                                                                                                                                                                                                                                         |
| -i            | --ip \<ip>              | X         | IP address of the database host                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| -u            | --username \<username>  |           | User account (user name and password)<br> If no account is specified, the following default credentials will be used:<br> -  MySQL: root (empty password)<br> -  Cassandra: root/root<br> -  ElasticSearch: no security                                                                                                                                                                                |
| -p            | --password \<password>  |           |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| -f            | --forced                |           | Skip all prompts.<br> If this argument is not used, the user will be asked for a final confirmation.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
| -d            | --Database \<keyspace>  |           | Database/keyspace to be cleaned.<br> If this argument is not used, everything will be cleaned.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| -k            | --keepcustomcredentials |           | Preserve the specified Cassandra credentials (user and password) throughout the factory reset process                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| -l            |                         |           | Log level:<br> -  0 = Off<br> -  1 = Trace (default)<br> -  2 = Debug<br> -  3 = Info<br> -  4 = Warning<br> -  5 = Error<br> -  6 = Fatal |
| --timeout     |                         |           | Timeout (milliseconds)<br> If execution takes longer than the specified timeout, the program is killed.<br> Default: int.MaxValue (\~2 billion)                                                                                                                                                                                                                                                                                                                                                                                                                                                     |

> [!NOTE]
> - When you perform a factory reset, no backup of the DataMiner Agent will be taken.
> - SLReset must be run with administrative privileges.

#### SLNetClientTest tool: Generating SMIv2 MIB files \[ID_26320\]

In the SLNetClientTest tool, you can now generate SMIv2 MIB files for SNMP managers of type SNMPv2 and SNMPv3.

To do so, go to *Advanced \> Tests \> Generate MIB for SNMP Manager*, select an SNMP manager and click *Generate*.

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).

#### DMS Alerter: New “Set the alarm as read in Cube after the alarm has been acknowledged” set­ting \[ID_26579\]

When, in DMS Alerter, the new *Set the alarm as read in Cube after the alarm has been acknowledged* setting is enabled, each time you acknowledge an alarm in DMS Alerter, that same alarm will automatically be marked as “read” in DataMiner Cube.

> [!NOTE]
> This feature will only work if one and the same user is running both DMS Alerter and DataMiner Cube on the same client machine.

#### DMS Alerter: New “Hide the comment window when acknowledging an alarm” setting \[ID_26621\]

A new setting, *Hide the comment window when acknowledging an alarm*, is available in the Alerter app. If this setting is enabled, you can take ownership of an alarm in an Alerter pop-up balloon without having to add a comment.

#### StandaloneElasticBackup tool \[ID_27683\]

The StandaloneElasticBackup.exe tool allows you to back up and restore Elasticsearch database clusters.

**General syntax**

```txt
StandaloneElasticBackup.exe <action> <arguments>
```

**Actions**

This tool allows you to perform the following actions:

| Action  | Description                |
|---------|----------------------------|
| init    | Initialize a repository.   |
| backup  | Take a backup/snapshot.    |
| restore | Restore a backup/snapshot. |

Example:

```txt
StandaloneElasticBackup.exe backup --host 127.0.0.1 -u elastic --pw mypw123 -r reponame
```

**General arguments**

| Option     |     | Description                                                                                                                 |
|------------|-----|-----------------------------------------------------------------------------------------------------------------------------|
| --host     | -h  | The host on which the command has to be run.<br> Default: 127.0.0.1                                                         |
| --port     | -p  | The port on which Elasticsearch will be contacted.<br> Default: 9200                                                        |
| --username | -u  | The credentials that have to used to connect to Elasticsearch.<br> Only use these options when credentials have to be used. |
| --pw       |     |                                                                                                                             |

**Arguments to add when you want to initialize the repository**

Run StandaloneElasticBackup.exe with the following two (mandatory) arguments to initialize the repository that should be made to take a snapshot.

| Option |     | Description                                                                                                                                                          |
|--------|-----|----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| --repo | -r  | The name of the repository to be created.                                                                                                                            |
| --path |     | The path of the repository as defined in the yaml.xml file of the Elasticsearch cluster, enclosed by “”.<br> This is the location where the snapshot will be placed. |

> [!NOTE]
> - Snapshots are incremental. Do not delete any of them.
> - See also: [https://www.elastic.co/guide/en/elasticsearch/reference/current/snapshots-register-repository.html](https://www.elastic.co/guide/en/elasticsearch/reference/current/snapshots-register-repository.html)

**Arguments to add when you want to take a backup/snapshot**

Run StandaloneElasticBackup.exe with the following two (mandatory) arguments to take a backup/snapshot.

| Option         |     | Description                                                                                                                                                                                                                                                                                                                                                                   |
|----------------|-----|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| --repo         | -r  | The repository in which to take the backup.<br> -  If none is defined and only one repository is found in the Elasticsearch cluster, then that one will be used.<br> -  If none is defined and none can be found, then no backup will be taken. |
| --snapshotname | -n  | The (lowercase) name of the snapshot to be taken.<br> Default: DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");                                                                                                                                                                                                                                                                  |

**Arguments to add when you want to restore a backup/snapshot**

Run StandaloneElasticBackup.exe with the following two (mandatory) arguments to restore a backup/snapshot.

| Option         |     | Description                                                                                                                                                                                                                                                                                                                                                                            |
|----------------|-----|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| --repo         | -r  | The repository containing the backup to be restored.<br> -  If none is defined and only one repository is found in the Elasticsearch cluster, then that one will be used.<br> -  If none is defined and none can be found, then an error will be thrown. |
| --snapshotname | -n  | The name of the snapshot to be restored.                                                                                                                                                                                                                                                                                                                                               |

> [!NOTE]
> - If, before restoring a backup, you notice that all data was deleted from the database, then re-initialize the repository.
> - It is advised to disable security when restoring a backup with security enabled. To do so, comment the security setting in the yaml file.

#### SLNetClientTest: Viewing and deleting trend data patterns \[ID_28098\]

In the SLNetClientTest program, it is now possible to view and delete trend data patterns.

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).

#### SLNetClientTest: Viewing and editing SLNet configuration options with regard to NATS \[ID_28683\]

In the SLNetClientTest program, it is now possible to view and edit the following SLNet configuration options with regard to NATS, which are stored in the MaintenanceSettings.xml file:

- NATSDisasterCheck

- NATSResetWindow

- NATSRestartTimeout

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).

## Changes

### Enhancements

#### Web Services API: An exception will now be returned when retrieving alarms while the alarm cache is not initialized yet \[ID_19927\]

Up to now, when a large amount of alarms were retrieved via the Web Services API while the IIS server alarm cache was not fully initialized yet, in some cases, an incomplete result set would be returned. From now on, an exception will be returned instead.

The HTML5 apps (e.g. Monitoring), which make use of the Web Services API, will in this case now also display an error message indicating the alarm cache status.

#### SLNet: Enhanced alarm sorting \[ID_22739\]

A number of enhancements have been made to the alarm sorting mechanisms in the SLNet process.

Current alarm levels (in order of increasing priority):

- Undefined

- Initial

- Suggestion

- Information

- Normal

- Masked

- Notice

- Warning

- Minor

- Major

- Critical

- Timeout

- Error

#### Improvements to Change Element States Offline tool \[ID_23833\]

Numerous improvements have been implemented to the Change Element States Offline tool:

- The overall layout of the tool has been improved.

- The state of elements is now added as a suffix to element names.

- A CSV and XML export option for element states is now available in the *File* menu.

- A new *Elements by Protocol* tab has been added, with a tree view showing elements by protocol and protocol version. Check boxes allow the quick selection of all elements in a node of the tree view.

- A search box has been added to make it easier to find elements in the *Elements by Name* and *Elements by Protocol* tabs. The wildcards "\*" (for any number of characters) and "?" (for exactly one character) can be used in this box. The element state can be included in the search

- The Ctrl+A key combination is now supported to select all elements.

#### Jobs app: Enhanced error handling when adding jobs \[ID_24238\]

Error handling when adding jobs has been enhanced.

#### Dashboards app: Updated design rotate button in button panel \[ID_24272\]

The design of the rotate button in a button panel component has been updated.

#### Smart-serial communication over IP: Receive time-out reduced from 100 ms to 15 ms \[ID_24282\]

In case of smart-serial communication over IP, the hard-coded time-out when receiving data has now been reduced from 100 ms to 15 ms.

#### DataMiner Cube - Stream Viewer: Buffer size increased to 1 MB \[ID_24330\]

The buffer size of Stream Viewer’s text box has increased from 32 kB to 1 MB.

#### Possibility to show information message in mobile apps + Dashboards app layout update \[ID_24336\]

In the Monitoring, Dashboards and Jobs apps, it is now possible to use the *ShowInformationMessage* method in a script to display a message in the app.

Note that a small change has also been implemented in the Dashboards app. The *New dashboard* button will no longer be displayed in the header bar. Creating a new dashboard remains possible via the context menu of the side panel and via the Dashboards homepage.

#### Jobs app: Timeline improvement \[ID_24352\]

In the Jobs app, the way items are displayed on the timeline has been improved:

- Items on the timeline now have a minimum width, so that they are displayed even if they have a very short duration.

- If items on the same height are very close to each other, they will be merged into one aggregated item.

- Clicking an item will now always select it. Clicking an aggregated item will select all the items it combines. To deselect an item, keep Ctrl pressed while you click it.

#### DataMiner Maps: Enhanced retrieval of marker alarm severities \[ID_24363\]

Due to a number of enhancements, overall performance has increased when retrieving marker alarm severities.

#### DataMiner Cube: Enhanced user picture icons in search results \[ID_24364\]\[ID_24573\]

A number of enhancements have been made to the user picture icons that appear in search results. Those icons will now also indicate whether a user is online, and when no user picture could be found, a default user icon will now be displayed instead.

Also, a user picture icon will now be displayed in the top-left corner of a user card.

#### SLAnalytics: Enhanced alarm template monitoring \[ID_24477\]

Due to a number of enhancements, overall performance of SLAnalytics has increased when monitoring alarm templates.

#### DataMiner Cube - Trending: Intermediary points added when exporting a trend graph as line graph \[ID_24580\]

If, when exporting trend data to CSV, you select the *Line graph instead of block graph* option, from now on, intermediary points will be added if no data is available at certain timestamps (which can happen when a value remained constant).

Depending on the step size of the data points, a point will be added at fixed intervals. Previously, points would only be added when a value changed.

#### DataMiner Analytics - Alarm focus: AlarmFocusEvents will no longer be cached by SLNet \[ID_24581\]

From now on, AlarmFocusEvents generated by SLAnalytics will no longer be cached by SLNet.

#### DataMiner Cube - Data Display: Matrices with more than 1000 inputs and outputs will no longer have an “Expand pages” button \[ID_24589\]

From now on, in order to prevent users from expanding large matrices, matrices with more than 1000 inputs and outputs will no longer have an “Expand pages” button.

#### Dashboards app: Changes to behavior table parameter subscriptions \[ID_24702\]

The following changes have been implemented to the behavior of table parameter subscriptions in the Dashboards app:

- When a column filter is specified, the client will only receive updates if the updated cell is part of a filtered column. This change also applies to the web API in general.

- In the drop-down, list and tree feeds, the indices will now be updated in real time if WebSockets are enabled. If WebSockets are not enabled, the indices will be fetched initially and then a message will be displayed to notify the user that WebSockets must be enabled in order to retrieve updates.

#### Jobs app: Fields marked “Show in list view” will now always be shown in the jobs list, even when those fields do not have values \[ID_24708\]

Fields that are marked “Show in list view” will now always be shown in the jobs list, even when none of the listed jobs have a value set in those fields.

#### DataMiner Analytics: Enhanced SLNet subscription management \[ID_24730\]

A number of enhancements have been made to the way in which DataMiner Analytics manages SLNet subscriptions.

#### Dashboards app: Enhanced “No data” error message in Line chart component \[ID_24737\]

Up to now, when no data could be displayed in a Line chart component, a general “No data” error message would be displayed. This general message has now been replaced by a more specific error message: “No data within the specified time range”.

#### HTML5 apps: Enhanced installation \[ID_24745\]

A number of enhancements have been made to the DataMiner HTML5 apps (e.g. Jobs, Dashboards, etc.). Users will now be able to install these apps much like they install other mobile apps.

#### DataMiner Analytics - Alarm focus: AlarmFocusEvents associated with alarms of elements that are paused or stopped will no longer be cleared \[ID_24750\]

From now on, events associated with alarms of elements that are paused or stopped will no longer be cleared.

#### DataMiner Cube - Services list: Only state change icons configured to perform a valid state change will be clickable \[ID_24753\]

When life cycle management is enabled, then the services list allows you to change the state of the service by clicking an icon. From now on, you will only be able to click icons that are configured to perform a valid state change.

#### Enhanced performance of NotifyDataMiner 128 (NT_UPDATE_PORTS_XML) \[ID_24777\]

Due to a number of enhancements, overall performance of NotifyDataMiner 128 (NT_UPDATE_PORTS_XML) has increased, especially when updating matrix data.

#### Monitoring app & Dashboards app: Parameter tables can now be displayed in full-screen mode \[ID_24789\]\[ID_24830\]

In the Monitoring app (DATA pages, VISUAL pages and CPE pages) and the Dashboards app (Parameter Page component), parameter tables can now be displayed in full-screen mode.

If your internet browser supports full-screen mode, a toggle button will appear in the top-right corner of each parameter table. You can exit full-screen mode by pressing ESC or F11.

#### Monitoring app: Enhanced performance when retrieving alarm information \[ID_24831\]

Due to a number of enhancements, overall performance of the Monitoring app has increased when retrieving alarm information.

#### Enhanced notification of DataMiner processes when a DMA leaves the DataMiner System \[ID_24906\]

Due to a number of enhancements, DataMiner processes will now get notified in a more uniform way when a DataMiner Agent leaves the DataMiner System. This will allow them to execute the necessary tasks when such an event occurs.

#### HTML5 apps: Enhancement date/time selector \[ID_24912\]

In all HTML5 apps (Monitoring, Dashboards, Ticketing, etc.), the date/time selector has been enhanced. It is now also possible to confirm the time by double-clicking the minutes.

#### Increased performance due to enhancements made to the locking behavior of the SLElement EPM cache \[ID_24916\]

Overall performance has increased due to a number of enhancements made to the locking behavior of the SLElement EPM cache.

#### DataMiner Cube - Alarm Console: Enhanced performance when displaying parameter heat lines \[ID_24928\]

Due to a number of enhancements, overall performance has increased when displaying parameter heat lines in the Alarm Console.

#### DataMiner Cube - Visual Overview: “Textblock” control now inherits text alignment of shape \[ID_24929\]

When you turned a shape into a text block control by adding a shape data item of type *Options* set to “Control=Textblock”, up to now, the text alignment of that control would by default be set to Left Center. From now on, “Textblock” controls will inherit the text alignment configuration of the shape.

#### DataMiner Analytics - Alarm focus: Enhanced likelihood calculation of alarms associated with elements that were paused or stopped \[ID_24931\]

A number of enhancements have been made to the alarm focus mechanism, especially with respect to the likelihood calculation of alarms associated with elements that were paused or stopped.

#### SLDataMiner will no longer try to send status updates to the Mobile Gateway if the latter has its location set to “\<none>” \[ID_24972\]

When the Mobile Gateway location was set to “\<none>”, up to now, SLDataMiner would incorrectly try to send status updates to the Mobile Gateway’s non-existing IP address 0.0.0.0.

From now on, when the Mobile Gateway location is set to “\<none>”, SLDataMiner will no longer try to send status updates to it. It will only add a line to the logs (with log level 0), indicating that no Mobile Gateway location has been specified.

> [!NOTE]
> From now on, when a user changes the cellphone location, an information event will be generated.

#### Indexing Engine: Enhanced mechanism to delete data using filters \[ID_24977\]

A number of enhancements have been made to the mechanism used to delete data from the Indexing Engine, especially when using large filters.

#### Mobile apps: Confirmation message when leaving page with interactive script or job configura­tion \[ID_25078\]

When a user leaves a DataMiner mobile app page while in an interactive Automation script or while configuring jobs, a confirmation message will now be displayed. However, note that this is message is not displayed when the mobile apps are used on iOS.

#### Reports & Dashboards: PDF library updated \[ID_25117\]

The third-party library used to generated PDFs in the legacy Reports & Dashboards app (Winnovative) has been updated to version 15.

#### DataMiner Cube - Trending: Enhanced accuracy of prediction data for history set parameters \[ID_25143\]

Due to a number of enhancements, the accuracy of prediction data for history set parameters has increased.

#### Spectrum Analysis: Improved spectrum graph axis labels \[ID_25161\]

To make spectrum graphs more easily readable, the unit of measure will now no longer be displayed in every label of the X- and Y-axis of a spectrum graph. Instead, it will only be displayed once at the end of each axis.

#### DataMiner Cube - Visual Overview: ListView component enhancements \[ID_25224\]

In a *ListView* component in Visual Overview that has been configured to display elements, the following columns are now available:

- Protocol

- Protocol Version

- Polling IP

- Element properties \> Created by

- Element properties \> Created at (i.e. creation date)

In addition, it is now also possible to configure a filter on the *ListView* shape using the term "Element.PollingIP", for example *Element.PollingIP == '127.0.0.1'*.

#### SLAnalytics: Logging will no longer contain “Unexpected number of responses returned while sending getInfoMessage” notices \[ID_25240\]

The SLAnalytics logging will no longer contain lines mentioning the following notice:

```txt
“Unexpected number of responses returned while sending getInfoMessage...”
```

#### Jobs app: Enhanced performance when viewing or editing a job \[ID_25292\]

Due to a number of enhancements, overall performance has increased when viewing or editing a job.

Also, a number of minor issues have been solved.

#### SLDataGateway: Enhanced retrieval of alarms from a MySQL database \[ID_25318\]

Due to a number of enhancements, the method used by the SLDataGateway process to retrieve alarms from a MySQL database has been optimized.

#### DataMiner Analytics - Alarm focus: timeOfArrival field added to AlarmFocusEvents \[ID_25343\]

AlarmFocusEvents now have a timeOfArrival field. In most cases, this field will be set to the time at which the corresponding AlarmEventMessage was received. However, in the following AlarmFocusEvents, it will be set to the current time:

- Hourly AlarmFocusEvents that update the focus value of active alarms.

- AlarmFocusEvents for old alarms that are resent after restarting an element.

- AlarmFocusEvents that are sent for active alarms on startup.

#### Default alarm bubble-up behavior in recursive tables changed from “recursive=none” to “recur­sive=up” \[ID_25349\]

The default alarm bubble-up behavior in recursive tables has been changed from “recursive=none” to “recursive=up”, i.e. from child nodes up to parent nodes (following the foreign key in the direction it is in).

#### DataMiner Installer now targets Microsoft .NET Framework 4.6.2 \[ID_25378\]

The DataMiner Installer now targets Microsoft .NET Framework 4.6.2.

#### Dashboards app: Pivot table supports mediation protocols \[ID_25491\]

The *Pivot table* dashboard component now supports mediation protocols.

#### Dashboards app: Service definition visualization will be updated when the service definition or the booking gets updated \[ID_25562\]

The service definition visualization will now be updated when the service definition or the booking gets updated.

> [!NOTE]
> When a booking gets deleted while the service definition instance of that booking is being displayed, an error will be shown.

#### SLAnalytics: Alarm focus enhancements \[ID_25591\]

From DataMiner 10.0.0/10.0.2 onwards, the DataMiner Analytics software assigns an estimated likelihood or “alarm focus score” to each alarm, after analyzing the short-term history and current behavior of incoming alarms in real time.

Due to a number of enhancements, overall performance of this alarm focus feature has now increased.

#### Indexing Engine: Default index replication factor now set to 2 \[ID_25606\]

From now on, new Indexing Engine installations will have their index replication factor set to 2 for all data objects except suggestions. For suggestions, the index replication factor will be set to 1.

#### Protocols - Serial clients: Enhanced locking behavior \[ID_25647\]

A number of enhancements have been made to the locking behavior of serial client elements.

#### Dashboards app: Enhanced rendering of scalable text \[ID_25671\]

Due to a number of enhancements, the rendering of scalable text in a number of dashboard components (e.g. digital clock, trend statistics, state visualizations) has been optimized.

#### DataMiner Cube - Visual Overview: \[profile:\] placeholder enhancements \[ID_25795\]

A number of performance enhancements have been made with regard to the \[profile:\] placeholder.

#### SLAnalytics - Behavioral anomaly detection: Enhanced performance when displaying icons on trend graphs \[ID_25798\]

Due to a number of enhancements, overall performance has increased when displaying icons on trend graphs to indicate behavioral anomalies.

#### SLPort logging enhancements \[ID_25806\]

A number of enhancements have been made to the SLPort logging.

#### Logs will now include Cassandra yaml file parsing errors \[ID_25809\]

From now on, Cassandra yaml file parsing errors will also be logged.

#### Cassandra 3.7 installer now uses AdoptOpenJDK 8u252 \[ID_25850\]

The Cassandra 3.7 installer now uses AdoptOpenJDK 8u252.

#### Alarm queuing enhancements to prevent alarms from getting stuck in the Alarm Console \[ID_25927\]

In some rare cases, alarms could get stuck in the Alarm Console. This has now been prevented by enhancing the alarm queuing mechanism.

#### SLAnalytics: Sending messages asynchronously has been optimized \[ID_25942\]

Due to a number of enhancements, sending messages asynchronously has been optimized.

#### Service & Resource Management: Enhancements with regard to quarantine-related messaging \[ID_25966\]

A number of enhancements have been made to the messages that appear when managing profile instances, especially with regard to quarantining.

#### Enhanced performance of Visio shapes linked to an EPM object but not to a view \[ID_25972\]

Due to a number of enhancements, overall performance of Visio shapes linked to EPM objects has increased, especially when they are not linked to a view.

#### Trend icons now determined based on trend window duration \[ID_26030\]

To improve the efficiency of the SLAnalytics process, it now determines the trend icon based on the trend window duration of the parameter.

#### Service & Resource Management: Optimized functions.xml generation \[ID_26060\]

The generation of functions.xml files has been optimized. Function names no longer have an “SRMFunction\_” prefix and the \<Graphical> tag of the parent function will now automatically be added to the generated functions.xml file.

#### Dashboards app: Enhanced performance of CPE feed component \[ID_26082\]

Due to a number of enhancements, overall performance of the CPE feed component has increased.

#### Jobs app: Time range validation when creating jobs \[ID_26166\]

From now on, due to a number of enhancements as to data validation, it will no longer be possible to create a job with an invalid time range.

#### Profiles app: Enhanced performance when loading \[ID_26197\]

Due to a number of enhancements, overall performance of the Profiles app has increased when loading, especially on systems with a large amount of profiles.

#### DataMiner Maps: Enhanced performance when retrieving EPM-related data \[ID_26216\]<br>\[ID_26233\]

Due to a number of enhancements, overall performance has increased when retrieving EPM-related data.

#### Dashboards: Column parameters with advanced naming supported for trend statistics visual­ization \[ID_26240\]

The *Trend statistics* visualization in the new Dashboards app now supports column parameters from tables that use advanced naming.

#### DataMiner Cube - Alarm Console: Reduced memory usage \[ID_26285\]

Due to a number of enhancements, overall memory usage of the Alarm Console has been reduced.

#### Dashboards app: Embedded Chromium web browser engine updated to v81 \[ID_26296\]

The embedded Chromium web browser engine has been updated to v81.

#### SLAnalytics: Enhanced logging \[ID_26335\]

A number of enhancements have been made to the SLAnalytics logging.

#### DataMiner Cube: Enhanced Back/Forward navigation \[ID_26457\]

Up to now, clicking the *Back* and *Forward* buttons would only make you jump from one card to another. From now on, also the navigation history within a card will be taken into account.

For example, when you drill down from a card page to a parameter, clicking *Back* will bring you back to that card page, and when you open the trend page of a table cell from within a Visio page, clicking *Back* will bring you back to that Visio page.

Also, when you hover over a *Back* or *Forward* button, a tool tip will now show the name of the card and the page that will be opened.

#### DataMiner Cube: Enhanced way of saving information about the last user who logged in \[ID_26483\]

When DataMiner Cube is shut down, it saves information about the last user who logged in. The formatting of that user data has now been enhanced.

#### Jobs app: Possible to update or delete values of drop-down fields in unused job sections \[ID_26503\]

From now on, if a job section is not being used by a job, it will be possible to update or delete values of drop-down fields in that section.

If you try to update or delete values of drop-down fields in sections that are being used, an error message will appear.

#### Applications using system files to be updated during a DataMiner upgrade will now forcefully be terminated \[ID_26505\]

When updating system files during a DataMiner upgrade, the SLReplace process will now forcefully terminate any application that is using the files to be updated.

#### Jobs app: Minor enhancements \[ID_26535\]

In the Jobs app, a number of minor enhancements have been made:

- Up to now, names of job templates had to be unique across the entire Jobs app. From now on, they only have to be unique within a specific domain.

- Up to now, when you changed the type of a job field that was being used in a job, in some cases, the value of the “Show in list view” option would incorrectly be changed. From now on, the value of this option will be left untouched.

#### Dashboards app - Line chart component: Loading indicator next to button to expand or collapse the trend graph legend \[ID_26557\]

Up to now, when data was being loaded into a line chart component, a loading indicator would replace the button to expand or collapse the legend. As a result, it was not possible to expand or collapse the legend while data was being loaded. From now on, when data is being loaded into a line chart component, a loading indicator will be displayed next to the button to expand or collapse the legend.

#### General security enhancements \[ID_26620\]

A number of enhancements have been made with regard to user permissions needed to retrieve or modify data on DataMiner Systems.

#### Dashboards app: Parameter feed enhancements \[ID_26627\]

Due to a number of enhancements, overall performance of the parameter feed has increased, especially when using it in conjunction with parameter table, pivot table and line chart components.

#### DataMiner Cube - Service & Resource Management: Enhanced error messages \[ID_26629\]

Throughout DataMiner Cube, a number of error messages related to Service & Resource Management have been rewritten to make them clearer and more user-friendly.

#### Cassandra: Enhanced performance when deleting element data \[ID_26639\]

Due to a number of enhancements, overall performance has increased when deleting element data from a Cassandra database.

#### Trending: Increased limit for trend values of type Double to be converted to scientific notation strings \[ID_26646\]

In the database, trend values are stored as text strings.

Up to now, all values of type Double with a length of more than 6 characters were converted to a scientific notation string (e.g. “1e07”). From now on, only values of type Double with a length of more than 12 characters will be converted to a scientific notation string.

#### Improved logging in case client is disconnected \[ID_26667\]

If a client application tries to send a request to a DMA that has already destroyed the client connection, or when the client application checks the connection and finds that it no longer exists, now the log information will mention that the connection was closed with the time when it was closed and the reason it was closed. Previously, logging only mentioned "no such connection" in this case.

#### Enhanced performance when migrating a database from MySQL to Cassandra \[ID_26670\]

Due to a number of enhancements, overall performance has increased when migrating a database from MySQL to Cassandra.

#### Jobs app: No longer possible to edit or delete hidden job sections \[ID_26687\]

In configuration mode, up to now, it was possible to not only unhide a hidden section, but also to edit or delete it. From now on, it will only be possible to unhide hidden sections. It will no longer be possible to edit or delete hidden sections.

#### Jobs app: Enhanced label behavior in timeline view \[ID_26727\]

A number of enhancements have been made to the way in which labels are visualized in the timeline view.

Also, the custom time filter will now correctly update when zooming in or out.

#### DataMiner Cube: Enhanced performance when processing parameter updates and calculating service statistics \[ID_26863\]

Due to a number of enhancements, overall performance has increased, especially when processing parameter updates and calculating service statistics.

#### SLAnalytics: Enhanced logging \[ID_26884\]

A number of enhancements have been made to the SLAnalytics logging.

#### Raw value displayed if string value of analog parameter could not be parsed as double \[ID_26909\]

If a string value of an analog parameter could not be parsed as double, since DataMiner 10.0.9, "0" would be displayed as the default fallback value. However, as some older drivers relied on the previous behavior, now the raw value will be displayed again instead.

#### Lazy loading of cards in tab layout \[ID_26920\]

To improve memory usage and performance, when you open a saved workspace with multiple cards in a tab layout, each card will only be initialized once it has been selected. The same applies when cards are loaded when you log in to Cube.

#### DataMiner Cube desktop app now updated silently after connection to DMS with higher DataMiner version \[ID_26944\]

When you connect to a DMS with a higher DataMiner version than the currently installed version, the DataMiner Cube desktop app is now updated silently, without a pop-up message.

#### Improved graph layout of service RCA chains \[ID_26945\]

An improved algorithm is now used to draw the graph of the RCA chain of a service. This will better prevent overlapping connections and connections running through nodes.

#### Service & Resource Management: Wildcard supported for protocol version in ProtocolLinks of VirtualFunctionDefinition \[ID_26966\]

In the list of *ProtocolLinks* of a *VirtualFunctionDefinition*, an asterisk ('"\*") can now be used as a wildcard character in a protocol version. However, the wildcard can only be specified at the end of the version.

#### DataMiner mobile apps updated to Angular 9 \[ID_26975\]

The DataMiner mobile apps that use Angular, e.g. the Monitoring, Dashboards and Jobs app, now use Angular 9 instead of Angular 8.

#### Opening the DataMiner Cube start window via system tray icon can now restore existing minimized window \[ID_27006\]

When the DataMiner Cube start window was opened and minimized, opening it again using the system tray icon will restore the existing window.

#### DataMiner Cube: Embedded DataMiner apps now always use Chromium browser \[ID_27052\]

All DataMiner apps displayed within an embedded web browser in DataMiner Cube (e.g. Ticketing, Dashboards, Reports, Annotations, etc.) will now always use the Chromium browser engine, regardless of which default browser engine is configured.

#### Alarm when Cassandra or Elasticsearch database go offline \[ID_27061\]

When the Cassandra or Elasticsearch database go offline, an alarm is now generated in DataMiner. In the alarm details, it will show exactly which storage is in file offload mode while the database is offline.

#### App packages now synced in Failover setup \[ID_27100\]

When an app package is uploaded to one of the DMAs in a Failover pair, it is now automatically synced to the other DMA in the pair. Similarly, if an app package is removed from one of the DMAs in a Failover pair, it is now also automatically removed from the other DMA.

#### Improved behavior of input controls in HTML5 apps \[ID_27129\]

In the DataMiner HTML5 apps, when you fill in a control consisting of multiple parts, e.g. a datetime control, now the next part will always be automatically selected after a part has been completed.

#### Dashboards app: Improved pop-up window when interactive Automation script is canceled \[ID_27141\]

If an interactive Automation script is canceled in the Dashboards app, a pop-up window will now be displayed with the title of the current content of the script, or with the name of the script if no title is available. The pop-up window will not mention the term "script" to avoid confusion in users who may not be aware that they are using a script.

#### Improved logging of PowerShell scripts in DataMiner upgrades \[ID_27160\]

When DataMiner is upgraded and one of the steps of the upgrade is a PowerShell script, the output of that script is now written to the progress.log file and displayed in the upgrade window.

#### Dashboards app: Improved row height behavior \[ID_27203\]

The height of the rows of the dashboard grid has been halved, from 36 to 18 pixels, in order to allow more precise control of the position of dashboard components. In existing dashboards, the existing components will therefore use twice as many rows.

In addition, row height will no longer be adjusted dynamically, the default height of a component now takes margin, padding and border into account and there is no longer a minimum height for a component.

#### Failover: More information will now be returned after synchronizing the two agents \[ID_27156\]<br>\[ID_27870\]

After synchronizing the two agents in a Failover setup, from now on, more detailed information about the synchronization process will be returned.

#### DataMiner Cube desktop app: Upgrade improvements \[ID_27159\]

A number of improvements were implemented to the upgrade mechanism of the DataMiner Cube desktop app:

- When the DataMiner Cube desktop app detects that an update is ready, in any open instances an info bar will now notify the user that the app needs to be restarted, and ask for confirmation.

- When the download of a new version is incomplete because of a restart or shutdown of the app, the download will now be cleaned up automatically to prevent issues.

- If the *Check for updates* option is selected in the start window, the resulting message will now be displayed in an info bar instead of a message box.

#### DataMiner Cube - Service & Resource Management: Enhanced retrieval of service states \[ID_27202\]\[ID_27484\]

Due to a number of enhancements, overall performance has increased when retrieving SRM service states in the Cube Surveyor, the Services app and Visual Overview.

#### Dashboards app: Enhanced tool tip icons \[ID_27331\]

Throughout the Dashboards app, the tool tip icons have been enhanced.

#### Dashboards app: Enhanced component resizing \[ID_27372\]

Due to a number of enhancements, the way to resize dashboard components has been improved, especially on mobile devices.

#### Jobs app: Miscellaneous enhancements \[ID_27454\]

A number of enhancements have been made to the user interface of the Jobs app: icons have been replaced, progress bars and tool tips have been added where appropriate, actions showing “remove” now all show “delete” instead, etc. Also, overall performance has increased.

#### Services app now includes virtual function definitions configured in DataMiner \[ID_27462\]

Previously, the Services module only listed virtual functions that had been uploaded to DataMiner via a Functions.xml file. Now it also includes virtual function definitions that were fully configured in DataMiner.

#### SLWatchdog will now automatically restart the NAS and NATS services \[ID_27478\]

From now on, when SLWatchdog notices that the NAS and/or NATS services were stopped, it will automatically restart them and generate an alarm.

#### DataMiner Cube: Enhanced performance when loading custom SVG icons during login \[ID_27480\]

Due to a number of enhancements, overall performance has increased when loading custom SVG icons during login.

#### DataMiner Maps: KML layers now always bottom layers of map \[ID_27492\]

In the DataMiner Maps application, KML layers will now always be placed below other layers. Other layers will be drawn from top to bottom as defined in the map configuration.

#### Monitoring app/Dashboards app: Support for embedded trend graphs in Visual Overview \[ID_27574\]\[ID_27584\]

The Monitoring app and Dashboards app now support the use of embedded trend graphs in Visual Overview. By default the trend graphs will display the last 24 hours of trending. In a dashboard, the colors of the graph will depend on the theme settings of the dashboard.

#### DataMiner Cube start window: Popup windows can be closed by pressing ESC & main window title changed to “DataMiner Cube” \[ID_27582\]

In DataMiner Cube start window, popup windows can now be closed by pressing the ESC button.

Also, the title of the main window has been changed to “DataMiner Cube”.

#### DataMiner upgrade packages now also include the C:\\Skyline DataMiner\\Resources folder \[ID_27600\]

DataMiner upgrade packages now also include the C:\\Skyline DataMiner\\Resources folder.

#### More details will be logged when an error occurs while taking a backup \[ID_27614\]

From now on, more detailed information will be added to the log files when an error occurs while taking a backup.

#### Dashboards app: Right-clicking a component now only shows “Copy embed URL” in edit mode \[ID_27629\]

Previously, when a dashboard component was right-clicked, this always showed the option *Copy embed URL*. However, as this option is not as useful for a dashboard operator as the default right-click menu, it will now only be displayed when the component is right-clicked in edit mode. Otherwise, the default right-click menu will be displayed.

#### DataMiner Cube - Services app: Enhanced retrieval of service information \[ID_27647\]

In the Services app, all SRM service information will now be retrieved page by page.

#### DataMiner Cube - Resources app: A popup message will now be displayed when trying to config­ure resources on a system with an SRM license but no Indexing Engine \[ID_27737\]

When, on a system with an SRM license but no Indexing Engine, you try to configure resources, from now on, DataMiner Cube will show a message, saying that this is not possible.

#### Client applications now also get notified when cell alarm levels in the source data tables of direct views change due to updates that do not change the cell value \[ID_27785\]

From now on, client applications displaying direct views will also be notified when cell alarm levels in the source data tables change due to updates that do not change the cell value. (e.g. when a cell in a source table gets masked).

#### Live Sharing Service: Enhanced error handling \[ID_27791\]

A number of enhancements have been made to the overall error handling in the Live Sharing Service.

#### DataMiner Cube: Enhanced consistency of trend graph legends \[ID_27831\]

From now on, when multiple trend graphs show similar data, they will all have a similar legend.

#### DataMiner Cube: Virtual functions now in separate section in Protocols & Templates app + made unavailable for regular element creation \[ID_27832\]

Virtual functions are now displayed in a separate *Virtual Functions* section in the Protocols & Templates app. In addition, when you create an element, virtual functions are not listed among the protocols you can choose for the element.

#### DataMiner Cube: Enhanced performance when connecting to a DMA with a large amount of alarms \[ID_27837\]

Due to a number of enhancements, overall performance has increased when connecting to a DataMiner Agent with a large amount of alarms.

#### Interactive Automation scripts: No longer possible to clear the value of a selection box control \[ID_27845\]

Up to now, in an interactive Automation script, it was possible to clear the value of a selection box control by clicking an X button. From now on, this is no longer possible.

#### Interactive Automation scripts: Multi-line text boxes will no longer expand when selected \[ID_27858\]

Up to now, a multi-line text box (i.e. a UIBlock of type TextBox with IsMultiline set to true) would by default have a height of 1 line and would expand when it was selected. From now on, its initial height will be fixed. It will no longer expand when selected.

#### DataMiner Cube: Enhanced retrieval of user images \[ID_27861\]

DataMiner Cube shows an image of the user who is logged in. The way in which this image is retrieved, has now been enhanced.

#### SLPort now automatically resizes the socket buffer before receiving data from a socket \[ID_27891\]

From now on, the SLPort process will automatically resize the socket buffer before receiving data from a socket.

#### DataMiner Jobs: new ResourceFieldDescriptor field \[ID_27922\]

A new *ResourceFieldDescriptor* field is now available for DataMiner jobs. This field requires a GUID value, which should be the GUID of a resource. It also has a *ResourcePoolIds* property which can be used to filter resources based on resource pools. This feature is intended to support the upcoming PLM app.

#### Performance enhancement: An element card page containing a direct view table will only show the alarm severity of that table when the page is opened \[ID_27928\]

When you open an element card, pages containing direct view tables will no longer show the alarm severity of those tables. Only when you open a page containing a direct view table will the alarm severity of that table be calculated and displayed.

#### DataMiner Jobs: New DefaultValue property of FieldDescriptor class \[ID_27934\]

The *FieldDescriptor* class for DataMiner jobs now has a new *DefaultValue* property, so that it is now possible to add a default field value to each FieldDescriptor. This feature is intended to support the upcoming PLM app.

#### Service & Resource Management: ResourcesNotMatchWithServiceDefinition check removed \[ID_27938\]

The ResourcesNotMatchWithServiceDefinition check has been removed.

As a result, an error will no longer be returned when saving a ServiceReservationInstance where the booked resources do not match the functions or virtual functions required by the ServiceDefinition.

#### Service & Resource Management: New VirtualFunctionID property added to NodeDefinition class \[ID_27953\]

A new *VirtualFunctionID* property is now available for *NodeDefinition* objects for service profiles.

When a service profile definition is created, DataMiner will check if the virtual function ID exists. If it does not exist, a new error reason *InvalidVirtualFunctionDefinitions* will be added in the trace data. The property *InvalidVirtualFunctionIDs* of the trace data will be filled in with the non-existing virtual function IDs. The property *ServiceProfileDefinition* of the trace data will allow you to identify which service profile definition has an error.

Note that this property can currently not yet be configured in DataMiner Cube.

#### Ticketing app: Enhanced “Edit ticket field” window \[ID_27962\]

Due to a number of enhancements to the *Edit ticket field* window, especially the section that allows you to define the possible values, configuring a ticket state field has been made more intuitive.

#### Dashboards app - Parameter feed: “partial table” renamed to “paged table” \[ID_28048\]

In the tool tip of the “Select all items” and “Select specific number of items” options, “partial table” has been renamed to “paged table”.

#### DataMiner Cube - EPM: Enhanced color scheme of EPM topology diagram in Skyline Black theme \[ID_28053\]

In the Skyline Black theme, the color scheme of the EPM topology diagram has been enhanced.

#### New icons added to Icons.xml file \[ID_28060\]

The following new icons have been added to the file Icons.xml, located in the folder C:\\Skyline DataMiner\\Protocols.

- Trash

- New item

#### Dashboards app: Default themes updated \[ID_28074\]

In the Dashboards app, a number of default themes have been updated.

#### Dashboards app: Enhanced page selector in embedded visual overviews \[ID_28237\]

A number of enhancements have been made to the page selector of embedded visual overviews.

For example, when a visual overview with multiple pages is embedded in a dashboard, the page selector will now also inherit the dashboard theme colors. Also, when a page is selected, the page selector will now display the name of the page.

#### DataMiner Cube: SVG icons will now automatically adapt to the chosen Cube theme \[ID_28248\]

Due to a number of enhancements, SVG icons will now automatically adapt to the chosen Cube theme.

#### Ticketing app: No automatic redirection anymore when ticket creation or ticket update has fin­ished \[ID_28310\]

Up to now, when, after creating or editing a ticket, you navigated to another part of the Ticketing app, you would automatically be navigated back to the ticket when the ticket creation of ticket update was finished. From now on, this will no longer be the case.

#### DataMiner Mobile apps: Improvement of arrow controls to increase/decrease a value \[ID_28312\]

In the DataMiner mobile apps, such as the Monitoring, Ticketing and Dashboards app, when you hover over the arrow buttons to increase or decrease the value of a date or time, the value that will be affected by the arrow buttons will now be highlighted. In addition, such arrow buttons will now only be displayed when you hover over the input.

#### Jobs app: No longer possible to start a job data migration when no Elasticsearch database is available \[ID_28385\]

From now on, it will no longer be possible to start a job data migration when no Elasticsearch database is available.

#### DataMiner Cube - Service & Resource Management: Enhanced performance when opening Cube \[ID_28603\]

Due to a number of enhancements, overall performance has increased when opening Cube, especially in SRM environments.

#### Dashboards app: Optimized rendering of GQI query results in PDF reports \[ID_28622\]

In the Automation, Correlation and Scheduler modules, you can generate a report based on a dashboard from the new Dashboards app.

Due to a number of enhancements, the way in which tables that display GQI query results are rendered in PDF reports has now been optimized. When the *Stack components* option is enabled, tables showing results from different queries will even be rendered in such a way that all result sets are displayed one after the other.

#### Failover: Heartbeat checks will now be logged in the debug logging \[ID_28627\]

In a Failover setup, heartbeat checks will now be logged in the debug logging.

#### SLAnalytics - Alarm Focus: Enhanced performance \[ID_28689\]

Due to a number of enhancements, overall performance has increased when fetching the alarm history.

#### Dashboards app - GQI: Changing the column order by using a column filter \[ID_28693\]

It is now possible to change the column order by using a column filter. The order of the selected columns in the column filter will now be used to construct the resulting table. By default, the order of the columns is determined by the data source.

Also, the following issue was fixed. When a row filter was used on a column that was not included in the default column set, in some cases, an additional column would incorrectly be added to the default column set.

#### Dashboards app - Table components: Enhancements with regard to resizing \[ID_28733\]

A number of enhancements have been made to the table components, especially with regard to the resizing of those components.

#### DataMiner Cube - Profiles app: Enhancements \[ID_28768\]

A number of enhancements have been made to the Profiles app. Overall performance has increased when loading profiles, and paging of profile parameters and profile definitions is now supported.

#### DataMiner Cube - Profiles app: A warning will now appear when no value is assigned to a man­datory parameter \[ID_28787\]

When, in the Profiles app, you indicate that a profile parameter is mandatory, if that parameter does not have a value assigned, a warning will now appear, saying that it is recommended to assign a value to mandatory parameters.

### Fixes

#### Dashboards app: Polling issues when WebSocket communication was disabled \[ID_23801\]

When WebSocket communication was disabled for a dashboard, it could occur that the state of views and redundancy groups was only polled every 5 minutes. In addition, it could occur that only the initial active alarms were retrieved.

#### Various issues in Change Element States Offline tool \[ID_23833\]

Various issues have been resolved in the Change Element States Offline tool.

#### Dashboards app - Trend charts: Boundary lines would only be drawn on the first axis \[ID_23837\]

When you added boundary lines to a trend chart, in some cases, the lines would only be drawn on the first axis. From now on, they will be drawn on every visible axis.

#### Jobs app: Problem when filtering on a field of the default job section \[ID_24236\]

When creating a filter on a field of the default job section, in some cases, an incorrect field ID would be used.

#### DataMiner Cube - Failover: Progress message no longer displayed during a switch-over \[ID_24250\]

During a switch-over, in some cases, users would no longer receive a “\<DMA> is switching to \<DMA>” message.

Also, the term “System Display” has been replaced by “Client Interface” in *Failover status* windows.

#### Dashboards app: Incorrect message would appear when an interactive Automation script went into timeout \[ID_24258\]

When an interactive Automation script running inside the Dashboards app went into timeout, in some cases, a success message would incorrectly be displayed instead of an error message.

#### Trending: Incorrect trend data retrieved for view column parameters \[ID_24268\]

In some cases, incorrect trend data would be retrieved for view column parameters.

#### Datetime value in interactive Automation script not updated correctly \[ID_24284\]

When a datetime value in an interactive Automation script was changed by the script itself, it could occur that the value was not updated correctly.

#### Dashboards app / Jobs app: Problem opening the user menu \[ID_24285\]

In the Dashboards app and the Jobs app, in some cases, it would not be possible to open the user menu.

#### Jobs app: Job end times displayed incorrectly in timeline \[ID_24287\]

In the jobs timeline, in some cases, job end times would be displayed incorrectly.

#### HTML5 apps: Selecting the month value in a datetime control would incorrectly clear that value \[ID_24323\]

When you selected the month value in a datetime control, in some cases, that value would incorrectly be cleared.

#### Automation: Dialog box from an interactive Automation script started in Dashboards would incorrectly appear in Cube \[ID_24328\]

In some cases, a dialog box from an interactive Automation script started in Dashboards would incorrectly appear inside a Cube session.

#### Dashboards app: Element tree of a multiple-parameter feed was sorted incorrectly \[ID_24495\]

In some cases, the element tree of a multiple-parameter feed would not be sorted correctly. From now on, this tree will be sorted correctly, even when multiple filters are applied.

#### Dashboards app: Parameters in the URL would not correctly be loaded in the multiple parame­ter feed \[ID_24536\]

When you opened a dashboard with a multiple parameter feed using a URL that contained the parameters to be loaded in that feed, in some cases, the parameters in the URL would not correctly be loaded into the multiple parameter feed.

#### Problem when opening an HTML5 app \[ID_24565\]

When you opened an HTML5 app (e.g. Monitoring & Control, Dashboards, etc.), in some cases, the app would not load due to a missing internal component.

#### Problem during protocol buffer serialization \[ID_24630\]

In some cases, an exception could be thrown during protocol buffer serialization.

#### DataMiner Cube - Alarm console: Dragging an element to the Alarm Console incorrectly showed all alarms on the DataMiner Agent \[ID_24655\]

When you dragged an element onto the Alarm Console, in some cases, the alarm tab would incorrectly list all alarms on the DataMiner Agent instead of only the alarms of the element in question.

#### Service & Resource Management: Incorrect result when comparing service definitions \[ID_24662\]

If an Automation script compared two service definitions with at least one interface configuration or edge in the diagram, it could occur that the Equals method returned false incorrectly.

#### DataMiner Cube - EPM/CPE: Problem with chain field option “statusTabs” \[ID_24668\]

In DataMiner Cube, in some cases, so-called status tab links to pop-up windows (defined in chain field “statusTabs” options) would no longer be rendered correctly.

#### SLAnalytics: Increased memory usage \[ID_24703\]\[ID_25601\]

Due to a code refactoring error, in some cases, the overall memory usage of the SLAnalytics process could increase by up to 40 percent.

#### Jobs app: Action buttons no longer displayed after executing an action \[ID_24710\]

In some cases, after a job action was executed (i.e. creation, editing or deletion of a job), it could occur that the action buttons in the header bar of the panel were no longer displayed.

#### Jobs app: Timeline action buttons displayed in incorrect location \[ID_24732\]

When a job was selected on the timeline in the Jobs app, the action buttons for the job were displayed in the header bar of the app instead of the header bar of the panel.

#### Dashboards app: Resource feed selection lost after refresh \[ID_24738\]

If a resource was selected in a feed, it could occur that the feed did not keep this selection when the page was refreshed.

#### Problem when writing multiple datasets to a database \[ID_24748\]

When multiple datasets were written to a database in one go, e.g. when inserting data temporarily stored in offload files, in some cases, the following exception could be thrown:

```txt
System.InvalidOperationException: Collection was modified after the enumerator was instantiated.
```

#### Problem when serial clients went into timeout \[ID_24764\]

When a serial client went into timeout, in some cases, the socket would not be cleaned up correctly, causing the client to not reconnect when the server became available again.

Also, in case of commands that did not require a response, in some cases, the sent data would not be cleaned up correctly, causing the socket to keep on sending.

#### Problem with SLPort when parsing SSH responses \[ID_24776\]

In some cases, an error could occur in SLPort when parsing SSH responses.

#### Memory leak in SLProtocol \[ID_24793\]

In some cases, SLProtocol could leak memory when communicating with SLPort.

#### Problem when performing a full synchronization \[ID_24804\]

When performing a full synchronization, in some cases, an error could occur due to a deadlock in SLDataMiner.

#### DataMiner Cube - Visual Overview: Trend components with dynamic shape data could no longer be collapsed \[ID_24812\]

In some cases, trend components with dynamic shape data could no longer be collapsed.

#### Business Intelligence: Correcting an SLA outage would incorrectly not affect the history table \[ID_24873\]

If you corrected an outage that was no longer in the current SLA window, in some cases, the history table (i.e. table 1000) would incorrectly not get updated.

#### Jobs app: Save button could no longer be clicked after trying to save a job that contained errors \[ID_24881\]

After trying to save a job that contained errors (e.g. missing fields), in some cases, it would no longer be possible to click the *Save* button again after correcting the errors.

#### Dashboards app: Problem when loading drop-down boxes of interactive Automation scripts \[ID_24888\]

When a dialog box of an interactive Automation script showed multiple drop-down boxes next to each other, in some cases, some of those boxes would become unresponsive when data was being loaded into them.

#### Jobs app: No headers were displayed at the top of the jobs list \[ID_25042\]

In the Jobs app, in some cases, no headers would be displayed at the top of the jobs list.

#### After an element restart, the view impact information of alarms retrieved from the database could be incorrect \[ID_25053\]

When, after restarting an element, the alarms associated with that element were retrieved from the database, in some cases, the view impact information in those alarms would be incorrect.

#### Active alarms could be displayed incorrectly after restarting a DMA with a MySQL database \[ID_25071\]

When a DataMiner Agent with a MySQL database was restarted, in some cases, the active alarms could be displayed incorrectly after the restart.

#### Jobs app: Problem listing the job section definitions \[ID_25087\]

In the Jobs app, in some cases, an error would occur when trying to list the job section definitions.

#### CRC trailer from separate IP packet not added to response \[ID_25089\]

If a CRC trailer was returned in a separate IP packet, it could occur that it was not added to the response.

#### Monitoring app: Severity color indication not displayed in Alarm Console and on alarms pages \[ID_25106\]

In some cases, it could occur that the severity color indication was not displayed in the Alarm Console and on alarms pages in the Monitoring app.

#### SLAnalytics: Trend prediction data would contain incorrectly converted time stamps \[ID_25111\]

In some cases, trend prediction data returned by SLAnalytics would contain incorrectly converted time stamps.

#### Exception when writing empty data set to Elastic database \[ID_25113\]

In some cases, an exception could be thrown when an empty data set was written to the Elastic database.

#### Business Intelligence: Incorrect total violation time due to a rounding issue \[ID_25115\]

In some cases, the Total Violation Time could be incorrect due to a rounding issue.

#### Missing or incorrect alarm details after retrieving alarms of a restarted element from a MySQL database \[ID_25123\]

When, after an element restart, the alarms of that element were retrieved from a MySQL database, in some cases, a number of alarm fields would either contain incorrect values or be missing.

#### Memory leak in SLAnalytics \[ID_25145\]

In some cases, a memory leak could occur in the SLAnalytics process.

#### Dashboards app: Not possible to select items in tree view \[ID_25151\]

In some cases, it could occur that it was not possible to select items in a tree view in the Dashboards app. This could for example be the case in a tree component or in the configuration of a parameter feed.

#### Number of masked alarm was incorrectly incremented when the severity of a masked alarm was changed \[ID_25182\]

When the severity of a masked alarm was changed, in some cases, the number of masked alarms would incorrectly be incremented.

#### DataMiner Cube - EPM: EPM filter not loaded when topology cell was not linked to topology cell of selected object \[ID_25191\]

If an EPM (formerly known as CPE) element displayed a diagram, it could occur that a filter above a filter containing a selection remained empty if the former had a topology cell that was not linked to the topology cell of the selected object.

#### Problem with SLAnalytics due to a threading issue \[ID_25207\]

In some cases, an error could occur in SLAnalytics due to a threading issue.

#### Problem when retrieving a large number of alarms from a MySQL database \[ID_25298\]

When, on a system with a MySQL database, a correlation alarm was based on a large number of alarms, in some cases, an exception could be thrown when retrieving those alarms.

#### DataMiner Cube - Alarm Console: Severity duration of cleared alarms was not set to “N/A” \[ID_25370\]

When you added the *Severity Duration* column to the Alarm Console, up to now, the duration for a cleared alarm was incorrectly shown as the difference between the time of the alarm and the current time. From now on, the duration of a cleared alarm will always be shown as “N/A”.

#### DataMiner Cube: Elements would go into timeout after being imported from a CSV file \[ID_25457\]

When you exported elements with non-used SNMP credential library references to a CSV file, those references were incorrectly saved as empty GUIDs. This would cause the elements to go into timeout after being re-imported from that CSV file.

#### Alarm file offload serialization would fail due to a protocol buffer error on a PropertyAccess­Type enum value \[ID_25459\]

In some cases, alarm file offload serialization would fail due to a protocol buffer error on a PropertyAccessType enum value.

#### Dashboards app - Service definition component: Script parameters were swapped \[ID_25476\]

When a script was launched from the service definition component, in some cases, the booking ID (or the service definition ID) and the node ID script parameters would be swapped.

#### SLAnalytics: Problem when retrieving data at startup \[ID_25479\]

In some cases, an error could occur when SLAnalytics retrieved data from the database at startup.

#### SNMP: Problem when using a specific polling rate in conjunction with the “SNMP set and get” or “dynamic SNMP get” options \[ID_25514\]

When a protocol configured to poll SNMP columns at a specific polling rate has write parameters that use the “SNMP set and get” option or parameters that use the “dynamic SNMP get” option, in some cases, values could appear to be toggling in the user interface.

#### DataMiner Cube - Data Display: Zero-width column was not saved at the correct position when saving the column layout of a table \[ID_25534\]

When you saved the column layout of a table that contained a hidden column (i.e. a column of which the width was set to 0 in the protocol), that hidden column would not be saved at the correct position.

#### Exception when exporting SNMP element to CSV \[ID_25586\]

When an element with an SNMP connection was exported to CSV, an exception could be thrown, causing the export to fail.

#### Web Services API v1: WSDL no longer backwards compatible for GetTicket method \[ID_25605\]

The WSDL was no longer backwards compatible for the GetTicket method.

#### Problem with SLPort due to a buffer resizing issue \[ID_25607\]

When SLPort receives data, it stores it in a buffer until everything has been received. If the amount of data received is larger than the size of the buffer, the buffer is automatically resized. However, in some cases, this would not happen, causing an error to occur.

#### Automation: Email sent from an Automation script had an incorrect subject \[ID_25618\]

When an email was sent from an Automation script, in some cases, the dashboard name would incorrectly be used as email subject.

From now on, the dashboard name will only be used as email subject when no subject was specified.

#### Backup that included an Indexing database with a red index would incorrectly succeed on one agent in the DMS \[ID_25658\]

When, in a DataMiner System, you took a backup that included an Indexing database with a red index, up to now, the backup would incorrectly succeed on one agent and fail on all others.

From now on, a backup that includes an Indexing database with a red index will fail on all agents and an error will be added to the elasticbackup log file in the Backup folder.

#### Ticketing app: Certain selection boxes were not scrollable \[ID_25719\]

Certain selection boxes, like the ticket domain selector in the subheader, would incorrectly not be scrollable.

#### Problem when conditionally monitoring a standalone parameter using a condition that included a column parameter check \[ID_25731\]

When a standalone parameter was monitored conditionally, and the condition in question included a column parameter check, in some cases, an error could occur in SLElement.

#### Service & Resource Management: Problem when updating multiple ReservationInstance proper­ties in rapid succession \[ID_25808\]

When multiple ReservationInstance properties were updated in rapid succession, in some cases, “PropertiesWereAlreadyModified” errors could be thrown.

#### DataMiner Cube - Resources app: Incorrect validation tool tip would appear when a capability parameter did not have a regular expression defined \[ID_25835\]

When adding or editing a resource in the Resources app, in some cases, an incorrect validation tool tip would appear when a capability parameter did not have a regular expression defined.

#### Indexing Engine: Memory issues caused by custom data paging cooking not being cleaned up \[ID_25836\]

On systems running Indexing Engine, custom data paging cookies would no longer be cleaned up. In some cases, this could lead to memory issues.

#### SLAnalytics: Memory usage would increase due to a buffering issue \[ID_25844\]

In some cases, the overall memory usage of the SLAnalytics process would increase due to a buffering issue.

#### SLAnalytics: Parameter information of inactive elements would incorrectly not get removed from the cache \[ID_25851\]

Up to now, parameter information of inactive elements would incorrectly not get removed from the cache.

#### Unnecessary “codedom” tag in SLNet.exe.config file \[ID_25868\]

In some cases, the SLNet.exe.config file would contain an unnecessary “codedom” tag. On certain DataMiner Agents, this could lead to issues when generating functions.

#### Interactive Automation scripts: Some drop-down boxes would unnecessarily trigger a refresh of the UI \[ID_25902\]

In some cases, drop-down boxes would unnecessarily trigger a refresh of the UI.

#### Dashboards app - Service Definition component: Booking ID not passed to the script when click­ing a node \[ID_25912\]

When, in a service definition component linked to a booking, you clicked a node that launched an Automation script, in some cases, the booking ID would not be passed to the script.

#### SLAnalytics: Element state changes and element deletions would not be processed correctly when behavioral anomaly detection was disabled \[ID_25929\]

Up to now, when behavioral anomaly detection was disabled, in some cases, element state changes and element deletions would not be processed correctly.

#### Problems when generating a PDF report based on a dashboard from the new app \[ID_25939\]

In PDF reports generated based on dashboards from the new Dashboards app, the page numbers would be incorrect and the service state visualizations would not be displayed correctly.

#### Problem when a table filter contained the table parameter ID instead of the column parameter ID \[ID_25988\]

When a DynamicTableQuery is passed to SLelement, it is possible to add a column filter in one of the following formats:

- Value= \<COLUMNPID> == \<Value>

- Fullfilter= \<COLUMNPID>==\<Value>

Up to now, when such a column filter contained the table parameter ID instead of the column parameter ID, in some cases, either a NULL response would incorrectly be returned or an error would occur in SLElement.

#### SLAnalytics: Different agents in a DMS would incorrectly each create a different configuration file \[ID_26005\]

Due to a synchronization issue, in some rare cases, different agents in a DMS would incorrectly each create a different SLAnalytics configuration file.

#### Failover: Backup agent would lose its connection to the virtual agent \[ID_26025\]

When, in a Failover setup with a Cassandra database, the backup agent was online, in some cases, it would lose its connection to the virtual agent.

#### DataMiner was not able to correctly parse the Cassandra.yaml file at startup \[ID_26041\]

At startup, in some cases, DataMiner was not able to correctly parse the IP addresses of the seed nodes when reading the Cassandra.yaml file.

#### Restarting an element immediately after masking it would cause it to be shown as unmasked for a short period of time \[ID_26070\]

When you masked an element and then immediately restarted it, in some rare cases, it could be shown as unmasked for a short period of time.

#### Incorrect page margins in PDF reports sent by an Automation script \[ID_26090\]

When an Automation script sent a PDF report based on a dashboard, in some cases, the page margins in that PDF report would be incorrect.

#### Failover: Problem when switching over the first time after migrating from MySQL to Cassandra \[ID_26116\]

When, in a Failover setup, the first switch-over occurred after migrating from MySQL to Cassandra, in some cases, a DataMiner run-time error alarm would be generated.

#### ResourceManager module would no longer initialize after a DataMiner restart \[ID_26117\]<br>\[ID_26309\]

In some cases, the ResourceManager module would no longer initialize after a DataMiner restart.

#### Problem with SLManagedScripting due to a locking issue \[ID_26139\]

In some rare cases, threads could get stuck in SLScripting due to a locking issue.

#### DataMiner Cube: Incorrect error would be logged when opening a view card without linked EPM object in an EPM environment \[ID_26141\]

When, in an EPM environment, you opened a view card without linked EPM object, in some cases, an incorrect error would be logged.

#### Dashboards app - Service definition component: When a node action was executed, all action buttons of other nodes with the same action configured would be set to “loading” \[ID_26145\]

In a service definition component, in some cases, all nodes with the same action configured would set the state of their action button to “loading” when the action was executed on one of those nodes.

#### DataMiner Cube - Trending: Trend graph of aggregation parameter did not show any data \[ID_26172\]

When you opened the trend graph of an aggregation parameter, in some cases, no trend data was shown.

#### Exceptions related to correlation data flushing would be logged during a DMA startup or Failover switch \[ID_26177\]

During a DMA startup or a Failover switch, in some cases, exceptions related to correlation data flushing would be logged in SLErrors.txt.

#### Visual Overview: Tabs names not displayed when alternative tab control style was used \[ID_26181\]

When a tab control in a Visio drawing was configured to use an alternative style with the option "*TabControlStyle=2*", it could occur that tab names were not displayed.

#### SLAnalytics: New alarms generated while SLAnalytics was stopped would incorrectly not be assigned an alarm focus score when SLAnalytics was restarted \[ID_26186\]

When a new alarm was generated while SLAnalytics was stopped, in some cases, that alarm would incorrectly not get assigned an alarm focus score when SLAnalytics was restarted.

#### Jobs app: Problem when creating custom data tables \[ID_26237\]

In the Jobs app, in some rare cases, an exception could be thrown when two custom data tables were created simultaneously.

#### Service & Resource Management: System functions were not synchronized when a new agent was added to an existing DataMiner System \[ID_26238\]

When a new agent was added to an existing DataMiner System, in some cases, the system functions would not be synchronized.

#### Memory leak in SLDataGateway \[ID_26361\]

In some cases, the SLDataGateway process would leak memory.

#### Monitoring app: Client timezone setting was disregarded when displaying timestamps in trend graphs \[ID_26368\]

In some cases, the Monitoring app would incorrectly disregard the client timezone setting when displaying timestamps in trend graphs.

#### Problem with user permissions for Automation scripts \[ID_26401\]\[ID_26957\]

Up to now the permissions to add, edit, delete and execute Automation scripts were only enforced in the client, which could make it possible for a user to modify the Automation scripts on a DMA despite not having the required permissions for this.

Now the system will enforce the permissions as follows:

- To view or retrieve an Automation script, you need the "Automation - UI available" or "Automation - Execute" permission.

- To create an Automation script, you need the "Automation - Add" or the "Automation - Edit" permission.

- To update an Automation script, you need the "Automation - Add" or the "Automation - Edit" permission.

- To delete an Automation script, you need the "Automation - Delete" permission.

- To execute an Automation script, you need the "Automation - Execute" permission.

- To perform a DLL injection in an Automation script, you need the "Automation - Add" or the "Automation - Edit" permission.

- To change a memory file, you need the "Automation - Add" or the "Automation - Edit" permission.

- To retrieve a memory file, you need "Automation - UI available" or "Automation - Execute" permission.

In addition, within DataMiner Cube, up to now there could be a problem when you made changes to the memory files in the Automation app. This has now been resolved. To bring the memory files tab in line with the rest of the Automation app, the *Cancel* button in this tab has also been replaced by a *Discard* button.

#### SLLogCollector tool: LogCollector package would incorrectly not contain any dump files \[ID_26417\]

When a LogCollector package had been made using the SLLogCollector tool, in some cases, that package would incorrectly not contain any dump files.

#### Active alarms would not be retrieved correctly from the database \[ID_26420\]

In some cases, an internal exception could be thrown, causing the active alarms not to be retrieved correctly from the database.

#### LoggerUtil: Some log entries would not get added to the logs \[ID_26429\]

In some cases, certain log entries would not get added to the logs.

#### Jobs app: Problem with “New” and “Save” buttons \[ID_26474\]

In the Jobs app, in some cases, the *New* button would not be shown in the subheader.

Also, in some cases, clicking the *Save* button would not cause a job to be saved.

#### Service & Resource Management: Problem when retrieving Profile Manager data \[ID_26478\]

When retrieving Profile Manager objects, in some cases, a NULL object would incorrectly be returned.

#### Jobs app: Problem when exporting a job to PDF \[ID_26484\]

In some cases, it would not be possible to export a job to a PDF file.

#### Jobs app: Problem when updating a job with bookings \[ID_26486\]

In some cases, an error could occur when you updated a job with bookings.

#### Jobs app: Bookings list would not be updated correctly after adding, editing or deleting a book­ing \[ID_26487\]

In the Jobs app, in some cases, the bookings list would not be updated correctly after adding, editing or deleting a booking.

#### Dashboards app - CPE feed: A field filtered by a field value lower in the chain would not contain the correct value \[ID_26529\]

When using a CPE feed on a dashboard, in some cases, a field filtered by a field value lower in the chain would not contain the correct value.

#### Monitoring app: Alarm Console could show an error when the browser was connected to the Web Services API using web sockets \[ID_26581\]

In the Monitoring app, in some cases, the Alarm Console would show a “Received invalid data” error when the browser was connected to the Web Services API using web sockets.

#### Renamed DVE element would again have its former name after restarting the DMA \[ID_26589\]

When you renamed a DVE element, in some cases, it would incorrectly have its former name again after the DMA was restarted.

#### MySQL: DVE child elements would incorrectly not be deleted when the DVE parent element was deleted \[ID_26607\]

When a DVE parent element was deleted from a MySQL database, in some cases, its child elements would incorrectly not be deleted.

#### Problem when opening a Visio file in an HTML5 app \[ID_26610\]

In some cases, an exception could be thrown when opening a Visio file in an HTML5 app (e.g. Monitoring).

#### Dashboards app: Problem when opening a dashboard after closing a dashboard containing feeds \[ID_26636\]

When you closed a dashboard containing feeds, and then opened another dashboard, in some cases, an error could occur.

#### Dashboards app: Feeds would not appear in the Feeds section of a component’s data tab \[ID_26702\]

In some cases, the time range, drop-down, list and tree feeds would not appear in the Feeds section of a component’s data tab.

#### Problem with SLAnalytics during a Failover switch \[ID_26711\]

In some cases, an error could occur in SLAnalytics during a Failover switch.

#### Jobs app: Fields of type static text could incorrectly be saved without assigning them a value \[ID_26721\]

When configuring job sections, up to now, it would incorrectly be possible to add fields of type static text without assigning them a value. From now on, when you add a field of type static text, you will have to assign it a value.

#### Ticketing app: Number of selected tickets would incorrectly be displayed next to the Delete but­ton when only one ticket was selected \[ID_26723\]

When more than one ticket is selected in the list, the number of selected tickets is displayed next to the *Delete* button at the top of the screen. However, up to now, the number of selected tickets would incorrectly also be displayed when only one ticket was selected.

From now on, the number of selected tickets will no longer be displayed when only one ticket is selected in the list.

#### Problem with SLDataMiner when an SNMP manager was deleted \[ID_26749\]

In some rare cases, an error could occur in SLDataMiner when an SNMP manager was deleted.

#### Long-term trend prediction shorter than mid-term/short-term prediction \[ID_26766\]

In some cases, it could occur that a long-term trend prediction was calculated that was in fact shorter than the mid-term or short-term prediction for the same parameter. In such cases, a long-term prediction will now no longer be available.

#### Protocols: Hex string parameters would not contain enough leading zeros \[ID_26777\]

When a parameter value of type “double” was converted to a value of type “hex string” (e.g. a CRC parameter), in some cases, it would not contain enough leading zeros when put into a data stream.

The problem would typically occur when the parameter was configured as follows:

| Property   | Value                             |
|------------|-----------------------------------|
| Base       | “16”                              |
| Length     | “2”, “4”, “8” or “16”             |
| LengthType | “fixed”                           |
| RawType    | “numeric text”, “text” or “other” |
| Type       | “double”                          |

#### DataMiner Cube - Profiles app: Problem when retrieving the discreet values of a profile parame­ter \[ID_26782\]

When you opened the *Profiles* app, in some cases, an error could occur when retrieving the discreet values of a profile parameter.

#### Dashboards app: No longer possible to delete dashboards \[ID_26798\]

In some cases, users would no longer be able to delete dashboards.

#### Alarm filter combining element and table column filter not working for history alarms tab \[ID_26797\]

If a history alarms tab was filtered using an element filter combined with a table column filter, it could occur that no alarms were displayed.

#### Dashboards app - Pivot table component: Problem with “Auto-expand rows” option \[ID_26803\]

In some cases, the pivot table component’s “Auto-expand rows” option would not work properly when exiting edit mode.

#### Jobs app: No longer possible to save jobs after removing all additionally added fields from the default job section \[ID_26805\]

When you added a number of additional fields to the default job section and then removed them again, in some cases, it would no longer be possible to save jobs.

#### Email report based on dashboard from new app was blank \[ID_26811\]

In some cases, it could occur that if an Automation script sent an email report based on a dashboard from the new Dashboards app, the PDF attached to this email was blank.

#### Dashboards app: Configuration of Group component not saved \[ID_26828\]

In the Dashboards app, it could occur that the configuration of a Group component was not saved.

#### Exception value of numeric parameter displayed incorrectly \[ID_26837\]\[ID_26889\]

If a numeric parameter was set to an exception value, it could occur that it displayed a numeric value instead of its exception value string.

#### Monitoring app: Visual Overview pages not retrieved if HTTPS was enabled \[ID_26839\]

When HTTPS was enabled on a DMA, it could occur that Visual Overview pages could not be retrieved in the Monitoring app.

#### Issues when exporting trend graph for multiple parameters to CSV with custom data set \[ID_26851\]

If a trend graph containing multiple parameters was exported to CSV with a custom data set, it could occur that the export window closed to soon, causing a problem in Cube or making it impossible to save the file. In addition, it could occur that multiple rows were created for the same timestamp.

#### Various issues in the Jobs app \[ID_26866\]

The following issues have been resolved in the Jobs app:

- The confirmation message when a job was deleted was not in line with other deletion confirmation messages.

- When a collapsed or expanded job section was deleted, it was respectively expanded or collapsed while the deletion confirmation message was displayed.

- When the pop-up window to edit a field was closed without saving the changes and then reopened, it still displayed the changes.

#### Jobs app: No error message when deleting all templates in the Load from template window & job fields could incorrectly be marked both “Required” and “Read only” \[ID_26868\]

When, in the *Load from template* window, you deleted all templates, up to now, no error message would be displayed, saying that there are no templates to be applied.

Also, when you configured a job field, up to now, it was possible to mark a field both *Required* and *Read only*. From now on, this will no longer be possible.

#### Service & Resource Management: Virtual function elements would remain in an “Undefined” state \[ID_26898\]

In some cases, the element state of a virtual function element would remain “Undefined”. As a result, bookings using the resource in question could not be started.

#### Service & Resource Management: Incorrect exception was logged when opening Profiles or Resources app \[ID_26901\]

When you opened the Profiles or Resources app, in some cases, an incorrect exception would be thrown when fetching discreet values for profile parameters.

#### Dashboards app: Problems with CPE feed \[ID_26905\]

In some cases, the diagram would not show the selected value when the first field was a text field.

Also, when you opened a drop-down field, in some cases, the fields would close again, making it impossible to select a value.

#### DataMiner state saved in connection and in event cache not in sync \[ID_26928\]

In some cases, it could occur that the DataMiner state saved on the connection and in the event cache were not in sync, which could cause various issues. For example, it could be impossible to delete a ticketing resolver.

#### DataMiner Cube desktop app installation drop-down box not displayed correctly on landing page on small screen \[ID_26934\]

On the DataMiner landing page, the drop-down box that allows you to install the desktop DataMiner Cube app was not displayed correctly if the screen was too small. Since the DataMiner Cube desktop app can only be installed on PCs with a relatively large screen, on small screens this drop-down box will no longer be displayed.

#### DataMiner Cube: Text displayed incorrectly in mixed DPI environment \[ID_26937\]

If DataMiner Cube was displayed on different monitors with different DPI settings, it could occur that text was not displayed correctly in some places.

#### Incorrect information about Cube in Programs and Features window \[ID_26944\]

In the Windows *Programs and Features* window, it could occur that the version number and size of the originally installed DataMiner Cube desktop app were displayed, instead of the actual version number and size.

#### Service & Resource Management: Virtual function definition linked to protocol version used as production version could not be bound to element using production version \[ID_26966\]

If an element used the production version of a protocol, a virtual function definition with a protocol link to the version of the protocol that was used as the production version could not be bound to the element.

Note that protocol links do not support specifying "production" as the protocol version. Note also that when the protocol of an element is changed, the virtual function resource bound to that element is currently not yet changed.

#### Dashboards app: Title not updated after switch between dashboards \[ID_26969\]

When you switched between dashboards in the new Dashboards app, it could occur that the title was not updated correctly.

#### Dashboards app: No error message shown when opening a non-existing dashboard \[ID_26997\]

When you tried to open a non-existing dashboard (e.g. by using an incorrect URL), no error message would appear. Instead, an empty dashboard would be opened.

#### DataMiner Cube: Issues occurring during DELT import operations \[ID_27004\]

A number of issues that would sometimes occur during DELT import operations have now been fixed.

#### Indexing Engine: Incorrect “Sequence contains no elements” error \[ID_27010\]

On systems running Indexing Engine, in some cases, an incorrect “Sequence contains no elements” error would regularly be added to the logs.

#### Bookings app: Hidden “Booking state” column could no longer be set visible again \[ID_27058\]

When, in the *Bookings* app, the *Booking state* column was set hidden, in some cases, it would no longer be possible to set it visible again.

#### Dashboards app: Incorrect default indices selection in parameter feed linked to CPE feed \[ID_27116\]

If a dashboard contained a CPE feed linked to a parameter feed containing a number of indices that had to be selected by default, it could occur that changing the CPE feed selection caused this default selection to be incorrect.

#### Dashboards app: State component linked to a services feed would not immediately get updated when a service was selected \[ID_27137\]

When a feed containing services was linked to a state component, in some cases, the state component would not immediately be updated when you selected a service.

#### Dashboards app: Problem with trend statistics component \[ID_27147\]

When you dragged a table column parameter onto a trend statistics component and then also dragged table indices onto it to act as a filter, in some cases, an error message would appear, saying that no trend data was available.

#### Dashboards app: “Delete component” button would not immediately get updated when you selected multiple components \[ID_27148\]

When you selected multiple components, the *Delete component* button at the top of the screen would incorrectly only get updated to *Delete X components* when you hovered over it.

#### Web Services API: Too many bookings retrieved when multiple subscription sets were used \[ID_27176\]

If there were subscriptions to multiple bookings in multiple subscription sets, it could occur that the API retrieved too many bookings.

#### Dashboards app: Pivot table component retrieved only first page of partial table \[ID_27178\]

In some cases, it could occur that a pivot table component only retrieved data from the first page of a partial table.

#### DataMiner Cube - Profiles app: Problem when duplicating a profile parameter \[ID_27194\]

When, in the *Profiles* app, you duplicated a profile parameter of type “discrete” and discreteType “number”, in some cases, the discreteType and the raw discrete values would not be copied correctly.

#### Dashboards app: Double scrollbars in dashboard with State component \[ID_27272\]

If a dashboard contained a State component, in some cases double scrollbars could be displayed.

#### DataMiner Cube - Trending: Problem when calculating trend predictions \[ID_27292\]

When calculating trend predictions on a more general level (e.g. daily), in some cases, the algorithm would not take into account missing values. Hence, it would incorrectly assume that a repeating pattern found on the more general level was also found on the more detailed level.

#### Dashboards app: Dashboard grid not resized \[ID_27293\]

In some cases, it could occur that the dashboard grid was not resized when necessary.

#### Dashboards app: Duplicate “Delete component” button \[ID_27295\]

When a dasboard contained a Group component, it could occur that two *Delete component* buttons were displayed when the dashboard was in edit mode.

#### Interactive Automation scripts: Problems with the UIBlockDefinition.IsEnabled and UIBlockDefi­nition.InitialValue properties \[ID_27326\]

Up to now, UIBlockDefinition.IsEnabled was not applied for blocks of type “checkbox”. From now on, a block of type “checkbox” will be disabled when the UIBlockDefinition.IsEnabled property is set to False.

Also, UIBlockDefinition.InitialValue was not applied correctly for blocks of type “calendar” when the value was not a valid ISO string. From now on, the UIBlockDefinition.InitialValue property will be ignored and the datetime picker block will be constructed based on the DMAAutomationUICalendarComponent.Timestamp property, which will contain the UTC time stamp the InitialValue represents.

#### Dashboards app: Problems with the color picker \[ID_27329\]\[ID_27365\]

A number of issues have been fixed with regard to the color picker.

#### Dashboards app: Navigation pane issue after refresh in edit mode \[ID_27339\]

If you exited edit mode in the Dashboards app after refreshing while edit mode was active, all folders in the navigation pane were collapsed and the current dashboard was no longer indicated as selected.

#### Dashboards app: Minor issues with time range feed \[ID_27357\]

The following minor issues could occur with a time range feed component in a dashboard:

- In some cases, the clock icon was not displayed next to the time summary.

- It could occur that the configuration pane of the time range feed was not correctly aligned with the time summary.

#### DataMiner Cube - Profiles app: “Modified” label would not disappear after saving \[ID_27373\]

When, in the *Profiles* app, you saved a profile definition, a profile instance or a profile parameter, in some cases, the “Modified” tag would incorrectly not disappear.

#### Dashboards: Problem when changing the theme \[ID_27398\]

When, in the Dashboards app, you changed the theme, the colors of certain components (e.g. analog clock, digital clock,...) would not be changed accordingly.

#### Problem when a QAction launched an Automation script immediately after the element had been started \[ID_27431\]

When a QAction launched an Automation script immediately after the element had been started, in some cases, an exception could be thrown.

#### DataMiner Cube: Not possible to filter tables on display value \[ID_27490\]

In the quick filter boxes for tables in DataMiner Cube, previously it was only possible to filter on the raw value of the cells, i.e. the value used by the protocol, which is not necessarily the same as the displayed value. Now filtering on the displayed value is also possible.

#### Problem when renaming DVE elements \[ID_27494\]

When you renamed a DVE element, in some cases, the element name would incorrectly not get updated.

#### Jobs app: When applying a template, job section fields of type “User” would incorrectly not be overwritten \[ID_27495\]

When, in the Jobs app, you applied a template to a job, values in job section fields of type “User” would incorrectly not get overwritten with the values from the template.

#### Dashboards app - Image component: Image selection box would incorrectly also contain non-image files \[ID_27510\]

When, in the Dashboards app, you added an image component and opened the image selection box on its *Settings* tab, in some cases, the selection box would list all files found in the C:\\Skyline DataMiner\\Dashboard\\\_IMAGES\\ folder, including files that were not images. From now on, the image selection box will only list image files.

#### Dashboards app: Table in visual overview component not filtered correctly \[ID_27517\]

When a visual overview component was used in a Dashboards app, it could occur that a table in the visual overview was not filtered properly.

#### Dashboards app: Problem with line chart component displaying resource capacity information \[ID_27526\]

When a line chart component in a dashboard was configured to display resource capacity information, and no data was displayed for the current timespan, a problem could occur if you selected the *Use percentage based units* option in the *Settings* pane.

#### DataMiner Cube - Visual Overview: No log entry would get created when a Visio shape con­tained a reference to an element on a disconnected DMA \[ID_27527\]

No log entry would get created when a Visio shape displaying a chart contained a reference to an element located on a disconnected DataMiner Agent.

#### DataMiner Cube - Visual Overview: Memory leak caused by alarm shapes not getting cleaned up properly \[ID_27550\]

In some cases, alarm shapes created as part of a Children shape would not get cleaned up properly.

#### DataMiner Cube start window: Entering text in the Arguments text box could resize the UI \[ID_27559\]

When, in the DataMiner Cube start window, you edited an agent entry, in some cases, the UI could get resized incorrectly when entering text in the *Arguments* text box.

#### DataMiner Cube - Services app: Problem when trying to assign a service profile instance to a profile instance with a parameter of type “capability” \[ID_27580\]

When you tried to assign a service profile instance to a profile instance with a parameter of type “capability” (exclusively), in some cases, an exception could be thrown.

#### Dashboards app: Line chart component would not draw the trend graph of a resource capacity \[ID_27606\]

In some cases, a line chart component would not draw the trend graph of a resource capacity.

#### Service & Resource Management: Parameters of type double in generated SRM protocols will now have their lengthtype set to “next param” instead of 8. \[ID_27617\]

Up to now, parameters of type double in generated SRM protocols would have their rawtype set to “numeric text” and their lengthtype set to 8. As a result, if a parameter of a generated SRM protocol contained a value of more than 8 characters, that value would incorrectly be replicated to 0.

From now on, parameters of type double in generated SRM protocols will have their lengthtype set to “next param” instead.

#### Dashboards app: Problem with Auto-select all indices option for Parameter feed component \[ID_27623\]

In the Dashboards app, if the *Auto-select number of indices* option was selected for a Parameter feed component, it could occur that the *Auto-select all indices* option did not work.

#### Jobs app: Problem when no domains were configured \[ID_27635\]

When no domains had been configured, in some cases, the jobs list would incorrectly keep loading. Also, when you refreshed an empty jobs list, a “page not found” error would be displayed.

> [!NOTE]
> Up to now, when no domains were configured, a popup message would be displayed, asking you to create one. From now on, visual indication and a button will be displayed instead.

#### FileInfoManager: Problem when handling production protocols \[ID_27645\]

In some cases, FileInfoManager would handle production protocols incorrectly.

Also, Automation script IDs will now be case insensitive.

#### SLAnalytics: Problem when updating behavioral anomaly detection suggestion events \[ID_27646\]

In some cases, updates to behavioral anomaly detection suggestion events would contain an incorrect root alarm ID. As a result, a second suggestion event would be created and linked to the same change point. Also, after two hours, only the original alarm would be cleared.

#### Jobs app: Loading problem when selecting the already selected job domain in configuration mode \[ID_27651\]

When, in configuration mode, you selected the job domain that was already selected, in some cases, the loading indicator would remain visible indefinitely.

#### Interactive Automation scripts: Problem when a text box had its wantOnChange setting set to true and its value set to an empty string \[ID_27666\]

When a text box in an interactive Automation script had its wantOnChange setting set to true and its value set to an empty string, in some cases, an exception could be thrown.

#### Mobile apps: Problem with time range quick pick buttons \[ID_27676\]

In the Dashboards app and other DataMiner mobile apps, it could occur that the quick pick buttons of a time range selector did not function correctly.

#### Dashboards app: Problem when pivot table component displayed table parameters with same table index values \[ID_27687\]

In case a pivot table component of a dashboard displayed different table parameters of which the table index values were the same, it could occur that the table index was displayed instead of parameter names.

#### DataMiner Cube - Trending: Problem when exporting a trend graph to a CSV file \[ID_27708\]

When you select the *Line graph instead of block graph* option when exporting a trend graph to a CSV file, the timestamps of the average data points are put halfway between two points.

In some cases, when you exported a trend graph multiple times in a row using that line graph option, the timestamps would incorrectly keep shifting in the direction of the future.

#### DataMiner Cube - Trending: Numbers smaller than 1 could be missing their decimal separator \[ID_27717\]

In some cases, trend data numbers smaller than 1 could be missing their decimal separator.

#### Automatic incident tracking: Problem when removing the IDP location from elements with active alarms \[ID_27723\]

On a system using automatic incident tracking on which DataMiner Infrastructure Discovery Provisioning (IDP) was deployed, in some cases, when the IDP location of an element with active alarms was removed, that location would not be removed correctly. This would cause certain alarms to be grouped by an empty location.

> [!NOTE]
> From now on, IDP location grouping requires that the *Make this property available for alarm filtering* option is activated for the following element properties: IDP, Location Name, Location Building, Location Floor, Location Room, Location Aisle and Location Rack.

#### Dashboards app: Pivot table component showed an error message \[ID_27724\]

In the Dashboards app, the pivot table component would show the following error message:

```txt
Error trapped: 'Skyline.DataMiner.Web.Common.IPersistentConnectionContainerEx' does not contain a definition for 'GetElementProtocol'
```

#### Service & Resource Management: Problem when rebinding a VirtualFunctionResource \[ID_27735\]

When a VirtualFunctionResource was unbound, in some cases, it would still be processing parameter sets from its bound element. This would cause the parameters of the unbound element to no longer be in an “uninitialized” state. Instead, they would incorrectly stay set to the last received value from the bound element.

#### Interactive Automation scripts: MinWidth, MaxWidth, MinHeight and MaxHeight properties of UIBlock components would not be parsed correctly \[ID_27736\]

In some cases, the MinWidth, MaxWidth, MinHeight and MaxHeight properties of UIBlock components would not be parsed correctly.

#### Dashboards app: Problem when grouping parameter data \[ID_27755\]

When grouping parameter data in components that support parameter data grouping, in some cases, an error could be thrown when you selected either “by element” or “all together” while some of the grouped parameters were single-value parameters without an index.

#### DataMiner Cube: Problem when opening a ListView component containing bookings \[ID_27780\]

In some cases, a KeyNotFound exception could be thrown when you opened a ListView component that contained a list of bookings.

#### Problem with SLDataMiner at startup when no NICs could be found \[ID_27799\]

In some cases, an error could occur in SLDataMiner at startup when no NICs could be found.

#### Jobs app: Empty drop-down boxes when creating/editing job \[ID_27810\]

When a job was created or edited in the Jobs app, it could occur that no items were displayed in drop-down boxes.

#### SLAnalytics: Problem when opening a trend graph on a system using pattern matching \[ID_27829\]

On a system using pattern matching, in some cases, an error could occur in SLAnalytics when you opened a trend graph.

#### Dashboards app - Line chart component: Problems when retrieving trend data \[ID_27853\]

In some cases, a trend graph legend would show an error when a trend data request was interrupted, e.g. by scrolling to another page before the current page was fully loaded.

Also, when multiple trend requests were required, in some cases, those requests would be ignored when a trend data request was already in progress.

#### Service & Resource Management: When an unbound Virtual Function Resource was deleted, the replication connection was incorrectly not removed \[ID_27857\]

When an unbound Virtual Function Resource was deleted, in some cases, the replication connection would incorrectly not be removed.

#### DataMiner Cube - Profiles app: Service profiles could not be deleted when linked to a profile instance \[ID_27860\]

In some cases, it would not be possible to delete a service profile, especially when a profile instance had a link to it. In the profile instance editor, the service profile selection box now contains a “\<None>” entry. This will allow the link to the service profile instance to be severed.

Also, in some cases, the Profiles app would not load service profile objects.

#### Dashboards app - Line chart component: Trend graph incorrectly showed primary key instead of display key \[ID_27879\]

When a table parameter had a display key that was different from the primary key, up to now, the trend graph would incorrectly show the primary key. From now on, it will show the display key instead.

#### Dashboards app - Pivot table component: Problem with conditions \[ID_27897\]

When a pivot table component had conditions configured, in some cases, those conditions would incorrectly only work in conjunction with table column parameters, not with single-value parameters.

Also, a selection box problem could occur when multiple conditions were configured in the “Configure indices” section.

#### Automation: Problem when retrieving information events from all DMAs \[ID_27903\]

When, in a DataMiner System with multiple agents, information events were retrieved by an Automation script, in some cases, not all information events would be retrieved.

#### DataMiner Cube - Correlation: Number of occurrences in “Sliding window” section could incor­rectly not be changed \[ID_27909\]

When you tried to define that a correlation rule had to be triggered when a situation occurred a specific number of times in a specified period of time, in some cases, it would not be possible to change the default number of times (i.e. 1).

#### DataMiner Cube would constantly try to reconnect due to a problem that occurred while serial­izing alarm metadata in proactive suggestion events \[ID_27927\]

Due to a problem that occurred while serializing alarm metadata in proactive suggestion events, in some cases, DataMiner would constantly try to reconnect.

#### Dashboards app - Time range component: Default range would be used even after being over­written afterwards \[ID_27941\]

If the default values of a time range component had been set to a custom range, in some cases, those values would incorrectly still be used after being overwritten afterwards (e.g. by means of URL arguments or another feed).

#### Jobs app: Job section fields would not be displayed in the correct order \[ID_27943\]

When editing a job, in some cases, the fields of a particular job section would not be displayed in the order in which they were defined in the job domain.

#### Dashboards app: Table component would not be rendered correctly in a PDF report \[ID_27958\]

In some cases, a table component would not be rendered correctly in a PDF report.

#### DataMiner Cube - Trending: Rounding issue when exporting a trend graph to CSV \[ID_27980\]

When you exported a trend graph to CSV with the *Line graph instead of block graph* option selected, in some cases, the timestamps would be off by a second due to a rounding error.

#### DataMiner Cube - Visual Overview: Save button no longer working in embedded Service Man­ager component \[ID_28003\]

In an embedded Service Manager component, in some cases, the Save button would no longer work.

#### DataMiner Cube - Alarm Console: Problem with “unread alarms” counter \[ID_28063\]

In some cases, the number of unread alarms displayed in the header of an alarm tab would be incorrect, especially on history tabs, on filtered tabs or when e.g. masking an alarm immediately after it was set to read.

#### DataMiner Cube - Profiles app: “Based on” selection box would be empty \[ID_28089\]

When, in the *Definitions* tab of the Profiles app, you selected a profile definition and then clicked *Add* to select another profile definition in the *Based on* selection box, in some cases, that selection box would be empty.

#### Dashboards app: Share window would incorrectly be resized when you entered a message \[ID_28093\]

When you opened a dashboard, clicked *Start sharing*, and entered a message, in some cases, the *Share* window would incorrectly be resized.

#### DataMiner Cube - Profiles app: Regular expression of a profile instance parameter would incor­rectly not be checked \[ID_28094\]

In the Profiles app, it is possible to define a parameter of type text and add a regular expression that values have to match.

When such a parameter was added to a profile instance, in some cases, when its value was changed, the regular expression would incorrectly not be checked and all values would be allowed.

#### DataMiner Cube - Visual Overview: ListView filter would not reapply conditions when new items were added \[ID_28095\]

When a ListView component listing elements or services had an external filter applied, the filter would incorrectly not be reapplied when new items were added to the list.

#### Dashboards app: Problems with table component \[ID_28146\]

A number of problems have been fixed with regard to the table component.

In some cases, for example, rendering issues could occur when resizing table columns.

#### Dashboards: Problems with CPE feed \[ID_28157\]

When you selected a CPE filter, in some cases, the raw key would incorrectly be displayed for a short while.

Also, when you selected a chain filter (e.g. Region) and a value (e.g. California), and then selected another chain filter and value, in some cases, nothing would be displayed and an error would occur.

#### Ticketing app: Problem when creating a ticket \[ID_28167\]

In some cases, a null reference exception could be thrown when creating a ticket.

#### DataMiner Cube: EPM manager would incorrectly show the base table on a KPI popup \[ID_28194\]

When a field was defined on a base table while the topology cell was defined on a view table based on that base table, in some cases, a KPI popup on the field in question would incorrectly display the base table instead of the view table.

#### DataMiner Cube - Alarm Console: Problem when opening an active alarms tab containing cor­relation alarm details \[ID_28232\]

In some cases, an error could occur when you opened an active alarms tab that contained correlation alarm details.

#### Dashboards app: Components could not be moved in a Chromium web browser due to a spacing problem \[ID_28260\]

When using the Dashboards app in a Chromium web browser, in some cases, a lack of spacing around the components would prevent you from moving them.

#### DataMiner Cube: EPM card would not open when no topology cell was linked to the filter \[ID_28272\]

When an EPM field was defined on a table without a chain topology cell, in some cases, it would not be possible to launch an EPM card of an item in this field from the *Topology* tab in the sidebar.

#### SLAnalytics: Problem when trying to process a parameter update for a non-existing parameter \[ID_28282\]

In some case, an error could occur in SLAnalytics when trying to process a parameter update for a non-existing parameter.

#### Ticketing app: Headers would incorrectly not be cleared when switching domains \[ID_28291\]

In the Ticketing app, in some cases, headers would not be cleared when you switched domains.

#### Web Services API v0: Serialization error when using the GetActiveAlarmsFromView and GetAc­tiveAlarmsFromElement methods \[ID_28293\]

Due to a serialization error, in some cases, the following Web Services API v0 methods would no longer work:

- GetActiveAlarmsFromView

- GetActiveAlarmsFromElement

#### Interactive Automation scripts: Equals signs not accepted in UI block values \[ID_28324\]

In some cases, equals signs (“=”) could not be used in UI block values.

#### Failover: Configuration issues \[ID_28378\]

In a Failover setup, in some cases, an error could occur when no ElasticSearch database was found.

Also, in some cases, configuration updates would be ignored after a Failover switch.

#### Assembly incorrectly configured in SLNet.exe.config file \[ID_28408\]

In the SLNet.exe.config file, an assembly was configured incorrectly.

#### Dashboards app - GQI: Problem with the query builder \[ID_28415\]

In the Dashboards app, in some cases, errors could occur when building a query.

#### Dashboards app: Problem with charts in PDF reports \[ID_28449\]

In PDF reports, the alarm top component would not show the grid lines and the generic bar charts would not position properly due to a CSS issue.

#### DataMiner Cube - Visual Overview: Booking shape timers would not get updated every second when the shape was being displayed \[ID_28453\]

In a booking shape, timers can show remaining time, elapsed time, etc. However, in some cases, those timers would not get updated every second when the shape was being displayed.

#### Deserialization exceptions during file offload \[ID_28481\]

During a file offload, in some cases, a large number of deserialization exceptions could be written to the SLDBConnection.txt log file.

#### DataMiner Cube: Problem when opening the Protocols & Templates app \[ID_28529\]

In some cases, an error could occur when you opened the Protocols & Templates app.

#### DataMiner Cube - Alarm Grouping: Problem when changing the polling IP address of an element associated with an alarm \[ID_28563\]

When the polling IP address of an element with a timeout alarm was changed, in some rare cases, the timeout alarm would incorrectly be linked to the old IP address instead of the new one. This would then lead to an incorrect grouping of alarms.

#### DataMiner Cube - Trending: Problem with percentile line \[ID_28565\]

When you added an additional trend line to an existing trend graph with one parameter, and then removing the original parameter, in some cases, the percentile line would no longer be visible.

#### Dashboards app - GQI: Problem when creating new queries due to file locking issue \[ID_28636\]

Due to a file locking issue, in some cases, it would not be possible to create new queries.

#### HTML5 apps: Problem when the SAML response from the identity provider contained line breaks \[ID_28671\]

When an HTML5 app (Dashboards, Monitoring, Job, Ticketing, etc.) received a SAML response from the identity provider, in some cases, an error could occur when that response contained line breaks.

#### Problem in SLDataMiner if Protocol.xml.lnk file linked to unavailable path \[ID_28715\]

A problem could occur in the SLDataMiner process if a protocol production version Protocol.xml.lnk file linked to a path that could not be reached.

#### DataMiner Cube - Services app: Capacity/capability value override would not be saved correct-ly \[ID_28721\]

When, in a service profile instance, you overrode the capacity of a parameter, the update would not be saved correctly when you had set the value to 0.

#### DataMiner Cube - Services app: Discard button would not be enabled after including or exclud­ing a service profile definition parameter \[ID_28741\]

When, in the *Services* app, you included or excluded a service profile definition parameter in the *By node* tab, in some cases, the Discard button would incorrectly not be enabled.

#### DataMiner Cube - Alarm Console: Alarms in alarm tab of type “Active alarms linked to cards” would be filtered incorrectly when opening an EPM card \[ID_28780\]

When, in your Alarm Console, you had an alarm tab of type “Active alarms linked to cards”, in some cases, when you opened an EPM card, the alarms in that alarm tab would not be filtered correctly. Also, the name of the alarm tab would not be displayed correctly.

#### Re-installation of NAS/NATS services would fail \[ID_28781\]

When the NAS and NATS services had been deleted manually, in some cases, re-installing those services would fail.

#### HTML5 apps: Problem with internal API calls when fetching data \[ID_28830\]

When working with HTML5 apps like Ticketing or Jobs, in some cases, the internal API calls ObserveTickets, ObserveJobs and ObserveBookings could throw an exception when fetching data.

#### Problem with SLDataMiner when loading protocols \[ID_28833\]

In some cases, an error could occur in the SLDataMiner process when loading protocols.

#### Locking issues in SLNet, SLASPConnection and SLDMS \[ID_29050\]

In some cases, locking issues could occur in the SLNet, SLASPConnection and SLDMS processes.

## Addendum CU1

### Enhancements

#### Dashboards app - GQI: Column selection enhancements \[ID_28202\]

When building a GQI query, it is now possible to click the up and down arrows on the right to make a column swap places with the column above or below it.

Also, by clicking the up and down arrows while holding the CTRL key, you can make a column swap places with the nearest selected column above or below it.

> [!NOTE]
> - Columns marked as a datasource’s default columns will be selected by default.
> - When a column selector node with values is reloaded (e.g. when an existing query is opened), the selected columns will be displayed before the unselected ones.

#### SLReset will now reset the backup agent to its factory settings when it is taken out of a  Failover configuration \[ID_28456\]

When the two DMAs in a Failover configuration were taken out of that configuration, up to now, the backup agent had to be cleaned manually. From now on, SLReset will automatically reset the backup agent to its factory settings.

#### SLDMS: Enhanced processing of DMS_SECURITY_NO_FORWARD messages \[ID_28796\]

Due to a number of enhancements, the way in which SLDMS processes DMS_SECURITY_NO_FORWARD messages has been optimized.

#### DataMiner Cube - Visual Overview: Unselecting a table row with the SingleSelection option enabled will now also clear the session variable \[ID_28848\]

In situations involving a table with columns that have a SelectionSetVar option configured and an embedded table control in Visual Overview with a SingleSelection option specified in its ParameterControlOptions data field, up to now, the session variable would not be updated when the selection was cleared.

From now on, the session variable will be cleared when you click the selected table row while holding down the CTRL key.

#### DataMiner Cube: SurveyorSearchText session variable will now be cleared when the advanced search tab is closed \[ID_28851\]

With the SurveyorSearchText session variable, you can configure a shape to display the most recently used search entry in the Surveyor, or to trigger a search in the Surveyor with a particular search entry.

From now on, this session variable will be cleared when the advanced search tab is closed.

#### DataMiner Cube - Services app: Enhanced performance when fetching profile definitions and profile instances \[ID_28870\]

Due to a number of enhancements, overall performance has increased when fetching profile definitions and profile instances in the Services app.

#### Size of C:\\Skyline DataMiner\\Logging\\MiniDump folder limited to 1 GB or 100 files \[ID_28879\]

The size of the C:\\Skyline DataMiner\\Logging\\MiniDump folder is now limited to 1 GB or 100 files (whichever is larger).

When a new ZIP file is created when the folder size is at its limit, the oldest ZIP file(s) in the folder will automatically be deleted.

#### DataMiner Cube - Visual Overview: Parameter value will now be cleared from the shape text when the dynamic part of its Parameter shape data field changes \[ID_28901\]

When a dynamic part of a Parameter shape data field changes, from now on, the existing parameter value will by default be cleared from the shape text.

If you do not want this to happen, then add ClearValueOnSubscriptionChange=False in the shape’s Options data field:

| Shape data field | Value                                |
|------------------|--------------------------------------|
| Options          | ClearValueOnSubscriptionChange=False |

#### Cassandra: Logging will now include health status transitions and failed queries \[ID_28913\]

Cassandra health status transitions and failed queries will now also be logged in the SLDBConnection.txt log file.

#### DataMiner Cube: EPM card enhancements \[ID_28931\]

In DataMiner Cube, a number of general enhancements have been made to EPM cards.

#### DataMiner Cube: Enhanced performance during startup due to optimized creation of virtual function icons \[ID_28936\]

At startup, DataMiner Cube retrieves all virtual functions of all protocols and creates icons to graphically indicate the existence of those functions. Due to an optimization of this icon creation process, overall performance has increased during startup.

#### Sidebar: New help button to open DataMiner Dojo menu \[ID_28990\]

At the bottom of the sidebar, you can now click a help button that will open a menu containing links to the following pages on DataMiner Dojo:

| Menu command    | Page on DataMiner Dojo                                                                        |
|-----------------|-----------------------------------------------------------------------------------------------|
| Blog            | <https://community.dataminer.services/blog/>                |
| Questions       | <https://community.dataminer.services/questions/>           |
| Learning        | <https://community.dataminer.services/learning/>            |
| Resources       | <https://community.dataminer.services/documentation/>       |
| Suggest feature | <https://community.dataminer.services/feature-suggestions>  |

#### Jobs app: PDF configuration & preview \[ID_28994\]

In the Jobs app, clicking the PDF button will now open a pop-up window where you can view a preview of the PDF and configure its settings. You can specify the PDF title and subject, select whether your company information, your company logo, and/or page numbers should be included, and customize the PDF width.

#### DataMiner Cube - Alarm Console: Enhanced performance when updating the source values of a Correlation base alarm \[ID_29020\]

Due to a number of enhancements, overall performance has increased when updating the source values of a Correlation base alarm.

#### Dashboards app - GQI: Empty parameter values in query results will now be displayed as “Not initialized” \[ID_29045\]

In GQI query results, from now on, empty parameter values will be displayed as “Not initialized”.

#### Failover: Enhanced version check during synchronization \[ID_29077\]

When two agents in a Failover setup synchronize, their DataMiner versions are compared to make sure those versions are compatible. A number of enhancements have now been made to this version check.

### Fixes

#### Problem when multiple network interfaces shared the same MAC address \[ID_27971\]

When multiple network interfaces shared the same MAC address, in some cases, DataMiner would not be able to correctly detect those interfaces.

#### Dashboards app: Trend statistics components would not show any content when part of a PDF report \[ID_28286\]

In a PDF report, in some cases, trend statistics components would not show any content.

#### Service & Resource Management: Exported protocol would show incorrect parameters after a new function file had been activated \[ID_28290\]

When a new function file was activated, which updated parameters for a particular function, in some cases, the exported protocol would incorrectly show the old parameters.

#### Dashboards app: Problem with Stack components option when generating a PDF report \[ID_28362\]

In the Automation, Correlation and Scheduler modules, you can generate a report based on a dashboard from the new Dashboards app. Up to now, in some cases, it would not be possible to generate such a report when the *Stack components* option had not been selected.

#### DataMiner Cube: Problem when navigating using breadcrumbs \[ID_28468\]

In some cases, the overall element state of a partially included element would incorrectly be visible in the breadcrumbs. Also, users would incorrectly be able to open the full element via the breadcrumbs, even when they did not have full access to that element.

And when they used the breadcrumbs to navigate to the element via the service child, the element would incorrectly be opened instead of the service.

#### Alarm templates: Problem when calculating the transition from one week to the next \[ID_28477\]

In some cases, an error could occur when, in the alarm template schedule, the transition from one week to the next was calculated.

#### Problem when updating DVE protocols \[ID_28561\]

When an existing DVE protocol was updated, in some cases, the update would fail.

#### Service & Resource Management: DecimalQuantity property of CapacityUsageParameterValue incorrectly saved without decimals \[ID_28582\]

When the DecimalQuantity property of the CapacityUsageParameterValue of a Profile-Instance was specified, in some cases, the decimals would be lost was the ProfileInstance was saved in the Elasticsearch database.

#### Problem when trying to take a backup of an Elasticsearch database while Elasticsearch security is enabled \[ID_28679\]

In some cases, an error could be thrown when trying to take a backup of an Elasticsearch database while Elasticsearch security was enabled.

#### Correlation: Correlation rules would incorrectly be triggered by empty alarms \[ID_28680\]

In some cases, correlation rules would incorrectly be triggered by empty alarms, causing emails to be sent with unresolved placeholders.

#### Remote connections would incorrectly get removed from the local cache of a DMA when it lost its connection to another DMA \[ID_28760\]

When a DMA temporarily lost its connection to another DMA, in some cases, remote connections of other DMAs would incorrectly also get removed from its local cache.

#### Timetrace data would become incorrect when an element had been dynamically included in or excluded from a service \[ID_28777\]

When an element had dynamically been included in or excluded from a service while active alarms were present, in some cases, the alarm count for the service in timetrace would start to show an incorrect value.

Also, when an element was excluded from a service while it had active alarms, in some cases, SLDataGateway would incorrectly consider the alarm reference to have an impact on the service. When the alarm was cleared while the element was excluded, it would never be removed from the service alarm impact list. As a result, that list could keep growing, which would eventually lead to an overall decrease of the alarm handling performance.

#### DataMiner Cube: Element name and icon would be incorrectly be visible in the alarm card and the alarm details when you did not have explicit access to the element \[ID_28778\]

In some cases, alarms for an element that is partially included in a service would be visible in the Alarm Console even when you did not have explicit access to that element. Also, when you opened the alarm card or the alarm details of one of those alarms, the element icon, alarm state and name would be displayed.

From now on, this will no longer the case when you do not have access to the element itself. Also, you will no longer be able to an element card of an element to which you do not have explicit access.

#### DataMiner Cube - Trend templates: Problem with “Allow offload database configuration” set­ting \[ID_28794\]

When, in a trend template, you changed the Allow offload database configuration setting, in some cases, the setting would not be applied correctly.

#### Trending - MySQL: parameterName column in Offload database contained incorrect data \[ID_28824\]

In some cases, the parameterName column in an offload database of type MySQL would contain incorrectly concatenated values. They would contain parameterName + chIndex instead of parameterName + displayKey.

#### Problem when launching Automation scripts when switching elements in a redundancy group that contained DELT elements \[ID_28832\]

When Automation scripts were launched when switching elements in a redundancy group of which either the primary or backup elements were DELT elements, in some cases, it would not be possible to pass \<Any Primary> or \<Any backup> as dummies.

#### DataMiner Cube - Alarm Console: Problem when deleting elements during an alarm storm \[ID_28836\]

When, during an alarm storm, you deleted an element, in some cases, the alarm storm prevention mechanism would incorrectly keep taking the alarms of that element into account.

Also, when, during an alarm storm, you deleted an element with a large number of alarms, in some cases, the alarm counter would start to show an incorrect value.

#### DataMiner Cube - Services app: UI selections would be lost after saving or discarding changes made to a service profile definition \[ID_28839\]

When, in the Services app, you saved or discarded changes made to a service profile definition, in some cases, the selections you made in the UI would be lost.

#### Element log file would not be properly restarted on element restart \[ID_28841\]

In some cases, the element log file would not be properly restarted on element restart.

#### SLNet cache would throw exceptions when receiving NULL data \[ID_28859\]

In some cases, the SLNet cache would thrown exceptions when receiving NULL data. In DataMiner, those exceptions would then appear as alarms of type error.

From now on, the SLNet cache will ignore any NULL data it receives.

#### DataMiner Cube: Problem when opening the Bookings app while being connected to a system with a MySQL database \[ID_28861\]

When, in DataMiner Cube, you opened the Bookings app while being connected to a system with a MySQL database, in some cases, an error could be thrown.

#### Problem with SLAutomation when an interactive Automation script was communicating with a client app \[ID_28862\]

When an interactive Automation script was communicating with the client app, in some cases, an error could occur in SLAutomation.

#### Service & Resource Management: Problem when saving or updating a service profile definition after defining virtual function IDs \[ID_28868\]

Due to an incorrect ID check, in some cases, it would not be possible to create or update a service profile definition after defining virtual function IDs.

#### DataMiner Cube - Interactive Automation scripts: Multiple “Continue” messages would be sent to the DataMiner Agent \[ID_28872\]

When an interactive Automation script was running, DataMiner Cube would incorrectly send multiple identical “Continue” messages to the DataMiner Agent. In some cases, this would cause an error in SLAutomation.

#### DataMiner Cube - Visual Overview: Problem when pressing CTRL+TAB while an item inside a Visio page had the focus \[ID_28876\]

When you pressed CTRL+TAB while an item inside a Visio page had the focus, in some cases, an exception could be thrown.

#### DataMiner Cube - Services app: Incorrect service definition data was displayed after saving a new service definition \[ID_28882\]

When, in the Services app, you saved a newly created service definition, in some cases, the UI would still display data belonging to the service definition that was selected before.

#### Legacy Reporter: Service definition image in the “Booking Details” report would exceed the width of the report \[ID_28886\]

In the legacy Reporter, the service definition image in the “Booking Details” report would exceed the width of the report. That image has now been assigned a maximum width.

#### Problem in SLElement when recalculating alarm statuses while retrieving view data \[ID_28892\]

In some cases, an error could occur in SLElement when recalculating the alarm status for virtual function impact changes while retrieving view data.

#### Dashboards app: The contents of PDF reports would incorrectly be uploaded to the DMA twice \[ID_28895\]

When a PDF report was generated in the Dashboards app, the contents of that report would incorrectly be uploaded to the DMA twice.

#### Failover: Problem with failing heartbeats when agents were unreachable \[ID_28900\]

When checking Failover agent connectivity through heartbeats, failures could be registered even when the heartbeats succeeded. In some cases, this could lead to “Failing Heartbeat Path” notices being toggled indefinitely.

#### Problem when a cell in a table included in a virtual function was invalidated while the state of the service that included the virtual function was being changed \[ID_28911\]

In some cases, an error could occur when a cell in a table that was included in a virtual function was invalidated while the state of the service that included the virtual function was being changed.

#### DataMiner would no longer be able to connect to Cassandra after running SLReset \[ID_28925\]

After running the SLReset tool, in some cases, DataMiner would no longer be able to connect to a Cassandra database.

#### DataMiner Cube: Scheduler permissions would not include the timeline \[ID_28944\]

Up to now, the user permissions that control access to the Scheduler app would incorrectly not control access to the timeline view.

The following table lists the timeline actions users will now be allowed to perform when they have been granted a particular Scheduler user permission.

| User permission                 | Action a user is allowed to perform              |
|---------------------------------|--------------------------------------------------|
| Modules \> Scheduler \> Add     | Drop events on the timeline.                     |
| Modules \> Scheduler \> Delete  | Delete events on the timeline.                   |
| Modules \> Scheduler \> Edit    | Edit or move events on the timeline.             |
| Modules \> Scheduler \> Execute | Manually start or stop an event on the timeline. |

#### DataMiner Cube: Profiles app would incorrectly try to load service profiles on a non-SRM system \[ID_28947\]

When opening the Profiles app, in some cases, it would incorrectly try to load service profiles on a non-SRM system.

#### Service & Resource Management: Problem with GetEligibleResources calls \[ID_28960\]

In some cases, a GetEligibleResources call could incorrectly return resources that were not available due to a concurrency overflow.

Also, in some cases, a GetEligibleResources call would not return resources that were available because the system would incorrectly think no more capacity was available.

#### DataMiner Cube: A “debug.log” file would incorrectly be created when initializing the CefSharp library \[ID_28963\]

In some cases, a “debug.log” file would incorrectly be created in the %LocalAppData%\\Skyline\\DataMiner\\DataMinerCube folder when the CefSharp library was initialized.

#### Dashboards app: A “debug.log” file would incorrectly be created when generating a PDF report via Automation \[ID_28969\]

In some cases, a “debug.log” file would incorrectly be created in the C:\\Skyline DataMiner\\Files folder when a PDF report was generated via Automation.

#### Problem with SLNet due to a NATS issue \[ID_28972\]

In some rare cases, a NATS issue could cause an error to occur in SLNet.

#### Problem with overall performance of SLNet connections \[ID_28976\]

In some cases, the overall performance of connections between SLNet and DataMiner clients would decrease.

#### DataMiner Cube - Alarm Console: Problem when using the history slider on systems with a Cas­sandra database \[ID_28982\]

When, on a system using a Cassandra database, you moved the history slider, in some cases, the HistoryAlarmRequest that was sent would contain an incorrectly converted timestamp.

#### Dashboards app: Problem when deleting GQI queries \[ID_29017\]

In some cases, it was not possible to delete GQI queries.

#### DataMiner landing page: Clicking the waffle icon did not open the sidebar \[ID_29050\]

When you clicked the waffle icon in the top-left corner of a DataMiner landing page (i.e. https://\<DmaAddress>/root/), in some cases, the sidebar listing the available apps would not open.

#### Updating an element via a CSV export/import would not work properly when that element had an empty port type value \[ID_29052\]

When an element had an empty port type value, in some cases, trying to edit that element by exporting its data to a CSV file and then importing the updated CSV file would not work as expected.

#### Problem when assigning an alarm template group to a DVE element \[ID_29063\]

When you assigned an alarm template group to a DVE element, no alarms would be generated.

#### ProtocolThread run-time error could occur when an element with a serial connection was paused \[ID_29083\]

In some cases, a ProtocolThread run-time error could occur when an element with a serial connection was paused.

#### Memory leak in SLXml when registered objects were removed \[ID_29091\]

In some cases, the SLXml process could leak memory when registered objects were removed.

#### DataMiner Cube - Alarm Console: Incorrect alarm count when loading a history tab with an ele­ment filter while some alarms in the time range were still active \[ID_29106\]

When you loaded a history tab with an element filter while some of the alarms in the selected time range were still active, in some cases, the tab header would show an incorrect alarm count.

#### Failover: LDAP notification setting would incorrectly be ignored when synchronizing Data­Miner.xml \[ID_29117\]

In a Failover setup, in some cases, the notification attribute of the LDAP element would incorrectly be ignored when synchronizing the DataMiner.xml file between the two Failover agents.

#### SLAutomation: Problem when clearing the internal parameter cache \[ID_29165\]

In some cases, an error could occur in SLAutomation when its internal parameter cache was being cleared.

#### SLAnalytics: Problem when a connection was lost while handling a previous connection loss \[ID_29210\]

In some cases, an error could occur in SLAnalytics when a connection was lost while a previous connection loss was being handled.

## Addendum CU2

### Enhancements

#### Improved performance when writing trend data in Cassandra \[ID_27777\]

Performance has improved when writing trend data in the Cassandra database, both for single Cassandra nodes and Cassandra clusters.

#### Improved performance when writing data to file offload storage \[ID_28294\]

Performance has improved when data is written to the file offload storage while the Cassandra or Elasticsearch database is down.

#### Improved performance when writing and deleting data on single Cassandra node \[ID_28376\]

Performance has improved for all write and delete queries on single Cassandra nodes (not Cassandra clusters). This applies to all data handled by the SLDataGateway process, including alarms, trending, element data, etc.

#### Improved performance when deleting element data in database \[ID_28424\]

Performance has improved when deleting element data in a Cassandra or SQL database.

#### Cassandra: Enhanced method for restoring a Cassandra database backup \[ID_28485\]

From now on, a Cassandra database backup will be restored in the following way onto a DataMiner Agent with an existing Cassandra database:

1. Reset Cassandra to its factory default settings.

2. Delete the existing Cassandra data folder.

3. Restore the backup.

To restore a Cassandra database backup on a DataMiner Failover system with a Cassandra database, you will now have to proceed as follows:

1. End the DataMiner failover configuration as well as the Cassandra failover configuration.

2. Clear/reset the backup agent.

3. Restore the Cassandra database backup onto one of the two agents.

4. Set up the DataMiner Failover system again.

#### NATS: Enhanced log settings & offline Failover agents now prevented from becoming the primary NAS \[ID_28557\]

The settings controlling the NATS server logging have been adjusted. Debug logging is now disabled by default and a new log file will now be created whenever the size of the current one exceeds 3 MB.

Also, offline Failover agents will now be prevented from becoming the primary NAS.

#### Schedule configuration of BPA tests \[ID_29000\]

On the *Agents* > *BPA* page in System Center, you can now schedule when a BPA test should run. In the drop-down box in the *Schedule* column, you can select to run a test at different intervals, e.g. daily or every 12 hours.

#### Cache for SNMP inform messages \[ID_29034\]

To handle situations where inform messages are sent out again while they have already been acknowledged by DataMiner, DataMiner will now by default keep the latest 20 inform messages per SNMP entity in a cache, so that it can check whether an incoming inform message has already been processed, and discard it if this is the case.

In the *DataMiner.xml* file, you can customize how many inform messages are stored in the cache. To do so, set the *informCacheSize* attribute of the *SNMP* tag to the number of inform messages that should be stored. For example:

```xml
<DataMiner>
   ...
   <SNMP informCacheSize="25" />
   ...
</DataMiner>
```

> [!NOTE]
> - If you set *informCacheSize* to 0, the cache will be disabled.
> - Only inform messages are stored in this cache, not traps.
> - When an inform message is discarded, this is logged in *SLSNMPManager.txt* on information level 3.

#### Enhanced performance when assigning alarm templates with conditions used in multiple rules \[ID_29109\]

Due to a number of enhancements, overall performance has increased when assigning an alarm template to an element, especially when that alarm template contains conditions that are used in multiple rules.

#### SLLogCollector tool can now be accessed via the DataMiner Taskbar Utility \[ID_29154\]

You can now open the SLLogCollector tool by selecting *Launch \> Tools \> SLLog Collector* in the DataMiner TaskBar Utility.

#### DataMiner Cube: Warning message will now appear when you duplicate an SNMPv3 element from another DMA \[ID_29192\]

When you duplicate an SNMPv3 element from a DMA other than the one to which you are connected, from now on, a message box will appear, saying that you have to re-enter the SNMPv3 credentials for the newly created element.

> [!NOTE]
> No such message will be displayed when using either a credential library or the NoAuthNoPriv security level.

#### Enhanced loading and initializing of alarm templates \[ID_29236\]

A number of enhancements have been made with regard to the loading and initializing of alarm templates.

#### Database: File offload enhancements \[ID_29238\]\[ID_29245\]

Due to a number of enhancements, overall performance has increased when offloading data to a file.

Also, during file offloads, less disk space will be used.

#### “!! No link found for xxx\[xx\] -> xxxx” errors will now be logged in SLErrorsInProtocol.txt instead of SLErrors.txt \[ID_29264\]

Up to now, when a “!! No link found for xxx\[xx\] -> xxxx” error was generated by SLElement, that error would be logged in SLErrors.txt. From now on, this type of errors will be logged in SLErrorsInProtocol.txt instead.

#### SLElement: Enhanced error handling \[ID_29270\]

A number of enhancements have been made to the error handling in SLElement.

#### DataMiner Cube: Filter box in Documents app & Documents card pages \[ID_29298\]

In the *Documents* app and the *Documents* card pages, a filter box now allows you to filter the list of documents.

#### Enhancements to prevent “Messages have gone lost, making the connection invalid” errors from being thrown \[ID_29304\]

A number of enhancements have been made to prevent “Messages have gone lost, making the connection invalid” errors from being thrown.

#### DataMiner Cube - Visual Overview: New icons added to Icons stencils \[ID_29315\]

The following icons has been added to the Icons stencil:

- Airplane

- Android

- Apple TV

- Boat

- Browser.2

- Bus

- Car

- Chromecast

- Delete Connections

- Delete Element

- Discover Connections

- Download Configuration Back-Up

- House

- IOS

- Laptop

- Person

- Profile Manager

- Provision Connections

- Reapply CI Type

- Reassign CI Type

- Remove Filter

- Restore Default Configuration

- Train

- Unmanage Element

- Voice

#### DataMiner Cube: Enhancement made to “Skyline Black” theme \[ID_29370\]

A number of enhancements have been made to the “Skyline Black” theme, especially with regard to readability in the *Database* section of *System Center*.

#### “Saving report...” entry will no longer be added to SLWatchdog.txt when a Watchdog report has successfully been saved \[ID_29379\]

From now on, when a Watchdog report has successfully been saved, no “Saving report...” entry will be added to the SLWatchdog.txt log file anymore.

#### Enhanced performance of file synchronization operations \[ID_29401\]

When the internal file change repository of the SLDMS process reached a considerable size, up to now, overall performance of the file synchronization operations would decline.

Due to a number of enhancements, overall performance of the file synchronization operations has now been optimized.

### Fixes

#### DataMiner Cube: 'Migrate booking data to Indexing Engine' button would still be displayed after the booking data had already been migrated \[ID_28813\]

In DataMiner Cube, clicking the *Migrate booking data to Indexing Engine* button starts a wizard that allows you to migrate booking data from the Cassandra database to the Indexing database. In some cases, this button would incorrectly still be displayed after the booking data had already been migrated.

#### DataMiner Cube - Visual Overview: Element shapes would incorrectly not inherit the service con­text of their parent element shape \[ID_28867\]

Up to now, an element shape that was a child of another element shape would not inherit the service context of its parent.

From now on, an element shape that is a child of another element shape will inherit the service context of its parent when it does not have a service context of its own.

#### DataMiner Cube: Linked alarm tab would not show all alarms after all cards had been closed & no context menu when right-clicking an app in the Cube header search box \[ID_28893\]

When you closed all cards while a linked alarm tab was open in the Alarm Console, that linked alarm tab would not show all alarms. Instead, it would incorrectly keep the last card you closed as a filter.

Also, when you searched for an app using the search box in the Cube header, right-clicking the app in the search results would not open its context menu.

#### Cassandra: Problem with file offload \[ID_28951\]

Due to a file offload problem, in some rare cases, data operations (e.g. parameter updates) executed during a Cassandra outage would not get pushed to the database after the outage.

#### Dashboards app: Multiple parameter feeds in PDF reports would incorrectly also show all selected parameter indices \[ID_28978\]

When you generated a PDF report with the options “No grouping” and “Include feeds” enabled, in some cases, multiple parameter feeds would not only show the selected parameters, but incorrectly also all selected parameter indices.

#### DataMiner Cube - Automation: Discarding a newly created script would not delete it \[ID_29032\]

When you discarded a newly created Automation script, in some cases, it would incorrectly not be deleted although it had disappeared from the UI. As a result, trying to create a new script with the same name would fail.

#### No trigger keys listed when debugging a QAction due to a compatibility issue between Data­Miner and DataMiner Integration Studio \[ID_29049\]

Due to a compatibility issue between DataMiner and DataMiner Integration Studio, in some cases, when debugging a QAction, the *Trigger key* box in the *DIS Inject *window would incorrectly not list any trigger keys.

#### SNMPAgent: Engine ID and engine boots counter of local agent would incorrectly be cleared when the users were cleared \[ID_29081\]

Up now on, when an SNMP agent cleared the users during the re-initialization of the SNMP forwarding, the engine ID and the engine boots counter of the local agent would incorrectly be cleared as well. From now on, when an SNMP agents clears the users, it will ignore the engine ID and engine boots counter of the local agent.

#### DataMiner Cube - Resources app: Capacity parameter values would incorrectly be stored without decimals \[ID_29082\]

Up to now, in the Resources app, capacity parameter values would incorrectly be stored without decimals.

#### SLNet.txt log file would contain irrelevant log entries \[ID_29120\]

From now on, the following irrelevant entries will no longer be added to the SLNet.txt log file:

```txt
DmaConnections|Unexpected filter type: SubscriptionFilter\`2
```

```txt
Unexpected filter type: Skyline.DataMiner.Net.SubscriptionFilters.SubscriptionFilter\`2[XXXX,XXXXXX]
```

#### Interactive Automation scripts: Date selected in calendar control would be parsed incorrectly \[ID_29153\]

When, in an interactive Automation script, a calendar control was used to select a date (i.e. a datetime value without a specific time), in some cases, the value of the selected date would be parsed incorrectly.

#### UDP smart-serial server would receive an empty package each time a new client started send­ing data to it \[ID_29166\]

When multiple clients were sending data to a smart-serial UDP server, that server would incorrectly receive an empty package each time a new client started sending data.

#### DataMiner Cube - EPM: No longer possible to unmask items in a topology diagram or alarms in the Alarm Console \[ID_29173\]

In an EPM environment, in some cases, it would no longer be possible to manually unmask items in a topology diagram or alarms in the Alarm Console.

#### Dashboards app: Ring or Gauge component would incorrectly indicate the maximum value \[ID_29175\]

In some cases, a Ring or Gauge component would indicate the maximum value instead of the current value, especially when that value had a unit assigned.

#### DataMiner Cube: Table columns with a width set to 0 in the protocol would incorrectly be visible \[ID_29196\]

In DataMiner Cube, in some cases, table columns of which the width was set to 0 in the protocol would incorrectly be visible.

#### Dashboards app - GQI: Aggregated values would incorrectly be displayed in raw format \[ID_29200\]

In GQI query results, aggregated values would incorrectly be displayed in raw format. From now on, they will be formatted according to the display properties (e.g. units, decimals, etc.) defined in the protocol.

#### DataMiner Cube - Alarm Console: Problem when trying to unmask an EPM object \[ID_29213\]

When an EPM object is masked, you can try to unmask it via its alarms in the Alarm Console. These alarms are linked to the EPM object via the “System Name” and “System Type” properties.

In some cases, it would no longer be possible to unmask such an EPM object due to a casing issue in those “System Name” and “System Type” properties.

#### DataMiner Cube - EPM: No longer possible to manually unmask items in a topology diagram \[ID_29228\]

In an EPM environment, in some cases, it would no longer be possible to manually unmask items in a topology diagram.

#### Problem in SLNet could cause DataMiner to restart \[ID_29229\]

In some rare cases, an error occurring in SLNet could cause DataMiner to restart.

#### DataMiner 10.1.0 upgrade package: Launcher.ashx file missing \[ID_29235\]

The C:\\Skyline DataMiner\\Webpages\\DataMinerCubeStandAlone\\Launcher.ashx file was missing in the DataMiner 10.1.0 upgrade package.

#### Dashboards app - GQI: Problem when performing an aggregation operation on an additional column \[ID_29249\]

In some cases, an exception could be thrown when a aggregation operation was performed on an additional column.

#### DataMiner Cube: Problem when exporting tables to function DVE protocols \[ID_29266\]

When a table is exported to a function DVE protocol, some of the columns can optionally be left out. In some cases, especially when the omitted columns appeared before the primary key or display key columns, DataMiner Cube would interpret the data incorrectly.

#### Data would not get written to the backup agent after configuring a Failover setup on a system with MySQL databases \[ID_29267\]

When a Failover setup is configured on two DataMiner Agents with a MySQL database, after synchronizing the two databases, all new data should be written to both these databases. However, in some cases, new data would incorrectly not be written to the backup agent until after the primary agent had been restarted.

#### DataMiner Cube - System Center: Incorrect counter values on Agents \> BPA page \[ID_29271\]

In *System Center*, on the *Agents \> BPA* page, in some cases, the displayed counters would show incorrect values.

#### Problem with SLAnalytics \[ID_29275\]

In some rare cases, an error could occur in the SLAnalytics process.

#### Dashboards app: Problem when no elements could be found when running an inter-element GQI query that retrieved a table \[ID_29285\]

When no elements could be found while running an inter-element GQI query that retrieved a table, up to now, an exception would be thrown. From now on, an empty result set will be returned instead.

#### Jobs app: “no sections added yet” error incorrectly displayed on a booking section \[ID_29293\]

In some cases, a “no sections added yet” error would incorrectly be displayed on a booking section.

#### Problem at DataMiner startup due to an invalid loop in the view hierarchy \[ID_29307\]

On DataMiner startup, in some cases, an error could occur when an invalid loop was found in the view hierarchy. From now on, when an invalid view loop is found, an error mentioning the incorrectly configured views will be logged.

#### Problem when an Element.xml or Service.xml file could not be found \[ID_29322\]

Up to now, in some cases, an exception would be thrown when an Element.xml or Service.xml file could not be found. From now on, an error will be logged instead.

#### Jobs app: Problem when updating section and field definitions \[ID_29325\]

In some cases, changes made to job sections and job fields would not immediately be visible in the UI.

Also, when a field with the *Allow filtering on this field* option enabled had its type changed, in some cases, the *Allow filtering on this field* option would incorrectly stay enabled.

#### Problem with SLDataMiner when an element was stopped \[ID_29327\]

In some cases, an error could occur in SLDataMiner when an element was stopped.

#### DataMiner Cube - Alarm Console: Correlation sources would no longer be updated \[ID_29330\]

When one of the sources of a correlation alarm (group) was updated, in some cases, the update would not be reflected in the Alarm Console. When you opened the correlation alarm (group), the previous alarm source would incorrectly still be shown.

#### Dashboards app: Web components would not load HTTPS-only websites when the Dashboards app was being used with HTTP \[ID_29352\]

When the Dashboards app is being used with HTTP instead of HTTPS (which is not recommended), then it also loads all web component URLs using HTTP, even when they are configured to use HTTPS. As a result, up to now, websites only accessible using HTTPS could not be loaded.

From now on, it will also be possible to load websites only accessible using HTTPS when the Dashboards app is being used with HTTP.

#### Legacy Reporter app: Status query report with table parameters exported to a CSV file would contain tables within table cells \[ID_29355\]

When, in the legacy Reporter app, you generated a report containing a status query with a number of table parameters and exported it to a CSV file, full tables would end up in status query cells.

From now on, when you export a status query report containing table parameters to a CSV file, the data in the table parameters will be exported to separate CSV files as before, but it will no longer appear inside status query cells.

#### DataMiner Cube - Bookings app: Bookings without an end time would incorrectly only be listed when their start time was within the specified time window \[ID_29356\]

In the Bookings app, booking without an end time would incorrectly only be listed when their start time was within the specified time window.

#### Using an NT_EDIT_PROPERTY (62) call to update an alarm property of a DVE element would fail when no element ID was specified \[ID_29358\]

When an alarm property of a DVE element was updated using a SetDataMinerInfoMessage of type 62 (NotifyType.EditProperty) without specifying the element ID, the request would fail with an “element is unknown” error.

#### Elements with a large amount of data stored in a Cassandra database would fail to start \[ID_29363\]

On systems with a Cassandra database, in some cases, elements that had a large amount of data stored in the database would fail to start.

#### Dashboards app - CPE feed: Selection box contained too much data \[ID_29377\]

Due to incorrect filtering, in some cases, the selection box in the CPE feed would contain too much data.

#### DataMiner Cube: Problem when selecting a value from a drop-down parameter in a custom con­text menu of a table \[ID_29383\]

If a parameter of type “drop-down” in a custom context menu of a table retrieved its values from a dependency parameter, in some cases, the first time a value was selected, the selection would not be applied.

#### Jobs app: Small typographical error in warning message \[ID_29388\]

When, in the Jobs app, you tried to hide the only domain that was visible, up to now, the warning message that appeared, would contain a small typographical error.

- Former message: “Atleast one job domain should be visible.”

- New message: “At least one job domain should be visible.”

#### Jobs app: Booking sections did not have their initial values filled in \[ID_29392\]

In some cases, booking sections did not have their initial values filled in.

#### Jobs app: Jobs no longer selected after canceling a delete operation \[ID_29402\]

When you selected a number of jobs in the list, clicked *Delete*, and then clicked *Cancel*, in some cases, the jobs you had selected would no longer be selected.

#### Automation: Subscripts would return an incorrect output \[ID_29405\]

When, in an Automation script, a subscript that returned its output was run twice, in some cases, when it cleared its output during its second run, it would incorrectly return the same output it had returned at the end of its first run.

#### Legacy Reporter: Status query would no longer show alarm colors \[ID_29516\]

In the legacy Reporter app, in some cases, the status query would no longer show alarm colors.

## Addendum CU3

### Enhancements

#### DataMiner Cube - Visual Overview: Viewport and Navigate variables of a Resource Manager timeline will now be read and applied upon opening \[ID_29299\]

When, in Visual Overview, you create a shape that should display the Resource Manager timeline by adding a shape data field of type Component set to “Reservations” or “Bookings”, the Navigate and Viewport session variables allow you to control navigation and zooming within the timeline.

- The Navigate variable can be used to automatically navigate to a specified time range.

- The Viewport variable can be used to zoom to a specified time range and to visualize the time range to which you zoomed manually.

From now on, both variables can be processed immediately upon opening a visual overview with a Resource Manager timeline.

- Setting the Navigate variable using a page-level InitVar will make the timeline navigate immediately to the chosen time slot and clear the Navigate variable.

- The Viewport variable will always be read upon opening the Resource Manager timeline. In other words, if a session variable already exists in the scope in question (e.g. when the time line was opened while using the global variable scope), the timeline will automatically zoom to the last-known view port.

> [!NOTE]
> The Navigate variable will be processed after the Viewport variable.

#### DataMiner Cube - SLAnalytics: Enhanced handling of errors that occurred at startup \[ID_29311\]

In DataMiner Cube, from now on, when errors occurred while SLAnalytics was starting up its different features, a message box will be displayed, listing the features that could not be started.

For more information about the listed errors, users can then check the SLAnalytics logging.

#### DataMiner Cube - Service & Resource Management: Enhanced performance \[ID_29398\]

Due to a number of enhancements, overall performance of the different Service & Resource Management modules has increased.

#### Dashboards app - PDF reports: Data overflow warnings will now be added at the bottom of the email body \[ID_29417\]

Up to now, when a data overflow was detected while generating a PDF report, a warning would be added to the “Report” section, which is closed by default. From now on, data overflow warnings will be added at the bottom of the email body, below the “Report” section. This will allow users to immediately notice the warnings when they open the email message.

#### Jobs app: Tool tips added to section definition settings \[ID_29443\]

The job section definition settings “Color”, “Icon” and “Allow Multiple Instances” now have tool tips that indicate that they are linked to the job domain and will not affect other referenced job section definitions in other domains.

#### Mobile apps - Visual Overview: Linking shapes to webpages \[ID_29444\]

When you link a shape to a webpage using a shape data field of type *Link*, that page will be opened each time a user clicks that shape. This feature will now also work on visual overviews in mobile apps (e.g. Dashboards, Monitoring, etc.).

#### Dashboards app - GQI: Enhanced performance when executing large queries \[ID_29473\]

Due to a number of enhancements, overall performance has increased, especially when executing large queries.

#### Enhancements made to the method that decides which subscriptions to forward to other agents in the DMS \[ID_29490\]

A number of enhancements have been made to the method that decides which subscriptions to forward to other agents in the DMS. These enhancements will considerably reduce SLNet CPE usage, especially on systems with a large number of active subscriptions.

#### Ticketing app: Enhancements \[ID_29492\]

A number of enhancements have been made to the Ticketing app, especially with regard to masked domains.

- When a masked domain is deleted, all tickets associated with that domain will now also be deleted.

- On the Configuration page, masked domains will now be marked with a special icon.

- When a masked domain is opened via a URL, a warning will now be displayed, indicating that the domain is masked. Also, no edit buttons will appear.

- When you open the create ticket window or edit ticket window via a URL to create or edit a ticket from a masked domain, a warning will now be displayed, and all fields of that ticket will be disabled.

#### Visual Overview: New option to keep real-time charts from showing exception values in labels \[ID_29504\]

In the *ParametersOptions* shape data field for a parameter chart showing real-time values, you can now use the *VisualizeExceptions=false* option to keep the display value for exception values from being shown in a label.

| Shape data field  | Value                                                                     |
|-------------------|---------------------------------------------------------------------------|
| ParametersOptions | VisualizeExceptions=true (default behavior)<br> VisualizeExceptions=false |

#### DataMiner Cube: Enhancements with regard to dragging, sizing and positioning of undocked windows and cards \[ID_29508\]

DataMiner Cube automatically scales each window based on the monitor it is displayed on. A number of enhancements have now been made, especially with regard to the dragging, sizing and positioning of undocked windows and cards.

Sizing:

- When a window is undocked via a drag operation, it will take the same size as the docked window.

- When a window is undocking via SHIFT-Click or via the Undock context menu action, it will take a size based on the type of window. If no specific size is provided (e.g. in case of an element card), the default size will be used (i.e. 80% of the screen size).

- Window size range: From 600x400 (minimum) to 80% of the screen (maximum)

Positioning:

- When a window is undocked, it will be centered on the Cube’s main window.

- Undocked windows will respect the screen boundaries and be confined to one screen.

- When a window is undocked via a drag operation, it will correctly follow the mouse cursor and initiate a window drag that can immediately snap to screen borders.

#### Notice will now appear in the Alarm Console when the initial synchronization of a DMA fails \[ID_29532\]

When, after adding a DMA to the DataMiner System, the initial synchronization of that agent fails, a notice will now appear in the Alarm Console.

Also, a number of protective measures have been added to prevent an agent that has not yet completed its full synchronization from being synchronized at midnight.

#### Protocols - QActions: #define ALARM_SQUASHING \[ID_29549\]

The preprocessor directive “#define ALARM_SQUASHING” will now automatically be added to each QAction when compiling a protocol.

In QActions, all code related to alarm squashing should be enclosed as follows:

```txt
#if ALARM_SQUASHING
    // Code specific for alarm squashing (DataMiner 10.1.0 and later)
#else
    // Code for DataMiner 10.0.0 and earlier
#endif
```

This allows protocols that contain alarm squashing functionality to also be compiled on DataMiner versions that do not support alarm squashing.

#### Elasticsearch: Support for NotRegex filters \[ID_29567\]

DataMiner now supports the use of NotRegex filters in Elasticsearch.

#### DVE elements notifications no longer added to SLNetCOM Notification Stack \[ID_29601\]

On DataMiner startup and hourly at report generation, a batch of notifications gets forwarded between DataMiner modules, ending up on the SLNetCOM Notification Stack. Up to now, two such notifications were also forwarded for every DVE element. These will now no longer be sent.

#### Automation scripts: #define ALARM_SQUASHING \[ID_29613\]

The preprocessor directive “#define ALARM_SQUASHING” will now automatically be added to each C# block of an Automation script.

In C# blocks, all code related to alarm squashing should be enclosed as follows:

```txt
#if ALARM_SQUASHING
    // Code specific for alarm squashing (DataMiner 10.1.0 and later)
#else
    // Code for DataMiner 10.0.0 and earlier
#endif
```

This allows C# blocks that contain alarm squashing functionality to also be compiled on DataMiner versions that do not support alarm squashing.

> [!NOTE]
> Up to now, the following directives would only be added to QActions. These will now also be added to C# blocks of Automation scripts.
> - #define DBInfo
> - #define DCFv1

#### SLNetCom notification thread will now only start ignoring messages after a grace period has passed \[ID_29631\]

When the SLNetCom notification thread reaches a certain threshold (defined by MaxStackSLNetCOMNotifications), the DMA assumes something is wrong and stops processing messages, requiring a restart. However, in some cases, this threshold can be reached even when nothing is wrong.

In order to prevent this, a grace period has now been introduced. When the number of SLNetCom notification messages reaches a peak, the DMA will only start ignoring messages when the number of messages on the stack is equal or greater than the threshold during the entire grace period.

Using the SLNetClientTest tool, you can specify this grace period by configuring the SLNetCOMNotificationsStackExceedsThresholdGracePeriodInMin setting (default value: 1 minute).

#### DataMiner Cube - Element Connections app: Mechanism used to delete connections between a destination parameter and a non-virtual source parameter has been optimized \[ID_29653\]

Due to a number of enhancements made to the Element Connections app, the mechanism used to delete connections between a destination parameter and a non-virtual source parameter has been optimized.

#### Standalone Elastic Backup tool will now have to be used to restore a backup of an Elasticsearch database \[ID_29677\]

When you take a backup of a DataMiner Agent, you can opt to also take a backup of its Elasticsearch database. However, as the latter will in most cases be a cluster, automatically restoring an Elasticsearch backup when restoring a DataMiner Agent is not advisable.

From now on, even when a DataMiner backup includes an Elasticsearch backup, the latter will not be automatically restored when the DataMiner backup is restored. Restoring an Elasticsearch backup will now have to be done using the Standalone Elastic Backup tool.

For more information on the Standalone Elastic Backup tool, see [Standalone Elastic Backup Tool](https://community.dataminer.services/documentation/standalone-elastic-backup-tool/) on DataMiner Dojo.

#### DataMiner Cube - Surveyor: Enhanced performance when loading services \[ID_29715\]

Due to a number of enhancements, especially with regard to the loading of services into the Surveyor, overall performance of DataMiner Cube has increased when starting up.

### Fixes

#### Problem when retrieving protocol-level TTL settings from the database \[ID_28023\]

When writing trend data to the database, in some cases, protocol-level TTL settings could not be retrieved. From now on, when TTL settings cannot be retrieved from the database, additional information will be added to the logs.

#### DataMiner Cube - Visual Overview: DCF connections of hidden shapes would incorrectly still be visible \[ID_28930\]

Up to now, DCF connections of shapes that were hidden because of a condition would incorrectly still be visible. From now on, any connection that is linked to a shape that is hidden will no longer be displayed.

Also, hidden shapes will no longer be taken into account when grouping shapes.

#### DataMiner Cube - Visual Overview: IDOfSelection session variable would not get updated when selected rows were removed or the selection was cleared in a ListView component \[ID_29057\]

When you select one or more rows in a ListView component, the IDs or GUIDs of the selected items are stored in the IdOfSelection session variable.

Up to now, when a selected row was removed or when the selection was cleared in any way, in some cases, the contents of the IdOfSelection session variable would not get updated.

#### NATS service would no longer start up after being reset when a DataMiner Agent was removed from the DMS \[ID_29075\]

In some cases, the NATS service would no longer start up after being reset when a DataMiner Agent was removed from the DMS.

#### DataMiner Cube - Trending: Extra data point would incorrectly be exported to CSV \[ID_29212\]

When you exported average trend data to a CSV file, in some cases, extra data points would incorrectly be added to the exported trend data.

#### Protocols: Problem with SLProtocol when the save attribute of a table parameter was incor­rectly set to “true” \[ID_29214\]

When, in a protocol.xml file, the save attribute of a table parameter was incorrectly set to “true”, in some rare cases, an error could occur in SLProtocol.

#### Dashboards app - Parameter feed: Problem with parameter indices in dashboard URLs \[ID_29242\]

In the URL of a dashboard, primary key and display key in parameter indices are by default separated by a forward slash character (“/”). In some cases, when display keys also contained that same character, parameter indices would be parsed incorrectly.

Also, when a dashboard URL containing a selection was refreshed, in some cases, part of that selection would be cleared.

#### Dashboards app - GQI: Colors set for exception values of numeric parameters would not get applied \[ID_29244\]

In the *Layout* tab of the Table component, the *Column filters *option allows you to highlight cells based on a condition. In some cases, colors set for exception values of numeric parameters with a range would not get applied.

Also, the *Column filters *option now allows you to highlight “Not initialized” values.

#### At DMA startup, NT_CLEAN_SUBSCRIPTION_FOR_STOPPED_ELEMENT would incorrectly be called before all elements were fully loaded \[ID_29257\]

When a DataMiner Agent was started in a DataMiner System, in some cases, errors would be logged due to NT_CLEAN_SUBSCRIPTION_FOR_STOPPED_ELEMENT being called before all element were fully loaded.

#### DataMiner Cube: No search results when using an element card search box on a system with an Elasticsearch database \[ID_29310\]

When using an element card search box on a system with an Elasticsearch database, in some cases, no search results would appear.

#### Automation: UIBuilder properties MaxWidth and MaxHeight would incorrectly not get applied to interactive Automation script pop-up windows \[ID_29361\]

In some cases, the UIBuilder properties “MaxWidth” and “MaxHeight” would incorrectly not get applied to interactive Automation script pop-up windows.

#### Incorrect data could be returned during a migration from MySQL to Cassandra \[ID_29385\]

Due to a problem with certain COM calls, in some cases, incorrect data could be returned during a migration from MySQL to Cassandra.

#### Jobs app: Problem when sorting on a field added to the default job section \[ID_29386\]

In some cases, an error could occur when you sorted the jobs list on a field that had been added to the default section.

#### Dashboards app: Input boxes would extend beyond the borders of the screen \[ID_29406\]

When configuring certain components, a number of input boxes would not resize correctly. Instead, they would extend beyond the borders of the screen.

#### Dashboards app - GQI: Filters would not be applied when requesting aggregated values from an Elasticsearch logger table \[ID_29439\]

In some cases, filters in GQI queries would not be applied when requesting aggregated values from an Elasticsearch logger table. This would cause the values to be aggregated over the entire table instead of a subset of that table.

#### Jobs app: Name of default job section would incorrectly be set to “DefaultJobDomain” when the section was updated \[ID_29460\]

When the default section was updated, its name would incorrectly be changed to “DefaultJobDomain” instead of “DefaultJobSection”.

#### SLAnalytics: Problem when retrieving data from DVE elements \[ID_29464\]

Due to a problem when retrieving data from DVE elements, in some cases, trend prediction and pattern matching would not work for this type of elements.

#### DataMiner Cube - EPM: Children of the siblings of the selected object would incorrectly also be displayed \[ID_29465\]

Up to now, when the *ShowSiblings* option was combined with the *ShowChildren* option, the children of the siblings of the selected object would incorrectly also be displayed. From now on, only the children of the selected object will be displayed.

#### DataMiner Cube - Alarm Console: Problem when clicking the “Alarm storm” button \[ID_29472\]

If alarm storm protection by delaying is activated, during an alarm storm you can click the red *Alarm storm* button in the alarm bar to open a new card with a list of the delayed alarms.

In some cases, when you clicked that button, an exception would be thrown and no alarms would be displayed.

#### Legacy Dashboards app - Trend component: Custom range values would be ignored when the time range of the chart was updated \[ID_29480\]

In the legacy Dashboards app, the “Custom low range” and “Custom high range” options of the Trend component would incorrectly be ignored whenever the time range of the chart was updated.

#### Dashboards app: Data item dragged onto a component would not appear in the component’s edit panel \[ID_29481\]

When you dragged a data item (e.g. the entire Elements dataset) onto a component, in some rare cases, that item would not appear in the component’s edit panel.

#### Dashboards app: Index feed would remain in status “Loading” when an error occurred while fetching the indices \[ID_29487\]

When an error occurred while fetching the indices, in some cases, the index feed would remain in status “Loading”. From now on, when an error occurs while fetching the indices, the reason of the failure will be displayed.

#### SLLogCollector would incorrectly not take a dump when the temp folder did not exist \[ID_29500\]

In some cases, SLLogCollector would incorrectly not take a dump when the temp folder did not exist.

#### Mobile apps: Error 404 page would not list the 6th app \[ID_29521\]

When the DataMiner landing page listed 6 apps and you were redirected to an error 404 page due to an error with one of those apps, then the error 404 page would only list 5 apps.

#### DMA that was incorrectly cleaned after having been removed from a DMS would skip its initial synchronization when added to another DMS later on \[ID_29523\]

When a DataMiner Agent had been removed from the DataMiner System and was cleaned up incorrectly afterwards (e.g. by manually updating the DMS.xml file), in some cases, it would skip its initial synchronization when it was added to another DataMiner System later on.

#### Problem with SLASPConnection when processing the results of a GetAlarmHistory call \[ID_29525\]

In some cases, an error could occur in SLASPConnection when processing the results of a GetAlarmHistory call.

#### DataMiner Cube - Alarm Console: Blue footer bar had an incorrect dark blue color \[ID_29529\]

In some cases, the blue footer bar of the Alarm Console would have an incorrect dark blue color.

#### Baseline of standalone parameter would incorrectly be cleared when its condition had first been evaluated as true and then as false \[ID_29531\]

When relative or absolute monitoring was enabled on a standalone parameter of which the condition had first been evaluated as true and then as false, in some cases, the baseline of the parameter would incorrectly be cleared.

#### Problem with SLElement at DataMiner startup \[ID_29539\]

At DataMiner startup, in some rare cases, an error could occur in SLElement.

#### Dashboards app - GQI: Problem when executing a large query \[ID_29540\]

In some cases, the Dashboards app could become unresponsive when a large query was being executed.

#### Service & Resource Management: Problem loading functions.xml files \[ID_29551\]

When the first attempt to load a functions.xml file would fail, in some cases, no further attempts would incorrectly be made.

#### Problem when taking a backup of an Elasticsearch database after logging on with a password encrypted by DataMiner \[ID_29564\]

In some cases, it would not be possible to take a backup of an Elasticsearch database to which you had logged on using a password encrypted by DataMiner.

#### DataMiner Cube - Embedded Chromium web browser engine: Problems with scaling \[ID_29596\]

In some cases, the following problems could occur with regard to Chromium web browser controls:

- When opened in a window on a high-DPI monitor, they would be scaled twice and the image would not match the mouse cursor.

- When displayed in a window that was moved from one monitor to another, they would not adapt to the new DPI scale.

- When displayed on a high-DPI monitor, they were rendered at 100% DPI and then upscaled, resulting in an imperfect image.

#### SLNetComNotificationThread: Delay between notifications \[ID_29599\]

In SLNet, up to now, the SLNetComNotificationThread had a delay of 15 ms between notifica-tions. In cases where a large number of notifications had to be processed, the total delay could be significant.

#### Incorrect in-memory state in SLDMS when removing an agent from a DMS \[ID_29612\]

When a DMA was removed from a DataMiner System, in some cases, the memory of the SLDMS process would be left in an incorrect state.

This could prevent actions like initial synchronization from working when setting up a new DMS or a new Failover environment that included the agent in question.

#### Elasticsearch: Problem when trying to create a customdata object \[ID_29617\]

When a customdata object had to be created in an Elasticsearch database, in some rare cases, multiple DMAs in the DMS would try to create the same table. This would cause an exception to be thrown on some of those DMAs.

#### DataMiner Cube - Data Display: Problem with dynamic parameter ranges \[ID_29625\]

When a protocol updated parameter ranges using an NT_UPDATE_DESCRIPTION_XML call, in some cases, the ranges could be reverted to an old value, especially when the PageUnloadOnNavigatingAway option was enabled or when the ranges belonged to parameters located on pages that had not yet been visited.

#### Problem with SLSNMPAgent \[ID_29629\]

In some cases, an error could occur in SLSNMPAgent when dealing with issues caused by not being able to fetch XML cookies from SLDataMiner.

#### Problem in SLDataMiner when reloading virtual functions \[ID_29641\]

In some cases, an error could occur in SLDataMiner when a functions.xml file was reloaded.

#### DataMiner Cube - Element Connections: Duplicated non-virtual parameters would be added twice when they referred to a destination parameter \[ID_29645\]

In the Element Connections app, in some cases, duplicated non-virtual parameters would be added twice when they referred to a destination parameter.

#### Dashboards app - Line chart component: Zero values would incorrectly be exported to CSV as null values \[ID_29660\]

When trend data was exported to a CSV file, in some cases, zero values would incorrectly be exported as null values.

#### DataMiner Cube - Spectrum Analysis: Start, stop and center frequencies incorrectly displayed without decimals \[ID_29661\]

When you opened a Spectrum element card, in some rare cases, the start, stop and center frequencies would incorrectly be displayed without decimals.

#### DataMiner Cube: No views visible in the Surveyor after clicking the “Start” button on the mes­sage box saying that the agent was not running \[ID_29665\]

When you opened DataMiner Cube and clicked Start on the message box saying that the agent was not running, the agent would start up but, in some cases, no views would be visible in the Surveyor.

#### Problem when restarting a DMA without stopping SLNet \[ID_29667\]

When you restarted a DataMiner Agent without stopping SLNet, in some rare cases, an exception could be thrown.

#### DMS Alerter would start to consume an excessive amount a memory when configured to play a sound when the alarm in the pop-up matched a filter \[ID_29672\]

When you had configured Alerter to play a sound when the alarm displayed in the pop-up balloon matched a filter, in some cases, Alerter would start to consume an excessive amount a memory.

## Addendum CU4

### Enhancements

#### Security enhancements \[ID_29848\]\[ID_29887\]\[ID_29889\]

A number of security enhancements have been made.

#### Dashboards app: Enhanced overflow detection when generating PDF reports \[ID_28985\]

Due to a number of enhancements, overflow detection has improved when generating PDF reports.

#### SLWatchdog: Notification enhancements \[ID_29697\]

A number of enhancements have been made with regard to notifications generated by the SLWatchDog process.

#### DataMiner Cube - ListView component: Enhancements \[ID_29761\]

A number of enhancements have been made to the ListView component, especially with regard to list updates after rows were added, updated or removed.

#### DataMiner Cube: “Not applicable” replaced by “N/A” when displaying alarm statistics while the alarm storm protection mode is active \[ID_29771\]

When, in Visual Overview or the Surveyor, alarm statistics were displayed while the alarm storm protection mode was active, up to now, the number of alarms would be replaced by “Not applicable”. From now on, the number of alarms will be replaced by “N/A” instead of “Not applicable”.

#### DataMiner Cube - Service & Resource Management: Enhanced performance when fetching initial data \[ID_29799\]

Due to a number of enhancements, overall performance of the different Service & Resource Management modules has increased, especially when fetching initial data.

#### Inter-DMA communication: Enhanced automatic HTTP port detection \[ID_29834\]

Up to now, when port 80 (HTTP) was unavailable between DataMiner Agents, connections between the DataMiner Agent modules on the different servers would only work after the ConnectTimeout setting had been increased. From now on, when auto-detecting the target port (via port 80 or 443) fails, the connection attempt will continue on default port 8004.

Also, a number of additional options were added to the connection string configuration (SLNetClientTest \> Advanced \> Edit Connection Strings):

- The “To” field can now contain wildcards (\* or ?). If there is no exact match, the settings of the record in question will then apply to all matching destinations. If more than one wildcard entry matches a destination, the behavior is undefined.

- The connection string can now be set to “auto://nodetect” in order to skip the auto-detection of the target SLNet port and automatically default to 8004. When port 80 is blocked between agents, the 15-second autodetection timeout will then be skipped.

#### DataMiner Cube - Bookings app: Enhanced performance of the bookings timeline \[ID_29876\]

Due to a number of enhancements, overall performance of the bookings timeline has been increased.

#### LogCollector: Enhanced handling of long file paths \[ID_29910\]

When, during the creation of a dump file, SLLogCollector encountered a file of which the path was longer than 256 characters, up to now, an error would be thrown and the entire dump operation would fail. From now on, when SLLogCollector encounters a file of which the path was longer than 256 characters, it will exclude that file, and continue creating the dump file.

Also, when in the registry of a Windows 10 version 1607 or above the LongPathsEnabled option is set to 1 in Computer\\HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\FileSystem, SLLogCollector will now accept file paths that are longer than 256 characters.

#### SLManagedAutomation: Locking mechanism will now prevent exceptions from being thrown when reading or writing items in the dummies collection \[ID_29930\]

In an Automation script, every Engine object contains a collection of “dummies”. Each of these dummies represents an element and can be used to interact with that element. When an Automation script wants to interact with an element that is not yet available in the dummies collection, a new dummy is created.

Up to now, exceptions could be thrown when multiple threads were trying to read or write items in the dummies collection. Now, a locking mechanism has been added to prevent multiple threads from interfering with each other while accessing the dummies collection.

#### SLSNMPManager: Enhanced logging \[ID_29935\]

In order to determine the root causes of certain SNMP-related issues, the SLSNMPManager error logging has been enhanced.

This enhanced logging will especially be helpful when investigating the “Unable to set the destination IP” error.

#### SLElement: Enhanced memory usage when processing service impact data \[ID_29948\]

Due to a number of enhancements, overall memory usage of SLElement has increased, especially when processing service impact data.

Also, a small memory leak was fixed in elements contained within services.

#### New BPA tests added to default test set \[ID_30010\]

The following new BPA tests have been added to the default test set:

- Minimum Requirements Check

- Report Active RTE

- View Recursion

### Fixes

#### Service & Resource Management: Problem when trying to retrieve a resource with status “Main­tenance” or “Unavailable” \[ID_29511\]

Due to a serialization issue involving the AvailableTo and AvailableFrom properties of the GetResourceMessage, in some cases, it would not be possible to retrieve a resource with status “Maintenance” or “Unavailable”.

#### DataMiner Cube - Surveyor: Newly created elements located in multiple views would incorrectly only appear in one of those views \[ID_29544\]

When you created a new element located in multiple views, in some rare cases, it would incorrectly only appear in one of those views. Only when you reconnected Cube would the element be displayed in all views in which it was located.

#### Problem when using GetPropertyValueMessage to request properties from an element or ser­vice hosted on a DMA other than the one to which you were connected \[ID_29655\]

When GetPropertyValueMessage was used to request properties from an element or service that was hosted on a DataMiner Agent other than the one to which you were connected, in some cases, no response would be returned.

#### DataMiner Cube - Trending: Color icons missing from trend graph legend \[ID_29718\]

When you opened a trend group with several graphs, in some rare cases, color icons would be missing from the trend graph legend.

#### Manually clearing a clearable alarm on a single-value parameter would incorrectly set the alarm state of the parameter to “undefined” instead of “normal” \[ID_29745\]

When you manually cleared a clearable alarm on a single-value parameter, the alarm state of the parameter would incorrectly be set to “undefined” instead of “normal”.

#### DataMiner.xml: \<NetworkAdapters> tag not correctly applied when a network adapter did not have a current IP address assigned \[ID_29759\]

In the DataMiner.xml file, you can use the \<NetworkAdapters> tag to override the order of the network adapters on a DataMiner Agent.

Up to now, when one of the adapters had an IP address defined in the Windows Registry but had no current IP address assigned, in some cases, an incorrect order could get applied in DataMiner.

#### DataMiner Cube - Alarm templates: Problem with overlapping time frames when the end time of a schedule entry was set to midnight \[ID_29772\]

When configuring schedules in alarm templates, in some cases, entries could have overlapping time frames, especially when the end time of one of those entries was set to midnight.

#### DataMiner Cube - Visual Overview: Field and FieldID placeholders could not be used by a Visio file assigned to a view enhanced with EPM data \[ID_29790\]

When a view was enhanced with EPM data and had a Visio file assigned to it, in some cases, the Visio file assigned to that view would not be able to use the Field and FieldID placeholders.

#### DataMiner Cube: Problem when pressing the Back button during logon \[ID_29808\]

When you pressed the Back button while logging on, in some cases, an error could occur in the logon screen, forcing you to restart Cube.

#### Monitoring app: Service child popup pages without parent page could not be opened \[ID_29816\]

When, for an element included in a service, only parameters from one of its popup pages were included and none of that popup page’s parent page, then that parent page would not be included in the service and there would be no way to access the popup page. From now on, in cases like this one, popup pages of service children will be added to the Monitoring app’s side panel after all other pages.

#### Legacy Reporter app: Problem when trying to display a trend graph for a table column parameter \[ID_29818\]

When the legacy Reporter app had to display a trend graph for a table column parameter, in some cases, a “no trend graph is available” message would incorrectly appear instead, especially when that table column parameter had both average and real-time trending enabled on certain rows.

#### DataMiner Cube: Problem with SLSpectrum when closing a spectrum element card \[ID_29824\]

In some cases, an error could occur in SLSpectrum when you closed a spectrum element card.

#### Not all references to child elements were removed from the original DMA after a DELT migra­tion of main DVE elements \[ID_29831\]

After a DELT migration of main DVE elements from one DMA to another, in some cases, not all references to the child elements would be removed from the original DMA.

#### SLDataGateway: Problem when creating a job queue \[ID_29837\]

In some rare cases, SLDataGateway would throw a null reference exception when creating a job queue.

#### DataMiner Cube - Visual Overview: Problem when opening a visual overview that contained a filtered table \[ID_29846\]

In some cases, DataMiner could become unresponsive when you opened a visual overview that contained a filtered table.

#### Mobile apps: Selection box values would be ellipsed even when there was ample space to fully display them \[ID_29850\]

In the mobile apps (e.g. Jobs, Ticketing, etc.), in some cases, selection box values would be ellipsed even when there was ample space to fully display them.

#### DataMiner Cube - Trending: “Exclude gaps” option would not work when exporting average trend data \[ID_29870\]

When you exported average trend data to a CSV file with the *Exclude gaps* option enabled, the gaps would incorrectly not be excluded.

#### Masking monitored column parameters that were not in an alarm state would not cause them to get marked as being masked \[ID_29871\]

When you masked a monitored column parameter that was not in an alarm state, it would incorrectly not get marked as being masked.

#### DataMiner Cube: Problem when opening the Services app \[ID_29884\]

In some cases, opening the Services app could take a long time due to a problem while loading the SRM icons.

#### Dashboards app - PDF reports: Toggling the “Include feeds” option would disable the “Create” button \[ID_29920\]

When, in the PDF preview window, you toggled the *Include feeds* option multiple times in a row, in some cases, the *Create* button would get disabled.

#### SLAnalytics: Memory spikes when requesting trend predictions \[ID_29925\]\[ID_29983\]

In some cases, large memory spikes would occur in the SLAnalytics process when requesting trend predictions for parameters with a small polling interval that did not receive regular (non-exception) parameter value updates in the real-time trend data history.

#### DataMiner Cube - Alarm Console: Problem with automatic removal of information events \[ID_29928\]

Due to a problem with the mechanism that automatically removes information events from the *Information events* tab page, in some cases, DataMiner Cube could become unresponsive when too many information events were being received.

#### DataMiner Cube - Services app: Functions not loaded in service definition diagrams \[ID_29954\]

When you opened a service definition in the Services app, in some cases, the functions would not get loaded into the service definition diagram.

#### DataMiner Cube could become unresponsive when you opened the Services app \[ID_30001\]

When you opened the Services app, in some cases, Cube could become unresponsive.

#### DataMiner Cube - Visual Overview: Booking placeholder would not update correctly when it was not able to resolve the booking ID at initialization \[ID_30011\]

When, at initialization, a booking placeholder was not able to resolve its booking ID to an actual GUID, any updates to that placeholder would not be processed correctly.

#### DataMiner Cube - Bookings app: Memory leak in bookings list \[ID_30048\]

When an item was removed from the bookings list, it could occur that the item was not removed from memory.

#### DataMiner Cube - Services app: Profile parameters not displayed when clicking a node of a service definition \[ID_30059\]

When, in the Services app, you clicked a node of the service definition, in some cases, the profile parameters would not be displayed. Also, it would not be possible to select a profile instance for that node.

#### Problem when masking DVE elements containing table parameters \[ID_30084\]

When an element is masked, DataMiner will mask all parameters of that element. Table parameters will be masked as a whole, meaning that column parameters will not be masked individually. However, in case of DVE elements, a column parameter can be exported as a separate, standalone DVE parameter. So, here, a column parameter can be masked individually as the rest of the table is not part of the DVE element.

Up to now, when an entire table had been exported to a DVE element, and that DVE element was masked, then DataMiner would incorrectly mask the table as a whole as well as each column individually, leading to double masking.

From now on, when an entire table was exported to a DVE element, the column parameters will no longer be masked individually. The default table masking procedure will be applied.

## Addendum CU5

### Enhancements

#### Security enhancements \[ID_29980\] \[ID_30012\] \[ID_30195\]

A number of security enhancements have been made.

#### Enhanced performance when executing offloaded database operations against a Cassandra or Elasticsearch database \[ID_29451\] \[ID_29857\]

Due to a number of enhancements, overall performance has increased when executing Cassandra and Elasticsearch database operations that were offloaded to a file when the database was unavailable.

> [!NOTE]
> While executing database operations that were offloaded to a file when the database was unavailable, an information event and a log entry will be created every 30 seconds to indicate the execution progress.

#### Limiting disk space occupied by offload files \[ID_29563\]

In the C:\\Skyline DataMiner\\Database\\DBConfiguration.xml file, you can now specify the maximum amount of disk space that can be occupied by database offload files.

Example:

```xml
<DatabaseConfiguration>
  <FileOffloadConfiguration>
    <MaxSizeMB>10</MaxSizeMB>
  </FileOffloadConfiguration>
</DatabaseConfiguration>
```

> [!NOTE]
> - If no DBConfiguration.xml file exists in C:\\Skyline DataMiner\\Database, then create one with the content of the example above.
> - If no limit is set in DBConfiguration.xml or if the file offload configuration is invalid, the size of the database offload files will by default be limited to 10 GB.
> - When the specified limit has been reached, an alarm with the following text will be generated: “Max file offload disk usage for certain storages has been reached, new data for these storages will be dropped.” Also, the following entry will be added to the SLDBConnection log file: “\|INF\|0\|112\|2021-04-14T13:34:19.559\|DEBUG\|DataGateway.FileOffload\|Max disk usage reached: True for storage Cassandra.TimeTrace (timetrace)”.

#### Enhanced handling of stack overflow exceptions \[ID_29796\]

A number of enhancements have been made to better handle stack overflow exceptions.

#### Smart-serial client connections: Logging incoming data \[ID_29874\]

When a smart-serial client connection receives incoming data, it will forward that data to SLProtocol and display it in Stream Viewer. However, when the incoming data does not match the configured response, the connection will forward TIMEOUT to SLProtocol, making it hard to find out what data was received by SLPort.

From now on, if you enable a specific connection in PortLog.txt (see DataMiner Help) and set SLPort debug logging to level 4 or higher, log entries like the one below will be added to SLPort.txt. These entries contain the IP address and port of the server, the size of the incoming data and the data itself.

```txt
2021/05/14 15:30:57.452|SLPort.exe 8.5.1519.6|39680|39544|CSmartIP::ProcessIncomming|DBG|4|Incoming data from 127.0.0.2:4598 (total length: 5 bytes) -    000000  576F72642E                                   Word.
```

#### SLUpgrade can now run BPA tests before starting the upgrade process \[ID_29903\]

When a DataMiner upgrade package contains a set of BPA tests in its Prerequisites folder, SLUpgrade will now run those tests before starting the upgrade process. Upon failure of one or more of these tests, the upgrade process will be aborted and a message will be displayed.

The BPA tests run before the start of an upgrade process will generally be tests designed to check whether the system meets the requirements necessary to upgrade to the new DataMiner version.

BPA tests added to the Prerequisites folder of a DataMiner upgrade package must comply to the following rules:

- They must have their CanRunOnOfflineAgents flag enabled. This will make sure that, in a Failover setup, the offline agent will also be checked.

- They must have their RequireSLNet flag disabled.

#### Enhanced performance when exporting function protocols \[ID_29929\]

When you uploaded a new version of a protocol that had an active functions file, up to now, all active function elements would be re-evaluated after the function protocols were exported. From now on, the function elements will only be re-evaluated when the function file is set to active.

#### Enhanced logging of parameter update stack notices \[ID_29996\]

Up to now, when the number of items on the parameter update stack was divisible by 1000 after an item had been added to it, a log entry would be added to the log file of the element for which that last item had been added. As a result, parameter update stack notices would be scattered among different log files.

From now on, when the parameter update stack exceeds 5000 items, log entries will be added to the log files of all elements for which there are items on the stack. Also, similar log entries will be added to the same log files each time the number of items on the stack is divisible by 1000 until the number of items on the stack drops below 1000.

#### DataMiner backup packages will now also include the softlaunchoptions.xml file \[ID_30076\]

From now on, DataMiner backup packages will also include the softlaunchoptions.xml file.

#### Enhanced performance when updating user information \[ID_30102\]

Due to a number of enhancements, overall performance has increased when updating user information, especially on systems with a large number of users.

#### DataMiner Cube: “DataMiner Cube mobile” changed to “DataMiner web apps” \[ID_30201\]

Throughout the Cube UI, the term “DataMiner Cube mobile” has been replaced by the term “DataMiner web apps”.

#### DataMiner Cube - Data Display: Service cards now also support conditional page visibility \[ID_30217\]

In a protocol.xml file, it is possible to specify that a Data Display page should either be shown or hidden based on a parameter value. Service cards now also support this feature.

#### BPA test “Report Active RTE” will now run more frequently \[ID_30250\]

The BPA test “Report Active RTE” will now run once every 8 minutes instead of once every hour.

#### Updated BPA tests: “Minimum Requirements Check” & “View Recursion” \[ID_30259\]

The following default BPA tests were updated:

- Minimum Requirement Checker: Name changed to “Minimum Requirements Check”

- View Recursion: Description updated

### Fixes

#### DMS Alerter: Problem when closing Alerter while balloons are popping up \[ID_29725\]

In some cases, an exception could be thrown when you closed Alerter while balloons were popping up.

#### SLDataMiner: High-level log entries would incorrectly not get added to the log after increasing the log level \[ID_29781\]

When you increased the log level of SLDataMiner, high-level log entries would incorrectly not get added to the log.

#### DataMiner Cube - Visual Overview: Problem with SelectionSetVar option \[ID_29797\]

When, in Visual Overview, a table control had the SelectionSetVar option specified, in some cases, it would not be possible to select a row.

#### Cassandra: “tried to execute null statement” errors incorrectly added to SLDBConnection.txt log file \[ID_29947\]

On systems with a Cassandra database, errors similar to the one below would incorrectly be added to the SLDBConnection.txt log file:

```txt
[timestamp]|SLDBConnection.txt|SLDBConnection|SLDBConnection|ERR|0|335|Cassandra: tried to execute null statement.
```

#### DataMiner Cube - Visual Overview: Problem when using the FollowPathColor option \[ID_29959\]

In some cases, using the FollowPathColor option would cause Cube to become unresponsive.

#### Dashboards app - Group component: Visualizations would incorrectly be removed when open­ing the Layout tab \[ID_29962\]

When you opened the Layout tab of a Group component, in some cases, the visualizations will incorrectly be removed.

#### Data offloading would incorrectly be disabled when saving the settings of the offload data­base \[ID_29985\]

When, in DataMiner Cube, you saved the settings of the offload database, the settings for offloading the real-time trend data would not be applied correctly. As a result, offloading would be disabled until the DataMiner Agent was restarted.

#### Part of SLNet initialization could be skipped when a client disconnected while the DMA was starting up \[ID_29986\]

When a client disconnected while the DMA was starting up, in some rare cases, part of the initialization of the SLNet process could get skipped, which would lead to issues later on. Up to now, the error would only be added to the logs. From now on, in cases like this, the following will happen:

- When a client cannot be re-registered during the SLNet initialization, an entry will be added to the logs, but the initialization will no longer fail.

- Any exception thrown during the SLNet initialization will now also show up in the Alarm Console as “Unexpected Exception \[Initialize DMA\]: xxxxxx”

#### Interactive Automation scripts: Only the value added in the last text box would be saved \[ID_29995\]

When, in interactive Automation scripts, you rapidly entered values in multiple text boxes, in some rare cases, only the value entered in the last text box would be saved.

#### Stopping an SLA would cause a “window change” event that would lead to outages being closed when history set alarms were received \[ID_29998\]

When an SLA is stopped while it has an open outage, the open outage will be closed with a timestamp containing the time at which the SLA was stopped. This ensures that all outages are closed in case the SLA starts again when no impacting alarms are present to open and later close the outage.

However, this event would be logged as a “window change”, causing the SLA to close and reevaluate the current alarms at the time the SLA was stopped whenever a history set alarm was received with a timestamp earlier than the time at which the SLA was stopped. This would then cause extra non-intended outages.

#### Interactive Automation scripts: Values shown in datetime controls would be out of sync with the values sent to the server \[ID_30015\]

In interactive Automation scripts, in some rare cases, the value shown in a datetime control would be out of sync with the value sent to the server. Also, in some cases, datetime controls could trigger updates even when their WantsOnChange property was set to false.

#### Synchronization of a cleared DMS.xml file would incorrectly cause all agents to remove them­selves from the DataMiner System \[ID_30023\] \[ID_30163\]

When a DataMiner Agent is starting up, it checks whether the DMS.xml file was changed while it was down. If changes are found, these are then synchronized among the other agents in the DataMiner System. However, up to now, when the DMS.xml file had been cleared and only contained either the IP address of the DataMiner Agent that was starting up or the name of the DataMiner System, this would incorrectly cause a cascade of delete operations throughout the DataMiner System, resulting in all the agents slowly removing themselves from the DataMiner System.

Also, when an outdated cluster configuration was left on a standalone DataMiner Agent after manually removing the DMS.xml file or after restoring a DataMiner backup, other agents in the DataMiner System could be triggered to leave the DataMiner System once the standalone agent was re-added to the cluster.

#### Failover: Network interface would not properly release the virtual IP address when being re-attached after being disconnected during a Failover switch \[ID_30033\]

When a network interface was disconnected or disabled during a Failover switch, in some cases, it would not properly release the virtual IP address when it was re-attached.

#### InstanceAlarmLevel would not fall back to CellActualAlarmLevel when there was bubble-up information but no instance information \[ID_30044\]

In case of a view table with bubble-up information and view columns with alarm information, up to now, the InstanceAlarmLevel property on the primary key cell would incorrectly be set to “Undefined” instead of the highest severity of those columns.

#### DataMiner Cube - Alarm Console: Problem when reconnecting after adding the “Severity Dura­tion” column \[ID_30099\]

When, in the Alarm Console, you added the Severity Duration column and then reconnected, on a large DataMiner System, Cube could become unresponsive.

#### Problem with SLNet during upgrade \[ID_30103\]

During a DataMiner upgrade, in some rare cases, a problem could occur in the cleanup connection thread of SLNet.

#### BPA tests could fail with a “BPA has an invalid signature” error \[ID_30118\]

On DataMiner Agents on which the latest Windows updates had not been installed, in some cases, BPA tests would fail with the following error:

```txt
BPA has an invalid signature
```

Also, the following entry would be added to the SLBpaManager.txt log file at DataMiner startup:

```txt
Ignoring certificate SkylineCodeSigning.cer: Certificate is not trusted by the machine
```

From now on, BPA tests that are signed with the Skyline code signing certificate will be forcefully loaded, and the following entry will be added to the SLBpaManager.txt log file:

```txt
Force loaded certificate: SkylineCodeSigning.cer (Skyline Certificate). WARNING! Machine might not have latest Windows Updates.
```

#### SNMPv1/SNMPv2 element could remain in a timeout state after its IP address had been first set to a non-existing address and then to its original address \[ID_30123\]

When you change the IP address of an SNMPv1 or SNMPv2 element that is polled using a “dynamic IP” parameter to a non-existing address, the element will go into timeout as it tries to poll that non-existing IP address. However, up to now, when you then changed the IP address back to the one the element had before, it would incorrectly remain in timeout until it was restarted.

Also, from now on, when an SNMP-related failure occurs, the log entry will include the error code. Where previously a log entry like “Unable to set destination port” would be added, DataMiner will now add a log entry like “Unable to set destination port (error code: 3)”.

#### DataMiner Cube - Backup: Users without “Backup \> Configure” permission would incorrectly be allowed to update the “Indexing Engine location” backup path \[ID_30131\]

In the *Backup* section of *System Center*, users without *Modules \> System configuration \> Backup \> Configure* permission would incorrectly be allowed to update the *Indexing Engine location* backup path.

#### DataMiner Cube - Scheduler: Users with permission to add tasks but not to edit them would not be able to save a newly created task \[ID_30132\]

When, in the Scheduler app, users created a new scheduled task, they were not able to save that task when they had permission to add tasks but not to edit them.

#### NATS logfile_size_limit setting would not automatically be added after a DataMiner upgrade \[ID_30146\]

When a DataMiner Agent using NATS was upgraded to a version containing the logfile_size_limit setting, that setting would not automatically be added to the nats-server.config file in the C:\\Skyline DataMiner\\NATS\\nats-streaming-server folder. It would only be added the first time you manually sent a NatsCustodianRestartNatsRequest message.

From now on, when a DataMiner Agent starts up after being upgraded and the nats-server.config does not contain the logfile_size_limit setting, it will be added at SLNet startup. Its value will by default be set to 10 MB.

#### DataMiner Cube - Users/Groups: Duplicate activity log entries \[ID_30162\]

When, in the *Users/groups* section of *System Center*, you opened a user card and selected the *Activity* tab, in some cases, the list would contain duplicate activity log entries.

#### DataMiner Cube - Visual Overview: Button to navigate to another card would no longer work after clicking the Back button \[ID_30167\]

When, on a visual overview, you clicked a button to navigate to another card and then clicked the Back button, in some cases, clicking the button to navigate to another card a second time would no longer open that other card.

#### SLLogCollector: Problem when process list update took longer than 1 second \[ID_30203\]

When SLLogCollector updated its list of processes, it would incorrectly try to update it again when the update took longer than 1 second.

#### DataMiner Cube: Not possible to unmask a masked EPM object \[ID_30208\]

In some cases, it would not be possible to unmask a masked EPM object. When you right-clicked, the shortcut menu’s *Unmask* command would incorrectly be disabled.

#### Service & Resource Management: Problem due to ReservationInstance locks not getting released \[ID_30281\]

When executing the start actions of a ReservationInstance, DataMiner locks that instance. In some cases, that lock would not get released, causing other operations involving that same instance or even the SLAutomation process to get blocked.

## Addendum CU6

### Enhancements

#### Security enhancements \[ID_30200\] \[ID_30323\] \[ID_30362\] \[ID_30363\] \[ID_30417\] \[ID_30422\] \[ID_30423\] \[ID_30561\]

A number of security enhancements have been made.

#### Dashboards app - Time range component: Selecting a preset timespan will now cause the name of that timespan to be added to the URL of the dashboard \[ID_27963\]

Up to now, when you selected a preset timespan (e.g. today, yesterday, etc.) in a time range component, the start time and end time of that timespan was added to the URL of the dashboard. From now on, when you select a preset timespan, the actual name of that timespan (e.g. today, yesterday, etc.) will be added to the URL instead.

#### DataMiner Cube - Trending: Enhanced input and validation of trend graph Y axis settings \[ID_30176\]

When you right-click on a trend graph and select “Y axis settings”, you can change the minimum and maximum Y-axis value for each numeric axis. A number of enhancements have now been made with regard to how these values are entered and validated.

#### Service & Resource Management: No longer possible to create a resource with invalid capacities and/or capabilities \[ID_30207\]

From now on, it will no longer be possible to add a resource with invalid capacities and/or capabilities.

- When you try to add a resource with “NULL” instead of a Capacity or with a Capacity of which the value is set to “NULL”, an error with reason ResourceCapacityInvalid will be added to the TraceData. The error’s ResourceManagerErrorData will contain the following properties:

    - ResourceId: The ID of the resource.

    - ResourceCapacity: The capacity object that did not reference a correct capacity profile.

- When you try to add a resource with “NULL” instead of a Capability or with a Capability of which the value is set to “NULL” and IsTimeDynamic set to FALSE, an error with reason ResourceCapabalityInvalid will be added to the TraceData. The error’s ResourceManagerErrorData will contain the following properties:

    - ResourceId: The ID of the resource.

    - ResourceCapability: The capability object that did not reference a correct capability profile.

#### Enhanced performance when creating function resources \[ID_30248\]

Due to a number of enhancements, overall performance has increased when creating function resources.

#### SLElement: Enhanced performance when processing table request filters \[ID_30262\]

Due to a number of enhancements, overall performance of SLElement has increased when processing table request filters.

#### SLElement: Enhanced performance when managing virtual elements \[ID_30274\]

Due to a number of enhancements with regard to the caching of key links, overall performance of the SLElement process has increased when managing virtual elements.

#### Enhanced performance when including/excluding elements in services based on parameter val­ues \[ID_30284\]

Due to a number of enhancements, overall performance has increased when including/excluding elements in/from services based on parameter values, especially when the same parameter is used in a large number of element inclusion conditions.

#### http://\[dma\]/root/tools/ page now allows you to install SECTIGO certificate \[ID_30297\]

DataMiner Cube files are now signed with a SECTIGO certificate.

You can install that certificate by clicking a hyperlink in the *DataMiner tools* section of the http://\[dma\]/root/tools/ page.

#### SLElement: Enhanced performance when starting up elements \[ID_30315\] \[ID_30316\]

Due to a number of enhancements, overall performance of SLElement has increased when starting up elements, especially DVE elements and elements with a large number of foreign keys, virtual functions, etc.

#### Enhanced performance due to improved locking mechanism \[ID_30328\]

Due to a number of enhancements to the internal locking mechanism, overall performance of all DataMiner processes has increased.

#### SLElement: Enhanced performance when resolving foreign keys \[ID_30348\] \[ID_30426\]

Due to a number of enhancements, overall performance of SLElement has increased when resolving foreign keys, especially when dealing with replicated elements.

#### DataMiner Cube - Bookings app: Enhancements made to bookings timeline and bookings list \[ID_30354\]

Up to now, whenever the “now” line re-appeared in the visible range of the bookings timeline, the Follow mode would automatically be enabled again. From now on, the Follow mode will instead get the status it had before the “now” line last disappeared from the visible range.

Also, when you change the time range in the booking timeline, the bookings list will now be refreshed instead of reset. In other words, the list will no longer be cleared and rebuilt before the list filter is re-evaluated.

#### SLNet will now notify SLWatchdog when it has updated VersionHistory.txt \[ID_30366\]

When the SLWatchdog process is started, it checks the VersionHistory.txt file to find out the DataMiner version running on the DataMiner Agent in question. The VersionHistory.txt file, located in the C:\\Skyline DataMiner\\Upgrades\\ folder of a DataMiner Agent, lists all the major upgrades that have been performed on that DataMiner Agent, each with the date at which the DataMiner Agent was first started after that particular upgrade.

Up to now, when SLNet updated the DataMiner version in VersionHistory.txt while SLWatchdog was running, the latter would not be aware of that change until it was restarted. From now on, SLNet will notify SLWatchdog when it has updated VersionHistory.txt.

#### DataMiner Cube: Links to deprecated DCP platform replaced by links to the new https://data­miner.services platform \[ID_30430\]

Throughout the Cube UI, all links to the deprecated DataMiner Collaboration Platform have been replaced by links to the new https://dataminer.services platform.

#### DataMiner Cube - Data Display: Memory consumption of tables showing service impact has been reduced \[ID_30433\]

Due to a number of enhancements, overall memory consumption of tables showing service impact has been reduced.

#### SLElement: Enhanced performance when processing updates in tables with foreign key columns \[ID_30434\]

Due to a number of enhancements, overall performance of SLElement has increased when processing updates in tables with foreign key columns.

#### DataMiner upgrade packages will now include StandAloneBpaExecutor \[ID_30438\]

The StandAloneBpaExecutor tool will now by default be included in DataMiner upgrade packages.

#### DVE elements and virtual functions will start faster when their main element is restarted \[ID_30457\]

Due to a number of enhancements, DVE elements and virtual functions will start faster when their main element is restarted.

#### Enhanced performance when stopping elements that are in a timeout state \[ID_30462\]

Due to a number of enhancements, overall performance has increased when stopping elements that are in a timeout state.

#### Dashboards app - GQI: Queries verified and repaired when opened for editing \[ID_30507\]

In the Dashboards app, when you open a GQI query to edit it, it will now first be verified and repaired if necessary. Only when verification and repair have finished, will you be able to edit the query.

#### Dashboards app - chart components: Loading indicator \[ID_30515\]

When you opened or refreshed a dashboard, up to now, the chart components on that dashboard would show “no data” until the data had been fully loaded. From now on, when data is being loaded into a state component or a chart component using data from a query, a loading indicator will be shown instead.

### Fixes

#### Dashboards app: Error messages would incorrectly be displayed multiple times \[ID_28544\]

When an error had been thrown in the Dashboards app, in some cases, multiple instances of the same error message would be displayed. From now on, each error message will only be displayed once.

#### Problems when initializing scheduled alarm templates \[ID_29783\] \[ID_30365\]

In some cases, an alarm template group that was either unassigned or assigned to a stopped element would not get updated when the schedule of one of the alarm templates in that group was enabled or disabled.

Also, when an alarm template schedule was started, in some cases, either the active state of that schedule or the entire schedule itself would be set incorrectly.

- When an alarm template with a schedule was edited while, according to its schedule, it was inactive, the following would happen:

    - The template would temporarily be activated, causing alarms to be created which would immediately be cleared.

    - When no active window was scheduled that day, the first window of the upcoming days would be used for that day.

- When an alarm template with a schedule was assigned to an element while, according to its schedule, it was inactive, it would be activated until the first window had passed.

- When an alarm template schedule contained an overlapping window because DataMiner Cube did not detect the incorrect configuration, the overlap would not get corrected and the schedule would get activated at random times.

- When an alarm template with a schedule was updated on a DMA that was part of a DataMiner System, elements running on other DMAs in that DataMiner System would not apply the new schedule until the DMA on which the template was updated was restarted or until another alarm template update occurred on that DMA.

NT_ADD_FILE (99) has now been adapted in order to better handle alarm template changes. When NT_ADD_FILE is called and the templateDetails variable (object 2) specifies the type as “1” (alarm template), then the protocolDetails variable (object 1) will optionally receive a fourth string value: “364” (NT_INITIALIZE_SCHEDULE) or “378” (NT_CLEAR_SCHEDULE). This will specifies how the template's schedule should be reloaded in the memory of SLDataMiner.

> [!NOTE]
> When no fourth string value is passed along, it will by default be set to NT_INITIALIZE_SCHEDULE as it is capable of handling a template without a schedule.

#### DataMiner Cube - Alarm templates: Hysteresis could incorrectly be applied to “low” severity lev­els for parameters of type string \[ID_30117\]

When applying hysteresis to specific alarm severity level for parameters of type string, up to now, it would incorrectly be possible to do so for “low” severity levels. From now on, for parameters of type string, it will only be possible to apply hysteresis to “high” severity levels.

> [!NOTE]
> If, for a string parameter, Hysteresis is set to “On” or “Off”, then the High and Low levels must be consistent. Both should either be enabled or disabled.

#### DataMiner Cube - Scheduler: Tasks with a type other than “Once” would incorrectly allow you to enter a date and a time in the start date box \[ID_30140\]

When you configure a scheduled task with a type other than “Once”, you can specify a start date and an end date. Up to now, the start date box would allow you to enter a date and a time. As this is not relevant, from now on, the start date box will only allow you to enter a date.

#### DataMiner Cube - Cassandra: Information events would not have the correct properties \[ID_30178\]

When you opened an information event on a DataMiner Cube connected to a system with a Cassandra database, in some cases, that information event would not have the correct properties. The problem was due to the properties being stored incorrectly into the database.

#### DataMiner Cube - Visual Overview: Problem with session variables that control an embedded Resource Manager component \[ID_30180\]

When a Resource Manager component is embedded in a visual overview, it can be controlled by a number of session variables. For example, with YAxisResources you can set the timeline bands and with SelectedReservation you can highlight a certain booking.

Normally, the bands must be updated before a new selection is set. However, in some cases, the selection was set first, both session variables were set simultaneously, or the time line band was set via an Execute page option. From now on, when timeline bands are updated, the latest “set booking selection” will be always be set again to make sure the selection is kept even when bands are changed or updated.

#### Problem with SLElement when the hysteresis timer was activated when an element was restarted \[ID_30212\]

In some rare cases, an error could occur in SLElement when the hysteresis timer was activated at the moment when an element was restarted.

#### SLDataGateway: “Connection was closed” error \[ID_30213\]

In some cases, a “connection was closed” error could occur in the SLDataGateway process.

#### CPU usage of SLASPConnection would surge after a service update \[ID_30242\]

On systems with a large number of services, in some cases, the CPU usage of the SLASPConnection process would temporarily surge after a service had been updated.

#### DataMiner Cube - Surveyor: Newly created element would be displayed twice after being updated \[ID_30258\]

When a newly created element was in multiple views, and at least two of these views had been opened in the Surveyor, in some cases, the element would incorrectly be displayed twice in the same view after being updated.

#### DataMiner Cube could become unresponsive when the Bookings app was closed \[ID_30261\]

In some cases, DataMiner Cube could become unresponsive when you closed the Bookings app.

#### DataMiner Cube - Visual Overview: Problem when the parent shape of a shape with an embed­ded Chromium web browser control had a show/hide condition configured \[ID_30270\]

In some rare cases, an exception could occur when, in a visual overview, the parent shape of a shape with an embedded Chromium web browser control had a show/hide condition configured.

#### Problem with SLElement when changing an alarm template of a DVE element that contained references to general parameters in conditional monitoring rules \[ID_30277\]

When a DVE element had its alarm template updated, was assigned a new alarm template or went to “not monitored”, in some cases, an access violation error could occur in SLElement when the alarm template contained references to general parameters in conditional monitoring rules.

#### DataMiner Cube - Services app: Same connection could incorrectly be drawn twice in diagram \[ID_30291\]

When drawing connections between nodes in a service definition diagram, in some cases, it would incorrectly be possible to draw the same connection twice.

#### Web apps: Problems with DefaultTimeZone setting \[ID_30301\]

The time displayed in the DataMiner web apps (e.g. Jobs, Dashboards, etc.) is based on the DefaultTimeZone setting in the *C:\\Skyline DataMiner\\Users\\ClientSettings.json* file.

Up to now, the following problems could occur with regard to this setting:

- When DefaultTimeZone was set to a time zone without offset (e.g. UTC), in some cases, an error message could appear.

- In the Dashboards app and the Monitoring app, the configured time zone would not always be applied correctly.

#### Cassandra cluster: Problems with cluster health monitoring & data offloads \[ID_30310\]

In some cases, an incorrect consistency level and replication factor would be used when assessing the health of the Cassandra cluster.

Also, a problem could occur when offloading data to a file.

#### DataMiner Cube - Alarm Console: Sources of correlated alarms would incorrectly not be removed from the Alarm Console \[ID_30311\]

In some rare cases, the sources of a correlated alarm would incorrectly not be removed from the Alarm Console.

#### BPA tests: Version compatibility test would fail when a BPA test was run on a Feature Release version instead of a Main Release version \[ID_30312\]

A BPA test can only be executed if it has been digitally signed by Skyline, and if your DataMiner version is within the limitations of the minimum and/or maximum DataMiner version configured in the test (if any). However, up to now, the version compatibility test would fail when a BPA test was run on a Feature Release version instead of a Main Release version.

The version compatibility test has now been adapted:

- When no minimum and/or maximum DataMiner version is specified, the BPA test will run regardless of the version.

- When a minimum and/or maximum DataMiner version is specified, the BPA test will run when the DataMiner Agent has

    - a Main Release version greater than the minimum Main Release version and smaller than or equal to the maximum Main Release version, or

    - a Feature Release version greater than the minimum Feature Release version and smaller than or equal to the maximum Feature Release version, or

    - a Release version of which the Main Release on which it is based is greater than the minimum Feature Release version and smaller or equal to the maximum Feature Release version.

#### SLNet would fail to initialize when external authentication via SAML was configured incorrectly \[ID_30318\]

When external authentication via SAML was configured incorrectly, up to now, SLNet would fail to initialize. From now on, a “Failed to build External Authentication for SAML” notice will be generated instead and SLNet will continue its initialization routine.

#### SLAnalytics: “Division by zero” error when encountering an invalid polling time in legacy param­eterInfo records \[ID_30321\]

In some cases, a “division by zero” error could occur in SLAnalytics when encountering an invalid polling time in legacy parameterInfo records.

#### DataMiner Cube - Alarm Console: Submenu of Copy command not shown in right-click menu \[ID_30334\]

When, in the Alarm Console, you selected all alarms with element name “DMA” and then right-clicked to open the shortcut menu, the submenu of the “Copy” command would incorrectly not be shown.

#### DVE elements / Virtual functions: Alarms in tables would not get re-evaluated when foreign keys linking those tables to other tables had changed \[ID_30336\]

In some cases, alarms in tables would not get re-evaluated when foreign keys linking those tables to other tables had changed.

#### Problem with SLDataMiner \[ID_30359\]

In some cases, the SLDataMiner process could become unresponsive due to a problem with its element locking mechanism.

#### Enabling or disabling a Failover setup would break the Cassandra cluster \[ID_30361\]

When either enabling or disabling a Failover setup using a Cassandra cluster, in some cases, the Cassandra cluster would break.

#### Failover: “DB forwarding is failing” alarm would incorrectly be generated when using Cassandra Cluster \[ID_30392\]

In a Failover environment using a Cassandra Cluster, in some cases, the following alarm would incorrectly be generated:

```txt
Failover DB forwarding is failing since YYYY-MM-DD HH:MM:SS
```

#### DataMiner Cube - Visual Overview: Service definition passed in a session variable to an embed­ded Service Manager component would not be selected in that component \[ID_30396\]

When a service definition was passed in a session variable to an embedded Service Manager component, in some cases, that service definition would not be selected and, as a result, its diagram would not be loaded.

#### EPM: All clients would incorrectly receive view updates when one view was enhanced \[ID_30412\]

When, in an EPM environment, you enhanced a view on a particular DataMiner Agent in the DMS, all clients connected to any of the other DataMiner Agents in the DMS would incorrectly receive updates for all of the enhanced views in the system.

#### Legacy Reports & Dashboards - Alarm List: History alarms with missing ‘Hosting DataMiner ID’ & GetAlarmTreeDetailsMessage not working for imported elements \[ID_30415\]

When, in the legacy Reports & Dashboards app, the Alarm List component requested the alarm tree details, all history alarms would incorrectly have a hosting DataMiner ID equal to -1 and using the GetAlarmTreeDetailsMessage with Hosting DataMiner ID and Root Alarm ID did not work for elements imported by means of a DELT package.

#### Failover: SLASPConnection would be unaware of the local DMA ID \[ID_30416\]

On a Failover setup, part of the SLASPConnection process would be unaware of the local DataMiner ID. In some cases, this could lead to “Handle Notifications Thread” errors.

#### Security: Problems when adding domain users and domain groups \[ID_30428\]

In some cases, a problem could occur when adding a domain user or a domain group to DataMiner.

#### Dashboards app - GQI: Queries could cease to function when items used in those queries were renamed \[ID_30436\]

Up to now, in some cases, a GQI query could cease to function when items used in that query (e.g. parameters, profile definitions, etc.) were renamed.

#### Dashboards app - State timeline: Problem with state change highlighting in Mozilla Firefox \[ID_30446\]

When using the Dashboards app in Mozilla Firefox, the state timeline component would not highlight the correct state change when you hovered over the component.

#### DataMiner Cube: Problem when opening a service \[ID_30471\]

In DataMiner Cube, in some cases, a stack overflow exception could be thrown when you opened a service.

#### Incorrect exceptions thrown when installing a DataMiner upgrade package \[ID_30516\]

When you install a DataMiner upgrade package, a number of checks are performed before the upgrade is started. In some cases, one of those checks would throw incorrect ZipExceptions.

#### DataMiner Cube - Visual Overview: Asterisk in shape text of an “Info” shape would not be replaced when the shape text contained more than just the asterisk \[ID_30534\]

When the shape text of an “Info” shape contained more than just an asterisk (“\*”), in some cases, the asterisk would not be replaced with the information specified in the Info shape data field.

#### DataMiner Cube - Tab layout: Clicking e.g. an element multiple times would incorrectly each time open a new instance of the card in question \[ID_30541\]

When in tab layout, clicking e.g. an element multiple times would incorrectly each time open a new instance of the card in question.

> [!NOTE]
> When, on a visual overview, you click a button to navigate to another card and then click the *Back* button, in some cases, clicking the button to navigate to another card a second time may no longer open that other card.

#### Legacy Reporter app - Bookings component: Not possible to select properties \[ID_30547\]

When, in the legacy Reporter app, you had created a report template with a booking component of which the type was set to “list”, in some cases, it would not be possible to select properties to be included in the report.

#### DataMiner Cube - Data Display: Table cells would not contain their current value when in edit mode \[ID_30553\]

In some cases, when you had changed a value in a table cell, and then clicked inside that same cell to change the value again, the cell would not contain the current value. Instead, it would contain the value it contained before the first change.

#### DataMiner Cube - Service & Resource Management: Missing icons in service definitions \[ID_30619\]

In some cases, icons could be missing in service definitions because SVG content could not be loaded.

#### Dashboards & Monitoring apps - Popups no longer working \[ID_30797\]

In the Dashboards app and the Monitoring app, in some cases, no popup would appear when you clicked a page button.

## Addendum CU7

### Enhancements

#### Security enhancements \[ID_30124\] \[ID_30479\] \[ID_30570\] \[ID_30581\] \[ID_30597\] \[ID_30600\] \[ID_30604\] \[ID_30786\]

A number of security enhancements have been made.

#### Service & Resource Management: Interface state calculation for virtual function interfaces dis­abled \[ID_30537\]

As the interfaces of virtual functions are generated from a table that cannot be monitored, the interface state calculation for these interfaces is now disabled. This may result in improved performance.

#### Service & Resource Management: Improved performance when processing virtual functions \[ID_30585\]

A number of enhancements have been implemented to improve performance when processing virtual functions.

#### Alarm templates - Smart baselines: Calculated baseline values outside the value range will automatically be set to the nearest value in the range \[ID_30704\]

When a calculated baseline value is outside the baseline value range, from now on, it will automatically be set to the nearest value in the range.

Examples:

- If the baseline value range is 10-50 and the calculated value is 7, it will be set to 10.

- If the baseline value range is 10-50 and the calculated value is 58, it will be set to 50.

#### Dashboards app - Table components: Selecting multiple rows on an Apple Mac computer \[ID_30734\]

When working inside a table component using an Apple Mac computer, up to now, it was not possible to select multiple rows. From now on, users of an Apple Mac computer will be able to select multiple table rows while holding down the *Command* key.

Also, on an Apple Mac computer, it will now be possible to sort a table on multiple columns by clicking column headers while holding down the *Command* key.

#### SLElement: Enhanced performance when looking up linked rows after a foreign key has changed \[ID_30747\]

Due to a number of enhancements, overall performance of SLElement has increased when looking up linked rows after a foreign key has changed.

#### Web Services API v1: SetParameter and SetParameterRow methods can now also be used to update parameters of enhanced services \[ID_30823\]

The SetParameter and SetParameterRow methods of the DataMiner Web Services API v1 can now also be used to update parameters of enhanced services.

### Fixes

#### Ticketing app: Problem with drop-down fields \[ID_29478\]

When you added or updated options in a field of type “drop-down list”, in some cases, the default values of those options were not filled in correctly.

Also, when you turned a field into a field of type “drop-down list”, in some cases, a null reference exception could be thrown.

#### Slow initial synchronization of services in DMS \[ID_30074\]

In some cases, it could occur that the initial synchronization of services in a DMS was slow because of unnecessary errors generated in the SLDMS process. Usually, an error similar to the following was logged:

```txt
2021/06/03 01:00:00.302|SLDMS.txt|SLDMS.exe 10.1.2118.668|13524|26072|CSystem::ResolveServicePaths|ERR|-1|Failed resolving hosting DMA info for 10.10.80.20 and service RT_ServiceCreationDelete_66_2021_06_03_00_58
```

#### Dashboards app - GQI: “Start from” option would not be available when the Queries.json file was empty or missing \[ID_30157\]

When building a GQI query, in some cases, the “Start from” option would not be available when the *C:\\Skyline DataMiner\\Generic Interface\\Queries.json* file was empty or missing.

#### Improved performance when including/excluding elements in services based on alarm or ele­ment alarm state \[ID_30303\]

Performance has improved when elements are dynamically included or excluded in a service based on alarm state or element alarm state.

#### Dashboards app: Problem with query linked to table component \[ID_30372\]

When a query in a dashboard was linked to a table component, it could occur that the query could not be rebuilt. In some cases, an error was shown in the data pane, e.g. "Cannot ready property 'selectedBlock' of undefined".

#### Problem with conditional monitoring after alarm template update \[ID_30531\]

When an alarm template was refreshed in the SLElement process, e.g. because the alarm template was modified or the baseline changed, it could occur that conditional monitoring was ignored for standalone parameters. Because of this, if a parameter was not monitored because the condition for this was met, it was shown as monitored regardless.

#### Dashboards app: Table incorrectly identified by display name instead of ID \[ID_30591\] \[ID_30684\]

Previously, if a query in a dashboard used the data source "Get parameter table by ID", the table was identified by its display name. However, as this is not necessarily unique in a protocol, this could cause incorrect results. New queries will now us the table ID as the identifier, though they will display the name in the UI.

#### Automation: CheckboxList and RadiobuttonList not decoding "\\" correctly \[ID_30605\]

In an interactive Automation script, it could occur that the *CheckboxList* and *RadiobuttonList* components did not correctly decode a backslash ("\\") character.

#### Information about running elements missing in SLProtocol logging \[ID_30612\]

Since DataMiner 9.6.0/9.6.1, information about running elements could be missing in the SLProtocol logging.

#### DataMiner Cube - Spectrum Analysis: Problem when retrieved client session data contained duplicate keys \[ID_30644\]

When you open a spectrum analyzer element in Cube, it will retrieve all client sessions of that spectrum element. Up to now, when the retrieved client session data contained duplicate keys, an exception could be thrown. From now on, a log entry will be generated instead.

#### GetAlarmFilterResponse and GetTrendFilterResponse messages caused protocol buffer serial­ization errors \[ID_30650\]

In some cases, it could occur that the *GetAlarmFilterResponse* and *GetTrendFilterResponse* messages failed to be serialized even though these were marked as eligible for protocol buffer serialization. An error similar to the following could be displayed in the Cube logging:

```txt
Message : Index was outside the bounds of the array.
Exception : (Code: 0x80131508) Skyline.DataMiner.Net.Exceptions.DataMinerException: Index was outside the bounds of the array. ---> System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at System.Collections.Generic.List\`1.Add(T item)
   at Skyline.DataMiner.Net.Serialization.ProtoBufSerializationManager.Log(String method, String text)
   at Skyline.DataMiner.Net.Serialization.ProtoBufSerializationManager.ProtoBufPackMessage(DMSMessage rawMessage)
```

The scenarios where these messages cannot be serialized will now be handled better, so that they can no longer cause errors. In addition, to make it easier to troubleshoot errors with protocol buffer serialization, a new *SLProtobufSerialization.txt* log file is now available.

#### DataMiner Cube: Problem with table filters \[ID_30658\]

In Data Display and Visual Overview, in some cases, table filters could yield incorrect results when they contained numeric column filters with a “\<=”, “=”, or “=>” operator.

####  DataMiner Cube: No reports or alarm heatlines shown for view table parameters \[ID_30667\]

Up to now, for view table parameters, no reports were shown on the details page for the parameter in DataMiner Cube. In addition, no alarm heatline was shown for these parameters in trend graphs.

#### Spelling error in exception when minimum software version requirements for app package not met \[ID_30672\]

When an app package was installed on a DMA but the minimum software version requirements were not met, the exception message contained a spelling error.

```txt
Could not install the package because it requires DataMiner version {appInfo.MinDmaVersion}, but this agent us running version {dataMinerVersion}.
```

####  Dashboards app: Trace not displayed for spectrum buffer \[ID_30686\]

If a Spectrum analyzer component in the Dashboards app was used to visualize a spectrum buffer, it could occur that the buffer trace was not displayed.

####  CRC parameter with LengthType “fixed” and RawType “other”, “text” or ”numeric text” would incorrectly always be set to 0x20 or 0x30 \[ID_30730\]

When a CRC parameter with LengthType “fixed” and RawType “other”, “text” or “numeric text” was used in a command, it would incorrectly always be set to 0x20 characters for parameter of type “string” or 0x30 characters for parameters of type “double”.

####  Problem with SLDataMiner when using alarm templates with a monitoring schedule \[ID_30732\]

In some cases, an error could occur in SLDataMiner when alarm templates with a monitoring schedule were being used.

####  Problem with SLDataMiner when an element was restarted while a protocol exporting DVE or function protocols was being uploaded \[ID_30743\]

In some cases, an error could occur in SLDataMIner when an element was restarted while a protocol exporting DVE or function protocols was being uploaded.

####  DataMiner Cube - Visual Overview: Cube could become unresponsive while retrieving service states \[ID_30762\]

When a visual overview with at least one service shape was open when you opened a Cube, and the initial service states had not yet been received, in some cases, Cube could become unresponsive while retrieving the service states.

#### DataMiner Cube: Problem when hovering the mouse pointer over an alarm storm warning \[ID_30799\]

When, during an alarm storm, you hovered the mouse pointer over the alarm storm warning, in some cases, an exception could be thrown.

####  DataMiner Cube - Alarm Console: Comments containing a new line would be displayed incorrectly \[ID_30801\]

When an alarm contains one or more comments, you can right-click it and select “View comments” to see all comments in the alarm tree in question. In that list, up to now, comments containing a new line would not be displayed correctly.

## Addendum CU8

### Enhancements

####  SLLogCollector: Command line support \[ID_26293\]

The SLLogCollector tool now supports the following command line options:

| Option             | Function                                                                                         |
|--------------------|--------------------------------------------------------------------------------------------------|
| -c, --console      | Use the SLLogCollector console.                                                                  |
| -h, -?, --help     | List syntax and available options.                                                               |
| -f, --folder=VALUE | Specify the folder in which the zipped log files will be stored.<br> Default: C:\\Skyline_Data\\ |
| -d, --dumps=VALUE  | Specify the comma-separated list of processes from which dumps should be taken (IDs or names).   |
| -m, --memory=VALUE | Take an extra dump as soon as the process uses the specified amount of memory (in MB).           |

#### StandAloneBPAExecutor: New command line option to save test result to file \[ID_27776\]

The StandAloneBpaExecutor tool, which can be found in the C:\\Skyline DataMiner\\Tools folder of a DMA, can be used to execute BPA (Best Practice Analysis) tests.

When using this tool to run a test from a command line, it is now possible to have the test result stored in a JSON file.

| Option                                                      | Function                                                   |
|-------------------------------------------------------------|------------------------------------------------------------|
| -f “PATH/TO/FILE.json”<br> or<br> -file “PATH/TO/FILE.json” | Specify the file in which the test results will be stored. |

#### Cassandra: Alarm squashing setting will by default be set to false when it cannot be requested from SLNet \[ID_30309\]

From now on, when it is not possible to request the value of the alarm squashing setting from SLNet when retrieving alarms from a Cassandra database, by default the alarm squashing setting will be considered false.

#### Alarm templates: Baseline editor now allows you to configure baselines and smart baselines specified in protocols \[ID_30388\] \[ID_30461\]

Up to now, when a parameter had a (smart) baseline value specified in the protocol, it was not possible to update that (smart) baseline value in Cube’s alarm template baseline editor. From now on, that editor will allow you to configure (smart) baselines specified in protocols.

> [!NOTE]
> - The alarm template baseline editor will not allow you to change the monitoring type (Normal, Relative, Absolute or Rate).
> - When a baseline is specified in a protocol, the baseline value is stored in a separate parameter. Although you should specify a read parameter (e.g. \<Alarm type="absolute:READ_PARAM_ID,108">), make sure that read parameter has an associated write parameter. Otherwise, it will not be possible to update the baseline value stored in that parameter. Also, the parameter in which the baseline value is stored must be free of any restrictions (e.g. step size, number of decimals, high/low range, etc.)

#### Security enhancements \[ID_30494\]

A number of security enhancements have been made.

#### No longer possible to launch a system-wide upgrade procedure when one agent fails to upload the upgrade package \[ID_30511\]

Up to now, when an agent in a DataMiner System failed to upload a DataMiner upgrade package, it would still be possible to launch the system-wide upgrade procedure. From now on, as soon as one of the agents in a DataMiner System fails to upload an upgrade package, it will not be possible to launch a system-wide upgrade procedure.

#### SLElement: Enhanced service impact calculation \[ID_30648\]

A number of enhancements have been made to the way in which SLElement calculates the service impact of an alarm.

#### Enhanced performance when enabling virtual functions with monitored parent elements \[ID_30673\]

Due to a number of enhancements, overall performance has increased when enabling virtual functions with monitored parent elements.

#### Interactive Automation scripts: File selector component can now be configured to only allow a script to continue after a file has been uploaded \[ID_30728\]

In an interactive Automation script that is used in Dashboards, you can now configure a file selector component to only allow a script to continue after a file has been uploaded. To do so, set the property *IsRequired* to true.

For example:

```txt
UIBlockDefinition uibDef = new UIBlockDefinition();
uibDef.Type = UIBlockType.FileSelector;
...
uibDef.IsRequired = true;
```

#### Enhanced performance when determining the virtual impact of an alarm \[ID_30766\]

Overall performance has increased when determining the virtual function impact of an alarm.

Also, a number of issues have been fixed with regard to displaying statuses of virtual function alarms, exporting alarms to DVE child elements, masking of external alarms and updating virtual function states when alarms are cleared.

#### DataMiner Cube - Alarm Console: Availability of “Count alarms” button now depends on the alarm filter that was specified \[ID_30810\]

When, in the Alarm Console, you add a new history or sliding window tab page, you can add a filter by clicking *Apply filter*. After configuring that filter, you can click *Count alarms* to see how many alarms will be retrieved when that filter is applied. However, up to now, when the filter contained one of the following items, it would not be possible to count the number of alarms that matched the filter:

- ElementType

- InterfaceImpact

- ParameterDescription

- Protocol

- ServiceImpact

- ViewID

- ViewImpact

- ViewName

- VirtualFunctionID

- VirtualFunctionImpact

- VirtualFunctionName

From now on, when the alarm filter contains one of the above-mentioned items, the *Count alarms* button will not be available.

####  Automation scripts: SLAnalyticsTypes.dll added to the list of default DLL references \[ID_30821\]

All Automation scripts will now by default have a reference to the SLAnalyticsTypes.dll file.

#### BREAKING CHANGE: DataMiner installer will only enable ICMP and HTTP ports 80 & 8004 \[ID_30913\]

From now on, the DataMiner installer will by default only enable

- ICMP (ping) and

- HTTP ports 80 and 8004.

> [!NOTE]
> When you enable Telnet or the SNMP agent feature, from now on, you will have to manually create a firewall rule for the HTTP ports in question.

#### DataMiner Cube - Aggregation: Enhanced performance \[ID_30917\]

Due to a number of enhancements, overall performance of the Aggregation module has increased.

#### SLDataGateway: Enhanced startup routine \[ID_30934\]

A number of enhancements will now allow the SLDataGateway process to handle Cassandra exceptions and file offload initialization errors more efficiently, which may prevent startup issues.

#### Ticketing: FieldName of TicketFieldDescriptor can no longer contain certain characters [ID_30962]

From now on, the FieldName of a TicketFieldDescriptor has to meet the following requirements:

- It cannot start with an underscore character ("\_").
- It cannot contain any of the following characters:

    - . (period)
    - \# (number sign)
    - \* (asterisk)
    - , (comma)
    - " (double quote)
    - ' (single quote)

#### DataMiner Cube - System Center: Enhanced “Limited administrator” tooltip \[ID_31042\]

When, in the *Users/Groups* section of *System Center*, you hover over the *Modules \> System configuration \> Security \> Specific \> Limited administrator* permission, a tooltip gives you more information about that permission. That tooltip now contains the following updated text:

```txt
* Read-only access on all groups * Read-only access to users in your groups * Create new DataMiner users * Editing your own user properties
```

### Fixes

####  Problem when starting Kibana after restoring an Elasticsearch backup \[ID_29943\]

After restoring an Elasticsearch backup that was taken with the StandaloneElasticBackup tool, in some cases, it would no longer be possible to start Kibana when Elasticsearch had security enabled.

#### Dashboards app - Node edge graphs: Parameter values in node tooltips would incorrectly show “not initialized” \[ID_30694\]

When you hovered over a node, parameter values shown in the node tooltip would incorrectly be set to “not initialized”.

#### Elasticsearch installations would fail on systems on which Cassandra was installed remotely \[ID_30731\]

On systems on which Cassandra was installed remotely, in some cases, Elasticsearch installations would fail.

####  DataMiner Cube - Settings: User group settings not taken into account when applying regional settings \[ID_30813\]

When starting up, up to now, Cube would load the regional settings before loading the user group settings. As a result, it would only take into account the user settings when applying the regional settings. From now on, Cube will also take into account the user group settings when applying the regional settings.

####  SLSNMPManager: Problem when using MultipleGetBulk to poll a table containing only a single row \[ID_30815\]

When MultipleGetBulk was used to poll a table that contained only a single row and the response from the device was cut because it exceeded the maximum package size, in some cases, the algorithm would get stuck into an infinite loop.

#### DataMiner Cube - Visual Overview: Child shapes representing alarms would incorrectly appear on a white background \[ID_30820\]

When generating child shapes that represent alarms, up to now, those child shapes would always appear on a white background, even when the Cube theme was set to e.g. Skyline Black.

From now on, generated child shapes that represent alarms will appear on a transparent background instead.

#### Confusing “Already authenticated error” would be thrown when an error occurred during an authentication process \[ID_30827\]

When an error occurred during an authentication process, in some cases, a confusing “Already authenticated” exception would be thrown instead of the actual error message. From now on, the actual error message will be thrown.

#### DataMiner Cube: Alarm counter in alarm storm warning did incorrectly not decrease when alarms were cleared \[ID_30836\]

When, during an alarm storm, you hover the mouse pointer over the alarm storm warning, a tooltip appears, showing you which alarms are causing the storm and the number of alarms per parameter. Up to now, when one of those alarms got cleared, the number of alarms shown in the tooltip would incorrectly not decrease.

#### Compiled QAction DLL files would incorrectly not be deleted from the ProtocolScripts folder when a protocol was deleted \[ID_30841\]

When a protocol was deleted, up to now, the compiled QAction DLL files would incorrectly not get deleted from the C:\\Skyline DataMiner\\ProtocolScripts folder.

#### SLElement: ParameterThread error \[ID_30855\]

In some cases, a ParameterThread error could occur in SLElement.

####  Interactive Automation scripts: Value returned by the client would incorrectly be considered as an invalid file path selected in a file selector block \[ID_30879\]

When, in an interactive Automation script, a file selector block was defined after another type of input block (e.g. a checkbox), in some cases, the input block value returned by the client would incorrectly be considered as an invalid file path selected in the file selector. As a result, an “Invalid Data” error would be thrown.

#### DataMiner Cube - Alarm Console: Incorrect notices like “!! Unknown \<Type> R!AD for parameter xxx” \[ID_30884\]

In some rare cases, notices like “!! Unknown \<Type> RE!D for parameter 123” would incorrectly appear in the Alarm Console.

#### Protocols: Double values with leading zeros would not be displayed correctly when using scien­tific notation \[ID_30892\]

In some cases, double values with leading zeros would not be displayed correctly when using scientific notation.

####  Protocols: QActions and their compiled versions could get linked incorrectly \[ID_30896\]

In some rare cases, errors occurring in SLScripting or SLProtocol could cause QActions and their compiled versions to be linked incorrectly.

####  SLReset tool would incorrectly stop deleting files when it encountered a locked file \[ID_30906\]

In some cases, the SLReset tool would incorrectly stop deleting files when it encountered a locked file.

#### DataMiner Cube - View cards: Aggregation page would incorrectly be loaded as soon as a view card was opened \[ID_30907\]

In some cases, the Aggregation page of a view card would incorrectly be loaded as soon as you opened the card. From now on, the Aggregation page of a view will only be loaded when you select that page.

#### DataMiner Cube - Service definitions: Selection boxes would incorrectly contain raw values instead of display values \[ID_30916\]

When you configured a service definition, in some cases, selection boxes would incorrectly contain raw values instead of display values.

#### Problem when disabling a virtual function and then enabling it again \[ID_30918\]

When you disabled a virtual function and then enabled it again, in some rare cases, it would incorrectly disappear from the system.

#### Problem with SLDataMiner when deleting a service or a redundancy group \[ID_30925\]

In some cases, an error could occur in SLDataMiner when a service or a redundancy group was deleted.

#### Automation: Problem with ScriptEntry.GetHashCode method \[ID_30939\]

In some cases, calling the ScriptEntry.GetHashCode method could cause a NullReference-Exception to be thrown.

####  Problem with SLAutomation when a Timespan.MaxValue timeout had been defined \[ID_30946\]

In some cases, SLAutomation would throw an ArgumentOutOfRangeException when a Timespan.MaxValue timeout had been defined.

#### Legacy Reporter: Problem with SLASPConnection when requesting trend statistics \[ID_30966\]

In some cases, an error could occur in SLASPConnection when requesting trend statistics (Minimum/Maximum/Average).

#### Alarms in tables that were part of multiple relation paths for different DVEs would not get re-evaluated when a DVE was created \[ID_30979\]

In some cases, an alarm in a table that was part of multiple relation paths would not get re-evaluated when a DVE in one of those paths exported that alarm. As a result, the alarm would not get exported to the DVE child element, causing the element state to become incorrect.

####  DVE element information would no longer be written to the database \[ID_31004\]

In some cases, DVE element information would no longer be written to the database due to a NullReferenceException in SLDBConnection.

####  DataMiner Cube - Visual Overview: Problem with navigation buttons on visual pages after click­ing a card’s Back button \[ID_31012\]

When you clicked a card’s Back button, in some cases, the navigation buttons on the card’s visual pages could start to behave incorrectly.

#### DataMiner Cube: Asset Manager app failed to initialize \[ID_31072\]

In some cases, the Asset Manager app would fail to initialize.

#### Run-time errors in ParameterThread when defining a column parameter in the functions.xml \[ID_31074\]

In some cases, run-time errors could occur in the ParameterThread when defining a column parameter in the functions.xml.

#### Table row exports for DVEs and virtual functions would trigger updates to be sent when no client applications were connected \[ID_31156\]

In some cases, table row exports for DVEs and virtual functions would trigger updates to be sent, even when no client applications were connected.

## Addendum CU9

### Enhancements

#### Security enhancements \[ID_31048\] \[ID_31122\]

A number of security enhancements have been made.

#### Restoring a DataMiner backup package will no longer be possible when the package was cre­ated on a system with a different DataMiner version \[ID_30921\]

From now on, it will no longer be possible to restore a DataMiner backup package on a system with a DataMiner version that is different from the one on which the backup was taken.

####  DataMiner upgrade: All agents in the DataMiner System must now meet the requirements before an upgrade of the entire DataMiner System can proceed \[ID_31002\]

When you start an upgrade of an entire DataMiner System, from now on, all agents in that DataMiner System will be checked to determine if they meet the requirements specified in the upgrade package. If one of the agents does not meet the requirements, the entire upgrade will be aborted.

> [!NOTE]
> This check is performed when you upload an upgrade package. When, in DataMiner Cube, you select *Upload only*, the uploaded upgrade package will be marked “Failed” when the requirements are not met.

#### SLLogCollector: Option “Upload to Skyline” removed \[ID_31032\]

Up to now, when an internet connection was available on the DMA, the SLLogCollector tool provided an option to upload the collected information to Skyline via email. This “Upload to Skyline” option has now been removed.

#### DataMiner Cube - Data Display: Enhanced performance when opening an element with a tree control parameter \[ID_31099\]

Due to a number of enhancements, overall performance of DataMiner Cube has increased when opening an element with a tree control parameter.

####  DataMiner Cube - Visual Overview: Enhanced updating of resource, booking and service booking information \[ID_31153\]

A number of enhancements have been made with regard to updating resource, booking and service booking information in Visual Overview.

####  Minor enhancements to several DataMiner processes \[ID_31155\]

A number of minor enhancements have been made to a number of DataMiner processes (e.g. SLXml, SLWatchdog, SLDMS, SLASPConnection and SLNet).

#### NATS upgraded to version 2.2.6 + new NATS SLNet settings \[ID_30156\]

To improve support for previous enhancements, the NATS version used by DataMiner has been upgraded to version 2.2.6.

In addition, two new options are available to refine the NATS settings in *MaintenanceSettings.xml* (in the \<SLNet> element):

- *NATSLogFileCleanupMs*: Determines the time (in milliseconds) between NATS log file cleanup attempts. This timing will only be applied after the next cleanup attempt after the configuration change. For example, if the next cleanup attempt is in 15 minutes and you change this value, the next cleanup will still be in 15 minutes, but all subsequent cleanups will happen after 1-minute intervals. The default value of this setting is 900000 (15 minutes).

- *NATSLogFileAmountToKeep*: The number of log files to keep (default =10). This value only applies to the log files that do not have the .log extension.

For example:

```xml
<MaintenanceSettings>
  ...
  <SLNet>
    ...
    <NATSLogFileCleanupMs>60000</NATSLogFileCleanupMs>
    <NATSLogFileAmountToKeep>20</NATSLogFileAmountToKeep>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

####  UDP port 162 opened by default \[ID_31035\]

In the default firewall configuration, from now on, UDP port 162 will again be opened by default.

> [!NOTE]
> On systems that do not rely on SNMP traps, it is recommended to close this port.

####  Cassandra cluster: Unnecessary scheduled maintenance tasks will automatically be deleted \[ID_31180\]

When a Cassandra cluster is starting up, the following scheduled tasks will automatically be deleted in Windows Task Scheduler:

- DBGatewayMaintenance/SLDefaultCassandraCompaction

- DBGatewayMaintenance/SLCassandraDefaultRepair

####  DataMiner Cube - Update Center: Enhanced error handling \[ID_31191\]

A number of enhancements have been made with regard to error handling and the rendering of error messages in Update Center.

####  DataMiner Cube - Visual Overview: Chromium web browser engine now supports find and zoom functionality \[ID_31232\]

The Chromium web browser engine now support find and zoom functionalities.

Available shortcuts:

| Shortcut     | Alternative shortcut | Command       |
|--------------|----------------------|---------------|
| Ctrl-F       |                      | Find          |
| Ctrl-G       | F3                   | Find next     |
| Shift-Ctrl-G | Shift-F3             | Find previous |
| Escape       |                      | Cancel find   |
| Ctrl-Plus    | Ctrl-MouseScrollUp   | Zoom in       |
| Ctrl-Minus   | Ctrl-MouseScrollDown | Zoom out      |
| Ctrl-0       |                      | Reset zoom    |

####  BPA framework: Cluster BPAs can now execute code across the entire cluster \[ID_31266\]

Cluster BPAs can now call an InvokeCluster method to execute code across the entire cluster.

#### Standalone BPA Executor: UI enhancements \[ID_31303\]

In the *Run from DMA* tab, the *Delete* and *Save* commands have been removed from the right-click menu and replaced by the following buttons:

| Button             | Function                                |
|--------------------|-----------------------------------------|
| Delete             | Delete all selected tests.              |
| Save Tests Results | Save the results of all selected tests. |

> [!NOTE]
> The *Get Last Results* button will now only fetch the most recent results for any selected tests that are run on a schedule.

####  DataMiner Cube - Services app: Enhanced performance when saving all changes made to ser­vice definitions \[ID_31355\]

Due to a number of enhancements, overall performance has increased when clicking *Save all changes* to save all changes made to service definitions in the Services app.

### Fixes

####  DataMiner Cube - Visual Overview: No longer possible to display aggregated parameter values in shapes \[ID_30864\]

In Visual Overview, it was no longer possible to display aggregated parameter values in shapes by specifying either the DMA and element ID of an aggregation element or an \[AggregationRule:...\] placeholder in a shape data field of type Aggregation.

#### Failover: Resources.xml would constantly be updated during a Failover switch \[ID_31006\]

During a Failover switch, in some cases, the Resources.xml file would constantly be updated.

#### Problem with SLAutomation when trying to run Automation scripts on elements for which no protocol information could be retrieved \[ID_31030\]

In some cases, an error could occur in SLAutomation when trying to run Automation scripts on elements for which no protocol information could be retrieved.

#### Problem during DataMiner startup when retrieving alarms for multiple elements from an Elas­ticsearch database \[ID_31039\]

In some cases, the DataMiner startup process could become unresponsive and the CPU usage could rise to 100% when alarms for multiple elements were being retrieved simultaneously from an Elasticsearch database.

#### SLAnalytics: Problem during initialization \[ID_31044\]

When the SLAnalytics process was starting up, in some cases, an error could occur when one of its dependencies was not available. From now on, if an error were to occur during the initialization of the SLAnalytics process, the process will shut down gracefully.

#### DataMiner Cube - Correlation: Problem when discarding or moving a duplicated correlation rule or correlation analyzer \[ID_31058\]

When you duplicated a correlation rule or a correlation analyzer and then immediately discarded the duplicate or moved it to another folder, in some cases, the original rule or analyzer would incorrectly be deleted or moved.

#### Failover: Resources.xml would incorrectly not be synchronized on offline agent \[ID_31117\]

When a new Failover configuration was created, in some cases, the Resources.xml file would incorrectly not be synchronized on the offline agent.

#### DataMiner Cube - Trending: Alarm colors on the Y axis of a trend graph would be shown incor­rectly when exceptions and numeric values were combined in the same severity \[ID_31124\]

In case of a numeric parameter with exceptions, an alarm template allows you to combine an exception value and a numeric threshold in one severity. Up to now, when an exception value and a numeric threshold were combined in one severity, in some cases, the alarm colors shown on the Y axis of a trend graph would not be correct.

#### SLProtocol would evaluate certain conditions incorrectly \[ID_31129\]

When a condition defined in a protocol contained an operator like +, -, \*, /, etc. at the right-hand side but no parentheses, the operation would be applied to the left-hand side, causing SLProtocol to evaluate the condition incorrectly.

In the following example, 20 would incorrectly be added to parameter 2002 instead of parameter 2001.

```xml
<Condition><![CDATA[id:2002 < id:2001 + 20]]></Condition>
```

#### Smart-serial & smart-IP protocols: Data could get lost when receiving large data packets \[ID_31132\]

Up to now, when a smart-serial or smart-IP protocol received large data packets, in some cases, it was possible for data to get lost.

#### Scheduler: Problem when a scheduled task was deleted from Windows Scheduler \[ID_31138\]

When a scheduled task had been deleted from Windows scheduler but was still present on the DataMiner Agent, in some cases, an error could be thrown. From now on, when that type of error is thrown after a manually executed task was deleted, the task in question will be recreated.

####  DataMiner Cube: View updates and element removals would incorrectly not trigger an update of the “Below this view” list in a view card \[ID_31141\]

In some cases, view updates and element removals would incorrectly not trigger an update of the “Below this view” list in a view card.

> [!NOTE]
> This change will also enhance overall performance when starting Cube on a system with SRM enabled and breadcrumbs disabled.

#### Problem with SLNet after replicating a DELT element \[ID_31154\]

When an element had been migrated within a DataMiner System and then configured to get replicated from its new host agent, in some cases, an incorrect subscription could be created when the replication connection was created and subsequently destroyed during DataMiner startup, prior to the agent being aware of the correct location of the DELT element. As a result, on both the former host agent and the current host agent, the CPU usage of the SLNet process would rise significantly.

#### Service & Resource Management: DateTime values were formatted incorrectly \[ID_31160\]

Due to a deserializing/serializing issue, in some cases, datetime values could be formatted incorrectly.

#### Web Services API v1: GetInformationEvents method would return an empty array \[ID_31162\]

Up to now, in some cases, the following methods would return an empty array, even when a valid timespan had been specified.

- GetInformationEvents

- GetInformationEventsV2

- GetInformationEventsSorted

- GetInformationEventsSortedV2

#### DataMiner Cube - Automation: DateTime control incorrectly updated with the DateTimeKind property \[ID_31190\]

When, in an interactive Automation script, you had configured the DateTimeKind property of a DateTime control, in some cases, the control would incorrectly be updated with the DateTimeKind property instead of the actual datetime value.

#### DataMiner Cube - Router Control: “park source” feature would incorrectly not work on matrices with IO table structures \[ID_31239\]

Up to now, the “park source” feature would incorrectly not work on matrices with IO table structures.

####  Memory leak in SLElement when stopping or deleting an element with a protocol of type “vir­tual” \[ID_31252\]

In some cases, SLElement could leak memory when stopping or deleting elements with a protocol of type “virtual”.

#### Automation: Problem when calling Engine.CreateExtraDummy or Engine.FindElement from mul­tiple threads or tasks within the same script \[ID_31253\]

In some cases, errors could occur in SLAutomation when Engine.CreateExtraDummy or Engine.FindElement were called from multiple threads or tasks within the same script.

#### DataMiner Cube - Visual Overview: Property values would not get updated correctly \[ID_31293\]

In Visual Overview, in some cases, property values would not get updated correctly.

####  Failover: Full synchronization incorrectly not run at setup \[ID_31296\]

When a Failover system was set up, in some cases, a full synchronization would incorrectly not be run.

####  DataMiner Cube - Spectrum analysis: “Auto RBW Factor” and “Auto VBW Factor” values stored incorrectly in spectrum preset \[ID_31299\]

In some cases, the “Auto RBW Factor” and “Auto VBW Factor” values would be stored in spectrum presets in an incorrect way. This would then lead to an incorrect auto RBW/VBW calculation.

#### DataMiner Cube - Visual Overview: Table connections would disappear at certain zoom levels \[ID_32336\]

When using dynamic positioning in combination with dynamic zooming, shape grouping and table connections, in some cases, the connection lines could disappear at certain zoom levels.

####  DataMiner Cube - Services app: Contents of “Configure groups” window would be arranged incorrectly \[ID_31344\]

When you right-clicked a Service Definition diagram and selected *Configure groups*, the contents of the *Configure groups* window would be arranged incorrectly. For example, the *Add group* button would be positioned at an incorrect location.

####  Jobs app: Date values saved in UTC format would be parsed incorrectly \[ID_31345\]

In the Jobs app, in some cases, date values saved in UTC format would be parsed incorrectly.

####  Web apps: Setvar controls in visual overviews would no longer be rendered correctly \[ID_31351\]

In web apps (e.g. Monitoring), in some cases, SetVar controls in visual overviews would no longer be rendered correctly.

####  STARTTLS/SSL options for SMTP would not get applied when sending generic emails \[ID_31592\]

When generic emails were sent via the SLASPConnection process, some of the SMTP options related to the connection type (STARTTLS/SSL) would not get applied, potentially causing failures when trying to send emails.

> [!NOTE]
> Since DataMiner version 10.1.10, sending emails via the SLAutomation process would also fail when using STARTTLS or non-default SSL port configurations.

## Addendum CU10

### Enhancements

####  Security enhancements \[ID_31784\]

A number of security enhancements have been made.

#### SLLogCollector will now also collect the NATS log and configuration files \[ID_31238\]

SLLogCollector will now also collect the log and configuration files from the NATS\\nats-account-server and NATS\\nats-streaming-server.

####  Security: New NATS installations will no longer open IP port 8222 \[ID_31422\]

During a NATS installation, from now on, only ports 4222 and 6222 will be opened. IP port 8222 will be left closed.

####  DataMiner Cube: Enhanced performance when logging in \[ID_31541\]

Due to a number of enhancements, overall performance has increased when logging in to Cube.

#### DataMiner Cube - EPM: Enhanced handling of hidden Data Display pages of EPM elements \[ID_31567\]

When the Alarm Console contained an alarm on a parameter of an EPM element with hidden Data Display pages\*, and the user had configured that the Data Display of the parameter had to be displayed when double-clicking the element, up to now, double-clicking the alarm would open a popup with the trend graph. From now on, the alarm card will be opened instead. If users want to access the trend information of the parameter in question, they can click the parameter name.

*\*If the “CPEOnly” option is specified in the protocol of an EPM element, the Data Display pages of that element are hidden for all users except administrators.*

#### Enhanced polling of SNMP tables using MultipleGetBulk and MultipleGetNext \[ID_31715\]

In DataMiner versions prior to 10.1.11, when MultipleGetBulk was used to poll a table that contained only a single row and the response from the device was cut because it exceeded the maximum package size, in some cases, the algorithm could get stuck into an infinite loop. That problem was fixed in DataMiner version 10.1.11, but now, the MultipleGetBulk/MultipleGetNext polling mechanism has received a more thorough overhaul.

#### SLA management: Enhanced automatic SLA data clean-up \[ID_31729\]

A number of enhancements have been made with regard to automatic SLA data clean-up.

### Fixes

#### DataMiner Connectivity Framework: Virtual functions would incorrectly inherit interfaces from the main element \[ID_30715\]

By default, the interfaces of a virtual function are the interfaces defined in the functions.xml file. Up to now, in some cases, virtual functions would also incorrectly inherited the interfaces of the main element.

#### SLLogCollector could fail to take process dumps \[ID_31213\]

In some rare cases, SLLogCollector could fail to take process dumps.

#### SLLogCollector would incorrectly stop collecting files when a file could not be copied \[ID_31220\]

When SLLogCollector would fail to collect a file from a remote server, in some cases, it would stop collecting log files. From now on, when it fails to collect a certain file, it will log the failure but continue to collect log files.

#### Service & Resource Management: No bookings could be retrieved when bookings were being created \[ID_31357\]

When bookings were being retrieved while bookings were being created, in some cases, no bookings would get retrieved.

From now on, the getResourcesMessage, the getResourcePoolsMessage and the getReservationsMessage will be allowed to skip the ResourceManager queue.

#### Protocols: Export rules would fail to parse values containing escaped XML characters \[ID_31362\]

When, in a protocol, values contained escaped XML characters (e.g. \<Description>Measurements \> 5\</Description>), the export rules would fail to parse those values and the generated DVE or Virtual Function protocol would only have some or none of the export rules applied.

#### Jobs app: Jobs would be retrieved using a query that contained an incorrect time filter \[ID_31365\]

When you opened the Jobs app, in some cases, the jobs would be retrieved using a query that contained an incorrect time filter.

#### ProfileManager module could get stuck during its initialization routine \[ID_31367\]

In some rare cases, the ProfileManager module could get stuck during its initialization routine.

#### Problem with SLElement when performing alarm level linking calculations \[ID_31404\]

In some cases, an error could occur in SLElement when performing alarm level linking calculations.

#### Alarm limit updates for column parameters would contain invalid data \[ID_31415\]

When alarm monitoring of type “rate” was used to monitor a column parameter, alarm limit change events would contain invalid data.

From now on, alarm limit change events will only be sent for standalone parameters and column parameters that are exported as standalone parameters in a virtual function or DVE child element.

#### DataMiner Cube - Correlation: Incorrect background color when creating or opening an ana­lyzer or a correlation rule \[ID_31482\]

When, in the Correlation app, you created or opened an analyzer in the Analyzers tab or you created or opened a legacy correlation rule in the Correlation rules tab, the tab would incorrectly have a gray background.

#### DataMiner Cube: Problem when opening a specific page of a card \[ID_31490\]

In some cases, it would no longer be possible to open a specific page of a card.

#### DataMiner Cube: Incorrect display value could be displayed when discreet values and display values overlapped \[ID_31497\]

When the discreet values and the display values of a certain parameter overlapped, in some cases, an incorrect display value could be displayed.

#### Web Services API v1: Problem when using GetTableForParameterFiltered or GetTableForParam­eterSorted to retrieve part of a parameter table \[ID_31504\]

When the GetTableForParameterFiltered orGetTableForParameterSorted method was used to retrieve part of a parameter table by specifying a non-zero start index and a specific number of rows, in some cases, not all requested rows would be returned.

#### DataMiner Cube: Problem when the version history of a protocol included a version that was incorrectly based on itself \[ID_31508\]

In some cases, DataMiner Cube would become unresponsive when you changed the protocol of an element to a protocol of which the version history included a version that was incorrectly based on itself. From now on, a warning will appear when you try to change the protocol of a element to a protocol with an incorrect version history.

#### Problem when interpreting cell content wrapped in quotes while importing CSV files \[ID_31511\] \[ID_31522\]

When a CSV file was imported, up to now, SLDataMiner would incorrectly interpret cell content wrapped in quotes. For example, if quoted cell content contained a separator character, it would incorrectly be interpreted as a separator.

From now on, cell content will be parsed as follows:

- When no quotes are present, the cell will not have its spaces trimmed. When quotes are present around the cell's data, spaces will be trimmed outside of the quotes.

- Quotes inside a cell are expected to be escaped by another quote.<br>Example: “A “”value”” inside a cell”.

- When there are quotes inside a cell, it is not allowed to have anything besides spaces outside of the quotes. The cell will be parsed as if no quotes are used and the first separator will close the cell. See the following example.

    | If you import... | cell 1 will contain... | cell 2 will contain... | cell 3 will contain... |
    |--------------------|------------------------|------------------------|------------------------|
    | “0,1m”, “0,5”m,    | 0,1m                   | “0                     | 5”m                    |

- Each imported object is expected to be a single element (besides the headers). Providing a string that contains a newline (\\n) for a property is possible, but carriage returns are removed (\\r) and tabs (\\t) are converted to spaces.

> [!NOTE]
> When you import a CSV file via DataMiner Cube, DataMiner Cube will send the imported data to the DataMiner Agent without performing any kind of preprocessing.

#### SLPort would leak a socket when executing an action of type “open” via a socket that had already been opened \[ID_31512\]

When an action of type “open” was executed on a smart-serial interface via a socket that had already been opened, SLPort would leak a socket as well as a port in the ephemeral port range. This would eventually lead to a situation in which no more ports were available and no more sockets could be created. From now on, SLPort will close the socket when it receives an action of type “open” on a socket that is already open.

#### Dashboards app - GQI: Problem when migrating “start from” queries \[ID_31544\]

When you opened a query that was created using an older GQI version, and that query was configured to start from another query, in some cases, it would incorrectly be migrated to the current GQI version.

Also, in some cases, a server query would not be translated correctly to a client query.

#### DataMiner Cube - Visual Overview: Child shapes of type alarm could lose data when scrolling through them \[ID_31547\]

When you scrolled through a large number of automatically generated shapes that represented alarms, in some cases, information displayed on those shapes would incorrectly disappear.

#### DataMiner Cube - Alarm Console: Problem when clearing an alarm while alarms were grouped by service \[ID_31549\]

When, in one of the tab pages in the Alarm Console, alarms were grouped by service, in some cases, an exception could be thrown when an alarm listed in more than one group was cleared.

#### DataMiner Cube - Data Display: Pressing a button inside a tree control would pass an incorrect row key \[ID_31554\]

When you pressed a button inside a tree control, in some cases, an incorrect row key would be passed to the command in question.

#### DataMiner Cube: Trend icons could stay hidden until Data Display was resized \[ID_31555\]

In Data Display, in some cases, trend icons next to parameters could incorrectly stay hidden until Data Display was resized.

#### DataMiner Cube: Parent view(s) of element, service or redundancy group created in one Cube session would be expanded in the Surveyor of another Cube session \[ID_31558\]

When, in a particular Cube session, a new element, service or redundancy group was created, in some cases, the Surveyor in other Cube session would incorrectly expand the parent view(s) of that new element, service or redundancy group.

#### Problem when run-time errors occurred in identically named process threads \[ID_31564\]

When, in a single process, multiple threads have a run-time error, those errors are grouped into one alarm tree. However, some threads have names that are not unique. When multiple identically named threads had a run-time error, all associated alarms would be generated simultaneously with the same value. This would cause SLElement to generate additional, incorrect alarms and SLWatchdog to not properly close those alarms.

#### Jobs app: Problem when changing the type of a field that was being used in a job filter \[ID_31565\]

When you changed the type of a custom section field that was being used a job filter, in some cases, that field would incorrectly still be used as a filter, even when it was not possible to use that type of field as a filter.

#### DataMiner Cube - Settings: Changes made in “Alarm Console \> Card-specific” section would incorrectly not get applied \[ID_31566\]

In the *Alarm Console \> Card-specific* section of the *Settings* app, you can configure which alarm tabs should be shown on element, service and view cards. Up to now, when you made changes to the settings on that page, those changes would incorrectly not get applied.

#### DataMiner Cube - Service templates: Generated services missing from the list \[ID_31576\]

In some cases, the *Service Templates* app would incorrectly not list generated services of which the ID was identical to that of generated services found on other DataMiner Agents.

#### Problem with SLDataMiner when deleting an alarm template or a trend template \[ID_31583\]

In some rare cases, an error could occur in SLDataMiner when an alarm template or a trend template was deleted.

#### bypassProxy option would incorrectly not be taken into account in case of a websocket connec­tion \[ID_31584\]

When the bypassproxy option had been set in a bus address field, this setting would incorrectly not be taken into account in case of a websocket connection.

From now on, when the bypassproxy option is specified for a websocket connection, the HTTP handshake to set up the websocket connection will not go through the configured proxy server.

#### Jobs app: Preset field values would not be filled in when a newly created job template was applied \[ID_31585\]

When you applied a newly created job template, in some cases, preset field values would incorrectly not be filled in.

#### DataMiner Cube: Problem when creating an element of type SNMPv3 when the UI language was not set to English \[ID_31588\]

When Cube’s UI language was set to a language other than English, an error could be thrown when you tried to create an element of type SNMPv3.

#### DataMiner Cube - Alarm cards: Services were not sorted naturally \[ID_31607\]

When you opened an alarm card, in some cases, the services affected by the alarm would incorrectly not be sorted naturally.

#### Jobs app: Job templates linked to a job domain were not deleted when the job domain was deleted \[ID_31616\]

In some cases, job templates linked to a job domain would incorrectly not be deleted when the job domain in question was deleted.

#### DataMiner Cube - Visual Overview: Embedded page would incorrectly not show DCF connec­tions \[ID_31627\]

When you opened a visual overview with only one visible page containing an embedded hidden page with DCF connections, in some cases, those DCF connections would incorrectly not be shown.

#### DataMiner Cube - Sidebar: Some applications and modules would not be translated correctly when the UI language was changed \[ID_31633\]

In the *Apps* pane of Cube’s sidebar, some applications and modules would not be translated correctly when you changed the UI language.

#### Memory leak in SLProtocol when a fill array or fill column method passed along empty or null values \[ID_31634\]

In some cases, SLProtocol could leak memory when a fill array or fill column method was called on the protocol object passing along empty or null values for a cell.

#### Problem when SLWatchDog was copying log files to the Minidump folder \[ID_31652\]

When an error of type “thread problem” occurs, the contents of the C:\\Skyline DataMiner\\Logging folder is compressed into a zip file, which is then placed in the C:\\Skyline DataMiner\\Logging\\Minidump folder. During this action, in some cases, a lock inside the SLWatchdog process would accidentally delay the start-up of elements.

#### DataMiner Cube: Problem when refreshing a log file after scrolling down \[ID_31662\]

When, in the *Logging* section of *System Center*, you opened a log file, scrolled down beyond the first 50 KB of data, and then refreshed the file, the vertical scroll position would incorrectly not be restored.

#### DataMiner Cube - Settings: Turning an alarm tab of type “sliding window” into a normal alarm tab would cause this change to be reverted as soon as another change was made to it \[ID_31664\]

When, in the group settings, you added an alarm tab of type “sliding window” and enforced it, as soon as a user had turned this tab into a normal alarm tab, the slightest change made to the tab afterwards would cause the tab to be changed back into a tab of type “sliding window”.

#### DataMiner Cube - Alarm Console: Problem when alarm tabs were grouped by property \[ID_31673\]

When an alarm tab was grouped by property, in some cases, DataMiner Cube could become unresponsive, especially on systems with high alarm traffic.

#### DataMiner Cube - Scheduler: Creating a task could fail on client machines with culture set to “Finnish” \[ID_31712\]

In DataMiner Cube, creating a task in the Scheduler app could fail when the culture of the client machine was set to “Finnish”.

#### DataMiner Cube: Element, service and view cards on a saved workspace would not show the correct page when the workspace was opened \[ID_31718\]

When you opened a saved workspace, in some cases, open element, service or view cards would not show the correct page.

#### DataMiner Cube - EPM: Zoom buttons on trend graph popup would incorrectly be displayed twice \[ID_31719\]

When you opened an EPM trend graph popup from a KPI on an EPM card, in some cases, the zoom buttons would incorrectly be displayed twice.

#### Dashboards app: Problem when listing the parameters of a selected element \[ID_31737\]

When, in a dashboard, you selected an element, in some cases, an “Index was outside the bounds of the array” error could be thrown when a linked parameter component tried to list all parameters of the element you selected.

#### DataMiner Cube - Trending: Problem when opening a histogram \[ID_31745\]

In some cases, an exception could be thrown when you opened a histogram.

#### SLAnalytics - Automatic incident tracking: Problem when trying to parse invalid element IDs \[ID_31820\]

When a view contained invalid element IDs, up to now, an exception would be thrown. From now on, when SLAnalytics was not able to parse an element ID, an error will be added to the SLAnalytics log file.

## Addendum CU11

### Enhancements

#### SLElement: Enhanced service impact calculation \[ID_31163\]

A number of enhancements have been made to the service impact calculation in SLElement.

#### Enhanced performance when initializing elements that are included in multiple services \[ID_31611\]

Due to a number of enhancements, overall performance has increased when initializing elements that are included in multiple services.

#### DataMiner Cube: Miscellaneous enhancements \[ID_31641\]

A number of small enhancements have been made to DataMiner Cube and the DataMiner Cube start window.

#### SLLogCollector: Resources to be collected can now be specified in configuration files \[ID_31674\]

SLLogCollector will now check the C:\\Skyline DataMiner\\Tools\\SLLogCollector\\LogConfigs folder for configuration files in which you can specify the resources (i.e. objects) to be collected.

By default, the above-mentioned folder will contain a Default.xml file, listing a default list of resources to be collected. If necessary, additional XML files can be created and stored in this folder.

Example of a configuration file:

```xml
<ResourceCollectorConfig>
  <Collectors>
    <File name="Collector1">
      ...
    </File>
    <Http name="Collector2">
      ...
    </Http>
    <Exe name="Collector3">
      ...
    </Exe>
  </Collectors>
</ResourceCollectorConfig>
```

In the example above, three collectors have been defined:

- Collector1 is a collector of type “File”, and will order SLLogCollector to retrieve a set of files (e.g. log files).

- Collector2 is a collector of type “Http”, and will order SLLogCollector to send an HTTP request to a server and to store the response.

- Collector3 is a collector of type “Exe”, and will order SLLogCollector to run an executable file and to store the output.

**Collectors of type “File”**

Collectors of type “File” can be configured using the following XML elements and attributes:

| Element/attribute                    | Type   | Mandatory | Description                                                                                                                                        |
|--------------------------------------|--------|-----------|----------------------------------------------------------------------------------------------------------------------------------------------------|
| File@name                            | String | Yes       | The name for the collector.                                                                                                                        |
| File.Source                          |        | Yes       | The folder in which SLLogCollector will search for files and folders.                                                                              |
| File.Destination                     |        | Yes       | The (relative) path to the destination folder in the archive.                                                                                      |
| File.Patterns                        |        | Yes       | The element containing all search patterns.                                                                                                        |
| File.Patterns.Pattern                |        | Yes       | A Microsoft .Net search pattern to filter file names or file paths.                                                                                |
| File.Patterns.Pattern<br> @amount    | Int    | No        | The X most recent items to be copied.                                                                                                              |
| File.Patterns.Pattern<br> @recursive | Bool   | No        | Whether to search recursively or not. Default: false                                                                                               |
| File.Patterns.Pattern<br> @isFolder  | Bool   | No        | If true, then SLLogCollector will search for folders matching the pattern and will copy the entire content of the matching folders. Default: false |

**Collectors of type “Http”**

Collectors of type “Http” can be configured using the following XML elements and attributes:

| Element/attribute                                           | Type   | Mandatory | Description                                                                                                                |
|-------------------------------------------------------------|--------|-----------|----------------------------------------------------------------------------------------------------------------------------|
| Http@name                                                   | String | Yes       | The name for the collector.                                                                                                |
| Http.Source                                                 |        | Yes       | The IP address and port to which the requests have to be sent.<br> Format: http://ip:port                                  |
| Http.Destination                                            |        | Yes       | The (relative) path to the destination folder in the archive.                                                              |
| Http.Endpoints                                              |        | Yes       | The element containing all endpoints.                                                                                      |
| Http.Endpoints.Endpoint                                     |        | Yes       | The element grouping all information on a particular endpoint.                                                             |
| Http.Endpoints.Endpoint<br> @name                           | String | Yes       | The name of the endpoint.                                                                                                  |
| Http.Endpoints.Endpoint<br> .Requests                       |        | Yes       | The element containing all requests to be sent to the endpoint.                                                            |
| Http.Endpoints.Endpoint<br> .Requests.Request               |        | Yes       | The request to be sent.                                                                                                    |
| Http.Endpoints.Endpoint<br> .Requests.Request<br> .fileName | String | No        | The name of the file in which the response has to be saved.<br> Default: \<Endpoint.name> \<Endpoint.Requests.Request>.txt |

**Collectors of type “Exe”**

Collectors of type “Exe” can be configured using the following XML elements and attributes:

| Element/attribute                  | Type   | Mandatory | Description                                                                                         |
|------------------------------------|--------|-----------|-----------------------------------------------------------------------------------------------------|
| Exe@name                           | String | Yes       | The name for the collector.                                                                         |
| Exe.Source                         |        | Yes       | The folder in which the executable is located.                                                      |
| Exe.Executable                     |        | Yes       | The name of the executable.                                                                         |
| Exe.Destination                    |        | Yes       | The (relative) path to the destination folder in the archive.                                       |
| Exe.Commands                       |        | Yes       | The element containing all commands to be run.                                                      |
| Exe.Commands<br> .Command          |        | Yes       | The command to be run.                                                                              |
| Exe.Commands<br> .Command@fileName | String | No        | The name of the file in which the result has to be saved.<br> Default: \<executable> \<command>.txt |

#### DataMiner Cube: Minor enhancements with regard to views, elements and services \[ID_31742\]

A number of minor enhancements have been made with regard to views and elements:

- The *System Info* name (*System Center \> Agents*), which is used as root view name, can no longer be the name of an existing view.

- Users will now receive a clearer error message when they try to create an element or a service with a name that starts or ends with a space.

- When, in a view card, you right-click the header of the “Below this view” list, the context menu that appears is empty when the system has no properties defined. Now, when the context menu is empty, a message will be displayed, explaining users why it is empty.

- Up to now, when multiple items were selected in the “Below this view” list of a view card, selecting one item would not clear the selection. From now on, it will do so.

- When, in the “Below this view” list of a view card, you sort the list by alarm state, the list will be sorted by severity (default: descending).

- When, in a view card, you right-click the header of the “Below this view” list, the overall responsiveness of the context menu has been enhanced.

#### Chromium web browser control: Enhancements with regard to the translations of the find and zoom commands \[ID_31755\]

A number of enhancements have been made with regard to the translations of the find and zoom commands of the Chromium web browser control.

#### Enhanced performance when editing an element \[ID_31846\]

Due to a number of enhancements, overall performance has increased when editing an element.

Also, up to now, when an element was edited, all tab characters (“\\t”) in field content would be replaced by spaces. From now on, tab characters will be left untouched.

#### Unclear “version of the protocol is not correct” notice replaced by “DataMiner version is too low to use this protocol. Please check the protocol's Compliancies tag.” notice \[ID_31855\]

When a protocol had a minimum DataMiner version that was higher than the DataMiner version of the DMA, up to now, an unclear “version of the protocol is not correct” notice would appear in the Alarm Console and the log files. From now on, that unclear notice will be replaced by a clearer “DataMiner version is too low to use this protocol. Please check the protocol's Compliancies tag.” notice.

#### SLLogCollector: Process list will now also include processes of which the name starts with “DataMiner” \[ID_31883\]

The SLLogCollector tool will now also list all processes of which the name starts with “DataMiner”. This will allow you to also take memory dumps of processes like “DataMiner CloudGateway”, “DataMiner CoreGateway”, “DataMiner FieldControl”, “DataMinerCube”, etc.

Also, an issue was fixed where duplicate entries would appear in the list after a DMA restart while the tool was open.

#### Elasticsearch: Backup timeout increased to 15 minutes \[ID_31595\]

The timeout of Elasticsearch backups has been increased from 1 minute to 15 minutes.

This applies to backups taken via DataMiner as well as backup taken via the Standalone Elastic Backup tool.

#### Service & Resource Management: Ending an ongoing booking by changing the end time will now cause all missed events to be run \[ID_31907\]

When the end time of an ongoing ReservationInstance is set to a time stamp in the past, from now on, all events that have not been run when the booking ended will be run.

#### DataMiner Cube - System Center: New LDAP settings \[ID_31924\]

In *System Center*, the *LDAP* tab of the *System settings* section allows you to configure a number of LDAP settings. A number of changes have now been made to the *General* tab.

- The *Use custom configuration* option has been replaced by the *Referral configured* option.

- A new *SSL/TLS* option has been added. Enable this option if you want DataMiner to use SSL/TLS when connecting to the LDAP server.

#### SLDataMiner: Enhanced locking when editing elements \[ID_31948\]

A number of enhancements have been made to SLDataMiner with regard to element locking, especially when editing elements.

#### Enhanced socket cleanup after closing a serial connection \[ID_31955\]

A number of enhancements have been made with regard to socket cleanup after closing a serial connection, especially in situations where the “closeConnectionOnResponse” option is enabled or when a close action is performed.

#### DataMiner Taskbar Utility: Improved entering of credentials before testing the SLNet connec­tion \[ID_32079\]

When you right-click the Taskbar Utility icon and select *Options*, in the *SLNet* tab, you can enter your credentials and click *Test & Save Connection* to test the connection to SLNet.

Up to now, in some cases, you could experience some lag while entering your credentials. From now on, entering your credentials will go much smoother.

#### Updated BPA tests \[ID_32102\]

The following BPA tests have been updated:

- Cassandra DB Size

- Check Antivirus DLLs

#### DataMiner Cube - Visual Overview: Spectrum Analysis component now allows combining an inline preset with one or more measurement points \[ID_32101\]

When configuring a Spectrum Analysis component, it is now possible to combine an inline preset with one or more measurement points.

#### Replication: Name of the local element will now be logged in SLReplication.txt when a replica­tion connection is set up \[ID_32109\]

When a replication connection is set up to another DataMiner Agent, from now on, the name of the local element for which that connection is set up will be logged in the SLReplication.txt file.

#### SLLogCollector will now also by default collect the most recent backup\_\*.log.txt file and all Database\\\*.xml files \[ID_32114\]

From now on, SLLogCollector will also by default collect the following files:

- The most recent backup\_\*.log.txt file in C:\\Skyline Dataminer\\Backup

- All \*.xml configuration files in C:\\Skyline Dataminer\\Database

### Fixes

#### Cassandra: Problem when creating user-defined types \[ID_31001\]

On systems with a Cassandra database, in some rare cases, creating user-defined types could fail and return an exception.

When creating the user-defined types failed during a migration from MySQL to Cassandra, the following exception could be thrown:

```txt
The migration has failed.DBGatewayException(SLCassandraClassLibrary.DBGateway.Cassandra.StorageManagers.SingleNode.CassandraConnection,,UNKNOW SLDataGateway.Types.DBGatewayException: CassandraConnection CreateCustomType - no host available All hosts tried for query failed.
```

#### Problem with SLProtocol when trying to parse data received from SLPort \[ID_31676\]

In some cases, an error could occur in SLProtocol when trying to parse data received from SLPort.

#### Problem with SLDataMiner when a trigger to reload service settings was delayed & memory leak in SLElement \[ID_31711\]

When a trigger to reload service settings was delayed, in some cases, a run-time error could occur in the service thread of SLDataMiner.

Also, SLElement could leak memory when services were configured with a delayed trigger or a redundancy condition that persisted for a period of time.

#### Deadlock in SLDataGateway could cause data to not get written to the database \[ID_30717\]

In some cases, a deadlock in the SLDataGateway process could cause e.g. Correlation rule data to not get written to the database and remain in memory indefinitely.

#### Problem with SLElement after restarting an element with a subscription that had a “resolve” or “filter” option configured \[ID_31741\]

When there was an active element subscription with a “resolve=x” or “sort=x” filter option configured, in some cases, an error could occur in SLElement when processing table changes after an element restart.

#### SLPort could incorrectly accept a payload containing only a trailer and forward it to SLProtocol \[ID_31743\]

In case of a serial protocol, when both a header and trailer were configured for a response, in some cases, SLPort could incorrectly accept a payload containing only a trailer and forward it to SLProtocol before the timeout of the command was reached.

From now on, if a payload contains only a trailer, the socket buffer will be read until the configured timeout is reached and then the payload will be forwarded to SLProtocol.

#### SLA: Problem when an update of an SLA setting coincided with a window change \[ID_31750\]

When an update of an SLA setting (e.g. Base timestamp, Monitor span, Window size, Window Unit, Window type, Validity start or Validity end) coincided with a window change, in some rare cases, the next window would incorrectly be taken instead of the window that triggered the change. This would cause calculations to incorrectly use a timestamp in the future.

#### Failover: Redundancy groups containing DVE elements would not get loaded after a Failover switch or a restart of the Failover system \[ID_31765\]

After a Failover switch or a restart of a Failover system, in some cases, redundancy groups containing DVE elements would incorrectly not get loaded.

#### “Duplicate name detected” notice would incorrectly be generated when turning a service into an enhanced service or vice versa \[ID_31801\]

When a service was turned into an enhanced service, or when an enhanced service was turned into a regular service, a “Duplicate name detected” notice would incorrectly be generated.

#### DataMiner Cube: Miscellaneous small fixes \[ID_31802\]

In DataMiner Cube, a number of small fixes have been made:

- In a tree control, the tab borders would not be visible in the Skyline Black theme.

- Undocking the Alarm Console could affect the layout of the main Cube window.

- When you pressed ENTER in an editable table cell, a trend graph would incorrectly open instead of the table cell editor.

- When an element was restarted, in some cases, a table would incorrectly stay grayed out.

- A parameter containing a disabled exception value would stay disabled after it had received a normal value.

#### SLElement: Problem with invalid parameter IDs in the Generic DVE Linker Table \[ID_31805\]

When creating resources, the \[Generic DVE Linker Table\] is used to link a row from the \[Generic DVE Table\] to any other table. Up to now, in some cases, invalid parameter IDs in the \[FK Table\] column would result in invalid relations being constructed in SLElement’s memory.

From now on, the values from the \[FK Table\] will be checked against the protocol's parameters and a functioning link will only be made when a table with such a parameter ID exists in the element.

#### DataMiner Cube - Settings: Filtered alarm tabs configured to show active alarms and masked alarms would incorrectly only show active alarms \[ID_31815\]

When, in the Settings app, you had configured a filtered alarm tab to contain both active alarms and masked alarms, that alarm tab would incorrectly only show active alarms.

#### Problem when SLAnalytics was stopped while it was writing to the database \[ID_31824\]

When SLAnalytics was stopped while it was writing to the database, in some rare cases, caching issues could occur.

#### Ticketing app: Problem with Ticket exposer \[ID_31826\]

When the Ticket exposer was used with a filter like the one below, in some cases, incorrect results would be returned:

```txt
var query = TicketingExposers.Ticket.Contains(@"7999").ToQuery();
```

#### DataMiner Cube - Visual Overview: Connection between two shapes would incorrectly not be hidden when one of the shapes was hidden \[ID_31839\]

When a shape with a connection to another shape was hidden, in some cases, the connection between the two shapes would incorrectly not be hidden.

#### SLProtocol could leak memory when an enhanced service was tracking alarms that contained duplicate property names \[ID_31851\]

When an enhanced service was tracking alarms, SLProtocol could leak memory when an alarm contained duplicate property names.

Also, the same process could leak memory when a table parameter was cleaned up after an element restart.

#### SLPhotoManager would incorrectly log “PrincipalServerDown” exceptions in SLErrors.txt when trying to retrieve pictures of local users \[ID_31865\]

Up to now, when SLPhotoManager was unable to retrieve pictures of local (i.e. non-LDAP) users, it would incorrectly log “PrincipalServerDown” exceptions in the SLErrors.txt log file. From now on, it will log those exceptions in the SLPhotoManager.txt log file when the debug level is set to 5.

#### Web apps - Visual Overview: Native controls inside clickable child shapes would incorrectly not be displayed \[ID_31871\]

When, in a web app, a visual overview had interactive parent shapes with clickable child shapes that contained a native control (e.g. view shapes containing an embedded browser control), that control would incorrectly not be displayed.

#### Scheduled tasks configured to take a DataMiner backup, optimize the database or perform an LDAP resynchronization would incorrectly not get executed \[ID_31877\]

In some cases, scheduled tasks configured to take a DataMiner backup, optimize the database or perform an LDAP resynchronization would incorrectly not get executed.

#### Visual Overview: Hidden pages of an embedded Visio file would incorrectly be displayed when viewed in a web app \[ID_31881\]

When an embedded multi-page Visio file with hidden pages was viewed in a web app, the hidden pages would incorrectly be displayed.

#### Elements of which the second port was incorrectly configured would no longer start up \[ID_31882\]

Elements of which the second port was incorrectly configured would no longer start up. In some cases, a port could get configured incorrectly after the production version of a protocol had been changed to a version with an additional port.

Editing the element, setting any missing port values and saving the element configuration will fix this kind of problem. Therefore, whenever the system detects an element with an incorrect port configuration, from now on, a notice alarm with the following text will be generated for that element:

```txt
Initializing the communication of port (x) failed. Please verify the connection settings in the Edit window of the element.
```

> [!NOTE]
> Even if the second port of an element is a hidden port that does not require any configuration, the system will generate a notice alarm like the one above when it detects any anomalies in the port settings.

#### DataMiner Cube - Visual Overview: DCF signal paths would not be visualized correctly on pages with a grid layout \[ID_31888\]

In some cases, a DCF signal path would not be visualized correctly on Visio pages with a grid layout.

#### SLNet would thrown an “Arithmetic operation resulted in an overflow” exception when perfor­mance information was being calculated \[ID_31894\]

In some cases, SLNet would thrown an “Arithmetic operation resulted in an overflow” exception when performance information was being calculated.

#### Exported protocols would incorrectly have the same Protocol.Description and Protocol.Type as their parent protocol \[ID_31904\]

Up to now, the Protocol.Description and Protocol.Type values in an exported protocol would incorrectly be identical to those of the parent protocol. From now on, the Protocol.Description and Protocol.Type elements of an exported protocol will contain the export name and the virtual type instead.

#### Errors occurring while deleting Cassandra compaction and repair tasks could affect the DataMiner startup routine \[ID_31921\]

When a DataMiner Agent with a Cassandra cluster configuration starts up, any scheduled task to compact or repair the Cassandra database is deleted. Up to now, when an error occurred while deleting such a task, in some cases, the DataMiner Agent would not start up correctly.

From now on, any error that occurs while deleting Cassandra compaction and repair tasks will no longer affect the DataMiner startup routine.

#### Dashboard Gateway was not able to access the dashboard configuration files of user accounts other than the one used to set up the Dashboard Gateway connection \[ID_31926\]

Since DataMiner version 10.0.10, a Dashboard Gateway would no longer be able to access the dashboard configuration files of user accounts other than the one used to set up the Dashboard Gateway connection.

From now on, a Dashboard Gateway will be able to access the dashboard configuration files of all users when the user account that is used to set up the Dashboard Gateway connection has been granted the *Modules \> System configuration \> Tools \> Admin tools* permission.

#### DataMiner Cube - Visual Overview: DCF connections incorrectly not shown when opening a sec­ond visual overview for the same element \[ID_31931\]

When you had opened a visual overview with DCF information for a particular element, and you opened another visual overview with DCF information for that same element, in some rare cases, the latter would incorrectly not show any DCF connections.

#### Problem when reading out a parameter or element latch \[ID_31932\]

When DataMiner was started or when an element was started, in some cases, the following event could appear in the Windows event viewer:

```txt
Could not read element latch for DMAID/EID. 0x80131533
```

#### Dashboards app: “Top X alarms” chart would incorrectly not include a graph in a PDF report \[ID_31949\]

When a PDF report was generated of a dashboard containing a “top X alarms” chart based on alarm state duration, in some cases, that chart would incorrectly not include a graph when set to stacked mode.

#### “Service Manager not licensed” error when synchronizing files on DataMiner Agents that do not have a Service Manager license \[ID_31958\]

In some cases, when a DataMiner Agent did not have a Service Manager license, a “Service Manager not licensed” error would be thrown when synchronizing files. From now on, when a DataMiner Agent does not have a Service Manager license, no attempt will be made to synchronize system function definitions when synchronizing files.

#### Failover: Standalone BPA Executor could incorrectly not be launched from an offline agent \[ID_31959\]

When, in a Failover setup, the Standalone BPA Executor was launched from the offline agent, up to now, it would throw an exception, stating that the agent was offline. Because this tool must be able to run certain tests on offline agents, it has now been made possible for the Standalone BPA Executor to be launched from an offline agent.

#### GetAnalogTrendDataMessage would incorrectly return 5-minute data point when more than 48 hours of trend data was requested \[ID_31970\]

When a GetAnalogTrendDataMessage was used to retrieve more than 48 hours of trend data for a particular element, in some cases, the result set would incorrectly contain 5-minute data points instead of 60-minute data points.

#### DataMiner Cube - Visual Overview: Trend graph would incorrectly not be loaded when clicking a trend icon \[ID_31978\]

When, in a visual overview that showed a table with trended columns, you opened a trend graph by clicking a trend icon, in some cases, the trend graph would incorrectly not be loaded and a “Trending is currently not enabled for this parameter” message would appear.

####  Cassandra: Incorrect “null statement” messages would be added to SLDBConnection.txt \[ID_31979\]

In some cases, the following message would repeatedly be added to the SLDBConnection.txt log file:

```txt
Cassandra: tried to execute null statement.
```

#### Failover: Initial file synchronization would incorrectly not be performed \[ID_31991\]

When a standalone DataMiner Agent had been added to a Failover setup, in some cases, the initial file synchronization from online agent to offline agent would incorrectly not be performed.

#### Problem when creating separate SLScripting processes for every protocol being used \[ID_32015\]

In the DataMiner.xml file, you can configure to have separate SLScripting processes created for every protocol being used. When this option was enabled, up to now, when SLScripting processes would crash, in some cases, they would either not get recreated or too many SLScripting processes would get created.

#### Failover: Certain system files would incorrectly not get synchronized to the offline agent during the initial sync \[ID_32034\]

When a Failover system was set up, certain system files (e.g. PropertyConfiguration.xml) would incorrectly not get synchronized to the offline agent during the initial sync.

#### DataMiner Cube: Information templates could no longer be edited when connected to a Data­Miner Agent installed on Windows Server 2016 \[ID_32035\]

In DataMiner Cube, in some cases, it would no longer be possible to edit information templates; especially when connected to a DataMiner Agent installed on Windows Server 2016.

#### DataMiner Cube - Alarm Console: Alarms coming in while grouping or sorting an alarm tab would incorrectly not appear in that alarm tab \[ID_32051\]

In some rare cases, alarms coming in while you were grouping or sorting the alarms on an alarm tab would incorrectly not appear on that alarm tab, especially on heavy-duty systems.

####  Legacy Dashboards: Using “Add to dashboard” in Cube would no longer work when the Data­Miner Agent was only accessible via HTTPS \[ID_32083\]

From DataMiner 9.0 onwards, it is possible to add items to a legacy dashboard directly from the Cube UI, for instance from the Surveyor or an element card.

This functionality would no longer work when the DataMiner Agent was only accessible via HTTPS.

#### DataMiner upgrade: SLNet could load an incorrect version of the SLUpgrade.dll file \[ID_32094\]

To be able to check the prerequisites during a DataMiner upgrade, SLNet needs to load the SLUpgrade.dll file. In some cases, it would load the 32-bit version instead of the 64-bit version or vice versa.

#### SLReset would incorrectly delete the Webpages\\root and Webpages\\monitoring folders \[ID_32139\]

Up to now, SLReset would incorrectly delete the following folders:

- C:\\Skyline DataMiner\\Webpages\\root

- C:\\Skyline DataMiner\\Webpages\\monitoring

From now on, SLReset will no longer delete these folders.

####  Newly created elements would incorrectly be assigned an ID equal to -1 \[ID_32178\]

In some cases, newly created elements would incorrectly be assigned an ID equal to -1.

## Addendum CU12

### Enhancements

#### Security enhancements \[ID_32125\]

A number of security enhancements have been made.

#### SLElement: Enhanced performance when working with tables using the “naming” or “naming­format” option \[ID_30973\]

Due to a number of enhancements, overall performance of SLElement has increased, especially when working with tables using the “naming” or “namingformat” option.

#### OpenSSL libraries updated to version 1.1.1l \[ID_31977\]

The OpenSSL libraries in DataMiner have been updated to the latest version (v1.1.1l).

#### SLElement: Enhanced performance when processing partially included services \[ID_32080\]

Due to a number of enhancements, overall performance of SLElement has increased when processing partially included services.

#### SLElement: Enhanced performance when processing alarms \[ID_32111\]

Due to a number of enhancements, overall performance of SLElement has increased when processing alarms.

#### SLElement: Enhanced performance when working with DCF interfaces \[ID_32126\] \[ID_32127\]

Due to a number of enhancements, overall performance of SLElement has increased when working with DCF interfaces.

#### Enhanced performance when connecting to a system with a large number of LDAP users \[ID_32146\]

Due to a number of enhancements, overall performance has increased when connecting to a system with a large number of LDAP users.

#### Logging at element startup has been optimized \[ID_32172\]

Logging at element startup has been optimized.

#### Enhanced smart-serial client throughput \[ID_32219\]

Due to a number of enhancements, the overall throughput of smart-serial clients has increased.

#### SNMPAgent: Enhanced error handling \[ID_32276\]

A number of enhancements have been made to the SLSNMPAgent process, especially with regard to error handling.

#### DataMiner Cube - System Center: Enhanced performance when opening the Users/Groups sec­tion \[ID_32307\]

Due to a number of enhancements, overall performance has increased when opening the Users/Groups section of System Center.

#### Web Services API: Web socket interface will now handle incoming messages asynchronously \[ID_32390\]

Up to now, when clients sent messages to the web socket interface of the Web Services API, those message were handled synchronously. From now on, the web socket interface will handle all incoming messages asynchronously.

#### DataMiner Cube: Skyline Black theme now features improved support for function icons \[ID_32430\]

The Skyline Black theme now features improved support for function icons.

### Fixes

#### Cassandra: Incorrect health status \[ID_29502\]

In some cases, the Cassandra health status was incorrect.

#### DataMiner Cube: When opening an email report, certain parameters would not be loaded cor­rectly \[ID_31969\]

When you created an email report in Scheduler, Automation or Correlation, and then added a number of parameters to it, in some rare cases, some of those parameters would not be loaded correctly when you reopened Scheduler, Automation or Correlation.

#### DataMiner Cube: Trend graph of a parameter updated via history sets would be drawn incor­rectly \[ID_31994\] \[ID_32001\]

Up to now, the trend graph of a parameter updated via history sets would be drawn incorrectly. From now on, for history set parameters, the line indicating parameter updates will no longer be drawn up to the current time. Instead, it will be drawn up to the time of the last parameter update.

#### SoftLaunchOptions.xml would be parsed incorrectly \[ID_32019\]

In some cases, the contents of the SoftlaunchOptions.xml file would be parsed incorrectly.

#### Failover: MigrationManager and ProfileManager exceptions could be thrown when setting up a Failover system without an ElasticSearch database \[ID_32163\]

When a Failover system was set up without an ElasticSearch database, in some cases, BaseProfileManager and MigrationManager exceptions could appear in the Alarm Console.

#### Service & Resource Management: A GetResources call with a filter applied could return different results depending on the software license \[ID_32168\]

A GetResources call with a filter applied could return different results depending on the software licenses found on the system (Resource Manager license but no IDP License, or vice versa).

#### Problem when stopping or removing elements belonging to an enhanced service \[ID_32175\]

In some cases, an error could occur in SLProtocol when stopping or removing elements belonging to an enhanced service.

#### Parent EPM item unmasked while still containing masked sub-items \[ID_32179\]

When a specific EPM item was masked for a period of time and then got unmasked, it could occur that its parent EPM item was also unmasked even though it still contained other masked EPM sub-items.

Now an EPM item can only be unmasked if all underlying items are unmasked. When an EPM sub-item cannot be unmasked for some reason, this will be logged in the SLNet logging. In addition, when you mask an EPM item and some of its sub-items cannot be masked, only the sub-items that were masked will be considered to be masked together with the EPM item, and the failures will be logged in the SLNet logging.

#### Problem with SLAnalytics due to a stack overflow exception \[ID_32190\]

In some cases, an error could occur in the SLAnalytics process due to a stack overflow exception.

#### DataMiner Cube - Alarm Console: “Audible alert” option was not saved correctly when an alarm tab was added to a workspace \[ID_32191\]

When you undocked an alarm tab in which the “audible alert” option was selected, and then saved the workspace, the “audible alert” option would not be saved correctly.

#### DataMiner Cube: Certain shortcut menu items would not be displayed when the UI language was set to a language other than English \[ID_32196\]

In some cases, certain shortcut menu items would not be displayed when the UI language was set to a language other than English.

#### SLLogCollector would not start up when SLWatchDog2.txt or SLElementsInProtocol.txt were missing \[ID_32205\]

At startup, the SLLogCollector tool checks for issues by reading the SLWatchDog2.txt and SLElementInProtocol.txt log files. Up to now, it would not start up when it was unable to find those files. From now on, when SLLogCollector does not find the above-mentioned log files, it will notify the user but start up correctly.

#### DataMiner Cube - Alarm Console: Making an alarm tab show history alarms instead of active alarms would cause the name of the alarm tab to be updated incorrectly \[ID_32215\]

When you created an “active alarms” tab for a certain object (element, service or view) by dropping that object onto the Alarm Console, and then made the tab show history alarms instead of active alarms, the automatically generated tab name was incorrectly set to “Alarms of the last 0 hours” instead of “\~Last hour (up till X)”.

#### DataMiner Cube - Alarm Console: Not possible to change the “automatic incident tracking” option in an alarm tab that was enforced by group settings \[ID_32218\]

In an alarm tab that was enforced by group settings, up to now, it would not be possible to change the “automatic incident tracking” option.

#### Problem with SLPort when stopping an element with a serial or smart-serial connection \[ID_32221\]

In some cases, an error could occur in SLPort when an element with a serial or smart-serial connection was stopped.

#### DataMiner Cube: Aggregation rule values were displayed with too many decimals \[ID_32235\]

In some cases, aggregation rule values were displayed with too many decimals.

#### Problem with SLXml at DataMiner startup \[ID_32255\]

At DataMiner startup, in some rare cases, an error could occur in the SLXml process.

#### DataMiner Cube - Alarm Console: Alarm status no longer updated when alarms were grouped by service \[ID_32294\]

When, in an alarm tab, the alarms were grouped by service, in some cases, the status of alarms that affected at least two services for which no alarms existed at the moment the alarms were grouped would no longer be updated.

#### Service & Resource Management: SRM operations could fail due to connection issues between agents \[ID_32296\]

In some cases, SRM operations like creating or updating bookings and creating or updating resources could fail due to connection issues between the different agents.

#### Incorrect service impact alarms after disabling and enabling a virtual function \[ID_32359\]

When a virtual function was disabled and then enabled again, in some cases, the alarms that affected the function would incorrectly affect a deleted service.

#### DataMiner Cube - Visual overview: Problems with path highlighting \[ID_32364\]

The following issues with regard to connection highlighting have been fixed:

- In some cases, paths of connectors without a matching DCF connection would no longer be highlighted. Only shapes and lines that were linked directly would be highlighted.

- Clicking a non-linked shape that was part of a path would no longer cause that path to be highlighted.

    > [!NOTE]
    > If a non-linked shape in a path has shape text and you want it to be highlighted when clicked, then make sure to add a shape data field of type Enabled to it to and set that field to “False”. This will disable the “copy text” command in the shape’s shortcut menu command and make sure the shape can be highlighted.

#### Problem when retrieving trend data in the Monitoring app \[ID_32366\]

In some cases, it was no longer possible to retrieve trend data in the Monitoring app due to a parsing problem in GetParameterResponseMessage and GetAlarmStateResponseMessage.

#### DataMiner Cube - Visual Overview: DCF connectivity not loaded when opening a Visio page embedded in another Visio page \[ID_32377\]

Up to now, when a Visio page was opened, the DCF connectivity would incorrectly not be loaded when that Visio page was embedded in another Visio page.

#### DataMiner Cube - Alarm Console: Newly created private alarm filter would not be automatically selected in the filter selection box \[ID_32401\]

When, in the Alarm Console, you created a new private alarm filter, in some cases, that new filter would not automatically be selected after saving it. The filter selection box would incorrectly show “\<Click to select>” instead of the name of the newly created filter.

#### Spectrum Analysis: Presets not saved/loaded correctly in spectrum card launched from spec­trum thumbnail \[ID_32404\]

When a spectrum element card is launched from a spectrum thumbnail in Visual Overview, it is displayed in buffer mode. Up to now, in this buffer mode, markers, reference lines, and thresholds were not taken into account when presets were saved or loaded. These will now be included. Note that the initial preset content checkboxes will be different in this buffer mode compared to the regular spectrum analyzer mode.

#### SLAnalytics: Automatic incident tracking would not start up when an alarm was cleared during the startup routine \[ID_32408\]

In some cases, automatic incident tracking would not start up when an alarm was cleared during the startup routine.

#### SLAnalytics: Problem with alarm grouping when alarms were generated while automatic inci­dent tracking was starting up \[ID_32410\]

When alarms were generated while automatic incident tracking was starting up, in some cases, an alarm could internally be duplicated, leading to incorrect alarm groups (e.g. groups containing only a single alarm).

#### DataMiner Cube - Alarm Console: Problem with “new alarms” counter when alarms were grouped by service \[ID_32427\]

When, in an alarm tab in which the alarms were grouped by service, an alarm affecting at least two services was cleared, then the “new alarms” counter in the tab header would show an incorrect number of alarms.

#### Alerter: Sound files not loaded correctly \[ID_32431\]

In some cases, the sound files configured in Alerter could not be loaded correctly to the client, so that these no longer worked.

#### A large number of CRequest::Request errors would be logged when elements were stopped \[ID_32444\]

When elements were stopped, in some cases, a large number of CRequest::Request errors would be logged.

#### Not possible to create element with invalid XML character in name \[ID_32455\]

In some cases, it was no longer possible to create elements with an invalid XML character in the element name, even if that character was supported in Cube (e.g. “&”).

#### DataMiner Cube: Problem when accessing an information template, a trend template or an alarm template from within the Alarm Console \[ID_32457\]

In the Alarm Console, you can right-click an alarm and select *Change \> Information*, *Change \> Trending* or *Change \> Alarm range* to access the information template, the trend template or the alarm template for the parameter associated with the alarm. In some rare cases, you could only do so once. When you tried to access an information template, a trend template or an alarm template a second time by right-clicking *Change \> Information*, *Change \> Trending* or *Change \> Alarm range*, a blank window would incorrectly appear.

#### Pinned state of alarm tab cards not included in workspace \[ID_32471\]

When a workspace was saved, the pinned state of alarm tab cards was not included.

## Addendum CU13

### Enhancements

#### SLElement: Enhanced performance when resolving table relationships \[ID_32176\]

Due to a number of enhancements, overall performance of SLElement has increased when resolving table relationships.

#### DataMiner Cube: Enhanced performance when reloading protocols after a protocol update \[ID_32315\]

Due to a number of enhancements, overall performance has increased when reloading protocols after a protocol update.

#### Filtered subscriptions will now be processed similarly to non-filtered subscriptions \[ID_32399\]

Filtered subscriptions will now be processed similarly to non-filtered subscription, regardless of whether the element in question is hosted on the local DMA or a remote DMA.

#### DataMiner Cube - Users/Groups: Permissions needed to edit group membership \[ID_32456\]

When opening their user card, from now on, users will only be able to edit group membership if they have the following permissions:

- Administrator permission, or

- Limited administrator permission as well as “Edit all groups” or “Edit own groups” permission

> [!NOTE]
> Users only need to have the “Edit own groups” permission to be able to configure a group of which they are a member.

####  Dashboards app - Parameter page component: WebSocket subscriptions will now be used for parameter tables when possible \[ID_32476\]

When a parameter table is being displayed in a parameter page component, when possible, the underlying table component will now make use of WebSocket subscriptions.

#### DataMiner backups will now by default also include SSL certificates and EPMConfig.xml files \[ID_32504\]

Full backups and configuration backups will now by default also include the EPMConfig.xml files and all certificates used by protocols for encrypted communication with devices.

#### DataMiner Cube - Correlation: Using hidden elements when creating correlation rules \[ID_32510\]

When creating a correlation rule in the Correlation app, it is now possible to use a hidden element in both the *Alarm Filter* section and the *Rule Condition* section.

#### Enhanced performance when stopping SNMP elements \[ID_32523\]

Due to a number of enhancements, overall performance has increased when stopping SNMP elements.

#### Dashboards app - Parameter feed: “Selected only” toggle button has been removed \[ID_32541\]

Up to now, a parameter feed had a *Selected only* toggle button that allowed you to show or hide items that were not selected. Now, this toggle button has been removed.

Also, when a dashboard is loaded with an initial selection (either configured or in the URL), the selected items will now always appear at the top of the list.

#### DataMiner Cube - Data Display: Row filter will now be shown when opening the alarm template, trend template or information template for a particular parameter table row \[ID_32555\]

When, in Data Display, you drill down to a specific row of a parameter table, you can open the alarm template, trend template or information template for that specific row. From now on, if a filter was configured for the table row in question, it will also be shown in the UI.

####  DataMiner Cube - Automation: SaveAutomationScriptXmlMessage will now be used when importing, saving and updating Automation scripts \[ID_32557\]

Up to now, when an Automation script was imported, the file would not be processed in the same way as when an Automation script was saved or updated. From now on, the same SaveAutomationScriptXmlMessage will be used when importing, saving and updating Automation scripts.

#### Protocols: Allow for different remote element sources in view table columns \[ID_32579\]

When setting up remote columns, up to now, all columns had to refer to the same parameter containing a list of remote elements (e.g. “view=:x:y:z”, where x is the ID of the parameter containing the remote element IDs). From now on, it is possible to have two sets of elements referenced by different columns within the same view table.

In the following example, parameters 201 and 301 each contain a list of remote elements, and both can be used within the same view table (in different ColumnOption tags).

```xml
<ColumnOption idx="3" pid="2004" type="retrieved" options=";view=:201:1000:3"/>
<ColumnOption idx="4" pid="2005" type="retrieved" options=";view=:301:1000:4"/>
```

#### Service & Resource Management: Updated exceptions thrown when the time range of a child ReservationInstance or child ReservationDefinition is invalid \[ID_32581\]

The following exception messages have been enhanced:

**Exception thrown when the time range of a child ReservationInstance is invalid**

This message now includes the ID, the name and the time range of both the parent and the child.

```txt
The TimeRange of the child is not within the boundaries of the parent ReservationInstance (Child: '{Child Name}' ({Child ID}) has range '{Child Range}' & Parent: '{Parent Name}' ({Parent ID}) has range '{Parent Range}')
```

**Exception thrown when the time range of a child ReservationDefinition is invalid**

This message now includes the ID, the name and the time range of both the parent and the child. For the child, the offset has now also been added.

```txt
The timing of the child is not within the boundaries of the parent ReservationDefinition (Child: '{Child Name}' ({Child ID}) has timing with duration '{Child Timing Duration}' and offset '{Child offset}' & Parent: '{Parent Name}' ({Parent ID}) has timing with duration '{Parent Timing Duration}')
```

####  Hanging threads in SLNet will now be logged in SLHangingCalls.txt \[ID_32582\]

Up to now, hanging threads in SLNet would be logged in the SLNet.txt file. From now on, these will be logged in the new SLHangingCalls.txt file instead (without the stack trace).

This file will by default be refreshed every 5 minutes.

#### Enhanced performance when uploading DataMiner upgrade packages \[ID_32597\]

Due to a number of enhancements, overall performance has increased when uploading DataMiner upgrade packages.

#### DataMiner Cube - Spectrum analysis: Additional logging to help pinpoint monitor failures \[ID_32605\]

When, on a spectrum element card, you select *View buffer* in the *monitors* tab of the ribbon, the selection boxes should contain all available monitor buffers.

In DataMiner Cube, additional logging is now available to help pinpoint monitor execution failures by providing information about the monitor buffers that will be shown based on the backend buffer response.

#### DataMiner Cube: Information templates will only show the read parameter in case of a toggle button \[ID_32610\]

Up to now, for a write parameter configured as a toggle button, an information template would show two parameters: a read parameter and a write parameter. From now on, toggle buttons will be treated as regular parameters. In an information template, only the read parameter (of type discreet) will be shown.

#### Enhanced performance of the interprocess communication between SLDataGateway and SLA­nalytics \[ID_32653\] \[ID_32709\]

Due to a number of enhancements, overall performance of the interprocess communication between SLDataGateway and SLAnalytics has increased.

#### Server processes will now use InvariantCulture \[ID_32665\] \[ID_32912\]

Up to now, server processes like SLNet used the default system locale. If this locale was a language other than English, all internal .NET Framework exception stack traces and log messages would be generated in that language, making it harder to interpret or analyze them. From now on, the server processes will now force their threads to use the CultureInvariant culture by default.

> [!NOTE]
> SLManagedAutomation and SLManagedScripting will continue to use the default system locale.

#### DataMiner Cube - Automation: Specifying an offset value will now be optional in case of a Set action \[ID_32743\]

When, in an Automation script, you configured a Set action for which an offset value could be specified, up to now, it was mandatory to specify that offset value. From now on, specifying an offset value will be optional. Either select “with value offset” and enter a value, or select “without value offset”.

Default: “without value offset”

### Fixes

#### SNMP forwarding: Problem when deleting an SNMP manager and immediately creating an identical one \[ID_32406\]

When you deleted an SNMP manager of type SNMPv3 and then immediately created an identical one, in some rare cases, an exception of type “Float Invalid Operation” would be thrown.

#### DataMiner Cube - Services app: Expand/collapse button in front of a service profile definition would disappear when you expanded or collapsed the service profile definition node \[ID_32439\]

When, in the Profiles tab of the Services app, you expanded or collapsed a service profile definition node in the tree on the left, the expand/collapse button in front of that service profile definition would incorrectly disappear. In other words, there was no way to reverse the expand/collapse action.

#### DataMiner Cube - Data Display: Not possible to open the alarm template or trend template of a parameter that was not trended \[ID_32449\]

When, in Data Display, you drill down to a parameter of an element, you can configure the alarm and trend templates for that specific parameter. When you tried to configure the alarm template or the trend template of a parameter that can be trended but wasn’t, up to now, it would incorrectly not be possible to open the alarm template or trend template of that specific parameter.

#### DataMiner Cube - Profiles app: Problem when trying to retrieve mediation snippets and service profiles on a system without ElasticSearch database \[ID_32488\] \[ID_32539\]

When you tried to open the Profiles app on a DataMiner System with a Service Manager license that did not have an ElasticSearch database, the app would fail to initialize when attempting to retrieve mediation snippets and service profiles. From now on, the presence of an ElasticSearch database will be checked before trying to retrieve mediation snippets and service profiles.

> [!NOTE]
> On systems without an ElasticSearch database, it is not possible to configure mediation snippets.

#### Stopping an SNMPv3 element could have a negative impact on the overall performance of other SNMPv3 elements \[ID_32498\]

Up to now, in some cases, stopping an SNMPv3 element could have a negative impact on the overall performance of other SNMPv3 elements.

#### Problem when trying to delete a protocol \[ID_32522\]

In some cases, an error could occur when you tried to delete a protocol.

#### DataMiner Cube - Visual Overview: Problem with initial page selection \[ID_32527\]

When you assign a Visio drawing to a view or a service, you can specify a default page. This initial page selection would no longer work.

Also, when the *How to show element card Data pages* setting was set to “Show in drop-down box”, initial page selection would no longer work.

#### SLProtocol would leak memory when using a “change after response“ trigger \[ID_32572\]

When using a “change after response” trigger, SLProtocol would leak memory on every incoming response. See the following example.

```xml
<Trigger id="2">
  <On id="1">parameter</On>
  <Time>change after response</Time>
  <Type>action</Type>
  <Content>
    <Id>2</Id>
  </Content>
</Trigger>
```

#### Elasticsearch: Problem when using a filter that checked whether a string was empty \[ID_32586\]

In some cases, Elasticsearch would return an incorrect number of records when a query contained a filter that checked whether a string was empty in combination with other filters.

#### Memory leak in SLNet caused by GQI queries \[ID_32589\]

In DataMiner versions up to and including 10.1.12, GQI queries would cause a memory leak in SLNet.

#### Miscellaneous small fixes \[ID_32655\]

A number of miscellaneous, small fixes have been made.

#### Serial protocols: Length check would incorrectly take into account the data before the header \[ID_32669\]

Up to now, when a payload with data before the header was received (e.g. aaaa\<header>payloadwithfixedlength), the data before the header would correctly be stripped off before forwarding the payload to the protocol, but the length check would incorrectly take that data into account.

#### SLNetClientTest: Problems with “Agent Connections” window \[ID_32679\]

When, in the SLNetClientTest tool, you opened the *Agent Connections* window (by selecting *Diagnostics \> Connections \> View DMA Connections*),

- Agents could incorrectly display a “Disconnected” state while actually being connected.

- The “Calls From” column could incorrectly display “(not available)”.

#### DataMiner Cube - Asset Manager: UI could become unresponsive when the database configura­tion was being retrieved \[ID_32766\]

When, in DataMiner Cube, you opened the Asset Manager app, in some cases, the UI could become unresponsive when the database configuration was being retrieved.

## Addendum CU14

### Enhancements

####  Security enhancements \[ID_32954\] \[ID_32992\] \[ID_33052\]

A number of security enhancements have been made.

#### Enhanced setup of serial connections with SSL/TLS enabled \[ID_32969\]

A number of enhancements have been made with regard to the setup of serial connections with SSL/TLS enabled.

### Fixes

#### Alarm templates: Miscellaneous fixes \[ID_32462\]

A number of issues have been fixed with regard to alarm templates.

- When you updated an alarm template that contained a table parameter with at least two filters, only the last of those filters was calculated.

- When, in an alarm template, you disabled the smart baselines for a table parameter with a filter and then re-enable it, the smart baselines for that table parameter would no longer be calculated.

Also, a number of enhancements have been made with regard to the calculation of smart baselines.

#### Service & Resource Management: GetEligibleResources would ignore the time range passed to it \[ID_32763\]

Up to now, when GetEligibleResources was called, the eligible resources would incorrectly be calculated based on the time range of the ReservationInstance to be ignored. From now on, when the context passed to GetEligibleResources includes a time range, the time range of the ReservationInstance will be ignored.

#### DataMiner Cube: Problem when opening the Ticketing app \[ID_32775\]

Up to now, in some cases, the Cube UI could become unresponsive when you opened the Ticketing app.

#### DataMiner Cube - Visual Overview: SET command linked to a shape would not be executed when the page was displayed in a VdxPage window of type “Popup” \[ID_32780\]

When a page that was displayed in a VdxPage window of type “Popup” contained a shape linked to a SET command, clicking that shape would incorrectly not execute the SET command.

####  DataMiner Cube - Resources app: No resources or resource pools would be loaded when opening the Resources app \[ID_32790\]

When you opened the Resources app, in some cases, no resources or resource pools would be loaded.

#### Processes would not get registered correctly when a DataMiner upgrade included a reboot \[ID_32818\]

When a DataMiner upgrade included a reboot (either explicitly requested, or e.g. after installing Microsoft .NET 4.8), in some cases, services would not get registered correctly, especially when the new DataMiner version included services that did not previously exist.

#### Problem with SLDMS hosting agent cache \[ID_32827\]

In some rare cases, the SLDMS hosting agent cache could get corrupted. As a result, it would no longer contain the correct data when processing element updates.

####  NAS: Incorrect default settings in nas.config file \[ID_32840\]

The default settings in the nas.config file would be incorrect.

####  Memory leak in SLElement \[ID_32885\]

In some cases, a problem with subscriptions on views with remote data would cause SLElement to leak memory, which could eventually lead to run-time errors in the parameter thread.

#### Filtered tables could incorrectly receive updates for rows that did not match the applied filter \[ID_32915\]

In some cases, a filtered table could incorrectly receive updates for rows that did not match the applied filter. On EPM setups, this would cause performance issues and run-time errors.

#### Online SLA window would not get properly closed \[ID_32946\]

In some cases, an online SLA window would not get properly closed.

#### DataMiner Cube: No longer possible to move DVE elements to another view \[ID_32984\]

In some cases, it would incorrectly no longer be possible to move DVE elements to another view.

#### Problem with SLLog when a log file was closed \[ID_33191\]

In some cases, an error could occur in the SLLog process when a log file was closed.

## Addendum CU15

### Enhancements

#### Security enhancements \[ID_33014\]

A number of security enhancements have been made.

####  DataMiner Taskbar Utility: Deprecated launch options for System Display and Cube removed \[ID_32877\]

In the DataMiner Taskbar Utility, the following options have been removed:

- Launching System Display by double-clicking while pressing the SHIFT key.

- Opening the locally installed DataMiner Cube in Microsoft Internet Explorer by double-clicking.

> [!NOTE]
> The following option has been kept:
> - Opening Windows file explorer in the C:\\Skyline DataMiner\\ folder by double-clicking while pressing the CTRL key.

#### Enhanced performance when starting up elements \[ID_33023\]

Because of a number of enhancements, overall performance has increased when starting up elements, especially elements containing large amounts of data.

#### DataMiner Cube & legacy Reporter app: Alarm state change graphs now differentiate between masked state and unknown state \[ID_33082\]

From now on, the alarm state change graphs (pie chart and time line) in the legacy Reporter app and the alarm state change pie chart on the REPORTS page of an element card in Cube will differentiate between masked state and unknown state.

Also, in the legacy Reporter app, the default colors have now been aligned with the default DataMiner alarm colors.

####  Monitoring app now also takes into account Param.Message tags \[ID_33162\]

In a protocol.xml file, for every write parameter, you can specify a message to be displayed when users change that parameter on the UI.

Up to now, this *Param.Message* tag was only taken into account by DataMiner Cube. From now on, the Monitoring app will also take it into account.

#### SLDMS process is now large address aware \[ID_33234\]

SLDMS, which is a 32-bit process, will now be started with the /LARGEADDRESSAWARE flag. This way, it will be able to access up to 4GB of memory.

#### Enhanced performance when processing a large number of objects with links to other objects \[ID_33271\]

Because of a number of enhancements, overall performance has increased when processing (e.g. exporting) a large number of objects with links to other objects.

#### IPC channel port names will now always be unique \[ID_33274\]

IPC channel port names will now always be unique.

### Fixes

#### QActionHelper DLL file could incorrectly be loaded twice \[ID_32647\]

In some rare cases, protocols could incorrectly load the QActionHelper DLL file twice.

#### Ticketing app: Problem when using the filter box \[ID_33079\]

When you entered a search string in the filter box, all tickets would incorrectly be returned.

#### DataMiner Cube - Automation: Problem when validating an Automation script \[ID_33084\]

When, in the Automation app, you validated an Automation script that either contained an empty line in the DLL references or had a DLL reference removed, in some cases, an “Empty path name is not legal” error could be thrown.

#### DataMiner Cube: REPORTS page of a masked element would incorrectly indicate that the ele­ment was in alarm instead of masked \[ID_33087\]

When you masked an alarm as well as its associated element, in DataMiner Cube, the REPORTS page of the element in question would incorrectly indicate that the element was in alarm instead of masked.

#### Business Intelligence: Problem with SLProtocol when an SLA or an element in a service tracked by an SLA was being (re)started \[ID_33098\]

In some cases, an error could occur in SLProtocol when an SLA or an element in a service tracked by an SLA was being (re)started.

Also, additional logging has been added to help debug and track SLA issues.

#### SLElement: Display key cache would not get properly cleaned up when a row was deleted \[ID_33114\]

In some cases, the display key cache of SLElement would not get properly cleaned up when a row was deleted. This could cause memory leaks when a protocol added or removed a large amount of rows.

#### DataMiner Cube - Visual Overview: Bitmap images would be missing when opening a cached version of a VDX file \[ID_33116\]

When a Visio file of type VDX contained bitmap images, in some cases, those images would be missing when you opened a cached version of that file.

#### SNMP polling: Group with multiple tables of which some had the “partialSNMP” option enabled would get re-polled indefinitely \[ID_33197\]

When a group that contained multiple tables of which some had the partialSNMP option enabled was polled, in some cases, that same group would incorrectly get re-polled indefinitely.

#### Interactive Automation scripts: Slider linked to a numeric text box would incorrectly keep fol­lowing the mouse pointer \[ID_33204\]

In interactive Automation scripts, in some cases, the slider linked to a numeric text box would incorrectly keep following the mouse pointer, even after the mouse button had been released.

#### Port 0 would incorrectly be used for serial communication when a dynamic IP parameter did not contain an IP port \[ID_33235\]

When a dynamic IP parameter was set to a value that contained only an IP address instead of an IP address and a IP port, then port 0 would incorrectly be used for serial communication.

From now on, when no IP port is specified, the last port set will be used. And if no port has been set yet, then the port configured in the element wizard will be used.

#### Problem when trying to retrieve base parameter values after changing the production version of a protocol based on a base protocol \[ID_33288\]

After changing the production version of a protocol based on a so-called base protocol, it would no longer be possible to retrieve values from any of the base parameters (i.e. parameters of the base protocol).

#### Problem when filtering a table with a foreign key relation to a remote table using a filter that contained a value from the remote table \[ID_33294\]

When a table with a foreign key relation to a remote table was filtered using a filter that contained a value from the remote table, up to now, all rows would incorrectly be returned when the remote table was empty. From now on, when the remote table is empty, no rows will be returned.

#### DataMiner Cube - Trending: Problem when zooming out on a trend graph \[ID_33298\]

When you zoomed out on a trend graph with a large number of data points, in some cases, the UI would become unresponsive.

#### Problem with SLDataMiner when a DMA started up while another DMA in the DMS was register­ing the SLAs \[ID_33303\]

When a DataMiner Agent started up while another DataMiner Agent in the DMS was registering the SLAs, in some cases, an error could occur in the SLDataMiner process.

## Addendum CU16

### Enhancements

#### QActionTable class - FillArray and FillArrayNoDelete methods: Argument “row” renamed to “columns” \[ID_33034\]

The *row* argument of the FillArray and FillArrayNoDelete methods in theQActionTable class has been renamed to *columns*.

#### SLPort: Enhanced performance when processing large HTTP responses \[ID_33128\]

Because of a number of enhancements, overall performance of SLPort has increased when processing large HTTP responses.

#### SLProtocol: SetParameterIndexByKey and SetParametersIndexByKey methods can now also be used to update a single cell \[ID_33198\]

From now on, the SetParameterIndexByKey and SetParametersIndexByKey methods can also be used to update a single cell.

#### Ticketing app: Tickets can now be filtered on fields of type “drop-down list” \[ID_33370\]

In the Ticketing app, tickets can now also be filtered on fields of type “drop-down list”.

#### DataMiner Cube - Visual Overview: Shape that displays a page of the Visio drawing linked to a view, service or element will no longer be displayed when the element, service or view in ques­tion does not exist \[ID_33484\]

From now on, a shape that displays a page of the Visio drawing linked to a view, service or element (i.e. a shape with a shape data field of type VdxPage) will no longer be displayed when the view, service or element in question does not exist.

#### DataMiner Cube: Enhanced performance when using the search box in the Cube header \[ID_33510\]

Because of a number of enhancements, overall performance has increased when using the search box in the Cube header.

#### SLLogCollector will now also collect the log files of the ArtifactDeployer, CloudFeed and Orches­trator processes \[ID_33514\]

SLLogCollector will now also collect the log files of the following cloud processes:

- ArtifactDeployer

- CloudFeed

- Orchestrator

#### SLElement: Enhanced performance when processing service and DCF information \[ID_33635\]

Because of a number of enhancements, overall performance of SLElement has improved when processing service and DCF information.

### Fixes

#### Protocol QActions: Problem when calling FillArray or FillArrayNoDelete with List\<object\[\]\> as columns value \[ID_28573\]

When, in a QAction, protocol.FillArray or protocol.FillArrayNoDelete were called with List\<object\[\]\> as columns value, an exception would be thrown.

#### DataMiner Cube - Logging: Entries in the “Communication” tab would not get cleaned up as long as System Center was kept open \[ID_33085\]

When, in *System Center*, you opened the *Logging* section, entries would be added in the *Communication* tab as long as *System Center* was kept open. The cleanup settings specified in *Settings \> Computer \> Advanced \> Communication* would incorrectly not be applied. On systems with a large amount of traffic, this could lead to memory problems.

From now on, the above-mentioned cleanup settings will be applied correctly.

#### Failover: Problem when the Cassandra service was unexpectedly started by DataMiner during setup \[ID_33161\]

When a Failover system was being set up, an error could occur when the Cassandra service was unexpectedly started by DataMiner.

#### Protocols: WebSocket ports incorrectly interpreted as HTTP ports \[ID_33220\]

When you created an element with a protocol in which a WebSocket connection was configured as shown in the example below, up to now, the connection would incorrectly be interpreted as an HTTP port instead of a WebSocket port.

```xml
<Connections>
  <Connection id="0" name="WebSocket Interface">
    <Http>
      <CommunicationOptions>
        <WebSocket>true</WebSocket>
        <NotifyConnectionPIDs>
          <Connections>6</Connections>
        </NotifyConnectionPIDs>
      </CommunicationOptions>
    </Http>
  </Connection>
</Connections>
```

#### Replicated main DVE element would incorrectly execute a sequence twice \[ID_33270\]

When, inside a replicated DVE parent element, the exporting DVE table that contained the column with DVE element IDs also contained a column with a \<Sequence>, then that sequence would incorrectly be executed twice on the replicated element.

#### DataMiner Cube - Trending: Legend would incorrectly show a unit when hovering over an excep­tion value \[ID_33280\]

When, in a trend graph, you hovered the mouse pointer over an exception value, the legend would not only show the minimum value, the maximum value and the value of the data point, but also incorrectly a unit. From now on, when you hover over an exception value, the legend will no longer show a unit.

#### Values in a decimal logger table column would lose their decimals when the element was restarted or the database was queried \[ID_33315\]

When, in a logger table, a column with \<ColumnDefinition>DECIMAL\</ColumnDefinition> contained a value with decimals, then those decimals would be lost when the element was restarted or the database was queried.

#### SNMP forwarding: Problem with OID logging \[ID_33338\]

In the SNMP Managers log, in some cases, OIDs would incorrectly be replaced by hexadecimal numbers.

Also, when a table column contained an OID in an incorrect format, the table would only contain the first row up to the column with that incorrectly formatted OID. The rest of the rows would be missing. From now on, when an incorrectly formatted OID is detected, the table will no longer contain any data and Stream Viewer will show an error containing the OID in question.

#### Incorrect IP address could be added to DMS.xml during a DataMiner startup \[ID_33339\]

When the DataMiner software started up on an agent that was not part of a Failover setup, in some cases, an incorrect IP address could get added to the DMS.xml file. Later on, this could lead to e.g. agent synchronization issues.

#### Automation scripts would incorrectly succeed even when uploading a report had failed \[ID_33368\]

When, in an Automation script, you had configured an action that uploads a report to a shared folder or FTP, up to now, the script would still succeed even when it had not been able to copy the generated report to the remote location (shared folder or FTP). From now on, when a script is not able to copy a report to a remote location, it will fail.

#### DataMiner Cube: Casing incorrectly not taken into account when comparing the name of a newly created property against the existing property names \[ID_33388\]

When you created a new view, element, service or alarm property, up to now, the name of that new property would be checked against all existing property names without taking the casing into account. From now on, when the name of a newly created property is checked against existing property names, the casing will be taken into account.

#### Protocols: Mediation base protocols not available to DVE elements \[ID_33392\]

When a base protocol for a DVE element was configured at runtime, up to now, that base protocol would incorrectly only be taken into account after a DataMiner restart.

Also, after a DataMiner restart, only the base protocols of the main DVE element would be made available, even in situations where DVE child elements did not have the same base protocols as the DVE main element.

#### Protocols: \<UserSettings> element would not be taken into account when a new element was created \[ID_33394\]

When a protocol.xml file using the latest \<Connections> syntax contained a \<UserSettings> element, the user settings specified in the \<UserSettings> element would incorrectly not be taken into account when a new element was created.

#### Errors when different protocol selection for element was incompatible with existing SNMPv1 connection \[ID_33406\]

When a different protocol was selected for an element, causing one of the connections to no longer be compatible with SNMPv1, this could cause "Element not known yet" errors during polling and potentially even RTEs. To prevent this, the element will now be placed in an error state in such a case.

#### Service & Resource Management: Primary key of FunctionResource would be set to an invalid value after an update \[ID_33412\]

When an existing FunctionResource object was updated, in some cases, the primary key would be set to an invalid value.

#### Problems related to alarms \[ID_33413\]

A number of alarm-related issues have been fixed:

- When advanced naming was configured to create a display key that contained parameters from linked tables, in some cases, the service impact of the alarms would be incorrect.

- When a new row was added to a table, in some cases, the conditional monitoring based on service impact alarming would be incorrect.

- In some cases, alarms retrieved from the database would contain outdated fields in the alarm tree.

#### Automation scripts: Problem with processor directives \[ID_33424\]

Up to now, the following preprocessor directives would incorrectly be inserted into the Automation script code, causing syntax errors to appear on the incorrect lines.

- #define DBInfo

- #define DCFv1

- #define ALARM_SQUASHING

#### Log entry containing an incorrect number of timers would be added to the element log file when an element was stopped \[ID_33438\]

When you stopped an element, an entry containing an incorrect number of timers would be added to the element log file. See the example below.

```txt
CProtocol::HaltPolling|INF|0|-- -7599514566606716925 timers to stop
```

#### DataMiner Cube - Visual Overview: No longer possible to filter Alarm Console tabs when clicking an AlarmFilter shape \[ID_33443\]

If you add a shape data field of type *AlarmFilter* to a shape, clicking the shape will cause Alarm Console tabs of type *Active alarms linked to cards* only to show alarms that match the alarm filter specified in the field value. However, in some cases, this no longer worked.

#### Problem when trying to migrate elements of which the name contained square brackets \[ID_33455\]

When you tried to migrate an element with a name containing square brackets (e.g. “\[HQ\] Main Switch”), in some cases, the operation could fail with an error message like “Illegal 'Reference Protocol' syntax”.

#### Automatic Incident Tracking: Clearable base alarms of an incident were cleared when the inci­dent was cleared \[ID_33481\]

When an incident (i.e. alarm group) was cleared, in some cases, its clearable base alarms would incorrectly be cleared as well when the AutoClear option was disabled.

#### Automation: SetParameterByPrimaryKey would fail to update a write-only parameter when using the parameter name as argument \[ID_33511\]

When, from an Automation script, a write parameter in a column of a table inside an element was updated using a ScriptDummy.SetParameterByPrimaryKey call with the parameter name as argument, the update would fail when that write parameter did not have a matching read parameter.

#### Problem when deleting a DVE child element or a virtual function \[ID_33519\]

When a DVE child element or a virtual function was deleted, all data related to the main DVE element and the other DVE child elements and virtual functions would incorrectly also be deleted from the service cache. As a result, alarm updates would no longer affect the services.

#### Problem with SLElement when updating bubble-up levels \[ID_33542\]

In some rare cases, an error could occur in SLElement when updating the bubble-up levels.

#### Problem in SLSNMPManager when element using SNMP polling was stopped \[ID_33563\]

When an element using SNMP polling was stopped, a problem could occur in the SLSNMPManager process. The cause of this was that the polling did not stop and requests kept being sent, leading to a stack overflow. To prevent this, now an error has been added when data is requested while the polling is halted.

## Addendum CU17

### Enhancements

####  Security enhancements \[ID_33684\]

A number of security enhancements have been made.

#### Business Intelligence: Enhancements made to the automatic SLA data clean-up mechanism \[ID_33663\]

A number of enhancements have been made to the automatic SLA data clean-up mechanism.

### Fixes

#### Problem with SLPort when the last serial element using a specific IpAddress:IpPort connection was stopped \[ID_33437\]

In some cases, an error could occur in SLPort when the last serial element using a specific IpAddress:IpPort connection was stopped.

#### Problems when migrating data from SQL to Cassandra \[ID_33524\]

In some cases, the following issues could occur when migrating data from SQL to Cassandra:

- Online migration would be executed, but would not get marked as completed in Cube.

- Offline migration would fail to launch.

Also, Cube will no longer throw “System.InvalidOperationException: Collection was modified” errors.

#### DataMiner Cube: Properties of exported elements would not be added to the CSV file in the cor­rect order \[ID_33528\]

When you had exported elements to a CSV file, the element properties would not be added to the CSV file in the correct order.

#### DataMiner Cube - Data Display: Problems with button and date/time picker sizing \[ID_33601\]

In some cases, the width of a button would not automatically be adapted to the text displayed on the button.

Also, in date/time picker controls, the buttons to pick or clear a date/time would not be displayed correctly.

####  DataMiner Cube - Annotations: Images would get removed when saving an annotation \[ID_33623\]

When you saved an annotation, in some cases, any images added to the annotation would incorrectly get removed.

#### DataMiner Cube - Data Display: Buttons inside a table would incorrectly be grayed out when scrolling \[ID_33641\]

When scrolling through a table of which the rows contained buttons, in some cases, those buttons would incorrectly be grayed out.

#### Serializing/deserializing would not work when dictionary key contained spaces \[ID_33677\]

Up to now, serializing/deserializing would not work when creating a filter that contained spaces inside quotes (see the example below).

Example:

```txt
AlarmEventMessageExposers.PropertiesDict.DictStringField($"Booking Manager Element ID").Matches(".+")
```

####  Service & Resource Management: Problem when adding, updating or deleting a resource \[ID_33678\]

When you tried to add, update or delete a resource, a NullReferenceException could be thrown when the Resources.xml file was locked by another process.

#### No alarm would be generated when an element that exported data failed to start \[ID_33744\]

When an error occurred during the startup of an element that exported data (e.g. a DVE or function element), in some cases, no alarm would be generated.

#### SLWatchdog: Problem when generating the database report \[ID_33769\]

In some cases, an error could occur in SLWatchdog when generating the database report.

#### SNMP: Former value of updated cell would incorrectly be returned the first time the table was polled after the update \[ID_33855\]

When a cell in a table with “pollingrate” enabled had been updated, the first time the table was polled after the update, the former value of that cell would incorrectly be returned.

#### Protocols: Additional connections with a “Type” defined would incorrectly be ignored \[ID_33941\]

Additional connections that had a “\<Type>” defined would incorrectly no longer be taken into account.

In the following example, the second connection would incorrectly be ignored.

```xml
<Connections>
  <Connection id="0" name="HTTP Connection">
    <Type>http</Type>
    ...
  </Connection>
  <Connection id="1" name="WebSocket Interface">
    <Type>http</Type>
    ...
```

> [!NOTE]
> Specifying a type with \`\<Type>\` for one connection and specifying a type with e.g. \`\<Http>\` for another connection is not supported.

## Addendum CU18

### Enhancements

#### Security enhancements

A number of security enhancements have been made.

#### Serial connections: Hostname resolution enhancements [ID_33702]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a serial connection was configured with a hostname instead of an IP address, up to now, the hostname would be resolved when the port was initialized. When the hostname suddenly pointed to a different IP address, an element restart or a dynamic IP address change was needed for the serial connection to be aware of that change.

This has now been changed:

- In case of a TCP-oriented serial connection (serial SSL/TLS, SSH and serial TCP), the hostname will be resolved upon every connect.

- In case of a UDP-oriented serial connection (serial UDP), the hostname will be resolved prior to every send.

#### SLPort: Order of parameters in an HTTP session request will be identical to that in the protocol [ID_33796]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In an HTTP session request, the order of the parameters will now always be identical to that in the protocol.

#### DVE function protocol version of active functions will now be deleted when the main DVE protocol version is deleted [ID_33834]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a version of a DVE protocol with function DVE protocols is deleted from the system while functions are active, from now on, the function DVE protocol versions associated with those active functions will also be removed from the system.

#### SLLogCollector: Enhanced processing of SLProtocol memory dumps [ID_33932]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Because of a number of enhancements, SLLogCollector is now better able to collect SLProtocol memory dumps, especially in cases where there is no reference to an element.

#### Enhanced error handling in case QActions fail due to a problem with SLScripting [ID_34010]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When an error occurs in SLScripting, from now on, a new SLScripting instance will be started and all QActions will be reloaded.

#### Parameter changes will now only be pushed from SLProtocol to SLElement when needed [ID_34047]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Up to now, parameter changes would always be pushed from SLProtocol to SLElement. From now, those changes will only be pushed from SLProtocol to SLElement when needed.

#### Size of the WebSocket messages sent from SLPort to SLProtocol will now be limited to 1024 packets [ID_34049]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.8 [CU1] -->

In order to prevent SLPort from running out of memory, from now on, the size of the WebSocket messages sent from SLPort to SLProtocol will be limited to 1024 packets.

### Fixes

#### SLLogCollector would become unresponsive when the name of the process or the path where the files had to be stored contained spaces [ID_33493]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

While collecting log information, SLLogCollector would become unresponsive when the name of the process or the path where the collected files had to be stored contained spaces.

#### Monitoring app: Trend graph of table column parameter not displayed when table row index contained forward slash [ID_33661]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.8 -->

In the Monitoring app, the trend graph of a table column parameter would not be displayed when the table row index contained a forward slash.

#### SLProtocol would leak memory leak each time a parameter of a replicated element was updated [ID_33745]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

SLProtocol would leak memory each time a parameter of a replicated element was updated.

#### Problem with SLElement when resolving foreign keys took a long time and the the element debug log level was equal to or higher than 1 [ID_33826]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When the element debug log level was equal to or higher than 1, an error could occur in SLElement when resolving foreign keys took a long time. 

#### SNMPv3 credentials would incorrectly be checked when replicating an element with SNMPv3 connections [ID_33859]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you replicated an element with SNMPv3 connections, the SNMPv3 credentials of that element would incorrectly be checked. As a result, alarms like the following one would appear in the Alarm Console:

```txt
Load Element Failed: Error parsing SNMPv3 password for element: <element name>
```

#### SLProtocol could leak memory when the NT_UPDATE_PORTS_XML command was sent [ID_33891]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, the SLProtocol process could leak memory when the NT_UPDATE_PORTS_XML command was sent.

#### Certain types of alarms could affect and degrade an SLA [ID_33899]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When an alarm of one the following types was generated, in some cases, that alarm could affect and degrade an SLA or be added to the list of active alarms for that SLA (i.e. enhanced service):

- Information Event
- Suggestion Event
- Error Alarm
- Notice Alarm

#### SLSNMPManager: StackOverflow exception while trying to resolve the next Request ID [ID_33901]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, SLSNMPManager could throw a StackOverflow exception while trying to resolve the next Request ID.

#### An alarm property with a name identical to that of an element, service of view property would incorrectly get duplicated when the element with that alarm property was restarted [ID_34021]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you created an alarm property with a name identical to an existing property of an element, service or view, that alarm property would incorrectly be duplicated each time the element with that alarm property was restarted.

> [!NOTE]
> When upgrading to v10.2.0 [CU6] or v10.2.9, an upgrade action will check the *PropertyConfiguration.xml* file for any issues with duplicate properties and correct them.

#### Problem with SLSNMPManager when an SNMP Get or Set was put on the queue while the element in question was being stopped [ID_34038]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some rare cases, an error could occur in the SLSNMPManager process due to an SNMP Get or Set having been put on the queue while the element in question was being stopped.

#### When a stopped element was deleted, its logger tables would incorrectly not be deleted if created with options="database" [ID_34067]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a stopped element was deleted, logger tables associated with that element would incorrectly not be deleted if created with `options="database"`.

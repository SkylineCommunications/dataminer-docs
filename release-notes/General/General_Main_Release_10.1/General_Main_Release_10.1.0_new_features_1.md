---
uid: General_Main_Release_10.1.0_new_features_1
---

# General Main Release 10.1.0 - New features (part 1)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!NOTE]
> **Internet Explorer Support**
>
> Though DataMiner Cube is available as a desktop application, many users still like to use the DataMiner browser application that requires Internet Explorer. However, Microsoft no longer recommends using Internet Explorer, and support for Internet Explorer is expected to cease in 2025, though currently the program is still maintained as part of the support policy for the versions of Windows it is included in. For more information, see <https://docs.microsoft.com/en-us/lifecycle/faq/internet-explorer-microsoft-edge>.
>
> The preferred way to use DataMiner Cube is as a desktop application, which can be downloaded from each DMA’s landing page in any other browser than Internet Explorer. From DataMiner 10.0.9 onwards, this application also comes with a new start window for increased ease of use.
>
> However, if you do wish to use DataMiner Cube in a browser, this remains possible:
>
> - Microsoft Edge can be configured to open specific URLs in IE compatibility mode. If you configure Edge to open the DataMiner Cube URLs of DMAs in this mode, you will be able to access the DMAs with DataMiner Cube in Edge. However, make sure you only do this for the exact URLs of DataMiner Cube, as other DataMiner apps will not function optimally in IE compatibility mode. For more information see, <https://docs.microsoft.com/en-us/DeployEdge/edge-ie-mode-policies>.
> - You can still continue to use Internet Explorer to access DataMiner Cube as long as Microsoft support continues. However, in this case we highly recommend to use a different browser to access any other websites on the internet.

### DMS core functionality

#### New SLNet setting 'ClusterTransitionStateTimeout' in MaintenanceSettings.xml \[ID_22136\]

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

1. Make sure the Cassandra cluster software is installed on each DMA. A [standalone installer](xref:Standalone_Cassandra_Cluster_Installer) is available for this.

1. [Install DataMiner Indexing](xref:Installing_Elasticsearch_via_DataMiner) on each DMA in the cluster if you have not done so already.

1. Migrate the database data to the Cassandra cluster. See [Migrating the general database to a DMS Cassandra cluster](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster).

    > [!NOTE]
    > We recommend that DataMiner is stopped before the migration is started. While it is possible to run the migration while DataMiner is running, any data that is stored in the source database during the migration may not be migrated to the target database.

1. In DataMiner Cube, go to System Center \> Database and select *CassandraCluster* in the Database box. Then specify the name, DB server and credentials to connect to the Cassandra cluster.

##### DB.xml changes

In the file *DB.xml*, the new database type “CassandraCluster” is now supported for the general (previously known as local) database. While previously, information in this file related to the general database was not synced in a cluster, if this database type is used, *DB.xml* is now completely synchronized throughout the cluster.

##### Cassandra cluster support in the DataMiner installer

If you want to use a Cassandra cluster for a new DMS, the DataMiner installer can be run in unattended mode with the necessary commands to install both Elasticsearch and Cassandra, and configure a Cassandra Cluster.

Below, you can find a list of new or updated settings that can be specified in the configuration file *InstallConfiguration.xml*.

- *DMA* tag:

  | Subtag | Description |
  |--|--|
  | Database | Indicates the database type to use (*Cassandra*, *CassandraCluster*, *MySQL* or *MSSQL*) using the type attribute. This tag must contain the following subtags, detailing the configuration for the *Db.xml* file: *DB*, *DBServer*, *DBDrive*, *ConnectString*, *UID* (user), *PWD* (password) and *Maintenance*. It is possible to leave some of these tags empty, in which case the default configuration will be applied. In addition, any other tags that can be configured in *Db.xml* can also be specified here, e.g. in the *Maintenance* tag. Note that for a non-Cassandra database, the drive specified in *DBDrive* must be C. |
  | CassandraClusterSettings | Used in case a database of type *CassandraCluster* is installed. See “CassandraClusterSettings tag” below. |
  | ElasticClusterSettings | Used in case a database of type *CassandraCluster* is installed. See “ElasticClusterSettings tag” below. |
  | SearchDataBase | Used in case a database of type *CassandraCluster* is installed. This tag must contain the following subtags, detailing the configuration for the Elasticsearch database in the Db.xml file: *DBServer*, *UID* (user) and *PWD* (password). |

- *CassandraClusterSettings* tag:

  | Subtag | Description |
  |--|--|
  | ListenAddress | The IP address that should be filled in for the *listen_address* setting in the cassandra.yaml file. |
  | Seeds | The IP addresses of the different Cassandra nodes in the system, which will be filled in for the *seed_provider* setting in the cassandra.yaml file. It is recommended to configure at most 3 seed IP addresses per data center; |
  | ClusterName | The name of the Cassandra cluster, which will be filled in for the *cluster_name* setting in the cassandra.yaml file. This must be the same for all DMAs. |
  | ClusterSize | The size of the cluster. When installing Cassandra, the installer will wait until this number of nodes are online before it continues. |
  | Port | The CQL native transport port, which will be filled in for the *native_transport_port* setting in the cassandra.yaml file. |
  | SystemAuthReplicationFactor | The replication factor for the system_auth keyspace. This keyspace contains the data required to log in to Cassandra. The replication factor determines how many replicas will exist for each row of this keyspace. |
  | DefaultKeyspaceReplicationFactor | The replication factor of the default keyspace. |
  | RpcAddress | The IP address that Cassandra will use for client-based communication, such as through the CQL protocol.  If this is left empty, it will not be defined in the cassandra.yaml. |
  | BroadCastRpcAddress | The address that Cassandra nodes will publish to connected clients. If most clients are outside the cluster's local network, this is typically the public address. Otherwise, it is typically the local network address. If this is left empty, it will not be defined in the cassandra.yaml. |
  | TargetInstallationDirectory | The location where Cassandra will be installed. |
  | DataPath | The location where Cassandra data will be stored. |
  | Snitch | The value that should be filled in for the *endpoint_snitch* setting in the cassandra.yaml file. The following values are supported: *SimpleSnitch*, *GossipingPropertyFileSnitch*, *PropertyFileSnitch*, *Ec2Snitch*, *Ec2MultiRegionSnitch*, *RackInferringSnitch*. Cassandra uses this setting to figure out the network topology, so that it can route requests efficiently and optimize the way data replicas are spread around the cluster. The recommended value is *GossipingPropertyFileSnitch.* Other values are commonly used when the Cassandra nodes are hosted in the cloud. |
  | IsResponsibleForConfiguration | Determines whether this DMA will be responsible for configuring the Cassandra cluster after it has been created. This includes creating the defined user as well as setting the “system auth” replication factor. This should only be set to true for 1 DMA. Possible values: true, false. |

- *ElasticClusterSettings* tag:

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

#### Dynamic table filters: New component type 'recursivefullfilter' \[ID_24672\] \[ID_24676\]

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

#### DataMiner Application packages \[ID_25911\]\[ID_26027\]\[ID_26169\]\[ID_26243\]\[ID_26271\]\[ID_26338\]\[ID_26351\]\[ID_26371\]\[ID_27257\]

It is now possible to install a DataMiner application or solution on an existing DataMiner system by uploading and installing a so-called “application package”.

##### Creating an application package

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

| File/Folder | Contents |
|--|--|
| AppInfo.xml | General information about the application:<br> - Name<br> - Version<br> - Description<br> - Minimum DataMiner version (format: x.x.x.x-xxxx, e.g 10.0.11.0-9451)<br> - Configuration parameters<br> - … |
| Scripts | \-  Install.xml: a script containing all installation instructions<br> - Config.xml: a script that will be launched when the application or solution is configured or reconfigured<br> - InstallDependencies: a folder containing all DLL files used by the installation script<br> - ConfigureDependencies: a folder containing all DLL files used by the configuration script |
| AppInstallContents | All auxiliary files needed by the installation script. |

> [!NOTE]
>
> - The Install.xml script, which must be able to access all data stored in the AppInstallContents folder, should check whether the system contains an earlier version of the application or solution in question and upgrade it. A full installation from scratch is to be avoided.
> - All configuration parameters used by the Config.xml script can be specified in the AppInfo.xml file.

##### Structure of the AppInfo.xml file

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

##### Script entry points

In both the Install.xml and Config.xml scripts, an entry point has to be defined.

- In the Install.xml script, define the following entry point:

    ```csharp
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

    ```csharp
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

##### Installing an application package

Application packages can be uploaded, viewed, installed and configured using the DataMiner SLNetClientTest tool. All commands related to application packages can be found under Advanced \> Apps \> AppPackages.

> [!NOTE]
> To be allowed to install application packages, you must be granted the following user permission:
>
> - Modules \> System configuration \> Agents \> Install App packages

Although the above-mentioned method is to be preferred, it is also possible to embed an application package into a .dmupgrade package. To install an application package this way, do the following:

1. Create a .dmupgrade package.

1. In the UpdateContent.txt file of that package, add an “InstallApp” instruction, followed by the path to the application package you created earlier:

    ```txt
    InstallApp ./Path/To/AppPackage/AppPackage.zip
    ```

1. Install the .dmupgrade package on a DataMiner Agent that is running.

> [!NOTE]
>
> - Make sure the .dmupgrade package does not contain any instructions to stop the DataMiner Agent.
> - If you intend to install the .dmupgrade package using the DataMiner Taskbar Utility, make sure the DataMiner Agent is running.
> - If you install the .dmupgrade package onto a DataMiner System, the DataMiner Agent on which the upgrade is launched will run the installation script found in the application package. If the upgrade is launched from a DataMiner Agent that is not a member of the DataMiner System, then the DataMiner Agent with the first IP address (in alphabetical order) will run the installation script.
> - It is not possible to install an application package on multiple Agents of the same DataMiner System by adding their IP addresses to the “external IPs” list in DataMiner Cube. This would cause the installation script to be launched on each of the Agents in that list. If you want to install an application package on multiple Agents, you can select the Agents to be upgraded while connected to one of the Agents in the DataMiner System (which makes it unnecessary to have an external IPs list) or you can install it using the DataMiner Taskbar Utility.

##### AppPackageHelper

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

##### Using statement

LogHelper should always be created within a using statement. See the following examples.

Automation script example:

```csharp
using(var logHelper = LogHelper.Create(engine.GetUserConnection()))
{
    // ...
 }
```

QAction example:

```csharp
using(var logHelper = LogHelper.Create(protocol.GetUserConnection()))
{
    // ...
 }
```

##### Automation

A new method was added to Engine and IEngine:

- Engine#GetUserConnection() : IConnection

It returns a connection that impersonates the user who ran the script based on Engine#UserCookie. If no user cookie is present on the script, the returned IConnection will act as the SLManagedAutomation connection.

##### QActions

A new method was added on SLProtocol interface:

- SLProtocol#GetUserConnection() : IConnection

It returns a connection that impersonates the user who triggered the QAction based on SLProtocol#UserCookie. If no user cookie is present within the QAction context, the returned IConnection will act as the SLManagedScripting connection.

##### Script and QAction compilation

Automation scripts and QActions will now by default be compiled with a reference to SLLoggerUtil.dll (C:\\Skyline DataMiner\\Files\\SLLoggerUtil.dll).

#### Proactive cap detection \[ID_26637\]\[ID_27132\]\[ID_27241\]\[ID_27355\]\[ID_27393\]

To further enhance the proactive monitoring capabilities of DataMiner, proactive cap detection is now available. This DataMiner Analytics feature predicts future issues based on trend data in the Cassandra database, using advanced techniques that consider repeating patterns, information on the rate at which a parameter value increases or decreases, etc. However, note that some events simply cannot be predicted. For example, a spike in a trend graph caused by randomly pulling out a cable can never be predicted by looking at historical trend data, so proactive cap detection will not know about this in advance.

##### Specifications

For the best results, both real-time and average trending should be activated on a parameter for which you want proactive cap detection to be available. To calculate its predictions, DataMiner Analytics will make use of the available real-time data, 5-minute average data, 1-hour average data and daily average data. It can predict at most 200 data points into the future. This is further limited by the available data: if there is a data set of a specific number of points, DataMiner Analytics can never predict further than that number of points divided by ten. For example, if the database contains one year of hourly averages and no daily averages, then DataMiner Analytics computes 365 daily averages and is able to predict issues 36 days into the future.

This feature is currently only available for trended parameters with numeric values, and not for partial table parameters. Because of memory constraints, proactive cap detection is also only possible for up to 100 000 parameters per DMA. If there are more parameters for which proactive cap detection would be possible, no predictions will be available for these and the Analytics log file will mention that the number of tracked parameters exceeded the maximum.

in addition, proactive cap detection is currently only supported for parameters for which there are explicitly specified value bounds. It will predict when a parameter will cross one of these bounds:

- A high and/or low data range value specified in the protocol, or,

- A (by default) critical alarm limit of type normal (i.e. not rate or baseline) specified in the alarm template, or,

- A data range indirectly derived from the protocol info. Currently this is limited to the values 0 and 100 for percentage data for which no historical values were encountered outside the \[0,100\] interval.

However, note that in case there is both a data range in the protocol and an alarm threshold in an alarm template, the alarm template will get precedence.

##### Configuration in DataMiner Cube

In DataMiner Cube, you can enable this feature in System Center, via *System settings* > *analytics config*. There you can also configure the lowest alarm threshold severity that will be taken into account for proactive cap detection. If this is for example set to *Major*, proactive cap detection will alert the operator whenever a parameter is predicted to go out of range or is predicted to trigger a major or critical alarm.

##### Suggestion events

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
>
> - When NATS is enabled on a DataMiner Agent, firewall rules will automatically be added for ports 4222, 6222, 8222 and 9090.
> - Automatic detection and triggering of NATS cluster self healing can be activated or deactivated by setting the \<NATSDisasterCheck> option to true of false in the MaintenanceSettings.xml file. Default setting: deactivated.
> - Only users who have been granted the *Admin tools* permission (Modules \> System configuration \> Tools) are allowed to reset the NATS service.

#### SLSNMPAgent will now also use the SNMP++ library to forward SNMPv2 traps and inform messages \[ID_27590\]

From now on, SLSNMPAgent will also use the SNMP++ library to forward SNMPv2 traps and inform messages. This means that it will now use the same library to send SNMPv1 traps, SNMPv2 traps and inform messages and SNMPv3 traps and inform messages.

> [!NOTE]
>
> - Because of limitations of the SNMP++ library, the inform message resend time cannot be set to a value less than 10ms. If you set it to a value less than 10ms, the default setting will be used instead (i.e. 30 ms).
> - From now on, all SNMPv2 traps and inform messages will by default include the “1.3.6.1.2.1.1.3.0” (sysUpTime) and “1.3.6.1.6.3.1.1.4.1.0” (snmpTrapOID) bindings.

### DMS Security

#### Jobs and ReservationInstances now have a SecurityViewID property to control access to them \[ID_24800\]

Jobs and ReservationInstances now have a SecurityViewID property.

If, for a particular job or ReservationInstance, this property contains a view ID, then the job or ReservationInstance will only be accessible to users who have access to the specified view.

- Users who display a list of jobs or ReservationInstances will only see the jobs or ReservationInstances associated with a view to which they have Read access.

- Users who try to create, update or delete a job or a ReservationInstance will only be able to do so if they have Write access to the view associated with that job or ReservationInstance.

> [!NOTE]
>
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

#### Serial clients can now parse data past the trailer of a response of which the length is defined in a parameter of type 'next param' \[ID_24442\]

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

```csharp
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

```csharp
NotifyDataMiner(128 /* NT_UPDATE_PORTS */,"10;[ELEMENT_ID];[MATRIX_PARAM_ID];[DMA_ID]","InputLeftOutputTop");
```

```csharp
NotifyDataMiner(128 /* NT_UPDATE_PORTS */,"10;[ELEMENT_ID];[MATRIX_PARAM_ID];[DMA_ID]","InputTopOutputLeft");
```

```csharp
NotifyDataMiner(128 /* NT_UPDATE_PORTS */,"10;[ELEMENT_ID];[MATRIX_PARAM_ID];[DMA_ID]",MatrixLayoutOptions.INPUT_LEFT_OUTPUT_TOP);
```

```csharp
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
>
> - If an uploaded DLL dependency would break existing QActions, no errors will be returned.
> - It is advised to strong-name DLL files when referring to multiple versions of the same file in different QActions. Not strong-naming DLL files could lead to unexpected behavior.

#### NT_SNMP_RAW_GET, NT_SNMP_RAW_SET, NT_SNMP_GET and NT_SNMP_SET requests now support the credential library \[ID_27275\]

The NT_SNMP_RAW_GET, NT_SNMP_RAW_SET, NT_SNMP_GET and NT_SNMP_SET requests now support the credential library.

- If you pass a GUID, you do not need to pass any credentials.

- If you do not pass a GUID or you pass an empty string instead of a GUID, you must pass credentials in plain text. When you pass neither a GUID nor plain-text credentials, the request will be considered invalid.

> [!NOTE]
>
> - Library credentials take precedence over plain-text credentials.
> - If you pass an invalid GUID (either a non-existing GUID or a GUID of an incorrect type), the request will be considered invalid. There will be no fall-back to plain-text credentials.

See the examples below.

- GET example:

  ```csharp
  // NotifyDataMiner NT_SNMP_RAW_GET
  object[] oTableElementInfo = new object[10];
  ...
  oTableElementInfo[9] = "665d680e-4097-455c-9ffc-0e4a06fa63c1";
  result = (object[])protocol.NotifyDataMiner(424 /*NT_SNMP_RAW_GET*/, oTableElementInfo, oRequestInfo);

  // NotifyProtocol NT_SNMP_GET
  object[] oTableElementInfo = new object[15];
  ...
  oTableElementInfo[14] = "665d680e-4097-455c-9ffc-0e4a06fa63c1";
  result = (object[])protocol.NotifyProtocol(295 /*NT_SNMP_GET*/, oTableElementInfo, oRequestInfo);
  ```

- SET example:

  ```csharp
  // NotifyDataMiner NT_SNMP_RAW_SET
  object[] oTableElementInfo = new object[8];
  ...
  oTableElementInfo[7] = "665d680e-4097-455c-9ffc-0e4a06fa63c1";
  result = (object[])protocol.NotifyDataMiner(425 /*NT_SNMP_RAW_SET*/, oTableElementInfo, oRequestInfo);

  // NotifyProtocol NT_SNMP_SET
  object[] oTableElementInfo = new object[12];
  ...
  oTableElementInfo[11] = "665d680e-4097-455c-9ffc-0e4a06fa63c1";
  result = (object[])protocol.NotifyProtocol(292 /*NT_SNMP_SET*/, oTableElementInfo, oRequestInfo);
  ```

#### A message body can now be added to raw HTTP requests \[ID_27438\]

In a QAction, it is now possible to add a message body to raw HTTP requests sent in a multi-threaded timer.

Old syntax:

```csharp
object[] httpRequestInfo = new object[3] { "http", new string[6] { sVerb, sURL, sUser, sPass, httpHeaders, "200" }, new string[1] { httpCommand } };
```

New syntax:

```csharp
object[] httpRequestInfo = new object[3] { "http", new string[6] { sVerb, sURL, sUser, sPass, httpHeaders, "200" }, new object[1] { new string[2] { httpCommand, dataToSend } } };
```

> [!NOTE]
>
> - The old syntax can still be used. If you use the old syntax, no message bodies will be sent. If you use the new syntax for a single resource, no message body needs to be added. In that case, you should define an empty string instead.
> - By adding the message bodies to the last array in the request, the new syntax allows you to send a different message body to each of the different subpages.
> - Using the new syntax, the last array can be an object array of string arrays of size 2:
>   - The first part of each string array is the subpage to which the request needs to be sent.
>   - The second part of each string array is the message body that needs to be sent to that specific subpage.
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

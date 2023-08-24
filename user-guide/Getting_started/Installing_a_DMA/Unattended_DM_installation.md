---
uid: Unattended_DM_installation
---

# Unattended DataMiner installation

The unattended installation process can be used to install a standalone DMA, but also to install a cluster, set up Failover, or even add a DMA to an existing cluster.

> [!NOTE]
> The 10.2.0 installer currently does not support unattended installation of a cluster.

To make sure the installation is executed correctly, a valid configuration file and license file must be included in the same folder as *Setup.exe*. See [Unattended installation configuration file](#unattended-installation-configuration-file).

> [!TIP]
> See also: [Obtaining a DataMiner license](xref:DataminerLicenses)

You can then start the unattended installation by running the following command:

```txt
[path to setup]/setup.exe unattended
```

Instead of *unattended*, you can also specify the option *u*, */u* or *-u*. All of these options have the same effect. During the installation, all the actions of the installer will be logged in the console.

> [!NOTE]
> If DataMiner is installed on several servers, the installation must be started at the same time on each of the servers.

Once the installation process has started, the installer will go through the following steps:

1. Automatic installation of any missing prerequisites:

   - VC++ redistributables if required
   - .NET Framework if required
   - Database software: MySQL or Cassandra, depending on the configuration

   > [!NOTE]
   >
   > - The installer requires that at least .Net Framework 4.5 is already installed. If this is not the case, you will not be able to run the installer.
   > - WinPcap can only be installed during an attended installation. For an unattended installation, make sure it is installed beforehand.

1. Installation of the DataMiner version provided in the installer.

1. DataMiner startup.

1. Configuration performed on all DMAs.

1. Installation application packages, if any.

1. Full synchronization of the DMS.

When the installation has finished, you can get the %errorlevel% to see if the installation succeeded. In the example below, the installation failed, resulting in error 650.

```txt
C:\Users>Administrator>C:\Users\Administrator\Desktop\Setup.exe unattended
C:\Users>Administrator>echo %errorlevel%
650
```

If something goes wrong during the configuration, e.g. the connection with one of the servers is lost or a DMA is not correctly configured, configuration changes will be reverted, and the installation process will install a standalone Agent. Information on the issue can be found in the log file. See [Unattended installation logging](#unattended-installation-logging).

## Unattended installation configuration file

The XML configuration is done in the *InstallConfiguration.xml* file. The settings specified in this file make it possible for the setup of the DMA in the DMS to be automatically taken care of.

The *InstallConfiguration.xml* file must use the syntax detailed below.

> [!NOTE]
> You can check the validity of an *InstallConfiguration.xml* file using the [InstallConfiguration Schema file](xref:InstallConfiguration_XSD).

### DMS tag

The main *DMS* tag has the following possible subtags:

- **DataMinerVersion**

  Optional. The version of DataMiner to use when installing. If this version cannot be found in *Setup.exe*, the version contained in *Setup.exe* will be used instead.

- **ClusterName**

  The name of the cluster.

  You can omit this tag when installing a standalone DMA or a single Failover system. In that case, the cluster name will by default be set to "DMS".

- **Timeout**

  The time (in minutes) to wait for communication between DMAs in order to set up a DMS. Once this time has lapsed, the installer will fall back to the installation of a standalone DMA. For most installations, a timeout value between 30 and 60 minutes should suffice. For large clusters, a higher timeout value may be needed.

- **DMA**

  For each separate DMA and for each Failover pair a DMA tag must be present. For more information, see [DMA tag](#dma-tag).

- **CentralDatabase**

  Optional. Indicates the central database type to use (*MySQL*, *MSSQL* or *Oracle*) using the *type* attribute. This tag must contain the following subtags, detailing the configuration for the *Db.xml* file: *DB*, *DBServer*, *ConnectString*, *UID* (user), *PWD* (password) and *Offload*. It is possible to leave some of these tags empty, in which case the default configuration will be applied. In addition, any other tags that can be configured in *Db.xml* can also be specified here, e.g. in the *Offload* tag.

- **Package**

  Optional. One tag per additional application package that should be installed for all DMAs in the DMS. The package can either be included in the same folder as *Setup.exe* or in a different folder.

  In a *Package* tag, you can specify the relative or UNC path to the package to be installed (including the package extension).

### DMA tag

The *DMA* tag has the following possible subtags:

- **ID**

  The ID of the DMA that is being installed.

- **MachineName**

  The NetBIOS name of the server where the DMA is installed (max. 15 characters).

- **IP1**

  The IP address of the server where the DMA is installed.

- **IP2**

  Optional additional IP address of the server where the DMA is installed.

- **Failover1**

  Required in case of a Failover setup. The IP address of the Failover DMA.

- **Failover2**

  Optional in case of a Failover setup. Additional IP address of the Failover DMA, in case IP2 is specified for the other DMA.

- **FailoverMachineName**

  Required in case of a Failover setup. The server name of the Failover DMA.

- **VirtualIP1**

  Required in case of a Failover setup. The virtual IP to be used by the Failover pair.

- **VirtualIP2**

  Optional in case of a Failover setup. Additional virtual IP address of the Failover DMA, in case IP2 is specified.

- **IPMask1**

  Required in case of a Failover setup. The subnet mask for the Failover configuration.

- **IPMask2**

  Optional in case of a Failover setup. Additional subnet mask for the Failover configuration, in case IP2 is specified.

- **Database**

  Indicates the database type to use (*Cassandra*, *CassandraCluster*, *MySQL* or *MSSQL*) using the *type* attribute. This tag must contain the following subtags, detailing the configuration for the *Db.xml* file: *DB*, *DBServer*, *DBDrive*, *ConnectString*, *UID* (user), *PWD* (password) and *Maintenance*. It is possible to leave some of these tags empty, in which case the default configuration will be applied. In addition, any other tags that can be configured in *Db.xml* can also be specified here, e.g. in the *Maintenance* tag.

  Note that for a non-Cassandra database, the drive specified in *DBDrive* must be C.

- **Location**

  Optional. Allows you to specify details about the location where the DMA is installed.

- **Package**

  Optional. One tag per additional package included in the *Setup.exe* that should be installed for this DMA only.

  In a *Package* tag, you can specify the relative or UNC path to the package to be installed (including the package extension).

- **CassandraClusterSettings**

  Used in case a database of type *CassandraCluster* is installed. See [CassandraClusterSettings tag](#cassandraclustersettings-tag).

- **ElasticClusterSettings**

  Used in case a database of type *CassandraCluster* is installed. See [ElasticClusterSettings tag](#elasticclustersettings-tag).

- **SearchDataBase**

  Used in case a database of type *CassandraCluster* is installed. This tag must contain the following subtags, detailing the configuration for the Elasticsearch database in the *Db.xml* file: *DBServer*, *UID* (user) and *PWD* (password).

> [!NOTE]
>
> - Make sure the correct subnet mask and IP are specified, as the installation will fail if these are incorrect, and this could also cause your Ethernet adapter settings to be changed to incorrect values.
> - You can only specify packages either in the *DMA* tag or in the *DMS* tag, not in both.
> - In case Cassandra had already been installed previously, and the cluster name is changed with the new installer, Cassandra will not be automatically reconfigured. This must be done manually.
> - Installing a Cassandra cluster is only possible if there is no existing Cassandra or Elasticsearch installation on the server.

### CassandraClusterSettings tag

The *CassandraClusterSettings* tag has the following possible subtags:

- **ListenAddress**

  The IP address that should be filled in for the *listen_address* setting in the *cassandra.yaml* file.

- **Seeds**

  The IP addresses of the different Cassandra nodes in the system, which will be filled in for the *seed_provider* setting in the *cassandra.yaml* file. It is recommended to configure at most 3 seed IP addresses per data center.

- **ClusterName**

  The name of the Cassandra cluster, which will be filled in for the *cluster_name* setting in the *cassandra.yaml* file. This must be the same for all DMAs.

- **ClusterSize**

  The size of the cluster. When installing Cassandra, the installer will wait until this number of nodes are online before it continues.

- **Port**

  The CQL native transport port, which will be filled in for the *native_transport_port* setting in the *cassandra.yaml* file.

- **SystemAuthReplicationFactor**

  The replication factor for the *system_auth* keyspace. This keyspace contains the data required to log in to Cassandra. The replication factor determines how many replicas will exist for each row of this keyspace.

  A general recommendation is to use a replication factor of 3 to 5, depending on the number of nodes. If the cluster has 3 nodes or less, we recommend setting the replication factor to the same number as the number of nodes.

- **DefaultKeyspaceReplicationFactor**

  The replication factor of the default keyspace.

- **RpcAddress**

  The IP address that Cassandra will use for client-based communication, such as through the CQL protocol.

  If this is left empty, it will not be defined in the *cassandra.yaml* file.

- **BroadCastRpcAddress**

  The address that Cassandra nodes will publish to connected clients.

  If most clients are outside the cluster's local network, this is typically the public address. Otherwise, it is typically the local network address.

  If this is left empty, it will not be defined in the *cassandra.yaml* file.

- **TargetInstallationDirectory**

  The location where Cassandra will be installed.

- **DataPath**

  The location where Cassandra data will be stored.

- **Snitch**

  The value that should be filled in for the *endpoint_snitch* setting in the *cassandra.yaml* file. The following values are supported: "SimpleSnitch", "GossipingPropertyFileSnitch", "PropertyFileSnitch", "Ec2Snitch", "Ec2MultiRegionSnitch", "RackInferringSnitch".

  Cassandra uses this setting to figure out the network topology, so that it can route requests efficiently and optimize the way data replicas are spread around the cluster. The recommended value is "GossipingPropertyFileSnitch". Other values are commonly used when the Cassandra nodes are hosted in the cloud.

- **IsResponsibleForConfiguration**

  Determines whether this DMA will be responsible for configuring the Cassandra cluster after it has been created. This includes creating the defined user as well as setting the *system auth* replication factor.

  This should only be set to true for 1 DMA. Possible values: true, false.

### ElasticClusterSettings tag

The *ElasticClusterSettings* tag has the following possible subtags:

- **DiscoveryHosts**

  The IP addresses of the other nodes in the cluster. Not all IP addresses are needed, but ideally, the master node IP addresses should be included.

- **NetworkHost**

  The IP address Elasticsearch should be bound to. This corresponds with the *NetworkHost* setting in the *elasticsearch.yaml* file.

- **NetworkPublishHost**

  The IP address Elasticsearch should publish to. If virtual IPs are configured, this should not be set to "0.0.0.0".

- **ClusterName**

  The name of the Elasticsearch cluster. This must be the same for all DMAs.

- **NodeName**

  The name of the Elasticsearch node.

- **MinimumMasterNodes**

  The minimum number of master nodes for the Elasticsearch cluster. Set this to 1 for a single node and to 2 for a cluster.

- **MasterNode**

  Determines whether this node is a master node. Possible values: true, false

- **DataNode**

  Determines whether this node is a data node. Possible values: true, false.

  Recommended value: true.

- **DataPath**

  The location where Elasticsearch data will be stored.

- **TargetInstallationDirectory**

  The location where Elasticsearch will be installed.

## Unattended installation configuration file examples

### Cluster with three DMAs including one Failover pair

The example below is used to create the following cluster:

- DMA SLC-H44-G01 with corresponding Failover DMA SLC-H44-G03
- DMA SLC-H44-G04
- DMA SLC-H44-G02 with corresponding Failover DMA SLC-H44-G05

```xml
<DMS>
  <ClusterName>InstallerCluster2_2</ClusterName>
  <!-- timeout in minutes -->
  <Timeout>30</Timeout>
  <DMA>
    <ID>663</ID>
    <MachineName>SLC-H44-G01</MachineName>
    <Location>Remote1</Location>
    <IP1>10.11.1.44</IP1>
    <IP2>
      10.11.1.45<IP2>
        <!-- IP of the backup agent (in case of Failover setup) -->
        <Failover1>10.11.3.44</Failover1>
        <Failover2>10.11.3.45</Failover2>
        <!-- Name of the backup agent (in case of Failover setup) -->
        <FailoverMachineName>SLC-H44-G03</FailoverMachineName>
        <!-- virtual IP (in case of Failover setup) -->
        <VirtualIP1>10.11.250.44</VirtualIP1>
        <VirtualIP2>10.11.250.45</VirtualIP2>
        <!-- IP mask (in case of Failover setup) -->
        <IPMask1>255.255.0.0</IPMask1>
        <IPMask2>255.255.0.0</IPMask2>
        <DataBase type="Cassandra">
          <DB>SLDMADB</DB>
          <DBServer>localhost</DBServer>
          <DBDrive>C</DBDrive>
          <ConnectString></ConnectString>
          <UID>root</UID>
          <PWD>root</PWD>
          <Maintenance>
            <!-- Any tag that also exists in the DB.xml for local DB -->
          </Maintenance>
        </DataBase>
      </DMA>
  <DMA>
    <ID>664</ID>
    <MachineName>SLC-H44-G04</MachineName>
    <Location>Remote2</Location>
    <IP>10.11.4.44</IP>
    <DataBase type="Cassandra">
      <DB>SLDMADB</DB>
      <DBServer>localhost</DBServer>
      <DBDrive>C</DBDrive>
      <ConnectString></ConnectString>
      <UID>root</UID>
      <PWD>root</PWD>
    </DataBase>
  </DMA>
  <DMA>
    <ID>665</ID>
    <MachineName>SLC-H44-G02</MachineName>
    <Location>Remote1</Location>
    <IP>10.11.2.44</IP>
    <Failover>10.11.5.44</Failover>
    <FailoverMachineName>SLC-H44-G05</FailoverMachineName>
    <VirtualIP>10.11.249.44</VirtualIP>
    <IPMask>255.255.0.0</IPMask>
    <DataBase type="MySQL">
      <DB>SLDMADB</DB>
      <DBServer>localhost</DBServer>
      <DBDrive>C</DBDrive>
      <ConnectString></ConnectString>
      <UID>root</UID>
      <PWD>root</PWD>
    </DataBase>
  </DMA>
  <CentralDataBase type="MySQL">
    <DB>SLDMSDB</DB>
    <DBServer>localhost</DBServer>
    <ConnectString></ConnectString>
    <UID>root</UID>
    <PWD>root</PWD>
    <Offload>
      <!-- Any tag that also exists in the DB.xml for remote DB -->
    </Offload>
  </CentralDataBase>
  <Package>MyPackage.dmapp</Package>
</DMS>
```

### Cluster with Cassandra cluster general database

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

## Unattended installation logging

During the installation, all actions and errors are reported in a log file, which can be found in the temporary folder *%Temp%\DataMinerInstallerLog*.

The following error codes can be returned after the installation:

| Internal name | Error code | Description |
| ------------- | ---------- | ----------- |
| ERROR_SUCCESS | 0 | Success |
| ERROR_CANCELLED | 10 | The user has canceled the installation. |
| ERROR_DATAMINERALREADYINSTALLED | 20 |  DataMiner was already installed. |
| ERROR_VERIFY | 100 | Something is wrong with the setup file, possibly a required package is not included. |
| ERROR_LICENSE | 200 | No license file present. |
| ERROR_CUSTOMIZE | 300 |  Something is wrong in the configuration XML file. Refer to the log file for more details. |
| ERROR_CUSTOMIZE_XMLMISSING | 310 | The XML file is missing. |
| ERROR_INSTALLING | 400 | Something went wrong during installation, but no more details are available. |
| ERROR_INSTALLING_DISKSPACE | 401 | Installation could not continue because there is not enough disk space. |
| ERROR_INSTALLING_COPYRESOURCE | 402 | Installation failed when copying a resource (e.g. VC++, .NET, or DataMiner package). |
| ERROR_INSTALLING_PREREQ | 410 |  Installation of a certain prerequisite failed (e.g. VC++ or .NET) |
| ERROR_INSTALLING_DATABASE | 420 |  Installation of the database failed (Cassandra or MySQL). |
| ERROR_INSTALLING_DATAMINER | 430 | Installation of DataMiner failed. Refer to the log file for more details. |
| ERROR_CONFIGURATION | 500 | Something went wrong during the DMS configuration, but no more details are available. |
| ERROR_CONFIGURATION_ONLINE | 510 | Not all Agents in the cluster went online. |
| ERROR_CONFIGURATION_CLUSTER |  520 | Failed to create the cluster. |
| ERROR_CONFIGURATION_FAILOVER | 530 | Failed to set up Failover. |
| ERROR_CONFIGURATION_READY | 540 | Not all Agents were configured correctly. |
| ERROR_APPLICATION_PACKAGES | 650 | Failed while installing an extra package. |

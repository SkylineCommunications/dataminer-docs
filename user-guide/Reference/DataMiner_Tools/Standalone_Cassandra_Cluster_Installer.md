---
uid: Standalone_Cassandra_Cluster_Installer
---

# Standalone Cassandra Cluster installer

> [!NOTE]
> This tool is intended for installation of a Cassandra Cluster on Windows only. However, we highly recommend that you install Cassandra on Linux instead.

## About this tool

This installer can be used to install Cassandra 3.11.8 on Windows. This version of Cassandra has been tested with the DataMiner Cassandra Cluster feature, which is available from DataMiner 10.0.13 onwards if the *CassandraCluster* [soft-launch option](xref:SoftLaunchOptions) is activated, or from DataMiner 10.1.2 onwards otherwise.

The installer includes AdoptOpenJDK 8 as well as DevCenter. It sets up a Cassandra service and creates a firewall rule named CassandraCluster to allow TCP traffic on ports 7000 and 9042.

> You can download this tool from [DataMiner Dojo](https://community.dataminer.services/download/standalone-cassandra-cluster-installer/).

## Requirements

- Microsoft Windows

- Server without existing Cassandra installation (i.e. there is no service called “Cassandra”)

  > [!IMPORTANT]
  > In case the cluster will consist of multiple Cassandra nodes, all nodes must use the same time. Set up NTP on the servers to avoid possible issues caused by a time difference between the nodes.

- [Microsoft Visual C++ 2010 10.0 Service Pack 1](https://support.microsoft.com/en-us/topic/description-of-visual-studio-2010-service-pack-1-1f12811e-3826-6728-9f40-b11ee9ae2a0e)

  The installers for this are also included with the Standalone Cassandra Cluster installer in the folder “Visual Studio 2010 (VC++ 10.0) SP1”.

## Configuration

Before you run the installer, you first need to create a configuration file.

To do so, first create a sample configuration by running the following command:

`./SLDataGateway.installers.Cassandra.Runner.exe run-stand-alone -g`

In this file, you can then configure the settings detailed in the [Configuration settings](#configuration-settings) section.

> [!NOTE]
> In case the cluster consists of only one node, you can instead start a one-click installation by executing `run_localhost_configuration.bat`.

### Configuration settings

#### InstallerDependenciesDirectory

This setting should be set to the path containing the installer dependencies. This is the folder that contains the following subfolders: *cassandra*, *devcenter*, *java* and *prunsrv*.

By default this should be `./cassandra_installer_dependencies`.

#### CassandraTargetDirectory

This is the location where Cassandra will be installed. In most cases this is *C:\Program Files\Cassandra*.

#### CqlNativeTransportPort

This is the port that is used by the installer to connect to Cassandra. The default value is 9042.

#### CreateSuperUser, SuperUserUsername and SuperUserPassword

The installer will try to connect to the cluster using the default Cassandra superuser. If this fails, it will also attempt to connect using the given SuperUserUsername/SuperUserPassword. This is done to verify that the installation succeeded.

If *CreateSuperUser* is set to *true*, then a superuser will be created using the given *SuperUserUsername* and *SuperUserPassword*.

#### PortsToOpen

The ports defined in this setting will be used to create a firewall rule named *CassandraCluster* to allow TCP traffic. If no ports are defined, no firewall rule will be created.

#### SystemAuthReplication

The replication factor for the *system_auth* keyspace. The *system_auth* keyspace contains the user credentials. This data needs to be available when a connection is made to the cluster.

A general recommendation is to use a replication factor of 3 to 5, depending on the number of nodes. If the cluster has 3 nodes or less, we recommend setting the replication factor to the same number as the number of nodes.

#### ListenAddress

Located under the `<CassandraYamlSettings>` tag. This will be used to set the *listen_address* *cassandra.yaml* setting and always needs to have a value filled in.

It is the IP address or hostname that Cassandra binds to for connecting to other Cassandra nodes. For more information, refer to the Datastax information on [the cassandra.yaml configuration file](https://docs.datastax.com/en/cassandra-oss/3.0/cassandra/configuration/configCassandra_yaml.html).

#### ClusterName

Located under the `<CassandraYamlSettings>` tag. This will be used to set the *cluster_name* *cassandra.yaml* setting and corresponds with the `<DB>` tag in DB.xml.

#### DiskOptimizationStrategy

Located under the `<CassandraYamlSettings>` tag. This will be used to set the *disk_optimization_strategy* *cassandra.yaml* setting. Possible values are *SSD* and *Spinning*. This determines the strategy for optimizing disk reads.

#### BroadCastRpcAddress

Located under the `<CassandraYamlSettings>` tag. This will be used to set the *broadcast_rpc_address* *cassandra.yaml* setting. This is the IP or hostname that will be broadcast to clients during cluster discovery.

#### RpcAddress

Located under the `<CassandraYamlSettings>` tag. This will be used to set the *rpc_address* *cassandra.yaml* setting. Cassandra will bind to this address and listen for client connections.

#### DataPath

Located under the `<CassandraYamlSettings>` tag. This will be used to set the *data_file_directories* *cassandra.yaml* setting. This is the location where Cassandra will store data on disk.

#### SeedIPs

Located under the `<CassandraYamlSettings>` tag. This will be used to set the *seed_provider* *cassandra.yaml* setting.

At least one seed IP must be filled in.

At all times, at least one of these nodes needs to be online, so that when a node comes online, it can join the cluster.

The general recommendation is to have up to 3 seed nodes.

#### Snitch

Located under the `<CassandraYamlSettings>` tag. This will be used to set the *endpoint_snitch* *cassandra.yaml* setting. Possible values are: *SimpleSnitch*, *GossipingPropertyFileSnitch*, *PropertyFileSnitch*, *Ec2Snitch*, *Ec2MultiRegionSnitch* and *RackInferringSnitch*.

The *GossipingPropertyFileSnitch* is the go-to snitch for production use. The snitch is used to figure out the network topology, which is then used to route requests efficiently and decide how replicas should be spread around the cluster.

## Running the installer

Run the installer as follows:

1. Run PowerShell as Administrator.

1. Set the current directory to the location of the installer. Example:

   `cd C:\CassandraInstaller\2021-08-06_cassandra_cluster_standalone_installer`

1. Run the installer. Example:

   `.\SLDataGateway.Installers.Cassandra.Runner.exe run-stand-alone -c ".\localhost_configuration.xml"`

In case you are setting up a cluster, the installer should first be run on each of the seed nodes. When you install a seed node, confirm that the installation has succeeded before you continue with the next seed node.

After the seed nodes are up and running, the installer can be run on the remaining nodes. In this case, the installers can be run in parallel.

## Logging

Information is logged to the console window as well as to file. File logging can be found in the *Logs* folder, located next to *SLDataGateway.Installers.Cassandra.Runner.exe*.

---
uid: Standalone_Elasticsearch_Cluster_Installer
---
# Standalone Elasticsearch Cluster Installer

## About this tool

The Standalone Elasticsearch Cluster Installer can be used to install Elasticsearch 6.8.23 on Windows. This version of Elasticsearch has been tested for use with DataMiner.

The installer includes AdoptOpenJDK 8 as well as Kibana. It sets up an Elasticsearch service and creates a firewall rule named Elasticsearch to allow TCP traffic on ports 9200 and 9300.

You can download this tool from [DataMiner Dojo](https://community.dataminer.services/download/standalone-elasticsearch-cluster-installer/).

## Requirements

- Microsoft Windows

- Server without existing Elasticsearch installation

- Every DataMiner Agent in the DataMiner System needs to be connected to the new Elasticsearch cluster

  > [!TIP]
  > See [Manually connecting a DMA to an Elasticsearch cluster](xref:Manually_Connecting_DMA_to_Elasticsearch_Cluster).

## Configuration

Before you run the installer, you first need to create a configuration file.

To do so, first create a sample configuration by running the following command:

```txt
./SLDataGateway.installers.Elastic.Runner.exe run-stand-alone -g
```

In this file, you can then configure the settings detailed below.

**NOTE**: In case the cluster consists of only one node, you can instead start a one-click installation by executing `run_localhost_configuration.bat`.

### Configuration settings

#### InstallerDependenciesDirectory

This setting should be set to the path containing the installer dependencies. This is the folder that contains the following subfolders: *elasticsearch*, *java*, and *kibana*.

#### Networkhost & NetworkPublishHost

This is an *elasticsearch.yml* setting that should be bound to the IP of the node. It is the IP address or hostname that Elasticsearch binds to for connecting to other Elasticsearch nodes. For more information, refer to the Elasticsearch information on [the network settings of the *elasticsearch.yml* configuration file](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/modules-network.html).

#### ClusterName

The name of the cluster. Will be placed in *elasticsearch.yml*.

#### DiscoveryHosts

This is an *elasticsearch.yml* setting that should reference the IPs of the other nodes. For more information, refer to the Elasticsearch information on [the discovery setting of the *elasticsearch.yml* configuration file](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/discovery-settings.html).

#### MasterNode

This is an *elasticsearch.yml* setting that indicates if the node is a master node. For more information, refer to the Elasticsearch information on [the master node setting of the *elasticsearch.yml* configuration file](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/modules-node.html#master-node).

#### MinimumMasterNodes

This is an *elasticsearch.yml* setting that determines how many master nodes are needed to start up. For more information, refer to the Elasticsearch information on [the minimum master nodes setting of the *elasticsearch.yml* configuration file](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/discovery-settings.html#minimum_master_nodes).

#### RepoPath

Optional. This setting (which corresponds with the Path.Repo Elasticsearch setting) allows you to define a snapshot path. For a cluster, this should be a shared file location. If this setting is not filled in, it will be commented out in the Elasticsearch configuration.

### Configuration example

```xml
<ElasticConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
   <ElasticYamlSettings>
      <ClusterName>DMS</ClusterName>
      <NodeName>DataMinerBestMiner</NodeName>
      <DataPath>C:\ProgramData\Elasticsearch</DataPath>
      <RepoPath>C:\ProgramData\RepoPath</RepoPath>
      <NetworkHost>0.0.0.0</NetworkHost>
      <NetworkPublishHost>0.0.0.0</NetworkPublishHost>
      <DiscoveryHosts>
         <string>"IP1"</string>
         <string>"IP2"</string>
      </DiscoveryHosts>
      <MinimumMasterNodes>1</MinimumMasterNodes>
      <MasterNode>true</MasterNode>
      <DataNode>true</DataNode>
   </ElasticYamlSettings>
   <InstallerDependenciesDirectory>unspecified</InstallerDependenciesDirectory>
   <ElasticTargetDirectory>C:\Program Files\Elasticsearch</ElasticTargetDirectory>
</ElasticConfiguration>
```

## Running the installer

You can run the installer as follows:

`./SLDataGateway.Installers.Elastic.Runner.exe run-stand-alone -c "<path to configuration file>"`

In case you are setting up a cluster, run the installers on the different nodes at approximately the same time. This is necessary because at some point the installers will need the input from the other installers in order to continue.

## After installation

After installation, Elasticsearch will by default only use 4 GB of heap space. In most cases, this will not be enough. Use one of the methods described below to increase the heap space.

### Using the Registry Editor

1. Go to `Computer\HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Apache Software Foundation\Procrun 2.0\elasticsearch-service-x64\Parameters\Java`

1. Open the *Options* key and locate the `-xmsZg` and `-xmxZg` settings. In both settings, change “Z” to the amount of heap space (in gigabytes) you want Elasticsearch to use (example: -xms16 and -xmx16g). Default: 1

1. Restart the Elasticsearch service.

### Using the Elasticsearch service manager

1. Open a command window and go to the Elasticsearch installation folder. Default: `C:\Program Files\Elasticsearch`.

1. Go to the bin folder, and run `elasticsearch-service.bat manager`.

1. In the service manager window, go to the *Java* tab, and locate the `-xmsZg` and `-xmxZg` settings. In both settings, change “Z” to the amount of heap space (in gigabytes) you want Elasticsearch to use (example: -xms16 and -xmx16g). Default: 1

1. Click *Apply* and then click *OK*.

1. Restart the Elasticsearch service.

> [!NOTE]
>
> - Make sure the `-xms` and `-xmx` settings always contain the same value. Do not use different values.
> - We recommend that you set the `-xms` and `-xmx` settings to a value smaller than 26 GB and always make sure that there is enough memory left for the operating system.
> - For more information, see [https://www.elastic.co/guide/en/elasticsearch/reference/6.8/heap-size.html](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/heap-size.html).

---
uid: Preparing_the_two_DataMiner_Agents
---

# Preparing the two DataMiner Agents

Before you start the actual configuration, make sure you have the following:

- A primary DMA

- A backup DMA (newly installed)

- A pair of additional IP addresses or a hostname

  > [!NOTE]
  > To avoid possible conflicts, make sure these IP addresses are not used anywhere else and that these are reserved for the Failover pair.

## Primary DataMiner Agent

The primary DMA is a normal DataMiner Agent. In most cases, this will be an existing DMA that is a member of a DMS Cluster. It does not require any additional configuration.

## Backup DataMiner Agent

The backup DMA must be a newly installed DataMiner Agent.

- The DataMiner ID of this DMA must be identical to the DataMiner ID of the primary DMA.

  For more information on how to change the DataMiner ID, see [Changing the DataMiner ID of a DMA](xref:Changing_the_DMA_ID).

- The version of the DataMiner software on the backup DMA must be exactly the same as on the primary DMA.

- The backup DMA may not be a member of a DMS cluster.

## Additional IP addresses or hostname

When Failover is configured, one or two additional IP addresses are needed, depending on the number of network interfaces of the DMAs. These will be used as the virtual IP addresses of the primary or the backup DMA, depending on which of the two is online. If the DMAs only have one network interface, only one additional IP address is needed.

Alternatively, from DataMiner 10.2.0/10.1.8 onwards, a shared hostname can be used instead of the virtual IP addresses. This hostname must be configured in the network, i.e. a corresponding DNS record must exist. The hostname must resolve to both primary IP addresses of the Failover Agents. For example, this could be the output of an nslookup of such a hostname:

```txt
Name: ResetPlease.FailoverZone
Addresses: 10.11.5.52
 10.11.4.52
```

> [!IMPORTANT]
>
> - If your system has been configured to use HTTPS, make sure that the virtual IP addresses or shared hostname also have **signed certificates**. For more information, see [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA).
>
>   As the setup of the certificates can be highly situational, for example in case proxies are involved, check with your IT services if you are not sure how to generate and deploy TLS/SSL certificates.
>
> - If a DMS already contains a DMA that was added based on its hostname or a Failover pair based on hostname, any Failover pairs you add to that DMS have to be configured based on hostname. Similarly, if a DMS already contains a Failover pair with virtual IP addresses, other Failover pairs in that same DMS also have to be configured with virtual IP addresses. This way you avoid mixing two different environments in one DMS. From DataMiner 10.2.0 [CU21]/10.3.0 [CU9]/10.3.12 onwards, such a mix of environments is not allowed.<!--RN 37075-->

## Opening the required ports

To ensure that both primary and backup dmas can communicate, assert that both agents have the required ports open as seen in [Configuring the IP network ports](xref:Configuring_the_IP_network_ports). Assert that packets coming from the "Virtual IP address" or the "shared hostname" to and from these ports are not dropped by the network.

## Preparing the database

Each [supported system data storage architecture](xref:Supported_System_Data_Storage_Architectures) has a different way of handling the setup of a failover system. Therefore it is important to based on the chosen architecture take the measures described below:

### Legacy setup with MySQL or MSSQL database

DataMiner will automatically synchronize the configuration and subsequently its data.
To check the data synchronization state after the failover setup, you can check [Synchronizing the DMA databases](xref:Synchronizing_the_DMA_databases)
Note that MySQL is considered legacy as mentioned in [Legacy setup with MySQL or MSSQL database](xref:Legacy_setup_with_MySQL_or_MSSQL_database)

### Separate Cassandra setup without indexing

DataMiner will automatically attempt to add Cassandra to a cluster of 2 Cassandra nodes, one for the primary dma and one for the backup dma.
Before attempting to set up a failover agent, assert that Cassandra is installed and running on both DataMiner agents, by opening *Windows Services* and checking whether the *cassandra* service exists and is running.
If this is the case, open an *elevated command window* and navigate to *C:\Program Files\Cassandra\bin*.
There, execute the command *nodetool version*. Assert that the output of this command is the same before continuing.
e.g. if the command returns **"ReleaseVersion: 3.7"** you may only continue to configure the failover if the other node also returns **"ReleaseVersion: 3.7"**. If one of the DMAs has a release version of **3.7**, but for the other agent the release version is **3.11** or higher, please follow the procedure to update the Cassandra node with version **3.7** on the page [Updating Cassandra](xref:Cassandra_updating) in the tab *On Windows*.
Finally, ensure that between the primary and backup DMA, port 7000 and port 9042 is open to allow the databases to communicate as mentioned in [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

### Separate Cassandra setup with indexing

We recommend against this setup for failover. With this setup it is possible that if one node goes down, all data in the indexing database is unavailable.

If you do go ahead with this, please keep the following into account:
The indexing database will automatically create a cluster of 2 nodes, one for the primary dma and one for the backup dma.
To ensure this can happen, assert that ports 9200 and 9300 are open between primary and backup dma to allow the databases to communicate as mentioned in [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

For the steps taken for Cassandra: see paragraph [Separate Cassandra setup without indexing](xref:Preparing_the_two_DataMiner_Agents#separate-cassandra-setup-without-indexing).

### Dedicated clustered storage

- Assert that the agents to be added can reach the Cassandra Cluster through ports 9042 or 9142 when using TLS.

- Assert that the agents to be added can reach the Elastic or OpenSearch cluster through port 9200.

- Assert that no elements/ alarms or other DataMiner functionalities are used on the backup dma to ensure that no conflicts happen when joining the dmas.

- Stop the backup dma, then copy the database configuration from the primary dma to the backup dma.
The database configuration can be found on the primary (existing) dma in *C:\Skyline DataMiner\db.xml*.
Copy the contents of the "DataBases" tag to the file *C:\Skyline DataMiner\db.xml* on the backup dma.
Now restart the backup dma.

- When using TLS, assert that the required certificates are imported and configurations done on the backup dma as well.
For Cassandra see [Encryption in Cassandra](xref:Security_Cassandra_TLS).
For the indexing databases see the following. For Opensearch see [Securing the Opensearch database](xref:Security_Opensearch), for Elasticsearch (deprecated) see [Securing the Elasticsearch database](xref:Security_Elasticsearch).

> [!IMPORTANT]
>
> When using multiple [Elasticsearch clusters](xref:Configuring_multiple_Elasticsearch_clusters) or [Opensearch clusters](xref:Configuring_multiple_OpenSearch_clusters) prior to DataMiner 10.4.0 and 10.4.2, there is an additional file that needs to be copied from the primary to the backup dma. This file is found in *C:\Skyline DataMiner\Databases\DBConfiguration.xml*. This also needs to be done while the backup agent is stopped.

> [!NOTE]
> When using multiple [Elasticsearch clusters](xref:Configuring_multiple_Elasticsearch_clusters) or [Opensearch clusters](xref:Configuring_multiple_OpenSearch_clusters) you may wish to choose the *priorityOrder* attribute differently on the main or backup DMA.
> This can be done if you wish to swap which indexing cluster will be read from when the dma switches.
> For more info on the *priorityOrder* attribute, see [Elasticsearch clusters](xref:Configuring_multiple_Elasticsearch_clusters) or [Opensearch clusters](xref:Configuring_multiple_OpenSearch_clusters).

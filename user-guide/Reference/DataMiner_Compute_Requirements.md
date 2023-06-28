---
uid: DataMiner_Compute_Requirements
---

# DataMiner Compute Requirements

To make sure your DataMiner System performs optimally, it is important that sufficient resources are available. The overview below shows the requirements for a DataMiner setup using the latest version of DataMiner, with Cassandra and Elasticsearch. Minimum requirements are displayed in gray, default requirements in light blue, and requirements for high-end applications in dark blue. Below this, you will find more detailed information on the requirements.

> [!TIP]
>
> - To estimate how many nodes your DMS will need and what the specifications of these nodes should be, you can use the [DataMiner Node Calculator](https://community.dataminer.services/calculator/)
> - For other information on requirements (e.g. client requirements), see [DataMiner System Requirements](https://community.dataminer.services/documentation/dataminer-system-requirements/).

> [!IMPORTANT]
> If you intend to run e.g. DataMiner, Cassandra, and Elasticsearch on a single server, the hardware requirements in the diagram below need to be added up. So, when it comes to RAM, in this case you would need a minimum of 96 GB (32 GB for DataMiner, 32 GB for Cassandra, and 32 GB for Elasticsearch).

![DataMiner setup](~/user-guide/images/dataminer-compute-requirements_V04_Outline.svg "DataMiner setup")

## DataMiner requirements

To make sure you have immediate access to all the data from your system and to ensure that actions you want to perform are done instantly, sufficient hardware resources must be available and the correct software must be used.

### RAM

A DataMiner System can need a lot of RAM depending on the size of your network. There is a significant difference between “regular” DataMiner Systems and systems where a lot of aggregation is needed.

As a rule, between 32 GB and 128 GB RAM is needed, although 128 GB is an exceptionally high value that mostly applies for EPM/CPE environments.

> [!NOTE]
> The data rate and latency are also important in the choice of RAM (e.g. DDR4-3200 with ECC).

### Disk

DataMiner itself, without taking the database for persistent storage into account, does not require a disk with huge capacity. However, we do recommend using an SSD as we regularly write to files. We recommend a 250 GB SSD, ideally a hot-swappable RAID1 pair.

In addition, the disk throughput is of vital importance. The following minimum requirements apply:

- 4 KiB blocks should be 10 MB/s or higher.

- 512 KiB blocks should be 300 MB/s or higher.

- The average latency should be lower than 10 ms.

### CPU

DataMiner is very demanding in concurrency, as a lot of actions usually happen in parallel. Though typically the performed actions are not lengthy or bulky, heavy actions can occur in EPM/CPE environments where a lot of aggregation is needed.

As a rule of thumb, a CPU passmark of >10K is OK, but >20K is needed in EPM/CPE environments. We recommend at least 8 cores, but 16 cores are preferable.

### Network

The network speed and latency are also an important factor in DataMiner performance. Pure inter-DataMiner communication mostly uses smaller messages, so a small latency is important. For read and write actions to the storage nodes, a decent throughput is recommended. The common gigabit networks will not be overloaded by a DataMiner System. We understand that keeping the latency low is not always possible towards remote sites. As such, having a higher latency is not problematic for synchronization of your cluster, but it could become an issue if a high number of values need to be transferred between remote nodes. Check with Skyline if this is the case for you.

As a rule, we recommend a throughput ranging from 100 Mbps to 1 Gbps and a latency ranging from < 50 ms to < 30 ms.

### Operating System

We recommend that you use the latest Windows Server version. This will not only allow you to make use of the latest features, but also ensures that you will get support and security patches for as long as possible. At the moment, Windows Server 2022 is the recommended version.

### Time

If there is more than one DataMiner Agent in your cluster, the time in the cluster must be synchronized (NTP).

### Microsoft .NET Framework

- Microsoft .NET Framework **4.6.2** is recommended for versions prior to DataMiner 10.1.11.

- From DataMiner **10.1.11** onwards, Microsoft .NET Framework **4.8** is required.

- From DataMiner **10.1.12** onwards, in addition to Microsoft .NET Framework 4.8, Microsoft .NET **5.0** is required.

- From DataMiner **10.3.0 [CU3]/10.3.3** onwards, in addition to Microsoft .NET Framework 4.8 and .NET 5.0, .NET **6.0** is also required.

> [!NOTE]
> We recommend always upgrading to the latest .NET Framework version.

### Computer name

DataMiner requires a server with a name that is **no longer than 15 characters**. Make sure the name does not contain any characters that are disallowed in NetBIOS computer names or DNS host names. For more information, refer to [learn.microsoft.com](https://learn.microsoft.com/en-us/troubleshoot/windows-server/identity/naming-conventions-for-computer-domain-site-ou#netbios-computer-names).

## Cassandra requirements

For DataMiner Agents that make use of one or more Cassandra nodes for their [system database](xref:Databases_about), additional requirements apply. For these, we follow Cassandra’s official [guidelines](https://docs.datastax.com/en/dseplanning/docs/capacityPlanning.html). A Cassandra node can be hosted on the same server as DataMiner, or on a different server. It is also possible to use multiple Cassandra nodes with one DataMiner Agent.

### Cassandra software

The minimum supported version for the Cassandra software is **3.11**. If a database per cluster (or "Cassandra Cluster") setup is used, 3.11 continues to be supported for existing setups, but for new setups Cassandra **4.x** is mandatory. If a database per Agent setup is used, Cassandra 4.x is also supported, and it is even recommended in case there are multiple nodes per database.

> [!NOTE]
>
> - Cassandra 4.x does not support Windows so you will need extra Linux servers to host the Cassandra database in order to use this version.
> - Currently, Cassandra versions 4.0 and 4.1 are supported in the 4.x range.

### RAM

While the amount of required RAM depends on the amount of hot data, the following conventions apply:

- ECC RAM should always be used, as Cassandra has few internal safeguards to protect bit-level corruption.

- The Cassandra heap requires 8 GB of memory, but on systems with a heavy load more may be necessary.

- As a rule, 32 GB RAM is enough, with maximum 8 GB assigned to the JVM.

### Disk

Ideally, a Cassandra server should have 2 disks. This is mandatory if you use HDD, and optional if you use SSD. This is because Cassandra has 2 write cycles, one for the commit log (which will be accessed for every write from the client application), and one for the sstables (the real storage of the data). As such, read and write speed will benefit from an SSD. There is no need to opt for RAID1, as replication should be handled by the cluster configuration.

In addition, the disk throughput is of vital importance. The following minimum requirements apply:

- 4 KiB blocks should be 10 MB/s or higher.

- 512 KiB blocks should be 300 MB/s or higher.

- The average latency should be lower than 10 ms.

### CPU

Like DataMiner, Cassandra requires high concurrency. It also needs significant CPU power for actions like compaction and repair, and the write speed is bound to the performance of the CPU.

We recommend 16 logical cores and a passmark of >10K.

### Network

A high-speed network is required to be able to transfer the data between the different nodes. The higher the replication factor, the more data needs to be transferred in the Cassandra cluster. Though there is no real minimum specification for network latency in a Cassandra cluster, it should be as low as possible.

### Operating System

We recommend installing Cassandra on Linux. In fact, from Cassandra 4.0 onwards, only Linux is supported. Older Cassandra versions also support Windows.

### Time

If there is more than one Cassandra node, the time in the cluster must be synchronized (NTP).

## Elasticsearch requirements

For certain DataMiner features, an additional indexing engine is required. This [Elasticsearch cluster](https://community.dataminer.services/expert-hub-elastic/) comes with additional requirements. For these, we follow Elastics’s official [guidelines](https://www.elastic.co/guide/en/elasticsearch/guide/current/hardware.html).

### RAM

At least 32 GB RAM is required; 64 GB is recommended. Going for 128 GB would be excessive, as heap sizing and swapping could become a problem.

### Disk

An SSD is recommended. If you do opt for HDD, 15K RPM is advised. There is no need to opt for RAID1, as replication should be handled by the cluster configuration.

In addition, the disk throughput is of vital importance. The following minimum requirements apply:

- 4 KiB blocks should be 10 MB/s or higher.

- 512 KiB blocks should be 300 MB/s or higher.

- The average latency should be lower than 10 ms.

### CPU

A passmark of >10K is sufficient for Elasticsearch. Having an extra logical core in favor of a few extra CPU cycles is preferred.

### Network

Gigabit Ethernet is required for throughput, and low latency is required for easy cluster communication. Latency between the different nodes in a cluster should be similar.

If there are multiple Elasticsearch nodes in the cluster, a [shared network path](xref:Configuring_Elasticsearch_backups_Windows) is required where the backups of the database can be stored.

### Operating System

Elasticsearch can be installed on the operating system of your choice, under the condition that it is supported by Elastic. A 64-bit OS is preferred.

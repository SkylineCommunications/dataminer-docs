---
uid: DataMiner_Compute_Requirements
keywords: system requirements, .NET requirements, dotnet requirements
description: For optimal performance, make sure DataMiner has sufficient RAM, vCPUs, etc. Unless STaaS is used, minimum requirements for data storage also apply.
---

# DataMiner Compute Requirements

> [!IMPORTANT]
> If you use [DataMiner as a Service (DaaS)](xref:Creating_a_DMS_in_the_cloud), your entire DataMiner setup is automatically configured for optimal performance.

To make sure your DataMiner System performs optimally, it is important that sufficient resources are available. The overview below shows the requirements for a DataMiner setup using the latest version of DataMiner, with self-managed Cassandra and OpenSearch databases. However, we **recommend using [Storage as a Service](xref:STaaS) instead**. If you use STaaS, only the requirements for DataMiner itself will be relevant for you.

Minimum requirements are displayed in gray, default requirements in light blue, and requirements for high-end applications in dark blue. Below this, you will find more detailed information on the requirements.

> [!TIP]
> For all information on client requirements, see [DataMiner Client Requirements](xref:DataMiner_Client_Requirements).

> [!NOTE]
> While this is not recommended, you can run DataMiner, Cassandra, and OpenSearch on a single server. In that case, the hardware requirements mentioned below need to be added up. For example, for RAM, you would need a minimum of 96 GB (32 GB for DataMiner, 32 GB for Cassandra, and 32 GB for OpenSearch).

## DataMiner requirements

To make sure you have immediate access to all the data from your system and to ensure that actions you want to perform are done instantly, sufficient hardware resources must be available and the correct software must be used.

![DataMiner setup](~/dataminer/images/dataminer-compute-requirements_V04_Outline.svg "DataMiner setup")

### RAM

A DataMiner System can need a lot of RAM depending on the size of your network. There is a significant difference between “regular” DataMiner Systems and systems where a lot of aggregation is needed.

As a rule, between 16 GB and 128 GB RAM is needed, although 128 GB is an exceptionally high value that mostly applies for EPM/CPE environments.

> [!NOTE]
> The data rate and latency are also important in the choice of RAM (e.g. DDR4-3200 with ECC).

### Disk

DataMiner itself, without taking the database for persistent storage into account, does not require a disk with huge capacity. However, we do recommend using an SSD as we regularly write to files. We recommend a 128 GB SSD, ideally a hot-swappable RAID1 pair.

In addition, the disk throughput is of vital importance. The following minimum requirements apply:

- 4 KiB blocks should be 10 MB/s or higher.

- 512 KiB blocks should be 300 MB/s or higher.

- The average latency should be lower than 10 ms.

### CPU

DataMiner is very demanding in concurrency, as a lot of actions usually happen in parallel. Though typically the performed actions are not lengthy or bulky, heavy actions can occur in EPM/CPE environments where a lot of aggregation is needed.

A minimum of 4 vCPUs is required (typically for up to 100 average elements). 8 vCPUs is recommended (typically for up to 250 average elements). In very demanding environments, such as EPM/CPE environments, 16 vCPUs is preferable.

### Network

The network speed and latency are also an important factor in DataMiner performance. Pure inter-DataMiner communication mostly uses smaller messages, so a small latency is important. For read and write actions to the storage nodes, a decent throughput is recommended. The common gigabit networks will not be overloaded by a DataMiner System. We understand that keeping the latency low is not always possible towards remote sites. As such, having a higher latency is not problematic for synchronization of your cluster, but it could become an issue if a high number of values need to be transferred between remote nodes. Check with Skyline if this is the case for you.

As a rule, we recommend a throughput ranging from 100 Mbps to 1 Gbps and a latency ranging from < 50 ms to < 30 ms.

### Operating System

For all supported DataMiner versions, we support all Windows versions that Microsoft currently supports. <!-- However, we recommend that you use the latest Windows Server version. This will not only allow you to make use of the latest features, but also ensures that you will get support and security patches for as long as possible.  -->At the moment, Windows Server 2025 is the recommended version.

### Time

If there is more than one DataMiner Agent in your cluster, the time in the cluster must be synchronized (NTP).

### Microsoft .NET

In the table below, you can find which .NET (Framework) versions are required for specific DataMiner versions.

| DataMiner version       | Required .NET (Framework) versions        |
|-------------------------|-------------------------------------------|
| DataMiner Feature Release 10.4.10 and higher<br>DataMiner Main Release 10.5.0 and higher<br>DataMiner Main Release 10.4.0 [CU7] and higher<br>DataMiner Main Release 10.3.0 [CU19] and higher<!--RN 38015, RN 38710, RN 40498--> | [Microsoft .NET Framework 4.8](https://go.microsoft.com/fwlink/?linkid=2088631) and .NET 8.0 (download the latest Hosting Bundle under ASP.NET Core Runtime from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)) |
| DataMiner Feature Release 10.4.3 to 10.4.9<!--RN 37969--><br>DataMiner Main Release 10.4.0 to 10.4.0 [CU6]<br>DataMiner Main Release 10.3.0 [CU12] to 10.3.0 [CU18] | [Microsoft .NET Framework 4.8](https://go.microsoft.com/fwlink/?linkid=2088631), [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-6.0.36-windows-hosting-bundle-installer) and .NET 8.0 (download the latest Hosting Bundle under ASP.NET Core Runtime from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)) |
| DataMiner Feature Release 10.3.9 to 10.4.2 | [Microsoft .NET Framework 4.8](https://go.microsoft.com/fwlink/?linkid=2088631) and [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-6.0.36-windows-hosting-bundle-installer) |
| DataMiner Feature Release 10.3.3 to 10.3.8<br>DataMiner Main Release 10.3.0 [CU3] to 10.3.0 [CU11] | [Microsoft .NET Framework 4.8](https://go.microsoft.com/fwlink/?linkid=2088631), [.NET 5.0](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-5.0.17-windows-hosting-bundle-installer), and [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-6.0.36-windows-hosting-bundle-installer) |
| DataMiner Feature Release 10.1.12 to 10.3.2<br>DataMiner Main Release 10.3.0 [CU2] | [Microsoft .NET Framework 4.8](https://go.microsoft.com/fwlink/?linkid=2088631) and [.NET 5.0](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-5.0.17-windows-hosting-bundle-installer) |
| DataMiner 10.1.11 | [Microsoft .NET Framework 4.8](https://go.microsoft.com/fwlink/?linkid=2088631) |
| DataMiner versions prior to 10.1.11 | Microsoft .NET Framework 4.6.2 |

> [!NOTE]
>
> - We recommend always upgrading to the latest .NET Framework version.
> - Major .NET versions are not cross-compatible, which means that you always need to install the appropriate version mentioned above. If you are for example using a DataMiner version that requires .NET 8.0, this will not work if only .NET 9.0 is installed, so in that case you will need to install .NET 8.0 as well.

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>Are you not sure which versions you have installed? Take a look at <a href="https://learn.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed" style="color: #657AB7;">Microsoft's guide</a> on this topic. You can also consult their <a href="https://learn.microsoft.com/en-us/dotnet/framework/install/" style="color: #657AB7;">.NET Framework installation guide</a>.
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

### Microsoft Visual C++

- From DataMiner versions 10.3.9, 10.3.0 [CU6], and 10.2.0 [CU18] onwards<!-- RN 36745 -->, only Microsoft Visual C++ **2015** or newer is required.

- Prior to DataMiner versions 10.3.9, 10.3.0 [CU6], and 10.2.0 [CU18], Microsoft Visual C++ **2010** and Microsoft Visual C++ **2015** or newer are required.

> [!NOTE]
>
> - If you want to **uninstall** Microsoft Visual C++ 2010, make sure to do so only **after upgrading** to 10.3.9, 10.3.0 [CU6], or 10.2.0 [CU18], as otherwise the upgrade will fail.
> - Microsoft Visual C++ versions 2015 up to 2022 are backwards-compatible, and only one version can be installed at the same time. For this reason, we recommend updating to the latest version of Microsoft Visual C++ 2022.

### Computer name

DataMiner requires a server with a name that is **no longer than 15 characters**. Make sure the name does not contain any characters that are disallowed in NetBIOS computer names or DNS host names. For more information, refer to [learn.microsoft.com](https://learn.microsoft.com/en-us/troubleshoot/windows-server/identity/naming-conventions-for-computer-domain-site-ou#netbios-computer-names).

## Standalone Cloud Gateway server requirements

If you want to [connect your system to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud) but would prefer to use a dedicated Cloud Gateway server for this, the server will need to meet the following requirements:

### Operating System

See "Operating system" under [DataMiner requirements](#dataminer-requirements).

### RAM

A minimum of 4 GB will be required to smoothly run the necessary services on the server.

### CPU

The processes are not CPU-heavy and do not require a lot of parallel computing. This means that 4 vCPUs should be enough.

### Network

See "Network" under [DataMiner requirements](#dataminer-requirements).

## Self-hosted storage

![self-hosted storage](~/dataminer/images/Self-hosted_Storage.svg)

### Cassandra requirements

For DataMiner Agents that make use of one or more Cassandra nodes for their [system database](xref:About_storage), additional requirements apply. For these, we follow Cassandra’s official [guidelines](https://docs.datastax.com/en/dseplanning/docs/capacityPlanning.html). A Cassandra node can be hosted on the same server as DataMiner, or on a different server. It is also possible to use multiple Cassandra nodes with one DataMiner Agent.

> [!IMPORTANT]
> Using a self-managed data storage architecture is not recommended. Instead, we recommend using [Storage as a Service (STaaS)](xref:STaaS), so that you will not need to maintain any Cassandra nodes.

#### Cassandra software

The minimum supported version for the Cassandra software is **3.11**. If a database per cluster (or "Cassandra Cluster") setup is used, 3.11 continues to be supported for existing setups, but for new setups Cassandra **4.x** is mandatory. If a database per Agent setup is used, Cassandra 4.x is also supported, and it is even recommended in case there are multiple nodes per database.

> [!NOTE]
>
> - Cassandra 4.x does not support Windows, so you will need extra Linux servers to host the Cassandra database in order to use this version.
> - Currently, Cassandra versions 4.0 and 4.1 are supported in the 4.x range.

#### RAM

While the amount of required RAM depends on the amount of hot data, the following conventions apply:

- ECC RAM should always be used, as Cassandra has few internal safeguards to protect bit-level corruption.

- The Cassandra heap requires 8 GB of memory, but on systems with a heavy load more may be necessary.

- As a rule, 32 GB RAM is enough, with maximum 8 GB assigned to the JVM.

#### Disk

Ideally, a Cassandra server should have 2 disks. This is mandatory if you use HDD, and optional if you use SSD. This is because Cassandra has 2 write cycles, one for the commit log (which will be accessed for every write from the client application), and one for the sstables (the real storage of the data). As such, read and write speed will benefit from an SSD. There is no need to opt for RAID1, as replication should be handled by the cluster configuration.

In addition, the disk throughput is of vital importance. The following minimum requirements apply:

- 4 KiB blocks should be 10 MB/s or higher.

- 512 KiB blocks should be 300 MB/s or higher.

- The average latency should be lower than 10 ms.

#### CPU

Like DataMiner, Cassandra requires high concurrency. It also needs significant CPU power for actions like compaction and repair, and the write speed is bound to the performance of the CPU.

We recommend 16 vCPUs.

#### Network

A high-speed network is required to be able to transfer the data between the different nodes. The higher the replication factor, the more data needs to be transferred in the Cassandra cluster. Though there is no real minimum specification for network latency in a Cassandra cluster, it should be as low as possible.

#### Operating System

We recommend installing Cassandra on Linux. In fact, from Cassandra 4.0 and DataMiner 10.4.x onwards, only Linux is supported.

#### Time

If there is more than one Cassandra node, the time in the cluster must be synchronized (NTP).

### OpenSearch/Elasticsearch requirements

Several DataMiner features are only available if your data storage setup includes an [indexing database](xref:Indexing_Database). Ideally, this should be an OpenSearch cluster. An Elasticsearch cluster can be used instead, but this is not recommended.

> [!IMPORTANT]
> Using a self-managed data storage architecture is not recommended. Instead, we recommend using [Storage as a Service (STaaS)](xref:STaaS), so that you will not need to maintain any openSearch or Elasticsearch nodes.

#### RAM

At least 32 GB RAM is required; 64 GB is recommended. Going for 128 GB would be excessive, as heap sizing and swapping could become a problem.

#### Disk

An SSD is recommended. If you do opt for HDD, 15K RPM is advised. There is no need to opt for RAID1, as replication should be handled by the cluster configuration.

In addition, the disk throughput is of vital importance. The following minimum requirements apply:

- 4 KiB blocks should be 10 MB/s or higher.

- 512 KiB blocks should be 300 MB/s or higher.

- The average latency should be lower than 10 ms.

#### CPU

We recommend 16 vCPUs.

#### Network

Gigabit Ethernet is required for throughput, and low latency is required for easy cluster communication. Latency between the different nodes in a cluster should be similar.

#### Operating System

We recommend installing OpenSearch on Linux. While OpenSearch is compatible with Windows (see [Operating system compatibility](https://opensearch.org/docs/2.2/install-and-configure/install-opensearch/index/#operating-system-compatibility)), this setup is not covered in our testing and therefore not recommended.

Elasticsearch can be installed on the operating system of your choice, under the condition that it is supported by Elastic. A 64-bit OS is preferred.

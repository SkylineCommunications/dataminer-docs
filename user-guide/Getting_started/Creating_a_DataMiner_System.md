---
uid: Creating_a_DataMiner_System
---

# Creating a DataMiner System

To create a DataMiner System (DMS), there are different possibilities:

- You can make use of **DataMiner as a Service (DaaS)**. This means that you [create your DMS in the cloud](xref:Creating_a_DMS_in_the_cloud) in just a few clicks, and it will be fully hosted and maintained by Skyline Communications.

- You can host the DataMiner nodes yourself. For **self-hosted DataMiner nodes**, you can either download a [Virtual Hard Disk (VHDX) with DataMiner pre-installed](xref:Using_a_pre_installed_DataMiner_VHDX) or manually [install the DataMiner Agents](xref:Installing_a_DataMiner_Agent). Afterwards you will need to set up your DataMiner System yourself. For the data storage for these nodes, two options are available:

  - You can make use of [Storage as a Service (STaaS)](xref:STaaS). You connect your DataMiner System to a scalable, easy-to-use, cloud-native storage platform hosted by Skyline.

  - You can host the storage nodes yourself. This means you will need to take care of [configuring and maintaining the databases](xref:Configuring_dedicated_clustered_storage).

> [!TIP]
> The [pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_VHDX) comes out-of-the box with a [locally hosted Cassandra Cluster and OpenSearch, running on Windows Subsystem for Linux (WSL)](xref:Local_database_on_WSL), allowing you to immediately get started.

> [!NOTE]
> Running an out-of-the box deployment with the [pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_VHDX) should only be used for test and staging environments when sufficient resources have been given to the Virtual Machine. Consider migrating to [Storage as a Service (STaaS)](xref:STaaS) or [configure dedicated clustered storage](xref:Configuring_dedicated_clustered_storage) if you intend to use it in production.

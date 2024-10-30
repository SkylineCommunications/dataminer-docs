---
uid: Creating_a_DataMiner_System
description: You can either create a DaaS system in the cloud, or install and set up a self-hosted DMS, using either STaaS or self-hosted storage nodes.
---

# Creating a DataMiner System

To create a DataMiner System (DMS), there are different possibilities:

- You can make use of **DataMiner as a Service (DaaS)**. This means that you [create your DMS in the cloud](xref:Creating_a_DMS_in_the_cloud) in just a few clicks, and it will be fully hosted and maintained by Skyline Communications.

- You can host the DataMiner nodes yourself. For **self-hosted DataMiner nodes**, you can either download a [virtual hard disk with DataMiner pre-installed](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk) or manually [install the DataMiner Agents](xref:Installing_a_DataMiner_Agent).

  For the data storage for these nodes, different options are available:

  - You can make use of [Storage as a Service (STaaS)](xref:STaaS). You connect your DataMiner System to a scalable, easy-to-use, cloud-native storage platform hosted by Skyline.

  - You can host the storage nodes yourself. This means you will need to take care of [configuring and maintaining the databases](xref:Configuring_dedicated_clustered_storage).

  - If you install DataMiner by [downloading the pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk), for testing or staging setups, you can host Cassandra and OpenSearch locally on Windows Subsystem for Linux (WSL). While this is very easy to set up and allows you to get started immediately, it should never be used for production systems. However, if you later decide to use such a system in production, you can switch the existing DataMiner System to one of the two setups above instead.

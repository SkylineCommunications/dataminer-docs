---
uid: Deploying_a_DataMiner_System
description: You can either create a DaaS system or install and set up a self-managed DMS using either STaaS or self-managed storage.
---

# Deploying a DataMiner System

If you want to deploy a DataMiner System, you can choose between different approaches:

- **Create your DMS in the cloud**: Deploy a system using DataMiner as a Service (DaaS) [in just a few clicks](xref:Creating_a_DMS_on_dataminer_services). Your system will be fully hosted and maintained by Skyline Communications.

- **Install DataMiner** on premises, in a private cloud, or in a hybrid setup. With this approach, you **host and manage the DataMiner nodes yourself**.

  There are two ways you can do this:

  - The easiest way is to [install the DataMiner Agents using the DataMiner Installer](xref:Installing_DM_using_the_DM_installer).

  - If you are familiar with virtualization, you can instead download and deploy [virtual hard disk with DataMiner pre-installed](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk).

  When you install such a self-managed system, you will be able to choose between different options for the data storage of your system:

  - The easiest option is **[Storage as a Service (STaaS)](xref:STaaS)**. If you choose this, you will connect your DataMiner System to a scalable, easy-to-use, cloud-native storage platform hosted by Skyline.

  - Alternatively, you can host and **manage the storage yourself**. This means you will need to take care of [configuring and maintaining the databases](xref:Configuring_dedicated_clustered_storage).

  - If you want to **create a small scale setup**, you can install DataMiner by [deploying the pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk) and choose to deploy the storage databases (Cassandra and OpenSearch) locally on Windows Subsystem for Linux (WSL). However, while this is easy to set up and allows you to get started immediately, it should only be used for single-Agent environments. These setups can be used for development or for minimal deployments where STaaS is not an option, and this will also require additional resources on the local machine.

> [!TIP]
> For more information about these different approaches, refer to [DataMiner hosting and high availability](xref:Overview_hosting).

> [!NOTE]
> By default, a DataMiner System is deployed with a **Community Edition license**. For information on pricing and limitations for this license, see [DataMiner Community Edition](xref:Pricing_Commercial_Models#dataminer-community-edition).

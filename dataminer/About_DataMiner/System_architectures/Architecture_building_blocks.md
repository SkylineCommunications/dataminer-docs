---
uid: Architecture_building_blocks
description: Learn about the building blocks of every DataMiner System architecture, including Agents, storage, redundancy features, and remote connectivity.
keywords: architecture, building blocks, DMA, DMS, storage, Swarming, replication, DataMiner Edge
---

# Building blocks of a DataMiner System

Every DataMiner architecture is built from the same set of building blocks. Understanding these makes it easier to choose a [system topology](xref:Architecture_overview) and then select the hosting, storage, and operational arrangements that support it.

## DataMiner Agents and DataMiner Systems

A **DataMiner Agent (DMA)**, also called a DataMiner node, is a server running the DataMiner software. It hosts elements, which communicate with the devices, applications, and services you manage, and it runs functionality such as alarm handling, trending, automation, and the web applications.

A **DataMiner System (DMS)**, also called a DataMiner cluster, is a collection of DMAs that work together as one system. Users see a DMS as a single entity, no matter how many DMAs it contains or where they are located. See [About DataMiner clusters](xref:About_DataMiner_Systems).

DataMiner nodes can be deployed in two ways:

- **DataMiner as a Service (DaaS)**: Skyline hosts and maintains the nodes in the cloud. You do not need to manage servers, operating systems, or virtual machines. See [DataMiner as a Service](xref:DaaS_hosting).

- **Self-managed DMS**: You host your system yourself, using physical servers or virtual machines, on premises, in a private cloud, or in a public cloud. Its compute nodes run on Windows Server. See [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

You can also [combine both types of nodes in one cluster](xref:Hybrid_clusters) when full DMAs are needed in both environments. A cloud-hosted DMS can monitor private equipment via a VPN or DataMiner Edge without a self-managed DMA. See [Hosting and storage](xref:Architecture_hosting_and_storage) and [Hybrid deployments and temporary capacity](xref:Architecture_hybrid_cluster).

## Storage

Each DMS needs its own system data storage. This storage holds configuration data, trend data, alarms, and other data used by the system. There are two main options:

- **Storage as a Service (STaaS)**: A cloud-native storage platform managed by Skyline. Skyline takes care of scaling, patching, redundancy, and backups. Data is stored in a region of your choice, with zone-redundant storage (ZRS) by default and geo-redundant storage (GRS) as an option. Daily backups are kept for 30 days. Each DMS has its own isolated logical partition. STaaS is the storage option recommended by Skyline and is always used for DaaS systems. See [Storage as a Service (STaaS)](xref:STaaS) and [STaaS features](xref:STaaS_features).

- **Dedicated clustered storage (self-managed)**: You install and maintain a [Cassandra cluster](xref:Cassandra_database) and an [OpenSearch cluster](xref:Indexing_Database) for the DMS yourself, on dedicated Linux machines. This option is supported, but it requires database administration expertise. See [Dedicated clustered storage](xref:Dedicated_clustered_storage).

For the smallest compute topology, see [One-box system](xref:Architecture_single_agent). It covers a DaaS or self-managed DMS with STaaS, and local Linux databases on WSL for limited non-production use.

Older setups with a separate database per DMA, or with a MySQL or Microsoft SQL Server database, are deprecated or legacy. If you still use one of these, plan a migration to one of the options above. See [Storage options overview](xref:Supported_system_data_storage_architectures).

The table below compares the two main storage options:

| Aspect | Storage as a Service | Dedicated clustered storage |
|--|--|--|
| Installation and maintenance | Managed by Skyline | Your responsibility, including upgrades, compaction, repairs, and monitoring |
| Redundancy | ZRS by default, optionally GRS | Depends on your design: at least 3 OpenSearch nodes (uneven number) and multiple Cassandra nodes |
| Backups | Daily, retained for 30 days | You need to configure and test database backups yourself |
| Scaling | Automatic | Add nodes and resources yourself |
| Connectivity | Outbound HTTPS from every DMA, directly or via a proxy | Low-latency connectivity between every DMA and all database nodes |
| Air-gapped networks | Not possible | Possible |
| Hybrid clusters (DaaS and self-managed nodes) | Supported | Not supported |

> [!NOTE]
> In addition to the system data storage, you can configure optional storage, such as an [offload database](xref:Offload_database), to make data available to third-party systems.

## Redundancy features

DataMiner offers several features that you can combine to make a system resilient. Keep in mind that **the system is only as redundant as its weakest component**: redundant DataMiner nodes still depend on the availability of the storage, the network, and the managed devices.

### Swarming

With [Swarming](xref:Swarming), elements and other objects are no longer bound to a specific DMA. Their configuration is stored in the database, so you can move them between DMAs in the same cluster. Combined with [Node Recovery](xref:NodeRecovery_About), you can automate the redistribution of elements when a node fails.

This lets you distribute supported workloads across active nodes and relocate them for maintenance or load balancing. The remaining nodes need enough capacity and device reachability to absorb relocated workloads. Not all object types can be swarmed. Global outage detection in Node Recovery requires at least three nodes and an elected leader; local detection can be used with two nodes but requires care to avoid conflicting actions during a network split. See [Enabling Swarming](xref:EnableSwarming) and [Node Recovery detection](xref:NodeRecovery_Detection) before choosing the recovery model.

Use Swarming for the new architectures described in this section. Validate supported object types, connectivity, and recovery capacity before enabling it.

### Storage redundancy

With STaaS, storage redundancy is provided by the platform (ZRS or GRS). With dedicated clustered storage, you achieve redundancy by running multiple Cassandra nodes with an appropriate replication factor and an OpenSearch cluster with at least three nodes. See [Dedicated clustered storage](xref:Dedicated_clustered_storage).

### Surviving the loss of a site

To keep a system running when a complete site is lost, both the DataMiner nodes and the storage must be redundant across sites. Redundant storage on its own is not enough:

- **Storage**: Choose STaaS redundancy or self-managed replication against the storage failures and recovery targets you need. STaaS GRS provides an additional copy in a second region; a self-managed geo-redundant arrangement uses database replicas at two sites and an OpenSearch tie-breaker at a third location. See [Geo-redundant system](xref:Architecture_geo_redundant).
- **Compute**: The DMS must have nodes at the remaining site that can take over supported workloads through Swarming, with enough spare capacity and the required recovery configuration.
- **Network and devices**: The remaining site must still be able to reach the managed devices and the storage, and users must be able to reach the remaining nodes.

### Redundancy on element level

Some types of redundancy are handled inside DataMiner itself rather than on infrastructure level, for example [redundancy groups](xref:About_redundancy_groups) that switch between primary and backup devices. These are independent of the system architecture, but they are often part of the overall resilience design.

## Connecting multiple sites and systems

### One cluster across sites

A single DMS can contain DMAs at different locations. This gives you one system with centralized management, but it requires reliable connectivity between the DMAs and between the DMAs and the storage. See [Architecture design considerations](xref:Architecture_design_considerations#network).

### Hybrid clusters

A [hybrid cluster](xref:Hybrid_clusters) combines DaaS nodes and self-managed nodes in one DMS, connected via a site-to-site VPN. STaaS is mandatory for every node in a hybrid cluster. Consider it for a specific full-node requirement, migration, or temporary capacity rather than simply for mixed public and private data sources. See [Hybrid deployments and temporary capacity](xref:Architecture_hybrid_cluster).

### DataMiner Edge

[DataMiner Edge](xref:DataMiner_Edge) brings data from remote or on-premises locations to a central DataMiner System, for example on DaaS, without the need for a site-to-site VPN:

- An [Edge Gateway](xref:About_Edge_Gateways) provides a secure tunnel so that integrations running centrally can reach remote data sources.
- An [Edge Node](xref:About_Edge_Nodes) runs compatible Python-based integrations close to the data. It buffers collected data on disk during interruptions and synchronizes it after reconnection. It is not an independent full DMS. This mode is currently available in preview.

### Element replication between systems

With [element replication](xref:Replicated_elements), an element managed by one DMS can be shown in another DMS. This is useful when you deliberately keep separate systems but still want a central view of selected elements. Note that the source and destination DMA must run the same DataMiner version.

### dataminer.services

When a DMS is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud), you gain access to [Catalog deployments](xref:About_the_Catalog_app), [Remote Access](xref:About_Remote_Access), [dashboard sharing](xref:Sharing_a_dashboard), and managed services. [Proactive Support](xref:Proactive_Support) adds remote assistance and diagnostic collection, while [CDMR](xref:CDMR) enables proactive system-health monitoring when its prerequisites are met. These benefits also apply to connected self-managed systems. DaaS systems are connected by default. See [Benefits of connecting to dataminer.services](xref:Architecture_hosting_and_storage#benefits-of-connecting-to-dataminerservices).

## Environments

Production, staging, development, and evaluation describe an environment's purpose, not a separate topology. Apply the topology and operational choices needed for each purpose. See [Lab, staging, and proof-of-concept environments](xref:Architecture_lab_and_staging).

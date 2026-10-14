---
uid: Architecture_hosting_and_storage
description: Choose DaaS or self-managed DataMiner compute and STaaS or self-managed databases independently of your system topology and environment.
keywords: architecture, hosting, storage, DaaS, STaaS, on premises, Cassandra, OpenSearch
---

# Hosting and storage

Hosting determines where compute runs and who operates it. Storage determines where system data is kept and who maintains the database platform. Neither defines the system topology: centralized, distributed, geo-redundant, and independent systems can all use on-premises infrastructure where their technical requirements permit.

## Cloud-hosted compute with DaaS

With [DataMiner as a Service](xref:DaaS_hosting), Skyline hosts and maintains the compute infrastructure, and STaaS provides system data storage. This suits an operation that wants to avoid managing servers, operating systems, or database clusters, whether the monitored data sources are public or private.

Private data sources can be reached through a site-to-site VPN or [DataMiner Edge](xref:DataMiner_Edge). An Edge Gateway gives centrally running integrations access to remote equipment. An Edge Node runs integrations close to the equipment and forwards data to the DMS. Select the option according to integration support, local access, and connectivity requirements; private equipment alone is not a reason to deploy a full local DMA.

Choose a compute region close to users and data sources. Multi-region DaaS arrangements are available as custom setups; see [Regional support for DaaS](xref:DaaS_hosting#regional-support-for-daas). Storage has its own region choice and optional geo-redundant pair. Redundant compute and storage still need a connectivity design that lets the remaining nodes reach managed equipment.

You remain responsible for DataMiner configuration, such as elements, dashboards, and Automation scripts, and for planning DataMiner upgrades and configuration backups. Internet connectivity is required, so this is not an air-gapped deployment option.

## Self-managed compute with STaaS

You can host DataMiner nodes on premises, in a private cloud, or in a public cloud while Skyline operates the storage. This is a deployment variation of your chosen topology, not a separate architecture.

It is useful where you want to reuse an existing server platform, control compute operations, or place a full DMA near equipment. You maintain Windows, virtualization or hardware, and the DataMiner installation, while STaaS removes the need to operate Cassandra and OpenSearch servers.

Every DMA needs outbound HTTPS access to STaaS, directly or through a supported proxy. Critical sites need appropriate internet, firewall, and proxy redundancy. DMZ setups are currently not supported with STaaS. See [Setting up STaaS](xref:Setting_up_StaaS).

## Self-managed compute and databases

Self-managed storage is useful when the DMS must run without internet access or when data location policies rule out STaaS. It can support a centralized cluster, a distributed system with suitable links, or a geo-redundant design. Isolation and topology remain separate decisions: an air-gapped system may still contain many nodes and sites.

Skyline recommends STaaS for system data storage. [Dedicated clustered storage](xref:Dedicated_clustered_storage) is supported, but requires you to install, size, monitor, patch, and back up Cassandra and OpenSearch, normally on dedicated Linux machines. Plan for database repairs, disk usage, supported versions, and capacity growth.

For a fully hardware-redundant Failover deployment, the documented minimum is two DataMiner machines, three Cassandra machines, and three OpenSearch machines. This is a storage-and-redundancy example, not a requirement for every topology. Size additional resources for the actual workload. For limited non-production use with local WSL databases, see [Single-agent system](xref:Architecture_single_agent).

In an air-gapped network, plan how software and connector updates enter the environment. Functions that rely on dataminer.services are not available without the required connectivity.

## Redundancy and backups

STaaS provides zone-redundant storage by default and optional geo-redundant storage. Daily backups are retained for 30 days. See [STaaS features](xref:STaaS_features). These features protect storage, not the availability of a single DMA.

With self-managed storage, choose replication and placement according to the failures you must withstand. OpenSearch requires an uneven number of nodes, at least three for redundancy. Follow the [dedicated storage guidance](xref:Dedicated_clustered_storage) for Cassandra sizing and geo-redundant arrangements.

Configure [DataMiner backups](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube) outside the node. With self-managed databases, also configure native database snapshots and test restores. Schedule configuration and database backups close together so recovery points align. Virtual machine snapshots alone do not guarantee a consistent distributed database backup.

## Sizing and cost

Use the [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements) for self-managed compute and storage, and the [node calculator](https://community.dataminer.services/calculator/) for Cassandra sizing. For services, see the [DaaS sizing guide](xref:Pricing_sizing_guide_services_DaaS) and [STaaS sizing guide](xref:Pricing_sizing_guide_services_StaaS). An existing system can provide input through [STaaS cost estimation](xref:STaaS_cost_estimation).

Prepare device types and counts, polling rates, parameter and table volumes, trending retention, alarm rates, user load, and any solution-specific processing requirements. These give a more useful estimate than a device count alone.

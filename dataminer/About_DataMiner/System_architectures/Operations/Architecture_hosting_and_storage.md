---
uid: Architecture_hosting_and_storage
description: Choose DaaS or self-managed DataMiner compute and STaaS or self-managed databases independently of your system topology and environment.
keywords: architecture, hosting, storage, DaaS, STaaS, on premises, Cassandra, OpenSearch
---

# Hosting and storage

Hosting determines where compute runs and who operates it. Storage determines where system data is kept and who maintains the database platform. Neither defines the system topology: centralized, distributed, geo-redundant, and independent systems can all use on-premises infrastructure where their technical requirements permit.

## Cloud-hosted compute with DaaS

With [DataMiner as a Service](xref:DaaS_hosting), you can create a cloud-hosted DMS in minutes and start connecting data sources without procuring servers or setting up database clusters. Skyline hosts and maintains the platform, while STaaS provides scalable system data storage. This lets you focus on getting your operation up and running, whether the monitored data sources are public or private.

Private data sources can be reached through a site-to-site VPN or [DataMiner Edge](xref:DataMiner_Edge). An Edge Gateway gives centrally running integrations access to remote equipment. An Edge Node runs integrations close to the equipment and forwards data to the DMS. Select the option according to integration support, local access, and connectivity requirements; private equipment alone is not a reason to deploy a full local DMS. For connectivity options and VPN setup, see [Connecting to private data sources with DaaS](xref:Connecting_to_private_data_sources).

You can combine VPN and Edge connectivity in the same deployment when different sites or integrations need different access methods. The topology diagrams deliberately illustrate one remote-access approach at a time for visual clarity, not because mixed connectivity is unsupported. Likewise, each diagram shows one storage choice: STaaS or self-managed databases, not both for the same DMS.

Choose a compute region close to users and data sources. Multi-region DaaS arrangements are available as custom setups; see [Regional support for DaaS](xref:DaaS_hosting#regional-support-for-daas). Storage has its own region choice and optional geo-redundant pair. Redundant compute and storage still need a connectivity design that lets the remaining nodes reach managed equipment.

Skyline manages DaaS backups and platform maintenance. See the [DaaS backup policy](xref:Creating_a_DaaS_system_FAQ#what-backup-policy-does-a-daas-system-have) and [DaaS Planned Maintenance Policy](xref:DaaS_Planned_Maintenance_Policy). Your DMS is connected to dataminer.services from the start, giving you access to Catalog deployments, collaboration features, and proactive support. Internet connectivity is required, so this is not an air-gapped deployment option.

## Self-managed compute with STaaS

You can host your DMS on premises, in a private cloud, or in a public cloud while Skyline operates the storage. This is a deployment variation of your chosen topology, not a separate architecture. A DMS remains a complete system even when it contains only one Agent.

It is useful where you want to reuse an existing server platform, control compute operations, or run the DMS close to equipment. You maintain Windows, virtualization or hardware, and the DataMiner installation, while STaaS removes the need to operate Cassandra and OpenSearch servers.

The DMS needs outbound HTTPS access to STaaS from each of its nodes, directly or through a supported proxy, which can be placed in a DMZ. Critical sites need appropriate internet, firewall, and proxy redundancy. See [Setting up STaaS](xref:Setting_up_StaaS).

## Self-managed compute and databases

Self-managed storage is useful when the DMS must run without internet access or when data location policies rule out STaaS. It can support a centralized cluster, a distributed system with suitable links, or a geo-redundant design. Isolation and topology remain separate decisions: an air-gapped system may still contain many nodes and sites.

Skyline recommends STaaS for system data storage. [Dedicated clustered storage](xref:Dedicated_clustered_storage) is supported, but requires you to install, size, monitor, patch, and back up Cassandra and OpenSearch on dedicated Linux machines. Deploy both database platforms on Linux for best performance. Plan for database repairs, disk usage, supported versions, and capacity growth.

Use Swarming for compute redundancy and design database replication and placement separately. Size recovery capacity for the actual workload and follow the storage platform's redundancy requirements. For limited non-production use with local WSL databases, see [One-box system](xref:Architecture_single_agent).

In an air-gapped network, plan how software and connector updates enter the environment. Functions that rely on dataminer.services are not available without the required connectivity.

## Benefits of connecting to dataminer.services

A self-managed DMS can also benefit from [connecting to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud), independently of whether you use self-managed databases or STaaS. DaaS systems are connected by default.

- **Features and collaboration**: Use the [Catalog](xref:About_the_Catalog_app) to deploy solutions and versioned packages, [Remote Access](xref:About_Remote_Access) to reach your system, and [dashboard sharing](xref:Sharing_a_dashboard) to collaborate with stakeholders.
- **Faster support**: [Proactive Support](xref:Proactive_Support) enables collection of logs and crash dumps and remote assistance by Skyline Operations, subject to the documented security and access conditions.
- **Proactive health monitoring**: [Customer DataMiner Reporting (CDMR)](xref:CDMR) supplies system health information to Skyline so issues can be identified proactively, with the required prerequisites in place.

See the [dataminer.services overview](xref:Overview_dataminer_services) for the available services and [cloud connectivity and security](xref:Cloud_connectivity_and_security) for the security model.

## Redundancy and backups

STaaS provides zone-redundant storage by default and optional geo-redundant storage. Daily backups are retained for 30 days. See [STaaS features](xref:STaaS_features). These features protect storage, not the availability of a single DMA.

With self-managed storage, choose replication and placement according to the failures you must withstand. OpenSearch requires an uneven number of nodes, at least three for redundancy. Follow the [dedicated storage guidance](xref:Dedicated_clustered_storage) for Cassandra sizing and geo-redundant arrangements.

For DaaS, Skyline manages system backups according to the [DaaS backup policy](xref:Creating_a_DaaS_system_FAQ#what-backup-policy-does-a-daas-system-have). For a self-managed DMS, configure [DataMiner backups](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube) outside the compute hosts. With self-managed databases, also configure native database snapshots and test restores. Schedule configuration and database backups close together so recovery points align. Virtual machine snapshots alone do not guarantee a consistent distributed database backup.

## Sizing and cost

Use the [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements) for self-managed compute and storage. For services, see the [DaaS sizing guide](xref:Pricing_sizing_guide_services_DaaS) and [STaaS sizing guide](xref:Pricing_sizing_guide_services_StaaS). An existing system can provide input through [STaaS cost estimation](xref:STaaS_cost_estimation).

Prepare device types and counts, polling rates, parameter and table volumes, trending retention, alarm rates, user load, and any solution-specific processing requirements. These give a more useful estimate than a device count alone.

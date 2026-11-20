---
uid: Architecture_single_agent
description: "Explore the smallest DataMiner System footprint: one DaaS or self-managed Agent with STaaS, or local WSL databases for limited testing."
keywords: architecture, single agent, small footprint, DaaS, STaaS, WSL
---

# One-box system

A one-box system is a complete DMS whose compute workload runs on a single Agent. It is the smallest compute topology: one DataMiner server or virtual machine, rather than a multi-server compute cluster. That one box can be hosted through DaaS or self-managed. With STaaS, storage runs as a managed service outside the box; the local WSL variation also puts the databases on the same machine.

## When this topology fits

This topology can for example be used in case your workload fits one node, you are evaluating DataMiner, or your operation can tolerate the node being unavailable during maintenance or recovery. These are examples, not cumulative requirements.

A small production system can use this topology if its availability requirements permit it.

The data sources can be public APIs, private equipment, or a combination. A DaaS DMS can reach private sources through a [site-to-site VPN](xref:Connecting_to_private_data_sources#about-the-site-to-site-vpn-connection) or [DataMiner Edge](xref:DataMiner_Edge). A self-managed DMS can use direct local access, routed network access, or DataMiner Edge to reach remote sites.

## Common use cases

- **Small monitoring installations**: One DMS manages a limited workload at a facility where compute downtime is acceptable.
- **Proofs of concept**: Quickly connect representative devices or APIs and evaluate a solution without deploying a compute cluster.
- **Development labs**: Build and test connectors, scripts, and packages in an isolated DMS.
- **Training and demonstrations**: Run a complete system with simulated or selected real data on one compute machine.
- **Limited non-production environments without STaaS**: Run local Linux databases on WSL alongside DataMiner, within the documented test and staging restrictions.

The one-box footprint is a deployment choice, not a sizing guarantee. Size the whole workload and revisit redundancy if the system becomes operationally critical.

## Deployment variations

Three variations are possible:

- [**A single DaaS node**](#daas-node): Skyline operates the compute infrastructure and storage. STaaS is the only storage option for DaaS. You configure the system and provide a supported path to your data sources.
- [**A Self-managed DMA with STaaS**](#self-managed-one-box-dms-with-staas): You operate one Windows compute machine and Skyline operates storage. This is suitable if you already have a server platform or need to run the DMS locally. Outbound HTTPS to STaaS is required.
- [**Self-managed DMA with local WSL databases**](#self-managed-one-box-dms-with-local-wsl-databases): Cassandra and OpenSearch run locally on Linux through Windows Subsystem for Linux. This reduces the number of machines, not the combined resource requirements or maintenance responsibilities. The local-storage setup is intended for small test, development, and staging environments, not normal production use.

> [!TIP]
> For detailed requirements and architecture information, refer to [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements) and [Single DMA storage setups](xref:Dedicated_clustered_storage#single-dma-setups), respectively.

### DaaS node

The DMS consists of only one DaaS node. A DaaS system always uses STaaS, which is hosted in the same dataminer.services cloud environment for low-latency storage access. Private equipment can be reached through [Edge](xref:DataMiner_Edge) or a site-to-site VPN; equipment does not need to be publicly accessible.

![Diagram of a cloud environment hosting one DaaS DMA and STaaS system data storage with low-latency access. A private site network containing an Edge Gateway connects to the cloud through an Edge tunnel, and the Edge Gateway connects to private equipment over a local network. The cloud also connects to public APIs and cloud services using HTTPS and API calls](~/dataminer/images/One-box_system_DaaS_node.png)

The example above uses an Edge Gateway for visual clarity. A site-to-site VPN is another option for DaaS. An Edge Node can instead run compatible integrations locally (for details, refer to the [distributed topology](xref:Architecture_distributed_sites#architecture-variants)).

### Self-managed one-box DMS with STaaS

The DMA is in your own network and uses STaaS in the cloud. This example uses an Edge Gateway to reach equipment at a remote site.

![Diagram of your site network with one Windows machine running a DMS that contains a single DMA. The DMA connects to STaaS managed cloud storage over HTTPS, directly or via a proxy, to public APIs and cloud services using HTTPS and API calls, and to equipment in the same network over a local network or local interface. An Edge tunnel links the DMA to an Edge Gateway in a remote site network, which connects to remote equipment over a local network](~/dataminer/images/Self-managed_one-box_DMS_with_STaaS.png)

STaaS keeps the local footprint to one DMA, without local database servers.

### Self-managed one-box DMS with local WSL databases

For **limited non-production** use, both the DMA and Linux databases can run on one Windows machine. Unlike the previous [variation with STaaS](#self-managed-one-box-dms-with-staas), in this case the storage shares the machine's resources and failure domain with the DMA. This should not be used for production systems.

![Diagram of your site network with one Windows machine running a DMS. Inside the machine, a DMA has local database access to Cassandra and OpenSearch running on Linux on WSL. Outside the machine, the DMA connects to local equipment over a local network or interface](~/dataminer/images/Self-managed_one-box_DMS_with_local_WSL_databases.png)

The example above shows local equipment only; remote access can be added if needed.

## Availability and growth

One DMA has **no compute redundancy**. STaaS provides storage redundancy, but does not take over a failed DMA. With local WSL storage, compute and databases share the same machine, so a host failure affects both. Plan downtime for maintenance and test your restore procedure.

If the load outgrows one node, move to a [centralized cluster](xref:Architecture_centralized_cluster). If availability becomes critical, add an appropriate redundancy model even if the workload still fits one DMA. A local WSL deployment that grows beyond its intended scope needs migration to STaaS or dedicated storage and [decommissioning of WSL](xref:Decommissioning_WSL).

## Operations and getting started

For DaaS:

- Start with [Creating a DMS on dataminer.services](xref:Creating_a_DMS_on_dataminer_services).
- Backups are managed automatically by Skyline (see [DaaS backup policy](xref:Creating_a_DaaS_system_FAQ#what-backup-policy-does-a-daas-system-have)).

For a self-managed DMA with STaaS:

- Use the [DataMiner installer](xref:Installing_DM_using_the_DM_installer) and [STaaS setup instructions](xref:Setting_up_StaaS).
- You will need to configure [DataMiner backups](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube) yourself; however, storage does not need to be included in these. STaaS provides daily storage backups that are retained for 30 days.

For a self-managed DMA with local WSL databases

- Use the [pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk) and follow its platform-specific restrictions.
- You will need to configure [DataMiner backups](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube) and arrange database backups yourself.

> [!TIP]
> Compare costs using the [DaaS sizing guide](xref:Pricing_sizing_guide_services_DaaS) and [STaaS sizing guide](xref:Pricing_sizing_guide_services_StaaS).

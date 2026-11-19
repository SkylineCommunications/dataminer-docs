---
uid: Architecture_distributed_sites
description: "Explore the distributed multi-site DataMiner architecture, where one DataMiner System manages equipment at many stations, headends, or sites."
keywords: architecture, multi-site, distributed, remote sites, DataMiner Edge, WAN
---

# Distributed multi-site system

In this architecture, one DataMiner System manages equipment at several locations, such as regional TV stations, headends, teleports, transmitter sites, or train stations. You get one operational view while placing integrations or DataMiner nodes close to the equipment where needed. The system can use cloud-hosted or on-premises compute, with managed or self-managed storage according to its connectivity requirements.

This arrangement keeps site data in one operational system and lets you add locations gradually. Its suitability depends on the links and the amount of processing needed at each site, not on a fixed minimum number of locations.

## When to use this architecture

Any of the following cases can make this topology a good fit:

- You manage equipment spread over many sites, and you want to operate it from one or more central operations centers.
- Local interfaces or polling volumes make it useful to run integrations near the equipment.
- Some sites need local data collection during interruptions, using a supported [Edge integration](xref:DataMiner_Edge) or a deliberately independent system where required.

> [!TIP]
> Reliable cluster and storage connectivity remains a prerequisite for sites hosting full DMAs. For sites that operate independently, see [Multiple independent DataMiner Systems](xref:Architecture_multiple_systems).

## Use cases

- Broadcasters with a network of regional stations, studios, or transmitter sites.
- Cable and telecom operators with many headends, hubs, or central offices.
- Satellite operators with multiple teleports and gateway sites.
- Rail, transport, and utility networks with many stations or substations.

> [!TIP]
> See also: [Typical starting points per industry](xref:Overview_Architecture_and_components#typical-starting-points-per-industry).

## Architecture variants

The examples below show two approaches: distributing DMAs across sites and using Edge components for remote data collection. A deployment can combine both approaches.

### Self-managed DMAs at multiple sites

These self-managed DMAs belong to one DMS and use STaaS in the cloud. The unlabeled arrow indicates cluster communication over a routed WAN. Each DMA accesses STaaS independently and polls its local equipment.

![Diagram of DMA 1 in a central site network and DMA 2 in a remote site network, which communicate with each other. Both DMAs connect to STaaS managed cloud storage over HTTPS. DMA 2 also connects to local equipment in the remote site over a local network or interface](~/dataminer/images/Self-managed_DMAs_at_multiple_sites.png)

### DaaS with remote collection through Edge

In this example, the DMS runs on DaaS, co-hosted with STaaS in the same cloud environment. The Edge Node runs compatible integrations locally, while the Gateway provides a tunnel for centrally running integrations. A self-managed DMS can use Edge in the same way. Note that the Edge components are not DMAs and do not access system data storage directly.

![Diagram of a cloud environment hosting DaaS DMAs and STaaS system data storage with low-latency access. Site B runs integrations locally: an Edge Node exchanges integration management and data with the cloud and connects to local equipment over a local network or interface. Site C runs integrations centrally: an Edge Gateway connects to the cloud through an Edge tunnel and to local equipment over a local network](~/dataminer/images/DaaS_with_remote_collection_through_Edge.png)

STaaS requires outbound HTTPS from each self-managed DMA, directly or via a supported proxy. Edge Nodes can connect to the DMS directly or through dataminer.services. A DaaS system can also reach remote equipment through a [site-to-site VPN](xref:Connecting_to_private_data_sources#about-the-site-to-site-vpn-connection).

## Choosing a variant

### When use on-site DataMiner nodes?

A site can host a full DataMiner node when it needs local DataMiner functionality or workloads that are not covered by Edge. All nodes are part of one DMS and share the same storage. A full DMA is not required merely because the site is remote.

- Polling traffic stays within the site, which reduces WAN traffic and allows local interfaces such as serial connections.
- With [Storage as a Service](xref:STaaS), each site needs outbound internet access. With self-managed storage, each node needs a reliable, low-latency connection to the central database clusters.
- Every node is a full DataMiner Agent that needs to be maintained and upgraded.

### When use central polling over the WAN?

For smaller sites, you can poll equipment from central DataMiner nodes instead of deploying a local node. The equipment is polled directly over a routed network or through a [DataMiner Edge Gateway](xref:About_Edge_Gateways). A DaaS system can also use a [site-to-site VPN](xref:Connecting_to_private_data_sources#about-the-site-to-site-vpn-connection).

- Fewer servers to maintain.
- Monitoring of a site stops when the connection to the site is lost. However, the loss of connectivity itself is detected and reported centrally.
- Suitable for sites with a limited number of devices and a stable connection.

### When use DataMiner Edge Nodes?

This feature is currently in preview.

An [Edge Node](xref:About_Edge_Nodes) runs compatible Python-based integrations locally and forwards their data to elements in the central system. During a connection interruption, it buffers collected data on disk and synchronizes it when connectivity returns. This provides local execution with a smaller footprint than a full DMA.

## Redundancy

- **Central functions**: Apply the [centralized cluster](xref:Architecture_centralized_cluster) redundancy guidance, and add a [geo-redundant design](xref:Architecture_geo_redundant) if the operation must withstand loss of the central hosting site.
- **Sites**: Decide per site whether local redundancy is required. A DMS can have multiple compute nodes at critical sites and use Swarming for supported workloads, provided the recovery nodes can reach the equipment. Less critical sites may need only one compute node or an Edge component.
- **WAN**: Do not cluster DataMiner nodes that depend on each other over unreliable WAN links. Design each site so that a WAN failure only affects the visibility of that site, not the rest of the system.

### What happens when a site loses its connection?

Losing the connection to the central DataMiner nodes is different from losing access to storage. Having a local DMA or an Edge Node does not, by itself, guarantee that local alarm handling, control, and workflows will remain available during an outage.

If a site must remain fully operational in isolation, consider a separate DMS with a storage and connectivity design that supports that requirement. Test whether polling, alarm handling, control, and historical data storage continue during the expected outage, and verify how the site recovers after reconnection. Do not assume that deploying a local node guarantees continued operation.

#### Full on-site DMA

A local DMA may still be able to communicate with the equipment, but it also depends on storage and other cluster functions. Local equipment access alone therefore does not guarantee continued operation. Test which functions remain available when the DMA loses communication with other nodes, with storage, or with both.

Updates from an unreachable site cannot be relied on until connectivity returns.

#### Central polling, directly or through an Edge Gateway

If the connection used for polling is lost, the central DataMiner nodes can no longer collect new data from the equipment.

Live monitoring through that connection is unavailable until connectivity is restored.

#### Edge Node with compatible integrations

Collected data is buffered on disk and synchronized after reconnection. This is allows data collection to continue but does not make central alarm handling or control available while the connection is down.

New data reaches the DMS after connectivity returns.

## Maintenance and backups

- All compute nodes in one DMS must run the same DataMiner version.

- For the self-managed parts of a DMS:

  - Plan enough bandwidth and maintenance windows to reach every site.
  - Configure [DataMiner backups](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube) outside the compute hosts

- For DaaS nodes:

  - Skyline manages DaaS platform maintenance.
  - Skyline manages [DaaS backups](xref:Creating_a_DaaS_system_FAQ#what-backup-policy-does-a-daas-system-have).

- Keep an inventory of which elements run on which site, and use views and naming conventions per site to keep the system manageable.

## Sizing

Size each site node based on the number of elements and the load at that site, according to the [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements). Small sites with few elements may not need a dedicated node.

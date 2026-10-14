---
uid: Architecture_market_segments
description: Find out which DataMiner System architectures are commonly used in broadcast, satellite, telecom, media, transport, utilities, and other segments.
keywords: architecture, market segments, broadcast, satellite, teleport, cable, telecom, OTT, streaming, transport, utilities
---

# Architectures by market segment

The architecture of a DataMiner System depends more on the situation than on the industry. Still, organizations in the same market segment often face similar challenges, and certain architectures are therefore more common in some segments than in others. This page lists typical patterns per segment as a starting point. Always validate them against your own requirements using the [questions in the overview](xref:Architecture_overview#questions-to-ask-before-you-choose). For an explanation of terms such as Failover, Swarming, STaaS, and GRS, see [Key terms](xref:Architecture_overview#key-terms).

## Broadcast (TV and radio)

**Typical situation**: Master control rooms, playout centers, studios, contribution and distribution networks, and often a network of regional stations or transmitter sites. Monitoring of the air chain is critical, so high availability is usually required.

| Scenario | Common architectures |
|--|--|
| One main facility | [Self-managed nodes with STaaS](xref:Architecture_self_managed_staas) or an [on-premises system with self-managed storage](xref:Architecture_on_premises), with Failover or Swarming |
| A few facilities in one region, such as studios and a playout center | One DMS with nodes in the facilities that need local access, and redundant storage. See the [example scenario](xref:Architecture_overview#a-broadcaster-with-a-few-facilities-in-one-region). |
| Regional stations or transmitter sites | [Distributed multi-site system](xref:Architecture_distributed_sites), with a node at larger sites and central polling or DataMiner Edge for smaller sites |
| Main and backup facility | DataMiner nodes at both facilities, combined with STaaS with geo-redundant storage or a [geo-redundant on-premises system](xref:Architecture_geo_redundant). See [Surviving the loss of a site](xref:Architecture_building_blocks#surviving-the-loss-of-a-site). |
| Cloud-based playout or production | [Cloud-hosted system](xref:Architecture_cloud_hosted) or [hybrid cluster](xref:Architecture_hybrid_cluster) |

**Considerations**: Plan maintenance windows around the broadcast schedule, and use Failover or Swarming to keep monitoring the air chain during maintenance. A separate staging system is recommended for systems that include orchestration or automation.

## Media service providers, playout, and live production

**Typical situation**: Shared facilities serving multiple channels or customers, often combined with booking, scheduling, and orchestration of resources (for example with [MediaOps](xref:Overview_DataMiner_Solutions)). Event-driven workloads can vary strongly over time.

| Scenario | Common architectures |
|--|--|
| On-premises facility with orchestration | [Self-managed nodes with STaaS](xref:Architecture_self_managed_staas) or an [on-premises system with self-managed storage](xref:Architecture_on_premises), with separate staging |
| Facility combined with cloud workflows | [Hybrid cluster](xref:Architecture_hybrid_cluster) |
| Fully cloud-based production or remote production | [Cloud-hosted system](xref:Architecture_cloud_hosted) with DataMiner Edge |
| Separate environments per customer or business unit | [Multiple independent DataMiner Systems](xref:Architecture_multiple_systems) |

**Considerations**: Orchestration and booking functionality relies on both DataMiner and the storage being available, so storage redundancy is as important as DataMiner node redundancy. Validate workflow changes on a [staging system](xref:Architecture_lab_and_staging) that uses the same storage architecture as production.

## OTT, streaming, and cloud media

**Typical situation**: Most of the infrastructure consists of cloud services, CDNs, encoders, packagers, and origin servers that expose APIs, often combined with a limited amount of on-premises equipment.

| Scenario | Common architectures |
|--|--|
| Mainly cloud services | [Cloud-hosted system](xref:Architecture_cloud_hosted) |
| Cloud services plus on-premises headend or encoding | [Hybrid cluster](xref:Architecture_hybrid_cluster), or a cloud-hosted system with DataMiner Edge |

**Considerations**: Choose a region close to the cloud services you monitor. API rate limits of cloud providers can be a bigger constraint than DataMiner capacity.

## Satellite operators and teleports

**Typical situation**: RF equipment, modems, antenna control units, and network management systems at one or more teleports, often with a network operations center that manages several sites. Many devices are only reachable in private networks, and some require local or serial interfaces.

| Scenario | Common architectures |
|--|--|
| One teleport | [Self-managed nodes with STaaS](xref:Architecture_self_managed_staas) or an [on-premises system with self-managed storage](xref:Architecture_on_premises) |
| Multiple teleports or gateways managed centrally | [Distributed multi-site system](xref:Architecture_distributed_sites), with a DataMiner node at each teleport |
| Primary and backup teleport or network operations center, with a reliable low-latency link | DataMiner nodes at both sites, combined with STaaS with geo-redundant storage or a [geo-redundant on-premises system](xref:Architecture_geo_redundant). See [Surviving the loss of a site](xref:Architecture_building_blocks#surviving-the-loss-of-a-site). |
| Teleports far apart or connected via high-latency links | [Multiple independent DataMiner Systems](xref:Architecture_multiple_systems), one per teleport or region, with a central view via element replication |

**Considerations**: Place DataMiner nodes at the teleports where equipment requires local access. Avoid stretching one cluster over long-distance or satellite links with high latency. To decide between one system and several, see [One system or several?](xref:Architecture_overview#one-system-or-several) and the [example scenario](xref:Architecture_overview#a-satellite-operator-with-a-main-and-a-backup-teleport-in-different-countries).

## Satellite and VSAT service providers

**Typical situation**: Large numbers of remote terminals, often managed via the cloud APIs or network management systems of the satellite network or terminal vendor, combined with service provisioning and customer-facing monitoring.

| Scenario | Common architectures |
|--|--|
| Terminals managed via vendor cloud APIs | [Cloud-hosted system](xref:Architecture_cloud_hosted) |
| Hub infrastructure on premises plus remote terminals | [Self-managed nodes with STaaS](xref:Architecture_self_managed_staas) or a [hybrid cluster](xref:Architecture_hybrid_cluster) |

**Considerations**: Large numbers of terminals lead to large amounts of trend and alarm data, so storage scalability is important. Separate front-end nodes (for users and APIs) from back-end nodes (for polling) when the load is high.

## Cable and telecom operators

**Typical situation**: Large access networks (for example DOCSIS, FTTH, or mobile), headends, hubs, and data centers, often with [EPM](xref:EPM) to aggregate data from millions of customer devices. Systems tend to be large and grow over time.

| Scenario | Common architectures |
|--|--|
| Large central system | Clustered system with many nodes, based on [self-managed nodes with STaaS](xref:Architecture_self_managed_staas) or an [on-premises system with self-managed storage](xref:Architecture_on_premises) |
| Many headends or hubs | [Distributed multi-site system](xref:Architecture_distributed_sites) |
| Separate networks or technology domains | [Multiple independent DataMiner Systems](xref:Architecture_multiple_systems) |

**Considerations**: EPM and other aggregation-heavy solutions have higher [compute requirements](xref:DataMiner_Compute_Requirements) than average systems, for example in terms of RAM and CPU. Separating roles, such as user-facing nodes and polling nodes, helps to scale these systems. Plan the storage capacity for growth.

## Transport, rail, and utilities

**Typical situation**: Operational networks that are often separated from the internet, with equipment at many stations, substations, or along the track, and strict requirements for availability and security.

| Scenario | Common architectures |
|--|--|
| Isolated operational network | [On-premises system with self-managed storage](xref:Architecture_on_premises) |
| Many stations or substations | [Distributed multi-site system](xref:Architecture_distributed_sites) |
| Operational network with controlled internet access | [Self-managed nodes with STaaS](xref:Architecture_self_managed_staas) |

**Considerations**: Network segmentation and security zones often determine the architecture. Check early whether outbound connectivity to cloud services is allowed.

## Government, defense, and public safety

**Typical situation**: Strict security and data residency requirements, often with separate classified and unclassified networks.

| Scenario | Common architectures |
|--|--|
| Air-gapped networks | [On-premises system with self-managed storage](xref:Architecture_on_premises) |
| Separated networks or agencies | [Multiple independent DataMiner Systems](xref:Architecture_multiple_systems) |
| Mission-critical, multi-site | [Geo-redundant on-premises system](xref:Architecture_geo_redundant) |

**Considerations**: In air-gapped networks, plan how software updates and connectors will be transferred into the network, and make sure the team has the expertise to maintain the database clusters.

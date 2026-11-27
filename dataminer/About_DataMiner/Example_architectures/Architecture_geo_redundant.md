---
uid: Architecture_geo_redundant
description: "Design a geo-redundant DataMiner System with compute at separate locations and storage and connectivity that support recovery after site loss."
keywords: architecture, geo-redundancy, disaster recovery, failure domains, STaaS, Cassandra, OpenSearch
---

# Geo-redundant system

A geo-redundant design places compute at separate locations so a system can recover when a complete hosting site is lost. This can extend a centralized cluster or a distributed system. It is not limited to on-premises deployments: hosting may be cloud-based, self-managed, or a supported hybrid arrangement.

## When this topology fits

Site-loss continuity is the main reason to choose this topology. Examples include a broadcaster with a main and backup operational center, a satellite operator with two teleports, or an operation whose recovery target cannot depend on rebuilding the only hosting site. You do not need to match every example.

Recovery requires more than geographically separated machines. Remaining compute must have capacity, supported takeover mechanisms, access to storage, and access to the devices and services it must manage. If locations must operate independently or cannot meet cluster connectivity requirements, consider [separate systems](xref:Architecture_multiple_systems) instead.

## Compute and storage placement

The following example uses self-managed DMAs at two locations in one DMS, with STaaS in the cloud. Each location has its own storage connection. The unlabelled arrow between DMAs indicates cluster communication. Cross-site equipment access uses the routed WAN: moving a workload only helps when the recovery DMAs can still reach its data sources.

![Diagram of DMAs in Location A and DMAs with recovery capacity in Location B, which communicate with each other. Each location has equipment connected to its DMAs over a local network, and each location's DMAs connect to STaaS cloud storage, with zone-redundant or optional geo-redundant storage, over HTTPS. Recovery access over the WAN lets the DMAs in each location reach the equipment in the other location](~/dataminer/images/Compute_and_storage_placement.png)

The two location boxes do not imply a two-node cluster: size and place the nodes for the selected recovery mechanism. Equipment at a failed site may itself be unavailable; the recovery paths apply only to sources that remain operational and reachable.

Place DMS compute at both locations and use [Swarming](xref:Swarming) for supported workload movement and recovery. Swarming requires spare capacity and reachable data sources; global outage detection in Node Recovery also has cluster-size and leader-election prerequisites. Geographical placement alone does not guarantee automatic recovery.

### With STaaS

STaaS provides zone-redundant storage by default and optional geo-redundant storage (GRS) with a copy in a paired region. This separates the database operations from your compute placement. Select the storage option against your recovery targets using [Data location and redundancy](xref:STaaS_features#data-location-and-redundancy).

GRS does not provide a replacement DMA or reconnect managed equipment. Nodes at the surviving location must still reach STaaS and all required sources. For multi-region DaaS compute, consult the [DaaS regional guidance](xref:DaaS_hosting#regional-support-for-daas) and agree the supported design with Skyline.

### With self-managed databases

For a geo-redundant on-premises deployment, configure Cassandra with a data center per site and an appropriate NetworkTopologyStrategy. OpenSearch uses data nodes at both sites and a non-data tie-breaker node at a third location, with shard allocation awareness. The tie-breaker provides an additional voting location so the cluster can retain a majority after losing a site.

This storage variation replaces STaaS in the previous example. Both compute locations need connections to the database nodes they use, including the paths required during recovery. The drawing groups database nodes by site and does not specify node counts.

![Diagram of DMAs in Location A and Location B that communicate with each other. In each location, the DMAs have database connections to OpenSearch data nodes and to a Cassandra data center in that same location. A third voting location contains an OpenSearch tie-breaker that stores no data and is linked to the OpenSearch data nodes of both locations](~/dataminer/images/Compute_and_storage_placement_with_self-managed_databases.png)

Unlabelled links between OpenSearch components indicate database cluster communication and voting. Cross-site DMA-to-database paths are omitted to keep the drawing readable, but must be available where required by the recovery design. The tie-breaker is not another database containing a copy of operational data. All database components run on Linux; replication, shard placement, voting, and network requirements must follow the storage configuration guidance.

This arrangement gives control over data placement but makes database maintenance and network partitions part of your recovery design. See [Dedicated clustered storage](xref:Dedicated_clustered_storage) for the database placement and configuration guidance.

## Network requirements

Follow the [DataMiner inter-node requirements](xref:DataMiner_Compute_Requirements#network) for latency and throughput, and verify reachability from every recovery node. Self-managed OpenSearch nodes require a stable low-latency link between sites; they must not simply be stretched across high-latency connections. A cloud-hosted tie-breaker requires sufficiently low latency, below 50 ms.

These are different network paths: acceptable DataMiner inter-node latency does not automatically prove that a distributed database design is suitable. Measure the actual links and validate the design before deployment.

## Recovery and operations

Define how much downtime and recent data loss are acceptable, then test node loss, site loss, and network partitions separately. Replicated storage is not a substitute for backups, and a replicated copy does not by itself guarantee zero data loss.

For self-managed storage, coordinate repairs and upgrades across sites and test loss of each voting location. For STaaS, understand the selected service's redundancy and recovery behavior rather than assuming a storage-region failure and a compute-site failure are identical.

Size each surviving compute location for the workload it must absorb using the [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements). Store backups outside the failure domain they protect. See [Backups and disaster recovery](xref:Architecture_design_considerations#backups-and-disaster-recovery).

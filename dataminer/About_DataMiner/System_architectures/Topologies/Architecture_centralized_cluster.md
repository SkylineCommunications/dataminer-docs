---
uid: Architecture_centralized_cluster
description: Design one centrally hosted DataMiner cluster for shared operations, with multiple nodes for workload growth and appropriate redundancy.
keywords: architecture, centralized cluster, redundancy, Failover, Swarming, Edge
---

# Centralized cluster

A centralized cluster hosts multiple DataMiner nodes at a central location or cloud region. They share system data storage and provide one operational view. Integrations reach data sources directly, across a WAN or VPN, or through DataMiner Edge. The equipment does not need to be located alongside the cluster.

## When this topology fits

This topology is useful when you want one centrally operated system, need more capacity than one DMA, or need node redundancy. You do not need all of these reasons to apply. For example, a broadcaster may use a small redundant cluster for critical monitoring, while an EPM deployment may use many nodes to divide polling and aggregation workloads.

Centralized compute also fits private equipment at several sites if the connectivity and integration requirements can be met through a VPN or Edge. Where local integration execution is needed, consider Edge Nodes or a [distributed multi-site system](xref:Architecture_distributed_sites).

## Arrangement

```mermaid
flowchart LR
    subgraph Central["Central compute: DaaS or self-managed"]
        A[DataMiner node] --- S[(Shared system data storage)]
        B[Additional or backup nodes] --- S
    end
    Central --> APIs[Cloud services and APIs]
    Central -- Direct network / VPN / Edge --> Sites[Private or remote equipment]
```

Choose [hosting and storage](xref:Architecture_hosting_and_storage) independently of this arrangement. DaaS uses STaaS. Self-managed nodes can use STaaS or dedicated clustered storage, on premises or in a cloud environment.

As the system grows, you can separate user-facing functions from polling or aggregation workloads. All nodes remain part of one DMS, so configuration and upgrades stay coordinated. This reduces the need for cross-system integration, but means changes and shared dependencies can affect the whole system.

## Redundancy and maintenance

Multiple nodes alone do not guarantee takeover. Choose [Failover or Swarming](xref:Architecture_building_blocks#redundancy-features) according to the supported objects and recovery behavior you need. Failover provides a dedicated standby for a protected DMA. Swarming distributes supported workloads across active nodes, with sufficient capacity and reachability for recovery. Global Node Recovery detection requires at least three nodes; two-node recovery can use local detection with additional network-split risks. See [Node Recovery detection](xref:NodeRecovery_Detection) before relying on automatic redistribution.

Provide storage redundancy as well as compute redundancy. Place redundant nodes in separate failure domains, rather than on the same physical host or storage array. A cluster at one location does not by itself withstand loss of that location; apply a [geo-redundant design](xref:Architecture_geo_redundant) if that is required.

Central polling depends on the connection to each remote site. Edge Nodes can place integrations locally, but do not replace an independent full DMS where a site must operate in isolation. Include WAN interruptions in recovery testing.

## Sizing and operations

Size compute and any self-managed databases using the [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements). Keep capacity for the chosen recovery model, not just normal operation.

Coordinate upgrades across the cluster and test them in [staging](xref:Architecture_lab_and_staging). Configure [DataMiner backups](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube) alongside the storage backup strategy. Responsibilities depend on your hosting choice, as described in [Hosting and storage](xref:Architecture_hosting_and_storage).

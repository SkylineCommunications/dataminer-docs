---
uid: Architecture_centralized_cluster
description: Design one centrally hosted DataMiner cluster for shared operations, with multiple nodes for workload growth and appropriate redundancy.
keywords: architecture, centralized cluster, redundancy, Swarming, Edge
---

# Centralized cluster

A centralized cluster is the most common starting point for a multi-node DMS. It hosts compute at a central location or cloud region, with shared system data storage and one operational view. Integrations reach data sources directly, across a routed network, or through DataMiner Edge. A DaaS cluster can also use a site-to-site VPN. The equipment does not need to be located alongside the cluster.

## When this topology fits

This topology is useful when you want one centrally operated system, need more capacity than one DMA, or need node redundancy. You do not need all of these reasons to apply. For example, a broadcaster may use a small redundant cluster for critical monitoring, while an EPM deployment may use many nodes to divide polling and aggregation workloads.

Centralized compute also fits private equipment at several sites if the connectivity and integration requirements can be met through Edge or, for a DaaS cluster, a site-to-site VPN. Where local integration execution is needed, consider Edge Nodes or a [distributed multi-site system](xref:Architecture_distributed_sites).

## Common use cases

- **Broadcast facilities**: One DMS monitors studios, playout, and the air chain, with centrally managed alarms and workflows.
- **Satellite and service-provider operations**: A network operations center manages teleport equipment or terminal populations through reachable device interfaces and vendor APIs.
- **Cloud media and OTT**: Integrations monitor encoders, streaming services, and cloud platforms from a shared compute environment.
- **Cable and telecom aggregation**: Multiple nodes divide polling, EPM aggregation, and user-facing workloads while remaining one system.
- **Shared orchestration**: Booking, resource management, and automation operate across private and cloud resources without requiring a separate system for each location.

For DaaS access to private sources, see [Connecting to private data sources](xref:Connecting_to_private_data_sources). The same topology can also run as a self-managed DMS.

## Arrangement

Each example shows one DMS consisting of three DMAs. Three DMAs illustrate a cluster, not a fixed minimum for every deployment.

### DaaS with site-to-site VPN connectivity

With DaaS, the DMAs and STaaS are co-hosted in the same cloud environment, providing low-latency storage access. STaaS is the only storage option for DaaS. This example uses a site-to-site VPN to reach private equipment.

```mermaid
flowchart TB
    Cloud@{ shape: cloud, label: "Same cloud environment<br/>DaaS: DMA 1, DMA 2, DMA 3<br/>STaaS: shared system data storage<br/>Low-latency access" }
    Public["Public APIs and cloud services"]
    subgraph Remote["Private network"]
        E["Private equipment"]
    end
    Cloud <-->|"HTTPS / API calls"| Public
    Cloud <-->|"Site-to-site VPN"| E
```

DataMiner Edge is an alternative to the VPN. An Edge Gateway lets centrally running integrations reach remote equipment, and an Edge Node runs compatible integrations at the site.

### Self-managed storage with Edge connectivity

This example places self-managed DMAs and dedicated Linux database machines in the same site network. An Edge Gateway gives the DMS access to equipment at a remote site, such as a headend or distant teleport. The arrows between DMAs indicate cluster communication.

```mermaid
flowchart TB
    subgraph Site["Central site network"]
        subgraph DMS["One DMS"]
            A["DMA 1"]
            B["DMA 2"]
            C["DMA 3"]
            A <--> B
            B <--> C
            A <--> C
        end
        DB[("Cassandra and OpenSearch<br/>Dedicated Linux machines")]
        Local["Local equipment"]
    end
    subgraph Remote["Remote site network"]
        G["Edge Gateway"]
        RE["Remote equipment"]
    end
    DMS <-->|"Database access from every DMA"| DB
    DMS <-->|"Local network"| Local
    DMS <-->|"Edge tunnel"| G
    G <-->|"Local network"| RE
```

The Gateway is not a DMA. Self-managed DMAs can also use STaaS, with outbound HTTPS from every DMA. Each example uses one storage choice to keep the drawing clear.

Choose the [deployment model](xref:Overview_hosting) independently of this arrangement. DaaS uses STaaS. Self-managed nodes can use STaaS or dedicated clustered storage, on premises or in a cloud environment.

As the system grows, you can separate user-facing functions from polling or aggregation workloads. All nodes remain part of one DMS, so configuration and upgrades stay coordinated. This reduces the need for cross-system integration, but means changes and shared dependencies can affect the whole system.

## Redundancy and maintenance

Multiple nodes alone do not guarantee takeover. Use [Swarming](xref:Swarming) to move supported workloads across active nodes, with sufficient capacity and reachability for recovery. Global Node Recovery detection requires at least three nodes; two-node recovery can use local detection with additional network-split risks. See [Node Recovery detection](xref:NodeRecovery_Detection) before relying on automatic redistribution.

Provide storage redundancy as well as compute redundancy. Place redundant nodes in separate failure domains, rather than on the same physical host or storage array. A cluster at one location does not by itself withstand loss of that location; apply a [geo-redundant design](xref:Architecture_geo_redundant) if that is required.

Central polling depends on the connection to each remote site. Edge Nodes can place integrations locally, but do not replace an independent full DMS where a site must operate in isolation. Include WAN interruptions in recovery testing.

## Sizing and operations

Size compute and any self-managed databases using the [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements). Keep capacity for the chosen recovery model, not just normal operation.

For a self-managed DMS, coordinate platform upgrades across the cluster and configure DataMiner backups alongside the storage backup strategy. Skyline manages DaaS maintenance and backups; see [DataMiner as a Service](xref:DaaS_hosting). Develop and validate solution changes in [lab and staging](xref:Architecture_design_considerations#lab-and-staging-environments), promoting the same tested package version to production.

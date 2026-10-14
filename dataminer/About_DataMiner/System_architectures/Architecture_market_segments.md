---
uid: Architecture_market_segments
description: Relate DataMiner topologies to broadcast, satellite, telecom, media, and other scenarios, while choosing hosting and storage separately.
keywords: architecture, market segments, broadcast, satellite, teleport, cable, telecom, OTT, transport, utilities
---

# Architectures by market segment

Your data sources, availability targets, and isolation requirements determine the topology more than your industry does. The examples below suggest starting points, not mandatory combinations of requirements. You can apply the same topology in the cloud or on premises; select [hosting and storage](xref:Architecture_hosting_and_storage) separately.

For terminology and selection questions, see the [architecture overview](xref:Architecture_overview). Where both local and cloud data sources are involved, consider a VPN or DataMiner Edge before deciding that you need a hybrid cluster.

## Broadcast (TV and radio)

Air-chain monitoring often needs node redundancy, while studios and transmitter sites may need local integration execution. A centrally hosted cluster can serve several facilities if it can reach their equipment.

| Scenario | Topology and operational choices |
|--|--|
| One facility, or a few studios and a playout center | A [centralized cluster](xref:Architecture_centralized_cluster) with node redundancy for critical monitoring. Reach private equipment directly or via Edge, or via a site-to-site VPN when using DaaS. |
| Regional stations or transmitter sites | A [distributed multi-site system](xref:Architecture_distributed_sites), using Edge Nodes for compatible local integrations and full DMAs where required. |
| Continuity after loss of the hosting facility | Apply a [geo-redundant design](xref:Architecture_geo_redundant), including compute, storage, and device reachability. |
| Small non-critical installation | A [one-box DMS](xref:Architecture_single_agent), if compute downtime is acceptable. |

Plan maintenance around the broadcast schedule and validate automation and orchestration changes in a separate staging environment. See the [multi-facility example](xref:Architecture_overview#a-broadcaster-with-a-few-facilities-in-one-region).

## Media service providers, playout, and live production

Booking and orchestration combine operational data with resource control. Their availability depends on both compute and storage, while event-driven processing can create temporary peaks.

| Scenario | Topology and operational choices |
|--|--|
| Shared orchestration for local and cloud resources | A [centralized cluster](xref:Architecture_centralized_cluster), with Edge connectivity, or a site-to-site VPN for DaaS, where required. |
| Integrations executed at several production facilities | A [distributed multi-site system](xref:Architecture_distributed_sites). |
| Independent operations per business unit or security boundary | [Federated systems](xref:Architecture_multiple_systems), with selected information shared centrally while each DMS retains its own operations. |
| Additional compute during an event | Scale the chosen cluster. A [hybrid deployment](xref:Architecture_hybrid_cluster) can temporarily add DaaS capacity to self-managed compute if full cloud nodes are required. |

Use [staging](xref:Architecture_lab_and_staging) with representative workflows, storage, and recovery behavior. Combining on-premises equipment with cloud workflows does not itself require a hybrid cluster.

## OTT, streaming, and cloud media

Cloud services and APIs are often reachable from centrally hosted integrations. A [one-box DMS](xref:Architecture_single_agent) can fit a small workload; a [centralized cluster](xref:Architecture_centralized_cluster) provides room for capacity growth and node redundancy.

DaaS is a hosting option for either topology. If you also monitor a private headend or encoding equipment, a VPN, Edge Gateway, or compatible Edge Node integrations can connect those sources without adding a full local DMA. Choose regions and polling rates with latency and provider API limits in mind.

## Satellite operators and teleports

Teleports often contain RF equipment, modems, and antenna systems in private networks. Local interfaces can influence where integrations run, while main/backup operation adds reachability and recovery requirements.

| Scenario | Topology and operational choices |
|--|--|
| One teleport | A [one-box DMS](xref:Architecture_single_agent) where downtime is acceptable, or a [centralized cluster](xref:Architecture_centralized_cluster) with redundancy. Hosting may be local or DaaS with suitable connectivity. |
| Multiple teleports managed as one operation | A [distributed multi-site system](xref:Architecture_distributed_sites), selecting Edge or full DMAs according to integration requirements. |
| Main and backup teleport in one operational system | Add a [geo-redundant design](xref:Architecture_geo_redundant) and verify that surviving nodes can reach the required equipment. |
| Teleports requiring independent operation or unsuitable cluster links | [Federated systems](xref:Architecture_multiple_systems), with a central view of selected data from independently operated teleports. |

Do not assume a node at each teleport guarantees site isolation or recovery. Measure connectivity and decide [whether to use one system or several](xref:Architecture_overview#one-system-or-several).

## Satellite and VSAT service providers

Vendor APIs may expose many terminals through a small set of centrally reachable interfaces. A [centralized cluster](xref:Architecture_centralized_cluster) can divide polling, aggregation, and user-facing workloads without placing a DMA at every terminal.

Where hub equipment needs local integrations, extend to a [distributed arrangement](xref:Architecture_distributed_sites) using Edge or full DMAs as appropriate. Separate systems are useful when regions or service operations require isolation. Plan capacity for terminal data, alarm rates, and trending, not just the number of interfaces.

## Cable and telecom operators

Large access networks may use [Experience and Performance Management (EPM)](xref:EPM) to aggregate data from large device populations. This affects processing and storage requirements independently of hosting.

| Scenario | Topology and operational choices |
|--|--|
| Central aggregation and operations | A [centralized cluster](xref:Architecture_centralized_cluster), separating polling, aggregation, and user-facing roles as needed. |
| Local processing at many headends or hubs | A [distributed multi-site system](xref:Architecture_distributed_sites). |
| Independent networks, regions, or technology domains | [Multiple independent systems](xref:Architecture_multiple_systems). |

Apply EPM-specific [compute requirements](xref:DataMiner_Compute_Requirements), keep recovery capacity, and select storage for the expected growth.

## Transport, rail, and utilities

Many stations or substations can share a [distributed system](xref:Architecture_distributed_sites), while strictly separated operational domains may need [independent systems](xref:Architecture_multiple_systems). Add geo-redundancy where site-loss continuity is required.

An isolated network changes the hosting and storage choices, not these topologies: use self-managed compute and databases where internet services cannot be reached. If controlled outbound access is allowed, self-managed compute with STaaS is another option. Verify security-zone boundaries before choosing connections between sites or to cloud services.

## Government, defense, and public safety

Isolation, residency, and independent change processes may justify [multiple systems](xref:Architecture_multiple_systems). Each can use a centralized or distributed topology and a [geo-redundant design](xref:Architecture_geo_redundant) where required.

For air-gapped deployments, choose self-managed compute and storage and plan update transfer, database maintenance, and recovery within the isolated network. Lab and staging remain separate environment purposes, not additional production architectures.

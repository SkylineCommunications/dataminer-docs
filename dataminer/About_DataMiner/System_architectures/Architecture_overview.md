---
uid: Architecture_overview
description: Compare common DataMiner System architectures, from cloud-hosted to on-premises and hybrid, and find out which one best fits your scenario.
keywords: architecture, DMS architecture, reference architecture, topology, design
---

# DataMiner System architectures

A DataMiner System (DMS) can be deployed in many different ways: fully in the cloud, fully on premises, or anywhere in between. The right architecture depends on where the equipment and services you want to manage are located, how critical the system is for your operation, which network and security constraints apply, and how much infrastructure you want to maintain yourself.

This section describes a number of **generic reference architectures**. Each one explains when it is a good fit, what it looks like, and what its strengths and trade-offs are in terms of redundancy, maintenance, backups, and operational effort. You can use these architectures as a starting point and combine them where needed. Real-life systems often grow from one architecture into another, for example from a small single-node setup into a clustered or hybrid system.

> [!TIP]
> If you are new to DataMiner, first read [Building blocks of a DataMiner System](xref:Architecture_building_blocks). It explains the components that all architectures in this section are made of, such as DataMiner Agents, storage, and the available redundancy features. If you prefer to start from your industry, see [Architectures by market segment](xref:Architecture_market_segments).

## Key terms

The following terms are used throughout this section:

| Term | Meaning |
|--|--|
| DataMiner Agent (DMA) | One DataMiner node, i.e. one server or virtual machine running the DataMiner software. |
| DataMiner System (DMS) | One or more DMAs that work together as a single system, with one shared configuration and one view for users. |
| DataMiner as a Service (DaaS) | DataMiner nodes hosted and maintained by Skyline in the cloud. |
| Storage as a Service (STaaS) | Cloud storage for DataMiner data, hosted and maintained by Skyline. |
| Self-managed storage | Database clusters (Cassandra and OpenSearch) that you install and maintain yourself. |
| ZRS and GRS | Zone-redundant storage (copies in several data centers within one cloud region) and geo-redundant storage (an additional copy in a second region). |
| Failover | Two DMAs in a pair, where a backup DMA takes over when the active DMA fails. |
| Swarming | Elements and other objects can move between the DMAs of a cluster, for example to recover from a failed node or to perform maintenance. |
| DataMiner Edge | Lightweight components that connect equipment in remote or private networks to a DMS. |

## Questions to ask before you choose

The following questions will help you narrow down your options:

1. **Where are the data sources?** Are the devices, applications, and services you want to manage reachable over the internet or via public APIs, or are they located in private networks at one or more of your sites? Do some of them require a physical connection, such as a serial port?

1. **Can the system connect to the internet?** Cloud-hosted components such as [DataMiner as a Service (DaaS)](xref:DaaS_hosting) and [Storage as a Service (STaaS)](xref:STaaS) require outbound internet connectivity. A fully isolated (air-gapped) network requires a fully self-managed system.

1. **How critical is the system?** Determine how long the system can be unavailable, how much historical data you can afford to lose, and whether you need to survive the loss of a complete site.

1. **How many sites are involved, and how good are the links between them?** Latency, bandwidth, and the reliability of wide area network (WAN) links largely determine whether you can run one system across all sites or whether it is better to keep sites more independent.

1. **Who will maintain the infrastructure?** Self-managed DataMiner nodes and especially self-managed databases require knowledge of operating systems, virtualization, and database administration, as well as time for patching, upgrades, monitoring, and backups.

1. **How large is the system now, and how large will it be in a few years?** The number of elements, the amount of trending and alarm data, and the solutions you use (for example EPM or MediaOps) determine the [compute requirements](xref:DataMiner_Compute_Requirements).

## Decision guide

The diagram below gives a simplified view of how the answers to these questions lead to one of the architectures described in this section. It is a guideline, not a strict rule. Many systems combine several of these architectures.

```mermaid
flowchart TD
    A([Start]) --> B{Can the system use<br/>outbound internet connectivity?}
    B -- No --> C{Does the system need to<br/>survive the loss of a site?}
    C -- No --> D[On-premises system<br/>with self-managed storage]
    C -- Yes --> E[Geo-redundant on-premises system]
    B -- Yes --> F{Where are most<br/>data sources located?}
    F -- In the cloud or<br/>reachable over the internet --> G[Cloud-hosted system]
    F -- At one or a few sites --> H{Do you prefer to host the<br/>DataMiner nodes yourself?}
    H -- No --> I{Is a VPN to the site<br/>possible and desired?}
    I -- Yes --> J[Hybrid cluster]
    I -- No --> K[Cloud-hosted system<br/>with DataMiner Edge]
    H -- Yes --> L[Self-managed nodes<br/>with Storage as a Service]
    F -- At many sites --> M[Distributed multi-site system]
```

If your organization has strict separation between regions, business units, or security zones, also consider [multiple independent DataMiner Systems](xref:Architecture_multiple_systems). For test, staging, and proof-of-concept environments, see [Lab, staging, and proof-of-concept systems](xref:Architecture_lab_and_staging).

## One system or several?

A single DMS gives you one view and one configuration for all your locations, but all its DataMiner nodes need to communicate with each other and with the storage. As a guideline:

- **One system** is a good fit when the links between the locations are reliable and the latency between DataMiner nodes stays within the recommended range of roughly 30 to 50 ms or lower (see [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements)). This is typically the case for locations within the same country or region that are connected via a WAN or the internet.
- **Separate systems** are a better fit when locations are far apart (for example on different continents), connected via high-latency or unreliable links, or must be operated independently for organizational or security reasons. You can still create a central view, for example with element replication. See [Multiple independent DataMiner Systems](xref:Architecture_multiple_systems).

When you are in doubt, measure the latency and stability of the links between your locations before you decide. Skyline can help you assess whether one system is feasible.

## Example scenarios

The following examples show how the questions above lead to an architecture for some common situations.

### A broadcaster with a few facilities in one region

Two studios and a playout center in the same region, connected via a reliable network:

- One DMS is usually sufficient. Place a DataMiner node in a facility if it has equipment that needs local access or a lot of polling. Otherwise, the equipment can be polled from nodes at a central location.
- Make the nodes that monitor the air chain redundant with Failover or Swarming, and use redundant storage: [STaaS](xref:Architecture_self_managed_staas) or [dedicated clustered storage](xref:Architecture_on_premises).
- When the number of locations grows to many regional stations or transmitter sites, the [distributed multi-site system](xref:Architecture_distributed_sites) describes how to scale this approach.

### A satellite operator with a main and a backup teleport in different countries

The answer mainly depends on the link between the teleports:

- If the link is reliable and has a low latency, one DMS with DataMiner nodes at both teleports gives you one view and lets the backup teleport take over. Both the DataMiner nodes and the storage must be redundant across the sites. See [Surviving the loss of a site](xref:Architecture_building_blocks#surviving-the-loss-of-a-site).
- If the link has a high latency or is not reliable, use a separate DMS per teleport, each with local redundancy, and create a central view with element replication. See [Multiple independent DataMiner Systems](xref:Architecture_multiple_systems).

### A small team with one site and about 50 devices

A single DataMiner node is usually sufficient for a system of this size. With limited IT staff, the main question is how much infrastructure you want to maintain:

- A [cloud-hosted system](xref:Architecture_cloud_hosted) requires no servers on site. The equipment is connected via DataMiner Edge or a VPN.
- A [self-managed node with STaaS](xref:Architecture_self_managed_staas) runs on a Windows server or virtual machine in your own network. You maintain the server, while Skyline maintains the storage.
- An [on-premises system with self-managed storage](xref:Architecture_on_premises) is only needed when the system cannot connect to the internet. It requires you to also maintain Linux database nodes.

To estimate the costs, see the [sizing guide for DataMiner as a Service](xref:Pricing_sizing_guide_services_DaaS) and [Commercial and deploy models summary](xref:Pricing_Commercial_Models). For an accurate estimate, prepare an overview of the number and types of devices, how often they need to be polled, how much trending you need, and how many users will work with the system.

## Comparison of the architectures

The table below summarizes the architectures described in this section. The infrastructure effort refers to the infrastructure you need to operate yourself, not to the configuration of DataMiner itself.

| Architecture | Typical use | Redundancy options | Your infrastructure effort | Internet required |
|--|--|--|--|--|
| [Cloud-hosted system](xref:Architecture_cloud_hosted) | Cloud-native workflows, public APIs, remote sites reachable via VPN or DataMiner Edge | Multiple DaaS nodes, Swarming, zone- or geo-redundant storage | Very low | Yes |
| [Self-managed nodes with Storage as a Service](xref:Architecture_self_managed_staas) | Equipment in private networks, existing virtualization platform | Failover or Swarming, zone- or geo-redundant storage | Medium: DataMiner nodes only | Yes, outbound HTTPS |
| [Hybrid cluster](xref:Architecture_hybrid_cluster) | Mix of cloud resources and on-premises equipment in one system | Nodes in the cloud and on premises, Swarming, managed storage | Low to medium | Yes, plus a site-to-site VPN |
| [On-premises system with self-managed storage](xref:Architecture_on_premises) | Isolated or air-gapped networks, data that must stay within your own premises | Failover or Swarming, clustered Cassandra and OpenSearch | High: DataMiner nodes and databases | No |
| [Geo-redundant on-premises system](xref:Architecture_geo_redundant) | Systems that must survive the loss of a complete site | Nodes and database replicas at two sites, tie-breaker at a third location | Very high | No |
| [Distributed multi-site system](xref:Architecture_distributed_sites) | Many stations, headends, teleports, or remote locations managed centrally | One or more DataMiner nodes per site, shared storage | Medium to high, depending on the storage choice | Depends on the storage choice |
| [Multiple independent DataMiner Systems](xref:Architecture_multiple_systems) | Separated regions, business units, or security zones | Per system, optionally with element replication between systems | Multiplied by the number of systems | Depends on the systems |
| [Lab, staging, and proof-of-concept systems](xref:Architecture_lab_and_staging) | Development, testing, training, evaluation | Usually none | Low | Depends on the deployment |

> [!NOTE]
> The architectures in this section are generic examples. They do not cover every possible situation. If you are unsure which architecture suits your needs, or if you need a setup that is not described here, contact your Skyline account manager or [DataMiner Support](mailto:support@dataminer.services).

## Further reading

- To find out which architectures are commonly used in your industry, see [Architectures by market segment](xref:Architecture_market_segments).
- For network, platform, backup, and sizing guidelines that apply to all architectures, see [Architecture design considerations](xref:Architecture_design_considerations).
- For more information on the deployment and commercial models, see [DataMiner deployment models](xref:Overview_hosting) and [Commercial and deploy models summary](xref:Pricing_Commercial_Models).

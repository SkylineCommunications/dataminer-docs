---
uid: Architecture_multiple_systems
description: Find out when to use multiple independent DataMiner Systems instead of one cluster, and how to share data between them with element replication.
keywords: architecture, multiple DMS, multi-DMS, element replication, regions, security zones
---

# Multiple independent DataMiner Systems

Instead of one DataMiner System that covers everything, some organizations deploy several independent DataMiner Systems, for example one per region, per business unit, or per security zone. Each system has its own DataMiner nodes and its own storage.

> [!NOTE]
> In general, adding nodes to one DataMiner System is simpler than running several separate systems, because there is only one configuration, one storage, and one upgrade cycle to manage. Use multiple systems when there is a clear reason to keep them separate.

## When to use this architecture

Multiple independent systems are a good fit when:

- **Distance**: Sites or users are spread over different continents. One cluster with storage in one region would lead to high latency for some of them, and a single self-managed OpenSearch cluster cannot be stretched over long distances.
- **Organization**: Different business units or teams have their own operations, change processes, and upgrade schedules.
- **Security zones**: Networks are strictly separated, for example an operational technology network and a corporate network, or networks of different customers in a managed service.
- **Data residency**: Data of different regions must be stored in different jurisdictions. As each DMS uses one storage region, separate systems allow you to keep each region's data in its own location.
- **Blast radius**: You want to limit the impact of a failure, an upgrade, or a configuration error to one part of the organization.

## Architecture

```mermaid
flowchart TB
    subgraph R1["Region or business unit 1"]
        direction LR
        A1[DataMiner nodes] --- SA[(Storage)]
    end
    subgraph R2["Region or business unit 2"]
        direction LR
        B1[DataMiner nodes] --- SB[(Storage)]
    end
    subgraph Central["Optional central system"]
        C1[DataMiner nodes with<br/>replicated elements]
    end
    R1 -. Element replication .-> Central
    R2 -. Element replication .-> Central
```

Each system can follow any of the other architectures in this section. For example, a region with mainly cloud resources can use a [cloud-hosted system](xref:Architecture_cloud_hosted), while an isolated operational network uses an [on-premises system with self-managed storage](xref:Architecture_on_premises).

## Sharing information between systems

If you need a central view across systems, you have several options:

- **[Element replication](xref:Replicated_elements)**: An element from one DMS is shown in another DMS, with its parameter values and alarms. This is suitable for a limited number of key elements, such as a summary or aggregation element per system. The source and destination DMA must use the same DataMiner version, and the replicating DMS must be able to reach the source DMS (gRPC on port 443 or .NET Remoting on port 8004).
- **Dashboards and APIs**: Combine data from several systems in dashboards or external tools, for example via [dataminer.services](xref:Overview_dataminer_services) or APIs.
- **Manager of managers**: A central DataMiner System monitors the other systems in the same way it monitors any other data source, for example via connectors or alarm forwarding.

Each of these options adds connections and dependencies between the systems. Keep the integration as simple as possible.

## Redundancy

Each system has its own redundancy design. The failure of one system does not affect the others, except for the views that depend on replicated data.

## Maintenance and backups

- Each system needs its own maintenance, upgrades, backups, and monitoring.
- When you use element replication, keep the DataMiner versions of the systems aligned.
- Keep configurations such as connectors, alarm templates, and Automation scripts consistent across systems, for example via the [Catalog](xref:About_the_Catalog_app) or a CI/CD process.

## Pros and cons

| Pros | Cons |
|--|--|
| Strong isolation between regions, teams, or security zones | More systems to maintain, upgrade, and back up |
| Independent upgrade and change schedules | No single view across systems without additional integration |
| Failures and changes are contained within one system | Configuration can drift between systems |
| Each system can use the architecture that fits its location best | Element replication requires aligned DataMiner versions |

## Commonly used in

- International media groups and service providers with operations on several continents.
- Telecom and cable operators that keep separate systems for different networks or technology domains.
- Managed service providers that run separate systems for different customers.
- Government and defense organizations with strictly separated networks.

See also [Architectures by market segment](xref:Architecture_market_segments).

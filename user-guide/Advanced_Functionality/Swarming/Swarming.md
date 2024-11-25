---
uid: Swarming
---

# Swarming

As of DataMiner 10.5.1, a Swarming feature can be enabled on DataMiner Systems through which you will be able to swarm objects, such as [elements](xref:SwarmingElements) or [bookings](xref:SwarmingBookings), from one DataMiner Agent to another Agent in the same cluster.

The primary goal of Swarming is to eliminate downtime resulting from maintenance activities and provide a more polished user experience.

## Capabilities

The Swarming feature provides these capabilities:

- As a DataMiner System Admin, you are able to apply maintenance (e.g. Windows updates) on a live cluster, Agent by Agent, by temporarily moving functionalities away to other agents in the cluster.
- As a DataMiner System Admin, you are able to easily extend your system with an extra node and move functionalities from existing nodes to new nodes, so you can rebalance your cluster.
- Swarming makes it possible to recover functionalities from failing nodes by moving activities hosted on that node to the remaining nodes.

In a later iteration, the Swarming feature will also be able to assist in making rolling DataMiner software updates on live clusters possible, with limited downtime of specific functionality.

> [!NOTE]
>
> - The above capabilities are possible with limited downtime and as long as there is spare capacity. 
> - Initial versions have limitations: some DataMiner functionality is not included yet.
> - Swarming is not available in DataMiner Systems with a [storage per DMA setup](xref:Configuring_storage_per_DMA) (Cassandra or MySQL).
> - Swarming is not available in DataMiner Systems with [Failover](xref:About_DMA_Failover).
> - Swarming is not available in DataMiner Systems where the [*LegacyReportsAndDashboards* soft-launch option](xref:Overview_of_Soft_Launch_Options#legacyreportsanddashboards) is enabled.

DataMiner Swarming is currently limited to [basic elements](xref:SwarmingElements) (see [limitations](xref:SwarmingEnable#support)) and [bookings](xref:SwarmingBookings) (behind **soft launch**).

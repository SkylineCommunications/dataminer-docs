---
uid: Swarming
---

# Swarming

From DataMiner 10.5.1/10.6.0 onwards<!-- RN 41490 -->, you can enable the Swarming feature in a DataMiner System in order to be able to swarm objects, such as [elements](xref:SwarmingElements) or [bookings](xref:SwarmingBookings), from one DataMiner Agent to another Agent in the same cluster. Prior to this, this feature is available in preview if the *Swarming* [soft-launch option](xref:SoftLaunchOptions) is enabled.

The primary goal of Swarming is to eliminate downtime resulting from maintenance activities and provide a more polished user experience.

Note that when Swarming is enabled, this will result in some major changes to the DataMiner configuration:

- Alarm identifiers will be generated on a per-element basis instead of per Agent to make them unique within the cluster. Because of this change, you will need to make sure [your system is prepared](xref:SwarmingPrepare) before you can enable Swarming.

- Element configuration will be stored in the cluster-wide database instead of in the element XML files on the disk of the DataMiner Agent hosting each element.

> [!IMPORTANT]
> Once the element configuration has been moved from disk to database, there is no good way to revert this change, which means that if you were to disable Swarming again, you would lose all your elements, leaving your DMS with a lot of lingering references to non-existing elements. For instructions on how to disable Swarming and **partially** recover your elements, see [Partially rolling back Swarming](xref:SwarmingRollback).

## Capabilities

The Swarming feature provides these capabilities:

- As a DataMiner System Admin, you can apply maintenance (e.g. Windows updates) on a live cluster, Agent by Agent, by temporarily moving functionalities away to other Agents in the cluster.

- As a DataMiner System Admin, you can easily extend your system with an extra node and move functionalities from existing nodes to new nodes, so you can rebalance your cluster.

- Swarming makes it possible to recover functionalities from failing nodes by moving activities hosted on such a node to the remaining nodes.

In a later iteration, the Swarming feature will also be able to assist in making rolling DataMiner software updates on live clusters possible, with limited downtime of specific functionality.

> [!NOTE]
> The above capabilities are possible with limited downtime and as long as there is spare capacity.

## Limitations

Some functionality is not supported with the Swarming feature. These are the most important limitations at the moment:

- Swarming is not available in DataMiner Systems with a [storage per DMA setup](xref:Configuring_storage_per_DMA) (Cassandra or MySQL).

- Swarming is not available in DataMiner Systems with [Failover](xref:About_DMA_Failover).

- Swarming is not available in DataMiner Systems where the [*LegacyReportsAndDashboards* soft-launch option](xref:Overview_of_Soft_Launch_Options#legacyreportsanddashboards) is enabled.

- Swarming is currently limited to [basic elements](xref:SwarmingElements). For [bookings](xref:SwarmingBookings), swarming is supported if the *BookingSwarming* [soft-launch option](xref:SoftLaunchOptions) is enabled.

> [!NOTE]
> [Prerequisite checks](xref:EnableSwarming#running-a-prerequisites-check) are in place to prevent the enabling of the Swarming feature when non-supported objects are present. Where possible, you will also be prevented from configuring or creating these on a Swarming-enabled system.

Below you can find a complete overview of the differences between a system using DataMiner 10.5.1 or higher with or without Swarming.

|                                                  | 10.5.1+&nbsp; systems without Swarming | 10.5.1+ systems with Swarming  |
|--------------------------------------------------|----------------------------------------|--------------------------------|
| Element configuration                            | On disk (element.xml)                  | In database                    |
| Alarm IDs                                        | Per DataMiner Agent                    | Per element                    |
| Database per DMA                                 | Supported                              | Not supported                  |
| Scripts & QActions using legacy alarm references | Supported                              | Not supported                  |
| Legacy Reports & Dashboards                      | Supported                              | Not supported                  |
| Failover                                         | Supported                              | Not supported                  |
| Offload database                                 | Supported                              | Supported as of 10.5.2 <!-- RN 41706 --> but not swarmable* |
| Contributing bookings                            | Supported                              | Not supported*                 |
| SLA elements                                     | Supported                              | Supported but not swarmable*   |
| Enhanced services                                | Supported                              | Supported** but not swarmable* |
| Spectrum elements                                | Supported                              | Supported but not swarmable*   |
| Redundancy group elements                        | Supported                              | Supported but not swarmable*   |
| DVE and virtual function child and parent elements            | Supported                              | Supported but not swarmable*   |
| EPM elements                                     | Supported                              | Supported but not swarmable*   |
| Elements polling localhost                       | Supported                              | Supported but not swarmable    |
| Elements with element connections                | Supported                              | Supported but not swarmable*   |
| Smart-serial elements in server mode             | Supported                              | Supported but not swarmable    |
| Elements receiving SNMP traps                    | Supported                              | Supported but not swarmable    |

(*) To be added in later versions.

(**) Enhanced service connectors may [need to be adjusted](xref:SwarmingPrepare).

## Required user permissions

To enable the Swarming feature, the [Admin Tools](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools) user permission is required.

Once the feature has been enabled, users will need the [Swarming](xref:DataMiner_user_permissions#modules--swarming) user permission to trigger any swarming actions. To swarm an element, users will also need config rights on the element.

Users that have the [Import DELT](xref:DataMiner_user_permissions#general--elements--import-delt) and [Export DELT](xref:DataMiner_user_permissions#general--elements--import-delt) user permissions will automatically also get the *Swarming* user permission when DataMiner is upgraded from a version that does not support Swarming to a version that does support it.

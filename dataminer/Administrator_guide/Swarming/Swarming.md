---
uid: Swarming
---

# Swarming

With the Swarming feature, you can easily **swarm DataMiner objects from one DataMiner Agent to another Agent in the same cluster**. When this feature is enabled, the DataMiner objects are no longer linked to a specific DMA, but instead their information is stored in the database. This means that switching them over to a different DMA, or "swarming" them, is suddenly very easy.

![DataMiner objects stored in the database](~/dataminer/images/Swarming_database.png)

Swarming can be useful in many situations:

- As a System Administrator, you can **eliminate downtime** resulting from maintenance activities for a more polished user experience, by carrying out the maintenance activities (e.g. Windows updates) on a live cluster, Agent by Agent, by temporarily moving functionalities away to other Agents in the cluster.

  ![Maintenance without downtime](~/dataminer/images/Swarming_maintenance.png)

- With swarming, **load balancing** is easy. You can easily move elements between nodes to rebalance your cluster without effort, for example when you have added an extra node or when you want to reduce the load on a specific node.

  ![Load balancing using Swarming](~/dataminer/images/Swarming_load_balance.png)

- If a node in a cluster fails, you can quickly recover functionalities from the failing node by moving activities hosted on that node to the remaining nodes.

- In a later iteration, the Swarming feature will also be able to assist in making rolling DataMiner software updates on live clusters possible, with limited downtime of specific functionality.

For all of these capabilities, it is important that the different nodes in a cluster have spare capacity so that elements can be moved to them. For optimal ease of use of the Swarming feature, we therefore recommend deploying DataMiner in [subscription mode](xref:Pricing_Commercial_Models) and using as many DataMiner nodes as necessary to make sure there is plenty of capacity to move elements whenever needed.

Swarming can be enabled from DataMiner 10.5.1/10.6.0 onwards.<!-- RN 41490 --> Note that when it is enabled, this will result in some major changes to the DataMiner configuration:

- Alarm identifiers will be generated on a per-element basis instead of per Agent to make them unique within the cluster.
- Element configuration will be stored in the cluster-wide database instead of in the element XML files on the disk of the DataMiner Agent hosting each element.

> [!IMPORTANT]
> If you decide to [roll back Swarming](xref:SwarmingRollback) again, you will need to restore a backup to get the element XML files back. Any changes that have been implemented to elements after you enabled Swarming will be lost. As a consequence, the sooner you decide to roll back, the smaller the impact of the rollback will be.

## Upcoming features

At present, swarming is mainly supported for [basic elements](xref:SwarmingElements).

- For DVEs and virtual function child and parent elements, swarming is supported from DataMiner 10.5.11/10.6.0 onwards.<!-- RN 43793 --> Note that child elements cannot be swarmed directly; they follow the parent element.
- For [bookings](xref:SwarmingBookings), swarming is supported if the *BookingSwarming* [soft-launch option](xref:SoftLaunchOptions) is enabled.

In addition, we are working on adding the following functionality soon:

- Support for swarming services.
- Support for swarming of special elements: SLA elements, enhanced services, spectrum elements, redundancy group elements, EPM elements, and elements with element connections.
- Support for automatic switchover of elements in case issues are detected.

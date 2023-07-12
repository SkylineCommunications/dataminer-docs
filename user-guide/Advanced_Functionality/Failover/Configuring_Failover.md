---
uid: Configuring_Failover
---

# Configuring Failover

In a DataMiner System, a DMA can be linked to an identical backup DMA. That backup DMA will then be kept synchronized but offline, and will take over (either manually or automatically) when the primary DMA fails.

The following sections contain more information on configuring Failover:

- [Preparing the two DataMiner Agents](xref:Preparing_the_two_DataMiner_Agents)

- [Failover configuration in Cube](xref:Failover_configuration_in_Cube)

- [Advanced Failover options](xref:Advanced_Failover_options)

- [DataMiner Failover on Amazon Web Services](xref:Failover_AWS)

> [!NOTE]
> Failover is always one-to-one. A backup DMA can only have one primary DMA.

> [!TIP]
> See also: [Preferred configuration using virtual IP addresses (best practice)](xref:Preferred_configuration_using_virtual_IP_addresses__best_practice)

---
uid: Configuring_Failover
---

# Configuring Failover

In a DataMiner System, a DMA can be linked to an identical backup DMA. That backup DMA will then be kept synchronized but offline, and will take over (either manually or automatically) when the primary DMA fails.

> [!NOTE]
> Failover is always one-to-one. A backup DMA can only have one primary DMA.

> [!TIP]
> See also: [Preferred configuration using virtual IP addresses (best practice)](xref:Preferred_configuration_using_virtual_IP_addresses__best_practice)

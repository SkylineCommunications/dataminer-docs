---
uid: About_DMA_Failover
---

# About DMA Failover

When you team up a particular DataMiner Agent with a backup DMA, a virtual DMA team will be created. Two new IP addresses will be assigned to this virtual DMA team, which will be used as the virtual IP addresses of the online DMA in the Failover pair. Alternatively, from DataMiner 10.2.0/10.1.8 onwards, a hostname can be assigned to the virtual DMA team instead.

Within a DMA team, the two team members will act as peers. In other words, they will not act as primary DMA versus secondary DMA, but as active/online DMA versus passive/backup DMA.

By default, all synchronization traffic between the active and the passive team member will pass via the corporate network. If necessary, both team members can also be equipped with an additional network card.

The decision when to switch from the active to the passive DMA can be taken either by a person (i.e. manual Failover) or by the DMAs themselves (i.e. automatic Failover). In the latter case, the two DMAs in the team will check each other’s status by exchanging heartbeats.

> [!NOTE]
> Any given DMA can only be part of one virtual DMA team. In other words, one DMA cannot act as a backup for more than one DMA.

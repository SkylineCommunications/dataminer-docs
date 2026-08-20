---
uid: Configuring_Failover
description: "Learn how to configure Failover in DataMiner by linking a DMA to a synchronized backup DMA that takes over manually or automatically."
---

# Configuring Failover

In a DataMiner System, a DMA can be linked to an identical backup DMA. That backup DMA will then be kept synchronized but offline, and will take over (either manually or automatically) when the primary DMA fails.

> [!NOTE]
> Failover is always one-to-one. A backup DMA can only have one primary DMA.

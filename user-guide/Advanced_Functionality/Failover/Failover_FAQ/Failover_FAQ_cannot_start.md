---
uid: Failover_FAQ_cannot_start
---

# What should I do if one of the Agents in a Failover pair cannot be started or restarted?

When a Failover configuration is set up and you are using self-managed storage with a Cassandra cluster per DMA (which is not recommended), one of the Cassandra instances is automatically designated as the master seed node. When the master seed node is not available, it is not possible to restart or start the database of the other DMA.

Therefore, if starting or restarting one of the Agents in a Failover pair fails, first make sure the other Agent is online and available.

> [!NOTE]
> We recommend switching to [Storage as a Service](xref:STaaS) instead.

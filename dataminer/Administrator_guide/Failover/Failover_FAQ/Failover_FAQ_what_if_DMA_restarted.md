---
uid: Failover_FAQ_what_if_DMA_restarted
---

# What happens if one of the DMAs is restarted in a Failover setup?

If the **offline** DMA is restarted:

- In the Alarm Console of the online DMA, a “Failing Heartbeat Path” notice will appear during the restart.

If the **online** DMA is restarted:

- If the offline DMA detects several failing heartbeats because the restart takes a long time, an automatic switchover will occur.

  This depends on the duration of the restart and on the heartbeat settings.

  For more information on the heartbeat settings, see [Heartbeats](xref:Advanced_Failover_options#heartbeats).

- After the restart, if the online DMA cannot connect to the other DMA, it will go back online automatically.

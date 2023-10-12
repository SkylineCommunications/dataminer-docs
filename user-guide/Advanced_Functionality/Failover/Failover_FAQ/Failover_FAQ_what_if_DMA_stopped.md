---
uid: Failover_FAQ_what_if_DMA_stopped
---

# What happens if one of the DMAs is stopped in a Failover setup?

If the **online** DMA is stopped:

- The other, offline DMA will detect heartbeat path failures and will go online.

- In the Alarm Console of the other DMA a notice will appear, indicating that heartbeat paths and sync connection are failing.

- In the *Status* dialog box, you will see that the DMA is *Unreachable*, and that Heartbeat and DB Sync are *Failing*.

If the **offline** DMA is stopped:

- The online DMA will keep working as normal.

- In the Alarm Console of the online DMA a notice will appear, indicating that heartbeat paths and sync connection are failing.

- In the *Status* dialog box, you will see that the offline DMA is *Unreachable*, and that Heartbeat and DB Sync are *Failing*.

> [!NOTE]
> This is also what happens when a DMA shuts down unexpectedly, for instance because of a power failure.

> [!TIP]
> See also: [Viewing Failover information](xref:Viewing_Failover_information)

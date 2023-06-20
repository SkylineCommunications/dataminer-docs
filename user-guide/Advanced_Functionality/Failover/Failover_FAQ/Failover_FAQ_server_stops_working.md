---
uid: Failover_FAQ_server_stops_working
---

# What happens when the database server on one of the DMAs stops working?

If the database server on the **online** DMA stops working:

- There will be no automatic switchover to the offline DMA.

- Runtime errors or notices might show up on the online DMA, indicating a database problem.

- In the *Status* dialog box, the database will get the status *Failing*.

- Database data will still be gathered, and will be inserted into the database once it becomes available again.

If the database server on the **offline** DMA stops working:

- This problem will not immediately be visible from the online DMA.

- The *Failover* dialog box will indicate that the offline DMA is in an error state (red LED).

- In the *Status* dialog box, the database of the offline DMA will get the status *Failing*.

- Database data will still be forwarded, but the data will only be inserted into the database of the offline DMA when that database is accessible again.

> [!TIP]
> See also: [Viewing Failover information](xref:Viewing_Failover_information)

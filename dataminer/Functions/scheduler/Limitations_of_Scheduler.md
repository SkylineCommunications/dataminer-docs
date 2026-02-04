---
uid: Limitations_of_DataMiner_Scheduler
---

# DataMiner Scheduler Limitations

The Scheduler module can handle a large number of tasks, but there are practical limits to ensure reliability. The following guidelines are based on system testing and represent the recommended maximums.

## Task Capacity

- Up to **100 tasks** can start at the **same time, per DMA**. 
- Up to **3000 tasks** can be configured **per DMA** in total.

## Additional Notes

- These limits are **recommendations**. They are *not* enforced by the Scheduler module.
- Actual capacity depends on system performance and may be higher on more capable systems.
- The **3000‑task total** includes all tasks, regardless of:
  - Their enabled/disabled status.
  - Whether their trigger time is in the past or the future.
- **Recurring tasks** (e.g. daily or weekly schedules) count as **one task**, regardless of how many times they execute.
``

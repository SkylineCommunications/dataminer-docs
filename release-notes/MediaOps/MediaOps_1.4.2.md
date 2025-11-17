---
uid: MediaOps_1.4.2
---

# MediaOps 1.4.2

> [!NOTE]
> This version requires DataMiner 10.5.9/10.6.0 or higher. In addition, the [GQI DxM](xref:GQI_DxM) must be installed.

## Changes

### Enhancements

#### Scheduling: Improved sort order of jobs on Ops Board page [ID 44057]

In the Scheduling app, the default sort order on the *Ops Board* page has been improved. The following sorting will now be applied:

- Active jobs: By job end time (then by ID).
- Upcoming jobs: By job start time (then by ID).
- Completed jobs: By job end time in descending order (then by ID).
- All jobs: First all running jobs are sorted by end time (then by ID), then all upcoming jobs are sorted by start time (then by ID), and finally all completed jobs are sorted by end time in descending order (then by ID).

This enhancement also prevents unexpected changes to the order of the jobs on the *Ops Board* page when an action is executed that influences the timing of a job.

#### Scheduling: Nodes table maximize button removed from Edit job panel [ID 44085]

In the Scheduling app, the button to maximize the Nodes table has been removed from the *Edit job* panel, as this functionality was not used and did not work as expected.

#### Scheduling: Number of active query sessions reduced [ID 44113]

Through an improvement of the *Get Filter Status* data source, the number of active query sessions for each user interacting with the Scheduling app has been reduced. During basic operations, this will reduce the number of active query sessions to about a third of what was previously needed.

### Fixes

#### Scheduling: Adding a resource with linked resource pool to a confirmed or running job could cause an empty node [ID 44030]

When a resource was added to a confirmed or running job, and that resource was part of a resource pool that had a linked resource pool using manual resource selection or without available resources, it could occur that this resource was not added as expected. This could lead to a confirmed or running job with an empty node.

To prevent this issue, when a resource is added to a confirmed or running job, any linked pools will now no longer be added. A pop-up message will inform the user of which pools were not added.

#### Resource Studio: Resource error details not shown [ID 44036]

If a resource had an error, it was not possible to view the details of that error in the Resource Studio app. This issue has now been resolved.

#### Scheduling: No longer possible to swap resources through drag and drop [ID 44082]

Starting from MediaOps 1.4.0, it was no longer possible to swap resources by dragging and dropping them from the *Resource View* page of the Scheduling app.

---
uid: MediaOps_1.4.1
---

# MediaOps 1.4.1

## Prerequisites

* DataMiner version 10.5.9 or higher
* [GQI DxM](xref:GQI_DxM)

## Changes

### Enhancements

#### Exception thrown when timing of completed job is adjusted [ID 43847]

When a job is in the state *Completed*, *Canceled*, *Ready For Invoice*, or *Invoiced*, and an attempt is made to adjust the timing of the job, an InvalidOperationException will now be thrown, as this is not allowed in such cases.

#### Scheduling: Prefetching of data disabled to reduce memory usage [ID 43901]

To reduce memory usage, data will now no longer be prefetched in the Scheduling app. Previously, this prefetch was implemented to improve performance, but when queries were canceled before data was returned to the client, this could lead to a noticeable memory buildup especially when multiple users were using the system.

### Scheduling: Configuration status no longer shows green checkmark if no parameters are assigned [ID 43904]

Up to now, when a configuration was created for a node in the nodes table of the *Edit job* panel, a green check mark was shown for the configuration status. However, because this might be confusing when no parameters have been configured in the node configuration, such a case will now be visualized as if no configuration had been created.

### Fixes

#### MediaOps log files not included in SLLogCollector package [ID 43791]

When logging was collected using the SLLogCollector tool, the MediaOps logging was not included.

#### Scheduling: Lock on job not removed after duplication [ID 43915]

When a locked job was duplicated, the user who had a lock on the original job also had a lock on the duplicated job, which should not be the case and was not clear to the user. This could cause confusion when someone else tried to edit the duplicated job.

#### Scheduling: Jobs not locked when opening the Edit job panel [ID 43905]

With the release of MediaOps 1.4.0, jobs were no longer locked automatically when the *Edit job* panel was opened. Now opening the panel will again cause jobs to be automatically locked.

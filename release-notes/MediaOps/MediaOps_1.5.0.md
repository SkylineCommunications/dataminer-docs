---
uid: MediaOps_1.5.0
---

# MediaOps 1.5.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

#### Resource Studio: Improved feedback and visibility when deprecating or restoring multiple resources [ID 43804]

On the *Resources* page of the Resource Studio app, when a large number of resources are deprecated or restored, a loading indicator is now displayed, providing feedback on the action in progress. In addition, when you start an action to deprecate or restore multiple resources, you will now first be asked to confirm the action.

#### Exception thrown when timing of completed job is adjusted [ID 43847]

When a job is in the state *Completed*, *Canceled*, *Ready For Invoice*, or *Invoiced*, and an attempt is made to adjust the timing of the job, an InvalidOperationException will now be thrown, as this is not allowed in such cases.

#### Scheduling: Prefetching of data disabled to reduce memory usage [ID 43901]

To reduce memory usage, data will now no longer be prefetched in the Scheduling app. Previously, this prefetch was implemented to improve performance, but when queries were canceled before data was returned to the client, this could lead to a noticeable memory buildup especially when multiple users were using the system.

### Fixes

#### MediaOps log files not included in SLLogCollector package [ID 43791]

When logging was collected using the SLLogCollector tool, the MediaOps logging was not included.

#### Scheduling: Action buttons missing in Edit Job panel after reverting job status to Tentative [ID 43808]

When the status of a job was reverted from Confirmed to Tentative, it could occur that action buttons for the job were no longer displayed in the Edit Job panel.

#### Scheduler: Lock on job not removed after duplication [ID 43915]

When a locked job was duplicated, the user who had a lock on the original job also had a lock on the duplicated job, which should not be the case and was not clear to the user. This could cause confusion when someone else tried to edit the duplicated job.

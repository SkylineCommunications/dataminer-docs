---
uid: MediaOps_1.3.1
---

# MediaOps 1.3.1 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## New features

#### Pre-roll and post-roll configuration for jobs [ID 43035]

When a job is set up, either manually or automatically, operators or orchestration scripts require some time to do the setup or to take down the job or workflow. To ensure that resources are reserved for long enough before the start of the job and after the end of a job, it is now possible to configure a pre-roll and/or post-roll period.

#### Possibility to delete completed jobs [ID 43036]

It is now possible to delete completed MediaOps jobs.

## Changes

### Enhancements

#### Log files limited to maximum of 10 MB [ID 43032]

To improve performance and keep the size of log collector packages under control, the maximum size of the MediaOps log files has now been reduced from 100 MB to 10 MB.

#### Resource (pool) creation now happens via interactive Automation scripts [ID 43033]

Creating and editing resources and resource pools in the MediaOps apps will now be done with interactive Automation scripts instead of form components. This way, validation can be performed directly in the UI before the resources or resource pools are created or updated, and resources and resource pools can now be created directly in the complete state.

### Fixes

#### Resource Studio: Downgrading resource concurrency could cause sync issue [ID 43031]

When the concurrency of a resource was downgraded, this could result in conflicts for future jobs or bookings, which could in turn cause an incorrect concurrency to be visualized in Resource Studio, because the concurrency could not be lowered in DataMiner. Now when changing the concurrency will cause a conflict, the user will be prompted to confirm whether to proceed and jobs or bookings may be pushed into quarantine as a result.

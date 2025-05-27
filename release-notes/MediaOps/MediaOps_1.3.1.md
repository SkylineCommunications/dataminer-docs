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

#### Ability to set job back from confirmed to tentative [ID 43042]

When a job has been confirmed, it is now possible to return it to the tentative state.

## Changes

### Enhancements

#### Log files limited to maximum of 10 MB [ID 43032]

To improve performance and keep the size of log collector packages under control, the maximum size of the MediaOps log files has now been reduced from 100 MB to 10 MB.

#### Resource (pool) creation now happens via interactive Automation scripts [ID 43033]

Creating and editing resources and resource pools in the MediaOps apps will now be done with interactive Automation scripts instead of form components. This way, validation can be performed directly in the UI before the resources or resource pools are created or updated, and resources and resource pools can now be created directly in the complete state.

#### Performance improvements [ID 43037]

The following performance improvements have been implemented:

- When the job edit panel was opened, whenever there was an update to any existing job, the job details were retrieved for the job in the panel. This could cause performance issues in systems with many job updates. Now only changes to the job in the panel will cause the job details to be retrieved again.
- When certain fields (e.g. the organization) were not filled in, it could occur that requests were sent to the database with an empty field, which would fail. To make sure such unnecessary requests are no longer sent, the ID will now be validated before a request is sent.

#### Compatibility with SRM framework [ID 43038]

A custom quarantine script is now included in the MediaOps solution, making it compatible with the SRM framework. This means that you can now deploy both MediaOps and SRM on the same system.

#### Workflow Designer: 'Include in booking' option removed [ID 43039]

the *Include in booking* option has now been removed from the Workflow Designer app, as it could cause confusion for resources that were present in the job but that were not reserved.

#### GQI DxM now required [ID 43040]

To improve performance, the MediaOps Solution now requires the use of the [GQI DxM](xref:GQI_DxM).

### Fixes

#### Resource Studio: Downgrading resource concurrency could cause sync issue [ID 43031]

When the concurrency of a resource was downgraded, this could result in conflicts for future jobs or bookings, which could in turn cause an incorrect concurrency to be visualized in Resource Studio, because the concurrency could not be lowered in DataMiner. Now when changing the concurrency will cause a conflict, the user will be prompted to confirm whether to proceed and jobs or bookings may be pushed into quarantine as a result.

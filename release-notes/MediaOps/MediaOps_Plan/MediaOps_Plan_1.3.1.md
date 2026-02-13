---
uid: MediaOps_Plan_1.3.1
---

# MediaOps 1.3.1

> [!NOTE]
> This version requires DataMiner 10.5.7/10.6.0 or higher. In addition, the [GQI DxM](xref:GQI_DxM) must be installed.

## New features

#### Scheduling: Pre-roll and post-roll configuration for jobs [ID 43035]

When a job is set up in the Scheduling app, either manually or automatically, operators or orchestration scripts require some time to do the setup or to take down the job or workflow. To ensure that resources are reserved for long enough before the start of the job and after the end of a job, it is now possible to configure a pre-roll and/or post-roll period.

#### Scheduling: Possibility to delete completed jobs [ID 43036]

In the Scheduling app, it is now possible to delete completed MediaOps jobs.

#### Scheduling: Job and node properties can now be divided into sections [ID 43041]

On the *App Configuration* page of the Scheduling app, you can now divide job and node properties into sections. Within a property section, you can order the properties to your preference.

#### Scheduling: Ability to set job back from confirmed to tentative [ID 43042]

When a job has been confirmed, you can now return it to the tentative state from the job edit panel.

#### Scheduling: Recurring jobs [ID 43043]

Via the context menu on a job, it is now possible to convert the job into a recurring job. This will only be possible for jobs that have not started yet and only if the state of the jobs is draft or tentative.

Once a job has been converted into a recurring job, it is still possible to update each job individually, but it is not possible to update all jobs at once. This means that it is best to make sure a job is fully configured before you convert it into a recurring job.

#### Scheduling: New button to copy job edit panel URL to clipboard [ID 43059]

In the header bar of the job edit panel, a button is now available that allows you to copy the URL of the panel to the clipboard.

## Changes

### Enhancements

#### Log files limited to maximum of 10 MB [ID 43032]

To improve performance and keep the size of log collector packages under control, the maximum size of the MediaOps log files has now been reduced from 100 MB to 10 MB.

#### Resource Studio: Resource (pool) creation now happens via interactive Automation scripts [ID 43033]

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

#### Scheduling: Action icons temporarily disabled while action is being executed [ID 43045]

While actions are being executed in the Scheduling app, the icons that execute those actions (e.g. the pencil icon to open the edit job panel and the icons in the edit job panel) will now temporarily be disabled. This will prevent users from clicking action items multiple times while actions are still ongoing.

#### Fit to view option now enabled for optimal screen usage [ID 43259]

On all main pages of the MediaOps apps, the *Fit to view* option has now been enabled, ensuring optimal usage of the available space on the screen. This way, tables and timeline components will be able to take up more space on screens with larger resolutions (e.g. 4K).

#### Resource Studio: Resource property values limited to 150 characters [ID 43269]

To prevent possible reduced performance when large text values are saved for resource properties, updates to resource properties are now limited to a maximum of 150 characters.

#### Scheduling: Job edit panels now larger [ID 43270]

To ensure optimal usage of the available space on the screen, the job edit panels in the Scheduling app now have a width of 90% instead of the previous 75%. In addition, the height of the workflow section has been increased to allow for larger workflows.

### Fixes

#### Resource Studio: Downgrading resource concurrency could cause sync issue [ID 43031]

When the concurrency of a resource was downgraded, this could result in conflicts for future jobs or bookings, which could in turn cause an incorrect concurrency to be visualized in Resource Studio, because the concurrency could not be lowered in DataMiner. Now when changing the concurrency will cause a conflict, the user will be prompted to confirm whether to proceed and jobs or bookings may be pushed into quarantine as a result.

#### Scheduling: Duplicating a job did not duplicate the node configurations [ID 43189]

When a job was duplicated in the Scheduling app, the new job still used the same node configurations as the original job instead of a duplicate of the configurations.

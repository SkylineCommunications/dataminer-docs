---
uid: MediaOps_1.5.0
---

# MediaOps 1.5.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires DataMiner 10.5.11/10.6.0 or higher. In addition, the [GQI DxM](xref:GQI_DxM) must be installed.

## New features

#### Scheduling: Ability to pin time range quick picks [ID 43938]

On the *Job View* and *Resource View* pages of the Scheduling app, you can now pin quick picks for all users in the time range selector for the timeline.

#### Orchestration scripts [ID 44347]

Orchestration scripts have been implemented in the MediaOps Solution:

- From Resource Studio, you can define orchestration settings on pools. This will define what automated actions have to be triggered when such a pool is used in a workflow or job. When a node is added to a workflow or job, the orchestration settings defined on the pool will be copied to the node.

- From Workflow Designer, you can define orchestration settings for workflows and nodes of workflows. This will define the automated actions that have to be triggered when such a workflow is used. When a job is created from a workflow, the orchestration settings defined on the workflow and the nodes within will be copied to the job.

- From Scheduling, you can define orchestration settings for jobs and nodes of jobs. The orchestration settings define the automated actions that will trigger at the different events of the job (pre-roll start, pre-roll stop, post-roll start, and post-roll stop). When no pre-roll is defined, then the pre-roll start and pre-roll stop will be triggered sequentially if both are defined (similar for post-roll). If an orchestration script is defined for the job for a specific event, then it is up to that script to trigger orchestration scripts defined on nodes and connections. If no orchestration script is defined for the job for a specific event, then all node and connection orchestration scripts will be executed automatically for the corresponding event.

As orchestration scripts have more flexibility than workflow execution scripts, workflow execution scripts have now been marked as obsolete. If they were already configured with previous versions of MediaOps, they will still be triggered, to allow a smooth transition to orchestration scripts. You can disable them for workflows, but it will no longer be possible to change or enable workflow execution scripts. Orchestration scripts should be used instead.

#### Resource pool categories [ID 44534]

It is now possible to categorize resource pools using the new *Categories* app. This way, when operators select a category in the Scheduling app, they will only see the pools in that specific category.

To create categories for resource pools, deploy the Categories app from the DataMiner Catalog. In the app, first select the *Resource Pools* scope and then add categories into the scope. After you have created the categories, you can edit a pool and assign it to a category. Note that while the Categories app allows the creation of multiple levels of subcategories, it is not possible to use a category that has a parent for resource pools.

## Changes

> [!NOTE]
> This release also includes the enhancements and fixes of the 1.4.x releases.

### Enhancements

#### Resource Studio: Improved feedback and visibility when deprecating or restoring multiple resources [ID 43804]

On the *Resources* page of the Resource Studio app, when a large number of resources are deprecated or restored, a loading indicator is now displayed, providing feedback on the action in progress. In addition, when you start an action to deprecate or restore multiple resources, you will now first be asked to confirm the action.

#### Message when user has insufficient rights [ID 43942]

When users do not have the necessary permissions to execute a certain action, a clear message will now be shown to inform them of this. Previously, only a stack trace was shown.

#### Resource Studio: New resource icons [ID 44330]

A new LNB, SSPA, and transponder icon have been added to the list of available resource icons in the Resource Studio app.

### Fixes

#### Scheduling: Action buttons missing in Edit Job panel after reverting job status to Tentative [ID 43808]

When the status of a job was reverted from Confirmed to Tentative, it could occur that action buttons for the job were no longer displayed in the Edit Job panel.

#### Scheduler: Lock on job not removed after duplication [ID 43915]

When a locked job was duplicated, the user who had a lock on the original job also had a lock on the duplicated job, which should not be the case and was not clear to the user. This could cause confusion when someone else tried to edit the duplicated job.

#### Scheduling: Recurring jobs not saved correctly with daylight saving time [ID 44109]

When recurring jobs were created, daylight saving time was not correctly applied.

#### Scheduling: Errors on job copied in duplicated job [ID 44303]

When a job that had errors (for example because it went into the quarantined state) was duplicated, the errors were copied over to the new job. This will no longer occur.

#### Scheduling: Incorrect status message when canceling recurrence [ID 44304]

When a recurrence from the Scheduling app was canceled, previously this displayed the incorrect status "Updating Series...". Now the correct status "Canceling Series..." will be displayed instead.

### Resource Studio: Capability, capacity, and property title boxes not displayed correctly when multiple rows are selected [ID 44355]

When multiple rows were selected on the Resources page of Resource Studio, the title boxes for capabilities, capacities, and properties were not displayed correctly.

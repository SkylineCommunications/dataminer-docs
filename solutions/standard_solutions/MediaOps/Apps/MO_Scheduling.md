---
uid: MO_Scheduling
---

# Scheduling

The scheduling app allows you to manage and configure all jobs in the system. Using a job, users can easily schedule specific resources, request a resource for a given pool of resources, schedule an entire workflow, or a combination of each of the options. At start and at end of the job a script can be triggered to allow you to do orchestration. When a resource is added to a job it will be reserved for the time span of the job except if the job is still in draft state. All the possible states are described in the [Job States](xref:MO_S_Job_States). [Configuration parameters](xref:MO_S_Configuration) can be added on job and node level. Configuration parameters are intended to provide information on how the job can be (automatically) commissioned and decommissioned. In addition to configuration parameters, properties can be used on job and node level for additional information. To avoid that any misconfiguration could lead to a job failing during the orchestration process, there is a [validation mechanism](xref:MO_S_Job_Validation) that will validate all jobs in the near future.

ADD SCREENSHOT

## Obsolete?

TBD: Should we keep a list of pages in the apps?

The following pages are available in the app:

- [*Jobs View*](#job-view)
- [*Resource View*](#resource-view)
- [*Ops Board*](#ops-board)
- [*Search Jobs*](#search-jobs)
- [*Apps configuration*](#apps-configuration)
- [*About*](#about)

## Job View

From the Job View page you can keep track of all Jobs in the system on a timeline. With the filtering options provided you can focus on the jobs that are relevant to you. Creating new jobs can be done by clicking the 'New' button above the timeline component. To update existing jobs you can use the 🖉 icon to open the [Edit Job Panel](#edit-job-panel). To avoid conflicts when multiple people need to update the same job, there is an [automatic locking mechanism](xref:MO_S_Job_Locking) in place.

## Resource View

The Resource View page shows the Jobs for the resources in a specific resource pool. When the resource is used within a Job, it will be visualized in the row of that resource in the timeline component. From this view it is easy to swap between resources in the same resource pool: just drag the job from that resource's row to another resource's row.

## Ops Board

The Ops Board shows the Jobs in the system in a list view, filtered on the state of the job (Active, Upcoming, Completed or All). From the Actions column, you can edit, duplicate or start/stop the job easily.

## Search Jobs

The Search Jobs page gives you the tools to find any job back in the system.

## Apps Configuration

On the Apps Configuration page you can configure how the ID of the jobs should look like. Note that this ID is a user-friendly identifier, the real ID is a GUID which is not visible to the user.

## About

The About page provides information on the version of MediaOps package.
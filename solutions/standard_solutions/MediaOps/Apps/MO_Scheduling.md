---
uid: MO_Scheduling
---

# Scheduling

The scheduling app allows users to build up a schedule of Jobs, representing a planned activity that will have to be executed. With a Job, users can easily schedule specific resources, request a resource from a given pool of resources or even schedule an entire workflow for this planned activity. The system will make sure that, in the background, the availability of all resources is managed so that no resource conflicts occur. 

Next to that administrative metadata can be added to a Job, such as a description, and owner or the organization for which the Job will be carried out. It's also possible to add technical information on how the Job should be executed. This can be done by describing a 'workflow', detailing how the resources in the Job should be interconnected, and by specifying configuration parameters on a Job or on an individual resource in the Job.

The following pages are available in the app:

- [*Jobs View*](#job-view)
- [*Resource View*](#resource-view)
- [*Ops Board*](#ops-board)
- [*Search Jobs*](#search-jobs)
- [*Apps configuration*](#apps-configuration)
- [*About*](#about)

## Job View

From the Job View page you can keep track of all Jobs in the system on a timeline. With the filtering options provided you can focus on the jobs that are relevant to you. From this page, users can create new Jobs, either [starting from scratch](xref:SCH_Create_Job#from-scratch) or [starting from a predefined workflow](xref:SCH_Create_Job#starting-from-a-predefined-workflow). To update existing jobs you can use the 🖉 icon to open the [Edit Job Panel](xref:SCH_Edit_Job). To avoid conflicts when multiple people need to update the same job, there is an [automatic locking mechanism](xref:MO_S_Job_Locking) in place.

## Resource View

The Resource View page shows the Jobs for the resources in a specific resource pool. When the resource is used within a Job, it will be visualized in the row of that resource in the timeline component. The page allows to quickly [create a Job on one specific resource](xref:SCH_Create_Job#by-selecting-a-specific-resource).
From this view, it is also easy to swap Jobs between resources in the same resource pool: just drag the Job from that resource's row to another resource's row.

## Ops Board

The Ops Board shows the Jobs in the system in a list view, filtered on the state of the job (Active, Upcoming, Completed or All). From the Actions column, you can edit, duplicate or start/stop the job easily.

## Search Jobs

The Search Jobs page gives you the tools to easily find back any job in the system. This includes also canceled Jobs, which are hidden on all other pages.

## Apps Configuration

On the Apps Configuration page you can configure how the ID of the jobs should look like. Note that this ID is a user-friendly identifier, the real ID is a GUID which is not visible to the user.

## About

The About page provides information on the version of MediaOps package.
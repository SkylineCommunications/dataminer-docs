---
uid: MO_Scheduling
---

# Scheduling

The scheduling app allows you to manage and configure all jobs in the system. Using a job, users can easily schedule specific resources, request a resource for a given pool of resources, schedule an entire workflow, or a combination of each of the options. At start and at end of the job a job/workflow execution script can be triggered to allow you to do orchestration. When a resource is added to a job it will be reserved for the time span of the job except if the job is still in draft state. All the possible states are described in the [Job States](xref:MO_S_Job_States). To avoid that any misconfiguration could lead to a job failing during the orchestration process, there is a [validation mechanism](xref:MO_S_Job_Validation) that will validate all jobs in the near future.

The following pages are available in the app:

- [*Jobs View*](#job-view)
- [*Resource View*](#resource-view)
- [*Ops Board*](#ops-board)
- [*Search Jobs*](#search-jobs)
- [*Apps configuration*](#apps-configuration)
- [*About*](#about)

## Job View

From the Job View page you can easily track the jobs from a timeline component. With the filtering options provided you can focus on the jobs that are relevant to you. Creating new jobs can be done by clicking the 'New' button above the timeline component. To update existing jobs you can use the 🖉 icon to open the [Edit Job Panel](#edit-job-panel). To avoid conflicts when multiple people need to update the same job, there is an [automatic locking mechanism](xref:MO_S_Job_Locking) in place. Through drag-and-drop you can easily change the timings of the jobs without having to go into the [Edit Job Panel](#edit-job-panel).

## Resource View

The Resource View page is designed to have the same timeline component as in the [Job View](#job-view) but filtered based on a resource or resource pool selected. From this view it is easy to swap between resources in the same resource pool. When the resource is used within a job it will be visualized in the row of that resource in the timeline component. To swap it you can drag the job from that resource row to another resource row, this will swap then the resource.

## Ops Board

The Ops Board page gives you an overview of the jobs in a list view filtered on the state of the job (Active, Upcoming, Completed or All). From the Actions column, you can edit, duplicate or start/stop the job easily.

## Search Jobs

The Search Jobs page gives you the tools to find any job back in the system.

## Apps Configuration

On the Apps Configuration page you can configure how the ID of the jobs should look like. Note that this ID is a user-friendly identifier, the real ID is a GUID which is not visible to the user.

## About

The About page provides information on the version of MediaOps package.

## Edit Job panel

The Edit Job panel can be accessed from the [Job](#job-view) or [Resource](#resource-view) view through the 🖉 icon. On top of the Edit Job panel the current state of the job is indicated and what states will follow under normal circumstances. The panel also contains sections which are described below.

- **Job info**: Contains the general information (e.g. Name, Description, start, end) of the job and based on the [state of the job](xref:MO_S_Job_States) different buttons will be shown:
  - **Save as Tentative** (Draft): Move the job from Draft to a tentative state which will reserve all resources.
  - **Edit job config** (Draft, Tentative, Confirmed): some buttons to change the state of the job or to access the [profile configuration](xref:MO_ProfileConfig) of the job itself. The configuration for the nodes can be accessed from both the Nodes and Workflow section.
  - **Confirm job** (Tentative): Move the job from Tentative to confirmed. Once the job is confirmed, the orchestration script will be executed.
  - **Cancel job** (Tentative, Confirmed): To cancel the job and to free up the resources again.
  - **Manual start** (Confirmed): When the event needs to start immediately, you can use this action to move the start time to now. This will change the job state to running.
  - **Stop early** (Running): When the event needs to stop immediately, you can use this action to trigger the stop actions. This will change the job state to Confirmed.
  - **Finalize cost & billing** (Completed): This action will only be possible if an organization and contract has been defined in the Administration section. This will change the job state to Ready For Invoice.
  - **Set to invoiced** (Ready For Invoice): Once the job has been invoiced you can mark this on the job by pushing this button. This will chang the state of the job to Invoiced.
- **Related**: Contains all related/linked objects to the job. New links can be added by clicking the 'Add Link' button. New types can be added from the [Apps Configuration](#apps-configuration) page.
- **Administration**: This section provides information to which organization the job can be billed. The billing depends on the [contract](xref:MO_CB_Contracts) selected.
- **Nodes**: Provides a list view of all nodes in the job. Resources or resource pools can be added from this section through the 'Add Resource' button.
- **Workflow**: Provides a workflow diagram of all nodes. Nodes and connection between them can be managed from this view.

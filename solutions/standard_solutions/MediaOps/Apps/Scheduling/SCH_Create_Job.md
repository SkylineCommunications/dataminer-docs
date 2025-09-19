---
uid: SCH_Create_Job
---

# Creating a job

There are three main ways to manually create a new job through the Scheduling app:

- [From scratch](#creating-a-completely-new-job)
- [Starting from a predefined workflow](#creating-a-job-using-a-predefined-workflow)
- [By selecting a resource](#creating-a-job-by-selecting-a-specific-resource)

## Creating a completely new job

1. On the *Job View* page, click the *+ New* button at the top.

   !['New' button in the Scheduling app](~/solutions/images/Scheduling_Create_Job.png)

1. Specify the name and optionally a description for the job.

1. Customize the start and end time if necessary.

   By default, the time range is set to one hour starting from the current time.

1. Optionally, configure a pre-roll and/or post-roll time for the job.<!-- RN 43035 -->

   This can be useful to ensure that resources are reserved for long enough before the start of the job and after the end of a job, for example so operators or orchestration scripts have enough time to do the setup or to take down the workflow.

1. Configure the job's `Desired State`, which can be `Draft` or `Tentative`.

1. Optionally, click *Next* to select the organization and/or job owner linked to the job.

   This will link the job to an organization and/or contact defined in the [People & Organizations](xref:People_Organizations) app.

1. Click *Create Job*.

   This will create an empty job, without any resource in it yet. Once the job has been created, it will appear on the schedule in the [draft state](xref:MO_S_Job_States).

1. To start adding resources to your job, click the pencil icon of the job on the timeline to open a panel where you can edit the job. For detailed info, refer to [Editing a job](xref:SCH_Edit_Job).

   > [!NOTE]
   > When you have added the resources, it is best to click *Save as Tentative* as soon as possible. Saving the job in the [tentative state](xref:MO_S_Job_States) will ensure that the selected resources are reserved and cannot be used by other nodes or jobs.

## Creating a job using a predefined workflow

To create a job starting from a workflow that has been predefined in the [Workflow Designer](xref:MO_Workflow_Designer) app, follow the same procedure as detailed above, but select the desired workflow before you click *Create Job* in the *Create job* pop-up window.

![Selecting a predefined workflow to create a job](~/solutions/images/Scheduling_Create_Job_from_Workflow.png)

> [!NOTE]
> Only workflows that have been marked as *Complete* in the Workflow Designer will be available for selection in the Scheduling app.

## Creating a job by selecting a specific resource

Creating a job directly based on one specific resource can be useful when you want to quickly reserve a specific resource. To do so:

1. On the *Resource View* page, select the resource pool and the resource that need to be booked.

1. Click the *+ New* button at the top.

   ![Creating a job directly on a specific resource](~/solutions/images/Scheduling_Create_Job_on_Resource.png)

1. Configure the same settings as [mentioned above](#creating-a-completely-new-job) and click *Create Job*.

   The job will be created in the [tentative state](xref:MO_S_Job_States), so that the resource is immediately reserved.

1. If necessary, click the pencil icon on the job to edit it and add more resources. See [Editing a job](xref:SCH_Edit_Job).

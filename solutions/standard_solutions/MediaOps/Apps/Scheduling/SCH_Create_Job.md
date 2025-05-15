---
uid: SCH_Create_Job
---

# Creating a job

There are three main ways to manually create a new job through the Scheduling app:

- [From scratch](#from-scratch)
- [Starting from a predefined workflow](#starting-from-a-predefined-workflow)
- [By selecting a resource](#by-selecting-a-specific-resource)

## From scratch

The first way to create a new job is by clicking the *New* button on the *Job View* page of the application. This will open a popup box to define when the job needs to be created. The fields will be prefilled so that the job starts at job creation with a duration of one hour. This will create an empty job, without any resource in it yet. Once the job has been created, it will appear on the schedule in the draft state. The user can then start adding resources to it from the [Job edit panel](xref:SCH_Edit_Job) by clicking the pencil icon in the top-right corner of the job on the timeline. 

> [!NOTE]
> It is advised to go to the [tentative sate](xref:MO_S_Job_States) as soon as possible to ensure the resources you add/select are reserved and can't be used by other nodes or jobs.

!['New' button in the Scheduling app](~/user-guide/images/Scheduling_Create_Job.png)

## Starting from a predefined workflow

It is also possible to create a Job starting from a workflow that has been predefined in the [Workflow Designer](xref:MO_Workflow_Designer) app. This is done similarly to creating a Job from scratch, but instead selecting the desired workflow from the dropdown in the 'Create job' popup window.

![Selecting a predefined workflow to create a job](~/solutions/images/Scheduling_Create_Job_from_Workflow.png)

 > [!NOTE]
> Only workflows that have been marked as 'Complete' in the Workflow Designer will appear for selection in the Scheduling app.

## By selecting a specific resource

A third option is to create a job directly on one specific resource. This can be useful when a user wants to quickly reserve a specific resource. This is done by first selecting a resource pool, then selecting the resource that needs to be booked and then clicking the 'New' button above the timeline. This will trigger the same pop-up to create a job as described in the previous two options. The job will be created immediately in 'Tentative' state, so that the resource is immediately reserved. After creating the job, the user can still edit the job in order to add more resources to it if needed.

![Creating a job directly on a specific resource](~/solutions/images/Scheduling_Create_Job_on_Resource.png)

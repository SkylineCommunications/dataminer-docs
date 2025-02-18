---
uid: SCH_Create_Job
---

# Creating a Job

There are three main ways to manually create a new Job through the scheduling app:
- From scratch
- Starting from a predefined workflow
- By selecting a resource

## From scratch

The first way to create a new Job is by clicking the 'New' button on the 'Job View' page of the application. This will open a pop-up asking the user to enter a name and a start and end time for the new Job. By default, the timings will be set to a duration of one hour starting now. This will create an empty Job, without any resource in it yet. Once the job has been created, it will appear on the schedule in a Draft state. The user can then start adding resources to it from the [Job edit panel](xref:SCH_Edit_Job) by clicking the pencil icon in the top-right corner of the Job on the timeline. 

![Location of the 'New' button in the Scheduling app](~/user-guide/images/Scheduling_Create_Job.png)

## Starting from a predefined workflow

It's also possible to create a Job starting from a workflow that has been predefined in the [Workflow Designer](xref:MO_Workflow_Designer) app. This is done similarly to creating a Job from scratch, but instead selecting the desired workflow from the dropdown in the 'Create job' pop-up. 

![Selecting a predefined workflow to create a Job](~/solutions/images/Scheduling_Create_Job_from_Workflow.png)

 > [!NOTE]
> Only workflows that have been marked as 'Complete' in the Workflow Designer will appear for selection in the Scheduling app. 

## By selecting a specific resource

A third option is to create a Job directly on one specfic resource. This can be useful when a user wants to quickly reserve a specific resource. This is done by first selecting a resource pool, then selecting the resource that needs to be booked and then clicking the 'New' button above the timeline. This will trigger the same pop-up to create a Job as described in the previous two options. The Job will then be created immediatly in 'Tentative' state, so that the resource is immediatly reserver in the background. After creating the Job, the user can still edit the Job in order to add more resources to it if needed.

![Creating a Job directly on a specific resource](~/solutions/images/Scheduling_Create_Job_on_Resource.png)
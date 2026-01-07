---
uid: MO_Scheduling
---

# Scheduling

The Scheduling application is a comprehensive solution for the scheduling and orchestration of [resources](#resources) and [workflows](#workflows). Using a [job](#jobs), users can easily schedule specific resources, request a resource for a given pool of resources, schedule an entire workflow, or a combination of each of the options.

Among others, the app includes the following features:

- Tracking information about a job, including who is requesting it, when the job starts and ends, and job priorities.
- Guaranteeing that a resource used in a job is available for the scheduled time.
- Easily spotting when a job needs additional input prior to the job's start.

![Scheduling Overview](~/solutions/images/Scheduling_Overview.png)

> [!TIP]
> Do you prefer visual learning? Take a look at the [demo video](https://www.youtube.com/watch?v=lfeCwxYTA4o) about this app.

> [!NOTE]
> This page contains information about the Scheduling app within the MediaOps Solution. If you are looking for information about the Scheduler module within DataMiner Cube instead, refer to [DataMiner Scheduler](xref:scheduler).

## App overview

The following pages are available in the Scheduling app:

- ![Job View](~/solutions/images/Scheduling_Job_View.png) **Job View**: Allows you to keep track of all jobs in the system on a timeline. Using the available filtering options, you can focus on the jobs that are relevant to you. You can also **create new jobs** from here, either [starting from scratch](xref:SCH_Create_Job#creating-a-completely-new-job) or [starting from a predefined workflow](xref:SCH_Create_Job#creating-a-job-using-a-predefined-workflow). To **update existing** jobs, you can use the pencil icon to open the [Edit job panel](xref:SCH_Edit_Job). An [automatic locking mechanism](xref:MO_S_Job_Locking) is used to avoid conflicts when multiple users try to update the same job.

  > [!TIP]
  > For more information on how to work with timeline components in general, see [Changing the time range](xref:DashboardTimeline#changing-the-time-range). However, keep in mind that this describes everything that could potentially be done with a timeline component in a low-code app, so not all of the described functionality will apply for MediaOps.

- ![Resource View](~/solutions/images/Scheduling_Resource_View.png) **Resource View**: Shows the jobs for the resources in a specific resource pool. When a resource is used within a job, this will be visualized in the row of that resource in the timeline component. This page allows you to [create a job where the selected resource is added immediately](xref:SCH_Create_Job#creating-a-job-by-selecting-a-specific-resource). You can also **swap jobs** between resources in the same resource pool, by dragging the job from one resource's row to another resource's row.

- ![Ops Board](~/solutions/images/Scheduling_Ops_Board.png) **Ops Board**: Shows the jobs in the system in a list view, filtered on the state of the job (*Active*, *Upcoming*, *Completed*, or *All*). From the *Actions* column, you can **edit**, **duplicate**, **start** or **stop a job**.

- ![Search Jobs](~/solutions/images/Scheduling_Search_Jobs.png) **Search Jobs**: Provides the tools to **find any job** in the system. This includes canceled jobs, which are hidden on all other pages.

- ![App Configuration](~/solutions/images/Scheduling_App_Configuration.png) **App Configuration**: Allows you to configure general [app-wide settings](xref:MO_S_App_Configuration).

- ![Recurring Job View](~/solutions/images/RecurringJobView.png) **Recurring Job View**: Allows you to manage [recurring jobs](xref:SCH_Recurring).

- ![About](~/solutions/images/Scheduling_About.png) **About**: Provides information on the **version** of the MediaOps package.

## Jobs

A job represents a planned activity that will be executed. With a job, you can reserve [resources](#resources), request a resource from a given pool of resources, and schedule a [workflow](#workflows). The system will make sure that, in the background, the availability of all resources is managed so that no resource conflicts occur.

Next to that, **administrative metadata** can be added to a job, such as a description, an owner, or the organization for which the job will be carried out.

## Resources

Various types of resources can be included in a job and used to indicate that a job needs a certain type of resource for its operation. For example, if you are sending a live broadcast crew to report from an event, you might be sending an **OB truck** equipped with **broadcast cameras**, **mics**, and an **electricity generator**, together with a **driver**, a **camera operator**, an **audio engineer**, and an **announcer**. All of these can be represented as a resource inside MediaOps and scheduled with jobs in the Scheduling app.

For more details on how to create and manage resources, see [Resource Studio](xref:MO_Resource_Studio).

## Workflows

<!-- TODO: Check if this needs to be updated -->
When you schedule a job, you can either create a workflow on the fly, or you can select a [predefined workflow](xref:MO_Workflow_Designer#workflows) created in the [Workflow Designer](xref:MO_Workflow_Designer) app.

For an example of how you can create a job and make a workflow on the fly, refer to the tutorial [Creating a job and configuring it with resources](xref:Tutorial_MediaOps_Scheduling_Encoder_Decoder). For an example of how you can use a predefined workflow instead, follow the tutorial [Creating a workflow to use as a template for a job](xref:Tutorial_MediaOps_Workflow_Designer_Intro).

---
uid: MO_Scheduling
---

# Scheduling

The Scheduling app allows users to efficiently manage and orchestrate a schedule of [jobs](#jobs), [resources](#resources), and [workflows](#workflows).

![Scheduling Overview](~/user-guide/images/Scheduling_Overview.png)

> [!TIP]
> This page contains information about the Scheduling app within the MediaOps Solution. If you are looking for information about the Scheduler module within DataMiner Cube instead, refer to [DataMiner Scheduler](xref:scheduler).

## App overview

The following pages are available in the Scheduling app:

- ![Job View](~/user-guide/images/Scheduling_Job_View.png) **Job View**: Allows you to keep track of all jobs in the system on a timeline. Using the available filtering options, you can focus on the jobs that are relevant to you. You can also **create new jobs** from here, either [starting from scratch](xref:SCH_Create_Job#from-scratch) or [starting from a predefined workflow](xref:SCH_Create_Job#starting-from-a-predefined-workflow). To **update existing** jobs, you can use the pencil icon to open the [Edit job panel](xref:SCH_Edit_Job). An [automatic locking mechanism](xref:MO_S_Job_Locking) is used to avoid conflicts when multiple users try to update the same job.

- ![Resource View](~/user-guide/images/Scheduling_Resource_View.png) **Resource View**: Shows the jobs for the resources in a specific resource pool. When a resource is used within a job, this will be visualized in the row of that resource in the timeline component. This page allows you to [create a job where the selected resource is added immediately](xref:SCH_Create_Job#by-selecting-a-specific-resource). From this page, it is also easy to **swap jobs** between resources in the same resource pool: just drag the job from that resource's row to another resource's row.

- ![Ops Board](~/user-guide/images/Scheduling_Ops_Board.png) **Ops Board**: Shows the jobs in the system in a list view, filtered on the state of the job (*Active*, *Upcoming*, *Completed*, or *All*). From the *Actions* column, you can **edit**, **duplicate**, or **start/stop a job** easily.

- ![Search Jobs](~/user-guide/images/Scheduling_Search_Jobs.png) **Search Jobs**: Provides the tools to **easily find any job** in the system. This includes canceled jobs, which are hidden on all other pages.

- ![App configuration](~/user-guide/images/Scheduling_App_Configuration.png) **App configuration**: Allows you to configure general [app-wide settings](#app-wide-settings).

- ![About](~/user-guide/images/Scheduling_About.png) **About**: Provides information on the **version** of the MediaOps package.

## Jobs

A job represents a planned activity that will be executed. With a job, you can reserve [resources](#resources), request a resource from a given pool of resources, or even schedule an entire [workflow](#workflows) for this planned activity. The system will make sure that, in the background, the availability of all resources is managed so that no resource conflicts occur.

Next to that, **administrative metadata** can be added to a job, such as a description, an owner, or the organization for which the job will be carried out.

## App-wide settings

On the *App configuration* page, you can configure the following app-wide settings:

- To reserve a fixed amount of time for the equipment setup before a job starts and the time for the equipment dismantling after a job ends, you can define **pre-roll** and **post-roll** parameters across the whole app. This way, by default, the resources will be reserved for some time before the job begins and after it ends.

- Each job will have, apart from its name, a job ID, which can be used to uniquely identify the job, since the job names are not unique. Via the **Configure Job ID** button, you can configure the **job ID pattern** that will be used in all the newly created jobs.

- If you want to attach **additional metadata** to your jobs, you can do so through the system properties. Via the **Configure System Properties** button, you can define these properties, so you can then use them in your jobs. The properties will not affect any logic in the MediaOps apps; they are metadata intended purely as additional information for users.

- If you want your jobs to be able to reference internal MediaOps entities or external generic entities, you can define the entities referenced in the **Reference types** section. The references are very generic, enabling you to reference a vast array of different types of entities.

## Resources

Various types of resources can be included in a job and used to indicate that a job needs a certain type of resource for its operation. For example, if you are sending a live broadcast crew to report from an event, you might be sending an **OB truck** equipped with **broadcast cameras**, **mics**, and an **electricity generator**, together with a **driver**, a **camera operator**, an **audio engineer**, and an **announcer**. All of these can be represented as a resource inside MediaOps and scheduled with jobs in the Scheduling app.

For more details on how to create and manage resources, see [Resource Studio](xref:MO_Resource_Studio).

## Workflows

If you have a repeating group of resources you would like to reuse in your jobs, you can turn it into a **MediaOps Workflow** with the **Workflow Designer** app. For example, if a constant set of resources is required when organizing live broadcast events, you can group these into a **Workflow** and use them whenever you want to send out a crew out for a live broadcast operation.

For more details on how to create and manage workflows, see [Workflow Designer](xref:MO_Workflow_Designer).

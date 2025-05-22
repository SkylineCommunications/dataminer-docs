---
uid: MO_Scheduling
---

# Scheduling

The Scheduling app allows users to efficiently manage and orchestrate a schedule of [Jobs](#jobs), [Resources](#resources), and [Workflows](#workflows).

![Scheduling Overview](~/user-guide/images/Scheduling_Overview.png)

## App overview

The following pages are available in the Scheduling app:

- ![Job View](~/user-guide/images/Scheduling_Job_View.png) **Job View**: From the Job View page you can keep track of all Jobs in the system on a timeline. With the _filtering options_ provided you can focus on the jobs that are relevant to you. From this page, users can **create new Jobs**, either [starting from scratch](xref:SCH_Create_Job#from-scratch) or [starting from a predefined workflow](xref:SCH_Create_Job#starting-from-a-predefined-workflow). To **update existing** jobs you can use the 🖉 icon to open the [Edit Job Panel](xref:SCH_Edit_Job). An [automatic locking mechanism](xref:MO_S_Job_Locking) is used to avoid conflicts when multiple users try to update the same job.

- ![Resource View](~/user-guide/images/Scheduling_Resource_View.png) **Resource View**: The Resource View page shows the Jobs for the resources in a specific resource pool. When the resource is used within a Job, it will be visualized in the row of that resource in the timeline component. The page allows to [create a job where the selected resource is added immediately](xref:SCH_Create_Job#by-selecting-a-specific-resource). From this view, it is also easy to **swap Jobs** between resources in the same resource pool: just drag the Job from that resource's row to another resource's row.

- ![Ops Board](~/user-guide/images/Scheduling_Ops_Board.png) **Ops Board**: The Ops Board shows the Jobs in the system in a list view, filtered on the state of the job (`Active`, `Upcoming`, `Completed` or `All`). From the `Actions` column, you can **edit**, **duplicate** or **start/stop the job** easily.

- ![Search Jobs](~/user-guide/images/Scheduling_Search_Jobs.png) **Search Jobs**: The Search Jobs page gives you the tools to **easily find any job** in the system. This includes also `canceled` Jobs, which are hidden on all other pages.

- ![App configuration](~/user-guide/images/Scheduling_App_Configuration.png) **App configuration**: On the Apps Configuration page you can configure general [app-wide settings](#app-configuration).

- ![About](~/user-guide/images/Scheduling_About.png) **About**: The About page provides information on the **version** of the `MediaOps` package.

## Jobs

A `Job` represents a planned activity that will be executed. With a Job, users can easily reserve [resources](#resources), request a resource from a given pool of resources, or even schedule an entire [workflow](#workflows) for this planned activity. The system will make sure that, in the background, the availability of all resources is managed so that no resource conflicts occur. 

Next to that, **administrative metadata** can be added to a Job, such as a description, and owner or the organization for which the Job will be carried out.

## App Configuration

If you want to reserve a fixed amount of time for the equipment setup before the job starts and the time for the equipment dismantling after the job ends, you can define **pre-roll** and **post-roll** parameters across the whole app. This way, by default, the resources will be reserved for some time before the job begins and after it ends.

Each job will have, apart from its name, a **Job ID**, which can be used to uniquely identify the job, since the job names are not unique. Here you can also flexibly set the job ID pattern that will be used in all the newly created jobs.

If you want to attach **additional meta-data** to your jobs, you can do it through the `System properties`. You can define the system properties on this page, and then use them in your jobs. The properties will not affect any logic in the MediaOps apps, they are meta-data intended purely for consumption by humans.

If you want your jobs to be able to **reference** internal MediaOps entities, or external generic entities, you can define the entites referenced in the `Reference types` section. The references are very generic, enabling you to reference a vast array of different types of entities.

## Resources

Various types of resources can be included in a job and used to indicate that a job needs a certain type of resource for its operation. For example, if your sending a live broadcast crew to report from an event, you might be sending an **OB truck** equipped with **broadcast cameras**, **mics**, and an **electricity generator**; together with a personnel consisting of a **driver**, a **camera operator**, an **audio engineer**, and an **announcer**. All of these can be represented as a resource inside MediaOps and scheduled with jobs inside the Scheduling app.

For more details on how to create and manage resources, please check out the [Resource Studio Documentation](xref:MO_Resource_Studio).

## Workflows

If you have a repeating group of resources you would like to reuse in your jobs, you can turn it into a **MediaOps Workflow** with the **Workflow Designer** app. For example, if a constant set of resources is required when organizing live broadcast events, you can group these into a **Workflow** and use them whenever you want to send out a crew out for a live broadcast operation.

For more details on how to create and manage workflows, please check out the [Workflow Designer Documentation](xref:MO_Workflow_Designer).

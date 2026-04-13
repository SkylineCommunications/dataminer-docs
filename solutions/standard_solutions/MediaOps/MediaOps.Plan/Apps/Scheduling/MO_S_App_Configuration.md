---
uid: MO_S_App_Configuration
---

# App settings

On the *App Configuration* page, you can configure several app-wide settings.

![App Configuration](~/solutions/images/Scheduling_AppConfiguration.png)

## Configure Job ID

Each job will have, apart from its name, a job ID, which can be used to uniquely identify the job, since the job names are not unique. Via this button, you can configure the **job ID pattern** that will be used in all the newly created jobs.

## Configure Job Defaults

This allows you to define default values that are applicable to every user that creates a new job.

![App Configuration Job Defaults](~/solutions/images/Scheduling_AppConfiguration_JobDefaults.png)

The following values can be configured:

- **Pre-roll**: The default amount of time before the job starts, which is reserved to set up the resources.
- **Post-roll**: The default amount of time after the job ends to tear down the resources.
- **Desired State**: The default state in which new jobs are created.

## Configure System Properties

This allows you to define **additional metadata** to use in your jobs. These properties will not affect any logic in the MediaOps apps; they are metadata intended purely as additional information for users. To make it easier to order those properties, you can divide them into sections.<!-- RN 43041 -->

## Reference Types

If you want your jobs to be able to reference internal MediaOps entities or external generic entities, you can define the additional entities in this section. The references are very generic, enabling you to reference a vast array of different types of entities.

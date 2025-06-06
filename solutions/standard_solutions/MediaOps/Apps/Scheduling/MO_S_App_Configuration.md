---
uid: MO_S_App_Configuration
---

# Configuring the app settings

On the *App Configuration* page, you can configure the following app-wide settings:

- To reserve a fixed amount of time for the equipment setup before a job starts and the time for the equipment dismantling after a job ends, you can define **pre-roll** and **post-roll** parameters across the whole app. This way, by default, the resources will be reserved for some time before the job begins and after it ends.

- Each job will have, apart from its name, a job ID, which can be used to uniquely identify the job, since the job names are not unique. Via the **Configure Job ID** button, you can configure the **job ID pattern** that will be used in all the newly created jobs.

- If you want to attach **additional metadata** to your jobs, you can do so through the system properties. Via the **Configure System Properties** button, you can define these properties, so you can then use them in your jobs. The properties will not affect any logic in the MediaOps apps; they are metadata intended purely as additional information for users.

- If you want your jobs to be able to reference internal MediaOps entities or external generic entities, you can define the entities referenced in the **Reference types** section. The references are very generic, enabling you to reference a vast array of different types of entities.

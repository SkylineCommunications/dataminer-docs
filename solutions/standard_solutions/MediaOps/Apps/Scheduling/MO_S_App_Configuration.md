---
uid: MO_S_App_Configuration
---

## App Configuration

If you want to reserve a fixed amount of time for the equipment setup before the job starts and the time for the equipment dismantling after the job ends, you can define **pre-roll** and **post-roll** parameters across the whole app. This way, by default, the resources will be reserved for some time before the job begins and after it ends.

Each job will have, apart from its name, a **Job ID**, which can be used to uniquely identify the job, since the job names are not unique. Here you can also flexibly set the job ID pattern that will be used in all the newly created jobs.

If you want to attach **additional meta-data** to your jobs, you can do it through the `System properties`. You can define the system properties on this page, and then use them in your jobs. The properties will not affect any logic in the MediaOps apps, they are meta-data intended purely for consumption by humans.

If you want your jobs to be able to **reference** internal MediaOps entities, or external generic entities, you can define the entites referenced in the `Reference types` section. The references are very generic, enabling you to reference a vast array of different types of entities.


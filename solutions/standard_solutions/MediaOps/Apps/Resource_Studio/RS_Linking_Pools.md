---
uid: RS_Linking_Pools
---

# Linking resource pools

The Resource Studio app also allows you to "link" a resource pool to other resource pools. When a resource of that pool is then added to a job, the system will automatically also add resources from its linked pools to the same job. The same applies also when adding the pool to a workflow in the Workflow Designer app.

This functionality helps users who create jobs to make sure they have all the necessary resources to carry out the job. For example, a pool of OB trucks could be linked to a pool of truck drivers, so that when someone adds a truck to a job, the system will automatically also add a driver for the truck to that job. There are two possible resource selection types that can be selected when adding a linked resource pool to a pool:

- **Automatic**: 
    - When a pool or one of its resources is added to a job, the system will automatically pick a resource from the linked pool that is available for the entire duration of the job and add it to the job. If there are no resources in the linked pool that are available for the entire duration of the job, the system will add the linked resource pool to the job instead. This way, it is left up to the user to make sure a resource in the linked resource pool is made available and then swapped into the job.
    - When a pool or one of its resources is added to a workflow, a pool node will be added to the workflow, with the option 'Auto-select resource at job creation' set to 'true' on that pool node.

- **Manual**: 
    - When a pool or one of its resources is added to a job, the system will add the linked resource pool to the job, allowing the user to swap in a specific resource from that pool at a later point in time.
    - When a pool or one of its resources is added to a workflow, a pool node will be added to the workflow, with the option 'Auto-select resource at job creation' set to 'false' on that pool node.

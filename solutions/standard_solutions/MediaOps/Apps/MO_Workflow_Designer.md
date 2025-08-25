---
uid: MO_Workflow_Designer
---

# Workflow Designer

The Workflow Designer is an operator-level DevOps environment to create technical [workflows](#workflows). In the app, users can define what needs to happen when a connection is created between a source and a destination, when a certain job is executed, when a type of service is delivered, etc. This is done by describing workflows. Each workflow consists of a set of nodes and a set of connections between these nodes. These typically describe how a source signal (virtual signal group) is transported to a destination and how it gets processed in between. These workflows can then be executed by scheduling a job in the [Scheduling app](xref:MO_Scheduling).

![Example workflow](~/solutions/images/WFD_Example_WF.png)

> [!TIP]
> Do you prefer visual learning? Take a look at the [demo video](https://www.youtube.com/watch?v=DR1ObA8F0m0) about this app. Or if you would like a practical example of how to use this app, refer to the tutorial [Creating a workflow to use as a template for a job](xref:Tutorial_MediaOps_Workflow_Designer_Intro).

## App overview

The following pages are available in the Workflow Designer app:

- ![Home](~/solutions/images/WD_Home.png) **Home**: Allows you to keep track of all workflows in the system, [create new workflows](xref:WFD_Creating_Workflows), and **duplicate**, **update**, or **delete** existing workflows. You can also **specify the resources** required for a workflow and how they are linked to each other, as well as provide **default configuration** settings for resources.

- ![About](~/solutions/images/WD_About.png) **About**: Provides information on the **version** of the MediaOps package.

<!-- TODO: Add more info on how to delete workflows and configure default configuration settings (or if the latter refers to the "Configure Node" option mentioned on WFD_Creating_Workflows, clarify this) -->

## Workflows

A workflow defines which resources and resource pools are needed for an operation, and how they are interconnected. This is useful if you want to reuse the same set of resources in multiple jobs. For example, if a certain set of resources is always required when organizing live broadcast events, you can group these into a "Live Broadcast" workflow and use it whenever you want to send out a crew for a live broadcast operation.

Workflow Designer allows you to also use resource pools in your workflows, enabling you to specify which types of resources you need in your workflows, without the need to specify the exact resources up front.

For more details on how you can create workflows in this app, see [Creating workflows](xref:WFD_Creating_Workflows).

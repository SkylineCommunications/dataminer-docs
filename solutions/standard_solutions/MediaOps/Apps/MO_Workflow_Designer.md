---
uid: MO_Workflow_Designer
---

# Workflow Designer

The workflow designer app allows you to visually manage and configure [workflows](#workflows), which can be used as templates for jobs in the [Scheduling app](xref:MO_Scheduling).

![Example workflow](~/solutions/images/WFD_Example_WF.png)

## App overview

The following pages are available in the Workflow Designer app:

- ![Home](~/user-guide/images/WD_Home.png) **Home**: Allows you to keep track of all workflows in the system, [create new workflows](xref:WFD_Creating_Workflows), and **duplicate**, **update**, or **delete** existing workflows. You can also **specify the resources** required for a workflow and how they are linked to each other, as well as provide **default configuration** settings for resources.

- ![About](~/user-guide/images/WD_About.png) **About**: Provides information on the **version** of the MediaOps package.

## Workflows

A workflow defines what resources and resource pools are needed for an operation, and how they are interconnected. This is useful if you have a repeating set of resources you want to reuse in multiple jobs, or over a period of time. For example, if a certain set of resources is always required when organizing live broadcast events, you can group these into a "Live Broadcast" workflow and use it whenever you want to send out a crew for a live broadcast operation. Workflow designer allows you to also use resource pools in your workflows, enabling you to specify which types of resources you need in your workflows, without the need to specify the exact resources up-front.

For more details on how you can create workflows in this app, see [Creating workflows](xref:WFD_Creating_Workflows).

---
uid: WFD_Edit_Workflow
---

# Editing a workflow

To edit a workflow, click the pencil icon for that workflow from the *Home* page. This will open the *Edit workflow* panel. This panel consists of different sections where you can view and edit the workflow settings, **specify the resources** required, how they are linked to each other, as well as provide **default configuration** settings for resources.

![Edit Workflow](~/solutions/images/WFD_Open_Edit_Panel.png)

> [!NOTE]
> When you have finished configuring a workflow, you can make the workflow available in the [Scheduling app](xref:MO_Scheduling) through the *Mark as Complete* option from the *Home* page. As long as a workflow is still in the [draft state](xref:WFD_Workflow_States), it will not be available for scheduling.

## Adding nodes to a workflow

For a workflow to be useful, it must contain at least one **node**. Each node indicates something that is required by the workflow.

To add a node, click the *Add Pool* or *Add Resource* button:

- **Add pool**: Select this option if you don't know you need a resource of the pool, but not yet which resource instance in the pool should be used. The resource selection will then need to happen once a job is created from the workflow. As a job has a start and stop time, you can then pick a resource based on availability.

- **Add Resource**: Select this option if you know exactly which resource is required by the workflow. You must still define the pool, to indicate the context in which the resource will be used (resources can be part of multiple resource pools when they can be used for different functions). When a job is created using the workflow, the resource will automatically be added as node to the job.

Once a node is available in the workflow, you have the option to add another node (pool or resource) with a connection before or after a node by selecting a node in the workflow.

## Configuring existing nodes in a workflow

After you have added a node, you can make changes to it by selecting it and then selecting an action in the **Node Actions** menu at the top:

- **Edit**: Allows you to define an alias for the node, whether a resource should be automatically selected based on availability when creating a job.
- **Configure**: Allows you to predefine the orchestration settings for the node (e.g. defining capabilities, capacities, automated actions).
- **Edit properties**: Allows you to add or edit properties for a node.
- **Remove**: Allows you to delete the selected node(s).

## Creating connections between nodes

Select the source node, then additionally select the destination node (ctrl+click). Once both nodes are selected, the **Connect** button should be enabled, which allows you to make the connection.

You can also select a connection in the workflow and **Disconnect**, **edit** the connection.

## Edit workflow

## Configuring workflow orchestration settings

<!-- TODO: further complete this page -->
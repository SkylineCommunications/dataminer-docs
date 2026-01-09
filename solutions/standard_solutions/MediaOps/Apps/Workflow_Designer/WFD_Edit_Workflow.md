---
uid: WFD_Edit_Workflow
---

# Editing a workflow

To edit a workflow, click the pencil icon for that workflow from the *Home* page. This will open the *Edit workflow* panel.

![Edit Workflow](~/solutions/images/WFD_Open_Edit_Panel.png)

This panel consists of two sections:

1. [Workflow section](#workflow-section): where you can view and edit the workflow, **specify the resources** required, how they are linked to each other, as well as provide **default configuration** settings for resources.
1. [Nodes section](#nodes-section): where all nodes used in the workflow are listed (incl. linked nodes).

> [!NOTE]
> When you have finished configuring a workflow, you can make the workflow available in the [Scheduling app](xref:MO_Scheduling) through the *Mark as Complete* option from the *Home* page. As long as a workflow is still in the [draft state](xref:WFD_Workflow_States), it will not be available for scheduling.

## Workflow section

In the workflow section you can execute the following actions. Depending on the the selected node(s) or connection(s) it might happen that different buttons will be enabled/disabled.

1. [Edit the general workflow settings](#edit-the-general-workflow-settings)
1. [Configure the workflow orchestration settings](#configure-the-workflow-orchestration-settings)
1. [Refresh/centralize the workflow in the node-edge component](#refreshcentralize-the-workflow-in-the-node-edge-component)
1. [Adding nodes to a workflow](#adding-nodes-to-a-workflow)
1. [Adding nodes after/before the selected node](#adding-nodes-afterbefore-the-selected-node)
1. [Swapping a node to another pool/resource](#swapping-a-node-to-another-poolresource)
1. [Configure the node orchestration settings](#configure-the-node-orchestration-settings)
1. [Edit the general node settings](#edit-the-general-node-settings)
1. [Remove node(s)](#remove-nodes)
1. [Edit node properties](#edit-node-properties)
1. [Add a connection between two nodes](#add-a-connection-between-two-nodes)
1. [Remove connection(s)](#remove-connections)
1. [Insert a node in the selected connection](#insert-a-node-in-the-selected-connection)
1. [Edit the general connection settings](#edit-the-general-connection-settings)

### Edit the general workflow settings

To edit the general workflow settings click on the pencil icon next to the title of the workflow section.

![Edit General Workflow Settings](~/solutions/images/Workflow_Designer_Edit_Workflow.png)

### Configure the workflow orchestration settings

To edit the workflow [orchestration settings]() click on the cogwheel next to the title of the workflow section.

![Edit Workflow Orchestration Settings](~/solutions/images/Workflow_Designer_Configure_Workflow.png)

### Refresh/centralize the workflow in the node-edge component

It might happen that by zooming or navigating in the workflow you lose track of the nodes in the workflow section. The refresh button allows you to centralize again the nodes in the workflow section.

![Refresh Workflow](~/solutions/images/Workflow_Designer_Refresh_Workflow.png)

### Adding nodes to a workflow

For a workflow to be useful, it must contain at least one **node**. Each node indicates something that is required by the workflow.

To add a node, click the *Add Pool* or *Add Resource* button:

- **Add pool**: Select this option if you don't know you need a resource of the pool, but not yet which resource instance in the pool should be used. The resource selection will then need to happen once a job is created from the workflow. As a job has a start and stop time, you can then pick a resource based on availability.

- **Add Resource**: Select this option if you know exactly which resource is required by the workflow. You must still define the pool, to indicate the context in which the resource will be used (resources can be part of multiple resource pools when they can be used for different functions). When a job is created using the workflow, the resource will automatically be added as node to the job.

![Add Node](~/solutions/images/Workflow_Designer_Add_Node.png)

### Adding nodes after/before the selected node

Once a node is available in the workflow, you can select it and this will enable the buttons to add other nodes before or after the selected node in the workflow.

![Add node before/after](~/solutions/images/Workflow_Designer_Add_Node_After_Before.png)

### Swapping a node to another pool/resource

It is possible to swap a node to a different pool or resource. This to avoid losing all customizations done already on the node (e.g. configuration, properties, etc.). Select the node and click on *Swap To Pool* or *Swap to Resource* depending if you want to swap it to another pool or resource.

![Swap node](~/solutions/images/Workflow_Designer_Swap_Node.png)

### Configure the node orchestration settings

To edit the node [orchestration settings](), select the node and click on the *Configure* button.

![Edit node orchestration settings](~/solutions/images/Workflow_Designer_Configure_Node.png)

### Edit the general node settings

To edit the general node settings, select the node and click on the *Edit* button.

![Edit node settings](~/solutions/images/Workflow_Designer_Edit_Node.png)

### Remove node(s)

To remove node(s) from the workflow, select the node(s) and click on the *Remove* button.

![Remove node(s)](~/solutions/images/Workflow_Designer_Remove_Nodes.png)

### Edit node properties

To edit the properties of a node, select the node and click on the *Edit Properties* button.

![Edit node properties](~/solutions/images/Workflow_Designer_Edit_Node_Properties.png)

### Add a connection between two nodes

To add a connection between two nodes, select two nodes (ctrl click) and click on the *Connect* button.

![Connect nodes](~/solutions/images/Workflow_Designer_Connect_Nodes.png)

### Remove connection(s)

To remove connections, select the connection(s) to remove and click on the *Disconnect* button.

![Disconnect nodes](~/solutions/images/Workflow_Designer_Disconnect.png)

### Insert a node in the selected connection

To insert a node between two already connected nodes, select the connection and click on the *Insert Pool* or *Insert Resource* button.

![Insert node](~/solutions/images/Workflow_Designer_Insert_Node.png)

### Edit the general connection settings

To edit the general connection settings, select the connection and click on the *Edit* button.

![Edit connection settings](~/solutions/images/Workflow_Designer_Edit_Connection.png)

## Nodes section

From the nodes table (depending on your screen resolution, you might have to scroll down), you can execute the following actions on nodes.

1. Configure the node orchestration settings
2. Edit the general node settings
3. Edit node properties
4. Link a pool to the node
5. Link a resource to the node
6. Remove the node

![Actions from the nodes table](~/solutions/images/Workflow_Designer_Nodes_Table.png)
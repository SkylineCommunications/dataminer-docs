---
uid: WFD_Creating_Workflows
---

# Creating workflows

To create workflows, you can use the buttons in the header bar of the Workflow Designer.

![Workflow Designer header bar](~/solutions/images/Workflow_Designer_header_bar.png)

Either create a completely new workflow with the *New workflow* button, or select a workflow in the list and use the *Duplicate workflow* button. If you add a new workflow, you will first need to configure some basic information before it is added to the list. For detailed steps based on an example, refer to the tutorial [Creating a workflow to use as a template for a job](xref:Tutorial_MediaOps_Workflow_Designer_Intro).

Optionally, you can also specify a [workflow execution script](#describing-workflow-execution-behavior).

<!-- TODO: Write out full info on how to create a workflow here, explaining the impact of the various options (including Monitoring settings), instead of only referring to the tutorial -->

## Adding nodes to a workflow

For a workflow to be useful, it must contain at least one **node**. Each node indicates something that is required by the workflow.

To add a node, select the workflow and then click the *Add node* button. You can then select to either use a **resource pool** to indicate the type of required resource, or use a specific **resource**.

- **Resource pool**: Select this option if you want the specific resource instance to be assigned later. This way, you can already configure the node and limit the resources that will be selectable for jobs using the workflow, for example because you do not know yet which resources in the pool will be available.

- **Resource**: If you know exactly which resource will be required by the workflow, select a specific resource as a node. As a resource can be part of multiple resource pools, you will also have to select the resource pool to indicate the context in which the resource will be used. When a job will be created using the workflow, the resource will automatically be added as node to the job.

Once a first node has been added to a workflow, you can add additional nodes in different ways:

- Click the **Add node** button like before. The wizard will include an extra step where you can indicate how the node is connected to other nodes, by selecting the source and/or destination node(s).
- Select a node in the workflow, open the **Node Actions** menu, and select *Add before* or *Add After* to add the node before or after the selected node.

> [!NOTE]
> When you have finished configuring a workflow, click the pencil icon on the workflow to open the configuration panel and click **Mark complete** so that you can use it in the Scheduling app. As long as a workflow is still in the draft state, it will not be available for scheduling.

## Configuring existing nodes in a workflow

After you have added a node, you can make changes to it by selecting it and then selecting an action in the **Node Actions** menu at the top:

- **Edit**: Allows you to change the selected resource and/or resource pool. However, you cannot change the type of node. If you linked a node to a resource pool, you cannot change it to link to a resource instead, and vice versa.
- **Configure Node**: Allows you to select capabilities, capacities, or parameters for the node.
- **Edit properties**: Allows you to add or edit properties for a node.
- **Remove**

## Creating connections between nodes

Between workflow nodes that represent **network inventory**, connectivity may need to be set up in order to execute the workflow. For this, connections between the nodes can be defined. Each of these connections has a single source node and a single destination node.

You can configure these connections when you add the nodes, or you can use the **Add connection** button in the header bar to add connections between existing nodes.

You can also select a connection in the workflow and add a node in between, edit the connection, or remove it, via the **Connection Actions** menu in the header bar.

<!-- TODO: Add info on the different connection configuration options -->

## Describing workflow execution behavior

Workflows can be executed by planning a job based on the workflow in the [Scheduling app](xref:MO_Scheduling). The Workflow Designer app allows you to describe what needs to happen when a workflow execution is triggered. This is done by providing automation scripts in two places:

- **Workflow execution script**: This script describes the overall execution logic of the workflow. The script will always be triggered by the system when a workflow is executed. You can specify this when you create or edit a workflow.

  The dataminer.MediaOps installation package comes with a default workflow execution script called *Workflow.Default*. This script will iterate over the connections of the workflow in the execution order and trigger the execution script defined on the connections. Additional or different logic can be specified in the workflow execution script in order to automate anything that needs to happen when the job starts.

<!-- TODO: explain execution order (can possibly be included with connection configuration options mentioned above) -->

- **Connection execution script**: This is an optional property of all connections in a workflow. It can be used to describe what exactly needs to happen when the source of the connection is connected to its destination. You can specify this when you edit a connection in a workflow.

  > [!NOTE]
  > Contrary to the workflow execution script, there is no guarantee that the system will always execute the connection execution script.<!-- TODO: add reason why this is the case--> If you change the content of the workflow execution script, it is your responsibility to make sure the connection execution script is still executed for every connection in the workflow if needed.

---
uid: WFD_Creating_Workflows
---

# Creating Workflows

## Adding nodes to a workflow

In order to be of use, each workflow has to consist of at least one node. Two different types of nodes are currently already supported:

- **Resource**: Resource nodes define everything that happens in a workflow between source and destination. Resources are defined in the resource studio and can represent network inventory managed with an element in DataMiner or any other real-world entities that are not managed by DataMiner, such as people, vehicles, rooms, etc.

- **Resource pool**: Resource pools have the same purpose as resource nodes, but without the need to specify a specific resource instance. Instead they refer to a pool only, so that it is possible to select the specific resources at a later point in the workflow execution stage.

More node types will be supported in a later version. Each node that is part of a workflow also has several configuration options:

- Optional **alias** for the node in the workflow. This can be useful if there are multiple nodes of the same type in a workflow

- **Include in booking**: For resource or resource pool nodes, this determines whether node resources should be reserved when the workflow is executed.

## Creating connections between nodes

Between workflow nodes that represent network inventory, connectivity may need to be set up in order to execute the workflow. For this, connections between the nodes can be defined. Each of these connections has a single source node and a single destination node. 

## Describing workflow execution behavior

Workflows can be executed a by planning a Job based on the Workflow in the Scheduling app. The Workflow Designer app allows you to describe what needs to happen when a workflow execution is triggered. This is done by providing Automation scripts in two places:

- **Workflow execution script**: This script describes the overall execution logic of the workflow. The script will always be triggered by the system when a workflow is executed.

  The dataminer.MediaOps installation package comes with a default workflow execution script called *Workflow.Default*. This script will iterate over the connections of the workflow in the "execution order" and trigger the "execution script" defined on the connections. Additional or different logic can be specified in the workflow execution script in order to automate anything that needs to happen when the Job starts.

- **Connection execution script**: This is an optional property of all connections in a workflow. It can be used to describe what exactly needs to happen when the source of the connection is connected to its destination.


  > [!NOTE]
  > Contrary to the workflow execution script, there is no guarantee that the system will always execute the connection execution script. If you change the content of the workflow execution script, it is your responsibility to make sure the connection execution script is still executed for every connection in the workflow if needed.

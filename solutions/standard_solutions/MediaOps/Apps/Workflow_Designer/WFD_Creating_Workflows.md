---
uid: WFD_Creating_Workflows
---

# Creating Workflows

## Adding nodes to a workflow

For a workflow to be useful, it must contain at least one **node**. Nodes are used to indicate something is required by the workflow. When adding a node you will be able to select a class or a specific entity. At the moment we have **Resource pool** as class and **Resource** as entity:

- **Resource pool**: A resource pool indicates that a resource is needed from a specific pool without having to already assign a specific resource instance to the workflow. As the workflow can be reused for multiple jobs, it is not yet possible to understand which resources in the pool will be available. The resource pool node allows you to configure the node before selecting an available resource.

- **Resource**: When we know upfront what resource is required by the workflow, a specific resource can be selected as a node. As the resource can be part of multiple resource pools, we still have to select the resource pool (context) in which we want to use the resource. When creating a job from the workflow, the resource will automatically be added as node to the job.

More node types will be supported in a later version. Each node that is part of a workflow also has several configuration options:

- **Alias (optional)**: An alias for the node in the workflow. This can be useful if there are multiple nodes of the same type in a workflow.

- **Include in booking** — For resource or resource pool nodes, this determines whether node resources should be reserved when the workflow is executed.

## Creating connections between nodes

Between workflow nodes that represent **network inventory**, connectivity may need to be set up in order to execute the workflow. For this, connections between the nodes can be defined. Each of these connections has a single source node and a single destination node.

## Describing workflow execution behavior

Workflows can be executed by planning a Job based on the Workflow in the Scheduling app. The Workflow Designer app allows you to describe what needs to happen when a workflow execution is triggered. This is done by providing Automation scripts in two places:

- **Workflow execution script**: This script describes the overall execution logic of the workflow. The script will always be triggered by the system when a workflow is executed.

  The `dataminer.MediaOps` installation package comes with a *default* workflow execution script called `Workflow.Default`. This script will iterate over the connections of the workflow in the *execution order* and trigger the *execution script* defined on the connections. Additional or different logic can be specified in the workflow execution script in order to automate anything that needs to happen when the Job starts.

- **Connection execution script**: This is an optional property of all connections in a workflow. It can be used to describe what exactly needs to happen when the source of the connection is connected to its destination.

  > [!NOTE]
  > Contrary to the workflow execution script, there is no guarantee that the system will always execute the connection execution script. If you change the content of the workflow execution script, it is your responsibility to make sure the connection execution script is still executed for every connection in the workflow if needed.

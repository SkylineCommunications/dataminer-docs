---
uid: workflow_designer_app
---

# Workflow Designer

The workflow designer takes a central place in the dataminer.MediaOps solution. It allows media engineers to define the technical workflows that are made available for both ad-hoc and scheduled operations. The main actions that users can do in the app include:

* Adding nodes to a workflow. When a user creates a new workflow, the first thing they will typically do is adding nodes, which represent the different actors that will contribute to the execution of the workflow.
* Define booking behavior. When workflows get executed, users can opt to create reservations on the nodes in the workflow.
* Create connections between nodes. The workflow designer allows to define connectivity between nodes for nodes that need to have a network connection set up between them for the execution of the workflow.
* Describe what should happen when workflow gets executed.
* Specify monitoring settings

![Screenshot of the workflow designer app](~/user-guide/images/mediaops_wfd_overview.png)

## Adding nodes to a workflow

Each workflow, in order to be of use, should consist of at least one node. There are four different node types that can be added to a workflow:

* Source: sources in a workflow refer to a source defined in the virtual signal groups app. They can contain data that will be used to set up network connectivity as part of the workflow execution.
* Destination: similar to sources, these refers to a virtual signal group destination defined on the system.
* Resource: resource nodes define everything that happens in a workflow between source & destination. Resources are defined in the resource studio, and can represent network inventory managed with an element in DataMiner or any other real-world entities that are not managed by DataMiner, such as people, vehicles, rooms etc.
* Resource pool: has the same purpose as a resource node, but without the need to specify a specific resource instance, instead referring to a pool only, to allow selecting a specific resources only at a later point in the workflow execution stage.

Each node that's part of a workflow also has a couple of configuration options:

* Optional alias for the node in the workflow: can be useful if there are multiple nodes of the same type in a workflow
* Include in booking: determines for resource or resource pool nodes wether or not node resources should be reserved when executing the workflow
* Control script: here, the creator of a workflow can specify an interactive automation script that operators will be able to quickly call upon from their control surfaces to do some predefined parameter control on the underlying network inventory managed via DataMiner

## Creating connections between nodes

Workflow nodes that represent network inventory could require connectivity to be set up between them in order to execute the workflow. For this, connections between the nodes can be defined. Each of these connection has a single source node and a single destination node. On top of that, they also have following properties:

* Type: for now, only 'Level based' is supported here. This means that a connection will be made between the source and the destination of this connection based on the levels in their respective virtual signal groups.
* Subtype: within a level-based connection, there are several options for the exact connection execution:
  * All: all matching levels between source & destination will be connected.
  * Predefined subset: allows users to connect only a subset of levels matching between source & destination. The user can choose between a number of predefined options, including 'all video levels', 'all audio levels', 'all data levels' or any combination of the before (for example all video and all audio levels)
  * Custom subset: allows users to connect only a subset of levels matching between source & destination, beyond the options provided under 'predefined subset'. This allows users, for example, to only connect the first audio level between source and destination.
  * Shuffle: allows users to connect the content of a level from the source to a different level on the destination, for example connecting the content of levels Audio 1 and Audio 2 on the source to levels Audio 3 and Audio 4 on the destination.
* Execution order: this number allows to control the order in which the different connections defined in a workflow will be set up during the workflow execution.
* Execution script

If a workflow is called between a source and a destination that do not contain a sender and a receiver respectively on one of the level specified in these settings, nothing will be connected

## Describing workflow execution behavior

Workflow can be executed either ad-hoc, when connecting sources & destinations from the [control surface](xref:control_surface_app), or scheduled, by planning a job based on a workflow in the [scheduling app](xref:scheduling_app). The workflow designer allows users to describe what needs to happen when a workflow execution is triggered. This is done by providing automation scripts in two places:

* Workflow execution script: this script describes the overall execution logic of the workflow. This script will always be triggered by the system when executing a workflow, ad-hoc or scheduled. The dataminer.MediaOps installation package comes with a default workflow execution script called 'Workflow.Default'. In essence, this default script will:
  * For all nodes in the workflow of type 'resource pool', find a resource that's available from that pool.
  * Iterate over the connection of the workflow in their 'execution order', and trigger the 'execution script' defined on that connection.
* Connection execution script: as mentioned above, this is an optional property of all connections in a workflow. It can be used to describe what exactly needs to happen when connecting the source of the connection to its destination. The dataminer.MediaOps installation package comes with a default connection execution script called 'Workflow.Connection.Default'. This script will connect the source and destination as described by the connection's type and subtype. By tweaking this script, users can change that behavior, or add additional logic to it.

The exact behavior of the default execution scripts is documented here: TBD.

> [!WARNING]
> Contrary to the workflow execution script, there is no guarantee that the system will always execute the connection execution scripts. If the user changes the content of the workflow execution script, it is their responsibility to make sure the connection execution script is still executed for every connection in the workflow, if needed.

---
uid: workflows
---

# Workflows

MediaOps is shipped with a [workflow designer](xref:workflow_designer_app), which allows operators to describe how signals (virtual signal groups) are processed from input to output using a sequence of nodes (resources or resource pools).

Execution of these workflows can be used both for ad-hoc connections and scheduled connections.

Below, you can find more information on how to configure what workflow to execute when setting up connections and the actions that occur when a workflow is executed.

> [!WARNING]
> This functionality is still under development and is subject to change!

## Which workflow will be executed

Determining what workflow will be executed, depends on how it is triggered.

The execution of the actual workflow though is the same, no matter how it was triggered.

### Ad hoc

When connecting a source (virtual signal group) to one or multiple destinations (virtual signal groups) from e.g. a control panel, a workflow is triggered immediately to set up that connection.

In that case, extra configuration is required to make sure the correct workflow is selected.

#### Workflow configuration

A type can be assigned to every virtual signal group.

![Virtual signal group type](~/user-guide/images/mediaops_vsg_type.png)

This allows to configure what workflow needs to be executed when a source of a specific type needs to be connected to a destination of a specific type.

![Workflow configuration](~/user-guide/images/mediaops_wf_configuration.png)

### Scheduled

When creating jobs, you can optionally select to base it on a workflow.

![Job with workflow](~/user-guide/images/mediaops_s_job_create.png)

In this case, the selected workflow will be executed at job start.

### Workflow execution

Each workflow should have a configured *workflow execution script*. This is the script that will be started when a workflow is executed.

![Workflow execution script](~/user-guide/images/mediaops_wf_execution_script.png)

When a new workflow is added using the [workflow designer](xref:workflow_designer_app), a [default script](#mediaopsworkflowdefault) will automatically be configured.

If you want to deviate from the default workflow execution behavior, you can configure a different script that should be used to execute a workflow.

#### MediaOps.Workflow.Default

The default script to execute a workflow, requires the following input:

- Source Virtual Signal Group
- Destination Virtual Signal Group
- Action (Connect or Disconnect)
- Workflow (reference to the workflow that is being executed)

The following input is optional, and only applicable in case the workflow is triggered from a job:

- Resources that should be used for every node
- Job (reference to the job triggering this workflow)

The workflow execution script will execute the following actions:

1. Find an available resource for every node in between the source and destination
1. Retrieve the input and output virtual signal groups from every resource
1. Trigger the *connection execution script* for every connection between nodes
1. Create a job (in case the workflow is not triggered from a job)

Similar to the workflow itself, every connection in a workflow also has a *connection execution script*. The configured script will be triggered to set up the individual connections between nodes.

When adding nodes in a workflow, a [default script](#mediaopsworkflowconnectiondefault) will automatically be configured for each connection.

If you want to deviate from the default connection execution behavior, you can configure a different script that should be used to execute the actual connection.

![Connection execution script](~/user-guide/images/mediaops_wf_connection_execution_script.png)

#### MediaOps.Workflow.Connection.Default

The default script to execute a workflow requires the following input:

- Source Virtual Signal Group
- Destination Virtual Signal Group
- Action (Connect or Disconnect)

This script will only be used to set up the connection between the flows that are part of these virtual signal groups.

[Flow engineering](xref:flow_engineering_app) is used to calculate the path for the different flow pairs in the source and destination, and is also used to inform the different nodes (elements) part of that path.

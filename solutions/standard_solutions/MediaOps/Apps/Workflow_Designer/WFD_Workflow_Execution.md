---
uid: WFD_Workflow_Execution
---


# Defining workflow execution behavior

Workflows can be either executed ad hoc, when sources and destinations are connected in the Control Surface app, or scheduled, by planning a job based on a workflow in the scheduling app. The Workflow Designer app allows you to describe what needs to happen when a workflow execution is triggered. This is done by providing Automation scripts in two places:

- **Workflow execution script**: This script describes the overall execution logic of the workflow. The script will always be triggered by the system when a workflow is executed, whether this is ad hoc or scheduled.

  The dataminer.MediaOps installation package comes with a default workflow execution script called *Workflow.Default*:

  - For all nodes of type "resource pool" in the workflow, this script will find a resource that is available from that pool.

  - The script will iterate over the connections of the workflow in the "execution order" and trigger the "execution script" defined on the connections.

- **Connection execution script**: This is an optional property of all connections in a workflow. It can be used to describe what exactly needs to happen when the source of the connection is connected to its destination.

  The dataminer.MediaOps installation package comes with a default connection execution script called *Workflow.Connection.Default*. This script will connect the source and destination as described by the connection's type and subtype. By tweaking this script, you can change that behavior or add additional logic to it.

  > [!NOTE]
  > Contrary to the workflow execution script, there is no guarantee that the system will always execute the connection execution script. If you change the content of the workflow execution script, it is your responsibility to make sure the connection execution script is still executed for every connection in the workflow if needed.

---
uid: MediaOps_Plan_2.0.1
---

# MediaOps Plan 2.0.1

## Fixes

### Scheduling: Incorrect placeholder label in the Insert Node panel [ID 47063]

The *Insert Node* panel in the Scheduling app showed an incorrect placeholder label, which could provide misleading guidance when inserting a node. It now displays the correct label.

This correction is limited to the displayed label; node insertion behavior and existing scheduling data remain unchanged.

### Installation reported success despite failed setup steps [ID 47116]

Installations and upgrades could report success even when a step in the Resource Studio or Resource Scheduling setup scripts failed. The errors were logged, but did not cause the installation to fail, leaving the setup partially completed.

The installation now reports a failure and lists the failed steps. If this occurs, resolve the reported errors and run the installation again.

The `MediaOpsScript` class also has a new opt-in setting to rethrow unhandled exceptions after logging them. This setting is disabled by default, so other scripts retain their existing behavior.

### Resource Pools category scope missing after installation or upgrade [ID 47117]

The *Resource Pools* category scope could be missing after an installation or upgrade. On a fresh installation, initial requests to the newly created *MOP Lock Manager* element could time out while the element was preparing to handle requests. This interrupted Resource Studio setup before the scope was created.

After deploying the solution elements, the installer now waits up to 5 minutes for the *MOP Lock Manager* and *PNO Lock Manager* elements to become active and respond to lock requests. If either element does not respond in time, the installation stops with an error message.

The Resource Studio and Resource Scheduling setup scripts also run each setup step independently. A step that times out is retried up to 3 times, with 15 seconds between retries. All failed steps are reported together at the end.

### Workflow node-edge graphs could show an incomplete state after node swaps [ID 47141]

After a node swap triggered additional swaps through scripts running in parallel, the node-edge graph in the Scheduling and Workflow Designer low-code apps could show an in-between state, such as a missing connection. You previously had to refresh the page to see the correct graph.

The `WorkflowDesigner_GQI_GetWorkflowNodesAndEdges` data source now supports real-time updates. It watches the displayed workflow instance and sends only the nodes and connections that were added, updated, or removed, so the graph shows the final state after multiple swaps. Changes made between the initial load and the start of updates are also picked up. Deleted or missing instances now return no rows instead of an error, and refresh errors are logged instead of being thrown.

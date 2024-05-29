---
uid: scheduling_job_creation
---

# Scheduling - Job Creation

## Create empty job

## Create job with nodes

## Create job based on workflow

## Create job with nodes and based on workflow

This can be done from the [Resource Timeline view](xref:scheduling_resource_timeline) or by using the helper class.

### Logic

MediaOps Scheduling will try to replace as much as possible workflow nodes by the selected ones when creating the job. This will be done by grouping the workflow nodes and selected nodes by their resource pool.
For each workflow resource pool combination following actions will be executed:

1. Check if workflow resource nodes are available in list of selected nodes.
1. Check if remainder of workflow resource nodes can be replaced by selected resource nodes.
1. Check if workflow resource pool nodes (precedence to automatic) can be replaced by selected resource nodes.
1. Check if workflow resource pool nodes can be replaced by selected resource pool nodes.

The remaining selected nodes will be added as single nodes.

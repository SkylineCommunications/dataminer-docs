---
uid: MO_S_Configuration
---

# Configuration Parameters

For operators (or automatic orchestration scripts) to configure resources correctly, it is possible to save configuration parameters values on jobs and/or nodes. Depending on the type of resource (or resource pool) added it is possible to define what type of parameters are expected. This can be defined on the resource (pool) from the [Resource Studio](xref:MO_Resource_Studio). Once the resource (pool) is added it can further be customized in the workflow or job. Once a job is created, it will be needed to provide a value for every parameter that is not optional before it can be moved to the confirmed state. When you have configuration parameters on different nodes that have to match the same value, it is possible to use placeholders on those to point to a parameter value on job level.

## Profile parameters and definitions

The first step will be to create [Profile parameters](https://docs.dataminer.services/user-guide/Standard_Apps/SRM/srm_concepts/srm_definitions.html#profile-parameter) and [Profile definitions](https://docs.dataminer.services/user-guide/Standard_Apps/SRM/srm_concepts/srm_definitions.html#profile-definition). The profile definition is a logical group of parameters that we will link later to our jobs or nodes within the job.

> [!TIP]
> Define only parameters that can differentiate between jobs to keep the configuration work minimal for operators. Make sure your profile parameters are easy to understand for operators. For example, video formats (e.g. 1080p, 1080i, 720p, ...) are more intuitive compared to defining BW that is needed on network level and the BW could be calculated based on the video format used. However, when capacity management is needed on a resource, then you need to define the capacity parameter on the corresponding node.

## Profile instances or presets

Optionally, when all the values for a profile definition are known upfront and can be reused, it is possible to create Profile instances (aka presets). Then you find a set of values back for a in a Profile definition and give that a name.

## Linking profile definitions to resources

The next step, is to define what configuration parameters are expected for a resource or resource pool. When a profile definition is linked on resource level everything on resource pool level will be ignored. Only one profile definition can be linked to a resource or resource pool.

## Adding nodes to jobs/workflows with configuration

Now that is defined what parameters are needed, we can start adding nodes to jobs or workflows. When configuration is not optional, it will be required to provide a value before the job can be confirmed.

## FAQ

**Why does the config for the node on my job not match with what is defined on the resource (pool)?**

Configuration parameters are inherited from the resource or resource pool at the time the node is added to a job/workflow. Any changes later (e.g. swapping or selecting of resource in a pool) will not have any effect on the node in the job/workflow.

**What will happen when my resource is available in multiple resource pools?**

When a resource is added as node to a job/workflow you always have to select a resource pool as well. The profile definition of the resource pool selected when adding the node will be used (unless profile definitions are defined on resource level).

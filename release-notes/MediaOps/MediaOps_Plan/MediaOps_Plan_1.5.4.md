---
uid: MediaOps_Plan_1.5.4
---

# MediaOps Plan 1.5.4 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires:
>
> - DataMiner 10.5.11/10.6.0 or higher.
> - The [GQI DxM](xref:GQI_DxM), which must be installed and enabled.
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.0 or higher.
> - [Categories](https://catalog.dataminer.services/details/c9666f3a-be26-42fd-83f2-6ee7fab4f11e) 1.1.0 or higher.

> [!TIP]
> Installing [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) alongside MediaOps Plan allows you to orchestrate jobs and workflows and fully automate the setup and teardown processes.

## Changes

### Enhancements

#### Scheduling: Resource swapping blocked when mandatory parameters are missing for a running or confirmed job [ID 45036]

Up to now, it was always possible to swap a resource for a confirmed or running job. Now this will no longer be possible in case mandatory parameters are missing. Before being able to swap the resource, the user will have to provide the values for these parameters via the red hand icon in the swap panel. Only after all mandatory information has been provided, will the user be able to swap the resource.

#### Unhandled exceptions in scripts now immediately flushed to log files [ID 45086]

As soon as an unhandled exception is caught in a script, the logging of the script is now flushed to the log files, even while the script is still running. Previously, this only happened when the script was closed.

### Fixes

#### Scheduling: Configuration UI incorrectly showed dropdown for running job [ID 45039]

In the window where you can view the configuration for a job and its nodes, it could occur that a dropdown was shown for the configuration section even when a job was already running, when no changes to the configuration should be possible.

#### Scheduling: Not possible to remove mandatory configuration added to node [ID 45048]

In the Scheduling app, you can use a filter to already create a configuration when adding or swapping nodes on your job. Up to now, in case the selected resource pool did not contain any configuration, you could add anything that is defined in the system. However, if you added mandatory configuration, you could no longer remove this.

#### Scheduling: Incorrect filter configuration applied when adding node to job [ID 45080]

When a node was added to a job from the Add Node panel, the settings defined in the Add Node panel were not taken into account for the node configuration. This issue has been resolved.

#### Scheduling: Empty filter window for Resource View when only configuration parameters were defined [ID 45083]

When you used the filter button on the Resource View page of the Scheduling app, but only configuration parameters were defined as orchestration settings on a resource pool, it could occur that the pop-up window only showed the *Apply* and *Reset* buttons without any filtering possibilities and without any further information. Now a pop-up message will be shown instead in such a case: "There are no capabilities or capacities available for filtering".

#### Missing linked pool validation in Plan API helpers [ID 45141]

The following validation related to resource pool links was missing in the Plan API helpers (Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan) and has now been added:

- It should not be possible to add a deprecated resource pool as a linked resource pool.
- Deprecating a resource pool should check if the pool is used as a linked pool.

#### Issues related to linked resource pools [ID 45160]

The following issues related to linked resource pools have been resolved:

- When a resource pool was edited in Resource Studio, all linked resource pools were removed in memory during initialization. When the user made other changes and click *Save*, the linked resource pools were removed completely.
- When a new pool link was added, it was no longer possible to change to which pool it was linked.

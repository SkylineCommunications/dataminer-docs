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

### Fixes

#### Scheduling: Configuration UI incorrectly showed dropdown for running job [ID 45039]

In the view configuration wizard, it could occur that a dropdown was shown for the configuration section even when a job was already running, when no changes to the configuration should be possible.

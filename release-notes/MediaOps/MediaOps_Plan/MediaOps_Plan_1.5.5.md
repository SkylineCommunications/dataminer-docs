---
uid: MediaOps_Plan_1.5.5
---

# MediaOps Plan 1.5.5 - Preview

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

## Fixes

#### Link to documentation not working [ID 45238]

On the *About* page of the MediaOps Plan apps, the help button no longer linked to the correct documentation pages. This issue has been resolved.

#### Scheduling: Incorrectly linked data source [ID 45239]

In the Scheduling app, one of the data sources was linked to the wrong panel. While this had no visible effect on the app, this has been fixed to prevent possible issues in the future.

#### Error when removing parameters from swap panel [ID 45399]

When parameters were removed from an existing node configuration during the pick/swap action, an error was thrown. This issue has been resolved.

#### Resource Studio: Not possible to select VSG that contained pipe character in its name [ID 45418]

When a virtual signal group (VSG) was created with a pipe character (`|`) in its name, it was not possible to select the VSG as an input or output VSG when editing a resource.

#### Scheduling: Incorrect daily pattern for recurring jobs [ID 45425]

When a recurring job was created with a daily pattern so that it would be repeated after a specific number of days, the second instance of the job incorrectly occurred after one additional day, after which the other instances of the job followed according to the configured interval. This issue has been resolved.

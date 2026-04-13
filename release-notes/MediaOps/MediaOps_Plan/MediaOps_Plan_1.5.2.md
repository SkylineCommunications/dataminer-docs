---
uid: MediaOps_Plan_1.5.2
---

# MediaOps Plan 1.5.2

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

### Fixes

#### Scheduling: Incorrect start and end time feeds in link node panel [ID 44985]

In the Scheduling app, the feed for the start and end time of the active job was incorrectly linked to the "swap resource" panel instead of the "link node" panel. Because of this, the displayed timeline did not reflect the resources in the selected job.

This has been fixed, ensuring that the correct data will now be displayed on the "link node" panel.

#### Resource Studio: Resource concurrency updates not saved [ID 44997]

If changes were made to the concurrency of a resource in the Complete state, it could occur that these were not saved properly.

#### People & Organization: Person added to bookable team became draft resource [ID 45008]

When a new person was added to a bookable team in the People & Organization app, this person could incorrectly end up as a resource in Draft state in Resource Studio.

#### Workflow Designer: Exception when swapping pool node to resource node [ID 45010]

When a pool node was swapped to a resource node in Workflow Designer, an exception could be thrown. This issue has been resolved.

#### Workflow Designer/Scheduling: Missing camera icon [ID 45012]

In the Workflow Designer and Scheduling apps, the camera icon was not displayed for pool and resource nodes in the workflow.

---
uid: MediaOps_Plan_1.5.3
---

# MediaOps Plan 1.5.3

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

#### People & Organization: Person/team skills not always applied as resource capabilities [ID 45021]

In some cases, it could occur that skills for a person or team were not correctly applied as resource capabilities. These issues have been resolved:

- When a person is added to a bookable team, their skills will now correctly be applied to the resource as capabilities.
- Individual resources will now properly receive their assigned capabilities during resource creation.
- When a team is made bookable, the team's capabilities will now correctly be provided on the associated resource pool.

#### Scheduling: Draft job locked without ID after red hand icon was clicked [ID 45028]

When the red hand icon was clicked for a job in Draft state, the lock job action was incorrectly already triggered before the job ID was filled in. This issue has been resolved.

#### Workflow Designer: Incorrect layout home page [ID 45029]

In the Workflow Designer app, it could occur that an incorrect layout was displayed for the home page. Even though everything on the page still functioned as expected, the style of the page did not match the expected style for the app.

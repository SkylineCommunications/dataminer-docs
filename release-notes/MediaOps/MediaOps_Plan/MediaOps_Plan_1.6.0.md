---
uid: MediaOps_Plan_1.6.0
---

# MediaOps Plan 1.6.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires:
>
> - DataMiner 10.6.5/10.7.0 or higher.
> - The [GQI DxM](xref:GQI_DxM), which must be installed and enabled.
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.0 or higher.
> - [Categories](https://catalog.dataminer.services/details/c9666f3a-be26-42fd-83f2-6ee7fab4f11e) 1.1.0 or higher.

> [!TIP]
> Installing [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) alongside MediaOps Plan allows you to orchestrate jobs and workflows and fully automate the setup and teardown processes.

## Changes

### Breaking changes

#### Plan API: Breaking changes in DevPack NuGet to ensure resource pool link is removed correctly [ID 45260]

To resolve an issue where removing a resource pool did not remove its link from the associated resource, the following breaking changes have been implemented in the DevPack NuGet.

- IResourcesRepository
  - `GetResourcesPerPool(IEnumerable<ResourcePool>)`:
    - Old return value: `IReadOnlyDictionary<ResourcePool, IEnumerable<Resource>`
    - new return value: `IReadOnlyDictionary<ResourcePool, IReadOnlyCollection<Resource>`
  - `GetResourcesPerPool(IEnumerable<ResourcePool>, ResourceState)`
    - Old return value: `IReadOnlyDictionary<ResourcePool, IEnumerable<Resource>`
    - New return value: `IReadOnlyDictionary<ResourcePool, IReadOnlyCollection<Resource>`
- IResourcePoolsRepository
  - `GetPoolsPerResource(IEnumerable<Resource>)`
    - Old return value: `IReadOnlyDictionary<Resource, IEnumerable<ResourcePool>`
    - New return value: `IReadOnlyDictionary<Resource, IReadOnlyCollection<ResourcePool>`
  - `GetParentPoolLinks(IEnumerable<ResourcePool>)`
    - Old return value: `IReadOnlyDictionary<Resource, IEnumerable<ResourcePool>`
    - New return value: `IReadOnlyDictionary<Resource, IReadOnlyCollection<ResourcePool>`

### Enhancements

#### Scheduling: Improved tooltips [ID 45190]

Throughout the Scheduling app, improved tooltips have been implemented to provide faster, in-context access to key job and configuration details.

- On the Job View page, hovering over a job now displays its name as well as the pre-roll start, job start, job end, and post-roll end time.
- On the Resource View page, hovering over a job now displays its name.
- In the Nodes table of the Edit Job panel, hovering over the icon in the Config Status column now displays assigned parameter details for capabilities, capacities, configurations, and configured automated actions.

These tooltips will reduce navigation effort and improve visibility during scheduling and job validation.

#### Plan API: No longer possible to update resources in Deprecated state [ID 45261]

For the sake of consistency with the other objects in the DevPack, it is now no longer possible for resources to be updated while they are in the Deprecated state.

#### Scheduling: Unavailable resources grayed out [ID 45288]

In the Scheduling app, on panels where you can pick or swap a resource, resources that are not available are now shown grayed out on a hatched background. Previously, unavailable resources were shown with a ⦻ icon in front of the resource name instead.

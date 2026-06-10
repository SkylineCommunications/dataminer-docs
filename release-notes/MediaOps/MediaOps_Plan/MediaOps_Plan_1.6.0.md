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

## New features

#### Code library to manage objects from the People and Organizations app [ID 45455]

New helper classes and methods are now available to manipulate the objects that are part of the People and Organizations app. Different NuGet packages have been made available for the different environments where these may be needed:

- For DataMiner in general: <https://www.nuget.org/packages/Skyline.DataMiner.Dev.Utils.Solutions.PeopleAndOrganizations>
- For automation scripts: <https://www.nuget.org/packages/Skyline.DataMiner.Dev.Utils.Solutions.PeopleAndOrganizations.Automation>
- For connectors: <https://www.nuget.org/packages/Skyline.DataMiner.Dev.Utils.Solutions.PeopleAndOrganizations.Protocol>
- For ad hoc data sources: <https://www.nuget.org/packages/Skyline.DataMiner.Dev.Utils.Solutions.PeopleAndOrganizations.GQI>

Code compiled against these packages can only be executed if MediaOps Plan has been installed on the DataMiner System.

#### Dynamic parameter linking [ID 45607]

When configuring a resource pool in Resource Studio or configuring a workflow in the Workflow Designer or Scheduling app, it is now possible to dynamically link parameter values to other data sources. Instead of manually entering fixed values for capabilities, capacities, configurations, or orchestration script input, you can now configure a link to dynamically resolve the value from another source such as a resource property, capability, capacity, configuration, or job property.

The value will be automatically determined on job update based on the linked source. The UI will show a placeholder indicating where the value comes from.

This new feature has several benefits:

- Less manual configuration
- More consistency across setups
- Dynamic linking based on resource selection

##### Configuring a parameter link

1. While you are editing a workflow or configuring a resource pool, click the 🔗 (link) button next to the parameter you want to link.

   The parameter can be a capability, capacity, configuration, or orchestration script input.

   If the parameter is not yet linked, the button has a neutral style; if it is already linked, the button appears highlighted (call-to-action style) and its tooltip shows the current link target.

1. In the *Configure Link* dialog, select the [link type](#available-link-types) from the dropdown at the top.

1. If the selected [link type is node-scoped](#node-scoped-link-types), in the node dropdown, select the node whose data you want to reference.

   Depending on the link type, a second dropdown will appear where you can select the specific target (e.g. which property, which capability, which capacity, etc.).

1. Click the *Link* button to confirm.

   The parameter field in the configuration dialog will now show a placeholder indicating the linked source.

##### Removing a parameter link

1. While you are editing a workflow or configuring a resource pool, locate the linked parameter (recognizable by the highlighted 🔗 button and placeholder text).

1. Click the 🔗 (link) button next to the parameter.

1. In the *Configure Link* dialog, click *Unlink*.

   This button is only shown for parameters that are currently linked. It will return the parameter to manual-entry mode and remove the link.

##### Available link types

The available link types depend on the parameter category being configured. Each link type resolves to a specific value or object within the workflow, job, or node context.

- **Resource Name**: Resolves to the name of the resource assigned to a node.

  Available for: Configuration parameters and orchestration script inputs.

- **Resource Property**: Resolves to a specific property value of the assigned resource.

  Available for: Configuration parameters, orchestration script inputs, and orchestration script elements.

- **Resource Linked Object ID**: Resolves to the linked object ID of the assigned resource.

  Available for: Configuration parameters, orchestration script inputs, and orchestration script elements.

- **Capability Parameter**: Resolves to the value of a capability configured on a node.

  Available for: Capability parameters, configuration parameters, and orchestration script inputs.

- **Capacity Parameter**: Resolves to the value of a capacity configured on a node.

  Available for: Capacity parameters, configuration parameters, and orchestration script inputs.

- **Configuration Parameter**: Resolves to the value of a configuration parameter on a node.

  Available for: Capability parameters, capacity parameters, configuration parameters, and orchestration script inputs.

- **Job Name**: Resolves to the name of the job.

  Available for: Configuration parameters and orchestration script inputs.

- **Job Property**: Resolves to a custom property defined on the job.

  Available for: Capability parameters, configuration parameters, orchestration script inputs, and orchestration script elements.

##### Node-Scoped Link Types

The following link types are node-scoped, meaning that a specific workflow node (or the workflow itself) must be selected to determine where the value should be resolved from:

- Resource Name
- Resource Property
- Resource Linked Object ID
- Capability Parameter
- Capacity Parameter
- Configuration Parameter

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

#### Orchestration events executed asynchronously [ID 45309]

Orchestration events for MediaOps Live are now executed asynchronously. This can prevent issues in case an event takes a long time or times out.

#### Version info about loaded libraries in SLAutomation added to About pages [ID 45400]

On the About pages of the MediaOps Plan apps, version information has been added about the loaded libraries in SLAutomation. This can be helpful as SLAutomation does not reload the new libraries after a new MediaOps version is installed, and a restart of SLAutomation is needed in that case.

#### Ability to push new icon to all workflows [ID 45620]

When you update the icon on a resource or resource pool, the system will verify if the resource or resource pool is used in any workflow. If the resource or resource pool is used in a workflow, you will now be asked whether the new icon should be applied across all workflows that reference it. When you choose to update all workflows, the system will trigger a background automation script supporting both resources and resource pools to update the icon on all corresponding referencing workflow nodes.

#### Improved workflow node visualization [ID 45666]

The workflow node visualization in the Scheduling and Workflow Designer apps has been improved:

- **Support for custom icons**: You can now configure custom icons for workflow nodes by adding them in the folder `C:\Skyline DataMiner\Webpages\Public\MediaOps\Icons`.
- **Improved node selection indication**: When a node is selected, the background will now change to make the selected node stand out better (regardless of whether a custom icon is used).
- **Clearer difference between resources and resource pools**: Resources and resource pools now use different colors and shapes so they can be easily told apart.
- **Hand icon shown**: When the node configuration is incomplete, a red hand icon is now displayed on the node within the Scheduling app.

### Fixes

#### Scheduling: Default value dropdown not updated after change to discrete values of system property [ID 45442]

When system properties of type discrete were configured, the dropdown to select the default value was not updated with the newly added or changed discrete values.

#### DevPack: Not possible to update capability name [ID 45544]

Up to now, it was not possible to update the name of a capability using the [MediaOps Plan DevPack](https://github.com/SkylineCommunications/Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Plan).

#### Resource Studio: Logging for resource property management not always stored in log file [ID 45587]

Attempting to add and save a new property to a resource that had a concurrency of 0 in Resource Studio would fail with the pop-up message "Something unexpected happened". However, no message was added in the Resources logging. Now this logging will be added to the related log file. Also, in case there is only one error, the error message is now shown in the pop-up message instead of the default log message.

#### Aborting a script caused it to be logged as failed [ID 45590]

Previously, closing an interactive script by clicking the X icon in the top-right corner resulted in the script being logged as failed. This behavior has been fixed, and such actions no longer mark the script as a failure.

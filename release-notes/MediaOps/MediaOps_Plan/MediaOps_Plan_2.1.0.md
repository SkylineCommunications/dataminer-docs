---
uid: MediaOps_Plan_2.1.0
---

# MediaOps Plan 2.1.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires:
>
> - DataMiner 10.7.2 or higher.
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.1.3 or higher.
> - [Categories](https://catalog.dataminer.services/details/c9666f3a-be26-42fd-83f2-6ee7fab4f11e) 1.3.0 or higher.

> [!TIP]
> Installing [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) alongside MediaOps Plan allows you to orchestrate jobs and workflows and fully automate the setup and teardown processes. This requires MediaOps Live **1.2.0** or higher.

## Enhancements

### Plan API: Unresolved reference errors now identify the node and setting [ID 46983]

When you confirm a job, the API now reports one `JobUnresolvedReferenceError` for each setting with an unresolved reference, instead of one error per distinct reference. As a result, multiple errors can have the same `Reference` label.

Each error now includes a `NodeId` and `SettingId` to identify where the reference is held. `NodeId` is `null` when the setting is on the job itself. `SettingId` is `null` for orchestration event references.

`UnresolvedReferenceException` is now obsolete because it was never thrown.

### Jobs and workflows now enforce resource pool flow rules [ID 47055]

Jobs, workflows, and recurring jobs now honor the flow rules defined on resource pools. Saving fails when it adds or changes a connection that a flow rule marks as **Forbidden**, returning a dedicated error for jobs, workflows, or recurring jobs.

Connections stored before a rule change do not block later edits, so changing rules in Resource Studio does not freeze existing or running jobs.

The `Jobs.Validate` method also reports forbidden connections as a `FlowRuleViolationJobValidationError` (code `J701`). MediaOps clears this error automatically the next time a save resolves the violation. Resource pools without flow rules are unaffected.

### IDs of node groups in jobs and workflows now exposed [ID 47092]

The IDs of node groups in jobs, recurring jobs, and workflows are now exposed, making it possible to identify existing groups when making changes (e.g., renaming a group or changing its nodes). Previously, when changes were made to node groups, those groups were removed and replaced by new groups.

### Virtual function resources now enforce instance limits [ID 47111]

When you save a resource that uses a virtual function, MediaOps Plan now checks the function's `MaxInstances` limit per element. Previously, only the virtual function table index was validated, so more instances than allowed could be created.

The new check applies to functions without entry points whose `MaxInstances` value is greater than 0. Existing instances on the same element count towards the limit, including instances created outside MediaOps Plan. Resources that already occupy a slot are not counted again. If a save or batch would exceed the limit, all new resources for that element and function are rejected.

Resource conversion now applies the same validation: functions with entry points are checked against the virtual function table index, while functions without entry points are checked against `MaxInstances`. Table-based functions remain limited by their table rows.

A new `ResourceFunctionMaxInstancesExceededError` identifies the Agent, element, function, and maximum allowed number of instances.

### Virtual signal group roles now validated for resources and jobs [ID 47112]

MediaOps Plan now validates the roles of the virtual signal groups (VSGs) used by resources and jobs. An input VSG must have the *Destination* role, and an output VSG must have the *Source* role. Previously, only the existence of the VSG was checked, so a VSG with the wrong role could be accepted.

- Saving a resource with a VSG of the wrong role is rejected with a `ResourceInvalidVirtualSignalGroupRoleError` identifying the VSG. If the role changes after the resource is saved, subsequent updates to the resource are also blocked.
- Job validation reports a `VirtualSignalGroupInvalidRoleJobValidationError` (code `J202`) when a VSG has the wrong role.

The check is skipped when MediaOps Live is not installed. Because the role is not exposed in the public API, role details are provided in the error message.

### Eligible resource results now include capability usage [ID 47129]

Eligible resource lookups now report capability usage in addition to the existing concurrency and capacity information.

For each capability, the results indicate whether it is time-dependent. For time-dependent capabilities, they also list overlapping bookings, including their start time, end time, and booked value. Capabilities that are not time-dependent are always treated as available, regardless of other bookings.

Two new options on the eligible resources request control which usage details are returned:

- `IncludeAllCapacityUsages`: Returns usage for every capacity of the eligible resources, rather than only the requested capacities.
- `IncludeAllCapabilityUsages`: Returns usage for every capability of the eligible resources, rather than only the requested capabilities.

Each request also has an identifier, which is returned as the context identifier in the result. This allows you to match results to their requests when running multiple lookups.

### System capabilities can no longer be changed through the API [ID 47140]

The DevPack now prevents direct API callers, such as the user-defined APIs, from creating, updating, or deleting built-in system capabilities, including the internal *Resource Type* capability (`RST_ResourceType`). Previously, the UI and GQI hid this capability, but consumers using the *Capabilities* repository could still modify or remove it.

Operations on a system capability now fail with a `CapabilitySystemCapabilityError`. In bulk operations, only the system capability is marked unsuccessful; the other items are processed as before.

> [!IMPORTANT]
> Creating a system capability through the *Capabilities* repository is no longer allowed. Any external script that creates `RST_ResourceType` through the *Capabilities* repository must switch to `SystemCapabilities.ResourceType`. The setup script already uses this.

## Fixes

### Unavailable job resources reported without an error message [ID 47125]

When an update caused a resource's reservations to be moved to quarantine, the affected job resource could be reported as unavailable without an error message explaining the issue.

The error now identifies the unavailable resource: "Resource '{name}' is not available during the requested time range." If the resource name cannot be found, the message uses the resource's identifier instead.

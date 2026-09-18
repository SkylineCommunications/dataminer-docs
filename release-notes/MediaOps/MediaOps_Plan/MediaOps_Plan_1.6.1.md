---
uid: MediaOps_Plan_1.6.1
---

# MediaOps Plan 1.6.1

> [!NOTE]
> This version requires:
>
> - DataMiner 10.6.4/10.7.0 or higher.
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.0 or higher.
> - [Categories](https://catalog.dataminer.services/details/c9666f3a-be26-42fd-83f2-6ee7fab4f11e) 1.1.0 or higher.

> [!TIP]
> Installing [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) alongside MediaOps Plan allows you to orchestrate jobs and workflows and fully automate the setup and teardown processes.

## Changes

### Enhancements

#### People & Organizations: Deprecating bookable contact person now deprecates linked resource as well [ID 45758]

When you deprecate a bookable contact person in the People & Organizations app, the linked resource is now automatically also deprecated.

#### Scheduling: Configuration changes now possible for job in Error state [ID 45760]

When a job is in the Error state, it will now be possible to change its configuration.

### Fixes

#### Resource Studio: Unnecessary extra confirmation message shown when clicking Deprecate without selected resources [ID 45757]

When you clicked the *Deprecate* button on the Resources page while no resource was selected, an unnecessary additional message was displayed asking you to confirm the selected resources to be deprecated, even after you had already clicked OK for an initial notification that no resources were selected. Now clicking OK for this initial notification will close the message without showing an additional message.

#### Scheduling: Job property placeholder not resolved correctly [ID 45764]

When placeholders were used to link to a job property, it could occur that the reference was not correctly resolved, linking to a node property instead.

#### Stale validation errors on jobs returned to tentative state [ID 45777]

Previously, when a confirmed job was returned to the tentative state, any reference validation errors (unresolved references, reservation mismatches, or live-event mismatches) raised while the job was confirmed remained on the job indefinitely. However, these checks do not apply to tentative jobs, so the errors were no longer relevant, but they were never cleared.

Returning a job to tentative now re-runs job validation, so these outdated errors are automatically cleared, and the job no longer shows errors that no longer apply.

#### Resource Studio: Not possible to remove capability from resource pool [ID 45840]

In Resource Studio, it was not possible to remove a capability from a resource pool.

#### Scheduling: Capacity usage not updated after job-level configuration change [ID 45864]

When a job-level configuration parameter was updated, it could occur that the resource capacity usage continued to reflect the previous value until another edit was done. This could lead to overuse of resources. Now capacity calculations use the latest edited configuration immediately, including values resolved through configuration references, ensuring that the capacity usage is accurate right after each update.

#### Scheduling: Configuration parameters linked to pool or resource references not applied when adding resource pool to job [ID 45872]

When a resource pool was added to a job as a node, its scheduling configuration was copied to the new node, but configuration parameters linked to a pool, resource name, resource property, or resource linked object were not associated with that node. As a result, these references could not be resolved when the job was confirmed. This issue has now been resolved.

#### Scheduling: Invalid resource swap not blocked on confirmed job [ID 45873]

Swapping a resource on a confirmed (or running) job to a resource that was missing a property referenced by an orchestration script input was not blocked. The swap completed, and only afterwards an unresolved-reference error was attached to the job, without a clear signal up front about which resource property was missing. This has now been fixed: such invalid swaps are blocked.

#### Scheduling: Orchestration event input arguments not updated after job configuration changes [ID 45874]

Editing a job or node configuration value (for example, orchestration event input arguments) did not update the scheduled orchestration event in MediaOps Live. This issue has now been resolved.

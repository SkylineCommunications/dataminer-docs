---
uid: MediaOps_Plan_1.6.1
---

# MediaOps Plan 1.6.1 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires:
>
> - DataMiner 10.6.4/10.7.0 or higher.
> - The [GQI DxM](xref:GQI_DxM), which must be installed and enabled.
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

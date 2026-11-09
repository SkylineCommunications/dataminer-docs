---
uid: MediaOps_Plan_2.1.0
---

# MediaOps Plan 2.1.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## Enhancements

### Plan API: Unresolved reference errors now identify the node and setting [ID 46983]

When you confirm a job, the API now reports one `JobUnresolvedReferenceError` for each setting with an unresolved reference, instead of one error per distinct reference. As a result, multiple errors can have the same `Reference` label.

Each error now includes a `NodeId` and `SettingId` to identify where the reference is held. `NodeId` is `null` when the setting is on the job itself. `SettingId` is `null` for orchestration event references.

`UnresolvedReferenceException` is now obsolete because it was never thrown.

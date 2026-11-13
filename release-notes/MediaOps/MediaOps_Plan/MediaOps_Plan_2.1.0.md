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

### Jobs and workflows now enforce resource pool flow rules [ID 47055]

Jobs, workflows, and recurring jobs now honor the flow rules defined on resource pools. Saving fails when it adds or changes a connection that a flow rule marks as **Forbidden**, returning a dedicated error for jobs, workflows, or recurring jobs.

Connections stored before a rule change do not block later edits, so changing rules in Resource Studio does not freeze existing or running jobs.

The `Jobs.Validate` method also reports forbidden connections as a `FlowRuleViolationJobValidationError` (code `J701`). MediaOps clears this error automatically the next time a save resolves the violation. Resource pools without flow rules are unaffected.

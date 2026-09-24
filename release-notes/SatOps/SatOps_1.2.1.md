---
uid: SatOps_1.2.1
---

# SatOps 1.2.1 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires:
>
> - DataMiner 10.5.11/10.6.0 or higher, as well as DataMiner Web 10.6.2 or higher.
> - [MediaOps Plan 1.6.0](xref:MediaOps_Plan_1.6.0) or higher.

## Fixes

### Satellite Scheduling: Job creation failed on systems using MediaOps Plan 1.6.2 [ID 46603]

When you created a job directly from Satellite Scheduling on a system using MediaOps Plan 1.6.2, an object reference error could occur.

The NuGet package references for MediaOps.Plan 1.6.2 have now been corrected to fix this issue.

---
uid: MediaOps_Live_1.1.1
---

# MediaOps Live 1.1.1 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!TIP]
> Installing [MediaOps Plan](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) alongside MediaOps Live allows you to schedule orchestration events. MediaOps Live requires MediaOps Plan 1.5.0 or higher.

## Enhancements

*No enhancements have been added to this release yet.*

## Fixes

### Virtual signal group import/export behaved inconsistently for duplicate endpoint assignments [ID 46286]

Previously, when the same endpoint was assigned more than once within a virtual signal group (VSG), import and export could behave differently: import might accept the data, while export could fail.

This has been corrected:

- **Export continues when VSG issues are detected**: Instead of failing completely, the export now continues and reports errors at the individual item level.
- **Duplicate endpoints in source VSGs are handled correctly**: Reusing the same endpoint across multiple levels in a source VSG no longer causes export errors.
- **Import validation now follows the intended rules**:
  - Duplicate endpoint assignments are **allowed** for **source** VSGs.
  - Duplicate endpoint assignments are **blocked** for **destination** VSGs.

### Scheduler: Finished tasks not cleaned up correctly [ID 46216]

Finished scheduled tasks were not cleaned up correctly, which caused completed tasks to accumulate in [DataMiner Scheduler](xref:About_the_Scheduler_module). This issue has now been fixed.

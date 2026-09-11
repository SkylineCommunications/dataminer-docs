---
uid: MediaOps_Live_1.1.1
---

# MediaOps Live 1.1.1 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires:
>
> - DataMiner 10.5.11 or higher.
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.0 or higher.
> - [Categories](https://catalog.dataminer.services/details/c9666f3a-be26-42fd-83f2-6ee7fab4f11e) 1.2.5 or higher.

> [!TIP]
> Installing [MediaOps Plan](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) alongside MediaOps Live allows you to schedule orchestration events. This requires MediaOps Plan **1.5.0** or higher.

## Enhancements

*No enhancements have been added to this release yet.*

## Fixes

#### Installer: Downgrade attempts now fail explicitly instead of being skipped [ID 46060]

Previously, if you attempted to install an older version of MediaOps Live while a newer compatible version was already installed, the installation could be logged as "skipped". In some cases, DataMiner could still register the incoming package version internally.

As a result, the version effectively running on the system could differ from the version tracked by DataMiner, which could cause confusion during follow-up upgrades or troubleshooting.

This behavior has now been changed. In downgrade scenarios where a newer compatible version is already present, the installation now fails explicitly instead of continuing as a soft skip. This ensures the version registered by DataMiner remains aligned with the version that is actually installed and active on the system.

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

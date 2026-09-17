---
uid: MediaOps_Live_1.1.2
---

# MediaOps Live 1.1.2 - Preview

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

### Orchestration input dialogs could fail for short preset-group labels [ID 46522]

When you ran an orchestration script that requested parameter values, the input dialog could fail to open if a preset group label contained fewer than five characters. Instead, the script stopped with an unexpected error because the dialog calculated a column width of zero.

The dialog now always uses a minimum column width of one, so preset group labels with fewer than five characters, including empty labels, no longer cause the orchestration script to fail.

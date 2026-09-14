---
uid: MediaOps_Plan_1.6.3
---

# MediaOps Plan 1.6.3 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires:
>
> - DataMiner 10.6.4/10.7.0 or higher.
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.0 or higher.
> - [Categories](https://catalog.dataminer.services/details/c9666f3a-be26-42fd-83f2-6ee7fab4f11e) 1.1.0 or higher.

> [!TIP]
> Installing [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) alongside MediaOps Plan allows you to orchestrate jobs and workflows and fully automate the setup and teardown processes.

## Fixes

### Memory leak caused by GQI data sources [ID 46451]

When a GQI data source encountered an error while setting up internal watchers to detect changes to workflows, jobs, or resource reservations, watchers that had already been created were not properly released. Repeated failures could accumulate leaked resources over time. In addition, if a data source was stopped before it had fully started, cleanup could fail unexpectedly instead of completing safely.

To prevent these issues, cleanup logic has now been consolidated into a single, safe routine that correctly releases all watchers regardless of how many were successfully created and that can be called multiple times without error. This routine now runs consistently whenever the data source starts up, stops, fails during startup, or is destroyed, ensuring that resources are always released properly.

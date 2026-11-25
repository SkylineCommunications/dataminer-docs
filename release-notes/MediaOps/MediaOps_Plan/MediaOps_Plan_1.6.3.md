---
uid: MediaOps_Plan_1.6.3
---

# MediaOps Plan 1.6.3

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

When you navigated through the MediaOps Plan apps, an error in the GQI data sources could cause some of their data to be cleaned up incorrectly. If this occurred repeatedly, it could cause leaked resources to accumulate over time.

The cleanup logic has now been improved to prevent this issue.

### Error dialogs did not stop scripts [ID 46635]

When you clicked OK in an error dialog in an interactive MediaOps Plan script, it could occur that this incorrectly did not stop the script. For example, adding a Transponder resource to a job without a workflow displayed an error stating that resources are managed through an external application, but still added the resource.

This affected checks for job state, missing mandatory configuration, resource availability, and swaps, across all interactive scripts using the shared MediaOps scripting infrastructure.

This issue has been resolved. Clicking OK in an error dialog will now correctly stop the script.

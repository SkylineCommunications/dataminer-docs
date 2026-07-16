---
uid: MediaOps_Plan_1.6.2
---

# MediaOps Plan 1.6.2 - Preview

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

## Changes

### Fixes

#### Scheduling: MediaOps Live events failed when job was started manually or stopped early [ID 45968]

Since [ID 45309](xref:MediaOps_Plan_1.6.0#orchestration-events-executed-asynchronously-id-45309), MediaOps Live events are executed asynchronously for a manual start. In specific cases, this could cause the Engine object to be cleaned up while the script was still running, which could cause MediaOps Live events to fail when a job was started manually or stopped early.

This issue has now been fixed.

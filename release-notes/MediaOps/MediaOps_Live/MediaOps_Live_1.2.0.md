---
uid: MediaOps_Live_1.2.0
description: Highlights of the features, enhancements, and fixes included in the MediaOps Live 1.2.0 release, including improved CSV encoding.
---

# MediaOps Live 1.2.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!TIP]
> Installing [MediaOps Plan](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) alongside MediaOps Live allows you to schedule orchestration events. This requires MediaOps Plan **1.5.0** or higher.

## Enhancements

### DevPack: Asynchronous orchestration event execution [ID 46394]

The MediaOps Live DevPack now supports asynchronous execution of previously saved orchestration events. You can use the new `ExecuteEventsNowInBackground` methods on `OrchestrationHelper` to start event execution without blocking the calling script.

You can provide the event IDs:

```csharp
IEnumerable<Guid> eventIds =
[
    firstEventId,
    secondEventId,
];

orchestrationHelper.ExecuteEventsNowInBackground(eventIds);
```

Alternatively, you can provide the corresponding `OrchestrationEvent` objects directly:

```csharp
orchestrationHelper.ExecuteEventsNowInBackground(orchestrationEvents);
```

The DevPack will launch the `ORC-AS-EventOrchestration` automation script as a deferred fire-and-forget task and immediately return control to the caller. You must save the events before calling either method because the background script retrieves them by ID.

When you start an event scheduled for the future this way, its scheduled task will be removed to prevent duplicate execution. Failures during background execution will continue to be reported in the state of the associated job.

## Fixes

### CSV import and export could handle special characters incorrectly [ID 46381]

When importing endpoint or virtual signal group data from CSV files, special characters such as the degree symbol (°) could be parsed incorrectly, especially in files saved using the legacy Microsoft Excel CSV format.

CSV imports now support both UTF-8 and Windows-1252 encoding, preserving special characters during import and provisioning. CSV exports now use UTF-8 encoding with a byte order mark (BOM), allowing Microsoft Excel to detect the encoding correctly when opening exported files.

---
uid: MaintenanceSettings.DMSRevision
---

# DMSRevision element

Specifies when a full DataMiner System (DMS) synchronization should occur, ensuring all DataMiner Agents are fully aligned by triggering a complete system-wide sync at the configured time(s).

While typically scheduled once per day (e.g. the "midnight sync" at 00:00:00), multiple synchronization times can be configured if needed.

Default: Only at 00:00:00.

## Parents

[MaintenanceSettings](xref:MaintenanceSettings)

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| [StartTime](xref:MaintenanceSettings.DMSRevision.StartTime) | [1, *] | The start time. |

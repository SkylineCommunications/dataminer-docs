---
uid: MaintenanceSettings.DMSRevision
---

# DMSRevision element

Specifies when a full DataMiner System (DMS) synchronization should occur. This typically happens once per day and is also known as the "midnight sync". It ensures that all DataMiner Agents are fully in sync by triggering a complete system-wide sync at the configured time.

Default: Only at 00:00:00.

## Parents

[MaintenanceSettings](xref:MaintenanceSettings)

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| [StartTime](xref:MaintenanceSettings.DMSRevision.StartTime) | [1, *] | The start time. |

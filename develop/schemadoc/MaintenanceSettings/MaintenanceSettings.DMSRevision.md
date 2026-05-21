---
uid: MaintenanceSettings.DMSRevision
---

# DMSRevision element

Also known as the "midnight sync". Specifies when a full DataMiner System (DMS) synchronization should occur, typically once per day. It ensures all DataMiner Agents are fully in sync by triggering a complete system-wide sync at the configured times. Default: Only at 00:00:00.

## Parents

[MaintenanceSettings](xref:MaintenanceSettings)

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| [StartTime](xref:MaintenanceSettings.DMSRevision.StartTime) | [1, *] | The start time. |

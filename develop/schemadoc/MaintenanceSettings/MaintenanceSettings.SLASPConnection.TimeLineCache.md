---
uid: MaintenanceSettings.SLASPConnection.TimeLineCache
---

# TimeLineCache element

Specifies options for the caching of timeline data in the SLASPConnection process.

## Parents

[SLASPConnection](xref:MaintenanceSettings.SLASPConnection)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [enabled](xref:MaintenanceSettings.SLASPConnection.TimeLineCache-enabled) | string |  | Enables or disables timeline caching. |
| [expirationTime](xref:MaintenanceSettings.SLASPConnection.TimeLineCache-expirationTime) | nonNegativeInteger |  | Determines how long an entry remains in the cache (in s). Default value: 300s.|
| [gracePeriod](xref:MaintenanceSettings.SLASPConnection.TimeLineCache-gracePeriod) | nonNegativeInteger |  | When Reporter has detected a change in the timeline data, the cached data will still be removed after this duration (in s). Default value: 60s.|
| [logVerbose](xref:MaintenanceSettings.SLASPConnection.TimeLineCache-logVerbose) | string |  | Enables or disables additional logging in the SLASPConnection.txt log file indicating whether a timeline request was resolved from the database or from the cache. |
| [maxRecords](xref:MaintenanceSettings.SLASPConnection.TimeLineCache-maxRecords) | nonNegativeInteger |  | Specifies the maximum number of trend records in the cache. Older entries will be removed to make room for new entries. Default value: 1000000. |

## Remarks

> [!NOTE]
> These settings are **not synchronized** among the Agents in a DMS.

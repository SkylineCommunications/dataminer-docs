---
uid: GetActiveAlarmPagesForService
---

# GetActiveAlarmPagesForService

Use this method to retrieve the number of active alarms of a service, grouped either by time span (today, yesterday, etc.) or by severity (critical, major, etc.).

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp).  |
| dmaID      | Integer | The DataMiner Agent ID.                               |
| serviceID  | Integer | The service ID.                                       |
| groupOn    | String  | The property by which to group: “time” or “severity”. |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmPagesForServiceResult | Array of (Array of String) | The number of active alarms of the specified service, grouped per time span. For every time span, the method returns an array containing the time span or the severity, the number of alarms in that time span or with that severity, and the highest severity found among those alarms. |

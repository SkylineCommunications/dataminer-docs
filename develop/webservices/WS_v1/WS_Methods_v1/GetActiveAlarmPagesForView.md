---
uid: GetActiveAlarmPagesForView
---

# GetActiveAlarmPagesForView

Use this method to retrieve the number of active alarms of a view, grouped either by time span (today, yesterday, etc.) or by severity (critical, major, etc.).

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID     | Integer | The view ID.                                          |
| groupOn    | String  | The property by which to group: “time” or “severity”. |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmPagesForViewResult | Array of (Array of String) | The number of active alarms of the specified view, grouped either by time span or by severity. For every time span, the method returns an array containing the time span or the severity, the number of alarms in that time span or with that severity, and the highest severity found among those alarms. |

> [!NOTE]
> If you request the numbers grouped by severity, you get a GetActiveAlarmPagesForViewResult like the following:<br> *\["Critical","94","Critical"\],\["Error","1","Error"\],\["Major","7","Major"\],\["Minor","60","Minor"\],\["Notice","4","Notice"\],\["Timeout","3","Timeout"\], \["Warning","45","Warning"\]*

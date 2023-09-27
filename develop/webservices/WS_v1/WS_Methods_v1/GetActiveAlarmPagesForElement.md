---
uid: GetActiveAlarmPagesForElement
---

# GetActiveAlarmPagesForElement

Use this method to retrieve the number of active alarms of an element, grouped either by time span (today, yesterday, etc.) or by severity (critical, major, etc.).

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp).  |
| dmaID      | Integer | The DataMiner Agent ID.                               |
| elementID  | Integer | The element ID.                                       |
| groupOn    | String  | The property by which to group: “time” or “severity”. |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveAlarmPagesForElementResult | Array of (Array of String) | The number of active alarms of the specified element, grouped by time span or severity. For every time span, the method returns an array containing the time span or the severity, the number of alarms in that time span or with that severity, and the highest severity found among those alarms. |

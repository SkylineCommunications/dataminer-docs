---
uid: GetAvailableAlarmProperties
---

# GetAvailableAlarmProperties

Use this method to retrieve all properties that are available for alarm filtering.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetAvailableAlarmPropertiesResult | Array of [DMAProperty](xref:DMAProperty) | An array with all properties available for alarm filtering. |

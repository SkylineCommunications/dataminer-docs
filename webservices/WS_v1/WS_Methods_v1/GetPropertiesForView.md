---
uid: GetPropertiesForView
---

# GetPropertiesForView

Use this method to retrieve all the properties for a particular view.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ViewID     | Integer | The view ID.                                                                     |

## Output

| Item | Format | Description |
|--|--|--|
| GetPropertiesFor­ViewResult | Array of [DMAProperty](xref:DMAProperty) | All the properties for the specified view. |

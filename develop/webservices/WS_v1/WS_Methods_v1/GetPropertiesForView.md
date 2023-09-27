---
uid: GetPropertiesForView
---

# GetPropertiesForView

Use this method to retrieve all the properties for a particular view.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID     | Integer | The view ID.                                                                     |

## Output

| Item | Format | Description |
|--|--|--|
| GetPropertiesForViewResult | Array of [DMAProperty](xref:DMAProperty) | All the properties for the specified view. |

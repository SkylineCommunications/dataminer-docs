---
uid: GetViewByName
---

# GetViewByName

Use this method to retrieve the data of a particular view by name.

## Input

| Item       | Format | Description                                           |
|------------|--------|-------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewName   | String | The view name.                                        |

## Output

| Item                | Format                  | Description                     |
|---------------------|-------------------------|---------------------------------|
| GetViewByNameResult | [DMAView](xref:DMAView) | The data of the specified view. |

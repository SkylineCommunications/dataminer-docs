---
uid: GetViewByName
---

# GetViewByName

Use this method to retrieve the data of a particular view by name.

## Input

| Item       | Format | Description                                                                      |
|------------|--------|----------------------------------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ViewName   | String | The view name.                                                                   |

## Output

| Item                | Format                                         | Description                     |
|---------------------|------------------------------------------------|---------------------------------|
| GetViewByNameResult | [DMAView](xref:DMAView) | The data of the specified view. |

---
uid: GetView
---

# GetView

Use this method to retrieve the data of a particular view.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID     | Integer | The view ID.                                          |

## Output

| Item          | Format                  | Description                     |
|---------------|-------------------------|---------------------------------|
| GetViewResult | [DMAView](xref:DMAView) | The data of the specified view. |

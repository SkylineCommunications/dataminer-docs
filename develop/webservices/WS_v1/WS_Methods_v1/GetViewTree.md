---
uid: GetViewTree
---

# GetViewTree

Use this method to retrieve the view structure within the specified parent view.

## Input

| Item         | Format  | Description                                           |
|--------------|---------|-------------------------------------------------------|
| connection   | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| parentViewID | Integer | The ID of the parent view.                            |

## Output

| Item              | Format                          | Description                                          |
|-------------------|---------------------------------|------------------------------------------------------|
| GetViewTreeResult | [DMAViewTree](xref:DMAViewTree) | The view structure within the specified parent view. |

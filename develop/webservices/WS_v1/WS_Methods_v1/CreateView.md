---
uid: CreateView
---

# CreateView

Use this method to create a new view.

## Input

| Item         | Format  | Description                                               |
|--------------|---------|-----------------------------------------------------------|
| connection   | String  | The connection string. See [ConnectApp](xref:ConnectApp). |
| parentViewID | Integer | The ID of the parent view.                                |
| viewName     | String  | The name of the new view.                                 |

## Output

| Item             | Format  | Description  |
|------------------|---------|--------------|
| CreateViewResult | Integer | The ID of the new view. |

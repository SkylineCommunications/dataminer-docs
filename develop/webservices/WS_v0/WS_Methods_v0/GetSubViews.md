---
uid: GetSubViews
---

# GetSubViews

Use this method to request the names of all subviews of a specified view.

## Input

| Item           | Format | Description                                   |
|----------------|--------|-----------------------------------------------|
| connection     | String | The connection ID. See [Connect](xref:Connect). |
| parentViewName | String | The name of the parent view.                  |

## Output

| Item              | Format          | Description                                          |
|-------------------|-----------------|------------------------------------------------------|
| GetSubViewsResult | Array of string | The names of all the subviews of the specified view. |

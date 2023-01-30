---
uid: GetVisioPagesForView
---

# GetVisioPagesForView

Use this method to retrieve a list of the pages of the Visio file linked to a particular view.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID     | Integer | The view ID.                                                                     |

## Output

| Item | Format | Description |
|--|--|--|
| GetVisioPagesForViewResult | Array of [DMAVisioPage](xref:DMAVisioPage) | A list of the pages of the Visio file linked to the view. |

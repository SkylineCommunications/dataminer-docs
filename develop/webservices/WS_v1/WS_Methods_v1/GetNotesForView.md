---
uid: GetNotesForView
---

# GetNotesForView

Use this method to retrieve the notes for a particular view.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID     | Integer | The view ID.                                          |

## Output

| Item | Format | Description |
|--|--|--|
| GetNotesForViewResult | Array of [DMANote](xref:DMANote) | The notes for the specified view. |

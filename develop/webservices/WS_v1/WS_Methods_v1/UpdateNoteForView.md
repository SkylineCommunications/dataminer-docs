---
uid: UpdateNoteForView
---

# UpdateNoteForView

Use this method to update a specific note for a particular view.

## Input

| Item       | Format  | Description                                                                          |
|------------|---------|--------------------------------------------------------------------------------------|
| connection | String  | The connection string. See [ConnectApp](xref:ConnectApp). |
| viewID     | Integer | The ID of the view for which the note should be updated.                             |
| note.ID    | Integer | The ID of the note.                                                                  |

## Output

| Item                     | Format  | Description         |
|--------------------------|---------|---------------------|
| UpdateNoteForViewResult | Integer | The ID of the note. |

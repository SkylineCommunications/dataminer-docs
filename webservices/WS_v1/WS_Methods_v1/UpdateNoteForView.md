---
uid: UpdateNoteForView
---

# UpdateNoteForView

Use this method to update a specific note for a particular view.

## Input

| Item       | Format  | Description                                                                          |
|------------|---------|--------------------------------------------------------------------------------------|
| Connection | String  | The connection string. See [ConnectApp](xref:ConnectApp). |
| ViewID     | Integer | The ID of the view for which the note should be updated.                             |
| Note.ID    | Integer | The ID of the note.                                                                  |

## Output

| Item                     | Format  | Description         |
|--------------------------|---------|---------------------|
| UpdateNoteForView­Result | Integer | The ID of the note. |

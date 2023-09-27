---
uid: RemoveNoteFromView
---

# RemoveNoteFromView

Use this method to remove a specific note from a particular view.

## Input

| Item       | Format  | Description                                                                          |
|------------|---------|--------------------------------------------------------------------------------------|
| connection | String  | The connection string. See [ConnectApp](xref:ConnectApp). |
| viewID     | Integer | The ID of the view from which the note should be removed.                            |
| noteID     | Integer | The ID of the note.                                                                  |

## Output

| Item                      | Format  | Description         |
|---------------------------|---------|---------------------|
| RemoveNoteFromViewResult | Integer | The ID of the note. |

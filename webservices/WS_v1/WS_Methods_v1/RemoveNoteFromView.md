---
uid: RemoveNoteFromView
---

# RemoveNoteFromView

Use this method to remove a specific note from a particular view.

## Input

| Item       | Format  | Description                                                                          |
|------------|---------|--------------------------------------------------------------------------------------|
| Connection | String  | The connection string. See [ConnectApp](xref:ConnectApp) . |
| ViewID     | Integer | The ID of the view from which the note should be removed.                            |
| NoteID     | Integer | The ID of the note.                                                                  |

## Output

| Item                      | Format  | Description         |
|---------------------------|---------|---------------------|
| RemoveNoteFrom­ViewResult | Integer | The ID of the note. |


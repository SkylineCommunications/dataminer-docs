---
uid: RemoveNoteFromElement
---

# RemoveNoteFromElement

Use this method to remove a specific note from a particular element.

## Input

| Item       | Format  | Description                                                                          |
|------------|---------|--------------------------------------------------------------------------------------|
| Connection | String  | The connection string. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                              |
| ElementID  | Integer | The ID of the element from which the note should be removed.                         |
| NoteID     | Integer | The ID of the note.                                                                  |

## Output

| Item                         | Format  | Description         |
|------------------------------|---------|---------------------|
| RemoveNoteFrom­ElementResult | Integer | The ID of the note. |

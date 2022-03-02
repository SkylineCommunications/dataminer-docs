---
uid: UpdateNoteForElement
---

# UpdateNoteForElement

Use this method to update a specific note for a particular element.

## Input

| Item       | Format  | Description                                                                          |
|------------|---------|--------------------------------------------------------------------------------------|
| Connection | String  | The connection string. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                              |
| ElementID  | Integer | The ID of the element for which the note should be updated.                          |
| Note.ID    | Integer | The ID of the note.                                                                  |

## Output

| Item                        | Format  | Description         |
|-----------------------------|---------|---------------------|
| UpdateNoteFor­ElementResult | Integer | The ID of the note. |

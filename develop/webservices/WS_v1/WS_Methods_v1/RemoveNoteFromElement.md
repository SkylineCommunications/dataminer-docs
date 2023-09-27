---
uid: RemoveNoteFromElement
---

# RemoveNoteFromElement

Use this method to remove a specific note from a particular element.

## Input

| Item       | Format  | Description                                                                          |
|------------|---------|--------------------------------------------------------------------------------------|
| connection | String  | The connection string. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                              |
| elementID  | Integer | The ID of the element from which the note should be removed.                         |
| noteID     | Integer | The ID of the note.                                                                  |

## Output

| Item                         | Format  | Description         |
|------------------------------|---------|---------------------|
| RemoveNoteFromElementResult | Integer | The ID of the note. |

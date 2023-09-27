---
uid: UpdateNoteForElement
---

# UpdateNoteForElement

Use this method to update a specific note for a particular element.

## Input

| Item       | Format  | Description                                                                          |
|------------|---------|--------------------------------------------------------------------------------------|
| connection | String  | The connection string. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                              |
| elementID  | Integer | The ID of the element for which the note should be updated.                          |
| note.ID    | Integer | The ID of the note.                                                                  |

## Output

| Item                        | Format  | Description         |
|-----------------------------|---------|---------------------|
| UpdateNoteForElementResult | Integer | The ID of the note. |

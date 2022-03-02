---
uid: UpdateNoteForService
---

# UpdateNoteForService

Use this method to update a specific note for a particular service.

## Input

| Item       | Format  | Description                                                                          |
|------------|---------|--------------------------------------------------------------------------------------|
| Connection | String  | The connection string. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                              |
| ServiceID  | Integer | The ID of the service for which the note should be updated.                          |
| Note.ID    | Integer | The ID of the note.                                                                  |

## Output

| Item                        | Format  | Description         |
|-----------------------------|---------|---------------------|
| UpdateNoteFor­ServiceResult | Integer | The ID of the note. |

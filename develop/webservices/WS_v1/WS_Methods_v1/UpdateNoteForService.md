---
uid: UpdateNoteForService
---

# UpdateNoteForService

Use this method to update a specific note for a particular service.

## Input

| Item       | Format  | Description                                                                          |
|------------|---------|--------------------------------------------------------------------------------------|
| connection | String  | The connection string. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                              |
| serviceID  | Integer | The ID of the service for which the note should be updated.                          |
| note.ID    | Integer | The ID of the note.                                                                  |

## Output

| Item                        | Format  | Description         |
|-----------------------------|---------|---------------------|
| UpdateNoteForServiceResult | Integer | The ID of the note. |

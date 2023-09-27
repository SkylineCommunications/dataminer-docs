---
uid: RemoveNoteFromService
---

# RemoveNoteFromService

Use this method to remove a specific note from a particular service.

## Input

| Item       | Format  | Description                                                                          |
|------------|---------|--------------------------------------------------------------------------------------|
| connection | String  | The connection string. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                              |
| serviceID  | Integer | The ID of the service from which the note should be removed.                         |
| noteID     | Integer | The ID of the note.                                                                  |

## Output

| Item                         | Format  | Description         |
|------------------------------|---------|---------------------|
| RemoveNoteFromServiceResult | Integer | The ID of the note. |

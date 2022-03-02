---
uid: RemoveNoteFromService
---

# RemoveNoteFromService

Use this method to remove a specific note from a particular service.

## Input

| Item       | Format  | Description                                                                          |
|------------|---------|--------------------------------------------------------------------------------------|
| Connection | String  | The connection string. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                              |
| ServiceID  | Integer | The ID of the service from which the note should be removed.                         |
| NoteID     | Integer | The ID of the note.                                                                  |

## Output

| Item                         | Format  | Description         |
|------------------------------|---------|---------------------|
| RemoveNoteFrom­ServiceResult | Integer | The ID of the note. |


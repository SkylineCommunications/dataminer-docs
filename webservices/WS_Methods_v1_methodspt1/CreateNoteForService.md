---
uid: CreateNoteForService
---

# CreateNoteForService

Use this method to create a note for a specific service.

## Input

| Item       | Format     | Description                                                                                                                                                                                                                                                                                                                                                                                             |
|------------|------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Connection | String     | The connection string. See [ConnectApp](xref:ConnectApp) .                                                                                                                                                                                                                                                                                                                                                |
| DmaID      | Integer    | The DataMiner Agent ID.                                                                                                                                                                                                                                                                                                                                                                                 |
| ServiceID  | Integer    | The ID of the service to which the note should be added.                                                                                                                                                                                                                                                                                                                                                |
| Note       | DMANoteNew | Array consisting of:<br> -  String Summary<br> -  String Description<br> -  Long TimeExpiresUTC (“0” if the note does not expire, otherwise the number of milliseconds since midnight January 1, 1970 GMT) |

## Output

| Item                        | Format  | Description         |
|-----------------------------|---------|---------------------|
| CreateNoteForService­Result | Integer | The ID of the note. |


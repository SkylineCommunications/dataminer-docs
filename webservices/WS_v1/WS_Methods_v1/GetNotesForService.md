---
uid: GetNotesForService
---

# GetNotesForService

Use this method to retrieve the notes for a particular service.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ServiceID  | Integer | The service ID.                                                                  |

## Output

| Item                      | Format                                                                | Description                          |
|---------------------------|-----------------------------------------------------------------------|--------------------------------------|
| GetNotesForService­Result | Array of DMANote (see [DMANote](xref:DMANote)) | The notes for the specified service. |


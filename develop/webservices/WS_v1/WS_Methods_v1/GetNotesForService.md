---
uid: GetNotesForService
---

# GetNotesForService

Use this method to retrieve the notes for a particular service.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| serviceID  | Integer | The service ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetNotesForServiceResult | Array of [DMANote](xref:DMANote) | The notes for the specified service. |

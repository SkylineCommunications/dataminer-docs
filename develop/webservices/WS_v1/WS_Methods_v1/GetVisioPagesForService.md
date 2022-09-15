---
uid: GetVisioPagesForService
---

# GetVisioPagesForService

Use this method to retrieve a list of the pages of the Visio file linked to a particular service.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| serviceID  | Integer | The service ID.                                                                  |

## Output

| Item                           | Format                | Description                                                  |
|--------------------------------|-----------------------|--------------------------------------------------------------|
| GetVisioPagesForServiceResult | Array of [DMAVisioPage](xref:DMAVisioPage) | A list of the pages of the Visio file linked to the service. |

---
uid: GetVisioPagesForService
---

# GetVisioPagesForService

Use this method to retrieve a list of the pages of the Visio file linked to a particular service.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ServiceID  | Integer | The service ID.                                                                  |

## Output

| Item                           | Format                | Description                                                  |
|--------------------------------|-----------------------|--------------------------------------------------------------|
| GetVisioPagesFor­ServiceResult | Array of DMAVisioPage | A list of the pages of the Visio file linked to the service. |


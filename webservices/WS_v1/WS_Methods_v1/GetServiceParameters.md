---
uid: GetServiceParameters
---

# GetServiceParameters

Use this method to retrieve a list of all the parameters of a particular service.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ServiceID  | Integer | The service ID.                                                                  |

## Output

| Item                        | Format                                                                                                                             | Description                                              |
|-----------------------------|------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------|
| GetServiceParame­tersResult | Array of DMAServiceParame­tersElement (see [DMAServiceParametersElement](xref:DMAServiceParametersElement)) | The list of all the parameters of the specified service. |


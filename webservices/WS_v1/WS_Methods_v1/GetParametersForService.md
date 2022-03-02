---
uid: GetParametersForService
---

# GetParametersForService

Use this method to retrieve the data of all the parameters of a particular service.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ServiceID  | Integer | The service ID.                                                                  |

## Output

| Item                           | Format                                                                               | Description                                              |
|--------------------------------|--------------------------------------------------------------------------------------|----------------------------------------------------------|
| GetParametersForSer­viceResult | Array of DMAParameter (see [DMAParameter](xref:DMAParameter)) | The data of all the parameters of the specified service. |


---
uid: GetServiceConfiguration
---

# GetServiceConfiguration

Use this method to retrieve the configuration info for the specified service.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ServiceID  | Integer | The service ID.                                                                  |

## Output

| Item                           | Format                                                                         | Description                                 |
|--------------------------------|--------------------------------------------------------------------------------|---------------------------------------------|
| GetServiceConfigura­tionResult | [DMAServiceConfiguration](xref:DMAServiceConfiguration) | The configuration of the specified service. |


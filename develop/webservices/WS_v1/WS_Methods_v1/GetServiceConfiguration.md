---
uid: GetServiceConfiguration
---

# GetServiceConfiguration

Use this method to retrieve the configuration info for the specified service.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                               |
| serviceID  | Integer | The service ID.                                       |

## Output

| Item | Format | Description |
|--|--|--|
| GetServiceConfigurationResult | [DMAServiceConfiguration](xref:DMAServiceConfiguration) | The configuration of the specified service. |

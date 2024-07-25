---
uid: GetServiceParameters
---

# GetServiceParameters

Use this method to retrieve a list of all the parameters of a particular service.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                               |
| serviceID  | Integer | The service ID.                                       |

## Output

| Item | Format | Description |
|--|--|--|
| GetServiceParametersResult | Array of [DMAServiceParametersElement](xref:DMAServiceParametersElement) | The list of all the parameters of the specified service. |

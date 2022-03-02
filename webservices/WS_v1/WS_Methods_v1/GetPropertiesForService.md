---
uid: GetPropertiesForService
---

# GetPropertiesForService

Use this method to retrieve all the properties for a particular service.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ServiceID  | Integer | The service ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetPropertiesFor­ServiceResult | Array of [DMAProperty](xref:DMAProperty) | All the properties for the specified service. |

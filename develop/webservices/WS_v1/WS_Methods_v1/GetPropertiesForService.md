---
uid: GetPropertiesForService
---

# GetPropertiesForService

Use this method to retrieve all the properties for a particular service.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| serviceID  | Integer | The service ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetPropertiesForServiceResult | Array of [DMAProperty](xref:DMAProperty) | All the properties for the specified service. |

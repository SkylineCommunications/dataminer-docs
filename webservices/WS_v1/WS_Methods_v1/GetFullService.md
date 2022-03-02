---
uid: GetFullService
---

# GetFullService

Use this method to retrieve all data of a particular service, including a list of its parameters and its properties. This method effectively combines the GetService, GetServiceParameters and GetPropertiesForService methods. (Available from DataMiner 9.5.8 onwards.)

> [!TIP]
> See also:
> -  [GetPropertiesForService](xref:GetPropertiesForService)
> -  [GetService](xref:GetService)
> -  [GetServiceParameters](xref:GetServiceParameters)

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                              |
| ServiceID  | Integer | The service ID.                                      |

## Output

| Item                 | Format                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              | Description                                 |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------|
| GetFullServiceResult | Array of:<br> -  DMAElement (see [DMAElement](xref:DMAElement))<br> -  DMAServiceParametersElement (see [DMAServiceParametersElement](xref:DMAServiceParametersElement)) objects<br> -  DMAProperty (see [DMAProperty](xref:DMAProperty)) objects | The complete data of the specified service. |


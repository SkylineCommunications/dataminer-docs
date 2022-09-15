---
uid: CreateServiceByApplyingServiceTemplate
---

# CreateServiceByApplyingServiceTemplate

Use this method to create a service by applying a specified service template.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| serviceTemplateID | Integer | The ID of the service template that should be applied. |
| viewIDs | Array of string | The IDs of the views where the service should be created. |
| inputData | Array of DMAServiceTemplateInputData | Array of DMAServiceTemplateInputData objects, which are in turn an array of string denoting the name and value of the input data. |

> [!NOTE]
> It is possible to call this method without specifying the input data, for instance if you do not know which fields need to be specified. In that case, if data are missing in order to create the service, the result of the method will contain a MissingData array with the fields that still need to be specified. You can then call the method again and specify the missing information.

## Output

| Item | Format | Description |
|--|--|--|
| CreateServiceByApplyingServiceTemplateResult | [DMAServiceTemplateMissingData](xref:DMAServiceTemplateMissingData) | An array indicating any input data that are still missing in order to apply the service template. |

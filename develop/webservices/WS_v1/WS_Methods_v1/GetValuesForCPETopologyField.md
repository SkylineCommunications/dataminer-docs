---
uid: GetValuesForCPETopologyField
---

# GetValuesForCPETopologyField

Use this method to retrieve the possible values of a particular topology field of a CPE element.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The CPE element ID. |
| fieldPID | Integer | The parameter ID that is used to request possible field values, retrieved via the GetTopologyFieldsForCPEChain method. See [GetTopologyFieldsForCPEChain](xref:GetTopologyFieldsForCPEChain). |
| filters | Array of string | A string array of filters in the format “VALUE=TableIndexPID == theSelectedValue“. |

## Output

| Item | Format | Description |
|--|--|--|
| GetValuesForCPETopologyFieldResult | Array of [DMAGenericProperty](xref:DMAGenericProperty) | The possible values of the specified topology field of the CPE element. |

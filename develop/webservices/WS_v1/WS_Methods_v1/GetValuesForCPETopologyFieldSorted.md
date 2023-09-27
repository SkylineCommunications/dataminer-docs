---
uid: GetValuesForCPETopologyFieldSorted
---

# GetValuesForCPETopologyFieldSorted

Use this method to retrieve the possible values of a particular topology field of a CPE element, sorted according to their position.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The CPE element ID. |
| fieldPID | Integer | The parameter ID that is used to request possible field values, retrieved via the GetTopologyFieldsForCPEChain method. See [GetTopologyFieldsForCPEChain](xref:GetTopologyFieldsForCPEChain). |
| filters | Array of string | Server-side table filters. See [Filters](xref:GetTableForParameterFiltered#filters). |

## Output

| Item | Format | Description |
|--|--|--|
| GetValuesForCPETopologyFieldSortedResult | [DMATopologyFieldValues](xref:DMATopologyFieldValues) | The topology field values, sorted according to their position, with the total page count of the results and the number of the current page. |

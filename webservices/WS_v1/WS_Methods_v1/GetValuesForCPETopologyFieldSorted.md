---
uid: GetValuesForCPETopologyFieldSorted
---

# GetValuesForCPETopologyFieldSorted

Use this method to retrieve the possible values of a particular topology field of a CPE element, sorted according to their position.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID | Integer | The DataMiner Agent ID. |
| ElementID | Integer | The CPE element ID. |
| FieldPID | Integer | The parameter ID that is used to request possible field values, retrieved via the GetTopologyFieldsForCPEChain method. See [GetTopologyFieldsForCPEChain](xref:GetTopologyFieldsForCPEChain). |
| Filters | Array of string | Server-side table filters. See [Filters](xref:GetTableForParameterFiltered#filters). |

## Output

| Item | Format | Description |
|--|--|--|
| GetValuesForCPE­TopologyFieldSorted­Result | [DMATopologyFieldValues](xref:DMATopologyFieldValues) | The topology field values, sorted according to their position, with the total page count of the results and the number of the current page. |

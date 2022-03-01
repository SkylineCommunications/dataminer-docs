---
uid: GetValuesForCPETopologyFieldV2
---

# GetValuesForCPETopologyFieldV2

Use this method to retrieve the possible values of a particular topology field of a CPE element by page.

## Input

| Item       | Format          | Description                                                                                                                                                                                 |
|------------|-----------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Connection | String          | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                                                                            |
| DmaID      | Integer         | The DataMiner Agent ID.                                                                                                                                                                     |
| ElementID  | Integer         | The CPE element ID.                                                                                                                                                                         |
| FieldPID   | Integer         | The parameter ID that is used to request possible field values, retrieved via the GetTopologyFieldsForCPEChain method. See [GetTopologyFieldsForCPEChain](xref:GetTopologyFieldsForCPEChain). |
| Filters    | Array of string | Server-side table filters. See [Filters](xref:GetTableForParameterFiltered#filters).                                                                                                          |

## Output

| Item                                  | Format                                                                       | Description                                                                                             |
|---------------------------------------|------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------|
| GetValuesForCPE­TopologyFieldV2Result | [DMATopologyFieldValues](xref:DMATopologyFieldValues) | The topology field values, with the total page count of the results and the number of the current page. |


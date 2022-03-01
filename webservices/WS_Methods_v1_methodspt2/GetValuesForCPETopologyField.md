---
uid: GetValuesForCPETopologyField
---

# GetValuesForCPETopologyField

Use this method to retrieve the possible values of a particular topology field of a CPE element.

## Input

| Item       | Format          | Description                                                                                                                                                                                 |
|------------|-----------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Connection | String          | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                                                                            |
| DmaID      | Integer         | The DataMiner Agent ID.                                                                                                                                                                     |
| ElementID  | Integer         | The CPE element ID.                                                                                                                                                                         |
| FieldPID   | Integer         | The parameter ID that is used to request possible field values, retrieved via the GetTopologyFieldsForCPEChain method. See [GetTopologyFieldsForCPEChain](xref:GetTopologyFieldsForCPEChain). |
| Filters    | Array of string | A string array of filters in the format “VALUE=TableIndexPID == theSelectedValue“.                                                                                                          |

## Output

| Item                                | Format                                                                                                  | Description                                                             |
|-------------------------------------|---------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------|
| GetValuesForCPE­TopologyFieldResult | Array of DMAGenericProp­erty (see [DMAGenericProperty](xref:DMAGenericProperty)) | The possible values of the specified topology field of the CPE element. |


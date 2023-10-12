---
uid: DMAParameterEdit
---

# DMAParameterEdit

| Item | Format | Description |
|--|--|--|
| ParameterID | Integer | The ID of the parameter. |
| Type | String | The type of write parameter: “String”, “Discreet”, “Number”, ... |
| Name | String | The name of the parameter. |
| Value | String | The current value of the parameter. |
| DisplayValue | String | The parameter value that will be displayed. |
| Discreets | Array of [DMAParameterEditDiscreet](xref:DMAParameterEditDiscreet) | The discreet values of the parameter (only if *Type* is “Discreet”). |
| HasRange | Boolean | Whether the value of the parameter has to be within a certain range (which is defined in the protocol). |
| RangeHigh | Double | The maximum value to which the parameter can be set. |
| RangeLow | Double | The minimum value to which the parameter can be set. |
| RangeStep | Double | The step size. If *RangeStep* is 5, then the parameter value has to be in the series {... , -5, 0, 5, 10, 15, 20, ...}. |
| Options | String | The parameter options (extra flags to e.g. indicate special formatting instructions). |

> [!NOTE]
> From DataMiner 10.3.8/10.4.0 onwards, the value of a date or datetime parameter is passed as a Unix timestamp in milliseconds. In earlier DataMiner versions, the value is passed as an OLE Automation date.

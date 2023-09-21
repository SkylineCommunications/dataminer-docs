---
uid: DMAParameter
---

# DMAParameter

| Item | Format | Description |
|--|--|--|
| DataMinerID | Integer | The ID of the DataMiner Agent. |
| ElementID | Integer | The ID of the element. |
| Value | String | The current value of the parameter. |
| DisplayValue | String | The parameter value that will be displayed. |
| LastValueChange | String | The last time the value of the parameter has changed. |
| LastValueChangeUTC | Long integer | The last time the value of the parameter has changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| Positions | Array of [DMAParameterPosition](xref:DMAParameterPosition) | The places where the parameter can be found in the different Data Display pages of the element. |
| Type | String | The type of parameter: “Read”, “Write”, or “Table”. |
| WriteType | String | The type of write parameter: “String”, “Discreet”, “Number”, ... |
| ReadType | String | The type of read parameter. |
| AlarmState | String | The current alarm state of the parameter. |
| IsTrending | Boolean | Whether the value of the parameter is being trended. |
| Filters | String | Column and row filters, only filled in when using the method *GetParametersByPageForServiceElement*, in case only part of a table is included in the service. |
| LastChangeUTC | Long integer | The time when the parameter last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |

> [!NOTE]
> From DataMiner 10.3.8/10.4.0 onwards, the value of a date or datetime parameter is passed as a Unix timestamp in milliseconds. In earlier DataMiner versions, the value is passed as an OLE Automation date.

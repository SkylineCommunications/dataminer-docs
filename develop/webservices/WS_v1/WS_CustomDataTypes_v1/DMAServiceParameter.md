---
uid: DMAServiceParameter
---

# DMAServiceParameter

| Item | Format | Description |
|--|--|--|
| DataMinerID | Integer | The ID of the DataMiner Agent. |
| ElementID | Integer | The ID of the service. |
| ParameterID | Integer | The ID of the parameter. |
| TableIndex | String | The display key of the table row (in case of a table parameter). |
| ParameterName | String | The name of the parameter. |
| Value | String | The current value of the parameter. |
| DisplayValue | String | The parameter value that will be displayed. |
| LastValueChange | String | The last time the value of the parameter has changed. |
| LastValueChangeUTC | Long integer | The last time the value of the parameter has changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| Positions | Array of [DMAParameterPosition](xref:DMAParameterPosition) | The places where the parameter can be found in the different Data Display pages of the element. |
| Discreets | Array of [DMAParameterEditDiscreet](xref:DMAParameterEditDiscreet) | The discreet values of the parameter (only if WriteType is “Discreet”) |
| Type | String | The type of parameter: “Read”, “Write”, or “Table”. |
| InfoSubText | String | The parameter description. |
| WriteType | String | The type of write parameter: “String”, “Discreet”, “Number”, ... |
| IsMonitored | Boolean | Whether the value of the parameter is being monitored by an alarm template. |
| AlarmState | String | The current alarm state of the parameter. |
| IsTrending | Boolean | Whether the value of the parameter is being trended. |
| Options | String | The parameter options (extra flags to e.g., indicate special formatting instructions). |
| LastChangeUTC | Long integer | The time when the parameter last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |

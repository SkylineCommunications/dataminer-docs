---
uid: DMAParameterInfo
---

# DMAParameterInfo

| Item | Format | Description |
|--|--|--|
| ID | Integer | The ID of the parameter. |
| ParameterName | String | The name of the parameter. |
| InfoSubText | String | The parameter description. |
| IsMonitored | Boolean | Whether the value of the parameter is being monitored by an alarm template. |
| IsNumerical | Boolean | Whether the value of the parameter is numerical. |
| HasRange | Boolean | Determines whether the value of the parameter is defined within a certain range. |
| RangeLow | Double | If *HasRange* is true, this determines the lowest value of the parameter range. |
| RangeHigh | Double | If *HasRange* is true, this determines the highest value of the parameter range. |
| Options | String | The parameter options (extra flags to e.g. indicate special formatting instructions). |
| Unit | String | The unit of measure of the parameter. |
| PrimaryKeyID | Integer | If the parameter is a table parameter, the primary key. |
| DisplayKeyID | Integer | If the parameter is a table parameter, the display key. |
| IsLogarithmic | Boolean | Indicates whether the trend data of this parameter should be displayed on a logarithmic scale. |
| IsTableColumn | Boolean | Whether or not the parameter is a table column parameter. |
| IsTable | Boolean | Whether or not the parameter is a table parameter. |
| TableParameterID | Integer | If the parameter is a column parameter, this indicates the ID of the table parameter. |
| Discreets | Array of [DMAParameterEditDiscreet](xref:DMAParameterEditDiscreet) | The discreet values of the parameter (only if *WriteType* is “Discreet”). |
| DashboardsType | String | The button panel dashboard type: *None*, *ButtonPanel*, *ButtonPanelContainers* or *ButtonPanelCollection*. |

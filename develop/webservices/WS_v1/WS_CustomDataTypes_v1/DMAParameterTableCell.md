---
uid: DMAParameterTableCell
---

# DMAParameterTableCell

| Item          | Format       | Description              |
|---------------|--------------|--------------------------|
| ParameterID   | Integer      | The ID of the parameter. |
| Name          | String       | The name of the parameter. |
| Value         | String       | The current value of the parameter. |
| DisplayValue  | String       | The parameter value that will be displayed. |
| InfoSubText   | String       | The parameter description. |
| Type          | String       | The type of parameter: “Read”, “Write”, or “Table”. |
| WriteType     | String       | The type of write parameter: “String”, “Discreet”, “Number”, ... |
| AlarmState    | String       | The current alarm state of the parameter. |
| IsMonitored   | Boolean      | Whether the value of the parameter is being monitored by an alarm template. |
| IsTrending    | Boolean      | Whether the value of the parameter is being trended. |
| IsNumber      | Boolean      | Whether the table cell contains a number.<br>Inside a table, numbers are usually aligned to the right, while text is aligned to the left. |
| IsSortedASC   | Boolean      | Whether the table cell is part of a column that is sorted in ascending order (sorting order is defined in the protocol). |
| IsSortedDESC  | Boolean      | Whether the table cell is part of a column that is sorted in descending order (sorting order is defined in the protocol). |
| LastChangeUTC | Long integer | The time when the table cell last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |

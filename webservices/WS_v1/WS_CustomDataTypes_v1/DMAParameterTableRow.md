---
uid: DMAParameterTableRow
---

# DMAParameterTableRow

| Item | Format | Description |
|--|--|--|
| DataMinerID | Integer | The ID of the DataMiner Agent. |
| ElementID | Integer | The ID of the element. |
| ParameterID | Integer | The ID of the parameter. |
| Index | Integer | The number of the column that contains the primary key. |
| IndexValue | String | The value of the primary key. |
| DisplayIndex | Integer | The number of the column that contains the display key. |
| DisplayIndexValue | String | The value of the display key. |
| TrendKey | String | The tableIndex that should be used to request trend data (depending on whether advanced naming is used or not). |
| Position | Integer | The sequence number of the row. |
| AlarmState | String | The current alarm state of the table row. |
| Cells | Array of [DMAParameterTableCell](xref:DMAParameterTableCell) | The cells contained in the table row. |
| LastChangeUTC | Long integer | The time when the table row last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |

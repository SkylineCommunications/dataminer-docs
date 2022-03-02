---
uid: DMAParameterTableRowV2
---

# DMAParameterTableRowV2

| Item              | Format                                                                                        | Description                                                                                                     |
|-------------------|-----------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------|
| Index             | Integer                                                                                       | The number of the column that contains the primary key.                                                         |
| IndexValue        | String                                                                                        | The value of the primary key.                                                                                   |
| DisplayIndex      | Integer                                                                                       | The number of the column that contains the display key.                                                         |
| DisplayIndexValue | String                                                                                        | The value of the display key.                                                                                   |
| TrendKey          | String                                                                                        | The tableIndex that should be used to request trend data (depending on whether advanced naming is used or not). |
| Position          | Integer                                                                                       | The sequence number of the row.                                                                                 |
| AlarmState        | String                                                                                        | The current alarm state of the table row.                                                                       |
| Cells             | Array of DMAParameter­TableCellV2 (see [DMAParameterTableCellV2](xref:DMAParameterTableCellV2)) | The cells contained in the table row.                                                                           |
| LastChangeUTC     | Long integer                                                                                  | The time when the table row last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT).      |

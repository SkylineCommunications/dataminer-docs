---
uid: DMAParameterTableColumn
---

# DMAParameterTableColumn

| Item          | Format  | Description                                                                           |
|---------------|---------|---------------------------------------------------------------------------------------|
| ProtocolIndex | Integer | The position of the column in the table, as defined in the protocol.                  |
| Type          | String  | The type of parameter: “Read”, “Write”, or “Table”.                                   |
| WriteType     | String  | The type of write parameter: “String”, “Discreet”, “Number”, ...                      |
| IsPrimaryKey  | Boolean | Indicates whether the column contains the primary keys.                               |
| IsDisplayKey  | Boolean | Indicates whether the column contains the display keys.                               |
| IsElementLink | Boolean | Whether the column is linked to a different DataMiner object.                         |
| IsSortedASC   | Boolean | Whether or not the column is sorted in ascending order (as defined in the protocol).  |
| IsSortedDESC  | Boolean | Whether or not the column is sorted in descending order (as defined in the protocol). |

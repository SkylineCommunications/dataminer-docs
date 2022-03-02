---
uid: DMAParameterTableCellV2
---

# DMAParameterTableCellV2

| Item          | Format       | Description                                                                                                 |
|---------------|--------------|-------------------------------------------------------------------------------------------------------------|
| Value         | String       | The current value of the parameter.                                                                         |
| DisplayValue  | String       | The displayed parameter value.                                                                              |
| AlarmState    | String       | The current alarm state of the parameter.                                                                   |
| IsTrending    | Boolean      | Whether the value of the parameter is being trended.                                                        |
| LastChangeUTC | Long integer | The time when the table cell last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |

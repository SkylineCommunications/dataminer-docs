---
uid: AnalogTrendDataResponseMessage
---

# AnalogTrendDataResponseMessage

| Item         | Format            | Description                                                                                                                                           |
|--------------|-------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------|
| Avg          | Array of Double   | The trend values (average trending).                                                                                                                  |
| EndTime      | DateTime          | The timestamp of the last trend value.                                                                                                                |
| Max          | Array of Double   | The maximum values (only in case of average trending).                                                                                                |
| Min          | Array of Double   | The minimum values (only in case of average trending).                                                                                                |
| StartTime    | DateTime          | The timestamp of the first trend value.                                                                                                               |
| Data         | Array of Double   | The trend values (real-time trending or average trending).                                                                                            |
| FailReason   | String            | If the requested trend data could not be retrieved, this field will contain the error message.                                                        |
| HasFailed    | Boolean           | Whether or not the request for trend data failed.                                                                                                     |
| ParameterID  | Integer           | The parameter ID.                                                                                                                                     |
| ParameterIdx | String            | The display key of the table row (in case the parameter is a table parameter).                                                                        |
| Status       | Array of Integer  | iStatus values: 0, 5, 60, ..., or negative values indicating gaps in the graph.<br> See the list of iStatus values in the DataMiner User Guide.       |
| Timestamps   | Array of DateTime | The timestamps of the data points in Avg, *Max*, *Min* and *Status*. |

> [!NOTE]
> The arrays *Avg*,* Min*, *Max*, *Status* and *Timestamps* always have the same number of values.

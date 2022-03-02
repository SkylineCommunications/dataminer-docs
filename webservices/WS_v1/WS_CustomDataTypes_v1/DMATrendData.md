---
uid: DMATrendData
---

# DMATrendData

| Item        | Format                                                                                           | Description                                                                                                                                                          |
|-------------|--------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Avg         | Array of Double                                                                                  | The trend values (which can be either average trending or real-time trending).                                                                                       |
| Min         | Array of Double                                                                                  | The minimum values (only in case of average trending).                                                                                                               |
| Max         | Array of Double                                                                                  | The maximum values (only in case of average trending).                                                                                                               |
| Timestamps  | Array of long integer                                                                            | The timestamps in UTC format (milliseconds since midnight January 1, 1970 GMT). Note that these values should be divided by 1000 to get the correct boundary values. |
| StartTime   | Long integer                                                                                     | The timestamp of the first date value, in UTC format (milliseconds since midnight January 1, 1970 GMT).                                                              |
| EndTime     | Long integer                                                                                     | The timestamp of the last date value, in UTC format (milliseconds since midnight January 1, 1970 GMT).                                                               |
| Error       | String                                                                                           | If the requested trend data could not be retrieved, this field will contain the error message.                                                                       |
| Units       | String                                                                                           | The unit of measure of the trend values.                                                                                                                             |
| Logarithmic | Boolean                                                                                          | Whether or not the graph has to be drawn logarithmically.                                                                                                            |
| Exceptions  | Array of DMAParameter­EditDiscreet (see [DMAParameterEditDiscreet](xref:DMAParameterEditDiscreet)) | The exception values (by which the trend values will be replaced if necessary).                                                                                      |
| Discreets   | Array of DMAParameter­EditDiscreet (see [DMAParameterEditDiscreet](xref:DMAParameterEditDiscreet)) | The discreet values (by which the trend values will be replaced if necessary).                                                                                       |

> [!NOTE]
> The arrays *Avg*, *Min*, *Max* and *Timestamps* always have the same number of values.

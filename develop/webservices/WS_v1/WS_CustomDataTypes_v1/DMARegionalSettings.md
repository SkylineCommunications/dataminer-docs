---
uid: DMARegionalSettings
---

# DMARegionalSettings

| Item                       | Format                 | Description                                                                       |
|----------------------------|------------------------|-----------------------------------------------------------------------------------|
| ListDelimiter              | String                 | The list separator.                                                               |
| NumberDecimalDelimiter    | String                 | The decimal symbol.                                                               |
| NumberGroupDelimiter       | String                 | The digit grouping symbol.                                                        |
| TimeZone.DisplayValue      | String                 | The display name of the time zone.                                                |
| TimeZone.Value.Name        | String                 | The unique name of the time zone (e.g. “Romance Standard Time”).                  |
| TimeZone.Value.Labels      | Array of string        | The different time zone names corresponding with this time zone.                  |
| TimeZone.Value.TimeStamps | Array of long integers | The different start and end times corresponding with the labels.                  |
| TimeZone.Value.Offsets     | Array of long integers | The offset values (compared to UTC) corresponding with the labels and timestamps. |

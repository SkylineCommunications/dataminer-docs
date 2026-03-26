---
uid: DMATimeZoneInfo
---

# DMATimeZoneInfo

| Item             | Format                 | Description                                                                       |
|------------------|------------------------|-----------------------------------------------------------------------------------|
| DisplayValue     | String                 | The display name of the time zone.                                                |
| Value.Name       | String                 | The unique name of the time zone (e.g., “Romance Standard Time”).                  |
| Value.Labels     | Array of string        | The different time zone names corresponding with this time zone.                  |
| Value.Timestamps | Array of long integers | The different start and end times corresponding with the labels.                  |
| Value.Offsets    | Array of long integers | The offset values (compared to UTC) corresponding with the labels and timestamps. |

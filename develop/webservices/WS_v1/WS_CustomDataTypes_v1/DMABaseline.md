---
uid: DMABaseline
---

# DMABaseline

| Item           | Format  | Description                                                                                                                                                      |
|----------------|---------|------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Enable         | Boolean | Whether automatic updating of the baselines is enabled.                                                                                                          |
| Cyclic         | Boolean | Whether the baselines are update to detect a change in the daily pattern or not.                                                                                 |
| HandleWeekends | Boolean | Whether weekends are handled separately or not.                                                                                                                  |
| IntervalCount  | Integer | The number of days of the trend window to detect a deviation in the expected daily pattern.                                                                      |
| IntervalLength | Integer | The number of days (in seconds, e.g., 1 day = 86400) of the trend window to detect a continuous degradation.                                                      |
| IntervalOffset | Integer | In case the last X hours in the configured trend window need to be skipped, this item indicates this number of hours, expressed in seconds (e.g., 1 hour = 3600). |
| AverageType    | String  | Not used.                                                                                                                                                        |

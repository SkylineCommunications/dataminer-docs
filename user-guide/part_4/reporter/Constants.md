---
uid: Constants
---

# Constants

This section contains an overview of constants you can use when publishing Reporter components on a website.

## Alarm distribution graph types

| Constant               | Equivalent | Description                             |
|------------------------|------------|-----------------------------------------|
| DISTRIBUTION_DAY       | 1          | Last 24 hours, plus an all-time average |
| DISTRIBUTION_WEEK      | 2          | Last 7 days, plus an all-time average   |
| DISTRIBUTION_MONTH     | 3          | Last month                              |
| DISTRIBUTION_YESTERDAY | 7          | Yesterday                               |

## Trend graph types

| Constant        | Equivalent | Description                         |
|-----------------|------------|-------------------------------------|
| TREND_HOUR      | 1          | Last hour (1 value every 5 minutes) |
| TREND_DAY       | 2          | Last day (1 value every 5 minutes)  |
| TREND_WEEK      | 3          | Last week (1 value every hour)      |
| TREND_MONTH     | 4          | Last month (1 value every hour)     |
| TREND_YEAR      | 5          | Last year (1 value every day)       |
| TREND_YESTERDAY | 6          | Yesterday (1 value every 5 minutes) |

## Time period

| Constant                  | Equivalent | Description                                        |
|---------------------------|------------|----------------------------------------------------|
| TIMEPERIOD_WEEK           | 1          | Last week                                          |
| TIMEPERIOD_MONTH          | 2          | Last month                                         |
| TIMEPERIOD_GIVEN_WEEKDAY  | 5          | Given day of the week (cannot be used as avgType)  |
| TIMEPERIOD_GIVEN_MONTHDAY | 6          | Given day of the month (cannot be used as avgType) |
| TIMEPERIOD_YESTERDAY      | 7          | Yesterday                                          |

## Alarm severities

To indicate the alarm states to be included, you can specify either one of the predefined constants or a combination of bit flags.

### Predefined constants

For the list of predefined constants, see the following table.

| Constant       | Equivalent | Description                        |
|----------------|------------|------------------------------------|
| STATE_CRITICAL | 1          | Include critical alarms/state only |
| STATE_MAJOR    | 2          | Include major alarms/state only    |
| STATE_MINOR    | 3          | Include minor alarms/state only    |
| STATE_WARNING  | 4          | Include warning alarms/state only  |
| STATE_TIMEOUT  | 6          | Include timeout alarms/state only  |
| STATE_ALL      | 7          | Include all alarm states           |

### Bit flags

For the list of alternative bit flags, see the following table. These bit flags can be used to create graphs that show multiple severities at once. They need to be combined using bitwise OR.

| Flag                | Equivalent | Description                                         |
|---------------------|------------|-----------------------------------------------------|
| STATE_FLAG_CRITICAL | 0x01000    | Include critical alarms/state                       |
| STATE_FLAG_MAJOR    | 0x02000    | Include major alarms/state                          |
| STATE_FLAG_MINOR    | 0x04000    | Include minor alarms/state                          |
| STATE_FLAG_WARNING  | 0x08000    | Include warning alarms/state                        |
| STATE_FLAG_TIMEOUT  | 0x20000    | Include timeout alarms/state                        |
| STATE_FLAG_ALL      | 0x2f000    | Include all alarm states (combination of all flags) |

---  
uid: Validator_2_31_9  
---

# CheckOptionsAttribute

## MissingSortingOnDateTimeColumn

### Description

Table not mainly sorted on one of its date(time) column(s). Table PID '{tablePid}'. Date(time) column PIDs '{columnPids}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.31.9      |
| Severity     | Minor       |
| Certainty    | Uncertain   |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

If a table has any column of type date or datetime, one of those columns should typically be used as sorted column with sort priority 0.

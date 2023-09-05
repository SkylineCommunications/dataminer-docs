---  
uid: Validator_2_17_7  
---

# CheckOptionsAttribute

## ViewTableInvalidReference

### Description

Table view option '{viewOption}' must refer to an existing table excluding the view table itself. View table PID '{viewTablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.17.7      |
| Severity     | Variable    |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Make sure the view table refers to an existing table, excluding view tables.

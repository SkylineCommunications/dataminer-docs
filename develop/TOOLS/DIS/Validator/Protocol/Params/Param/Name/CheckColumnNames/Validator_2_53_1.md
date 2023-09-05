---  
uid: Validator_2_53_1  
---

# CheckColumnNames

## MissingTableNameAsPrefixes

### Description

Missing table name '{tableName}' in front of column names. Table PID '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.53.1      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The name of column parameters should start with the name of the table they belong to.

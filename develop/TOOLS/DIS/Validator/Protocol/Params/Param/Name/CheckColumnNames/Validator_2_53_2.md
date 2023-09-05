---  
uid: Validator_2_53_2  
---

# CheckColumnNames

## MissingTableNameAsPrefix

### Description

Missing table name '{tableName}' in front of column name '{columnName}'. Column PID '{columnPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.53.2      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

The name of column parameters should start with the name of the table they belong to.

---  
uid: Validator_2_38_3  
---

# CheckOptionsAttribute

## ViewInvalidCombinationFilterChange

### Description

Invalid combination of view table filterChange option with column view option. View table PID '{viewTablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.38.3      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

When the filterChange option is used on a view table, its columns can't have the view option.

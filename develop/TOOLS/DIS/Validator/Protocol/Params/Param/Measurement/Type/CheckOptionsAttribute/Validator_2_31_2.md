---  
uid: Validator_2_31_2  
---

# CheckOptionsAttribute

## MissingPriorityForSortedColumns

### Description

Missing column sorting priorities on table '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.31.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

In case multiple columns are sorted, set a sorting priority for all these columns. In case at least one of the displayed columns is a datetime column, one of these columns should be set as the main column for sorting.

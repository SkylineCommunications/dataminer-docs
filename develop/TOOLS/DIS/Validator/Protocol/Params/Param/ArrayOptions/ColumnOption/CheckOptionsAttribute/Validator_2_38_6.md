---  
uid: Validator_2_38_6  
---

# CheckOptionsAttribute

## ForeignKeyTargetExpectingRTDisplayOnPK

### Description

RTDisplay(true) expected on PK column Param '{pkColumnPid}' due to '{foreignKeyOption}' in 'ColumnOption@options' attribute. Table PID '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.38.6      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

When a table contains a FK to another table. That other table requires its PK column to have its RTDisplay tag set to true.

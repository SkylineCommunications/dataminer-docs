---  
uid: Validator_2_38_5  
---

# CheckOptionsAttribute

## ColumnOptionExpectingRTDisplay

### Description

RTDisplay(true) expected on column Param '{columnPid}' due to '{option}' in 'ColumnOption@options' attribute. Table PID '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.38.5      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Many options from the 'ColumnOption@options' attribute only make sense if the related column is exported or has RTDisplay tag set to true.

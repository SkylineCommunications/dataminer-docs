---  
uid: Validator_2_38_4  
---

# CheckOptionsAttribute

## ForeignKeyMissingRelation

### Description

Missing Relation between table '{fkToTablePid}' and table '{fkFromTablePid}' due to foreignKey on column '{fkColumnPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.38.4      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Tables directly linked via a foreignKey should always be adjacent in, at least one relation path.

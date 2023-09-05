---  
uid: Validator_13_2_6  
---

# CheckPathAttribute

## MissingForeignKeyInTable\_Sub

### Description

Missing foreignKey between table '{table1Pid}' and table '{table2Pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Relation    |
| Full Id      | 13.2.6      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The Relation path should contain a semicolon list of Param IDs for tables that are linked to each other.  
Additionally, Every adjacent table in a relation path need at least one foreignKey from one another.

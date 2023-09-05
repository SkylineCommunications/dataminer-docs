---  
uid: Validator_13_2_9  
---

# CheckPathAttribute

## DuplicateValue

### Description

Duplicated Relation path '{duplicateValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Relation    |
| Full Id      | 13.2.9      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The Relation path should contain a semicolon list of Param IDs for tables that are linked to each other.  
Additionally, Every adjacent table in a relation path need at least one foreignKey from one another.

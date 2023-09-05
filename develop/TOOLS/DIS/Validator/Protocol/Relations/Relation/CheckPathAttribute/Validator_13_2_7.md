---  
uid: Validator_13_2_7  
---

# CheckPathAttribute

## ReferencedParamWrongType

### Description

Invalid Param Type '{paramType}' in relation. Expected Type 'array'. Param ID '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Relation    |
| Full Id      | 13.2.7      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The Relation path should contain a semicolon list of Param IDs for tables that are linked to each other.  
Additionally, Every adjacent table in a relation path need at least one foreignKey from one another.

---  
uid: Validator_13_2_8  
---

# CheckPathAttribute

## ReferencedParamExpectingRTDisplay

### Description

RTDisplay(true) expected on Param referenced in a relation path. Param ID '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Relation    |
| Full Id      | 13.2.8      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The Relation path should contain a semicolon list of Param IDs for tables that are linked to each other.  
Additionally, every table in a relation is expected to have its RTDisplay element set to true.

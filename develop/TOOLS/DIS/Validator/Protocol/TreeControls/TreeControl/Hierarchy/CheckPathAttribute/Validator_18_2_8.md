---  
uid: Validator_18_2_8  
---

# CheckPathAttribute

## InvalidValueInAttribute\_Sub

### Description

Invalid value '{invalidPart}' in attribute 'Hierarchy@path'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.2.8      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The Hierarchy@path attribute should contain a comma separated list of table PIDs.  
Those tables will define the different levels of the TreeControl.  
Note that this can also be achieved with more flexibility via the Hierarchy\/Table tags.

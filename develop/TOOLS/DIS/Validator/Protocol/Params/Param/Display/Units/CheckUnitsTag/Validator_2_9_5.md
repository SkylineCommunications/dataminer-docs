---  
uid: Validator_2_9_5  
---

# CheckUnitsTag

## UnsupportedTag

### Description

Unsupported 'Units' tag for '{paramDisplayType}' Param with ID '{paramPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.9.5       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Remove the Units tag.

### Details

Depending on the type of displayed Param, it does not always make sense to add a unit. Example: adding a unit to a table Param.

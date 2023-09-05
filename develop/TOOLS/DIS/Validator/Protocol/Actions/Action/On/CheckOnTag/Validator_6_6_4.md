---  
uid: Validator_6_6_4  
---

# CheckOnTag

## InvalidValue

### Description

Invalid value '{actionOn}' in tag 'On'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.6.4       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/On' tag is mandatory and should contain one of the following values:  
command, group, pair, parameter, protocol, response, timer.

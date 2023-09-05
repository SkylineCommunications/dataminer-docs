---  
uid: Validator_18_9_4  
---

# CheckTableIdAttribute

## InvalidValue

### Description

Invalid value '{attributeValue}' in attribute 'Tab@tableId'. TreeControl ID '{treeControlPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.9.4      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Tab@tableId attribute should contain a valid table PID.  
The referred table allows to define the Treecontrol level to which an extra tab should be added and is expected to have the RTDisplay tag set to true.

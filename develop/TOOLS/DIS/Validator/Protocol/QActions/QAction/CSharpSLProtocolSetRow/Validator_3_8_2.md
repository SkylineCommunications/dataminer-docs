---  
uid: Validator_3_8_2  
---

# CSharpSLProtocolSetRow

## HardCodedPid

### Description

Unrecommended use of magic number '{hardCodedTablePid}', use 'Parameter' class instead. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.8.2       |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.SetRow is used to update the values of a table row.  
Make sure to provide it with an ID of a table parameter that exists.  
Using Parameter class is recommended.

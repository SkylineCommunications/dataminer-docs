---  
uid: Validator_3_9_3  
---

# CSharpSLProtocolFillArray

## HardCodedPid

### Description

Unrecommended use of magic number '{hardCodedTablePid}', use 'Parameter' class instead. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.9.3       |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.FillArray is used to update a table with new values.  
Make sure to provide it with an ID of a table parameter that exists.  
Using Parameter class is recommended.

---  
uid: Validator_3_11_4  
---

# CSharpSLProtocolFillArrayWithColumn

## HardCodedTablePid

### Description

Unrecommended use of magic number '{hardCodedTablePid}', use 'Parameter' class instead. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.11.4      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.FillArrayWithColumn is used to update the values of a column.  
Make sure to provide it with an ID of a table parameter that exists.  
Using Parameter class is recommended.

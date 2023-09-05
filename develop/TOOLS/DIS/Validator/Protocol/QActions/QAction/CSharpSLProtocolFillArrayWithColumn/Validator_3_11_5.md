---  
uid: Validator_3_11_5  
---

# CSharpSLProtocolFillArrayWithColumn

## HardCodedColumnPid

### Description

Unrecommended use of magic number '{hardCodedColumnPid}', use 'Parameter' class instead. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.11.5      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.FillArrayWithColumn is used to update the values of a column.  
Make sure to provide it with an ID of a column parameter that exists.  
Using Parameter class is recommended.

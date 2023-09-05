---  
uid: Validator_3_6_2  
---

# CSharpSLProtocolGetParameter

## HardCodedPid

### Description

Unrecommended use of magic number '{hardCodedPid}', use 'Parameter' class instead. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.6.2       |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.GetParameter is used to get the current value of a standalone parameter.  
Make sure to provide it with an ID of a standalone parameter that exists.  
Using Parameter class is recommended.

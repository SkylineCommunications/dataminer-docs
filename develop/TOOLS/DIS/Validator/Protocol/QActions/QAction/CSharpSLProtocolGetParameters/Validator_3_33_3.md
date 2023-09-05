---  
uid: Validator_3_33_3  
---

# CSharpSLProtocolGetParameters

## HardCodedPid

### Description

Unrecommended use of magic number '{hardCodedPid}', use 'Parameter' class instead. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.33.3      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.GetParameters is used to get current values of standalone parameters.  
Make sure to provide it with a uint array of existing standalone parameter IDs.  
Using Parameter class is recommended.

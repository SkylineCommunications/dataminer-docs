---  
uid: Validator_3_6_1  
---

# CSharpSLProtocolGetParameter

## NonExistingParam

### Description

Method 'SLProtocol.GetParameter' references a non\-existing 'Param' with ID '{paramId}'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.6.1       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.GetParameter is used to get the current value of a standalone parameter.  
Make sure to provide it with an ID of a standalone parameter that exists.  
Using Parameter class is recommended.

---  
uid: Validator_3_7_1  
---

# CSharpSLProtocolSetParameter

## NonExistingParam

### Description

Method 'SLProtocol.SetParameter' references a non\-existing 'Param' with ID '{paramId}'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.7.1       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.SetParameter is used to update the value of a standalone parameter.  
Make sure to provide it with an ID of a standalone parameter that exists.  
Using Parameter class is recommended.

---  
uid: Validator_3_33_2  
---

# CSharpSLProtocolGetParameters

## NonExistingParam

### Description

Method 'SLProtocol.GetParameters' references a non\-existing 'Param' with ID '{paramId}'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.33.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.GetParameters is used to get current values of standalone parameters.  
Make sure to provide it with a uint array of existing standalone parameter IDs.  
Using Parameter class is recommended.

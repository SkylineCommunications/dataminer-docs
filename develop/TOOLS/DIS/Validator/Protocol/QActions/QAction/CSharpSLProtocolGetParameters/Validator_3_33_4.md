---  
uid: Validator_3_33_4  
---

# CSharpSLProtocolGetParameters

## UnsupportedArgumentTypeForIds

### Description

Invocation of method 'SLProtocol.GetParameters' has an invalid type '{argumentType}' for the argument 'ids'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.33.4      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.GetParameters is used to get current values of standalone parameters.  
Make sure to provide it with a uint array of existing standalone parameter IDs.  
Using Parameter class is recommended.

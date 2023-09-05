---  
uid: Validator_3_33_1  
---

# CSharpSLProtocolGetParameters

## UnexpectedImplementation

### Description

Method 'SLProtocol.GetParameters' with arguments '{arguments}' is not implemented as expected. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.33.1      |
| Severity     | BubbleUp    |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.GetParameters is used to get current values of standalone parameters.  
Make sure to provide it with a uint array of existing standalone parameter IDs.  
Using Parameter class is recommended.

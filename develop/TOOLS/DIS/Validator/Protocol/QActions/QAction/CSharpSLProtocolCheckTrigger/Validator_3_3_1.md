---  
uid: Validator_3_3_1  
---

# CSharpSLProtocolCheckTrigger

## NonExistingTrigger

### Description

Method 'SLProtocol.CheckTrigger' references a non\-existing 'Trigger' with ID '{triggerId}'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.3.1       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

SLProtocol.CheckTrigger is used to make a trigger go off.  
Make sure to provide it with an ID of a trigger that exists.

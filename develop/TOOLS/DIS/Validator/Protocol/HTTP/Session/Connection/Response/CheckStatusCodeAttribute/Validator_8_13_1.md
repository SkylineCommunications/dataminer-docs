---  
uid: Validator_8_13_1  
---

# CheckStatusCodeAttribute

## NonExistingId

### Description

Attribute 'Response@statusCode' references a non\-existing 'Param' with ID '{pid}'. HTTP Session ID '{sessionId}'. Connection ID '{connectionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | HTTP        |
| Full Id      | 8.13.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Use this attribute to specify the id of an existing parameter where the response status code will be set.

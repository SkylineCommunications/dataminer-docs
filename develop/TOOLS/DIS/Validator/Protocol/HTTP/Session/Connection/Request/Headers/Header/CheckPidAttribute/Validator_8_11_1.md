---  
uid: Validator_8_11_1  
---

# CheckPidAttribute

## NonExistingId

### Description

Attribute 'Request\/Headers\/Header@pid' references a non\-existing 'Param' with ID '{pid}'. HTTP Session ID '{sessionId}'. Connection ID '{connectionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | HTTP        |
| Full Id      | 8.11.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Use this attribute to specify the id of an existing parameter containing the value for this request header.

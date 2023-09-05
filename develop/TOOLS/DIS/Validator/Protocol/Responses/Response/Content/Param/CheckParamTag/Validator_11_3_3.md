---  
uid: Validator_11_3_3  
---

# CheckParamTag

## InvalidParamTag

### Description

Invalid value '{value}' in tag 'Content\/Param'. Response ID '{responseId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Response    |
| Full Id      | 11.3.3      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Response\/Content tag should contain a list of 'Param' tags. The 'Param' tags should refer to the id of an existing Param.

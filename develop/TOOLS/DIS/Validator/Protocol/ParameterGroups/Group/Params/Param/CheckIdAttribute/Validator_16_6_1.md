---  
uid: Validator_16_6_1  
---

# CheckIdAttribute

## NonExistingId

### Description

Attribute 'ParameterGroup\/Group\/Params\/Param@id' references a non\-existing 'Param' with PID '{pid}'. ParameterGroup ID '{parameterGroupId}'.

### Properties

| Name         | Value          |
| ------------ | -------------- |
| Category     | ParameterGroup |
| Full Id      | 16.6.1         |
| Severity     | Critical       |
| Certainty    | Certain        |
| Source       | Validator      |
| Fix Impact   | Breaking       |
| Has Code Fix | False          |

### Details

'ParameterGroups\/Group\/Params\/Param' elements are used to link the alarm status of a DCF interfaces to one of the following types of parameters  
 \- Standalone parameter: 'ParameterGroups\/Group\/Params\/Param' element should contain a standalong parameter pid.  
 \- Table cell: 'ParameterGroups\/Group\/Params\/Param' element should contain a column parameter pid and index attribute should be used to specify the row key.

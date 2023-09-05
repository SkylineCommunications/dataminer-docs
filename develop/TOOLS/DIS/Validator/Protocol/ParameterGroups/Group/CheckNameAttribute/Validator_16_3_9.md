---  
uid: Validator_16_3_9  
---

# CheckNameAttribute

## UntrimmedAttribute

### Description

Untrimmed attribute 'name' in ParameterGroup '{parameterGroupId}'. Current value '{untrimmedName}'.

### Properties

| Name         | Value          |
| ------------ | -------------- |
| Category     | ParameterGroup |
| Full Id      | 16.3.9         |
| Severity     | Critical       |
| Certainty    | Certain        |
| Source       | Validator      |
| Fix Impact   | Breaking       |
| Has Code Fix | True           |

### Details

All ParameterGroups should have an unique name.  
These names are used by DataMiner to build the DCF interfaces names. Therefore, we recommend to keep it rather small (max 25 chars) and avoid using special characters (see protocol guide for more info).

---  
uid: Validator_16_3_7  
---

# CheckNameAttribute

## InvalidChars

### Description

Invalid chars '{invalidCharacters}' in attribute 'name'. Current value '{attributeValue}'.

### Properties

| Name         | Value          |
| ------------ | -------------- |
| Category     | ParameterGroup |
| Full Id      | 16.3.7         |
| Severity     | Critical       |
| Certainty    | Certain        |
| Source       | Validator      |
| Fix Impact   | Breaking       |
| Has Code Fix | False          |

### Details

All ParameterGroups should have an unique name.  
These names are used by DataMiner to build the DCF interfaces names. Therefore, we recommend to keep it rather small (max 25 chars) and avoid using special characters (see protocol guide for more info).

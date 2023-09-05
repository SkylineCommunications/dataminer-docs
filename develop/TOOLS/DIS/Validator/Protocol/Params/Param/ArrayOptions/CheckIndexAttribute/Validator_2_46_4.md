---  
uid: Validator_2_46_4  
---

# CheckIndexAttribute

## NonExistingColumn

### Description

Reference to non\-existing column with IDX '{indexValue}' in attribute 'index'. Table ID '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.46.4      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The value should correspond to one of the column IDXs. '0' (corresponding to the first column) is the recommended value. The referred column should be of Interprete\/Type 'string'.

---  
uid: Validator_2_46_2  
---

# CheckIndexAttribute

## EmptyAttribute

### Description

Empty attribute 'index' in table '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.46.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### How to fix

 Add the attribute with value 0.

### Details

The value should correspond to one of the column IDXs. '0' (corresponding to the first column) is the recommended value. The referred column should be of Interprete\/Type 'string'.

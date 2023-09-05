---  
uid: Validator_2_31_10  
---

# CheckOptionsAttribute

## ReferencedParamRTDisplayExpected

### Description

RTDisplay(true) expected on Param '{columnPid}' displayed as table column. Table PID '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.31.10     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Columns referred by the 'Measurement\/Type@options' attribute of a displayed table should have its RTDisplay tag set to true.  
A table is considered 'displayed' if its RTDisplay tag and\/or its export attribute is set to true.

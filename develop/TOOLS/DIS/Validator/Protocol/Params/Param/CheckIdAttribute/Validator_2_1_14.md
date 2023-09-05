---  
uid: Validator_2_1_14  
---

# CheckIdAttribute

## RTDisplayExpectedOnSpectrumParam

### Description

RTDisplay(true) expected on Spectrum Params. Param ID '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.1.14      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Either the parameter should be removed, either its RTDisplay tag should be set to true.

### Details

Parameters with ID in the range \[64 000, 64 299\] are considered as spectrum parameters.  
Such spectrum Param should have its RTDisplay set to true.

---  
uid: Validator_2_7_4  
---

# CheckRTDisplayTag

## RTDisplayExpected

### Description

RTDisplay(true) expected on Param '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.7.4       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Double check the subresults to evaluate if the features requiring RTDisplay are to be removed or if RTDisplay actually has to be set to true.

### Details

This protocol contains some feature(s) requiring this Param to need the RTDisplay tag to be set true (see subresults).

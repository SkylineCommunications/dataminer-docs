---  
uid: Validator_2_57_2  
---

# CheckPositionsTag

## RTDisplayExpected

### Description

RTDisplay(true) expected on Param '{pid}' which is positioned.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.57.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

A positioned Param (with Display\/Positions tag) requires its RTDisplay to be set to true in order to be properly displayed.  
Note that an exception to this rule can be made when a Param is only meant to be displayed on a DVE protocol and not on the main one.

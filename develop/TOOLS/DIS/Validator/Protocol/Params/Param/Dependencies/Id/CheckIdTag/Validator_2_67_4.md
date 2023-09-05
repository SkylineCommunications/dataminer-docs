---  
uid: Validator_2_67_4  
---

# CheckIdTag

## RTDisplayExpected

### Description

RTDisplay(true) expected on Param '{pid}' containing 'Dependencies\/Id' tag(s).

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.67.4      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

A 'Dependencies\/Id' tag should contain the ID of an existing Param. Both the referencing and the referenced Param should have their RTDisplay tag set to 'true'.

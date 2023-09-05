---  
uid: Validator_2_67_5  
---

# CheckIdTag

## RTDisplayExpectedOnReferencedParam

### Description

RTDisplay(true) expected on Param '{referencedPid}' referenced by a 'Dependencies\/Id' tag. Param ID '{referencingPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.67.5      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

A 'Dependencies\/Id' tag should contain the ID of an existing Param. Both the referencing and the referenced Param should have their RTDisplay tag set to 'true'.

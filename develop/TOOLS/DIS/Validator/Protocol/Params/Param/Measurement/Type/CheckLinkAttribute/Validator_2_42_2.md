---  
uid: Validator_2_42_2  
---

# CheckLinkAttribute

## MissingAttribute

### Description

Missing attribute 'Measurement\/Type@link' in matrix '{matrixPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.42.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### How to fix

Add link\="XXXXXXXX.xml"

### Details

This attribute causes an XML file to be created on the system. Make sure the value contains a valid file name including the .xml extension.

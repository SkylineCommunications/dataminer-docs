---  
uid: Validator_2_22_5  
---

# CheckPageTag

## DuplicatedValue

### Description

Duplicated Param Position\/Page '{duplicateValue}'. Param IDs '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.22.5      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

A Position tag should always contain a Page tag.  
Note that, exept for title end parameters, the same parameter should not be displayed more than once on the same page.

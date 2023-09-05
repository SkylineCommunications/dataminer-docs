---  
uid: Validator_1_27_4  
---

# CheckOverridePidAttribute

## NonExistingParam

### Description

Attribute 'Page.Visibility@overridePID' references a non\-existing 'Param' with ID '{pid}'. Page Name '{pageName}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.27.4      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The attribute 'Visibility@overridePID' is mandatory within a Page\/Visibility tag. It should refer to the ID of an existing Param. The referenced Param should have its RTDisplay tag set to 'true'.

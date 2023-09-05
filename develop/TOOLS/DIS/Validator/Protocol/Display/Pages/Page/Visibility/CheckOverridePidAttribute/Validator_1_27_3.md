---  
uid: Validator_1_27_3  
---

# CheckOverridePidAttribute

## UntrimmedAttribute

### Description

Untrimmed attribute 'Page.Visibility@overridePID' in Page '{pageName}'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.27.3      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

The attribute 'Visibility@overridePID' is mandatory within a Page\/Visibility tag. It should refer to the ID of an existing Param. The referenced Param should have its RTDisplay tag set to 'true'.

---  
uid: Validator_1_27_2  
---

# CheckOverridePidAttribute

## EmptyAttribute

### Description

Empty attribute 'Page.Visibility@overridePID' in Page '{pageName}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.27.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The attribute 'Visibility@overridePID' is mandatory within a Page\/Visibility tag. It should refer to the ID of an existing Param. The referenced Param should have its RTDisplay tag set to 'true'.

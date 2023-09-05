---  
uid: Validator_1_27_5  
---

# CheckOverridePidAttribute

## ReferencedParamExpectingRTDisplay

### Description

RTDisplay(true) expected on Param '{pid}' used as page visibility condition. Page name '{pageName}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.27.5      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The attribute 'Visibility@overridePID' is mandatory within a Page\/Visibility tag. It should refer to the ID of an existing Param. The referenced Param should have its RTDisplay tag set to 'true'.

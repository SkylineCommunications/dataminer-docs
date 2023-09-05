---  
uid: Validator_18_3_6  
---

# CheckIdAttribute

## ReferencedParamExpectingRTDisplay

### Description

RTDisplay(true) expected on table displayed in TreeControl Hierarchy. Table PID '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.3.6      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The Hierarchy\/Table@id attribute should contain a table PID allowing to define which table contains entries for a specific level of the TreeControl.  
Such table is expected to have RTDisplay tag set to 'true'.

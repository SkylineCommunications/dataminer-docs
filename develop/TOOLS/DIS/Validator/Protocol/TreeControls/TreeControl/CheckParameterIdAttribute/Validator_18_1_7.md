---  
uid: Validator_18_1_7  
---

# CheckParameterIdAttribute

## ReferencedParamExpectingRTDisplay

### Description

RTDisplay(true) expected on TreeControl Param. Param ID '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.1.7      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

TreeControl@parameterId attribute should contain the PID of a parameter which will be used to define where to display the TreeControl.  
Such TreeControl parameter is expected to have:  
\- 'Param\\Type' tag set to 'dummy' (or alternatively 'read' but 'dummy' is preferred).  
\- 'Param\\Display\\RTDisplay' tag set to 'true'.

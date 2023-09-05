---  
uid: Validator_2_72_6  
---

# CheckDisabledIfAttribute

## ReferencedParamRTDisplayExpected

### Description

RTDisplay(true) expected on Param '{referencedPid}' referenced by a 'Monitored@disabledIf' attribute. Param ID '{referencingPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.72.6      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Monitored@disabledIf attribute should follow the following format 'pid,value' where:  
\- pid: refers to the ID of an existing parameter.  
  The referenced Param is expected to:  
    \- Have RTDisplay tag set to 'true'.  
\- value: correspond to the value of the referenced parameter which will cause the monitoring to be disabled.  
  When using discreet values, it is only possible to set a condition on the discreet value, not on the display value.

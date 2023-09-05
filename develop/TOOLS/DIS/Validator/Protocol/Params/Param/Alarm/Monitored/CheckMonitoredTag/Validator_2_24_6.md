---  
uid: Validator_2_24_6  
---

# CheckMonitoredTag

## RTDisplayExpected

### Description

RTDisplay(true) expected on alarmed (monitored) parameters. Param ID '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.24.6      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Double check if alarming is really needed:  
\- if not, remove the full Alarm tag.  
\- If so, set RTDisplay tag to true.

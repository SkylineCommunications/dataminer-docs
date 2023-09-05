---  
uid: Validator_2_8_4  
---

# CheckTrendingAttribute

## RTDisplayExpected

### Description

RTDisplay(true) expected on trended parameters. Param ID '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.8.4       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Double check if trending is really needed:  
\- if not, remove trending.  
\- If so, set RTDisplay tag to true.

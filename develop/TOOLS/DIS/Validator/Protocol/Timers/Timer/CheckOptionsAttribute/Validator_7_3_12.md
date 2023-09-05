---  
uid: Validator_7_3_12  
---

# CheckOptionsAttribute

## InvalidPollingRateOption

### Description

Invalid value for 'pollingRate' option. Expected format: 'pollingRate:\<interval\>,\<maxCount\>,\<releaseCount\>'. Current value '{optionValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.3.12      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Expected format: 'pollingRate:\<interval\>,\<maxCount\>,\<releaseCount\>', where  \<interval\> specifies the interval (in ms).

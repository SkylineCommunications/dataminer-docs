---  
uid: Validator_7_3_26  
---

# CheckOptionsAttribute

## ThreadPoolCalculationIntervalDefined

### Description

Thread pool statistics can have a big impact on performance. Timer ID '{timerId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.3.26      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

In case the thread pool statistics are of no interest, disable the calculation of these by setting the \<calculationInterval\> to \-1.  
Also, set the value of the options that specify the ID of the parameter that will show the statistic to \-1.  
For example: threadPool:10,\-1,\-1,\-1,\-1,\-1,\-1,500.

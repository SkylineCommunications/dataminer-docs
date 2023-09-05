---  
uid: Validator_7_1_1  
---

# CheckTimeTag

## MissingTag

### Description

Missing tag 'Time' in Timer '{timerId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.1.1       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Choose a value between '1' and '2.073.600.000' (included). The max value corresponds to 24 days.

### Details

The minimum allowed value for a Timer Time is '1'.  
The maximum allowed value for a Timer Time tag is '2.073.600.000' which corresponds to 24 days.  
An altenative possible value is 'loop' which will cause the timer to continuously go off.  
Also note that, due to a software issue, a value higher than '86.400.000' which corresponds to 24 hours will cause issues on DMA version between 8.5.9.1 and 9.0 CU5.

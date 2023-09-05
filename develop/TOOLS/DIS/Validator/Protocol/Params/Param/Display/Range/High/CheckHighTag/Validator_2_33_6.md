---  
uid: Validator_2_33_6  
---

# CheckHighTag

## LogarithmicLowerOrEqualToZero

### Description

Range\/High '{rangeHigh}' should be bigger than zero due to Trending@logarithmic 'true'. Param ID '{paramId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.33.6      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

When Trending@logarithmic is set to 'true', both 'Range\/Low' and 'Range\/High' should be bigger than 0.

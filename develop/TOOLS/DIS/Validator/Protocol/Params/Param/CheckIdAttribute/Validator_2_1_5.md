---  
uid: Validator_2_1_5  
---

# CheckIdAttribute

## OutOfRangeId

### Description

Out of range Param ID '{id}'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | Param     |
| Full Id      | 2.1.5     |
| Severity     | Critical  |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### Details

Default allowed ranges are:  
\- 1 \-\> 64.299  
\- 70.000 \-\> 99.999  
\- 1.000.000 \-\> 9.999.999  
There are exception for spectrum, base, Enhanced Service, SLA and Aggregation drivers. For more information about those exceptions, please check the protocol reference guide.

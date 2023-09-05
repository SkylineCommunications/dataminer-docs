---  
uid: Validator_1_25_1  
---

# CheckMinimumRequiredVersionTag

## MinVersionTooLow

### Description

Minimum required version '{currentMinDmVersion}' too low. Expected value '{expectedMinDmVersion}'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | Protocol  |
| Full Id      | 1.25.1    |
| Severity     | Critical  |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | True      |

### Details

Indicates the minimum DataMiner ver­sion that the driver is compatible with.   
If the DMS software version is less recent than the indicated version, the protocol will not be useable.

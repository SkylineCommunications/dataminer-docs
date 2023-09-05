---  
uid: Validator_2_41_1  
---

# CheckMatrixDiscreets

## InvalidDiscreetCount

### Description

Invalid number of Discreets '{discreetCount}' for matrix Param. Expected count '{expectedDiscreetCount}'. Param ID '{matrixPid}'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | Param     |
| Full Id      | 2.41.1    |
| Severity     | Major     |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### How to fix

Make sure the number of discreets is equal to the number of inputs + outputs as defined in the Param\/Type@options dimension.

### Details

For matrix read parameters, the number of discreets should correspond to sum of the number of inputs and the number of outputs.  
Their values should be one\-based and sequentially increasing by 1.

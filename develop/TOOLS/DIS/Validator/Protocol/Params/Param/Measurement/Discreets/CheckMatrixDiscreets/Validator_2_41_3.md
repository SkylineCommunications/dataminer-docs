---  
uid: Validator_2_41_3  
---

# CheckMatrixDiscreets

## DiscreetsNotOneBased

### Description

Matrix Discreet values should be one\-based. Param ID '{matrixPid}'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | Param     |
| Full Id      | 2.41.3    |
| Severity     | Major     |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### How to fix

Make sure the first discreet value is 1.

### Details

For matrix read parameters, the number of discreets should correspond to sum of the number of inputs and the number of outputs.  
Their values should be one\-based and sequentially increasing by 1.

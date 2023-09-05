---  
uid: Validator_2_41_2  
---

# CheckMatrixDiscreets

## MissingDiscreetValue

### Description

Missing matrix Discreet values '{missingValues}'. Param ID '{matrixPid}'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | Param     |
| Full Id      | 2.41.2    |
| Severity     | Major     |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### How to fix

Make sure Discreet values are sequentially incremented by 1.

### Details

For matrix read parameters, the number of discreets should correspond to sum of the number of inputs and the number of outputs.  
Their values should be one\-based and sequentially increasing by 1.

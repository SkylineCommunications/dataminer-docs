---  
uid: Validator_2_39_2  
---

# CheckDisplayKey

## DisplayColumnSameAsPK

### Description

DisplayColumn is the same as the primary key. Table PID '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.39.2      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### How to fix

Remove the displayColumn\='' attribute.

### Details

The excessive displayColumn\='' definition has no added value and bad impact on the performance.

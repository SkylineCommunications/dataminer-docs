---  
uid: Validator_2_39_3  
---

# CheckDisplayKey

## DisplayColumnUnrecommended

### Description

Unrecommended use of displayColumn. Table PID '{tablePid}'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | Param     |
| Full Id      | 2.39.3    |
| Severity     | Minor     |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### How to fix

Replace the displayColumn attribute by the NamingFormat tag.

### Details

It is preferred to define the display key via the NamingFormat tag.

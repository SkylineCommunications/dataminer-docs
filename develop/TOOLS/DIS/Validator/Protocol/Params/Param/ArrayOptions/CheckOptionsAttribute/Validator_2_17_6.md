---  
uid: Validator_2_17_6  
---

# CheckOptionsAttribute

## PreserveStateShouldBeAvoided

### Description

Unrecommended use of the "preserve state" option on table '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.17.6      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Use a QAction to compare the previous and new values of the cells, and calculate the state of each row.

### Details

The use of the "preserve state" option on tables should be avoided as it requires sig­nificantly more processing.

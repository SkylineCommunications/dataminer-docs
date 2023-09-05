---  
uid: MajorChangeChecker_2_39_5  
---

# CheckDisplayKey

## FormatRemoved

### Description

Table display key previously defined via '{oldSyntax}' was removed. Table PID '{tablePid}'.

### Properties

| Name         | Value              |
| ------------ | ------------------ |
| Category     | Param              |
| Full Id      | 2.39.5             |
| Severity     | Major              |
| Certainty    | Certain            |
| Source       | MajorChangeChecker |
| Fix Impact   | Breaking           |
| Has Code Fix | False              |

### Details

The display key of tables can be defined via 'ArrayOptions@option:naming' or via 'ArrayOptions\/NamingFormat'.  
'ArrayOptions\/NamingFormat' is the prefered way and going from one syntax to another has no breaking impact as long as the defined format is equivalent.

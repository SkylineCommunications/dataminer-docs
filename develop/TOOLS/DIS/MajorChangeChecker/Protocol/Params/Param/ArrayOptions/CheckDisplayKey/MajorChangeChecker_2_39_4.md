---  
uid: MajorChangeChecker_2_39_4  
---

# CheckDisplayKey

## FormatChanged

### Description

Table display key was changed from {oldSyntax} '{oldFormat}' to {newSyntax} '{newFormat}'. Table PID '{tablePid}'.

### Properties

| Name         | Value              |
| ------------ | ------------------ |
| Category     | Param              |
| Full Id      | 2.39.4             |
| Severity     | Major              |
| Certainty    | Certain            |
| Source       | MajorChangeChecker |
| Fix Impact   | Breaking           |
| Has Code Fix | False              |

### Details

The display key of tables can be defined via 'ArrayOptions@option:naming' or via 'ArrayOptions\/NamingFormat'.  
'ArrayOptions\/NamingFormat' is the prefered way and going from one syntax to another has no breaking impact as long as the defined format is equivalent.

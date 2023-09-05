---  
uid: MajorChangeChecker_2_36_2  
---

# CheckExceptionsTag

## RemovedException

### Description

Exception with id '{exceptionId}' was removed from Param '{paramPid}'.

### Properties

| Name         | Value              |
| ------------ | ------------------ |
| Category     | Param              |
| Full Id      | 2.36.2             |
| Severity     | Major              |
| Certainty    | Certain            |
| Source       | MajorChangeChecker |
| Fix Impact   | Breaking           |
| Has Code Fix | False              |

### Details

Removing an exception value will have impact on existing alarm templates as an exception value is preceded by a '$' sign in the alarm template.

---  
uid: MajorChangeChecker_2_36_3  
---

# CheckExceptionsTag

## AddedException

### Description

Exception with id '{exceptionId}' was added to Param '{paramPid}'.

### Properties

| Name         | Value              |
| ------------ | ------------------ |
| Category     | Param              |
| Full Id      | 2.36.3             |
| Severity     | Major              |
| Certainty    | Certain            |
| Source       | MajorChangeChecker |
| Fix Impact   | Breaking           |
| Has Code Fix | False              |

### Details

Adding an exception will have impact on existing alarm templates as an exception value is preceded by a '$' sign in the alarm template.

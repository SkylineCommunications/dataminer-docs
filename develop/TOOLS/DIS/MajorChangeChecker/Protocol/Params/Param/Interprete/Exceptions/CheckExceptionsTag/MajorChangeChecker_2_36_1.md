---  
uid: MajorChangeChecker_2_36_1  
---

# CheckExceptionsTag

## UpdatedExceptionValueTag

### Description

Exception value tag for exception with id '{exceptionId}' on Param '{paramPid}' was changed from '{previousExceptionValue}' to '{newExceptionValue}'.

### Properties

| Name         | Value              |
| ------------ | ------------------ |
| Category     | Param              |
| Full Id      | 2.36.1             |
| Severity     | Major              |
| Certainty    | Certain            |
| Source       | MajorChangeChecker |
| Fix Impact   | Breaking           |
| Has Code Fix | False              |

### Details

Updating the exceptions value tag will have impact on existing alarm templates as an exception value is preceded by a '$' sign in the alarm template.

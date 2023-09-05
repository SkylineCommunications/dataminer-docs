---  
uid: MajorChangeChecker_2_45_4  
---

# CheckOthersTag

## AddedOthers

### Description

Other with Value tag '{newValue}' has been added. Param '{paramPid}'.

### Properties

| Name         | Value              |
| ------------ | ------------------ |
| Category     | Param              |
| Full Id      | 2.45.4             |
| Severity     | Major              |
| Certainty    | Certain            |
| Source       | MajorChangeChecker |
| Fix Impact   | Breaking           |
| Has Code Fix | False              |

### Details

If a new value is added to the Other tags and that value is withing the previously allowed range of values for that parameter, it might have an impact on configured alarm templates.

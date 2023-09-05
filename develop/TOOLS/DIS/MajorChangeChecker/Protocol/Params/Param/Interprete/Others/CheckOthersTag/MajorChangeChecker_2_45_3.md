---  
uid: MajorChangeChecker_2_45_3  
---

# CheckOthersTag

## DeletedValue

### Description

Other with Value tag '{oldValue}' has been deleted. Param '{paramPid}'.

### Properties

| Name         | Value              |
| ------------ | ------------------ |
| Category     | Param              |
| Full Id      | 2.45.3             |
| Severity     | Major              |
| Certainty    | Certain            |
| Source       | MajorChangeChecker |
| Fix Impact   | Breaking           |
| Has Code Fix | False              |

### Details

If a value is removed from the Other tags, it will have impact on an alarm template for which that value was configured as a threshold value.

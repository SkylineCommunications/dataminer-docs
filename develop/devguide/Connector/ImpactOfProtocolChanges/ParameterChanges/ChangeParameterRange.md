---
uid: ChangeParameterRange
---

# Change parameter range

Changing the range of a parameter is considered a major change.

However, this is only the case if the previous range defined on the parameter is not included in the updated range.

## Impact

Alarm templates need to be reconfigured because they will throw errors and fail to be applied if they have an alarm value configured outside the range.

*DIS MCC*

| Full ID | Error Message    | Description                                                                   |
|---------|------------------|-------------------------------------------------------------------------------|
| 2.32.1  | UpdatedLowRange  | Low range '{previousValue}' in Param '{paramPid}' increased to '{newValue}'.  |
| 2.32.2  | AddedLowRange    | Low range '{newValue}' in Param '{paramPid}' was added.                       |
| 2.33.1  | UpdatedHighRange | High range '{previousValue}' in Param '{paramPid}' decreased to '{newValue}'. |
| 2.33.2  | AddedHighRange   | High range '{newValue}' in Param '{paramPid}' was added.                      |

## Workarounds

There is no workaround.

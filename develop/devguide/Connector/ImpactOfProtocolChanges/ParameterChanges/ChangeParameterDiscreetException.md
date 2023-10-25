---
uid: ChangeParameterDiscreetException
---

# Change parameter discreet and/or exception

Changing the discreet(s) or changing exception(s) is considered a major change.

Note, a change in *dependancyValue* will not cause any impact.

## Impact

- Adapt Automation scripts, because the displayed value can be used in Automation scripts to perform sets.
- DMS Filters can be used with wildcards on the display value.

*DIS MCC*

| Full ID | Error Message | Description |
|---------|---------------|-------------|
| 2.12.1  | UpdatedValue | Discreet value tag with display '{displayValue}' on Param '{paramId}' was changed from '{previousValue}' into '{newValue}'. |
| 2.12.2  | RemovedItem | Discreet tag with value '{discreetValue}' on Param '{paramId}' was removed. |
| 2.13.1  | UpdatedValue | Discreet display tag with value '{oldValue}' on Param '{paramId}' was changed from '{previousDispay}' into '{newDisplay}'. |

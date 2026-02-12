---
uid: ChangeParameterDiscreetException
---

# Change parameter discreet and/or exception

Changing discreets or changing exceptions is considered a major change.

> [!NOTE]
> A change in *dependancyValue* will not cause any impact.

## Impact

- Adapt automation scripts, because the displayed value can be used in automation scripts to perform sets.
- Filters can be used with wildcards on the display value.

*DIS MCC*

| Full ID | Error Message | Description                                                                                                                 |
|---------|---------------|-----------------------------------------------------------------------------------------------------------------------------|
| 2.12.1  | UpdatedValue  | Discreet value tag with display '{displayValue}' on Param '{paramId}' was changed from '{previousValue}' into '{newValue}'. |
| 2.12.2  | RemovedItem   | Discreet tag with value '{discreetValue}' on Param '{paramId}' was removed.                                                 |
| 2.13.1  | UpdatedValue  | Discreet display tag with value '{oldValue}' on Param '{paramId}' was changed from '{previousDispay}' into '{newDisplay}'.  |

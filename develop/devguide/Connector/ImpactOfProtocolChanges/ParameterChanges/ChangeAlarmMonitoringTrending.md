---
uid: ChangeAlarmMonitoringTrending
---

# Change alarm monitoring and/or trending

Changing alarming and trending is considered a major change, but only in specific cases.

When alarming/trending is removed or the trend type is changed, for example, this can have an impact on the system.

Changes to normalization are also considered a major change, although a workaround is available to avoid impact.

## Impact

Changing the trend type will cause graph content to change.

Removing the normalization in a protocol will cause loss of configuration data.

## Alarm monitoring

*DIS MCC*

| Full ID | Error Message                 | Description                                                                                         |
|---------|-------------------------------|-----------------------------------------------------------------------------------------------------|
| 2.23.1  | RemovedNormalizationAlarmType | Normalization with Alarm type '{alarmType}' on Param '{paramId}' was removed.                       |
| 2.23.2  | UpdatedNormalizationAlarmType | Normalization with Alarm type '{alarmType}' on Param '{paramId}' was changed into '{newAlarmType}'. |
| 2.23.3  | AddedNormalizationAlarmType   | Normalization with Alarm type '{normalizationType}' on Param '{pid}' was added.                     |
| 2.24.1  | RemovedAlarming               | Alarming for Param '{paramId}' was removed.                                                         |
| 2.34.1  | UpdatedThresholdAlarmType     | Threshold with value '{oldValue}' on Param '{paramPid}' was changed into '{newValue}'.              |
| 2.34.2  | AddedThresholdAlarmType       | Threshold with value '{newValue}' was added to Param '{paramPid}'.                                  |
| 2.34.3  | RemovedThresholdAlarmType     | Threshold with value '{oldValue}' was removed from Param '{paramPid}'.                              |

## Trending

*DIS MCC*

| Full ID | Error Message    | Description                                 |
|---------|------------------|---------------------------------------------|
| 2.8.1   | DisabledTrending | Trending on Param '{paramId}' was disabled. |

## Workarounds

### Changing normalization

- Normalization should change from `absolute:<pid>` to `absolute`

- Add a button that will trigger two actions:

  - First, to copy the current values to the parameter holding the base values.

  - Second, to perform the normalization (action type [normalize](xref:LogicActionNormalize)).

To prevent the loss of the old base values stored using `absolute:<pid>`, use a trigger after startup and run every *normalize* action if there is a value filled in in the parameter holding the base value.

> [!IMPORTANT]
> Only the *normalize* action should be run after startup and not the copy action (so do not just trigger the button normalize). This should only run the very first time the element is restarted after a version change. So you might also want to include a save parameter holding a flag that indicates that this has already been performed.

> [!NOTE]
> In case of a (DVE) table, the values need to be copied using a QAction.

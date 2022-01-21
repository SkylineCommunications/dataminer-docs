---
uid: Guidelines_for_assigning_alarm_severity_levels
---

## Guidelines for assigning alarm severity levels

When assigning alarm severity levels in an alarm template, you should keep these guidelines in mind.

### General guidelines

- You do not always have to use every possible severity level.

- If you do not use dynamic alarm thresholds, in some cases it can be useful to specify a "Normal" alarm threshold, though this is not mandatory. You can for instance specify a "Normal" threshold for an analog parameter to indicate the base expectations for normal values in the oscilloscope or LED bar representing this parameter.

- You can assign the same severity level to multiple possible values of the same parameter.

    Example: If you have a parameter of which the value can range from 0 to 10, then you could assign the level “Minor” to all values from 0 to 4.

- If a parameter has an exception value, and you do not specify the exception value in the alarm template, it will be considered a normal value.

- Carefully select your alarm severity levels and always make sure they make sense. After all, alarm messages should be meaningful.

    - You should not monitor parameters just because you can.

    - Do not set your severity levels too tight. If you do, this could lead to alarm floods in which critical alarms might get overlooked.

    - Do not set your severity levels too wide. If you do, some alarms might never get raised.

- Constantly evaluate and question the alarm severity levels you have set and, if necessary, adjust them.

> [!TIP]
> See also:
> [Alarm severity levels](../alarms/Alarm_types.md#alarm-severity-levels)

### Assigning alarm severity levels to values of analog parameters

In case of analog parameters, different values can be assigned so-called high and low levels.

A parameter like “audio output level” could be assigned the following alarm severity levels.

| Parameter value   | Alarm severity level |
|-------------------|----------------------|
| Lower than -2     | Critical low         |
| Between -2 and 0  | Major low            |
| Between 0 and 3   | Warning low          |
| Equal to 7        | Normal               |
| Between 12 and 15 | Minor high           |
| Higher than 15    | Critical high        |

> [!NOTE]
> In the example above, some levels have been left out.

### Assigning alarm severity levels to values of discrete parameters

In case of discrete parameters, each value can be assigned a severity level.

A parameter like “fan status” could be assigned the following alarm severity levels.

| Parameter value | Alarm severity level |
|-----------------|----------------------|
| On              | Minor                |
| Off             | Normal               |

A parameter like “input level” could be assigned the following alarm severity levels.

| Parameter value | Alarm severity level |
|-----------------|----------------------|
| Extreme         | Critical             |
| High            | Major                |
| Medium          | Minor                |
| OK              | Normal               |
| Low             | Warning              |
| Very Low        | Critical             |

---
uid: Alarm_types
---

# Alarm types

Several types of alarms exist in DataMiner. In addition to five alarm severity levels, there are also a number of special alarm types.

- [Alarm severity levels](#alarm-severity-levels)

- [Special alarm types](#special-alarm-types)

- [Alarm type priority](#alarm-type-priority)

## Alarm severity levels

There are four alarm levels, each indicated by a color, as well as one additional “Normal” level, which represents the expected value of a parameter during normal operations.

| Severity level | Default alarm color |
|----------------|---------------------|
| Normal         | Green               |
| Warning        | Blue                |
| Minor          | Cyan                |
| Major          | Yellow              |
| Critical       | Red                 |

For the different alarm levels, it is also possible to assign high and low levels. For analog parameters, a high level alarm is triggered when the parameter value exceeds the set alarm threshold, and a low level alarm is triggered when the parameter falls below the set alarm threshold.

> [!TIP]
> See also:
> - [Changing the default alarm colors](xref:Changing_the_default_alarm_colors)
> - [Guidelines for assigning alarm severity levels](xref:Guidelines_for_assigning_alarm_severity_levels)

## Special alarm types

Several special alarm types exist in DataMiner:

- Alarms of the type Error and Notice refer to the functionality of the DataMiner System itself.

- Information events are messages intended to inform users without raising an alarm. See [Information event](#information-event).

- Timeout alarms indicate non-responding devices. See [Timeout](#timeout).

- Suggestion events are messages intended to give users insights into the data behavior of their metrics (Available from DataMiner 10.0.0/10.0.2 onwards). See [Advanced analytics features in the Alarm Console](xref:Advanced_analytics_features_in_the_Alarm_Console).

- Masked alarms, indicated in purple, are “hidden” to prevent unnecessary follow-up. See [Masking and unmasking alarms](xref:Masking_and_unmasking_alarms).

### Information event

An information event is a message distributed throughout the DataMiner System to draw attention to something. In the Alarm Console, these messages are shown in the default tab *Information events*.

Information events will normally be broadcast to inform users:

- that a DMA has been started or stopped,

- that an alarm template has been changed,

- that a protocol has been added or deleted,

- that an Automation script has failed or finished successfully,

- etc.

Default alarm color: Gray

> [!NOTE]
> You can also make DataMiner generate information events when a discrete parameter reaches a user-defined value or when an analog parameter crosses a user-defined threshold.

### Timeout

A timeout is an alarm that indicates that DataMiner has been unable to communicate with a particular element for some time. The time it takes before a timeout is triggered depends on the element configuration.

Default alarm color: Orange

If an element is in timeout, its parameters will be disabled, as no changes can be implemented until communication with the device has been re-established.

> [!NOTE]
> - From DataMiner 9.5.4 onwards, timeout alarms have a comment containing the IP address(es) of the connection(s) that caused the timeout.
> - From DataMiner 9.6.4 onwards, if a timeout occurs while there was already an alarm on an element, there will be a small red x icon next to the bar indicating the severity of that alarm, to make it clear that the status of the alarm is uncertain because of the timeout.

#### Timeout alarms on replicated elements or services

If a replicated element or service is in timeout state, this can have two different reasons:

- The element or service that is being replicated is in timeout state.

- The DMA is not able to communicate with the DMA where the element or service that is being replicated is located.

From DataMiner 9.5.5 onwards, the tooltip of the timeout icon in Cube will indicate if the DMA communication is the reason for the timeout.

## Alarm type priority

The different alarm types all have their own priority in DataMiner. From highest to lowest priority, the following order is applied:

```txt
Error, Timeout, Critical, Major, Minor, Warning, Masked, Normal, Notice, Information, Initial
```

This priority is applied in many different DataMiner applications:

- In the Surveyor, the icons get the alarm color with the highest priority.

- In Alerter, the alarm with the highest priority is shown in a balloon first.

- In the Alarm Console, if you sort alarms on severity, this order is used.

- On the data display pages of a view card, if you sort items in a view on severity, this order is used.

- In the footer of a view card, the items in the view are shown in this order.

    > [!NOTE]
    > Depending on your user settings, the footer may not be displayed. See [Card settings](xref:User_settings#card-settings).

- In Visual pages, this priority determines the displayed alarm color.

- Etc.

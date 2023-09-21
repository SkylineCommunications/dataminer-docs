---
uid: Alarm_types
---

# Alarm types

Several types of alarms exist in DataMiner. In addition to five [alarm severity levels](#alarm-severity-levels), there are also a number of [special alarm types](#special-alarm-types). Alarms also have a different [priority depending on their alarm type](#alarm-type-priority).

## Alarm severity levels

There are four alarm levels, each indicated by a color, as well as one additional "Normal" level, which represents the expected value of a parameter during normal operations.

| Severity level | Default alarm color |
|----------------|---------------------|
| Normal         | Green               |
| Warning        | Blue                |
| Minor          | Cyan                |
| Major          | Yellow              |
| Critical       | Red                 |

For the different alarm levels, it is also possible to assign high and low levels. For analog parameters, a high level alarm is triggered when the parameter value exceeds the set alarm threshold, and a low level alarm is triggered when the parameter falls below the set alarm threshold.

> [!NOTE]
> If you have trouble seeing certain colors, you can configure a color filter in Windows to make it easier for you to differentiate between specific colors. To do so, in your Windows settings, go to *Accessibility* > *Color filters*.

> [!TIP]
> See also:
>
> - [Changing the default alarm colors](xref:Changing_the_default_alarm_colors)
> - [Guidelines for assigning alarm severity levels](xref:Guidelines_for_assigning_alarm_severity_levels)

## Special alarm types

Several special alarm types exist in DataMiner:

- Alarms of the type Error and Notice refer to the functionality of the DataMiner System itself.

- [Information events](#information-events) are messages intended to inform users without raising an alarm.

- [Timeout alarms](#timeout-alarms) indicate non-responding devices.

- [Suggestion events](xref:Advanced_analytics_features_in_the_Alarm_Console) are messages intended to give users insights into the data behavior of their metrics (available from DataMiner 10.0.0/10.0.2 onwards).

- [Masked alarms](xref:Masking_and_unmasking_alarms), indicated in purple, are "hidden" to prevent unnecessary follow-up.

- [Correlated alarms](#correlated-alarms) group other alarms based on a Correlation rule.

### Information events

An information event is a message distributed throughout the DataMiner System to draw attention to something. In the Alarm Console, these messages are shown in the default tab *Information events*.

Information events will normally be broadcast to inform users:

- that a DMA has been started or stopped,

- that an alarm template has been changed,

- that a protocol has been added or deleted,

- that an Automation script has failed or finished successfully,

- etc.

The default alarm color of information events is gray.

> [!NOTE]
> You can also make DataMiner generate information events when a discrete parameter reaches a user-defined value or when an analog parameter crosses a user-defined threshold. See [Configuring an alarm template to generate information messages](xref:Configuring_alarm_template_information_message).

### Timeout alarms

A timeout is an alarm that indicates that DataMiner has been unable to communicate with a particular element for some time. The time it takes before a timeout is triggered depends on the element configuration.

Default alarm color: Orange

If an element is in timeout, its parameters will be disabled, as no changes can be implemented until communication with the device has been re-established.

> [!NOTE]
>
> - Timeout alarms have a comment containing the IP address(es) of the connection(s) that caused the timeout.
> - If a timeout occurs while there was already an alarm on an element, there will be a small red x icon next to the bar indicating the severity of that alarm, to make it clear that the status of the alarm is uncertain because of the timeout.

#### Timeout alarms on replicated elements or services

If a replicated element or service is in timeout state, this can have two different reasons:

- The element or service that is being replicated is in timeout state.

- The DMA is not able to communicate with the DMA where the element or service that is being replicated is located.

The tooltip of the timeout icon in Cube will indicate if the DMA communication is the reason for the timeout.

### Correlated alarms

Correlated alarms are alarms triggered by the [DataMiner Correlation](xref:About_DMS_Correlation) module. They group other alarms based on a Correlation rule.

You can expand a correlated alarm in order to see the base alarms that triggered the correlated alarm. By default, alarms are no longer shown in the *Active Alarms* tab when they are included in a correlated alarm.

The severity of a correlated alarm depends on the Correlation rule configuration. It can be the highest severity of its base alarms or a custom severity.

Correlated alarms are represented in the Alarm Console with a special icon. This is also the icon used for [alarm groups](xref:Automatic_incident_tracking).

![Correlated alarm](~/user-guide/images/correlated_alarm.png)<br>
*Correlated alarm in the Alarm Console in DataMiner 10.3.6*

## Alarm type priority

The different alarm types all have their own priority in DataMiner. From highest to lowest priority, the following order is applied:

- Error, Timeout, Critical, Major, Minor, Warning, Masked, Normal, Notice, Information, Initial

> [!NOTE]
>
> - Suggestion events have the same priority as information events.
> - The priority of a correlated alarm depends on the severity of the alarm.

This priority is applied in many different DataMiner applications:

- In the Surveyor, the icons get the alarm color with the highest priority.

- In Alerter, the alarm with the highest priority is shown in a balloon first.

- In the Alarm Console, if you sort alarms on severity, this order is used.

- On the data display pages of a view card, if you sort items in a view on severity, this order is used.

- In the footer of a view card, the items in the view are shown in this order. Note that depending on your [user settings](xref:User_settings#card-settings), the footer may not be displayed.

- On Visual pages, this priority determines the displayed alarm color.

- Etc.

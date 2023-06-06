---
uid: Alarm_storm_protection
---

# Alarm storm protection

In order to avoid Cube getting flooded by a large number of alarms, it is possible to enable alarm storm protection.

Two types of alarm storm protection are available:

- By grouping alarms with the same parameter description.

  When this functionality is enabled, an “alarm storm start” threshold is set with the number of alarms with the same parameter description that trigger the alarm storm mode. In addition, an “alarm storm stop” threshold is configured with the number of alarms that end the alarm storm mode.

  This way, the alarm storm mode is activated as soon as a batch of alarms with the same parameter description exceeds the “alarm storm start” threshold, and deactivated as soon as the last batch of alarms with the same parameter description drops below the “alarm storm end” threshold.

- By applying a delay on alarms. (Available from DataMiner 9.5.2 onwards.)

  When this functionality is enabled, an “alarm storm start” threshold is set with the number of alarm updates in a particular time range that trigger the alarm storm mode. In addition, an “alarm storm stop” threshold is configured with the number of alarm updates that end the alarm storm mode.

  This way, new alarm updates are delayed as soon as the number of alarm updates within a particular time period exceeds the “alarm storm start” threshold, and displayed again as soon as the number of alarms within the configured time period drops below the “alarm storm end” threshold.

  > [!NOTE]
  > Only alarm updates with a higher severity than the current severity of an alarm are taken into account.

These two alarm storm protection types can be combined.

> [!TIP]
> See also: [Rui’s Rapid Recap – Alarm storm prevention](https://community.dataminer.services/video/ruis-rapid-recap-alarm-storm-prevention/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Configuring alarm storm protection

To configure alarm storm protection:

1. Go to *Settings \> \[User\] \> Alarm Console*.

1. Two options are available:

   - To enable alarm storm protection by grouping alarms with the same parameter description:

     1. Select *Enable alarm storm protection by grouping alarms with the same parameter description*.

     1. Next to *Start grouping above*, enter the number of alarms that trigger the start of alarm grouping.

     1. Next to *Stop grouping below*, enter the number of alarms that trigger the end of alarm grouping.

   - To enable alarm storm protection by applying a delay on alarms (from DataMiner 9.5.2 onwards):

     1. Select *Enable alarm storm protection by applying a delay on the alarms*.

     1. Next to *Start delaying above*, enter the number of alarm updates that trigger the start of the alarm delay.

     1. Next to *Stop delaying below*, enter the number of alarm updates that trigger the end of the alarm delay.

     1. Next to *Time range in which the chosen number of alarm updates must enter*, enter the time range in which these alarm updates must occur.

     1. Next to *Delay alarms for*, specify how long alarms should be delayed.

     > [!NOTE]
     > Only alarm updates with a higher severity than the current severity of an alarm are taken into account.

## About alarm storm mode

When alarm storm mode is activated, the following happens:

- A message appears, informing the user that alarm storm mode is activated.

- Depending on the selected type(s) of alarm storm protection, the following happens:

  - Alarms with the same parameter description that exceed the alarm storm start threshold are grouped into one alarm, similar to a correlated alarm.

  - If more alarm updates enter than the alarm storm start threshold, alarms are delayed for the configured time period. Any alarms that are cleared before this delay has passed will no longer be displayed.

- From DataMiner 10.0.0/10.0.2 onwards: In the alarm bar, a red button labeled “Alarm storm” appears. Prior to DataMiner 10.0.0/10.0.2: In the Cube header, the text “Alarm storm mode” appears.

  - If alarm storm protection by grouping is activated, you can hover over this notification in order to see an overview of the parameters in alarm storm mode as well as the number of alarms per parameter description.

  - If alarm storm protection by delaying is activated, you can click this notification to open a new card with a list of the delayed alarms. This card is not updated automatically, but a refresh button is available to update the displayed information.

- Several functionalities are disabled or limited:

  - Alarm information is no longer displayed in the card footer, nor in element card tree controls.

  - Alarm blinking and statistics are disabled.

  - Shapes in Visual Overview will no longer be linked to the alarms that triggered the alarm storm mode.

    - The alarm card of the alarms triggering the alarm storm will no longer be updated.

    - Reports, trending, view cards and the time slider will no longer be updated in real time.

When alarm storm mode is deactivated, the following happens:

- A message appears, informing the user that alarm storm mode is deactivated.

- All functionalities return to normal.

> [!NOTE]
> - Alternatively, these settings can also be configured on group level. See [Configuring a set of user group settings](xref:Configuring_a_set_of_user_group_settings).
> - Alarm storm prevention can also be configured for certain specific DataMiner functionalities:
>   - For more information on alarm storm prevention for notifications, see [Configuring alarm storm prevention for notifications](xref:Configuring_alarm_storm_prevention_for_notifications).
>   - For more information on alarm storm prevention for SNMP forwarding, see [Configuring an SNMP manager in DataMiner Cube](xref:Configuring_an_SNMP_manager_in_DataMiner_Cube).

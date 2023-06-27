---
uid: Configuring_alarm_storm_prevention_for_notifications
---

# Configuring alarm storm prevention for notifications

Alarm storm prevention for notifications can be configured on three levels: on system level, on user level, and on group level.

## Configuring alarm storm settings on system level

1. In DataMiner Cube, go to *Apps* > *System Center \> System Settings \> notifications alarm storm prevention*.

1. For each type of notification you wish to configure, *Alerter*, *Email* or *SMS*, do the following:

   1. Select the checkbox for the notification type in question to enable alarm storm prevention for this notification type.

   1. Enter the *Minimum number of alarms* that triggers an alarm storm.

   1. Below this, enter the *Maximum time range* in which these alarms need to occur.

   1. Optionally, in the box below, enter a custom warning message that should be given when the alarm storm is triggered. If you do not enter a custom message, the default message displayed in the box will be used.

1. In the lower right corner, click the *Apply* button.

## Configuring alarm storm settings on user/group level

1. In DataMiner Cube, go to *Apps* > *System Center \> Users / Groups.*

1. Select the user or group for which you want to configure the settings, and go to the *Alerts* tab.

1. If you are using a version of DataMiner prior to 9.5.4, in the lower right corner, click the *Edit* button.

1. Expand the *Alarm storm prevention* section at the top of the tab.

1. For each type of notification you wish to configure, do the following:

   1. Select the checkbox for the notification type in question to enable alarm storm prevention for this notification type.

   1. Enter the *Minimum number of alarms* that triggers an alarm storm.

   1. Below this, enter the time span in which these alarms need to occur.

   1. In the box below, enter the warning message that should be given when the alarm storm is triggered.

1. In the lower right corner, click the *Apply* button.

> [!NOTE]
> Alarm storm configuration on user level in Alerter is done in the Alerter application itself. For more information, see [Configuring alarm storm prevention in Alerter](xref:Configuring_Alerter_alarm_storm_prevention).

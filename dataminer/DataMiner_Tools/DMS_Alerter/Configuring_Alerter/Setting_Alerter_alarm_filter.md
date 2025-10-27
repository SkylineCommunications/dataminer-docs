---
uid: Setting_Alerter_alarm_filter
---

# Setting an alarm filter in Alerter

It is possible to filter the alarms that will generate alerts, so that your attention is only drawn to a specific subset of alarms. To do so, you can use a combination of client-side filters and server-side filters.

To configure Alerter filters:

1. Go to *Settings \> Filter*.

1. Select the options you wish to apply:

   - **Client-side filter**: In this section, you can configure a client-side severity filter. Select the severities for which an alert should be displayed. Though this will not stop alarms from entering the Alerter *Alarms* list, only the alarms with the selected severities will generate alerts.

   - **Use server-side filter**: If you select this option, click the ellipsis button on the right, and select one or more of the available alarm filters. Only alarms matching the alarm filters will be sent to Alerter.

   - **Use client-side filter**: If you select this option, click the ellipsis button on the right, and select one or more of the available alarm filters. Though all alarms will be sent to Alerter, only alarms matching the alarm filters will generate an alert. If you combine this option with the first *Client-side filter* option, alerts will only be generated for alarms that match the selected filters and have the selected severities.

   - **Only retrieve new alarms**: If you select this option, Alerter will not receive any alarms that already exist at the moment when you connect to the DMS. Only alarms that are generated from that moment onwards are sent to Alerter and can potentially generate alerts, depending on the client-side filter configuration.

   - **Hide acknowledged alarms**: If you select this option, when Alerter receives an alarm that is acknowledged, that alarm will still be added to the *Alarms* list, but no alert will be generated, even if the alarm matches the client-side filters.

   - **Hide cleared alarms**: If you select this option, when Alerter receives an alarm that is cleared, that alarm will still be added to the *Alarms* list, but no alert will be generated, even if the alarm matches the client-side filters.

   > [!NOTE]
   > The alarm filters that you can select with the *Use server-side filter* and *Use client-side filter* options can be configured in DataMiner Cube. See [Working with saved alarm filters](xref:ApplyingAlarmFiltersInTheAlarmConsole#working-with-saved-alarm-filters).

1. Click *OK*.

> [!NOTE]
> Alerter never shows masked alarms.

---
uid: Viewing_a_list_of_current_active_service_alarms
description: "View the service alarms currently affecting an SLA, configure alarm display settings, and understand the scope of active service alarms."
---

# Viewing a list of current active service alarms

To view a list of the alarms that are currently affecting the SLA, go to the *Active Service Alarms* page of the SLA element. This page displays an overview of the current alarms, with detailed information on each alarm.

> [!NOTE]
> If you are using a version of the *Skyline SLA Definition Basic* protocol prior to 2.0.0.15, this page is named the *Affecting Alarms* page instead. The naming of the column headers is also different, mentioning "Affecting Alarm" instead of "Current Active Service Alarm".

## Alarm details

Of particular note are the following columns:

- *Current Active Service Alarm Calculated Inclusion State*: Shows the impact of the alarm on the SLA in percent. The value is determined by violation filters, and by the offline window.

- *Current Active Service Alarm Overruled Inclusion State*: Shows whether the alarm is included or not. For more information on how to keep an alarm from being included, see [Excluding alarms that affect the SLA](xref:Excluding_alarms_that_affect_the_SLA).

- *Current Active Service Alarm Offline Impact*: Shows whether the alarm also affects the SLA during the offline window. By default, during offline windows, no alarms are taken into account, but this can be overruled on parameter level.

## Display settings

You can adjust how active alarms are displayed:

- **Hiding active alarms**: For performance reasons, it is possible to keep active alarms from being displayed on this page. To do so, set *Active Alarms* to *Hide* on the *Advanced Configuration* page of the SLA. Note that you need at least security level 3 to change this setting.

- **Hiding offline or non-impacting outages**: With recent versions of the *Skyline SLA Definition Basic* protocol, it is possible to hide outages that occur in the offline window and/or alarms that have no impact on the SLA because of violation filters. See [Setting the offline window for an SLA](xref:Setting_the_offline_window_for_an_SLA) and [Setting a violation filter](xref:Configuring_the_alarm_settings_for_an_SLA#setting-a-violation-filter).

## Limitations of the active service alarms overview

The *Active Service Alarms* page only displays alarms that are currently active and affecting the SLA. It does not provide historical alarm or SLA tracking information:

- To view recorded outage intervals, use the *Outage List* page instead.

- To view historical SLA results summarized by tracking period, go to the *History* page of the SLA element. The *History Statistics* table summarizes compliance, availability, and violations for each recorded tracking period (only available for SLAs that use a fixed window). It is not a list of individual historical alarms.

  On the *History* page, you can adjust the maximum number of rows in the *Max Number Of History Rows* box, or clear the table using the *Clear History* button in the lower-right corner.

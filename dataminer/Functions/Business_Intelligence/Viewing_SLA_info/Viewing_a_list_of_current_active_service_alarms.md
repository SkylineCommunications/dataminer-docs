---
uid: Viewing_a_list_of_current_active_service_alarms
---

# Viewing a list of current active service alarms

To view a list of the alarms that are currently affecting the SLA, go to the *Active Service Alarms* page of the SLA element.

> [!NOTE]
>
> - If you are using a version of the *Skyline SLA Definition Basic* protocol prior to 2.0.0.15, this page is named the *Affecting Alarms* page instead. The naming of the column headers is also different, mentioning “Affecting Alarm” instead of “Current Active Service Alarm”.
> - For performance reasons, it is possible to keep active alarms from being displayed on this page. To do so, set *Active Alarms* to *Hide* on the *Advanced Configuration* page of the SLA. Note that you need at least security level 3 to change this setting.
> - With recent versions of the *Skyline SLA Definition Basic* protocol, it is possible to hide outages that occur in the offline window and/or alarms that have no impact on the SLA because of violation filters. See [Setting the offline window for an SLA](xref:Setting_the_offline_window_for_an_SLA) and [Setting a violation filter](xref:Configuring_the_alarm_settings_for_an_SLA#setting-a-violation-filter).

This page displays an overview of the current alarms, with detailed information on each alarm. Of particular note are the following columns:

- *Current Active Service Alarm Calculated Inclusion State*: Shows the impact of the alarm on the SLA in percent. The value is determined by violation filters, and by the offline window.

- *Current Active Service Alarm Overruled Inclusion State*: Shows whether the alarm is included or not.

  > [!NOTE]
  > For more information on how to keep an alarm from being included, see [Excluding alarms that affect the SLA](xref:Excluding_alarms_that_affect_the_SLA).

- *Current Active Service Alarm Offline Impact*: Shows whether the alarm also affects the SLA during the offline window.

  > [!NOTE]
  > By default, during offline windows, no alarms are taken into account, but this can be overruled on parameter level.

To view a list of all alarms that have affected the SLA, including past alarms, go to the *History* page of the SLA. This page displays an overview of all alarms that have occurred, with detailed information on compliance, availability and violations.

> [!NOTE]
>
> - The *History Statistics* table only contains data for SLAs that use a fixed window.
> - It is possible to change the maximum number of rows in the *History Statistics Table*. To do so, enter the desired number of rows in the *Max Number Of History Rows* box. You can also clear the table using the *Clear History* button in the lower-right corner.

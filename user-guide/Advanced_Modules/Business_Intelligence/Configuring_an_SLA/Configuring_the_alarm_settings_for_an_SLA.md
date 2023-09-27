---
uid: Configuring_the_alarm_settings_for_an_SLA
---

# Configuring the alarm settings for an SLA

In DataMiner Cube, you can configure the following settings on the *SLA Configuration* page of the SLA element:

- [Setting the violation level](#setting-the-violation-level)

- [Setting the delay time](#setting-the-delay-time)

- [Setting a minimum outage threshold](#setting-a-minimum-outage-threshold)

- [Setting a violation filter](#setting-a-violation-filter)

In addition, more recent versions of the *Skyline SLA Definition Basic* protocol also allow certain advanced settings on the *Advanced Configuration* page. See [Advanced SLA alarm configuration](#advanced-sla-alarm-configuration).

> [!NOTE]
> The weight of alarms that occurred prior to a change to these settings will not be recalculated retroactively. We therefore recommend resetting the SLA after changing these settings.

## Setting the violation level

To define the service alarm level from which the SLA must indicate it has been violated, choose a violation level in the drop-down list under *Violation Level* and confirm your choice.

## Setting the delay time

To set a delay time before the SLA starts indicating that it has been violated, enter a value in the box under *Delay Time*, either by typing it in or by choosing from the drop-down list. Then confirm the value.

It is also possible to indicate that no delay is used, by selecting the *Not used* checkbox.

## Setting a minimum outage threshold

To set an initial time span during which an alarm is not taken into account, enter a value in the box under *Minimum Outage Threshold*, either by typing it in or by choosing from the drop-down list. Then confirm the value.

> [!NOTE]
> When a delay time has been set, if the alarm is still in effect once the delay time is over, the full duration of the alarm will be taken into account. When a minimum outage threshold has been set, the time set in the minimum outage threshold will not be taken into account for the duration of the alarm.

## Setting a violation filter

Not all alarms in a service are equally important. Set a violation filter to give a weight to a certain alarm or to filter out alarms.

> [!NOTE]
> From version 2.0.0.25 of the *Skyline SLA Definition Basic* protocol onwards, it is possible to hide alarms that have 0% impact because of violation filters. To do so:
>
> - Using version 2.0.0.25, on the *SLA Configuration* page, set *Hide Filtered Alarms* to *Hide*.
> - Using version 3.0.0 or higher, on the *Advanced Configuration* page, set *Violation Filtered Alarms* to *Hide*. Note that you need at least security level 3 in order to change any of the settings on the *Advanced Configuration* page.
>
> If the filtered alarms are set to be shown again later, the alarms that were hidden while this setting was set to *Hide* will not be displayed again.

### Adding a violation filter

To add a violation filter, follow the procedure below:

1. Go to the *Violation Configuration* page of the SLA element.

1. Click *Add Entry* at the bottom of the *Violation Settings* table.

1. In the first column, choose the *Violation Filter Type* in the drop-down list and confirm. This is the alarm field on which you wish to filter, e.g. Severity.

   > [!NOTE]
   > The violation filter types *Key point*, and *Component info* refer to parameter data that can be set in the protocol information template. For more information, see [Creating an information template](xref:Creating_an_information_template).

1. Enter a *Violation Filter Property Name* in the next column, if the filter type is a custom property.

1. Enter the *Violation Filter Value* in the next column, e.g. if the violation filter type is “Severity”, this could be “Minor”. It is possible to use an asterisk or question mark as wildcards here.

1. Enter the impact you want the violation to have as a percentage under *Violation Filter Impact*.

1. In the column *Violation Filter Exclusive*, toggle whether the filter should be exclusive or not.

   > [!NOTE]
   >
   > - If set to *Filter*, an alarm that does not match the filter will not be evaluated further, and the weight specified in the last matching rule is taken. If it did not match a previous rule, then the weight for that alarm is set to 0%.
   > - If set to *Continue*, the following filters are also processed, and if in the end none of the filters matched, the weight for that alarm is set to 100%. If several alarms match several of the violation filters set to Continue, the weightings will be added together. If one alarm matches several of the violation filters, the last matching filter is applied.

1. Enter a value under *Violation Filter Sequence* to indicate the sequence in which you wish different filters to be used. The lowest number will be sequenced first.

1. Enable or disable the filter in the column *Violation Filter State*.

   > [!NOTE]
   > The table is interpreted by DataMiner from top to bottom. It is sorted first on *Violation filter state* and then on ascending *Violation filter sequence*.

### Violation filter examples

#### Example 1

With the configuration below, masked alarms will not affect the SLA.

| Type                    | Property name | Value       | Impact | Exclusive | Sequence | State   |
|-------------------------|---------------|-------------|--------|-----------|----------|---------|
| Alarm state             | ...           | Masked      | 0%     | Continue  | 100      | Enabled |

#### Example 2

With the configuration below, warnings count for only 10 %, and minor alarms for 30 %. If an element is in maintenance, alarms will not count at all. Any other alarms will count for the full 100 %.

| Type                    | Property name | Value       | Impact | Exclusive | Sequence | State   |
|-------------------------|---------------|-------------|--------|-----------|----------|---------|
| Severity                | ...           | Warning     | 10%    | Continue  | 1        | Enabled |
| Severity                | ...           | Minor       | 30%    | Continue  | 2        | Enabled |
| Custom element property | State         | Maintenance | 0%     | Continue  | 3        | Enabled |

## Advanced SLA alarm configuration

The *Advanced Configuration* page allows you to configure a number of additional settings related to the alarms processed by the SLA. However, you need at least security level 3 in order to change any of the settings on this page. These are also only available in recent versions of the *Skyline SLA Definition Basic* protocol (at least 3.0.0.0).

The following settings are available on the *Advanced Configuration* page:

- **Active Alarms**: To keep active alarms from being displayed on the *Active Service Alarms* page, set this setting to *Hide*. See [Viewing a list of current active service alarms](xref:Viewing_a_list_of_current_active_service_alarms).

- **Outages**: See [Turning SLA tracking on and off](xref:Turning_SLA_tracking_on_and_off).

- **Violation Filtered Alarms**: To hide alarms that have 0% impact because of violation filters, set this setting to *Hide*.

- **Offline Window Outage**: To hide outages that occur in the offline window, set this setting to *Hide*. See [Setting the offline window for an SLA](xref:Setting_the_offline_window_for_an_SLA).

- **Predictions**: Enable this setting to enable predicted availability and compliance calculation. See [Checking SLA Key Performance Indicators](xref:Checking_SLA_Key_Performance_Indicators) and [Checking the SLA compliance](xref:Checking_the_SLA_compliance).

- **Show Excluded Service Element Alarms**: Requires at least version 3.0.0.10 of the *Skyline SLA Definition Basic* protocol and DataMiner 9.5.5. If this setting is set to *Hide*, all references to excluded or 'Not used' elements will be removed from the SLA, and alarms on such elements will no longer affect the SLA.

- **Use Service Capping**: Requires at least version 3.0.0.10 of the *Skyline SLA Definition Basic* protocol and DataMiner 9.5.5. When you activate this setting, if a maximum severity is configured for alarms affecting the service, this "capping" will be applied to the SLA as well.

- **Affecting Alarms Level**: Requires at least version 3.0.0.10 of the *Skyline SLA Definition Basic* protocol and DataMiner 9.5.5. Set this parameter to a particular percentage to configure which impact alarms must have before they are considered to affect the SLA. On the *Main View* page, the *Number of Affecting Alarms* parameter will then indicate the number of alarms currently affecting the SLA according to this setting.

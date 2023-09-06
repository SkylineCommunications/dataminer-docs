---
uid: Connector_help_British_Telecom_-_21C_Ingest_Probe_Monitoring_Controller
---

# British Telecom 21C Ingest Probe Monitoring Controller

This is a virtual driver that is used to control/monitor the 21C Ingest Probes. The **IneoQuest Surveyor TS** probe is used as source probe. Manual or automatic actions can take place based on user interaction or based on probes reporting failures. To control the application, use the Visual Overview layer.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | /                      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                  | **Exported Components** |
|-----------|---------------------|-------------------------|------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [IneoQuest Surveyor TS](xref:Connector_help_IneoQuest_Surveyor_TS) | /                       |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

When the element has been created, several things need to be configured on the **Configurations** page:

- **Probe Polling Interval**: Determines how frequently the Manager needs to poll the probes. The range is *5 seconds* up to *2 minutes*.Note that the probe info is instantly pushed towards the Manager. This polling interval is purely intended for sync/fallback purposes.

- **Automatic Clean Up Delay**: The hysteresis time that the failure must be active in order for the automatic rediscovery to take place. When the delay has passed, the script will check the current state again and perform the rediscovery only if it is still necessary.This hysteresis makes it possible to ignore short outages or brief temporary streams. When this setting is disabled, automatic rediscovery will take place as soon as a failure comes in (in case the channel is monitored and running in Auto mode).

- **QoS on Hysteresis Time**: The time to wait before an outage is taken into account. Note that when an outage is taken into account, the full time will be counted for the QoS statistics.

- **QoS Refresh rate**: The refresh rate for the QoS statistic calculations. This can be increased or decreased to improve overall performance vs. QoS update speeds.

- **QoS Window Size**: The window size of the QoS statistics. When a window is closed, the results will move to the Last Window statistics columns and parameters.

- **QoS Window Definition**: Depending on the window size, the following parameters are needed:

- **Day of Month** (only applicable when the **Window Size** is *1 Month*).
  - **Day of Week** (only applicable when the **Window Size** is *1 Week*).
  - **Time of Day** (This field is always used to indicate when the window starts.)

- **VLAN Failure Hysteresis**: The amount of time the element waits before adding the outage time when a failure is detected for all channels in the same VLAN. This allows you to keep the outage value from increasing when there's a transition from one VLAN to another.

### Redundancy

There is no redundancy defined.

## How to use

### Probes

The main Visual Overview page shows an overview of the **Configured Probes**.

When you click the **Configuration** button, a pop-up window will open where you can configure the probes. However, note that this button is only available for users who have at least access level 1. For each VLAN, a probe/slot combination can be selected on one of the IneoQuest Surveyor probes.

The **Connection State** will show if the probe link is active and the **VLAN Status** will indicate the health of the streams on the probe. Depending on the configurable **Outage Threshold**, the states will change. Via the **Clear Manually** button you can change the "*Fail"* state to "*Not In Service (Fail)*".

Extra configuration parameters are available to configure where the source signals of the probe come from. This will be used to discover probe link failures.

### Channels

The main Visual Overview page also lists all the channels that are monitored by the probes. The following information is available: **ID**, **Name**, **Channel State, Monitoring Mode** and all the VLAN states.

The VLAN Status parameters are combined status values:

- *OK*: Stream is available.
- *OK (Not Preferred)*: Stream is OK, but normally not on this VLAN. (Depends on the **VLAN Used** column.)
- *Lost*: Stream is no longer available.
- *N/A*: Stream is not available, but there are no alarms.

**Average Availability Current Window** and **Average Availability Last Window** show the percentage of availability for all channels that have the marker **Reportable** set to *Yes*.

### Channel modifications

The main Visual Overview page contains page buttons that can be used to perform channel actions and configure settings. However, note that you need at least access level 1 to use these buttons.

Before opening the configuration window, you first have to make a selection in the Channels table. You can use the shortcut Ctrl+A to select all the items in the table. When you first apply a regular filter on the table and press Ctrl+A, only the filtered items will be selected.You can also make a dynamic selection using the Ctrl key to select multiple single channels, or using the SHIFT key to select a range of channels in the table. The use of Ctrl+A, SHIFT and Ctrl can also be combined.

- **Channel Modes:** Opens a pop-up window where you can update the channel mode for all selected channels in bulk. The following modes are available:

- *Channel State --\> **Monitored**:* The channel will be monitored by the application. Based on the monitor mode (*Auto* or *Manual)*, rediscovery will be done automatically.
  - *Channel State --\> **Monitoring Mode***: The channel will not be monitored. No actions are allowed.
  - *Monitoring Mode --\> **Auto***: The channels will automatically issue a rediscovery when outage failures are detected and the **Automatic Clean Up Delay** time has passed.
  - *Monitoring Mode --\> **Manual***: No automatic rediscovery will be performed, but it is allowed to perform manual actions.

> A confirmation message will list the changes you have made.

- **Channel Actions**: Opens a pop-up window where you can perform channel actions in bulk for all the selections made on this page.You can make the selections by using the Select All/Unselect All buttons, or by using the selection buttons on row or column level. You can also update single selections by directly selecting/deselecting the selection icon (lightning icon).Once the selection has been made, you can perform the following actions:

> - *Rediscover*: The script will be started per VLAN probe to rediscover all selected channels.
>
> A confirmation message will list the changes you have made. Rediscovery actions will be marked in the confirmation response.

Note that all manual changes will be performed immediately. The hysteresis times are only taken into account for automatic rediscovery.

### History Logs

When you click the history log icon on the main Visual Overview page, a pop-up window opens that lists the history events. For each event, the window shows the timestamp and the user who performed the action. Only manual actions are included in the log. When you select an entry, a detailed overview of the committed change is displayed next to it.

### Statistics

The statistics page gathers multiple availability averages that are calculated based on time constraints.

The **Daily Statistics Table** is updated every day based on the availabilities provided in the respective channel SLAs. Each day, the 21C Ingest Probe Manager fetches all history rows from each channel SLA and processes the last N rows. This N value is defined in the **Daily Statistics Limit per Channel** parameter.

Each row in the Daily Statistics Table is taken into account for the monthly statistics row calculation. When the month changes, a new monthly statistics row is calculated and added to the **Monthly Statistics Table**. When each channel reaches the limit defined in **Monthly Statistics Limit per Channel**, an older row will be replaced by a newer one.

Each channel can be assigned a category label. This category is used to aggregate multiple statistics into the **Availability Statistic Category Table**, which will aggregate the latest info from a channel with all the channels that contain the same category label. Channels that do not have a category assigned will be ignored and will not be taken into account for the statistics shown in this table.

Last Day/Week Availabilities are calculated from availability values from the **Daily Statistics Table** and Last Month/Year Availabilities are calculated from the data available in the **Monthly Statistics Table.**

The **Daily/Weekly/Monthly/Yearly Average Availability** refers to the average of all data from the current day, the last completed week, the last completed month and the last completed year, respectively.

Note that for all averages, only the last completed set of data and the availabilities corresponding to this time window are taken into account. This means that in the Availability Statistic Category, only data belonging to the same, and most recent, day/week/month/year is taken into account.

## Notes

This application requires a custom-designed Visio file. In addition, an Automation script is needed to control the probes (script name: *British Telecom 21C Probe Manager*).

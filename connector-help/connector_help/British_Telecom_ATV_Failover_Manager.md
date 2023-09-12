---
uid: Connector_help_British_Telecom_ATV_Failover_Manager
---

# British Telecom ATV Failover Manager

This is a virtual connector that is used to control/switch sources on **AppearTV X20** devices based on the signals measured by the probes. Both **IneoQuest Surveyor TS** probes and **IneoQuest Inspector Live** probes are supported for this integration. Manual or automatic actions can take place based on user interaction or probes reporting failures. To control the application, you need to use the Visual Overview layer.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | FDS          | New application.  |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                                                                                      | **Exported Components** |
|-----------|---------------------|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [AppearTV X20 Platform](/Driver%20Help/AppearTV%20X20%20Platform.aspx) [IneoQuest Surveyor TS](/Driver%20Help/IneoQuest%20Surveyor%20TS.aspx) [IneoQuest Inspector Live](xref:Connector_help_IneoQuest_Inspector_Live) | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When the element has been created, several things need to be configured on the **Configurations** page:

- **Probe Polling Interval**: Determines how frequently the ATV Failover Manager needs to poll the probes. The range is *5 seconds* up to *2 minutes*.
  Note that the probe info is instantly pushed towards the manager. This polling interval is purely intended for sync/fallback purposes.
- **ATV Polling Interval**: Determines how frequently the ATV Failover Manager needs to poll the AppearTV X20 devices. The range is *1 minute* up to *1 Day*.
- **Auto Switch Delay**: The hysteresis time that the automatic routing/unrouting will wait before checking the current state again and performing the expected switch based on this result.
  This hysteresis makes it possible to ignore short outages or short temporary streams.

### Redundancy

There is no redundancy defined.

## How to use

There are two Visual Overview pages: **SKY -\> BT** and **BT -\> SKY**. Both pages have the same structure and capabilities; only the data will be different.

### Probes

The main Visual Overview page shows an overview of the **Configured Probes**.

When you click the **Configuration** button, a pop-up window will open where you can configure the probes. However, note that this button is only available for users who have at least access level 1.

For each path, a probe/slot combination can be selected on one of the IneoQuest Surveyor or Inspector Live probes and the linked AppearTV X20 device can be configured.

The **Connection State** will show if the probe link is active. The **Force Poll Probe** button can be used to trigger an instant update of the relevant probe info.

### Channels

The main Visual Overview page also lists all the channels that are monitored by the probes. The following information is available: **ID**, **Name**, **Channel State**, and all the path states.

The Path Status parameters are combined status values:

- *Not monitored*: The state of this channel is set to *Disabled*.
- *Not Initialized*: Not all required parameters have been filled in to calculate the state.
- *(A) Master*: Automatic Mode, Current Path is in Master state, no detected issues.
- *(A) Master Fail*: Automatic Mode, Current Path is in Master state, issues detected. (If the Slave state is OK, switching will initiate.)
- *(A) Slave*: Automatic Mode, Current Path is in Slave state, no detected issues.
- *(A) Slave Fail*: Automatic Mode, Current Path is in Slave state, issues detected.
- *(M) Master*: Manual Mode, Current Path is in Master state, no detected issues.
- *(M) Master Fail*: Manual Mode, Current Path is in Master state, issues detected.
- *(M) Slave*: Manual Mode, Current Path is in Slave state, no detected issues.
- *(M) Slave Fail*: Manual Mode, Current Path is in Slave state, issues detected.
- *Master*: Monitor Mode, Current Path is in Master state, no detected issues.
- *Master Fail*: Monitor Mode, Current Path is in Master state, issues detected.
- *Slave*: Monitor Mode, Current Path is in Slave state, no detected issues.
- *Slave Fail*: Monitor Mode, Current Path is in Slave state, issues detected.

### Channel modifications

The main Visio page contains page buttons that can be used to perform channel actions and configure settings. However, note that you need at least access level 1 to use these buttons.

Before opening the configuration window, you first have to make a selection in the Channels table. You can use the shortcut "CTRL+A" to select all the items in the table. If you first apply a regular filter to the table and then press "CTRL+A", only the filtered items will be selected.
You can also make a dynamic selection using the "CTRL" key to select multiple single channels, or using the "SHIFT" key to select a range of channels in the table. The "CTRL+A", "SHIFT", and "CTRL" actions can also be combined.

- **Channel Modes:** Opens a pop-up window where you can update the channel mode for all selected channels in bulk. The following modes are available:

- *Control Mode:* The channel can be controlled by the ATV Failover Manager. Based on whether the channel path is set to *Auto* or *Manual*, actions can be performed.
  - *Monitor Mode*: The channel will be monitored only. No actions are allowed.
  - *Disabled Mode*: The channels will not be monitored or controlled.

> A confirmation message will list the changes you have made.

- **Channel Actions**: Opens a pop-up window where you can perform channel actions in bulk for all the selections made on this page.
  You can make the selections by using the Select All/Unselect All buttons, or by using the selection buttons on row or column level. You can also update single selections by directly selecting or removing the selection from the selection icon (lightning icon).
  Once the selection has been made, you can perform the following actions:

> - *Manual Mode*: Will allow manual routings, and no automatic actions will be performed.
> - *Auto Mode*: Will not allow manual override actions. Automatic actions will be performed. In case the state was *(M) Master Fail*, and the slave is running fine, auto routing will be initiated (or vice versa).
> - *Manual Mode + Force Route P1*: Manual mode will be forced, and the signal will be switched to path 1.
> - *Manual Mode + Force Route P2*: Manual mode will be forced, and the signal will be switched to path 2.
> - *Manual Mode + Force Swap*: Manual mode will be forced, and the signal will be altered to the current slave path.
>
> A confirmation message will list the changes you have made. Route changes will be marked with (P1) and (P2) for switches to *Path 1* and *Path 2*, respectively.

Note that all manual changes will be performed immediately. The hysteresis times are only taken into account for automatic switching.

### History Logs

When you select the history log icon on the main Visual Overview page, a pop-up window will open that lists the history events. The window shows the timestamp and the user who performed the manual action. When you select an entry, a detailed overview of the committed change is displayed next to it.

## Notes

A custom Visio file is needed in order for the application to work. In addition, an Automation script (with script name *British Telecom ATV Failover Manager*) is needed to execute the actual routings on the AppearTV X20 devices.

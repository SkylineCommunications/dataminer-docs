---
uid: Connector_help_British_Telecom_Strobe_Manager
---

# British Telecom Strobe Manager

This is a virtual driver for the British Telecom Strobe Manager.

It can be used to configure IneoQuest Surveyor probes to the British Telecom Strobe element to one of four paths (**BTT X**, **BTT Y**, **CH X**, and **CH Y**). When the driver has been correctly configured, it will retrieve and show the channels with their status in an overview in the **Channel Table**. Based on the mode a channel is in, the Strobe Manager can automatically send updates to the respective CISCO Nexus devices (CLI commands to route or unroute certain channels). It is also possible to perform manual actions on selections made across paths and across channels to *Force On* or *Force Off* the path signal for selected channels.

It is important that this driver is used in combination with the **Visio drawing** that was designed for this purpose.

## About

### Version Info

| **Range**            | **Key Features**                                                                    | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                                    | \-           | \-                |
| 2.0.0.x \[Obsolete\] | Strobe Manager 2.0: Workflow with IneoQuest Inspector Live and CISCO Nexus devices. | \-           | \-                |
| 2.0.1.x \[SLC Main\] | Decoupled MIP tables for Static Joins Interface 1 and Interface 2 tables.           | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

When the element has been created, you need to configure several things on its **Configurations** page:

- **Probe Polling Interval**: Determines how frequently the Strobe Manager needs to poll the probes. The range is *5 seconds* up to *2 minutes*.Note that the probe info is instantly pushed towards the Strobe Manager. This polling interval is purely intended for sync/fallback purposes.
- **Add Route Hysteresis** and **Remove Route Hysteresis**: The hysteresis time that the automatic routing/unrouting will wait before checking the current state again and adding or removing a route based on this result. This hysteresis makes it possible to ignore short outages or short temporary streams.

In addition, on the **MIP** page, you need to provide the references to the primary keys of the Cisco Nexus switches in order to have cross checking on the expectations vs. the actual routes and joins being made:

- **API Ref Routes**, **Static Join Interface 1 API Ref**, and **Static Join Interface 2 API Ref**: These should point to the *Primary Key* *(PID:17201) as GUID values* of the **API Polling** table (see **CLI** page on the CISCO Nexus element that is configured per probe).
- Via the context menu on the MIP tables you can add, update or remove trackers. Note that typically, linked Automation scripts ("*Control Path Nexus Auto*" or "*Control Path Nexus Manual*") take care of adding/updating the trackers list instead, which means that no manual configuration is needed.

## How to Use

### Probes

The main Visual Overview page shows an overview of the **Configured Probes**.

When you click the **Configuration** button, a pop-up window will open where you can configure the probes. However, note that this button is only available for users who have at least access level 1.

For each path, a probe/slot combination can be selected on one of the IneoQuest Surveyor probes and the linked CISCO Nexus element can be configured.

The **Connection State** will show if the probe link is active. With the **Switch Control** setting, you can disable switching on the Nexus for a certain path. The **Force Poll Probe** button can be used to trigger an instant update of the relevant probe info.

The **MIP** tables, which are used to cross-check if the expected routes and joins are present, are aggregated on probe level. The following parameters are available: **Nexus IP Routes State**, **Nexus Static Joins Interface 1 State** and **Nexus Static Joins Interface 2 State**. Only the AUTO mode items are considered from the expected MIP tables:

- *In Sync*: The expected static joins are present.
- *Fail (Auto) Link Missing*: The leg in auto state is currently missing one or more expected static joins.
- *Fail (Auto) Link Present*: The leg in auto state currently has one or more static joins that should have been removed.

### Channels

The main Visio page also lists all the channels that are monitored by the probes. The following information is available: **ID**, **Name**, **Active Path**, **Channel State**, **Priority**, **BTT X Status**, **BTT Y** **Status**, **CH X Status** and **CH Y Status**.

The BTT X, BTT Y, CH X and CH Y Status parameters are combined status values:

- *OK (Auto):* The channel is OK, and the mode is set to *Auto*.
- *OK (Monitor):* The channel is OK, but the state of this service is set to *Monitor*.
- *Failure (Auto)*: The channel is not OK, and the mode is set to *Auto*.
- *Failure (Monitor)*: The channel is not OK, and the mode is set to *Manual*.
- *OK (Off)*: The channel is OK, but the route was manually removed in the Nexus.
- *OK (On)*: The channel is OK, and the route is present in the Nexus.
- *Failure (On)*: The channel is not OK, but the route was manually added in the Nexus.
- *Failure (Off):* The channel is not OK, and there is no route in the Nexus.
- *Not Monitored*: The state of this service in the Strobe Manager is set to *Disabled*.
- *Not Initialized:* Not all parameters required to calculate the state have been filled in.

**MIP** states are also aggregated on channel level. The following parameters are available: **BTT X MIP State**, **BTT Y MIP State**, **CH X MIP State** and **CH Y MIP State**. The state is calculated out of the states from the expected joins (Interface 1 and Interface 2) and Expected Routes Table for that leg/probe. When one of these three marks an issue, the state on channel level will indicate *NOK.*

### Channel modifications

The main Visio page contains page buttons that can be used to perform channel actions and configure settings. However, note that you need at least access level 1 to use these buttons.

Before opening the configuration window, you first have to make a selection in the Channels table. You can use the shortcut "CTRL+A" to select all the items in the table. When you first apply a regular filter on the table and press "CTRL+A", only the filtered items will be selected.You can also make a dynamic selection using the "CTRL" key to select multiple single channels, or using the "SHIFT" key to select a range of channels in the table. The "CTRL+A", "SHIFT" and "CTRL" actions can also be combined.

- **Channel Priorities:** Opens a pop-up window where you can update the priority for all selected channels in bulk. The following priorities are available: *N/A*, *LoLo*, *Lo*, *Normal*, *Hi* and *HiHi.* A confirmation message will list the changes you've made.

- **Channel Modes:** Opens a pop-up window where you can update the channel mode for all selected channels in bulk. The following modes are available:

- *Control Mode:* The channel can be controlled by the Strobe Manager. Based on whether the channel path is set to *Auto* or *Manual*, actions can be performed (in case the **Switch Control** is *Enabled* for that specific path - see **Probes**).
  - *Monitor Mode*: The channel will be monitored only. No actions are allowed.
  - *Disabled Mode*: The channels will not be monitored or controlled.

> A confirmation message will list the changes you've made.

- **Channel Actions**: Opens a pop-up window where you can perform channel actions in bulk for all the selections made on this page.You can make the selections by using the Select All/Unselect All buttons, or by using the selection buttons on row or column level. You can also update single selections by directly selecting/deselecting the selection icon (lightning icon).Once the selection has been made, you can perform the following actions:

> - *Manual Mode*: Will allow manual routings and no automatic actions will be performed.
> - *Auto Mode*: Will no longer allow manual override actions. Automatic actions will be performed. In case the state was *Failure (On)* or *OK (Off)*, the routings will automatically be updated.
> - *Manual Mode + Force Route On*: Manual mode will be forced, and the route will be added.
> - *Manual Mode + Force Route Off*: Manual mode will be forced, and the route will be removed.
>
> A confirmation message will list the changes you've made. Route changes will be marked with (R) and (U) for Route and Unroute, respectively.

Note that all manual changes will be performed immediately (ordered by priority if applicable). The hysteresis times are only taken into account for automatic changes.

### History Logs

When you select the history log icon on the main Visio page, a pop-up window will open listing the history events. The window shows the timestamp and the user that performed the manual action. When you select an entry, a detailed overview of the committed change is displayed next to it.

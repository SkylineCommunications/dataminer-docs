---
uid: Connector_help_Imagine_Communications_SX_Pro_Multiviewer
---

# Imagine Communications SX Pro Multiviewer

This connector uses the **SNMP** protocol to gather status information from the **SX Pro Multiviewer** card, which is usually installed inside a Platinum router or matrix. The connector also receives SNMP **traps** from the multiviewer card.

## About

The **Platinum SX Pro Multiviewer** is designed for baseband applications. Integration with the router platform provides a single system solution to enable an efficient use of space in complex broadcast and A/V monitoring environments.

The Platinum SX Pro hardware is installed in the output section of a Platinum or IP3 router frame. It takes inputs from the router where it is installed and combines those inputs on three or six different output displays. The size of the various options determines the number of outputs (three or six) and the number of inputs (8 to 64, with optional redundancy when installed in a 5RU, 9RU or 15RU frame).

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.0.76                      |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default: *public*.
- **Set community string**: The community string used when setting values on the device, by default: *private*.

## Usage

### General

This page displays general information about the multiviewer, including the **System Name**, current **System Alarm Status** and **Software Version**.

The page also contains the **Group Status Table**, where you can set the **Active Preset** for each **Group ID** on the multiviewer.

### Display and PIP Status

This page shows the **PIP Status Table** and the **Display Status Table**.

The **PIP** (Video Channel) **Status Table** shows the **PIP Cards** and **PIP Channels** and the associated bitwise **PIP Alarm** and **PIP Audio Bar** for each channel. Also included are the **PIP Labels**, the bitwise **PIP Talley** lamp state and **PIP Dolby E Pair Alarm**.

The **Display Status Table** shows the scalar ID in full screen within a display.

### Audio Status

This page displays the **Audio Status Table**, which contains each bitwise **Audio Alarm** for each audio channel across all the **Audio PIP** channels.

### Alarm Summary

On this page, the **Recent Alarms** section shows information about the most recent alarm events. The **Alarm Summary** section shows the total number of various current alarms. The **Event Occurrence** section shows changes made to either **UMD** or **Tally PIP** changes.

### Dolby E Status

This page displays the **Dolby E Status Table**, which shows several alarms and parameters for each audio channel, including **Channel Type**, **Loss**, **Program Configuration Changes**, **Dialnorm Under Level**, **Dialnorm Over Level**, **DRC Change** and **Metadata Mismatch**.

### Traps

This page displays traps received from the multiviewer. Enabling and using traps can capture short duration alarms that occur outside of the normal connector polling cycles.

On the **Auto Clear** subpage, the auto-clear method can be configured, either by configuring **Max. Number** of traps, **Max. Duration** of traps or **Both (Max. Number and Max. Duration)**, or by clearing **Upon Alarm Polling**. The table size will remain constant, but when the max. number has been reached, the oldest table entries will be purged to make room for new entries. You can also clear all current traps by clicking the **Clear All Traps Now** button on this subpage.

## Notes

In order to receive SNMP traps with this element, it is necessary to make the following configuration changes to the device using its web interface GUI:

- **Hardware Configuration\SNMP**: Set **Trap Destination** to the **DMA IP** or the **Virtual IP** when using a 1:1 Failover DMA configuration.

- **Time Code: Trap Timestamps** are affected by this setting and care should be taken to select a proper time sync reference.

- **PC**: Allows you to set the **DMA IP** as the time source or the **Virtual IP** when using a 1:1 Failover DMA configuration.
  - **NTP**: Allows you to set **any NTP Server** in the network as the time source.

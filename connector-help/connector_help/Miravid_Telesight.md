---
uid: Connector_help_Miravid_Telesight
---

# Miravid Telesight

This is an SNMP connector that is used to monitor the Miravid Telesight.

## About

The connector is used to monitor a Miravid Telesight.

### Version Info

| **Range** | **Description**                                   |
|------------------|---------------------------------------------------|
| 1.0.0.x          | Initial version                                   |
| 2.0.0.x          | Review based on 1.0.0.x (table PIDs are the same) |

## Configuration and Installation

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### Programs

This page displays an overview of the programs in the device.

There are a couple of settings that influence the data in this table:

- **Automatically Remove All Missing Programs**: This setting will automatically remove the program entries that are missing.
- **Remove Missing Programs**: This can be used if **Automatically Remove All Missing Programs** is set to *false*. When you select one of the missing programs, it will be deleted from the table.

Click the **Advanced** page button to access additional settings:

- **Remove Special Characters**: This setting can be used to remove special characters from the program names.
- **Audio Silence Mode**: If the value is *Single*, then **Audio Silence** will be set to *Fail* as soon as one of the audio channels is *silent*. If the value is *Both* (default), then **Audio Silence** will be set to *Fail* only if both channels are *silent*.

### Alarms

On this page, you can find a table displaying the active alarms of the device.

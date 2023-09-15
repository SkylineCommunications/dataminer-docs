---
uid: Connector_help_Intellian_ACU_SNMP
---

# Intellian ACU SNMP

The Intellian ACU SNMP connector is used to monitor Intellian ACU devices with SNMP.

## About

This connector can be used to monitor the status of satellite tracking with the Intellian ACU device.

The protocol range 2.1.0.x is only compatible with the device firmware version 3.14.

### Version Info

| **Range**     | **Description**                                                    | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Old range.                                                         | No                  | Yes                     |
| 2.0.0.x              | New range for firmware v3.14.                                      | No                  | Yes                     |
| 2.1.0.x \[SLC MAIN\] | New range based on version 2.0.0.x. Major impacting changes added. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | 3.14                        |
| 2.1.0.x          | 3.14                        |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP Address/host**: The polling IP of the device.
- **Device address:** Not required.

SNMP Settings:

- **Port Number:** The port of the connection device, by default *161*.
- **Get community string:** The community string required to read from the device. The default value is *public.*
- **Set community string:** The community string required to set to the device. The default value is *private*.

## Usage

### General

This page contains general system parameters, such as the **System Description**, **System Contact**, **System Name**, etc.

### Interfaces

This page displays the **Interface Table**, which contains information related to the network interfaces of the device, such as **Type**, **MTU**, **Speed**, **Data Rate**, etc.

### Status

This page contains the main status information: **Status Lock**, **Latitude**, **Elevation**, **Status Track**, **TX Polarization**, **Bow Offset**, etc.

### Status Overview

Every 5 minutes, the **ACU Status Overview** table on this page is filled in with a new entry detailing the **Azimuth Relative Position**, **Elevation Position**, **NBD Frequency** and **Satellite Name** at that particular time**.**

### Blind Sector

This page contains the **Blind Sector Table**, where **Azimuth/Elevation Start/Stop** angles can be filled in. This way, an alarm can be generated via the **In** **Blind Sector** parameter when the satellite is in one of the defined blind sectors.

The **History Table** page button shows all the blind sector events in the last **History Age** month(s).

### Blocked Zones

This page displays a table with information regarding the antenna blocked zones in the ships (**Blocking Interval**: **Azimuth Start** and **End**, **Elevation**).

Blocking zones can be pre-configured via a page button.

### Export GPS Trace

On this page, you can enable or disable the **GPS data export feature** (storing GPS locations in the database) and adjust the corresponding settings.

### Web Interface

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

This connector is accompanied by a **custom Visio file** containing a compass scheme on the left, which shows the **ship heading** (compass needle), the **satellite positioning** and the **satellite communication blocked areas** (blue semi-circles).

---
uid: Connector_help_Cobham_SeaTel_MXP
---

# Cobham SeaTel MXP

This connector is designed to work with the Cobham SeaTel MXP to poll information about the system, antenna, and satellite, and to configure these.

An **SNMP** connection is used to communicate with the system.

## About

### Version Info

| **Range**            | **Key Features**                                                  | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                  | \-           | \-                |
| 1.0.1.x \[Obsolete\] | Initial version.                                                  | \-           | \-                |
| 1.1.0.x              | Main version for 2.xx and 3.xx firmware versions.                 | \-           | \-                |
| 1.2.0.x              | Main version for 1.xx firmware version.This version is read-only. | \-           | \-                |

### Product Info

| **Range**            | **Supported Firmware** |
|----------------------|------------------------|
| 1.0.0.x \[Obsolete\] | 2.12                   |
| 1.0.1.x \[Obsolete\] | 2.15                   |
| 1.1.0.x              | 2.xx, 3.xx             |
| 1.2.0.x              | 1.xx                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.2.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.

## How to use

You can find more information about the different data pages of the element below.

### General

On this page, you can find information about the ship where the unit is located. This includes the **ship's name**, **location**, **heading** and **average speed** (calculated based on the ship's previous positions).

The page also contains general information about the system, including its **name**, its **uptime**, the system **contact**, its **location**, the number of **services** it has, and its **firmware version**.

### System

This page allows you to configure system information. This includes **threshold mode** and **value** for the selected satellite, **auto search** mode for the system, **trims** for the system's **azimuth and elevation**, and the **name of the satellite**.

The **Modem** page button displays more information on the modem, including its type, I/O setting, and lock. Lastly, there are buttons for the **save**, **reboot**, and **firmware upgrade** functions.

### Satellite

This page contains information about the satellite, including its current **threshold** value, **lock** and **transmit mute** setting, the current **search delay**, **azimuth**, **elevation**,and **cross level**. It also lists any **errors** reported by the satellite as well as its **serial number**.

A number of settings can also be configured here, including the satellite's **longitude**, **frequency**, **skew**, **band**, **transmit polarity**, **search pattern**, **reflector**, **LNB** setting, **threshold auto offset** value, and **transmit mute** setting, as well as the **favorite satellite**.

### Antenna

This page contains information about the system's antenna, including its **model**, **relative position**, **linear polarity angle**, **AGC** value, and whether or not it is **initializing** or **targeting**.

A number of settings for the antenna can also be configured here.

### Blocked Zones

This page displays a table with information regarding the antenna blocked zones in the ships (**Blocking Interval** between **Azimuth**/**Elevation** **Start** and **End**).

Blocking zones can be preconfigured via a page button.

### Export GPS Trace

On this page, you can enable or disable the **GPS data export feature** (storing GPS location in database)and configure the corresponding settings.

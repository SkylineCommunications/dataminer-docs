---
uid: Connector_help_General_Dynamics_TRSC_1200
---

# General Dynamics TRSC 1200

With this driver, you can gather and view information from the General Dynamics TRSC 1200, as well as set values on this device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP address/host:** The polling IP of the device, e.g. *172.16.109.21.*
- **Device address:** Not needed.

SNMP Setting:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element consists of the data pages detailed below.

### General

This page displays general information about the device, such as the firmware version, device type, uptime, unit serial number, etc.

### Power Supply

This page shows information related to the power supply.

It also allows you to set the **TLNB Power Supply** and **TLNB Current Window,** and to enable or disable the **Power Up Warning** alarm.

### Unit Configuration

This page allows you to configure several parameters of the device, such as the **Controller Type**, **Band Switch Position**, **Calibration Control**, etc.

### Unit Status

This page displays the status of the unit alarms, with parameters such as **Power Up Warning**, **TLNB Fault**, **Power Supply Fault**, etc.

You can also reset the alarm state for all alarms, by clicking the button **Reset Alarms**.

In addition, the following page buttons are available:

- **Alarm Log:** Contains a table with log information for the last 32 alarms.
- **Detailed Status:** Contains more detailed alarms from the device.
- **History Alarms**: Displays the alarm history of the device.

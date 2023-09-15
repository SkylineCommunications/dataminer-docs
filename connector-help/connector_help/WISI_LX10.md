---
uid: Connector_help_WISI_LX10
---

# WISI LX10

With this connector, information from the device **WISI LX10** can be gathered and viewed, and values can be set on the device.

## About

Connector used to gather information from the **WISI LX10** device.

The connector has several pages with general information, alarms, power supply, transmitter information, etc.

## Installation and configuration

### SNMP Connection

- **IP address/host:** The polling IP of the device, e.g. *172.27.64.55*.
- **Device address:** Not needed.

### SNMP Setting

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

This page displays some general information about the device, such as the firmware version, device type, uptime, vendor information, etc.

### Power Supply

This page shows information regarding the power supply, as well as the status of the cooling fans.

### Transmitter Data

This page displays information regarding the transmitter: general transmitter information, laser information, CATV information, optical information, satellite information and voltage information.

### Unit alarms

This page displays the status of the transmitter alarms: the **System Temperature**, **Laser current**, **Optical Power**, etc.

The following page buttons are also available:

- **Alarm Log.**
- **System Status Enable.**
- **History Alarms.**

### Misc alarms

This page displays the status of miscellaneous alarms: the **2GHz Power**, **System Power**, **Communications Failure**, etc.

The following page buttons are also available:

- **Alarm Log.**
- **Misc Status Enable.**
- **Misc History Alarms.**

### Front Panel

This page shows the front panel status.

### Configuration

On this page, you can view and set the device configuration:

- **Network Setting**
- **Remote Configurations**
- **SNMP Settings**

Through two page buttons, **Trap Configuration.** and **Alarm Thresholds.**, you can configure the trap settings and the alarms thresholds.

### Web Interface

This page shows the device web interface.

A user name and password are required to access this page.

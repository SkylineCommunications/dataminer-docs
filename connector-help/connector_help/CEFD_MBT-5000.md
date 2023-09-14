---
uid: Connector_help_CEFD_MBT-5000
---

# CEFD MBT-5000

The **CEFD MBT-5000** is an SNMP-based protocol that is used to monitor and configure the **CEFD MBT-5000 Redundancy Controller**.

## About

The **Comtech EF Data (CEFD) MBT-5000** L-Band Up/Down Converter System provides frequency conversion between L-Band IF and C-/X-/Ku-Band RF frequencies. The **CEFD** **MBT-5000** connector can be used to monitor and configure this device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**: (already filled in)

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Extra configurations

There are a lot of extra settings that can be configured for this connector/device. These settings can be found on the connector's **Config** page. For more information about this page, refer to the **Usage** section below.

## Usage

### General

The **General** page displays most of the general information about the device. Some of the parameters that can be found on this page are for example: **Model Number**, **Software Revision**, **Part Number**, ...

The **Redundancy** **Switch** **Position** is also displayed on this page. This parameter displays which converter (A or B) is currently being used.
Below this parameter is a button that enables you to switch converters.

The most important alarms are also displayed on this page.

### Admin - Access

This page contains the network access settings. These settings can be grouped into 3 major components: **Ethernet, SNMP, Serial**.

### Config - MBT

The **Converters** page displays information about Converter A and B, as well as many configuration options for each converter.

It also displays if redundancy is enabled and what the current switch position is. These parameters can also be changed (R/W).

### Config - Utility

This **Config** page can be used to configure system device settings.

### Config - Redundancy

This page displays if redundancy is enabled and what the current switch position is. These parameters can also be changed (R/W).

### Status - Events

This page displays information about the events that happened on the device.

The page contains a table that displays all events and shows if there are currently any errors.

You can also clear the Stored Events on this page by clicking the **Clear All** button.

### Web Interface

This page can be used to access the actual web interface of the **CEFD MBT-5000**.

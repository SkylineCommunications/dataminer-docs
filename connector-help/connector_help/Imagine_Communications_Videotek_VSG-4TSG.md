---
uid: Connector_help_Imagine_Communications_Videotek_VSG-4TSG
---

# Imagine Communications Videotek VSG-4TSG

The Videotekr VSG-4TSG is part of the Imagine Communications Reference Sync and Timing platform, and is a «RU wide, 1RU tall and 12 inches deep 3G/HD/SD master timing generator. The unit is small in size, with redundant power supply inputs, and is low in power consumption and light in weight, making it a perfect fit for all broadcast television and post production environments.

## About

The following connector will be used in order to properly configure and monitor the Imagine Communications Videotek VSG-4TSG. This connector uses SNMPv2 protocol in order to poll from and configure data on the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | (Software Rev) 2.2          |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device. (default: 161)
- **Read Community**: The SNMP read community is used to poll data from the device. (default is public)
- **Write Community:** The SNMP write community is used to write data on the device. (default is public)

By default the device should have an Administrator, System and User community strings. The default community strings for each accounts are respectivly Vsg4TsgAdmin, Vsg4TsgSystem and Vsg4TsgUser.

## Usage

### General

The General Page displays generic information of the device.

### Sources

On the Sources Page the user will find a set of subpages that will contain configuration parameters related with the inputs such as **Phase Offset**, **Source Jam**, **PTP**, **NTP**, **GPS**, **LTC** and **VITC**.

### Output SDI General

This page contains configuration options for both **SDI 1** and **SDI 2** output interfaces. The user may configure the standard and format for each output. Depending on which configuration is selected for **SDI 1** and/or **SDI 2** a subset of pages will appear uppon which a user can configure in more detail the **format** and the **pattern** of a SDI output.

### Output PGM General

This page contains configuration options for both **PGM 1** and **PGM 2** output interfaces. The user may configure the standard and format for each output. Depending on which configuration is selected for **PGM 1** and/or **PGM 2** a page will appear uppon which a user can configure in more detail the **format** and the **pattern** of a PGM output.

### GPI

This pages contains information related with the **General Purpose Interface** (**GPI**).

### Unit Configuration

On this page the user may configure data related with the devices **Local Time**, **Front Panel**, **IP** and **DST**

### Time Source Status

This page contains all Time source related data for both primary and secondary sources.

### Input Status

This page contains all Input status data for **Local Time**, **NTP**, **LTC**, **GPS**, **PTP** and **VITC**.

### Output Status

This page contains all Output status data for **SDI**, **LTC**, **PGM**, **SYNC**, **ENET**.

### Leap Second

This page contains info related with the **Leap Second** feature also available on the Device UI.

### Alarms

This page displays information regarding the alarms that are present in the device.

An **Alarm Configuration** table is present to make it possible to configure the monitoring state and the severity of the alarms triggered by the device.

An **Active Alarms** table is present to display active alarms reported by the device.

### Web Interface

This page will display the web interface of the device's Microsoft Silverlight UI.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

---
uid: Connector_help_Novelsat_NS1000
---

# Novelsat NS1000

The NovelSat NS1000 Modulator delivers industry-leading data rates. A single unit covers the whole data range from 100 Kbps up to 365 Mbps using 70 Msym/sec transmission. The NS1000 features low bandwidth consumption, increasing satellite bandwidth efficiency by 30% to 60%, is highly versatile, with a single unit serving from 100 Kbps to 730 Mbps using existing bandwidth and has the smallest dish/HPA size, using the same data rates at remote locations.

## About

This SNMP connector can be used to monitor and configure the **Novelsat NS1000 Modulator** device.

### Version Info

| **Range**     | **Description**                                                                                                                                                  | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                                                                                                 | No                  | Yes                     |
| 1.0.1.x              | New range for firmware 1.1.1 (build 2592).                                                                                                                       | No                  | Yes                     |
| 1.0.2.x \[SLC main\] | New range because of a param Discreet Display change, change in layout for setting Datetime param, and datetime params changed from string to number (datetime). | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | U-Boot 2004.1051            |
| 1.0.2.x          | U-Boot 2004.1051            |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Main View

This page displays information about the device, including the modulator line settings, channel 1 settings and channel 2 settings.

The page also contains one page button, **MGMT Channel**, which allows you to configure the device channel settings.

### General

This page contains general information and settings:

- Ethernet communication settings, which can be configured.
- Serial communication settings, which can be configured.
- Clock source, which can be configured.
- Date and time.

There is also one page button, **Change Date and Time**, which allows you to configure the date and time of the device.

### Modulator

This page displays system information, such as the board temperature and clock source.

It also contains the following page buttons:

- **ACM Monitoring**: Displays the Modulator ACM (Adaptative Coding and Modulation) Table.
- **Ethernet Monitoring**: Displays the Modulator EthernetTable.
- **Interface Monitoring**: Displays the Modulator InterfaceTable.
- **Interface ASI Config**: Displays the Modulator Interface ASI Table, which can be configured.
- **Ethernet Interface Config**: Displays the Modulator Interface Ethernet Table, which can be configured.
- **Interface Test Config**: Displays the Modulator Interface Test Table, which can be configured.

### Line Settings

This page displays the modulator line settings of the device, such as **TX State**, **Line Mode**, **Line RF Frequency**, **Line Power**, etc.

### Channel Settings

This page displays the modulator channel settings for both channel 1 and channel 2, such as **Source**, **Frame size**, **Modulation**, **Stream Format**, etc.

### Alarms

This page displays the **Monitor Alarm Table**, which shows information regarding the system alarms, including the Date and Time, Severity, Source, Event and Description.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Revision History

DATE VERSION AUTHOR COMMENTS

08/03/2012 1.0.0.1 JVDW, Skyline Initial version

11/05/2012 1.0.0.2 JVDW, Skyline Added alarm and trending on Channel Modulation and FEC Rate

24/07/2012 1.0.1.1 JVDW, Skyline New range for firmware 1.1.1 (Build 2592)

31/05/2017 1.0.1.2 HTC, Skyline Added "MGMT Channel" page button

17/05/2018 1.0.1.3 RBL, Skyline Fix Set nsModConfigLineRFFreq - Modulator Line Frequency

17/07/2018 1.0.2.1 RBL, Skyline Fix MA FEC Rate param and use datetime for DateTime param

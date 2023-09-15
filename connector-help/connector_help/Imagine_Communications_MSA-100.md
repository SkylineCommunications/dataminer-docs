---
uid: Connector_help_Imagine_Communications_MSA-100
---

# Imagine Communications MSA-100

The new Multi-Source Analyzer (MSA) 100 from Imagine Communications offers a range of solutions that couple confidence monitoring with full testing of compressed video conformance, audio level, data services and TR-101-290 on any terrestrial broadcast, cable headend, satellite or telco network.

The MSA-100 delivers awareness of system information and ancillary data, with the ability to provide the conformance results in an intuitive user interface, along with one or more mosaic displays that provide real-time full-motion video decode and audio level analysis. A variety of physical input formats are supported, along with all major compression standards, a wide array of transport and streaming protocols, and the ability to simultaneously handle a large number of channels in real time.

## About

This connector contains different pages with information and settings. More detailed information on these can be found in the **Usage** section of this document.

The connector uses the SNMP protocol to communicate with the device. SNMP traps modify the severity of the events in the alarm table.

### Timing

All data gets retrieved from the device with the following timing:

- **Timers**:

- Identification parameters, every hour.
  - Virtual screens, every 5 minutes.
  - Source and programs, every minute.
  - Configuration data, every 10 minutes.
  - Alarm table, every 5 minutes.

- **Traps**: Traps can be sent to DataMiner whenever an alarm occurs and are used to update events in the alarm table.

### Version Info

| **Range** | **Description** | **DCP Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0                         |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains information related to the chassis of the MSA.

It also provides access to the **Resources** page, which contains information about the resources of the MSA chassis, such as the CPU and memory.

### Virtual Screens

This page contains a table with information on all the virtual screens under this chassis.

### Source and Programs

This page contains information on the sources and programs that are being monitored under this chassis.

### Configuration

This page displays information on the conformance settings. In addition, the information of the **status test settings** for each source is detailed in separate **ETR**, **Video** and **Audio (AES)** tables.

### Alarms

This page displays the active alarm events. You can also manage the polling frequency and filter time on this page.

### Log

This page contains information about events registered in the MSA. The information can be filtered based on a valid Source ID.

### History Data

This page contains two tables with information about events, one presenting the information grouped by month, the other listing events by the day of the month that is selected.

By default, the selected month is the current month, but a report for another month can also be selected.

Both the monthly table and the daily table display information for the current year.

---
uid: Connector_help_Gsertel_RCS400
---

# Gsertel RCS400

Gsertel's RCS400 DVB-T/T2 is a professional network monitoring platform that allows remote, proactive, simultaneous and real-time monitoring of up to 4 DVB-T/T2 digital television multiplex streams, both at RF and transport levels.

This connector can be used to monitor and control the device, as well as gather trend information.

## About

The connector uses an **SNMP** connection to communicate with the device.

### Version Info

| **Range**     | **Description**                   | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                  | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Column IDX in table 8200 changed. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 6.05                        |
| 1.0.1.x          | 6.05                        |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

## Usage

### General

This page contains all the device-related firmware information.

### Inputs

This page displays the **RF Measures**, **ASI Measures** and **IP Measures** tables.

In addition, it contains page buttons to the **Spectrum**, **Polling RF Measures**, **Constellation**, **Polling IP Measures** and **IP Channels** subpages, where you can find tables with further information.

### Services

This page contains the **Services**, **PCR** and **PID** tables. The Services table lists all the available service names and IDs.

### Transport Stream Alarms

This page contains the **Ts Test Failure**, **Service Alarm Config** and **Service Alarm Polling Status** tables

In addition, it contains page buttons to the subpages with the configuration and information for **First Priority Alarms**, **Second Priority Alarms** and **Third Priority Alarms**.

### Input Alarms

This page contains the **Alarm Summary** table, as well as page buttons to the following subpages:

- **RF Inputs**: Displays RF alarm information and advanced alarm information.
- **ASI Inputs**: Displays a table with information on the alarm polling status.
- **IP Inputs**: Displays IP-related alarm information.

### Web Interface

This page connects to the device web interface. However, note that the client machine has to be able to reach the device, as otherwise it will not be possible to open the web interface.

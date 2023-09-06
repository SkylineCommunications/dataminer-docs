---
uid: Connector_help_Advantech_Wireless_SBD75e_Demodulator
---

# Advantech Wireless SBD75e Demodulator

The Advantech Wireless SBD75e DVB-S/S2 Broadcast Receiver is designed for the reception and forwarding of digital television signals and/or transmission of high-speed data (IP) over Digital Video Broadcasting over Satellite (DVB-S/S2). The Advantech Wireless SBD75e Demodulator connector shows status information of the device and can be used to configure the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V 2.5.234              |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

This page displays the web interface of the device. The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **General** page of this connector, you can configure the datetime settings and view the chassis status information.

The **NTP Settings** page enables you to edit all NTP settings.

The **Demodulator Status** page displays the status of several demodulator properties and alarms used by the device itself.

The **Demodulator Monitor** page contains information about the demodulator. You can also configure the tuner frequency here.

On the **Polling Configuration** page, you can define the polling intervals for the following groups of parameters:

- **General**
- **General Board Temperature**
- **General Board Fan Speed**
- **General Chassis Alarm Status**
- **NTP Settings**
- **Demodulator Status**
- **Demodulator Alarm Status**
- **Demodulator Monitor**
- **Demodulator Monitor Temperature**
- **Demodulator Monitor Configuration**

All polling for these groups is enabled by default. In the **Polling Table**, you can configure the intervals in the **Time** column, enable or disable the polling in the **State** column, and poll a specific group on demand in the **Refresh on Demand** column.

---
uid: Connector_help_TeamCast_Vyper_DVBSS2_SNMP
---

# TeamCast Vyper DVBS/S2 SNMP

This connector retrieves information from a **DVB-S/DSNG/S2** modulator via **SNMP** and makes it possible to configure certain parameters.

## About

With the **TeamCast Vyper DVBS/S2 SNMP** connector, you can retrieve status information from a **TeamCast Vyper DVBS/S2** modulator and set configuration parameters.

### Version info

| **Range** | **Key Features**         | **Based on** | **System Impact**               |
|-----------|--------------------------|--------------|---------------------------------|
| 1.0.0.x   | Initial version          | \-           | \-                              |
| 1.1.0.x   | New firmware (see below) | 1.0.0.1      | Unknown                         |
| 1.2.0.x   | New firmware (see below) | 1.1.0.1      | Unknown.                        |
| 1.3.0.x   | New firmware (see below) | 1.1.0.1      | **Old trend data will be lost** |

### Product info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | S200                   |
| 1.1.0.x   | S100, S110             |
| 1.2.0.x   | S120                   |
| 1.3.0.x   | S132                   |

### System info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.2.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.3.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The IP address of the device, e.g. *194.206.71.180.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, e.g. *public.*
- **Set community string**: The community string used when setting values on the device, e.g. *private.*

## How to Use (1.0.0.x - 1.2.0.x)

### General

This page displays important information such as the device **temperature**, the selected **reference clock** and the **modulation type**.

There are also several page buttons that allow you to configure the device, retrieve software and hardware information, view the current state of a **firmware** update, and review and configure the **network configuration** of the control and data ports.

### Modulator

This page displays status information regarding the modulator: **frequency**, **output power**, **alarm mute status**, **bit rate**, **DVB-S2** and **DVB-S** configuration, etc. Several of these parameters can be edited.

### Status

This page displays global state information by indicating when **alarms** occur, etc.

### DVB-S2 Stream Configuration

On this page, you can configure the **input stream type**, as well as settings related to the chosen input stream type (single stream or multi stream).

## How to Use (1.3.0.x)

### Inputs

This page contains three page buttons that allow you to monitor and configure all inputs of the device and also configure the input related alarms.

### Outputs

This page contains three page buttons that allow you to monitor and configure all outputs of the device and also configure the output related alarms.

### General

This page displays important information such as the device **serial number, product type, hardware and software versions,** **temperature**, **hardware and software status.**

There are also several page buttons that allow you to monitor and configure several generic features of the device, namely **clock synchronization, ethernet, TSoIP, profile, carrier ID, dualcast, firmware update, temperature, relay, SNMP, time, log, license, power supply, GPS, redundancy** and **fan.**

### Modulator

In this page you can configure generic modulator configurations such as **standard** and **baudrate.** You can also go deep into **DVB-S, DVB-S2, DVB-S2X, BISS, pre-correction** and **NCR** configuration page buttons for more detailed configuration.

Also in this page you can monitor generic modulator parameter such as **ideal Es/No, Spectral Efficiency** and **ideal Eb/No.** You can also go deep into **multi-stream, DVB-S2X, BISS, pre-correction** and **NCR** monitoring page buttons for more detailed monitoring**.**

### Alarms

In this page you can monitor generic alarms status of the device such as **temperature status, hardware** and **software status**, **system clock status** and you can also go deep into **generic alarm configuration** page button to configure these alarms.

Also in this page you can configure and monitor all the input and output related alarms and some generic device related alarms such as **clock alarms, power supply alarms and fan alarms.**

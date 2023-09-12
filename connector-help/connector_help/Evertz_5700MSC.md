---
uid: Connector_help_Evertz_5700MSC
---

# Evertz 5700MSC

The 5700MSC-IP is an IP Network Grand Master Clock and a Video Master Sync Generator both referenced to GPS and/or GLONASS. The system features 2x GbE, 2x10 GbE ports, 6x fully timeable sync outputs, 4x SDI outputs and a loop-thru reference input.

This connector displays the status and controls of the generators and system information.

## About

### Version Info

| **Range**            | **Key Features**                                                                         | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                                                         | \-           | \-                |
| 1.1.0.x              | Trap/Syslog Table implementation; various display key and parameter description changes. | \-           | \-                |
| 1.1.1.x \[SLC Main\] | Changes to various display discrete values and position of columns.                      | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0 1289               |
| 1.1.0.x   | 1.0 1286               |
| 1.1.1.x   | 1.0 1286               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This driver uses a Simple Network Management Protocol (SNMP) connection to communicate with the device, and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The IP of the Evertz device.
- **IP port:** The IP port of the destination, by default *161*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### General

Contains the general device configuration, including the **GPS State, Glonass, Leap Time**, and **GPO 1 and 2.**

### Status

Displays device status parameters, including the **PTP State** table.

### Reference Control

Contains the configuration parameters for the reference controls, including the **Frequency**, **Time** and **VITC Line Time References.**

At the bottom of the page, you can find the **IP Servers** table.

### Sync Controls

Contains the **Sync Information** table, which can be used to configure the syncing of the device.

### Global

Contains global configuration parameters, primarily the **GPS, Video, 10 MHz, Free Run,** and **Payload Type** configuration.

### PTP Controls

Contains PTP controls. The **PTP Engines** table contains the engines configuration, while the **Acceptable Masters** table contains the configuration of acceptable master devices.

Via a page button, you can configure and view the **PTP Faults** table.

### NTP General

Contains the **Spoofing Control** and **NTP Information** table.

### TG Control

Allows you to configure the test generators. The main page includes the **Test Generator Controls** table and **Test Generator IP Table**, while the **TG Audio Controls** are available via a page button.

### LTC Control

Displays the **LTC Controls** table.

### Analog Audio

Allows you to configure the **Level Left, Level Right, Frequency Left,** and **Frequency Right.**

At the bottom of the page, you can find the **Analog Audio Events** table.

### AES DARS

Contains the DARS/AES configuration parameters, including the **Fine** and **Coarse Phase**, as well as the **Channel 1-3 Frequency and Levels.**

### Control and MGM Faults

Contains a table listing the **Control Faults** and **MGM Faults**.

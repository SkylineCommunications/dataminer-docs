---
uid: Connector_help_Meridian_II_Precision_TimeBase
---

# Meridian II Precision TimeBase

The Meridian II Precision TimeBase is a modular, network-centric, time and frequency standard module that provides precise and stable, GPS-synchronized time and frequency output.

### Version Info

| **Range**            | **Key Features**                                                            | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Implemented SNMP parameters for meridianGPS sub-tree (1.3.6.1.4.1.13827.10) | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination
- **IP port**: The IP port of the destination. Default value: *161*.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product. The web interface is not compatible with Internet Explorer.

## How to use

The element created using this driver consists of the data pages detailed below.

### General

This page displays system information, including the **System Time**, **System Description**, **System Location**, **System Contact**, **System Up Time** and other general parameters.

### Interfaces

This page displays information on the interfaces, such as the operational state and the traffic going through the interfaces.

### Storage

On this page, you can monitor the status of the storage (e.g. the size available per partition).

### NTP

This page displays all information related to the Network Time Protocol (NTP) module of the device.

### Receiver

This page contains information related to the GPS subsystem/receiver.

### Clock/Daylight Saving Time

This page contains the daylight saving time configuration for the Meridian II Precision TimeBase. It allows you to define when daylight saving time will start and end each year.

### Fault

This page lists all possible system faults of the device. The following types of faults are covered:

- Flash
- FPGA
- Signal
- DAC
- Antenna
- Polling Events
- Time Reference
- GPS Engine
- Primary Redundant Power Supply
- Secondary Redundant Power Supply

### Oscillator

This page displays the system oscillator control information for the GPS subsystem.

### CPU Options

This page displays information about the CPU options configured in the device.

### Plug-In Options

This page displays any installed plug-in modules and their settings.

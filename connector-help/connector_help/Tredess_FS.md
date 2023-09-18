---
uid: Connector_help_Tredess_FS
---

# Tredess FS

The Tredess FS connector can be used to configure and monitor a digital TV transmitter. This device is responsible for the correct functioning of terrestrial and satellite transmitters.

The connector retrieves and sets data via **SNMP**. If this is enabled on the device, **SNMP traps** can also be retrieved.

## About

### Version Info

| **Range** | **Key Features**                                 | **Based on** | **System Impact** |
|-----------|--------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version.                                 | \-           | \-                |
| 1.1.0.x   | Supports device software 01.V05.                 | \-           | \-                |
| 1.1.1.x   | SNMP connection replaced with SNMPv2 connection. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**              |
|-----------|-------------------------------------|
| 1.0.0.x   | 01.004                              |
| 1.1.0.x   | 01.V05 (MIB Revision 201806181005Z) |
| 1.1.1.x   | 02.V04 (MIB Revision 201811270849)  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: 10.145.1.35
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### System

This is the default page. It displays **general** information, including the **language**, **name**, **temperature**, **time sources (such as NTP)**, **general device information** and **settings**.

The following settings can be accessed via page buttons:

- **Network interfaces**: Configuration of the **remote interface** and **local interface**, and monitoring of the **link status**.
- **Web interface**: Configuration of the **auto-refresh** and the **passwords** for **users/admin**.
- **Event configuration**: Several tables where information from the individual **parts/interfaces** can be edited/monitored.
- **SNMP**: Configuration of the **agent**, including read/write community and **traps**.
- **Service**: Monitoring of the 3 **fans**, with the possibility to reset them with a **reset button**. Monitoring of the **DC power supply**, **calibration** and **reset** of the system.

### Polling Configuration

From version 1.1.1.4 onwards, a Polling Configuration page is available, where you can define the polling intervals for the following groups of parameters:

- **System**
- **Web Configuration**
- **Network Interfaces**
- **Software Update**
- **Service Slow**
- **Service Medium**
- **SNMP**
- **Alarm Configuration**
- **Event Configuration**
- **IO Interface Medium**
- **IO Interface Fast**
- **Hardware Basis**
- **Hardware Options**
- **Software Options**
- **Input**
- **Exciter RF**
- **IF Processor System**
- **IF Processor Echo Canceller**
- **IF Processor Precorrector**
- **Mute Configurations**
- **Exciter Modulator Slow**
- **Exciter Modulator Medium**
- **ISDB-T Configurations**
- **DVB-T2 Configurations**
- **DVB-T2 PLP Configurations**
- **DVB-T Configurations**
- **Reference**
- **Amplifier**
- **Status**
- **Input Status**
- **Modulator Status**

By default, polling for these groups is enabled, and the polling intervals for these groups are the same as in previous versions of the connector: 10 seconds for fast parameters, 1 minutes for medium parameters, and 1 hour for slow parameters.

In the **Polling Table**, you can configure the intervals in the **Time** column, enable or disable the polling in the **State** column, and poll a specific group on demand in the **Refresh on Demand** column.

### Input

This page is used for the configuration/monitoring of the **input switching** and **IP sockets**.

### Exciter RF

This page contains parameters for the configuration/monitoring of the **output frequency**.

### Exciter Modulator

This page contains information about the **modulator**, such as the **temperature**. The page also contains page buttons, which among others allow you to select the type and edit **DVB-T** settings.

### Reference

This page provides information about the **reference**. Here you can select which type of reference you want and the switching mode. In addition, information about the **synchronization module** is monitored.

### Amplifier

This page provides information about the **amplifier**, such as **configured power, forward and reverse power, thresholds, temperature**, and **transistor currents.**

### Redundancy

This page contains information about the **redundancy**. Several parameters are monitored, and it is also possible to edit the configuration of the **auto-verification**.

### Status

This page contains **status** parameters for the entire connector. The **status** parameters are polled and updated based on received **traps**.

### Web interface

This page displays the web interface of the device. The **address of the host/web UI** is the same as the polling IP of the element. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

There are several **known issues** in the device:

- The device returns **GENERIC_ERROR** when you try to set event configurations.
- Some parameters that are included in the MIB are not available on the device: **rfinput, echoCanceller, modLinearPrecorrection, modNonLinearPrecorrection, modEfficiencyImprovement, modClipping, modPrecorrectorLevels**, some parameters related to **synchronization**, and some **status parameters.**
- **Elevated Power Threshold** and **Reduced Power Threshold:** When a set is performed via the MIB, the device responds with a **bad value** **error**. When the set is performed via protocol, the device does not respond.

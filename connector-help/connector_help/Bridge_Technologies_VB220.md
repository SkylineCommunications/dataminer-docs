---
uid: Connector_help_Bridge_Technologies_VB220
---

# Bridge Technologies VB220

The VB220 IP-PROBE is a monitoring platform for applications in networks where digital video is carried across an IP infrastructure. It is built specifically for high-end industry needs and can monitor both pure IPTV networks and hybrid networks with IP transport cores, such as digital cable and terrestrial networks.

## About

This connector is used to collect data from the web interface of the device. This data is polled through HTTP commands sent via a serial connection.

The following modules are supported by the connector: VB120, 220, 330, 440, 252, 260, 262, and 273.
VB280 is supported in a separate version of the connector.

### Version Info

| **Range** | **Description**                                                                                                                                                                                                                                                                                                                                                                      | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Obsolete                                                                                                                                                                                                                                                                                                                                                                             |                     |                         |
| 2.0.0.x          | Obsolete                                                                                                                                                                                                                                                                                                                                                                             |                     |                         |
| 2.1.0.x          | Obsolete                                                                                                                                                                                                                                                                                                                                                                             |                     |                         |
| 3.0.0.x          | Obsolete                                                                                                                                                                                                                                                                                                                                                                             |                     |                         |
| 3.1.0.x          | Obsolete                                                                                                                                                                                                                                                                                                                                                                             |                     |                         |
| 3.2.0.x          | Obsolete -\> See 3.3.1.x.**Ethernet Streams Table** has a different primary key (decremented by 1) -\> Historical data for this table will be lost.**PID Info Polling** should be disabled if firmware \< 5.3. **RDP Version** should be set to *Version 1* if firmware \< 5.2; otherwise, it should be set to *Version 2*. **Ethernet Multicast Version** should be double-checked. | No                  | Yes                     |
| 3.2.1.x          | Obsolete -\> See 3.3.0.x.Added support for EII pidInfo call -\> no impact expected                                                                                                                                                                                                                                                                                                   | Yes                 | Yes                     |
| 3.3.0.x          | Obsolete -\> See 3.3.1.x. OTT Streams Table renamed to OTT Profiles -\> minor impact expected.                                                                                                                                                                                                                                                                                       | Yes                 | Yes                     |
| 3.3.1.x          | Obsolete -\> See 3.3.2.x. **PID Info Polling** should be disabled if firmware \< 5.3. **RDP Version** should be set to *Version 1* if firmware \< 5.2; otherwise, it should be set to *Version 2*. **Ethernet Multicast Version** should be double-checked.                                                                                                                          | Yes                 | Yes                     |
| 3.3.2.x          | Obsolete -\> See 3.3.3.x. Standalone "CPU Core 1-2 Usage" parameters were replaced by a table with all CPU cores.                                                                                                                                                                                                                                                                    | Yes                 | Yes                     |
| **3.3.3.x**      | **Main Range** Fixed PKs on Streams tables.                                                                                                                                                                                                                                                                                                                                          | **Yes**             | **Yes**                 |
| 4.1.0.x          | Obsolete -\> See 4.3.0.x.                                                                                                                                                                                                                                                                                                                                                            | No                  | Yes                     |
| 4.2.0.x          | Obsolete -\> See 4.3.0.x.                                                                                                                                                                                                                                                                                                                                                            | No                  | Yes                     |
| 4.3.0.x          | Specific version Only to be used if very accurate timing on alarms (history sets) is required.                                                                                                                                                                                                                                                                                       | No                  | Yes                     |
| 5.0.0.x          | Obsolete                                                                                                                                                                                                                                                                                                                                                                             |                     |                         |
| 6.0.0.x          | Obsolete Based on 3.2.0.X, but display keys use the naming options of before 3.2.0.67.                                                                                                                                                                                                                                                                                               | No                  | Yes                     |

### Product Info

The minimum required firmware version is **4.5**.

This is required in order to have the detailed ETR Data information.

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### Serial Xmldata Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

### Configuration (depending on firmware version)

Depending on the device firmware version, the **RDP** implementation is different.

By default, firmware versions below 5.2 are supported. In order to support firmware version 5.2 or later, the **RDP Version** parameter on the **RDP** page needs to be set to ***Version 2***.

## Usage

### General

This page contains general information and settings, including the **time zone**.

Via the **Configurations** page button, the following options are available:

- Enabling/disabling polling of **OTT**, **RDP**, **Redundancy**, **Media Window**, **Flash Alarms** and **L1** information.
- Enabling/disabling **Stream Severity Propagation** and **PID Severity Propagation**.
- The **Automatic Streams Removal** option can be used to remove missing rows.
- You can activate **Redundancy Polling**, in order to be able to use the **Redundancy** page.

It is possible to keep streams (Streams and Ethernet Streams Table), services and PIDs in DataMiner for a specific amount of time after they are no longer available in the device.
The **Automatic Streams Removal** can be set to the following options:

- **Remove Everything**: With this option, all streams, services and PIDs will be removed immediately.

- **Keep Streams (and check on Service Level)**: With this option, all streams will be kept for the configured amount of time (**Automatic Removal Delay**).
  The option Automatic Service Removal can be set to the following options:

- **Enabled**: All services and PIDs will be removed immediately.
  - **Disabled**: All services and PIDs will be kept for the configured amount of time.
  - **Set On Stream Level**: This setting can be configured on stream level in the **Streams Table**.

- **Keep Everything**: With this option, all streams, services and PIDs will be kept for the configured amount of time.

### Inputs

This page contains the **Inputs Table**, which consists of all **types of Input Streams.**

### Streams

This page contains the **Streams Table**, which consists of a more detailed view of all **input streams**. In addition, it also contains the **Ethernet Streams**, **QAM Streams**, **COFDM Streams** and **SAT Streams** tables.

There are also buttons available that allow you to normalize certain values.

Several page buttons are available:

- The **Ethernet Multicast** page button displays an overview of the **Ethernet multicasts**. Depending on the software version of the device, you can switch between two different types of **multicasts**.
- The **COFDM Tuning** page button displays an overview of the **COFDM Tuning Setups**.
- The **SAT Tuning** page button (in the **4.3.0.x connector range)**, displays the **SAT Tuning Setup** table, which allows you to **Add**, **Duplicate**, **Edit** and **Delete** SAT streams. To add a new SAT stream, right-click anywhere inside the table, select **Add Stream** and fill in all the fields in the pop-up window. To duplicate, edit or delete an SAT stream, right-click the **row (stream)** on which you want to perform the action, select the action you want to perform, and follow the ensuing steps.

### Services

This page displays the **services** that each **stream** consists of.

### PIDs

This page displays the **PIDs** contained in some **services**.

### Overview

This page contains the **tree view** from inputs to PIDs and is also the **default page**.

### IGMP

This page contains a table displaying all IGMP (version 2 or 3) messages detected by the probe. This includes IGMP **query messages** sent by routers, IGMP reply messages sent by the probe itself and IGMP reply messages sent by other probes and devices on the same subnet.

### Traffic

This page allows you to monitor IP traffic on the data/video port in terms of the protocols used.

### RDP

This page contains the **RDP** parameters. Depending on the device firmware version, the **RDP Version** parameter needs to be set to ***Version 1*** (for firmware version \< 5.2) or to ***Version 2*** (for firmware version \>= 5.2).

The **RDP Version 1** page button provides access to an overview of several status and metric parameters of RDP version 1.

### Thresholds

This page contains four tables: **Ethernet Threshold Presets**, **ETR Threshold Presets**, **PID Threshold Presets** and **Service Threshold Presets**.

### Redundancy

This page contains the **Redundancy** parameters for module VB273.

Note that in order to use these parameters, you need to enable **Redundancy Polling** on the **General** page.

### Import/Export

On this page, you can upload a new **Configuration** or **Firmware** version.

### OTT

On this page, the **OTT Table** is displayed.

It is possible to **automatically remove missing OTT entries** or to **remove single missing OTT entries.**

### Traps

On this page, the **traps alarms** are displayed.

### L1 for COFDM 1 - 4

These four pages provide an overview of several different status and statistic parameters for **COFDM 1 to 4**.

### Custom Statistics

This page contains custom statistics, such as **Sums**.

### Login

This page can be used to log in to have access to all features and write privileges, though by default there is no access control and all users have access to all features.

### Embedded Web Server

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **3.2.1.x** connector range of the Bridge Technologies VB220 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

Dynamic Interfaces

Virtual dynamic interfaces:

- Inputs: This is an interface for the virtual inputs (ASI, Ethernet, QAM, COFDM, SAT, VB252) of the device (**in**).

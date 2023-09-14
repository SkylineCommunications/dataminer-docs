---
uid: Connector_help_Harmonic_NSG_9000
---

# Harmonic NSG 9000

The Harmonic NSG (Network Services Gateway) 9000 is a universal high-density Edge QAM system that supports multiple applications and delivers up to 72 QAM-RF output streams.

## About

The number of delivered transport streams depends on the device configuration and the number of QAM-RF modules mounted in the slots of the device.

Each QAM may serve a different application, allowing a single device to concurrently support multiple applications.

### Version Info

| **Range**     | **Description**                           | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version                           | No                  | No                      |
| 2.0.0.x              | Customer-specific version for Unity Media | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 01.06.08.001                |
| 2.0.0.x          | 01.06.08.001                |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string:** The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

## Usage (Range 1.0.0.x)

### General

This page displays general information concerning the device and the **SNMP system.**

### Overview

This page displays the **Platform** tree, which shows the relationship between **Slots**, **RF Modules**, **RF Ports** and **QAM Channels**.

### Polling Configuration

On this page, you can **enable or disable the polling** for each table.

### Interfaces

This page displays a list of interface entries, with the management information for each interface.

### Slots

This page contains tables with information regarding the **Slots** and their **Card Presence Alarms**.

### Modules

This page contains information about **RF Modules** and the corresponding alarms.

### Ports

This page displays the **RF Ports** table and the **RF Ports Alarms** table, which also contains network data.

### Channels

This page contains information about **QAM Channels** and the corresponding alarms.

### QAMs

This page displays a table with the status of each **QAM Channel**.

### QAMs Config

This page contains tables with information regarding the **QAMs Channel Common** and the **QAMs Config**.

### Platform Alarms

This page displays the status of the **Platform** as well as the port link for the **GbE RJ45** and the **GbE SFP**.

### Digital Alarms

This page displays a table with information on the **Digital Alarms**.

### Web Interface

On this page, you can access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (Range 2.0.0.x)

### General

This page contains general information about the device. It displays the **System Description**, **System Name**, **System Location** and **System Contact**.

### Interfaces

This page contains information on the interfaces of the Arris E6000 device.

The **Interface Table** shows information for each interface, such as the **Description**, **Type**, **MTU**, **Speed**, **Physical Address**, status information (**Admin Status** and **Operational Status**), information about errors and discarded packets (**Inbound Discards**, **Inbound Errors**, **Outbound Discards**, **Outbound Errors**) and interface utilization (**Utilization In** and **Utilization Out**).

The page displays the **Number of Displayed Interfaces**, i.e. the number of interfaces that are currently being displayed in the table.

Via the **Interface Selection page button**, you can configure which interfaces will be displayed in the Interface Table:

- You can filter the interfaces that are displayed by specifying a **Description Filter** and **Type Filter**, and clicking the **Enable/Disable** button.
- You can enable or disable displaying particular interfaces with the toggle button in the **Displayed** column of the **Interface Selection Table**.

### QAMs

This page contains two tables, the **QAM Channel** table and the **QAM Channel Common** table, which both use the **QAM Channel Description** as an identifier.

- The **QAM Channel** table contains specific information per QAM channel.
- The **QAM Channel Common** table displays the **bandwidth**, **utilization** and **bitrate** values per QAM channel.

### RF Ports

This page contains the **RF Port Table**, which displays an aggregation of bandwidth, utilization and bitrate values of all QAM channels per RF port.

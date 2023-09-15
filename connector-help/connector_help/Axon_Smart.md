---
uid: Connector_help_Axon_Smart
---

# Axon SMART

The Axon SMART monitors, reports and analyzes live transport streams. This connector can be used to monitor this device.

## About

This connector monitors the state of each of the transport streams. The connector uses **SNMP** and **DCF** integration.

### Version Info

| **Range**     | **Description**                                         | **DCF Integration** | **Cassandra Compliant** |
|----------------------|---------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                                         | Yes                 | Yes                     |
| 1.0.1.X \[SLC Main\] | Auto clear functionality for TS, Service and PID tables | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Version 2.3.0.21            |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## Usage

### General

This page displays general information about the device, such as the **Product Name**, **Product Version**, **OS Version** and **RAM Usage**.

### Tree View

This page contains an overview of all transport streams, services and components.

### TS Overview

This page displays the **Transport Stream Table**, which contains a list of the transport streams on the device.

### Service Overview

This page displays the **Service Table**, which lists the services of each transport stream.

### PID Overview

This page displays the **PID Table**, which contains a list of the components of each transport stream.

### Alarms

This page contains the **Alarm Overview Table**, which displays the alarms present in each transport stream.

### ETR290

This page contains three tables: **ERT290 Priority 1**, **ERT290 Priority 2** and **ERT290 Priority 3**.

These tables contain the errors of each transport stream, separated by priority.

### Alarm Presets

On this page, the **Alarm Presets** table displays a list of the presets. You can **add or delete** presets from this list manually using the table's **right-click** **menu**.

Alternatively, you can also import and export a CSV file to update the table. The **Import/Export Status** displays the status of this operation. The list of CSV files that can be imported is in the **Configurations** folder. An exported CSV file will be stored in the generic DataMiner Documents folder, in a subfolder with the name **Configurations**. The **Refresh** button will refresh the CSV file list and the alarm presets displayed in the table columns.

> [!NOTE]
> In version 1.0.0.9, the file type is changed from CSV to XML.

Once an alarm preset has been assigned to a certain TS, Service or PID, this preset name can be used as a filter when creating alarm templates in DataMiner. This way, different thresholds can be configured for one and the same parameter (e.g. PID bitrate), depending on the selected alarm preset filter.

### Debug

This page displays the **Traps** table, where all the received traps are retrieved, as a debug option for the connector. It also allows you to define the source IP address sending the traps.

### Web Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

### DataMiner Connectivity Framework

This connector does not make any connections, but it does have interfaces.

### Interfaces

The dynamic interfaces are created based on the number of rows in **Table 73 Transport Stream Table (DCF Input Interfaces).**

**Table 73** will contain all the DCF input interfaces. The total number of rows depends on the number of rows in **Table 73 (Transport Stream Table)**.

- **TS ASI\_***instance value*\_*Interface Type*: dynamic interface with type **in**.
- **TS IP\_***instance value*\_*Interface Type*: dynamic interface with type **in**

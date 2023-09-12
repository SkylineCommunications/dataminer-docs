---
uid: Connector_help_Thales_TNM-7122-D
---

# Thales TNM-7122-D

This is an SNMP driver that can be used to monitor and configure Thales TNM-7122-D equipment.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                    | **Based on** | **System Impact**                                                                                                                                                                                                                                                                          |
|----------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Development version.                                                                                                                                                                | \-           | \-                                                                                                                                                                                                                                                                                         |
| 1.1.0.x \[Obsolete\] | Development version.                                                                                                                                                                | \-           | \-                                                                                                                                                                                                                                                                                         |
| 1.0.5.x              | Limited driver version for units with firmware version 01.05x.xx.                                                                                                                   | \-           | \-                                                                                                                                                                                                                                                                                         |
| 2.0.0.x              | Initial release range.                                                                                                                                                              | \-           | \-                                                                                                                                                                                                                                                                                         |
| 2.0.1.x \[SLC Main\] | Initial release range with fix to avoid overwritten active alarms caused by the device itself.                                                                                      | 2.0.0.x      | The Active Alarms table with PID 6000 is no longer available. Its data will now be shown in a new Active Alarms table with PID 6500. This table has a new primary key and display key. The primary key is the hashed concatenation of the module, the input, the description and the date. |
| 3.0.0.x \[Obsolete\] | SNMP2 version based on range 2.0.0.x. This range is no longer maintained, as it is now possible to select the SNMP version in the element configuration. Use range 2.0.1.x instead. | 2.0.0.x      | \-                                                                                                                                                                                                                                                                                         |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.1.0.x   | \-                     |
| 1.0.5.x   | 01.05x.xx              |
| 2.0.0.x   | \-                     |
| 2.0.1.x   | \-                     |
| 3.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.5.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 3.0.0x    | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public.*
- **Set community string**: The community string used when setting values on the device, by default *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element consists of the data pages detailed below.

### General

This page displays general information such as the Vendor and Serial Number. Via page buttons, you can access subpages related to **Equipment Features** and configurable **Relays**.

### Inputs-Outputs

This page displays the Switch State, Input 1, Input 2 and Output status.

### Tests Level 1/2/3/Advanced

These pages contain tables with test information.

### Streams

This page displays information on the transport streams.

### Services

This page displays information on **Services** and **Services Checks**.

### PIDs

This page contains information on PIDs. It also allows you to **Confirm all PIDs** and **Remove N/A PIDs**. Via page buttons, you can access the **PIDs Bandwidth** and **PIDs in Service** subpages

### Overview

This page contains a tree control that displays information about inputs.

### Output Streams

This page displays information on the output transport streams.

### Output Services

This page displays information on output services. You can remove services that are no longer available.

### Output PIDs

This page displays information on output PIDs. It also allows you to **Confirm all PIDs** or **Remove N/A PIDs**. Via page buttons, you can access the **Output PIDs Bandwidth** and **Output PIDs in Service** subpages.

### Output Overview

This page contains a tree control with information about outputs.

### Alarms

This page displays the **Active Alarms** and **Closed Alarms** tables.

### Configurations

This page displays configuration version information. You can retrieve a configuration from the list of available configurations. This will display the information related to Smart Switcher, System and Inputs configuration.

Via page buttons, you can access the following subpages:

- **System**: Displays various system configuration parameters.
- **Input**: Displays the Input Configuration table.
- **Smart Switcher**: Displays various smart switcher configuration parameters.

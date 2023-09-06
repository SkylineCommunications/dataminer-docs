---
uid: Connector_help_2WCOM_DAB-4c
---

# 2WCOM DAB-4c

This is a DataMiner connector for the 2WCOM DAB-4c, a converter device that can be used to receive data signals from legacy ETI and EDI multiplexers while simultaneously converting the signals to EDI/ETI transmitters.

## About

### Version Info

| **Range**            | **Key Features**                                                                                   | **Based on** | **System Impact**                                                                                                                                            |
|----------------------|----------------------------------------------------------------------------------------------------|--------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version                                                                                    | \-           | \-                                                                                                                                                           |
| 1.1.0.x              | New firmware (V0.9)                                                                                | 1.0.0.x      | \-                                                                                                                                                           |
| 1.2.0.x              | New firmware (V2.0)                                                                                | 1.1.0.x      | \-                                                                                                                                                           |
| 1.2.1.x              | Various improvements                                                                               | 1.2.0.x      | The description of the SNMP column and the column display order of the table has changed, which can affect existing visual overviews and Automation scripts. |
| 1.2.2.x \[SLC Main\] | Mutiple new tables and parameters have been added in the driver according to the newest MIB (V2.5) | 1.2.1.x      | Page names have been changed, which can affect existing visual overviews                                                                                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Firmware V0.6          |
| 1.1.0.x   | Firmware V0.9          |
| 1.2.0.x   | Firmware V2.0          |
| 1.2.1.x   | Firmware V2.0          |
| 1.2.2.x   | Firmware V2.3          |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.2.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.2.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.2.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General

On this page, you can monitor and configure the system's **Name**, **Location** and **Contact**. You can also monitor details related to the hardware and software versions running on the device.

The page contains page buttons to the following subpages:

- **Details**: Displays additional details related to the device.
- **Diagnostic**: Allows you to configure and monitor the Diagnostic Report module.
- **Licensing**: Displays detailed information about the licensing of the device.
- **Settings**: Allows you to configure additional global device settings.

### Interfaces

This page provides all information about the available interfaces.

### Converter Overview

This page displays an overview of the available converters in the **Converter Overview** table, as well as the **EDI-EDI** or **ETI-EDI Outputs** status.

### Input Sources

This page displays an overview of the Input and Output Sources.

### GPI

This page displays the state of the GPI interfaces and allows you to **Switch Sources** or **Invert Masks** of each interface.

### GPO

This page displays the state of the GPO interfaces and allows you to **Switch Sources** of each interface.

### Network

This page contains the general configuration of the **CTRL**, **Data 1**, **Data 2** and **Ember** interfaces.

The page contains page buttons to the following subpages:

- **LAN CTRL**: Contains the parameters related to the configuration of the CTRL interface.
- **LAN**: Allows you to configure **LAN** **CTRL**, built-in device alarm monitoring conditions.
- **Data 1**: Contains the parameters related to the configuration of the Data 1 interface.
- **Data 2**: Contains the parameters related to the configuration of the Data 2 interface.

### DNS

This page allows you to monitor the **DNS Server Configuration.**

### SNMP

On this page, you can monitor and configure **SNMP settings**, as well as the SNMP trap servers.

### Time

This page contains the **NTP Configuration** and **Timezone** configuration.

Via the **External NTP** page button, you can configure built-in device alarm monitoring conditions for **external clock NTP** and **NTP Calibration**.

Via the **NTP** page button, you can configure built-in device alarm monitoring conditions for **System NTP**.

### User

On this page, you can configure user accounts and the access to these accounts.

### Device Hardware

This page provides an overview of the device status, including the **CPU/Device Temperature**, **CPU Load** and **Power Supply Unit Parameters**, along with other generic monitoring parameters.

- **PSU**: Allows you to configure **PSU 1** and **PSU 2** built-in device alarm monitoring conditions.
- **Temp**: Allows you to configure **Temp** built-in device alarm monitoring conditions.

### Converter Alarms

This page displays the built-in device alarm states for **Converters Packet Loss Rate (PLR)** and **Output Errors**.

It also contains page buttons to subpages where these alarms can be configured:

- **EDI Input 1**: Allows you to configure **EDI Input 1** built-in device alarm monitoring conditions for each **converter**.
- **EDI Input 2**: Allows you to configure **EDI Input 2** built-in device alarm monitoring conditions for each **converter**.
- **ETI Inputs**: Allows you to configure **ETI Input** built-in device alarm monitoring conditions for each **ETI Input**.
- **Inputs**: Allows you to configure **Inputs** built-in device alarm monitoring conditions for each **Converter Input, EDI to EDI2 Input and ETI to EDI 2 Inputs**.
- **ETI Outputs**: Allows you to configure **ETI Output Error** built-in device alarm monitoring conditions for each **ETI output**.

### Log

This page displays the configuration of the built-in device system log.

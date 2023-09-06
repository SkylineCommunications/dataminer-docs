---
uid: Connector_help_RAD_Data_Communications_LA-210
---

# RAD Data Communications LA-210

This driver can be used to monitor RAD LA-210 switches via SNMP.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                              | **Based on** | **System Impact**                                                                                                     |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-----------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | SNMP monitoring.                                                                                                                                              | \-           | \-                                                                                                                    |
| 1.0.1.x \[Obsolete\] | DCF integration.                                                                                                                                              | 1.0.0.3      | Added DCF.                                                                                                            |
| 1.0.2.x \[SLC Main\] | Conditional monitoring of alarms and CFM table. Added in/out discard rates for interface table and forward green/yellow packets for Service Statistics table. | 1.0.1.1      | Impact on custom reports or scripts calling Service Statistics or Interfaces table IDX or displayed columns directly. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.72 - ...             |
| 1.0.1.x   | 2.72 - ...             |
| 1.0.2.x   | 2.72 - ...             |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

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

The element created with this driver consists of the data pages detailed below.

### General

This page contains general information about the device, such as the **System Uptime**. On the **System** and **Physical Entities** subpages, you can find further information about system parameters and software versions.

### Interfaces

This page contains a list of all the device interfaces. When a lot of interfaces are available, you can filter the list to reduce SNMP load via the subpage **Interface Filtering**.

By default, the filter is empty, which means that the whole table will be polled. If you manually add entries to the filter, the table will only poll those specific entries.

### Services

This page shows a list of services on the device, with information about bit rates and discard rates for each service.

### Flow

This page contains a table that lists the flows in the device. By default, this table will poll nothing. You can set up polling by adding regex filters on the **Flow Table Filter** subpage. The table will only poll entries for which the flow name matches one of the regex filters. Multiple regex filters can be imported at the same time in a .txt file, containing one regex filter per line.

### Traps

This page lists **Trap Destinations** with the corresponding settings.

### Connectivity Fault Management

This page contains multiple tables regarding CFM on the device.

You can enable or disable CFM polling by toggling the **Connectivity Fault Management** **Polling** option. Polling is enabled by default.

### Alarms

This page shows a list of the current alarms on the device. On the **Alarm Generation** subpage, you can find customization options for alarm generation.

You can enable or disable alarm polling by toggling the **System Buffer Alarm Polling** option. Polling is enabled by default.

### Web Interface

This page displays the web interface of the device. However, note that you can only access this if the client machine has network access to the device.

### DCF

This page contains a list of DCF physical interfaces based on the list of device interfaces on the **Interfaces** page. These are the interfaces of type Ethernet CSMACD and SHDSL.

By default, the DCF Table keeps all the interfaces it received even after they have been removed; however, if the filter from the **Interface Filtering** subpage is used, it will also affect the interfaces available to DCF.

Activating or deactivating filter mode will disconnect all DCF connections.

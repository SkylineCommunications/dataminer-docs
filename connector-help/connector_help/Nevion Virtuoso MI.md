---
uid: Connector_help_Nevion_Virtuoso_MI
---

# Nevion Virtuoso MI

This is a DataMiner connector for the Nevion Virtuoso MI, a media server designed for broadcast carrier-class applications. The connector uses an HTTP connection to allow monitoring of the Nevion Virtuoso MI.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                              | **Based on** | **System Impact**                                                                         |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                                                                                              | \-           | \-                                                                                        |
| 1.0.1.x \[SLC Main\] | SNMP traps implemented.                                                                                                                       | 1.0.0.1      | Existing elements need to be reconfigured before the new connection will be taken in use. |
| 1.1.0.x \[Obsolete\] | Support added for firmware using TXP communication. Refer to the [Nevion Virtuoso FA](https://catalog.dataminer.services/result/driver/8342). | \-           | Most parameters present in previous ranges do not exist in this range.                    |
| 1.1.1.x \[Obsolete\] | Communication using TXP. Refer to the [Nevion Virtuoso FA](https://catalog.dataminer.services/result/driver/8342).                            | 1.1.0.2      | Adding parameters and tables.                                                             |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.2.14                 |
| 1.0.1.x   | 1.2.14                 |
| 1.1.0.x   | 2.10.8                 |
| 1.1.1.1   | 2.10.8                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (fixed value: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

### Initialization

To make sure the connector can retrieve data, fill in the **Login Credentials** of the device on the **Settings** page.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element using this connector consists of the data pages detailed below.

### General

This page displays basic information about the device, e.g. **Device Name**, **Software Version**.

The page also contains page buttons to several subpages:

- **Frames**: Lists cards and ports. You can change the mode in the Ports table if the type of the slot is ASI.
- **Slots**: Contains the information of the slots in the device.
- **Licenses**: Contains all license information of the device.

### IP Interfaces

This page displays the types of IP interfaces and their labels, e.g. **Description**, **Label**.

In the **State** column, you can enable or disable the IP interface.

### Ethernet

This page displays Ethernet information related to the device, e.g. **MAC Address**, **RX Bitrate**, **TX Bitrate**.

In the **State** column, you can enable or disable Ethernet.

The page also contains page buttons to the following subpages:

- **Routing**: Lists receiver and transmitter routing information.
- **Status**: Contains status information related to receiving and transmitting, and the errors that might be in the device.
- **Sync Input**: Contains all information regarding Ethernet reference sync input and input routing.

### ASI Input

This page displays tables with information about the ASI input, e.g. **Routing**, **Stream**.

You can configure the values in the Label and Enabled columns in the ASI Input table.

### ASI Output

This page displays information about the ASI output, e.g. **Description**, **Stream Mode**.

You can configure the TS Mode and Advanced Monitoring columns with a dropdown box and toggle button, respectively.

### IP Input

This page displays general information about the SIPS configuration and status, e.g. **Speed/Duplex Mode**, **Top Severity**.

The values in all the columns except the instance column of the table SIPS configuration can be changed. With the dropdown box in the Expected Lagging Flow and Preferred Flow columns, you can select the values *Auto*, *A*, and *B*.

The page also contains page buttons to the following subpages:

- **Flow A**: Displays status information of the Flow A. The last columns to the right can be changed as desired.
- **Flow B**: Displays status information of the Flow B. The last columns to the right can be changed as desired.
- **FEC**: Displays information regarding the FEC of the device.
- **Buffer Regulator:** Displays information about the buffer regulator, e.g. **Utilization,** **Size.**

### TS input Switch

This page displays tables with information regarding the transport input switch, e.g. **TS Input Switch**, **Ts Switch Inputs**.

### Transport Streams

This page displays information for each IP input. You can also configure information like the state, source filter, and log IP statistics. The information is organized in tables, e.g. **TS IP Inputs**, **TS IP Outputs**.

### Services

This page displays information about the services present in the device., e.g. **Service Name**, **Total Rate**.

### Alarms

This page displays information about the alarms in the device, e.g. **Severity,** **Description**.

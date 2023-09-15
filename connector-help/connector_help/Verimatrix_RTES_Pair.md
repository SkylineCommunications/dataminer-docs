---
uid: Connector_help_Verimatrix_RTES_Pair
---

# Verimatrix RTES Pair

With this connector, you can monitor a redundant pair of **Verimatrix RTES** devices using SNMP.

## About

The Verimatrix RTES Pair connector monitors a redundant pair of Verimatrix RTES devices. The **two SNMP connections** are used to connect to the two RTES devices. Through **HTTP SOAP** communication, the connector also allows the user to retrieve the names of the channels that are described in a database.

### Version Info

| **Range** | **Description**                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                           | Yes                 | Yes                     |
| 2.0.0.x          | Branch version based on 1.0.0.x           | Yes                 | Yes                     |
| 2.0.1.x          | New firmware based on 2.0.1.x (see below) | Yes                 | Yes                     |
| 2.0.2.x          | Change of index in retrieved tables       | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |
| 2.0.1.x          | Unknown                     |
| 2.0.2.x          | Unknown                     |

### Exported connectors

| **Exported Connector**                                                                | **Description**                       |
|--------------------------------------------------------------------------------------|---------------------------------------|
| [Verimatrix RTES Pair - DVE](xref:Connector_help_Verimatrix_RTES_Pair_-_DVE) | 2 DVE elements, primary and secondary |

## Installation and configuration

### Creation

The **Verimatrix RTES Pair** has two SNMP connections. The first is to connect to the **A RTES** device, the second to connect to the **B RTES** device. The IP for those connections needs to be configured during creation of the element. The **Verimatrix RTES Pair** also has an HTTP connection. The hostname and port of the SOAP interface need to be configured during creation of the element.

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the main device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

**SNMP2 CONNECTION**:

- **IP address/host**: The polling IP of the secondary device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

**HTTP CONNECTION**:

- **Type of port**: TCP/IP.
- **IP address/hostname**: The IP of the SOAP interface, e.g. *10.11.12.13.*.
- **IP Port**: The IP port of the SOAP interface, e.g. *10.11.12.13.*.

## Usage

### General Page

This page displays general information and system information on both devices.

### Stream Settings Page

On this page, you can configure the type of stream, and configure some key values, such as the **Minimum Rate**, **Maximum Rate** and **Weight Factor**.

### Channel Performance Page

This page contains tables with information on the channels of each RTES device.

In addition, the **Channel Names** page button opens a window where you can get the channel names. These are retrieved using a query on an Oracle database. To retrieve the channel names, you need to specify the IP of the database, the instance of the table, the username and the password.

### Channel Health Page

This page contains a table with the bit rate of each channel for both devices, and shows whether the channel bitrate is between the **Minimum** and **Maximum Rate** defined on the **Stream Settings** page for that type of stream.

The page also includes information about the communication status of each device, and a parameter that indicates which is the preferred device.

### SNMP Pages

This page contains two tables, which display the RTE indexes.

### RTES

This page contains the **RTES Table**, listing the RTES devices.

---
uid: Connector_help_ETL_Systems_NGMC-21
---

# ETL Systems NGMC-21

This connector displays information related to the ETL Systems NGMC-21 combining matrix.

The connector uses two interfaces to communicate with the NGMC-21 device. The SNMP interface is used to retrieve information regarding the chassis (temperature, fan status, etc.) and also for the input and output card tables. The serial interface is used to execute the remaining commands related to the matrix.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | E240 Version 3.5       |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SERIAL main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during the creation of the element:

SERIAL CONNECTION:

- **Type of port:** TCP/IP.
- **IP address/host**: The polling IP or URL of the destination, e.g. *10145.1.12*.
- **IP port**: The port of the destination, e.g. 1*3000*.
- **Timeout of a single command:** 2500 ms (minimum).

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during the creation of the element:

SNMP CONNECTION:

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.
- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

The element created with this connector consists of the data pages detailed below.

### Main View

This page contains the device matrix. At the top, two buttons are available that allow you to **Undo** changes and **Reset Labels**.

### General

This page displays generic parameters, such as **Version**, **Number of Modules**, **Matrix Size**, etc. A subpage contains **Polling IP Config** parameters.

### Status

This page contains two SNMP-polled tables, the **Input** and **Output Card Status Table**. The status information in these tables cannot be edited, but can be used for monitoring and trending.

### Alarm

This page contains the SNMP-polled **Chassis Status Table**. This table contains the device status, such as temperatures, fan speeds, and communication state.

There are also a number of overall status parameters for the **Master PSU**, **Master PSU2**, **Master Communication Link** and **Master Summary Alarm**. Alarm monitoring can be enabled for these parameters.

### Configuration

This page allows you to update the matrix size. To do so, update the **Matrix Inputs** and **Matrix Outputs** parameters, and then click the **Change Size** button.

### Web Interface

This is a direct link to the web interface of this combining matrix. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

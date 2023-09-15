---
uid: Connector_help_Pro-Bel_SW-P-02
---

# Pro-Bel SW-P-02

The Pro-Bel SW-P-02 protocol provides an interface to set or remove audio connections in the output routing of a controlled device from remote devices.

## About

This protocol can be used to monitor and control any router that supports the Pro-Bel SW-P-02 protocol. A TCP/IP connection is used in order to successfully retrieve and configure the matrix. An SNMP connection is used for the PSU and FAN information of the device.

A matrix is used in order to easily connect a destination with a source.

### Version Info

| **Range** | **Description**                                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial range. Serial interface.                    | No                  | Yes                     |
| 2.0.0.x          | Based on 1.0.0.1. Smart-serial interface.           | No                  | Yes                     |
| 2.1.0.x          | Based on 2.0.0.2. Smart-serial and SNMP interfaces. | No                  | Yes                     |

## Installation and configuration

### Creation

#### Serial connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL connection:

- **Type of port:** The type of port of the connection, by default *TCP/IP*.
- **IP address/host**: The polling IP of the device.
- **IP port:** The IP port of the connection device.
- **Bus address:** The "NumberOfInputs" and "NumberOfOutputs" of the matrix separated by a "." (range of inputs and outputs: 1-1024). For instance: "*1024.1024*".

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP connection:

- **IP address/host**: The polling IP of the device.
- **Port number:** The port of the connection device, by default *161*.
- **Get community string:** The community string needed to read from the device. The default value is *public*.

## Usage

### Matrix

This page contains the matrix, sized according to the **Number of Inputs** and **Number of Outputs** specified during configuration.

### Device

This page contains the **PSU** and **FAN** fault tables of the device.

### Configuration

This page contains the following parameters:

- **Router Connection:** Displays the status (*Responding* or *Not Responding*) of the router's connection.
- **Matrix Configuration:** Displays any detected misconfigurations. The status **OK** indicates that the matrix was successfully configured.
- **Number of Inputs:** Displays the selected number of inputs for the matrix.
- **Number of Outputs:** Displays the selected number of outputs for the matrix.
- **Router Type:** Displays the type of the router.
- **Matrix Polling:** Enables or disables the polling of the matrix information.
- **Refresh CrossPoints:** Manually refreshes the entire matrix.
- **Device Polling:** Enables or disables the polling of the PSU and FAN fault tables.
- **Refresh PSU and FAN:** Manually refreshes the PSU and FAN fault tables.

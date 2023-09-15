---
uid: Connector_help_NEC_N+1_Control_HPC-1358D
---

# NEC N+1 Control HPC-1358D

The NEC N+1 Control HPC-1358 is a transmitter controller that can be used to manage transmitters in an N+1 redundancy setup. Each transmitter (DTU) is responsible for the distribution of TV signals. This device can carry different types of transmitters, displaying their status and performing redundancy among them.

## About

This connector can be used to monitor and control the NEC N+1 Control HPC-1358D transmitter controller via an **SNMP** connection.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.1.3                       |

### Exported connectors

| **Exported Connector** | **Description**                      |
|-----------------------|--------------------------------------|
| Main Transmitter      | Represents the mux transmitters.     |
| Reserve Transmitter   | Represents the reserve transmitters. |

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

## Usage

### General

This page contains general information related to the device, such as the **System Description**, **Object ID**, **Up Time**, **Contact**, **Name** and **Location**.

### N+1 Page

This page displays the **Control Operation Mode**, **Auto Change State**, **ASI Switch Status**, **CPU Alarm**, **PSA Status**, **PSB Status**, **Mux Number**, **Control Mode Selector**, **Mux Control** and **Mux Reset Control**.

It also contains a subpage with the **Enable/Disable Traps** functionality for the N+1 parameters.

### Reserve Transmitters

This page contains the **Reserve Transmitters Table**, which displays the **Name**, **Status Detection**, **Output Connection Route**, **ASI Input**, **Operation Mode**, **Ready State**, **Alarm State**, **Fault State**, **Communication State**, **ASI Input Control**, **ON/OFF Control** and **Reset Control**. On this page, the DVEs for each of the reserve transmitters can be created.

### Main Transmitters

This page contains the **Main Transmitters Table**, which displays the **Name**, **Status Detection**, **Output Connection Route**, **Operation State**, **Operation Mode**, **Coaxial Switch Fault**, **Alarm Status**, **Fault Status**, **Tx Channel**, **Priority Antenna Status**, **ON/OFF Control** and **Reset Control**. On this page, the DVEs for each of the main transmitters can be created.

### Embedded Web Server

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

### Notes

For the current version of the connector, the traps for the main transmitter could not be generated on the device, and as such could not be properly tested. For this reason, main transmitter traps are currently not yet included in the connector.

---
uid: Connector_help_Tandberg_MEM_General
---

# Tandberg MEM General

The **Tandberg MEM General** is a Multiplex Element Manager, which controls **Evolution 5000 compression equipment**.

## About

The connector polls the device via **SNMPv2** calls. **Traps** are not implemented.

### Version Info

| **Range**     | **Description**                                                                                   | **DCF Integration** | **Cassandra Compliant** |
|----------------------|---------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version                                                                                   | No                  | Yes                     |
| 1.1.0.x \[SLC Main\] | Complete redesign to meet the current standards (2005 style tables, etc.) | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.32 Rev1                   |
| 1.1.0.x          | 4.13                        |

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains general information about the device, such as the **Product Name**, **MIB** version and **Administrative State**.

### Streams

This page contains the **Streams Table**, with information such as the **Multiplexer Stream Output** and **Active Multipler**.

### Mux

This page contains the **Mux Table**, with information such as the **Health Status**, **Communications Status** and **Availability**.

### Modulator

This page contains the **Modulator Table**, with information such as the **Health Status**, **Communications Status** and **Availability**.

### Encoder

This page contains the **Encoder Table**, with information such as the **Type**, **Health Status**, **Availability** and **Description**.

### Module (1/2)

This page contains the following tables:

- **BMI Table**: Displays the **Health Status** and **Description**.
- **Video Table**: Displays the **Health Status**, **Availability** and **Description**.
- **Audio Table**: Displays the **Health Status**, **Availability** and **Description**.

### Module (2/2)

This page contains the **Sync Table**, the **Async Table** and the **Text Table**, which each display the **Health Status**, **Availability** and **Description**.

### TSP

This page contains the **TSP Table**, with information such as the **Mux Card Slot**, **Physical Port** and **Health Status.**

### IRD

This page contains the **IRD Table**, with information such as the **IRD Comms Status**, **Health Status**, **Availability** and **Description**.

### Relay (1/2)

This page contains the following tables:

- **Encoder Relay Table**: Displays the **Encoder Index** and **Health Status**.
- **TSP Relay& Table**: Displays the **TSP Index** and **Health Status**.
- **Mux Relay Table**: Displays the **Mux Index** and **Health Status**.

### Relay (2/2)

This page contains the following tables:

- **Stream Aux Relay Table**: Displays the **Relay Number** and **Health Status**.
- **Aux Relay Table**: Displays the **Relay Number** and **Health Status**.

### Router Chassis

This page contains the **Router Chassis Table**, with information such as the **Chassis Type**, **Health Status**, **Comms Status**, **Availability** and **Description**.

### IPE

This page contains the **IPE Table**, with information such as the **Health Status**, **Availability** and **Description**.

### Traps

This page contains **Trap settings**, such as the **Trap Polling Interval** and the **Trap Generation** parameter.

## Notes

Version 1.0.1.x is not backwards compatible with the previous version. It is an entirely new version.

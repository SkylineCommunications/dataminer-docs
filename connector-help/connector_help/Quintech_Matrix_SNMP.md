---
uid: Connector_help_Quintech_Matrix_SNMP
---

# Quintech Matrix SNMP

This connector allows you to view and control the Quintech matrix crosspoints.

## About

This connector uses an SNMP connection to display information on a Quintech matrix and allows the user to configure the matrix.

### Version Info

| **Range** | **Description**                  | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                 | No                  | Yes                     |
| 1.1.0.x          | Updated to support new firmware. | No                  | Yes                     |

### Supported Firmware Versions

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 7.5.9:2201                  |
| 1.1.0.x          | 7.5.9:2201                  |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.19.19.30*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private.*

## Usage

### General Page

This page displays **system information.**

Multiple page buttons are available:

- **SNMP**: Opens a subpage with SNMP parameters.
- **QPE**: Opens a subpage with QPE parameters.
- **UI**: Opens a subpage with user parameters.

### Matrix Page

This page displays the SNMP matrix.

### Modules Page

This page displays two tables:

- **Modules:** This table lists the modules that are currently present in the system and also provides matrix information such as inputs and outputs, max/min inputs and outputs and gain parameters.
- **Module Status Info:** This table lists the statuses of the modules that are currently present in the system, such as the status of the fans, CPU, temperature, PS1/PS2, etc.

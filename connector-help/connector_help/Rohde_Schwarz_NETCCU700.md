---
uid: Connector_help_Rohde_Schwarz_NETCCU700
---

# Rohde Schwarz NETCCU700

This connector is developed for devices such as the **Rohde Schwarz NETCCU 700 Controller Console**. The connector polls parameters from the device to enable monitoring of the transmitters.

## About

With three timers, all parameters of the device are polled. The parameters are displayed on several different pages. Some parameters allow you to configure settings.

### Version Info

| **Range** | **Description**                             | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                             | Yes                 | No                      |
| 1.0.1.x          | Added DVEs                                  | Yes                 | No                      |
| 1.0.2.x          | Added a new button "Switch Over with Reset" | Yes                 | No                      |

### Exported connectors

| **Exported Connector**                  | **Description**    |
|----------------------------------------|--------------------|
| Rohde Schwarz NETCCU 700 Transmitter 1 | Transmitter 1      |
| Rohde Schwarz NETCCU 700 Transmitter 2 | Transmitter 2      |
| Rohde Schwarz NETCCU 700 Transmitter 3 | Transmitter 3      |
| Rohde Schwarz NETCCU 700 Transmitter N | Backup transmitter |

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.17.3.3*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Settings

On this page, settings can be done for transmitters and programs.

### Status

This page displays general status information. You can also view status information for each transmitter via page buttons. The program status can be monitored in the same way.

### Register

This page displays register parameters for each transmitter.

### Trap Masks

On this page, every parameter can be enabled or disabled. The same configuration can be set for each transmitter.

### Trap Events

This page displays all trap events, in a similar way as on the Trap Masks page.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

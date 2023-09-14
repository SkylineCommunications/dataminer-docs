---
uid: Connector_help_Rohde_Schwarz_SX8000_DTT
---

# Rohde & Schwarz SX8000 DTT

This connector monitors and manages transmitters such as the **Rohde & Schwarz SX8000 DTT**. It polls and sets parameters on the device.

## About

With three different timers, all parameters related to the transmitter are polled. It is also possible to set up the device via the connector.

### Version Info

| **Range** | **Description**         | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version         | Yes                 | Yes                     |
| 2.0.0.x          | Added serial connection | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.17.250.17*.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### Serial Connection

This connector uses a serial connection. The following configuration will be set by the connector:

SERIAL CONNECTION:

- **IP address/host**: Same as the SNMP IP.
- **IP port**: 8020.

## Usage

The connector consists of several pages:

- **General:** Displays general information about the product software and hardware.
- **Transmitter:** Contains summary information about the transmitter.
- **Transmitter Settings:** Contains settings that can be configured for the transmitter.
- **Exciter Status:** Displays the general status of the exciter.
- **Exciter Settings**: Contains general settings for the exciter.
- **Exciter 1 Settings**: Contains more specific settings for the exciter.
- **Common Traps:** Contains trap settings, as well as the **Trap Sink Table**.
- **Web Interface**: Displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface

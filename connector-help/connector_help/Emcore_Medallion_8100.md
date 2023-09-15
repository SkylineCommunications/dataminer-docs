---
uid: Connector_help_Emcore_Medallion_8100
---

# Emcore Medallion 8100

The **Emcore Medallion 8100** series is a family of high-performance DOCSIS 3.1 compliant 1550 nm externally-modulated CATV transmitters.

## About

This connector is used to monitor and configure the **Emcore Medallion 8100**. It uses an SNMP connection to get/set data from/to the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.20                        |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page shows general information regarding the device: **Tag ID**, **Device Type** and **Serial Number**.

Page buttons provide access to the following subpages:

- **Front Panel LED**: Displays the LED status information.
- **Network Config**: Allows you to view and configure the network information, **IP Address**, **Gateway**, **Netmask** and **IP Mode**.

### Transmitter Data

This page allows you to view and edit the transmitter parameters, such as **CATV RF Input**, **CATV Composite RF Level**, **CATV Attenuation** and **System Temperature**.

### Power Supply

This page contains power supply information, such as the **Power Supply Type**, **Temperature** and **Status**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise, it will not be possible to open the web interface.

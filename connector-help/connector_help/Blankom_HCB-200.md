---
uid: Connector_help_Blankom_HCB-200
---

# Blankom HCB-200

This is an SNMP-based connector used to monitor and configure the Blankcom HCB-200 controller.

## About

The Blankom HCB-200 is a headend controller, which contains a redundant power supply and a TCP/IP server. It can send SNMP traps to an SNMP server.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### Network Configuration

This page contains an overview of information related to the network configuration. It is also possible to change some of the settings.

Among the displayed parameters are for example the **MAC Address**, **Subnet Mask**, **SNMP Read Community**, etc.

### Headend

This page displays information about the headend, such as the **Headend Controller Type**, **Headend Controller Version T**, **Headend Controller Ambient Temperature, Headend Controller Voltage A**, etc.

### Web Interface

This page can be used to access the **web interface** of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

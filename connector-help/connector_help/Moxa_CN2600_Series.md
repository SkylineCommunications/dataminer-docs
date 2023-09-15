---
uid: Connector_help_Moxa_CN2600_Series
---

# Moxa CN2600 Series

This device has the ability to enable redundancy in your network.

This connector allows you to retrieve information from the Moxa CN2600 series. It allows you to monitor alarms and statistical information, and configure/activate the entire device.

The connector retrieves and sets information on the device through SNMP.

## About

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          |                             |

## Configuration

### Connections

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public.*
- **Set community string**: : The community string used when setting values from the device, by default *private.*

## Usage

### General

The general page contains generic machine information/configuration. Moxa Overview: This gives you an overview of the moxa general condition and settings such as Model name, firmware, serial number, power connection, etc.

### Interface Info

Allows you to monitor the interface values as well as bit rates on the different ports of the moxa device.

### Monitor Remote IP

Allows to monitor the connected IP addresses.

### Monitor Serial Port

This page includes:

- Serial Port Status
- Serial Port Error Count
- Serial Port Buffering

There is also a Settings Page, which is only for monitoring purposes.

### System Management

This page includes the following settings:

- SNMP Settings
- Server Settings
- Time Settings
- Host table
- Route table
- User Settings
- Authentication Server
- System Log Settings
- Console Settings
- Accessible IP List
- DDNS Agent
- Save And Restart Settings
- Reset to Factory default
- Auto warning Settings

### Network settings

Configuration of:

- LAN 1
- LAN2
- LAN PPPoE Account
- DNS Settings
- Wins Settings
- ARP Settings

### Serial Port Settings

All port settings:

- Application:

  - Sockets
  - Data Packing
  - Device Control
  - Reverse Terminal
  - Terminal
  - DRDAS
  - Dial

- Welcome Message

- Redundant COM

- Communication Parameter

- Data Buffering/logging

- Modem Settings

- Port Mode

### Web interface

Allows you to access the web interface of the device.

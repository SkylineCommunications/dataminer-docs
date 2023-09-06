---
uid: Connector_help_Moxa_CN2600_Series
---

# Moxa CN2600 Series

This device has the ability to enable redundancy in your network
AboutThis driver allows us to retrieve information from the Moxa CN2600 series. It allows to monitor, alarms, statistical information, and configure/activate the entire device.
The driver retrieves and sets information on the device through SNMP.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          |                             |

Installation and configuration

Creation

#### SNMP Main connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public.*
- **Set community string**: : The community string used when setting values from the device, by default *private.*

## Usage

### General

The general page contains generic machine information/configuration. Moxa Overview: This gives you an overvieuw of the moxa general condition and settings such as Model name, firmware, serial number, power connection,....

### Interface Info

Alaws you to monitor the interface values aswel as bitrates on the different ports of the moxa device.

### Monitor Remote IP

Allows to monitor the conneted IP adresses.

### Monitor Serial Port

This page includes:

- Serial Port Status
- Serial Port Error Count
- Serial Port Buffering

And a Settings Page, this is only fore monitoring puposes.

### System Management

This page includes the following settings:

> - SNMP Settings
> - Server Settings
> - Time Settings
> - Host table
> - Route table
> - User Settings
> - Authentication Server
> - System Log Settings
> - Console Settings
> - Accessible IP List
> - DDNS Agent
> - Save And Restart Settings
> - Reset to Factory default
> - Auto warning Settings



### Network settings

Configuration of:

> > > - LAN 1
> > > - LAN2
> > > - LAN PPPoE Account
> > > - DNS Settings
> > > - Wins Settings
> > > - ARP Settings



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

Allows you to acces the web interface of the device.

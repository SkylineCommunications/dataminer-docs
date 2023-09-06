---
uid: Connector_help_Moxa_CN2650-8-2AC
---

# Moxa CN2650-8-2AC

The **Moxa CN2650-8-2AC** is a Serial Gateway.

## About

**SNMP Protocol** is used for communication.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.1          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | 4.3 Build 14052214          |

## Installation and configuration

### Creation

SNMP Main connection

SNMP CONNECTION:

- **IP address/host**: \[The polling IP of the device.\]
- **Device address**: \[Indicate if required or not. If it is, specify default value and range.\]

SNMP Settings:

- **Port number**: \[The port of the connected device, by default *161*.\]
- **Get community string**: \[The community string used when reading values from the device
  (default value if not overridden in the driver: *public*).
  Note: If you have specified a default value in the driver, then specify that custom value.\]
- **Set community string**: \[The community string used when setting values on the device
  (default value if not overridden in the driver: *private*).
  Note: If you have specified a default value in the driver, then specify that custom value.\]

SNMP Redundancy connection

SNMP CONNECTION:

- **IP address/host**: \[The polling IP of the device.\]
- **Device address**: \[Indicate if required or not. If it is, specify default value and range.\]

SNMP Settings:

- **Port number**: \[The port of the connected device, by default *161*.\]
- **Get community string**: \[The community string used when reading values from the device
  (default value if not overridden in the driver: *public*).
  Note: If you have specified a default value in the driver, then specify that custom value.\]
- **Set community string**: \[The community string used when setting values on the device
  (default value if not overridden in the driver: *private*).
  Note: If you have specified a default value in the driver, then specify that custom value.\]



### Overview

This page displays: **Model Name, Serial Number, Firmware Version, Up Time, Power 1 Status,** and **Power 2 Status**.



### Basic Settings

This page allows the user to set: **Server Name,** and **Server Location.**

**
**

### LAN

This page displays: **IP Address, NetMask, Default Gateway,** and **Speed** for both LAN Interfaces.

It also contains a pagebutton to **LAN Settings.**



### LAN Settings

This page allows the user to set: **IP Configuration, IP Address,** **NetMask, Default Gateway,** **Speed, PPPoE User Account, PPPoE User Password,** and **DNS Server IP Address** for both LAN Interfaces.

It also allows the user to set: **Wins Function, Wins Server, Routing Protocol, Gratuitous ARP**, and **Gratuitous ARP Seind Period.**

Note: The User \*must\* press the **Set Network Parameters** Button in order for the settings to take effect!



### Restart

This page allows the user to Restart any individual Serial Port on the device, or the device itself.



### Web Interface

This page allows the user to directly access the device's web interface.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface."

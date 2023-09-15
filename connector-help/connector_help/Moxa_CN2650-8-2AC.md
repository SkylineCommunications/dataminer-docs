---
uid: Connector_help_Moxa_CN2650-8-2AC
---

# Moxa CN2650-8-2AC

The **Moxa CN2650-8-2AC** is a Serial Gateway.

## About

**SNMP Protocol** is used for communication.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.3 Build 14052214          |

## Configuration

### Connections

#### SNMP Main connection

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default: *public*.
- **Set community string**: The community string used when setting values on the device, by default: *private*.

#### SNMP Redundancy connection

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default: *public*.
- **Set community string**: The community string used when setting values on the device, by default: *private*.

### Overview

This page displays: **Model Name, Serial Number, Firmware Version, Up Time, Power 1 Status,** and **Power 2 Status**.

### Basic Settings

On this page, you can set the **Server Name,** and **Server Location.**

### LAN

This page displays: **IP Address, NetMask, Default Gateway,** and **Speed** for both LAN Interfaces.

It also contains a page button to **LAN Settings.**

### LAN Settings

On this page, you can set the **IP Configuration, IP Address**, **NetMask, Default Gateway**, **Speed, PPPoE User Account, PPPoE User Password,** and **DNS Server IP Address** for both LAN Interfaces.

You can also set the **Wins Function, Wins Server, Routing Protocol, Gratuitous ARP**, and **Gratuitous ARP Send Period.**

> [!IMPORTANT]
> You need to click the **Set Network Parameters** button in order for the settings to take effect.

### Restart

This page allows the user to Restart any individual Serial Port on the device, or the device itself.

### Web Interface

This page allows the user to directly access the device's web interface.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface."

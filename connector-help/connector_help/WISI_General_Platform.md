---
uid: Connector_help_WISI_General_Platform
---

# WISI General Platform

The **WISI General Platform** is used to monitor and control Optical Platform devices for FTTx and HFC.

## About

With the **WISI General Platform**, any module can be mounted into any slot, so that fully customized individual configurations are possible, specific to the intended application.

For each card inserted into one of the available slots, a corresponding **Dynamic Virtual Element** (**DVE**) will be generated, allowing the user to consult detailed information regarding the module.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | V01.00.00.00b               |

### Exported connectors

| **Exported Connector**         | **Description**    |
|-------------------------------|--------------------|
| WISI General Platform - CD80T | Transceiver Module |
| WISI General Platform - CD80A | Transceiver Module |
| WISI General Platform - CD72T | Rack Controller    |
| WISI General Platform - CD72N | Rack Controller    |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### System

This page displays general information about the device, including:

- **Name:** The name of the managed node.
- **System Description:** The description of the entity.
- **Position in Cabinet:** The position of the system in the cabinet.
- **Location:** The physical location of the node.
- **Contact:** Information on the person responsible for the node.
- **Up Time:** The time since the device was last restarted.
- **Object ID:** The identification of the entity.

### Network

This page displays network information about the device:

- **IPv4 Local Address:** The IPv4 network address of the unit in the local network.
- **IPv4 Local Netmask:** The IPv4 network net mask of the unit in the local network.
- **IPv6 Local Address:** The IPv6 network address of the unit in the local network.
- **IPv6 Local Link Pfx Len:** The prefix length of the IPv6 network address.
- **MAC Address:** The physical address of the hardware ethernet interface of the unit.
- **IPv4 Remote Address:** The IPv4 network address of the control unit in the remote network.
- **IPv4 Remote Netmask:** The IPv4 network net mask of the control unit in the remote network.
- **IPv4 Remote DHCP:** Displays whether the IPv4 network address and net mask are awarded via DHCP.
- **IPv4 Remote DHCP Grant Status:** Displays whether the IPv4 network address and net mask are awarded via DHCP.
- **IPv6 Remote Link Address:** The IPv6 network address of the control unit in the remote network.
- **IPv6 Remote Link Pfx Len:** The prefix length of the IPv6 network address of the control unit in the remote network.
- **IPv6 Remote Global Address:** The current global IPv6 network address of the control unit in the remote network.
- **IPv6 Remote Global Pfx Len:** The current prefix length of the global IPv6 network address of the control unit in the remote network.
- **IPv6 Remote Gateway:** The current IPv6 gateway network address of the control unit in the remote network.

### Settings

This page allows you to configure the following settings:

- **Syslog Server Address Type:** The type of network address of the remote syslog server.
- **IPv4 Syslog Server Address:** The IPv4 network address of the remote syslog server.
- **IPv6 Syslog Server Address:** The IPv6 network address of the remote syslog server.
- **TFTP Server Address Type:** The type of network address of the TFTP server.
- **IPv4 TFTP Server Address:** The IPv4 network address of the TFTP server.
- **IPv6 TFTP Server Address:** The IPv6 network address of the TFTP server.
- **Time Server Address Type:** The type of network address of the SNTP time server.
- **IPv4 Time Server Address:** The IPv4 network address of the SNTP time server.
- **IPv6 Time Server Address:** The IPv6 network address of the SNTP time server.

### Traps

This page displays information related to the trap handling of the device:

- **Trap Receiver Table:** The settings of the trap receiver (IPv4/IPv6 addresses and community strings).
- **Version:** The SNMP version used in the communication with the device.

### Alarm

This page displays the alarms logged since the system was first started up.

- **Alarm Log Table:** A list of the alarms that have been logged since the last unit reset.

### Devices

This page displays data related to the devices currently mounted on the rack:

- **Device Table:** Information about the devices of all subracks and all slots.

### Modules

This page contains the DVE tables and corresponding management controls.

### Web Interface

This page displays the web interface of the platform itself. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

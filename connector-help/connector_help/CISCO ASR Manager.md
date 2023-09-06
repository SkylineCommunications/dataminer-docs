---
uid: Connector_help_CISCO_ASR_Manager
---

# CISCO ASR Manager

This is an **SNMP** connector that is used to monitor and configure the **CISCO ASR Manager** equipment.

## About

### Version Info

| **Range**            | **Description**                                                                                 | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                                | Yes                 | Yes                     |
| 1.0.1.x \[Obsolete\] | Added "IF Translation Table".                                                                   | Yes                 | Yes                     |
| 1.0.2.x \[Obsolete\] | Changed display key for interface detail tables.                                                | Yes                 | Yes                     |
| 1.0.3.x \[Obsolete\] | Removed some parameters from the SSH page that were made irrelevant by the reworked SSH system. | Yes                 | Yes                     |
| 1.0.4.x \[SLC Main\] | Changed the type of some PTP parameters from string to numeric text.                            | Yes                 | Yes                     |
| 2.0.0.x \[Obsolete\] | DCF tables added.                                                                               | Yes                 | No                      |
| 2.0.1.x              | Fixed Cassandra compliancy.                                                                     | Yes                 | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Cisco IOS Cisco IOS XR |
| 1.0.1.x   | \-                     |
| 1.0.2.x   | \-                     |
| 1.0.3.x   | \-                     |
| 1.0.4.x   | \-                     |
| 2.0.0.x   | \-                     |
| 2.0.1.x   | \-                     |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Additional requirement from version 1.0.1.18 onwards

From version 1.0.1.18 of the connector onwards, the custom DLL "Renci.SshNetSLC.dll" is required.

## Usage

### General

This page displays the **System Name**, **System Description**, **System Location**, **System Contact**, **System Up Time**, and other general parameters.

You can also enable or disable the polling of some of the tables of the connector here.

### Detailed Interface Info

This page displays the **Detailed** **Interface Info** table.

The page also contains a button that can be used to **Remove Unused Interfaces** from the **Detailed Interface Info** table.

### Detailed Interface Info - Rx

This page displays the **Detailed** **Interface Info - Rx** table.

### Detailed Interface Info - Tx

This page displays the **Detailed** **Interface Info - Tx** table.

### PoE

This page displays the **PoE** and **Workgroup** table.

### ISDN

This page displays the **IDSN**-related information.

### BGP

This page displays the **BGP Peer** table and other BGP-related information.

### HSRP

This page displays the **HSRP Group** table.

### LDP

This page displays the **LDP** table.

### OSPF

This page displays the **OSPF-**related information.

### IGMP

This page displays the **IGMP Interface** and **IGMP Cache** table.

### IPSec

This page displays the **IPSec Phase 1 Peer State** and **IPSec Phase 1 Tunnel** and **IPSec Phase 2 Tunnel** table.

### IP SLA

This page displays the **IP SLA** table.

### QoS

This page displays the **QoS** tree view information.

### Hardware Info

This page displays the **Ent Physical** table.

### Fan - PS Info

This page displays the **Fan Tray Status** and **FRU Power Status** table.

### Sensor

This page displays the **Ent Sensor Value** table.

### VLAN Info

This page displays the **VLAN** **Info** table.

### PIM

This page displays the **Interface**, **Neighbor**, and **IP Multicast Route (PIM)** table.

### ISIS

This page displays the **ISIS** system-related information.

### EIGRP

This page displays the **VPN**, **Traffic Statistics**, **Topology**, **Peer**, and **Interface** **(EIGRP)** table.

### VRF

This page displays the **CSV VRF**, **VRF (CV)**, and **VRF Interface (CV)** table.

### VRF Interface Tree

This page displays the **VRF Interface** tree view information.

### MPLS VPN

This page displays the **MPLS VPN Interface Configuration**, **MPLS VPN VRF**, and **MPLS VPN VRF Route** table.

### VRF Tree

This page displays the **VRF** tree view information.

### Process

This page displays the **Process**-related information.

### SSH

This page allows you to send commands over **SSH**. Two types of authentication are available:

- **Default**: Uses the password to establish the connection.
- **Keyboard Interactive Authentication**: If this mode is selected, the connector simulates the entry of the password on the keyboard to allow successful authentication with the device. Some devices enforce this type of authentication for security reasons.

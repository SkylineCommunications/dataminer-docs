---
uid: Connector_help_Dell_MXL_10-40_GBE_Switch
---

# Dell MXL 10-40 GBE Switch

The Dell MXL 10-40 GBE Switch connector uses **SNMPv2** to retrieve information from the switch.

The **initial range** of the connector (1.0.0.x) only displays detailed information about the **interfaces** of the switch.

## About

### Version info

| **Range** | **Description**       |
|-----------|-----------------------|
| 1.0.0.x   | Initial version.      |
| 2.0.0.x   | Reviewed version.     |
| 2.0.1.x   | SSH connection added. |

### Product Info

| **Range**               | **Supported Firmware** |
|-------------------------|------------------------|
| 1.0.0.x 2.0.0.x 2.0.1.x | 9.7(0.0) 9.13(0.3)     |

## Configuration

### Connections

#### SNMPv2 Connection

This connector uses a Simple Network Management Protocol (SNMPv2) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

#### SSH Connection

From range 2.0.1.x onwards, this connector also uses an SSH connection, which requires the following input during element creation:

SSH CONNECTION (2.0.1.x):

- **IP address/host**: The polling IP of the device.

SSH Settings:

- **IP Port**: The port of the connected device, by default *22*.
- **Local IP Port**: The local IP port used for communicating with the device. The default value is *49155*.

## Usage

### General

This page displays general information about the device, such as the **description**, **uptime**, etc.

### Detailed Interface Info

This page displays the **Detailed Interface Info** table. This table contains information for all interfaces in the system.

The information in the table is retrieved from the following SNMP tables: **ifTable**, **ifXTable** and **f10IfTable**.

### Vlan

This page displays the **VLAN Static** table. The table shows the available VLANs.

### SSH Credentials

Available from the 2.0.1.x range onwards. This page allows you to enable the SSH connection using the **SSH Polling** toggle button. You can also specify the username and password to access the device.

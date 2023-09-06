---
uid: Connector_help_Cisco_Meraki
---

# CISCO Meraki

The **Cisco Meraki Cloud Controller** is a managed Wi-Fi solution, managing switches, routers and access points. This driver allows you to manage this device via **SNMP**.

## About

### Version Info

| **Range** | **Key Features**                                     | **Based on** | **System Impact** |
|-----------|------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version                                      | \-           | \-                |
| 2.0.0.x   | New driver range only polling interfaces over SNMPv1 | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                    |
|-----------|---------------------------------------------------------------------------|
| 1.0.0.x   | \-                                                                        |
| 2.0.0.x   | No specific firmware version required as only interfaces table is polled. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and needs the following user information:

SNMP Connection:

- **IP Address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## How to use

### 1.0.0.x range

In the 1.0.0.x range of the driver, the element consists of the following data pages:

- **General**: Contains the System Description, Up Time, Contact and other such parameters. Also displays the Organization Name and the Organization Status.
- **Network**: Contains the Network Table, which allows you to monitor the networks in the organization.
- **Device**: Contains the Device Table and the Device Interface Table, which allow you to monitor the devices (and their interfaces) in each network.
- **SSID**: Contains the SSID Table.
- **VLAN**: Contains the VLAN Table.

### 2.0.0.x range

In the 2.0.0.x range of the driver, the element consists of the following data pages:

- **General**: Mainly contains system information about the managed device, such as the **Description** and **Interfaces Number**.
- **Interfaces**: Contains the **Interfaces Details** table.

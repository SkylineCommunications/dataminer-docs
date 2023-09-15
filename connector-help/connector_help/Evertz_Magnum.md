---
uid: Connector_help_Evertz_Magnum
---

# Evertz Magnum

This connector can be used to monitor faults in the Evertz Magnum controller. The information is retrieved via an SNMP connection.

## About

### Version Info

| **Range** | **Key Features**                                     | **Based on** | **System Impact** |
|-----------|------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version.                                     | \-           | \-                |
| 1.0.1.x   | Fixed primary keys and added display keys to tables. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## How to Use

On the **Status** page, you can find various fault tables. Currently, only the Fault Status Device and Fault Status Client table are fully functional. We have reached out to Evertz to address this issue.

The **Device Monitor** and **Client Monitor** pages display additional tables that allow you to monitor the device and the client interface, as well as the connection for both.

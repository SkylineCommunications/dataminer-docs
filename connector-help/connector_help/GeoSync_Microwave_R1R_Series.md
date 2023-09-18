---
uid: Connector_help_GeoSync_Microwave_R1R_Series
---

# GeoSync Microwave R1R Series

The **GeoSync Microwave Redundant Switchover Unit** **Series** is designed to improve reliability and increase the availability of satellite links by providing switchover to a backup unit in the event of a critical alarm. When a fault is detected on a primary frequency converter, that converter is automatically switched to standby, and the backup converter is put online in its place. The monitor and control functions support local and remote control. An embedded web server provides a user-friendly computer interface.

The **GeoSync Microwave R1R Series** connector provides controls for the primary and backup converters, serial communication, and network addresses. It also provides monitoring and logging of the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.01                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The layout of the element is similar to that of the web interface.

The General page contains static data for the device, while the other page contains configuration parameters such as Switching Mode and Switch Position.

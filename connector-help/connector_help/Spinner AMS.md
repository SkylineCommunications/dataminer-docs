---
uid: Connector_help_Spinner_AMS
---

# Spinner AMS

The Spinner AMS is an Antenna Monitoring System, designed to detect arcing and water ingress in broadcast transmission systems.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**           |
|-----------|----------------------------------|
| 1.0.0.x   | 2018/9/23 15:00:00 (MIB version) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to Use

The driver uses SNMP to poll certain status parameters from the AMS.

Traps can be retrieved when this function is enabled on the device.

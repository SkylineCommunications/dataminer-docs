---
uid: Connector_help_2WCOM_NC06
---

# 2WCOM NC06

This driver allows you to monitor and configure the device 2WCOM NC06 via SNMP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |
| 1.0.1.x              | DVE support      | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                              |
|-----------|---------------------|-------------------------|-----------------------|----------------------------------------------------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | [2WCOM NC06 - Device](xref:Connector_help_2WCOM_NC06_-_Device) |
| 1.0.1.x   | No                  | No                      | \-                    | [2WCOM NC06 - Device](xref:Connector_help_2WCOM_NC06_-_Device) |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the following data pages:

- **General**: Displays general parameters like Description and Uptime.
- **Input**: Contains a table with the input of the device.
- **Output**: Contains a table with the output of the device.
- **Device**: Allows you to add and remove devices connected to this device. When you add a device, go to the Input and/or Output page and select the input/outputs that belong to that device.

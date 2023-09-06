---
uid: Connector_help_LTN_Crystal_GUI_Server
---

# LTN Crystal GUI Server

The LTN Crystal GUI Server is a monitoring and control system that provides an SNMP interface to monitor and control parameters on devices managed by this system.

This driver allows you to monitor and control parameters of the devices in the Crystal system.

## About

### Version Info

| **Range**            | **Key Features**                          | **Based on** | **System Impact** |
|----------------------|-------------------------------------------|--------------|-------------------|
| 1.0.0.x (obsolete)   | Initial version                           | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Fixes parameter names to match device GUI | 1.0.0.1      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Ruby (7.6)             |
| 1.0.1.x   | Ruby (7.6)             |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The **Device Type Table** contains the list of device types that can be monitored/controlled by the Crystal system. The **Device Presence** column indicates whether there is a supported device of that specific type in the system. If a device is present, its parameters can be displayed in a table based on the user requirements. In order to reduce the load on DataMiner, this table is not polled frequently.

When a new device is inserted in the system or when you want to update the displayed data, use the **Refresh Table** button.

---
uid: Connector_help_Evertz_570DSK-4K-25G
---

# Evertz 570DSK-4K-25G

This connector is used to monitor and configure the Evertz 570DSK-4K-25G device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.11                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

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

The **General** page shows the device health status as well as some general parameters.

You can change the device configuration on the **Device** **Configuration** page.

The driver has 6 main tables:

- **PTP Port Status**
- **QSFP Status**
- **1G Ethernet Port Configuration**
- **25G Ethernet Port Configuration**
- **Input Stream Configuration**
- **Output Stream Configuration**

These are located on the **PTP** **Status**, **QSFP**, **1G** **Ethernet**, **25G** **Ethernet**, **Input** **Stream** and **Output** **Stream** pages, respectively.

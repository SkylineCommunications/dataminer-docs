---
uid: Connector_help_Evertz_7707GPS-DT-F2
---

# Evertz 7707GPS-DT-F2

This connector is designed to manage the Evertz 7707GPS-DT-F2 card. It communicates using SNMP and has filter polling per card using subtables.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The slot number of the card in the frame.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Important Note

Full functionality of this connector, with frame status parameters such as temperature and power supply, also requires the Evertz 7X00 Frame Controller connector.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The connector will communicate with the frame but only poll information for the card slot defined during element creation.

All tables are polled via SNMP. Traps are supported.

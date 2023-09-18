---
uid: Connector_help_DHD_XC3
---

# DHD XC3

The XC3 IP core is intended for on-air applications in radio and TV, ranging from small DJ-operated studios with 12 faders to large control desks in complex studio environments with up to 48 faders.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Minimum:10.0.1         |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Port number**: The port of the connected device (default: *161)*.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Redundancy

Redundancy parameters available on the **General** page.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

Once you have created the element, the main parameters to monitor the device are available on the **System** and **Status** pages.

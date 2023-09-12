---
uid: Connector_help_Damocles2_1208
---

# Damocles2 1208

This connector polls, displays, and controls information from the Shelter AC.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

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
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

**Note**: Check the device to find the community strings used. If there is a common read-write string, use that for both the get and set community strings.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This connector contains the following pages:

- **General**: Displays system information about device.
- **Inputs**: Displays information about the inputs of the device.
- **Alarms**: Displays the alarms sent by the inputs of the device.

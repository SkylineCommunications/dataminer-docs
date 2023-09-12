---
uid: Connector_help_Scientific_Atlanta_Indus
---

# Scientific Atlanta Indus

This connector polls, displays, and controls information from the Indus Descrambler.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V01.00.01              |

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

**Note**: Check the device to find the community strings used. If there is a common read-write string, use that for both the get and set community strings.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This connector includes the following data pages:

- **General**: Displays system information of the device.
- **CAM**: Displays CAM information of the device.
- **Transport Stream:** Displays transport streams information.
- **Descrambling:** Displays descrambling information.
- **Alarms**: Displays the alarms sent by the inputs of the device.

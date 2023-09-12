---
uid: Connector_help_Sony_NXLK-IP50Y_51Y_HDR-CCR
---

# Sony NXLK-IP50Y_51Y HDR-CCR

The **Sony NXLK-IP50Y_51Y HDR-CCR** driver is used to monitor and control **Sony NXLK IP50Y and 51Y** **Drivers**. The driver also uses an HTTP connection and a WebSocket connection to handle the data.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

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

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP connection:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### HTTP Connection

This driver uses a Hypertext Transfer Protocol (HTTP) connection and requires the following input during element creation:

HTTP connection:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

#### WebSocket Connection

This driver uses a Websocket connection and requires the following input during element creation:

WebSocket connection:

- **IP address/host**: The polling IP or URL of the destination. Must contain either "ws://" or "wss://" as a prefix.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

It uses the connection to receive notifications of data changes in the device.

### Initialization

To authenticate the HTTP and WebSocket connections, on the **HTTP Login** page, specify the username and password.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product. The web interface uses **HTTPS**.

## How to use

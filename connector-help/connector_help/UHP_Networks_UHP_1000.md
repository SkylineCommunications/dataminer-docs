---
uid: Connector_help_UHP_Networks_UHP_1000
---

# UHP Networks UHP 1000

The UHP-1000 Hubless VSAT satellite router is fully scalable and can be operated as a mini-hub or a remote station in a TDM/TDMA network, or any node (master or slave) in a fully meshed Hubless TDMA network. This versatility makes this router a universal software-defined component of a highly efficient satellite network utilizing any operation mode or topology.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.2.1.0                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### Serial Connection - Telnet Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device, e.g. *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *23*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The connector follows the MIB structure and displays all the parameters on its various pages.

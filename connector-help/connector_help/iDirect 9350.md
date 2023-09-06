---
uid: Connector_help_iDirect_9350
---

# iDirect 9350

The iDirect 9350 is a satellite modem designed for high-bandwidth mobility applications, which can operate on high-throughput satellites. The 9350 is highly flexible and can support small antennas for government and military applications including command, naval, and vehicle-based terminals. It is also available in a board-level product variant.

This connector uses a serial connection to communicate with this satellite modem.

## About

### Version Info

| **Range**            | **Key Features**    | **Based on** | **System Impact** |
|----------------------|---------------------|--------------|-------------------|
| 1.0.0.x              | Initial version     | \-           | \-                |
| 2.0.0.x \[SLC Main\] | HTTP implementation | 1.0.0.1      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 16.0.3.8               |
| 2.0.0.x   | 21.0.4.0               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### Serial Extra Connection 1 Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *22*).

### Initialization

Go to the Settings subpage and set the Username and Password for the HTTP and SSH connections (parameters 100, 102, 110 and 112).

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element displays information about the firmware and software running on the device, as well as information on the satellite and external equipment.

VLANs and interfaces information is also available.

On the **Explorer** page, you can send SSH commands to the device and inspect the received result.

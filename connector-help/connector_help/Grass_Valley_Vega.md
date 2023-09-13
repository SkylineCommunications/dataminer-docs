---
uid: Connector_help_Grass_Valley_Vega
---

# Grass Valley Vega

The Grass Valley Vega is a compact router that offers configurable I/O in any mixture of physical interfaces such as coax, fiber, HDMI, balanced and unbalanced AES and MADI.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5.4.5.8070             |

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
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### Smart Serial Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600* (default: *9600*).
  - **Databits**: Databits specified in the manual of the device, e.g. *7* (default: *8*).
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1* (default: *1*).
  - **Parity**: Parity specified in the manual of the device, e.g. *No* (default: *no*).
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No* (default: *no*).

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The **matrix number**, **level number**, **number of inputs** and **number of outputs** of the matrix separated by periods (".") The matrix number range is 0-15, the level number range is 0-7, and the range of inputs and outputs is 1-1024.
    For example: *"0.0.1024.1024".*

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The **General** page and **Ports** page contain all SNMP monitoring information, including **Input Ports**, **Output Ports** and **PSU Faults** monitoring.

The other pages are related to the **matrix configuration**. The information on these pages is updated via the smart-serial connection.

The **Matrix Configuration** parameter displays any detected misconfigurations. The status *OK* indicates that the matrix was successfully configured.

---
uid: Connector_help_Leader_LT4610
---

# Leader LT4610

The LT4610 is 1U full-rack size sync signal generator that can output triple-rate SDI (3G-SDI/HD-SDI/SD-SDI) signals.

The Leader LT4610 has been designed in order to monitor and control the different features of the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | SNMP connection  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.6                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private).*

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This connector does not require any configuration in order to work. Almost all configurable parameters are displayed in the same way as in the web interface of the device.

The genlock function for external sync signals makes it possible for **SDI signals**, six sets of analog black sync signals, and audio word-clock signals to be output synchronously.

In addition to test pattern output, including color bars and SDI check fields, the **LT4610** connector can configure embed **ID characters**, **QVGA logo** marks, **safety area** markers, and embedded audio in **SDI signal output**.

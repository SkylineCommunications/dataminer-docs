---
uid: Connector_help_RF_Mondial_RF-DAB
---

# RF Mondial RF-DAB

RF-DAB is a professional DAB monitoring receiver for transmitter, content and field monitoring. Its modular design enables flexible configuration for various specific applications.

Some applications this device can execute are transmitter monitoring, RF measurements and synchronization monitoring, content verification and monitoring, etc.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V2.9-20210126-1127     |

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
- **Bus address**: The bus address of the device.

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

This element has the following data pages:

- **General**: Contains general device parameters.
- **Measure**: Provides an overview of the overall decoding status.
- **Services**: This page and its subpages display the services received by the device with some of their characteristics/metrics.
- **Alarms**: This page and its subpages map the received alarms.

Alarms can be of type Echoes, TII, SFN Drift, Audio, Data, Sub-Channel, and System.

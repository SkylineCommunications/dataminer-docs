---
uid: Connector_help_ATX_Networks_PRO4S
---

# ATX Networks PRO4S

The **XDS-PRO4S** digital audio receiver allows radio stations to receive audio broadcasts from distributed satellite or IP networks for live broadcasting or storage for later playout.

This connector communicates through SNMP and retrieves information of the device that can be monitored and trended.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | SNMP connection  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.0.15                 |

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

SNMP Settings:

- **IP port:** The IP port of the destination, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The connector allows you to configure several parameters of the device, such as:

- **Network** properties: NMS site, DNS, and interfaces.
- **Tuner** parameters: Frequency, Symbol Rate, Modulation Mode, and LNB Power.
- **Peripherals** parameters: OPTO settings such as title and commands. Audio, storage, and PAD data is also available for monitoring.

A dedicated **Faults** page is available, which describes the current faults and the number of past faults.

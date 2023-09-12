---
uid: Connector_help_Arris_DSR-7401
---

# Arris DSR-7401

The Arris DSR-7401 transcoder IRD can be used to down-convert and transcode up to 12 input HD video sources simultaneously across four satellite transponders. It features customizable multiplex creation with Statmux output and flexible transport stream grooming options.

This protocol monitors the activity of the Arris DSR-7401 device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0x2D4e83               |

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

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this protocol consists of the following data pages:

- **General**: Displays system parameters and the LED status. On subpages, you can find information related to the **Trap Receivers** configuration, the device **Firmware** and the network **Interfaces**.
- **Signals**: Displays a table with the **Signal Status** of the device inputs.
- **Alarms**: Displays the Alarms table with the latest traps sent from the device.

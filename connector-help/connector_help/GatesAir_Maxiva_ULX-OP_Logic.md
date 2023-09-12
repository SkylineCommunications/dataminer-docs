---
uid: Connector_help_GatesAir_Maxiva_ULX-OP_Logic
---

# GatesAir Maxiva ULX-OP Logic

The **GatesAir Maxiva ULX-OP Logic** is the logic controller part of the **GatesAir Maxiva ULX-OP** liquid-cooled broadcast transmitter.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.5                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public)*.
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No further initialization necessary.

### Redundancy

No redundancy is defined for this driver.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

This driver uses **SNMP** to communicate with the device.

The driver displays both general information about the device and more detailed information related to its power and to the single transmitter. It allows you to configure single transmitter events and configure the priority of these events.

## Notes

This driver is part of a group of 3 drivers, which together form the GatesAir Maxiva ULX-OP. As each part of this setup has its own IP address, the driver was split up in 3 parts.

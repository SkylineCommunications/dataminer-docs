---
uid: Connector_help_GatesAir_Maxiva_XTE_Exciter
---

# GatesAir Maxiva XTE Exciter

The **GatesAir Maxiva XTE Exciter** is an exciter that powers over-the-air delivery across the UHF television spectrum.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                     |
|-----------|------------------------------------------------------------|
| 1.0.0.x   | 06.00.0034 (PCM Software Version)01.00.0685 (SNMP Version) |

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
- **IP port**: The IP port of the destination. The default ports for the device depends on its location:

> Slot: **Exciter A Port**, **Exciter B Port**
>
> > Xmtr \#0 : 19617, 19873Xmtr \#1 : 21665, 21921Xmtr \#2 : 23713, 23969Xmtr \#3 : 25761, 26017Xmtr \#4 : 27809, 28065Xmtr \#5 : 29857, 30113Xmtr \#6 : 31905, 32161Xmtr \#7 : 33953, 34209Xmtr \#8 : 36001, 36257

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

With this driver, it is possible to monitor and configure the Exciter cards in the MSC frame. In addition, it is also possible to enable trap notifications.

The communication protocol that is used to get and set the values is SNMP.

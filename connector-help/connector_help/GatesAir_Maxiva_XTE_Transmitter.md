---
uid: Connector_help_GatesAir_Maxiva_XTE_Transmitter
---

# GatesAir Maxiva XTE Transmitter

The **GatesAir Maxiva XTE Transmitter** is a transmitter that powers over-the-air delivery across the UHF television spectrum.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                    |
|-----------|-----------------------------------------------------------|
| 1.0.0.x   | A05 (release version) 1024 (application software version) |

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
- **IP port**: The IP port of the destination. The default port of the device depends on its location:

> Slot: **Transmitter Port**, **Exciter B Port**
>
> > Xmtr \#0 : 18593
> > Xmtr \#1 : 20641
> > Xmtr \#2 : 22689
> > Xmtr \#3 : 24737
> > Xmtr \#4 : 26785
> > Xmtr \#5 : 28833
> > Xmtr \#6 : 30881
> > Xmtr \#7 : 32929
> > Xmtr \#8 : 34977

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

The **General** page displays generic information on the transmitter.

The **Transmitter Mode** is set to *Single Transmitter* by default, but you can change this to *Dual Transmitter*. In that case, the Dual Transmitter information will be polled, and those pages will also become available.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

With this connector, it is possible to monitor and configure the transmitter itself. In addition, it is possible to enable trap notifications and define their priorities.

Based on the Transmitter Mode (Single or Dual), some pages will be hidden or displayed.

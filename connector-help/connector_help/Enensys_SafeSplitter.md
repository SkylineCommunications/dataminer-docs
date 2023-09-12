---
uid: Connector_help_Enensys_SafeSplitter
---

# Enensys SafeSplitter

SafeSplitter is a dual-channel splitter that outputs two incoming ASI signals over 3 ASI outputs each. In case of power failure or equipment breakdown, SafeSplitter maintains service continuity and outputs the input signals on the first output of each channel. SafeSplitter also provides advanced monitoring of the incoming MPEG-2 transport streams, and it can detect and raise any errors related to ASI synchronization loss, ETR290 level, T2-MI, or MPEG-2 TS. In addition, it monitors MPEG-2 TS QoS, i.e. the service availability error ratio and the service degradation error ratio.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.2.0                  |

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
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element has the following data pages: **General**, **Alarms**, **TS Display**, **TS1**, **TS2** and **Polling**.

On the **Polling** page, you can enable or disable the polling of the parameter groups and also set the polling frequency time.

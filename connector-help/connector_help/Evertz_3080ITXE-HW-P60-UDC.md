---
uid: Connector_help_Evertz_3080ITXE-HW-P60-UDC
---

# Evertz 3080ITXE-HW-P60-UDC

This encoder with 3G/HD/SD SDI or IP/ASI MPEG2/H264/J2K inputs can be used to build a content ingest platform for MSO, DTH, IPTV, broadcast, data center, etc.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP or URL of the destination.
- **IP port:** The IP port of the destination

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

The element displays information about the device on multiple pages and subpages:

- **Decoder Control, Audio, Monitor, ANC Data Control**: These pages contain configurable parameters and tables for the decoder functionality of the device.
- **Encoder Control, Monitor**: These pages contain different tables to control and monitor both audio and video parameters and their configuration.
- **CC Over IP, Fault, SFP**: These pages contain more tables with information about the closed caption, faults, etc.
- The **Traps** table keeps a record of every trap received. Above the table, parameters are available that can be used to control the size of the table. The **Trap Status** can be used to monitor if a trap was received within a configurable time frame.

## Notes

The faults tables are updated based on both polling and traps.

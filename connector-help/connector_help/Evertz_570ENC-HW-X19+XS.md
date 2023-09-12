---
uid: Connector_help_Evertz_570ENC-HW-X19+XS
---

# Evertz 570ENC-HW-X19+XS

The 570J2K-HW-X19 is a multi-channel J2K encoding and decoding platform, with direct conversion of up to 12 signals to direct mezzanine compression via JPEG2000.

The 570J2K-HW-X19 supports up to 12 channels of 3G, HD/SDI, SD/SDI or up to 3 channels of UHD JPEG2000 encoding. The 570J2K-HW-X19 will support up to 9 channels of 3G, HD/SDI, SD/SDI JPEG2000 or 2 channels of UHD JPEG2000 decoding.

The 570J2K-HW-X19 will provide auto-timing time stamped Ethernet outputs, multi-resolution JPEG2000 streaming outputs and incorporates patent pending multi-path, multi-flow packet merge base network bit error resilience for 100% QoS.

The 570J2K-HW-X19 can be managed via integrated HTTP web interfaces as well as SNMP management via Frame Controller.

This driver Evertz 570ENC-HW-X19+XS only monitors the **MIBs available for the Encoder** of the Evertz 570J2K-HW-X19 devices.

This driver uses **SNMP** to poll data from Evertz 570ENC-HW-X19+XS based on the web interface layout.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V303B20200731-248      |

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

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This driver follows the layout of the web interface and features the same monitoring and configuration capabilities.

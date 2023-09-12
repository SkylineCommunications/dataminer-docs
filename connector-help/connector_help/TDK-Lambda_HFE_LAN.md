---
uid: Connector_help_TDK-Lambda_HFE_LAN
---

# TDK-Lambda HFE LAN

The TDK-Lambda HFE series is a line of LAN (Local Area Network) power supplies that provide regulated DC power for Ethernet-based equipment and other network devices. These power supplies feature a wide input voltage range, high efficiency, and protection against overvoltage, overcurrent, and short-circuit conditions.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 01.07                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **General** page, you can find the power supply information.

The **DC Power** page will contain information about voltage, current, and output measurements.

The **Faults** parameters can be used to monitor the DC, OTP, OTA, FAN, AC, OVP, PVA, an CE status.

On the **LAN** page, you can configure the LAN settings.

The **Miscellaneous** page provides coefficient information and PSU details.

---
uid: Connector_help_Timelink_Microsystems_TMG3420
---

# Timelink Microsystems TMG3420

The TMG3210 is a GNSS disciplined time and frequency generator specifically designed for low noise applications. The equipment is housed in a 1U 19" standard case. GNSS signal is used for long-term disciplining of the internal oscillator.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                        |
|-----------|-----------------------------------------------|
| 1.0.0.x   | N/A (Only requirement is an SNMP connection.) |

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

### Initialization

No extra initialization is needed.

### Redundancy

There is no redundancy defined.

## How to use

You can find all the information you need to monitor the timelink generator on the General data page.

---
uid: Connector_help_Streamlabs_Mosaic
---

# Streamlabs Mosaic

Streamlabs Mosaic is a DVB/DTH/OTT/Mobile/IP/Video monitoring and compliance recording device for headend, satellite, cable, IPTV, and CDN operators.

This connector monitors the activity of the Streamlabs Mosaic.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5.4.743.31305          |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to use

The **General** page displays general information about the device. On the **Overview** page, you can find a tree view of the current transport streams, services, and packets monitored by the device.

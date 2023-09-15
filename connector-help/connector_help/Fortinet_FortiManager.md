---
uid: Connector_help_Fortinet_FortiManager
---

# Fortinet FortiManager

The Fortinet FortiManager protocol can be used to monitor the different devices and administrative domains managed by this management server.

## About

### Version Info

| **Range** | **Key Features**                                        | **Based on** | **System Impact** |
|-----------|---------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version FORTINET-FORTIMANAGER-FORTIANALYZER-MIB | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5.6.8                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMPv2) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default value: *public*).
- **Set community string**: The community string used when setting values on the device (default value: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

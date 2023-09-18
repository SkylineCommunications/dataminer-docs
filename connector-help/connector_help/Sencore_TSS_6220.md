---
uid: Connector_help_Sencore_TSS_6220
---

# Sencore TSS 6220

The TSS 6220 Transport Stream Server provides streaming capabilities to create automated playout of media files into multiple channels. With the onboard redundant storage and FTP and SMB file upload, the unit can take stored media files and play them out according to user-supplied schedules. Up to 16 independent schedules and corresponding MPEG over IP outputs can be maintained simultaneously. The connector itself acts as a monitoring platform that allows the user to view most of the parameters retrieved from the device and apply alarm monitoring and trending to them.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial range.   | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

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
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This connector is mainly used for monitoring and basic settings, such as changing the alias of the device, changing the name or IP of a network adapter, or setting the SNMP communities.

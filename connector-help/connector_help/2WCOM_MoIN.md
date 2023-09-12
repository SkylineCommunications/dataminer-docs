---
uid: Connector_help_2WCOM_MoIN
---

# 2WCOM MoIN

The 2WCOM MoIN is a point-to-point or point-to-multipoint audio decoder using IP-based audio network technologies for real-time streaming.

It polls relevant information from the device every 10 seconds, 1 minute, or 1 hour. It also receives traps from the device and updates the values accordingly.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

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

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection with redundant polling and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### SNMP Connection - Secondary

This connector uses a Simple Network Management Protocol (SNMP) connection with redundant polling and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This connector uses SNMP parameters to access and modify the device. It presents the parameters in a structure similar to that of the web interface of the device and also allows you to control the parameters in a similar manner.

The first page contains general information about the device and the Global page contains more in-depth information about the connector.

The main functionality is on the **Codec** page, which includes the **Source Assignment**. For each of the 8 audio sources, you can assign a Main source and up to 3 Backup sources per row.

The remaining pages contain table data regarding the sources that can be assigned on the Codec page.

The connector uses traps to update values in the Monitoring Status Audio Streaming Input table, which is used for the decoder statuses in the Source Assignment table, and to update values in the Decoder Audio Status Overview table, which is used for the audio status in the Source Assignment table.

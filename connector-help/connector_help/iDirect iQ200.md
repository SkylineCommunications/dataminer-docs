---
uid: Connector_help_iDirect_iQ200
---

# iDirect iQ200

The iQ 200 Rackmount is part of ST Engineering iDirect's DVB-S2/S2X modem series with a software-defined architecture for maximum flexibility and expansion.

The iDirect iQ200 connector polls all data from the device web interface. The UI of the connector imitates that of the web interface.

## About

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**  |
|-----------|-------------------------|
| 1.0.0.x   | EVOLUTION - 21.0.6.3 90 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### Serial Connection - SSH Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *22*).

### Initialization

On the **General** \> **Settings** page, fill in the credentials for HTTP and SSH.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The following data pages are available:

- **General**: Displays all general data related to device. On the **Settings** subpage, the HTTP and SSH credentials need to be filled in.
- **Satellite**: Displays data for the modem state receiver and transmit data.
- **Terminal**: Contains terminal information, device status information, and geographical information.
- **LAN Interfaces**: Contains port configuration information and data related to sent and received packages.
- **LNB**: Contains data for LNB.
- **VLAN**: Contains a table with all device VLANs.
- **Explorer**: Allows you to send an SSH command and inspect the response.

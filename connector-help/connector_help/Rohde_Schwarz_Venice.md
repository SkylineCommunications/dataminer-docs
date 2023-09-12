---
uid: Connector_help_Rohde_Schwarz_Venice
---

# Rohde Schwarz Venice

The Rohde & Schwarz Venice is a high-performance, multi-format video server designed for use in broadcast, production, and post-production environments. It features a modular design, allowing users to customize the server to their specific needs. The Venice is able to support a wide range of video and audio formats, including HD and SD, as well as 3G, HD-SDI and HDMI. It also has advanced features such as up-/down-/cross-conversion, frame synchronizing, and noise reduction. The Venice server is known for its high-quality video processing and reliability.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5.0.15.0               |

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

### Initialization

No extra configuration is needed.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

When you have correctly created the element, the following data will be available:

- **General Page**: General system information.
- **Interfaces Page**: Interface and Ethernet interface information.
- **Video Servers**: Overview of the 4 video servers.
- **Card General**: Card information.
- **Card Channel**: Overview of the 4 card channels.

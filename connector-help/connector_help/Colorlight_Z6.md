---
uid: Connector_help_Colorlight_Z6
---

# Colorlight Z6

The Colorlight Z6 is a professional LED display controller with splicing, sending, and processing functions. It can handle 4K video input and UHD and HDR image processing and transmission.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.59                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **Version:** SNMPv3
- **IP address/host**: The polling IP of the device.
- **Device address**: N/A

SNMP Settings:

- **Port number**: The port of the connected device.
- **Security level and protocol**: authPriv
- **Username**: custom
- **Authentication password**: custom
- **Encryption password**: custom
- **Authentication algorithm**: MD5
- **Encryption algorithm**: DES

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The **General** page contains general information about the device such as the temperature, brightness, color temperature, etc.

The **Inputs** and **Outputs** pages indicate the signal status.

The **Receiver Cards** page contains a table with specific information about the receiver cards per port.

---
uid: Connector_help_Evertz_7882ENC-H264HD-IPASI
---

# Evertz 7882ENC-H264HD-IPASI

The 7882ENC-H264HD-IPASI is professional contribution H.264 and MPEG-2 encoder.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v2.0 build 1145        |

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

The element displays the device information on the following pages: **System**, **Product Features**, **Audio Proc Control**, **Encoder Control**, **Encoder Monitor**, **H264/MPEG2 Encoder**, **Dolby Metadata Control**, **SCTE 35 GPI**, **Preset**, and **Faults**.

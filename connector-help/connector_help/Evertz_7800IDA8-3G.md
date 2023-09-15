---
uid: Connector_help_Evertz_7800IDA8-3G
---

# Evertz 7800IDA8-3G

...

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the following pages:

- **General**
- **Audio Control**
- **Video Control**
- **Misc Control**
- **DMX Control**
- **UMX Control**
- **Thumbnail**
- **Audio Mixer**
- **IntelliSync Configuration**
- **IntelliGain Configuration**
- **IntelliGain Threshold**
- **IntelliGain Program**
- **IntelliTrak VANC Config**
- **Fault Control**
- **IntelliGain Fault Traps**
- **Video Fault Traps**
- **Audio Fault Traps**
- **Traps**

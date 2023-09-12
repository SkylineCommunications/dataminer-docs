---
uid: Connector_help_Miteq_UPC2
---

# Miteq UPC2

This **Uplink Power Control** (UPC) is designed to adjust the strength of uplink signals to compensate for varying weather conditions in order to ensure that a stable signal strength is received by the satellite.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v1.15                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This driver contains the following pages:

- **General**
- **System** **Status**
- **Configuration**
- **Channel Setup**

On the **General** page, you can find general information about the device, such as the **Firmware Version**, **UPC Control Mode**, etc. More system status information is located on the **System Status** page.

On the **Configuration** page, certain parameters can be configured. You can change the active receiver to A or B, change the **Correction Algorithm**, etc.

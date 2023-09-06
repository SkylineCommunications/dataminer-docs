---
uid: Connector_help_Evertz_Scorpion_18_MIO-APP-UDX-4K
---

# Evertz Scorpion 18 MIO-APP-UDX-4K

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

- **IP address/host**: The individual module control IP assigned to the **MIO module** (note: **not** the Scorpion Frame IP).
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

### Important Note

Full functionality of this connector also requires the **Evertz Scorpion X18 Frame** connector.

## How to use

The element consists of the following pages:

- **General**
- **Network Management**
- **IP**
- **Video**
- **ANC**
- **Audio**
- **Reference**
- **Presets**
- **Time Code**
- **License Management**

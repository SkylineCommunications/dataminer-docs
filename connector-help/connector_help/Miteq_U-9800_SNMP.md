---
uid: Connector_help_Miteq_U-9800_SNMP
---

# Miteq U-9800 SNMP

The MITEQ converters are designed for advanced satellite communication systems and are available for a wide variety of frequency plans. Phase noise, amplitude flatness and spurious outputs provide the user with transparent frequency conversion for all video and data applications. Local and remote control are supported, including control of frequency, attenuation, and 64 memory locations for each converter where various setups can be stored and recalled. A continuously updated log of time-stamped records of activity is also available.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**     |
|-----------|----------------------------|
| 1.0.0.x   | D172138V2.010D179861V1.001 |

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

This connector allows monitoring and control of the converter.

On the **General** page of the element, you can configure both the system and unit information.

The **Bands** page provides an overview of the available bands with the option to activate an inactive band.

The **Memory** page provides an overview of the available memory profiles with the option to activate a memory profile. You can configure a memory profile by selecting the related memory profile and selecting the right-click edit option.

## Notes

When the SNMP **Read Community** or **Write Community** settings are updated, the element's SNMP connection must be re-configured in order to avoid polling or configuration issues.

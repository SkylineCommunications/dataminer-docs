---
uid: Connector_help_2WCOM_X-4sd
---

# 2WCOM X-4sd

This connector uses SNMP to connect to a redundancy switch with audio conversion and network functionalities such as EMBER+.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0-rc7                |

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
- **IP port**: 161

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The connector uses SNMP to connect to the device. It allows you to configure many settings. The most important ones are the **switch settings** (Relay, Email, SNMP), **monitoring settings** (Hardware, PSU), and **system settings** (Ember+, Headphone, SNMP, NTP, GPO/GPI).

The following data pages are available:

- **General**: Contains general information such as the system name, location, and firmware details.
- **Input/Outputs**: Contains Input and Output Gain Tables.
- **Channels**: Contains XInput Mode settings.
- **Switch Settings**: Contains various settings such as SNMP, Email, LED, and Priority for Switch.
- **Device Status**: Contains various hardware information such as temperature and voltage status information.
- **Monitoring Settings**: Contains hardware settings for the device.
- **System Settings**: Contains various system settings such as CSL, Ember+, NTP, Headphone, GPO/GPI, and Ethernet information.

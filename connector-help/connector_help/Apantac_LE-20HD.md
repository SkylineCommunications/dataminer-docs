---
uid: Connector_help_Apantac_LE-20HD
---

# Apantac LE-20HD

The Apantac LE-20HD is an SDI & composite video input multiviewer with built-in CATx extender.

This connector uses SNMP to poll data from the Apantac LE-20HD device based on the Apantac MIB.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                         |
|-----------|--------------------------------------------------------------------------------|
| 1.0.0.x   | K(20190808) - Q0(20200325) Q1(20200325) Q2(20200325) Q3(20200325) Q4(20200325) |

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

### Initialization

No further configuration is required.

### Redundancy

There is no redundancy defined.

## How to use

On the **General** page, the **Managed** **Elements Table** contains general information and settings, while the **Managed Elements Status Table** contains status information for each managed element. The **Signal Table** lists all tracked signals. Each row of this table corresponds with a single monitored signal, e.g. an SDI video feed or an AES/EBU audio feed. For each signal, more information is available, including several status parameters.

On the **Configuration** subpage, several settings can be configured, including **Screens**, **Monitors**, **Text** **Message** and **Scroll** **Rate**.

This connector can also receive traps available in the Apantac MIB. When a specific trap is received, the relevant table is polled.

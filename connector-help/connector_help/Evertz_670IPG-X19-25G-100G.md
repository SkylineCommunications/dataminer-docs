---
uid: Connector_help_Evertz_670IPG-X19-25G-100G
---

# Evertz 670IPG-X19-25G-100G

This connector can be used to monitor and control the **Evertz** **670IPG-X19-25G-100G** media gateway device.

## About

### Version Info

| **Range**            | **Key Features**                       | **Based on** | **System Impact**                                                 |
|----------------------|----------------------------------------|--------------|-------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                       | \-           | \-                                                                |
| 1.0.1.x              | Adds redundant polling.                | 1.0.0.1      | Added interface for redundant polling.                            |
| 1.0.2.x \[SLC Main\] | Removed some unit tags and thresholds. | 1.0.1.2      | Potentially affects alarms, Visual Overviews, Automation scripts. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 2.9.2.r1.588           |
| 1.0.2.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

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

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The features of the connector include **SDI**, **Video IP**, **Audio IP**, **ANC IP**, **PTP Control**, and **SNMP Traps**.

The connector polls the device items in their own groups. Subtable methods are used to poll some of the tables.

You can enable or disable traps in the element, and the connector also receives traps. If a trap is not recognized by the connector, the element's log file will show the trap information.

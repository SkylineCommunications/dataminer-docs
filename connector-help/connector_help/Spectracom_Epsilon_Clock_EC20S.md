---
uid: Connector_help_Spectracom_Epsilon_Clock_EC20S
---

# Spectracom Epsilon Clock EC20S

This connector allows you to monitor and control the Spectracom Epsilon Clock EC20S clock distribution unit via SNMP.

The connector polls relevant information from the device every 15 seconds or 15 minutes. It can also receive traps from the device and update the corresponding values.

## About

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.6.11                 |

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

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The following data pages are available:

- **General**: Displays general information about the system, including the description, **firmware**, **uptime**, **contact**, etc.
- **Configuration**: Allows you to configure **thresholds**, **mute modes**, **date format**, etc. Via the **GNSS configuration** page button, you can update the defined latitude and longitude configuration. However, note that you need to click **Set Values** before you change the **GNSS Antenna Positioning Mode** to *User-Defined*.
- **General Status**: Displays information regarding the status of the device **not related to GNSS**.
- **GNSS Status**: Displays information regarding the GNSS status.

In addition, from version **1.0.0.5** onwards, a **Polling Configuration** page is available, which allows you to define the polling intervals for the following groups of parameters:

- **General**
- **Configuration**
- **GNSS** **Configuration**
- **General** **Status**
- **GNSS** **Status**
- **Best** **Satellites**
- **Traps**

By default, the polling intervals for these groups are 15 seconds for fast parameters and 15 minutes for slow parameters, and all polling for these groups is enabled.

In the **Polling Table**, you can configure the intervals in the **Time** column, enable or disable the polling in the **State** column, and poll a specific group on demand in the column **Refresh on Demand**.

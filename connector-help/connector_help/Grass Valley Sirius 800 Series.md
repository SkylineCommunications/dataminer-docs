---
uid: Connector_help_Grass_Valley_Sirius_800_Series
---

# Grass Valley Sirius 800 Series

The Grass Valley Sirius 800 Series products are hybrid video, audio, IP and 12G-SDI routers with integrated multi-viewers and four chassis options, from 288x288 to 1152x1152 I/O interfaces.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

To use this element, you need to configure the matrix level monitored by the element and the primary and secondary polling IPs.The matrix level default value is "1.1" and the default polling IP is the one configured while creating/editing the element.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver consists of the following data pages:

- **General**: Contains general status parameters and a table with all available matrix levels. Via the **Configurations** page button, you can configure driver polling settings such as the matrix level and the active polling IP.
- **Matrix**: Displays the matrix.
- **Router Control**: Displays the tables used by the driver to communicate with the Router Control application.
- **Routing**: Displays the **Inputs** and **Outputs** tables of the matrix.
- **Controller**: Displays the current device controller(s) status.
- **Alarms**: Contains a table where the device alarm events are logged.

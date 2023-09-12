---
uid: Connector_help_Radeus_Labs_ACU_DL9000
---

# Radeus Labs ACU DL9000

The 9000 ACU is compatible with industry-standard drive cabinet interfaces and legacy position feedback devices such as absolute rotary optical encoders, standard single-speed brushless size-11 resolvers, and two-speed brushless size-20 resolvers.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**        |
|-----------|-------------------------------|
| 1.0.0.x   | V9k-RC128 Database version 23 |

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

## How to use

The connector uses SNMP to retrieve data from the ACU, such as the **azimuth, elevation, and polarization** positions. All information regarding the status of the ACU can be found on the **Main View** and **General** pages.

To configure the ACU, you can use the subpages under **Settings**.

The **Status** page displays all the alarms possible for the ACU to allow for easy monitoring.

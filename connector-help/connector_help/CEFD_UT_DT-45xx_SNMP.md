---
uid: Connector_help_CEFD_UT_DT-45xx_SNMP
---

# CEFD UT DT-45xx SNMP

The CEFD UT DT-45xx SNMP is designed for the transmission of SCPC, DAMA, and TDMA signals in communication systems or satellite downlink data systems. These converters are also used in communication system applications with full transponder HDTV and analog TV.

## About

### Version Info

| **Range**            | **Key Features**                                | **Based on** | **System Impact**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
|----------------------|-------------------------------------------------|--------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                | \-           | \-                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| 1.0.1.x \[SLC Main\] | Force backup logic improved (see "How to Use"). | 1.0.0.6      | The Force backup parameter change has caused layout changes and parameter description changes, and parameters and a page button have been removed.<br>- SNMP parameter is now hidden (+ name changed) and a QAction is used to parse the information in order to display e.g. "Unit 01" instead of "01_Forced".<br>- The parameter to set this (including the button + logic) has been replaced with a dropdown menu containing all the available options. To create the information to be set on the hidden SNMP parameter, a QAction is now used. The parameter has also been renamed to match the SNMP parameter as it not only sets values but also displays current information. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.3.6                  |
| 1.0.1.x   | 1.3.6                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

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

This connector uses SNMP parameters to access and modify the device.

The Force Backup feature functions differently depending on the range. In the current main range, a single dropdown menu lists all units, including the "None" option. When you select a unit in the dropdown, the switch will immediately be executed.

The display value is also different in the 1.0.1.x range. Where previously it would for instance show "01_FORCED", it will now show "Unit 01".

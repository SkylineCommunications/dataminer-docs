---
uid: Connector_help_ZTE_ZXA10_C600
---

# ZTE ZXA10 C600

The ZXA10 C600 is large-capacity optical access equipment. It supports ultra-high bandwidth, big video, FMC, and network re-architecture, as well as carrier-class QoS and security.

This connector monitors the complete device and has several configuration options for data display and setup. Different possibilities are available for alarm monitoring and trending.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

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

## How to use

### General page

Two key parameters are included on this page:

- **DisplayKey Config**: If you have write permission, this parameter allows you to select the format for the Display Key column in the following tables: Ethernet Interfaces, PON Interfaces, PON Interfaces Status and Optic Status. The available options use the information extracted from the Iftable and IfXTable (ifDescription, IfName, IfAlias) and combine these in different ways:

- Alias
  - Name
  - Alias + Name
  - Name + Alias

- **DisplayKey Separator:** Works together with the DisplayKey Config parameter to fully customize the row identifier.

For example, imagine the If identifiers have the following values:

- Alias: My Interface
- Description: Test Interface
- Name: Interface01

The table below shows the possible display key format, depending on the selected options:

| **Separator (Quotes are ignored)** | **Alias**   | **Name**    | **Alias+Name**            | **Description+Alias**        | **Name+Alias**            |
|------------------------------------|-------------|-------------|---------------------------|------------------------------|---------------------------|
| "-"                                | MyInterface | Interface01 | MyInterface-Interface01   | Test Interface-MyInterface   | Interface01-MyInterface   |
| " - "                              | MyInterface | Interface01 | MyInterface - Interface01 | Test Interface - MyInterface | Interface01 - MyInterface |
| "/"                                | MyInterface | Interface01 | MyInterface/Interface01   | Test Interface/MyInterface   | Interface01/MyInterface   |

Note: Try to use separators that are not included in any of the interface identification fields. This will allow easier searching for alarm or trend information.

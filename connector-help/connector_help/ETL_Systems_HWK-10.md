---
uid: Connector_help_ETL_Systems_HWK-10
---

# ETL Systems HWK-10

Hawk Matrix is typically used for RF signal routing for LEO and MEO gateways, as well as small HTS ground stations and deployable VSAT terminals. The 1U Hawk Matrix has the capacity for two 8x8 matrix cards, which can be combining (fan-in) or distributive (fan-out), for uplink and downlink applications. It can be fitted with any combination of cards depending on the application, and it is ideally suited for smaller gateways with multiple modems and one or two antennas.

## About

### Version Info

| **Range**            | **Key Features**      | **Based on** | **System Impact** |
|----------------------|-----------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Two 8x8 matrix cards. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | HWK-10-D816-S5S5       |

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
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No additional configuration of parameters is necessary in a newly created element.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The connector contains two 8x8 matrices. You can set a crosspoint in the matrices by clicking the desired crosspoint in the matrix UI on the **Matrix View page**.

The **General page** will display the overall system health and the standard SNMP parameters (MIB RFC-1213).

Information about the different modules can be found on the **Modules page**.

CPU and PSU information is located on the corresponding **CPU and PSU pages**.

All crosspoint information (Inputs/Outputs/Locking/Blocking) can be consulted on the **Hawk Input** and **Hawk Output pages**.

## Notes

The initial version of this connector only allows manipulation of crosspoints. Locking and blocking are not implemented yet.

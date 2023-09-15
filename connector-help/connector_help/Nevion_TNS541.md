---
uid: Connector_help_Nevion_TNS541
---

# Nevion TNS541

The **Nevion** **TNS541 device** enables 1+1 redundancy switchover between two MPEG-2 transport streams. It provides a dual power supply and seamless switching, as well as continuous monitoring of both incoming MPEG-2 transport streams for status. It switches over automatically if required, based upon customizable criteria.

The **Nevion TNS541 connector** is mainly a **monitoring platform** for the most relevant parameters retrieved from the device. Some settings can also be adjusted by the user.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

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

## How to use

This connector mainly serves as a **monitoring platform**, where you can follow the behavior of the relevant parameters retrieved from the device.

Relevant parameters with numeric and discrete values can be included in an alarm or trend template as needed, so that DataMiner can generate alerts related to their values.

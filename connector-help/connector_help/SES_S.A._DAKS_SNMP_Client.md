---
uid: Connector_help_SES_S.A._DAKS_SNMP_Client
---

# SES S.A. DAKS SNMP Client

This driver will receive the SNMP traps from specific IP addresses configured by the user.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | No firmware            |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: *any*
- **IP port**: *161*

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

This driver uses an **SNMP** connection, but does not actively retrieve information. Instead, it receives **traps** from **multiple** **devices**, based on the IP addresses configured on the General page.

When the driver receives a trap, it will check the Text Message Negative column to see if the BCID needs to be sent to the Tetronik DAKS driver.

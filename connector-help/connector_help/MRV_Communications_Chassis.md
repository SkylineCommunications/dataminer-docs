---
uid: Connector_help_MRV_Communications_Chassis
---

# MRV Communications Chassis

The MRV Communications Chassis is a driver for an MRV chassis that houses MRV Communications modules.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | OD-5.14.1 (35924)      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**   |
|-----------|---------------------|-------------------------|-----------------------|---------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | MRV Communications Module |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device (default: *161)*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Redundancy

Redundancy is not defined in the driver.

## How to Use

The driver uses SNMP calls to poll the chassis. The information on the installed modules is retrieved in the same way.

This driver will export each installed module to a MRV Communications Module element.

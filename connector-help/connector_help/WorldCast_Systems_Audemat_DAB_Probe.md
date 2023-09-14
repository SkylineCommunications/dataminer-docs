---
uid: Connector_help_WorldCast_Systems_Audemat_DAB_Probe
---

# WorldCast Systems Audemat DAB Probe

The Audemat DAB Probe is a complete DAB radio monitoring solution to perform advanced signal analysis, on-site and in the broadcast coverage area.

## About

### Version Info

| **Range** | **Key Features**                                                     | **Based on** | **System Impact** |
|-----------|----------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. **TDF** only (**DataMiner 7.5**) with custom traps. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.1.2                  |

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
- **Bus address**: The bus address of the device.

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

The element consists of the following data pages:

- **General**: Contains general info about the device.
- **Channels**: Lists the current channels connected to the device.
- **Current alarms**: Lists the current active alarms in the device.
- **Service**: Contains the Info Service table, with information about the alarm status of each channel (based on traps).

## Notes

The 1.0.0.x connector range was created according to TDF requirements and must be compatible with DataMiner 7.5.

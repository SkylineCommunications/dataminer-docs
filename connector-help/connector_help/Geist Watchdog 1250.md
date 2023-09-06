---
uid: Connector_help_Geist_Watchdog_1250
---

# Geist Watchdog 1250

The Watchdog 1200 Series Environmental Monitoring Units are used to detect climate conditions in data centers. They provide remote environmental monitoring and alarms. Built-in sensors monitor temperature, relative humidity, airflow, light level, and sound level. Optional external sensors and network cameras are also available.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.16.4                 |

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

## How to use

With the **Temperature Precision** parameter on the General page, you can change the precision of all temperature values of all sensors to degrees or to tenths of a degree.

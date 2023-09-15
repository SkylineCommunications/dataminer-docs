---
uid: Connector_help_Harmonic_System_Manager
---

# Harmonic System Manager

This connector receives SNMP traps from the Harmonic Spectrum's System Manager for analysis and monitoring.

The System Manager acts as the administrative hub of a Spectrum media server installation. Its browser-based user interface allows users to make rapid adjustments to system configuration, integrate additional components, and identify fault conditions. The System Manager's fault reporting and alerting capabilities can head off issues before they become critical. It provides both facility-wide control, as well as active monitoring and alerting.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                         | **Based on** | **System Impact** |
|----------------------|--------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version. - Displays SNMP traps in a table. - Possibility to configure how long traps are displayed in the table. | \-           | \-                |
| 1.0.1.x \[SLC Main\] | REST API                                                                                                                 | 1.0.0.x      | New connection    |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 9.8.0.0.5              |

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
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: Default: *443*.
- **Bus address**: Default: *ByPassProxy*.

## How to use

The element consists of the following pages/subpages:

- **General:** Contains the Device Info table, which shows the data for all Spectrum servers monitored by the System Manager.
- **Media Store:** Displays media storage data for devices in the System Manager database.
- **Alarms:** Displays information from alarms received from the System Manager.
- **Alarm Settings:** Allows you to configure whether alarms should be automatically removed if they reach a certain lifetime in the element.

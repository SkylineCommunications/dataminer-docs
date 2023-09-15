---
uid: Connector_help_Broadpeak_BKS350
---

# Broadpeak BKS350

Broadpeak BKS350 is a packager streamer that improves multi-screen video delivery on managed or open internet networks.

This connector allows the real-time monitoring of BKS350 general information, server status, live streaming status and alarm information.

## About

### Version Info

| **Range**            | **Key Features**       | **Based on** | **System Impact**                                                         |
|----------------------|------------------------|--------------|---------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.       | \-           | \-                                                                        |
| 1.0.1.x \[SLC Main\] | HTTP connection added. | \-           | Existing elements will need to be reconfigured to use the new connection. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | 03.07.09.10076         |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.01x   | No                  | Yes                     | \-                    | \-                      |

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

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *8091*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## How to use

The element created with this connector consists of the following data pages:

- **General**: Contains general information, such as the current date and time, and the up time. Also shows the overall status of the equipment.
- **Live**: Contains a table with all live status parameters.
- **Alarm**: Shows the alarms that have occurred while the device was operational.
- **Output**: Contains a table that shows the output status along with the template name and output format.
- **Publishing**: Contains a table with all publishing status parameters.

## Notes

When you upgrade from range 1.0.0.x to 1.0.1.x, existing elements need to be reconfigured before the new connection will be taken in use.

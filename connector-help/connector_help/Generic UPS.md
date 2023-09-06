---
uid: Connector_help_Generic_UPS
---

# Generic UPS

This connector monitors the SNMP data retrieved from a generic UPS device. You can also use it to write directly to the device, configure the polling settings of various poll groups, as well as capture and manage SNMP traps.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                      | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version: - Reading SNMP data from the device and setting data on the device via SNMP. - SNMP trap management. | \-           | \-                |

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

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: 161).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This element consists of the following pages:

- **General**: Displays system information like Description and Uptime. Also displays the SysOR table of the device.
- **Battery Details**: Displays the battery status of the device.
- **Input Lines**: Displays information and statuses for the input lines.
- **Output Lines**: Displays information and statuses for the output lines.
- **Bypass Lines**: Displays information and statuses for the bypass lines.
- **Identification**: Displays manufacturing information of the device.
- **Alarms**: Displays the alarms captured by the device.
- **Tests**: Allows you to configure device tests and receive feedback from the device.
- **Configuration**: Allows you to configure settings that are written directly to the device.
- **Control**: Allows you to issue shutdown commands to the device system/output immediately or after a user-determined delay.
- **Polling Configuration Page**: Allows you to enable or disable polling of pages, as well as configure the frequency of SNMP polling for each page. You can also refresh specific pages or all pages with device data.
- **SNMP Page**: The SNMP Overview table allows you to enter information to retrieve data from specific OIDs.

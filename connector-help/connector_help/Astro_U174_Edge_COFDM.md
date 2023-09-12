---
uid: Connector_help_Astro_U174_Edge_COFDM
---

# Astro U174 Edge COFDM

With this driver, you can gather and view information from the device Astro U174, as well as configure the device. The Astro U174 is an IP-to-COFDM converter. This driver uses HTTP to monitor the device. The driver also has an SNMP interface to receive traps from the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5667                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### SNMP SNMP Trap Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver has the following data pages:

- **General**: Displays general information about the device, such as the Device Manufacturer, Uptime and Physical Location.
- **Status**: Displays the status of the device, with parameters such as Temperature, Power Supply and CPU Load.
- **Main**: Allows you to update the main configuration of the device, e.g. DNS, Time Source and Interfaces.
- **Test Gen**: Allows you to configure the test gen parameters, e.g. Data Rate and Packet ID.
- **IP RX**: Displays information about the input IP channels.
- **RF**: Displays information about the output RF channels.
- **System Log**: Allows you to configure the system log settings.
- **Update/Config**: Contains the FTP settings for the device's firmware update.
- **Alarm Severities**: Displays the severities of the possible alarms.
- **Active Alarms**: Displays a table with the current alarms of the device.

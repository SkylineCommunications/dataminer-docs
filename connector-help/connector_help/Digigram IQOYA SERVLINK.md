---
uid: Connector_help_Digigram_IQOYA_SERVLINK
---

# Digigram IQOYA SERVLINK

This connector can be used to gather and view information from the device Digigram IQOYA SERVLINK. It also allows you to configure the device.

The connector uses an SNMP connection to communicate with the device and also processes traps sent by the device.

## About

| **Range**            | **Key Features**                                                           | **Based on** | **System Impact**                                                                                                                                                                                                                                                                        |
|----------------------|----------------------------------------------------------------------------|--------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                           | \-           | \-                                                                                                                                                                                                                                                                                       |
| 2.0.0.x \[SLC Main\] | Changed protocol name to the correct name "Digigram" instead of "Digiram". | 1.0.0.2      | Live Update will be broken.Elements will need to use the new connector, which means that existing configurations for monitoring, reports, filters, and Automation scripts may need to be modified.If you are using an "allowed protocols" license, your license may need to be adjusted. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v02.05f001             |
| 2.0.0.x   | v03.08e001             |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

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

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General

The Generalpage contains general information about the device as well as GPIO counters. It also allows you to select how you want to access the web interface of the device, i.e. through an HTTP or an HTTPS connection.

The following page buttons are available:

- **Preferences**: Displays information about system failures, an audio codec count, and an option to define the Audio Core Sample Rate.
- **Firmware Updates**: Displays a table that allows actions such as installing or removing a firmware version.
- **Serial Port**: Displays tables with information about the serial ports of the device.
- **Clock**: Contains a table with the name of all the possible clocks to be used and information about the clock status. You can select a clock to use.

### Audio

This page contains tables with the states and the parameters of the audio input and output channels, a table with the audio bus configuration, and a table for the audio format managed by the device.

### Send

The Send page contains a table with the states and the parameters of the different programs, a table that allows you to view and declare the IP services to be streamed over IP, and a table with the URL of each destination.

### Receive

The Receive page is similar to the Send page. It contains a table with the information about the programs list, a table with network metrics available on the main sources and backups, and a table with information about the priority of the receivers.

### Network

This page contain status and other information about Vlans and Ethernet interfaces available on the device.

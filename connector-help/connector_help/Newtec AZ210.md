---
uid: Connector_help_Newtec_AZ210
---

# Newtec AZ210

This driver allows you to monitor and control a Newtec AZ210 1+1 modulator redundancy switch. General information about the device can be retrieved, alarms are retrieved and modulator redundancy can be viewed and set. The information is polled over a serial connection using the RMCP protocol.

## About

### Version Info

| **Range**            | **Key Features**                                            | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------|--------------|-------------------|
| 1.1.10.x             | Config ID: M1114; Software ID: 6369; Software Version: 1.10 | \-           | \-                |
| 1.1.11.x             | Config ID: M1114; Software ID: 6369; Software Version: 1.11 | \-           | \-                |
| 1.1.3.x \[SLC Main\] | Config ID: M1114; Software ID: 6369; Software Version: 1.03 | \-           | \-                |
| 2.1.11.x             | Config ID: N0047; Software ID: 6369; Software Version: 1.11 | \-           | \-                |
| 2.1.3.x              | Config ID: N0047; Software ID: 6369; Software Version: 1.03 | \-           | \-                |
| 3.1.14.x             | Config ID: M1125; Software ID: 6369; Software Version: 1.14 | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**       |
|-----------|------------------------------|
| 1.1.10.x  | M1114, Id 6369, version 1.10 |
| 1.1.11.x  | M1114, Id 6369, version 1.11 |
| 1.1.3.x   | M1114, Id 6369, version 1.03 |
| 2.1.11.x  | N0047, Id 6369, version 1.11 |
| 2.1.3.x   | N0047, Id 6369, version 1.03 |
| 3.1.14.x  | M1125, Id 6369, version 1.14 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.1.10.x  | No                  | Yes                     | \-                    | \-                      |
| 1.1.11.x  | No                  | Yes                     | \-                    | \-                      |
| 1.1.3.x   | No                  | Yes                     | \-                    | \-                      |
| 2.1.11.x  | No                  | Yes                     | \-                    | \-                      |
| 2.1.3.x   | No                  | Yes                     | \-                    | \-                      |
| 3.1.14.x  | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: The port of the destination, default: *5933.*
- **Bus address**: The bus address of the device, default: 100.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the following data pages:

- **General**: Displays general device information, as well as the internal temperature. Contains page buttons to the Device info, Security, Display, Power Supply, Serial, and Ethernet subpages.
- **Config**: Allows you to configure the modulator redundancy modulator and mode.
- **Alarms**: Shows all the current alarms.

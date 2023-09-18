---
uid: Connector_help_Tecsys_TS_9090
---

# TECSYS TS 9090

The **TECSYS TS 9090** is a media encoder solution for audio and video. This connector allows you to view and modify data related to this device.

## About

### Version Info

| **Range** | **Key Features**   | **Based on** | **System Impact** |
|-----------|--------------------|--------------|-------------------|
| 1.0.0.x   | Initial version.   | \-           | \-                |
| 1.1.0.x   | New firmware.      | \-           | \-                |
| 1.1.1.x   | DCF feature added. | 1.1.0.1      | \-                |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.09                        |
| 1.0.1.x          | 1.20                        |
| 1.1.1.x          | 1.20                        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

This connector allows you to access various information on the device. You can get data on each individual **Input RF** and **Input ASI** of the quad processor. You can also set different values for this same data. The connector also provides **media port** information and system information.

The following pages are available:

- **General**: Displays system information, including the **firmware** and **FPGA version**.
- **Input RF**: Provides information on the RF signal. Per Rx input, you can find the Channel Name, Rx Frequency, Rx CN Level, Rx Destination IP, etc.
- **Input ASI**: Provides information on the ASI signal. Per ASI, you can find the ID, destination IP, destination port, etc.
- **Media Port**: Allows you to view and modify data related to the media port of the device. Only the **Original MAC** parameter is not editable. Other parameters on this page are the Transport Type, Original IP, Output TS Packets, Time to Live, etc.

## Notes

When IP and MAC addresses are specified, these are checked to ensure compliance with each of these 2 types of strings. If an invalid IP or MAC address is specified, its value is not changed on the device or DMA element, and a log message is created.

---
uid: Connector_help_Newtec_2280
---

# Newtec 2280

The Newtec 2280 driver uses a serial connection to monitor and configure the corresponding device. Alarm monitoring and trending can be configured for most parameters.

## About

### Version Info

| **Range**            | **Key Features**                        | **Based on** | **System Impact** |
|----------------------|-----------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                         | \-           | \-                |
| 1.0.3.x              | Software version 3                      | 1.0.0.x      | \-                |
| 2.0.0.x              | Software version 2, software ID 6241    | 1.0.0.x      | \-                |
| 2.2.4.x              | Software version 2.4, software ID 6241  | 2.0.0.x      | \-                |
| 2.2.42.x             | Software version 2.42, software ID 6241 | 2.2.4.x      | \-                |
| 2.6.1.x \[SLC Main\] | Software version 6.2, software ID 6279  | 2.2.42.x     | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |
| 1.0.3.x   | v3                     |
| 2.0.0.x   | 2.0                    |
| 2.2.4.x   | 2.4                    |
| 2.2.42.x  | t2.42_RC1              |
| 2.6.1.x   | 6.2                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 2.6.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

#### Serial original Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (fixed value: *5933*).
  - **Bus address**: The bus address of the device (default: *100*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver has the following data pages:

- **General**: Contains general parameters, as well as page buttons to the following subpages: Device Info, Display, Power Supply, Security, Ethernet, Serial, Outdoor, Internal, External, Config and Test.
- **Modulator**: Displays information about the modulator, such as frequency, bit rates and output level. Also contains page buttons to the following subpages: NCR, BBFraming, PHLA, Additional, BER, BISS, Rate Adapter, Frames and Packets.
- **Alarms**: Displays the status of more than 30 alarms that can occur on the device. Many of the parameters on this page can be configured for alarm monitoring in an alarm template in DataMiner Cube.

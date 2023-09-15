---
uid: Connector_help_CPI_K4U74
---

# CPI K4U74

## Important note

This connector has been reviewed and is now available as a more generic connector: **CPI KHPA Gen IV Series Binary Version**.

Please use this new updated version instead of the version detailed below.

## About

This is an obsolete connector that was used to monitor a CPI K4U74 high-power amplifier.

It uses a serial connection to monitor the state of the HPA itself and to control the waveguide switches in order to allow redundancy switching between up to 10 other HPAs.

### Version Info

| **Range** | **Key Features**                                 | **Based on** | **System Impact** |
|-----------|--------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version                                  | \-           | \-                |
| 1.1.0.x   | New firmware that uses variable response lengths | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
|-----------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | Front Panel Boost Kernel Software Version: 03.00.13 Front Panel Main Program Software Version: 03.01.72 Power Supply Boot Kernel Software Version: 03.00.03 Power Supply Main Program Software Version: 03.01.34 RF Controller Boot Kernel Software Version: 03.00.03 RF Controller Main Program Software Version: 03.01.42 Ext Interface Boot Kernel Software Version: 03.00.03 Ext Interface Main Program Software Version: 03.01.54 Can Communication Level Key: 03.01.22 ID Version: GEN4 2003 |
| 1.1.0.x   | Front Panel Main Program Software Version: 03.01.85 Power Supply Main Program Software Version: 03.01.40 RF Controller Main Program Software Version: 03.01.46 Ext Interface Main Program Software Version: 03.01.62                                                                                                                                                                                                                                                                               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device.
- **Bus address**: The bus address of the connected device's relay processor, ranging from *17* up to and including *255*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element consists of the following data pages:

- **General**: Displays system information and information about software versions.
- **Measurements**: Displays the values for the current, voltage, power, UPC information, and temperature.
- **Switch Controller**: Displays information about Switch Position and Switch Controller amplifier channels.
- **Settings**: Contains configurable parameters, such as time and amplifier settings.
- **Alarms**: Displays the alarm status for all monitored parameters. Subpages are available with more specific alarm information.

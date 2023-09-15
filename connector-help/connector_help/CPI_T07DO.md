---
uid: Connector_help_CPI_T07DO
---

# CPI T07DO

The CPI T07DO is a 750 W outdoor TWT amplifier for satellite communication, designed for outdoor operation.

This connector communicates with the device using serial commands as described in the manual of the device.

## About

### Version Info

| **Range**            | **Key Features**                                                       | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                                       | \-           | \-                |
| 1.1.0.x              | Status command new response format.                                    | 1.0.0.2      | \-                |
| 1.2.0.x \[SLC Main\] | Changed the structure of "Status" response because of firmware update. | 1.0.0.3      | \-                |

### Product Info

| **Range**            | **Supported Firmware**                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
|----------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Main Boot Kernel Software Version: **01.00.00** Main Panel Software Version: **02.00.88** PS Controller Boot Kernel Software Version: **02.00.01** PS Controller Main Software Version: **02.00.53** BIPA Controller Boot Kernel Software Version: **02.00.01** BIPA Controller Main Program Software Version: **02.00.45** RF Controller Boot Kernel Software Version: **02.00.01** RF Controller Main Software Version: **02.00.33** CAN Communication Level Key: **01.00.73** |
| 1.1.0.x              | \-                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| 1.2.0.x \[SLC Main\] | Main Boot Kernel Software Version: **01.00.00** Main Panel Software Version: **02.01.96** PS Controller Boot Kernel Software Version: **02.00.05** PS Controller Main Software Version: **02.00.98** BIPA Controller Boot Kernel Software Version: **02.00.01** BIPA Controller Main Program Software Version: **02.00.87** RF Controller Boot Kernel Software Version: **02.00.05** RF Controller Main Software Version: **02.00.62** CAN Communication Level Key: **01.01.06** |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.2.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **Type of Port**: TCP/IP
  - **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
  - **IP port**: The IP port of the device, by default *50000*.
  - **Bus address**: The bus address of the device, by default *48*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element has the following data pages:

- **General**: Displays general information about the device. Via the **Set Time** page button, you can set the **Amplifier** **Name and** the **Time** of the device.
- **Amplifier Status**: Allows you to visualize several measurement points related to the amplifier and configure some important features on the device.
- **Switch Controller**: Displays information related to the switch controller. You can also change the switch controller settings here.
- **Set Points**: Use this page to set the fault and alarm trip points. Use the **Limits** page button to check the limits of the device before an alarm or fault is triggered.
- **System Status**: Allows you to check any fault on the device.
- **Alarm**: Displays the active alarms.
- **Log**: Allows you to log entries from the device. To do so, first set the **Log Entry Number To Get** and then the **Log Entry Units To Get**. Click **Get Entry** to send the command to the device. If you retrieve the same entry number but with different units, this will overwrite the row with the same entry number.

## DataMiner Connectivity Framework

The **1.2.0.x** connector range of the CPI T07DO protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

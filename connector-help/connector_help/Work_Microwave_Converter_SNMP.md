---
uid: Connector_help_Work_Microwave_Converter_SNMP
---

# Work Microwave Converter SNMP

This SNMP connector is used to monitor and configure the various Work Microwave Converters that use the conv2 MIB.

## About

The **Work Microwave Converter SNMP** connector is a full implementation of the conv2 MIB from Work. As such, this connector can be used for any Work Microwave that uses the conv2 MIB.
The connector allows the user to monitor the converter and to configure the system and converter.

### Version Info

| **Range**     | **Description**                                                                                                                | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                                                                                                                | No                  | Yes                     |
| 1.1.0.x \[SLC Main\] | Added frequency and attenuation channel band parameters that will replace the existing ones. Changed snmpSet to snmpSetAndGet. | No                  | Yes                     |

### Product Info

| **Range**     | **Device Firmware Version** |
|----------------------|-----------------------------|
| 1.0.0.x              | Unknown                     |
| 1.1.0.x \[SLC Main\] | XNA01.73                    |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required for this connector.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### Main View

This page displays the various converter temperatures as well as some general information, such as the **Base System ID**, **Device ID**, and **Date & Time**. It also displays the **System Status** and the **Converter Status** (in hex). To view more information about these status values, click the **Detailed Converter Status** or the **Detailed System Status** page button.

The page also contains the following page buttons:

- **Stored Events**: Displays the Stored Events Table.
- **Alarms**: Displays the Stored Alarms Table.
- **MC Interface**: Displays the MC interface table.
- **SNMP**: Displays the Trap Sink Server Table.
- **Device Info**: Displays additional device information (various IDs, **Load** and **Save Device State** options, as well as the **Autosave** option).

### Converter Config

On this page, you can configure various converter settings. This includes the **Sweep** settings, **Min Frequency**, **Max Frequency** and **Frequency Offset**.

There are also three buttons that link to **Channel Config** pop-up pages. On each of these pages, you can set the **Frequency**, **Attenuation** and **Equalizer** for the channel and band (band only for channel 1 and 2) in question. For channel 1, you can also set the **IF frequency**.

### System Config

On this page, you can view and configure the system settings. The page also has five page buttons that can also be found on the **Main View** page.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to access the web interface.

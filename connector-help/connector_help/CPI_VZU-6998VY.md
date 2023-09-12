---
uid: Connector_help_CPI_VZU-6998VY
---

# CPI VZU-6998VY

The CPI VZU-6998VY is a 750 W High-Power Amplifier (HPA). This driver uses serial communication to communicate with the device.

## About

### Version Info

| **Range**            | **Key Features**                         | **Based on** | **System Impact** |
|----------------------|------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                          | \-           | \-                |
| 1.1.0.x \[SLC Main\] | Ranges changed for RF output parameters. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**     |
|-----------|----------------------------|
| 1.0.0.x   | 750WNC 0 02.00.06 01.00.39 |
| 1.1.0.x   | 750WNC 0 02.00.06 01.00.39 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Bus address**: The bus address of the device.

## How to Use

The element consists of the data pages detailed below.

### Main View

Contains important information related to the device itself, e.g. High Reflected RF Fault, RF Output Power (dBm), Helix Voltage, System State.

### General Control

Contains general settings such as High Tube Temperature Alarm Trip Point, Heater Time Delay, RF Inhibit and System State.

### Control RF Output

Contains the configuration of RF output power and ALC RF output power in dBm, W, or dBW.

### Meter Query

Displays measured values such as the RF Output Power (dBm), Reflected RF, Helix Voltage and Cabinet Temperature.

### Linearizer Query

Displays linearizer values as well as offset values such as Gain, Phase Offset and Magnitude.

### Configuration

Contains configuration parameters such as Linearizer Installed, Switch System Configuration and Relay 1 Configuration.

### Status Info

Displays alarm states such as External Interlock Fault, DC Bus Fault, Helix Over Voltage Fault and BUC Fault.

The following page buttons are available:

- **Secondary Status**: Displays alarm states and settings, such as Low RF Alarm, Tube Over Temperature Alarm, CIF Control and Power Sensor Failure.
- **Summary Status**: Displays additional parameters such as ALC, W/G Switch Controller Mode, Latched Fault and Transmit Request.
- **Normalize Alarms**: Allows you to configure normalization of the RF Output Power in dBm, W and dBW, using the parameters Nominal RF Output Power (dBm), Nominal RF Output Power (W) and Nominal RF Output Power (dBW).

### Log

Allows you to retrieve a log entry and to set the Auto Log Time. For each entry, the following information is shown: Entry Date and Time, Activity Type, Log Attenuation, Log Fan Control Voltage, etc.

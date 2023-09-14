---
uid: Connector_help_Work_Microwave_Modulator_DVBCID_DVB2SX
---

# Work Microwave Modulator DVBCID/DVB2SX

This connector polls status parameters and allows you to edit the configuration of **Work Microwave Modulator DVBCID/DVB2SX** devices.

## About

Communication happens via **SNMP**. The main method used for table polling is *multipleGetBulk*.

This connector is compatible with "XNA" software units (base firmware starts with XNA).

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range**     | **Device Firmware Version**                                                           |
|----------------------|---------------------------------------------------------------------------------------|
| 1.0.0.x \[SLC Main\] | MCU Base Firmware: XNA01.65 MCU Device ID: FNA00.00 MCU Modulator Module ID: BBA01.25 |
| 1.0.0.2              | MCU Base Firmware: XNA01.73                                                           |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *62.245.205.52*.
- **Device address**: Required. The port on which the web interface is listening.

SNMP Settings:

- **Port number**: The port of the connected device, e.g. *4161*.
- **Get community string**: The community string used when reading values from the device, e.g. *public*.
- **Set community string**: The community string used when setting values on the device, e.g. *private*.

## Usage

### Modulator Configuration

On this page, you can edit the following parameters:

- **Signal Configuration** parameters, such as the **MCU Level**, **MCU Symbol Rate** or **MCU Spectrum Inversion**.
- **Overall Stream Configuration** parameters, such as **MCU Stream Mode**, **MCU S2 Short BCH Code** and **MCU Still Picture VID**.

In the **BISS Settings** section, you can set the **MCU BISS Clear SW**, **MCU BISS Encrypted SW** and **MCU BISS Injected ID**.

A number of page buttons provide access to **Single Stream Configuration**, **Stream Input...A/B Settings**, **Carrier ID** and **Predistortion** parameters.

### Monitor

This page provides access to the following status parameters: **MCU Front Panel Temperature**, **MCU Modulator Temperature**, **MCU Modulator Chip Temperature**, **MCU Converter Temperature**, **MCU Converter Synthesizer Temperature**, **MCU Bias Tee Voltage** and **MCU Bias Tee Current**.

The **DC Voltages** page button displays the **MCU DC Voltages Table**. The **Modulator Monitor** page button provides access to parameters such as **MCU IF Signal Level**, **MCU Bandwidth 3 dB** and **MCU Input Fill Level**.

### System Configuration

On this page, you can among others find the following parameters: **MCU Autosave, MCU Freq Max** and **MCU External Mute Input.**

Page buttons provide access to **Device State**, **M&C Interface Settings**, **SNMP** and **Firmware Version** parameters.

### Status

On this page, several alarms are displayed: **Mod. Communication (Alarm)**, **EEPROM (Warning)**, **LCD (Warning)**, **EEPROM (Warning)**, **SNMP (Warning)**, **NTP Communication (Warning)**, etc.

There are also page buttons that allow access to **MCU Interface Status Parameters,** **Modulator Status, Channel Status, Stored Events** and **Stored Alarms.**

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (1.0.0.2, 1.0.0.3)

### Modulator Configuration

On this page, you can edit the following parameters:

- **Signal Configuration** parameters, such as the **MCU Level**, **MCU Symbol Rate** or **MCU Spectrum Inversion**,
- **Overall Stream Configuration** parameters, such as **MCU Stream Mode**, **MCU S2 Short BCH Code** and **MCU Still Picture VID**.

In the **BISS Settings** section, you can set the **MCU BISS Clear SW**, **MCU BISS Encrypted SW** and **MCU BISS Injected ID**.

A number of page buttons provide access to **Single Stream Configuration**, **Stream Input...A/B Settings**, **Carrier ID** and **Predistortion** parameters. There are also page buttons that provide access to the **MCU MTS Channels Table** and **MCU** **TSoIP Channels Table.**

### Monitor

This page provides access to the following status parameters: **MCU Front Panel Temperature**, **MCU Modulator Temperature**, **MCU Modulator Chip Temperature**, **MCU Converter Temperature**, **MCU Converter Synthesizer Temperature**, **MCU Bias Tee Voltage** and **MCU Bias Tee Current**.

The **DC Voltages** page button displays the **MCU DC Voltages Table**. The **Modulator Monitor** page button provides access to parameters such as **MCU IF Signal Level**, **MCU Bandwidth 3 dB** and **MCU Input Fill Level.**

### System Configuration

On this page, you can among others find the following parameters: **MCU Autosave, MCU Freq Max** and **MCU External Mute Input**.

Page buttons provide access to **Device State**, **M&C Interface Settings**, **SNMP** and **Firmware Version** parameters.

### Status

On this page, several alarms are displayed: **Mod. Communication (Alarm)**, **EEPROM (Warning)**, **LCD (Warning)**, **EEPROM (Warning)**, **SNMP (Warning)**, **NTP Communication (Warning)**, etc.

There are also page buttons that allow access to **MCU Interface Status Parameters,** **Modulator Status, Stored Events** and **Stored Alarms.**

### Traps (from version 1.0.0.3 onwards)

Traps received from the device are displayed on this page in the **Traps** table. At the top of the page, you can choose whether traps are displayed in the table (*Add to Table*) or directly displayed in the Alarm Console (Create Alarm).

On the **Auto Clear** page, you can set up methods to automatically set limits on the number of rows in the Traps table.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

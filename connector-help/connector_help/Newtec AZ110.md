---
uid: Connector_help_Newtec_AZ110
---

# Newtec AZ110

The AZ110 is a satellite modulator used for broadcast contribution, DSNG and distribution applications over satellite in compliance with the DVB standards. This driver allows you to monitor this device via SNMP.

## About

### Version Info

| **Range** | **Key Features**                        | **Based on** | **System Impact** |
|-----------|-----------------------------------------|--------------|-------------------|
| 1.6.55.x  | Software version 6.55, Software ID 6279 | \-           | \-                |
| 1.7.02.x  | Software version 7.02, Software ID 6279 | \-           | \-                |
| 1.8.31.x  | Software version 8.31, Software ID 6279 | \-           | \-                |
| 2.2.30.x  | Software version 2.30, Software ID 6241 | \-           | \-                |
| 3.2.47.x  | Software version 2.47, Software ID 6241 | \-           | \-                |
| 3.2.56.x  | Software version 2.56, Software ID 6241 | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.6.55.x  | ID 6279, version 6.55  |
| 1.7.02.x  | ID 6279, version 7.02  |
| 1.8.31.x  | ID 6279, version 8.31  |
| 2.2.30.x  | ID 6241, version 2.30  |
| 3.2.47.x  | ID 6241, version 2.47  |
| 3.2.56.x  | ID 6241, version 2.56  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.6.55.x  | No                  | Yes                     | \-                    | \-                      |
| 1.7.02.x  | No                  | Yes                     | \-                    | \-                      |
| 1.8.31.x  | No                  | Yes                     | \-                    | \-                      |
| 2.2.30.x  | No                  | Yes                     | \-                    | \-                      |
| 3.2.47.x  | No                  | Yes                     | \-                    | \-                      |
| 3.2.56.x  | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial main connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP of the device.
  - **Bus address**: The bus address of the device, with a default of 100.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the data pages detailed below.

### General

This page displays general information about the device, such as the **Hardware ID** and **Internal Temperature.**

Page buttons provide access to additional information and settings:

- **Power Supply**: Displays the voltage levels of each power supply.
- **Display**: Allows you to configure the **Display Contrast**, **Screensaver Delay** and **Screensaver Message**.
- **Device Info**: Displays the version, ID, and capability information of the device's modules.
- **External**: Displays the **Ext. LO Frequency**, **Ext. Spectrum Inversion** and **Tx Clock Offset**.
- **Internal**: Displays internal 10 MHz information and configuration parameters.
- **Interface**: Allows you to configure interface A and B **Auto Negotiation**, **Force Speed** and **Speed Advertisement.**
- **Serial**: Allows you to configure the **Serial Interface Type, Device Address** and **Serial Baudrate.**
- **Ethernet**: Displays the device Ethernet information and configuration.
- **Security**: Displays the **Expert Password** and **License Key**.
- **Test**: Allows you to test some of the functionalities of the modulator.
- **Configuration**: Allows you to save and load the configuration of the device.
- **Redundancy**: Allows you to configure the modulator redundancy parameters.

### Modulator

This page displays configuration of the modulator parameters for the device.

Page buttons provide access to additional information and settings:

- **PHLA**: Displays PHLA configuration parameters of the device.
- **BBFraming**: Allows you to configure the **DVB-S2 DFL Encapsulation Mode**, **Baseband Data Field Length**, **Baseband Sync Distance** and **Baseband ISI**.
- **BISS**: Allows you to configure the modulator BISS parameters.
- **BER**: Allows you to configure the **BER Counter Input Selection**, and execute a BER counter reset or initialization.
- **Additional Configuration**: Displays additional information and allows you to configure the **Pilot Insertion**, **FEC Frame Type, Output Level Plan** and **Baseband Processing Mode**.
- **Modulation Packets**: Displays the **Input Packet Count, Input Packet Rate, Estimated Packetrate** and **Packet Count**.
- **Modulation Frames**: Displays the **Dummy PL Rate, Dummy PL Count, PL Efficiency, BBL Efficiency** and **Short Frames**.

### Alarms

This page contains the alarm status of the various functions of the driver. You can also clear the **Memorized Alarm Status**.

### Web Interface

This page contains an embedded web browser directed to the IP address of the UC-IRD+. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

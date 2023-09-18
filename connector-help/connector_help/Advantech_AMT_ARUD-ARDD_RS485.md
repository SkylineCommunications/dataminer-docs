---
uid: Connector_help_Advantech_AMT_ARUD-ARDD_RS485
---

# Advantech AMT ARUD-ARDD RS485

Using serial communication via the RS485 port, this connector monitors the status of the Advantech AMT ARUD-ARDD frequency converter and performs certain control functions on the device.

## About

As the RS-485 interface of the ARUD-ARDD frequency converter has a completely different command structure compared to the RS-232 version, this specific connector is necessary.

The interface uses a packet structure, with each packet consisting of 7 bytes of information. The packets can be either a command or a response message. The device will only accept a command if the first byte contains the appropriate address of the device. If the address of the packet does not match the address of the device, the command is ignored. The last (7th) byte of the packet is a checksum, which is calculated as the sum of byte 1 to 6. If the checksum is incorrect, the command is not executed and no response message is sent. The second byte is the command or data request. The 3rd through 6th byte can be used for command or response data. Unused bytes are set to 0xAA.

### Version Info

| **Range** | **Description**          |
|------------------|--------------------------|
| 1.0.0.x          | Initial version          |
| 1.1.0.x          | Support for firmware 0.5 |

### Product Info

| **Range** | **Supported Firmware Version** |
|------------------|--------------------------------|
| 1.0.0.x          | 01                             |
| 1.1.0.x          | 0.5                            |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: 9600
  - **Databits**: 8
  - **Stopbits**: 1
  - **Parity**: None
  - **FlowControl**: None

- Interface connection *(if using a serial gateway):*

  - **IP address/host**: The polling IP of the gateway.
  - **IP port**: The IP port assigned to the device's serial port on the gateway.
  - **Bus address**: Required. The address of the device. Valid range: *1 - 15*. Default: *1.*

## Usage

### General

You can find the following information on this page:

- **Switch Output:** Shows which module is the current output of the device. Can be *"A"* or *"B".* A toggle switch allows you to switch the output.

- **Device Address:** Shows the current address of the device, and allows you to change it. The valid range for the address is *1 - 15*.

  > [!NOTE]
  > If you change the device address, you also have to change the **Bus Address** of the device in order for the connector to continue communication. You can do this by right-clicking the device in the Surveyor and selecting **Edit**. Then, under **More TCP/IP** **settings**, change the bus address to match the address you entered for the parameter. Communication will then be re-established.

- **Unit Type:** Describes whether the unit is an *Up Converter* or a *Down Converter*.

- **Frequency Conversion Type**: Describes the type of frequency conversion.

- The **Software Version** of the unit and the **Unit Serial Number**.

- **Unit Temperature**: The temperature in degrees Celsius as measured by the sensor on the main controller.

### Modules

This page shows the status and configuration of Module A and Module B of the device:

- **Communication Status**: Indicates whether the main controller can communicate with the module.
- **RF Output Status**: Indicates whether the output of the module is *ON* or *OFF (muted*).
- **Summary Alarm**: Indicates whether a summary alarm is triggered on the device.
- **Switch Status**: Indicates whether the unit is *Online* or in *Standby* mode.
- **Gain**: The configurable gain of the unit. The valid range of values is described by the **Gain Range** below this.
- **Temperature**: The temperature measured (in degrees Celsius) by the sensor on the module.
- **Reference Status**: The current state of the reference signal. Possible values are *Internal Reference*, *External Reference* or *Alarm*.

---
uid: Connector_help_SpacePath_Communications_N6143_Controller_Series
---

# SpacePath Communications N6143 Controller Series

The **SpacePath Communications N6143 Controller Series** connector is used to monitor and configure the SpacePath Communications N6143 Controller Series **control unit**. This control unit can be used to control several types of **stellar amplifiers**.

## About

The connector communicates with the control unit through its **serial interface**. The control unit itself controls up to two stellar amplifiers. This connector will control only one amplifier per instance. To send commands to the correct amplifier, the connector has to know the **address** of the amplifier. You can find this address on the physical display of the control unit. It should be entered as a decimal value in the **Bus address** field of the DataMiner **element**.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                       |
|------------------|---------------------------------------------------|
| 1.0.0.x          | Complies with N6143 Series Operation Manual; 2015 |

## Installation and configuration

### Creation

#### Main Serial Connection

This connector uses a serial connection and requires the following input during element creation.

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: 9600 baud
  - **Databits**: 7 bits
  - **Stopbits**: 1 bit
  - **Parity**: Even
  - **FlowControl**: No

- Interface connection:

  - **IP address/host**: The IP address of the intermediate serial gateway.
  - **IP port**: The port specified by the intermediate serial gateway.
  - **Bus address**: The address of the amplifier connected to the control unit.
    You can find this address on the physical display of the control unit, in hexadecimal value (0x30 - 0x6F). This value has to be converted to a decimal before it is entered in DataMiner. For example: 0x30 is 48, 0x6F is 111.

## Usage

### General

This page contains an overview of the connected amplifier with its **Type** and **Firmware Version**. It shows how long and in which states the amplifier has been operational.

In addition, it displays the following key High Power Amplifier information: the **Current State**, **Attenuation**, **Helix Current** and **Forward Power**.

Finally, the **Linearizer State** is also displayed.

Note that some parameters will have the value ***Not Applicable***. This means that the value is not applicable for the currently connected amplifier.

### Configuration

On this page, you can configure multiple amplifier settings:

- The most important setting is the **Current State** of the amplifier. If the state is changed from *Off* to *Standby* or *Transmit*, the amplifier will need some time to warm up its traveling wave tube. This will take 180 s.
- The **Redundancy Mode** can be switched from *Manual* to *Automatic* mode.
- The **Output** can be set to a *Load* or an *Antenna*.
- The **Attenuation** is a nominal value that depends on the connected amplifier. If this value is zero, there will be no attenuation or maximum gain.
- The **Radio Frequency (RF) Status** can be enabled or disabled.
- The **Remote Status** can also be enabled or disabled. Note that when it is disabled, the other configuration commands will not work.
- The amplifiers alarms can also be configured here. An alarm will be triggered when the **Forward Power** of the amplifier is above the **High Power Alarm Threshold** or below the **Low Power Alarm Threshold**. When one of the values is zero, that threshold will be ignored.

### Alarms

This page contains multiple alarms in several categories: **Cooling Alarms**, **Voltage Alarms**, **Component Alarms**, **Power Alarms** and **Helix Alarms**.

Note that when one of these alarms has the value ***Not Applicable***, it is not supported by the currently connected amplifier.

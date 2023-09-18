---
uid: Connector_help_Funea_NEC-E
---

# Funea NEC-E

The **NEC-E** module is a controller used to manage, supervise and control other modules in one chassis.

## About

The **Funea NEC-E** connector is able to create virtual connectors for different module types. For more information on the supported modules, refer to the Notes section below. These virtual connectors represent the devices inside a chassis. They also make it possible for users to monitor and configure the devices as if they were using the web interface.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

When the element is created, it can take several minutes before everything is initialized. The devices in the chassis are automatically detected and their connectors are also automatically created. If a device's module is not supported, then no connector is created.

For more information on which modules are supported, refer to the Notes section.

## Usage

### Device Overview

The given table serves as a summary for the chassis. It shows which devices are present and which slot they use. Their **Status, Alias Name** and **Software Release** are also available.

### Status

The **Status Table** gives a summary of all the errors that are present in the chassis. Every DVE has their own **Status** page specific for a device.

### General Purpose I/O

It is possible to configure the description, mode and level of the 12 I/O ports of the NEC-E device. Six of these ports are general purpose inputs and six are general purpose inputs/outputs.

### Event Log

The table keeps a record of all traps that were sent to the chassis. The record includes the type of alarm, date, time, which model was involved, serial number of the device and a short description of the event.

You can clear the event log table manually with a button, or enter a value in the maximum log entries, so that entries are automatically deleted when this threshold is crossed. This parameter has a value from *0* to *1000* and is by default *1000.*

### Event Mask

This page provides a summary of all possible alarming, both analog and discrete, and allows the user to activate alarming.

### Server Properties

This page displays some general properties (e.g. **Server Model, Serial Number, Date & Time,** .). It is possible to reset the chassis and configure the **Location City** and **Street**.

The complete set of modifiable parameters is present in the **NEC-E module.**

### Web Interface

Refers to the web interface of the chassis. Here it is also possible to configure the devices in the chassis.

## Notes

It is possible that not all devices are supported. Devices are grouped in certain modules by their functionality. The currently supported modules are:

- Electric Pre Amplifier (EPA)
- Network Element Controller (NECE)
- Optical Switches (OPS)
- Optical Single Receivers (ORX1)
- Optical Receivers with Max. 4 Optical Inputs (ORX4)
- Dual Optical Transmitter (OTX2)
- Direct Modulated Optical Transmitters (OTXD)
- Optical Amplifiers (OVA)

If a device is shown in the **Device Overview**, but no element is created, this could be a sign that the limit of available elements in the DMA has been reached. Try to stop another element and create the Funea connector again. If no extra DVE element is created, this isn't the problem.

Not all alarm activation parameters (**Event Mask** page) are supported. It is not possible to program these parameters so that writable and non-writable parameters are separated.

### EPA module

#### About

These are electric pre-amplifiers. Example devices: SVK68#.

#### Usage

The following pages are available:

- **Status**: Displays whether or not there are alarms, warnings or notifications. Some of these are not available through SNMP, so there might be some differences with the statuses visible in the web interface.
- **Parameters**: Monitors **RF Input** and **Output** and **Device Temperature.**
- **Voltages**: Monitors the supply voltages.
- **Settings:** Allows settings of different modes and parameters (e.g. **Laser Frequency, RF gain,.**). If **Redundancy Mode** is not supported, you cannot set to this mode.
- **Limits 1**: Allows the configuration of the alarming of all parameters from the **Parameters** page.
- **Limits 2**: Allows the configuration of the alarming of all parameters from the **Voltages** page.
- **Event Mask:** Handles the (de-)activation of alarms, warnings and notifications for both analog and discrete values. Changing these values might take some time, because some rather large table transformations are involved.
  Note that not all alarm activation parameters are supported, as it is not possible to program these parameters so that writable and non-writable parameters are separated.
- **Properties**: The **General Information** contains the device's **Hardware Model, Alias Name** and **Software Release.** It's possible that no **Alias Name** is available. There's also a button to **Reset** the module and a toggle button to make the LED of the device blink for 10 seconds.

### NECE module

#### About

This is the management module for the whole chassis.

#### Usage

The following pages are available:

- **Status**: Displays whether or not there are alarms, warnings or notifications. Some of these are not available through SNMP, so there might be some differences with the statuses visible in the web interface.
- **Server Administration**: Allows the configuration of the device's **IP Address, Netmask** and **Default Router.**
- **SNMP Configuration**: All SNMP configurations are done here. There are 4 trap receivers, with 2 trap communities. The first community is for trap receiver No. 1 and the second community for trap receiver No. 2-4.
- **Server Properties:** In comparison to the server properties of the main element, this page is more elaborate. There are more general information parameters and only here it's possible to configure the date and time properties. There is also a reset specific for this module.

#### Notes

Be aware that writing a non-IP value in these parameters might cause problems. This is the case for the page **Server Administration**, many parameters of the **SNMP Configuration** and **NTP Server** in the **Server Properties** page.

### OPS module

#### About

These are optical switches. Example devices: BOS21#.

#### Usage

The following pages are available:

- **Status**: Displays whether or not there are alarms, warnings or notifications. Some of these are not available through SNMP, so there might be some differences with the statuses visible in the web interface.
- **Parameters**: Displays the **Input Power** and the **Device Temperature.**
- **Settings**: Allows the configuration of **Switch Mode, Position** and **Fallback Time**. The **switch position** is only configurable if the **Mode** is set to *Manual.*
- **Limits**: Allows the configuration of alarming limits of **Input Power** (**Nominal** and **Redundant Channel**).
- **Event Mask**: Handles the (de-)activation of alarms, warnings and notifications for both analog and discrete values. Changing these values might take some time, because some rather large table transformations are involved.
  Note that not all alarm activation parameters are supported, as it is not possible to program these parameters so that writable and non-writable parameters are separated.
- **Properties**: The **General Information** contains the device's **Hardware Model, Alias Name** and **Software Release.** It's possible that no **Alias Name** is available. There's a button to **Reset** the module and a toggle button to make the LED of the device blink for 10 seconds.

### ORX1 module

#### About

These are optical receivers with 1 channel. Example devices: SEO###.

#### Usage

The following pages are available:

- **Status**: Displays whether or not there are alarms, warnings or notifications. Some of these are not available through SNMP, so there might be some differences with the statuses visible in the web interface.
- **Parameters**: Displays **Input Power** and **+24V** supply voltage values.
- **Settings**: Allows configuration of the parameter **Output Level Adjust.**
- **Limits**: Allows the configuration of alarming limits of the parameters on the **Parameters** page.
- **Event Mask**: Handles the (de-)activation of alarms, warnings and notifications for both analog and discrete values. Changing these values might take some time, because some rather large table transformations are involved.
  Note that not all alarm activation parameters are supported, as it is not possible to program these parameters so that writable and non-writable parameters are separated.
- **Properties**: The **General Information** contains the device's **Hardware Model, Alias Name** and **Software Release.** It's possible that no **Alias Name** is available. There's a button to **Reset** the module and a toggle button to make the LED of the device blink for 10 seconds.

### ORX4 module

#### About

These are optical receivers with up to 4 channels. Example devices: SVO69#.

#### Usage

The following pages are available:

- **Status**: Displays whether or not there are alarms, warnings or notifications. Some of these are not available through SNMP, so there might be some differences with the statuses visible in the web interface.
- **Parameters**: Allows the monitoring of supply voltages and **In-/Output Power, Gain** and **Device Temperature**.
- **Laser(s)**: Displays the major laser parameters (e.g. **Pump Power, Current, Temperature,** ...).
- **Settings**: Allows the user to toggle the **Optical Power** (the laser(s)) on or off. The **Regulation Mode** can be used to switch the device mode to *Gain* or *Output Power.*
- **Limits 1**: Allows the configuration of alarming limits of the parameters on the **Parameters** page.
- **Limits 2**: Allows the configuration of alarming limits of the supply voltages.
- **Event Mask**: Handles the (de-)activation of alarms, warnings and notifications for both analog and discrete values. Changing these values might take some time, because some rather large table transformations are involved.
  Note that not all alarm activation parameters are supported, as it is not possible to program these parameters so that writable and non-writable parameters are separated.
- **Properties**: The **General Information** contains the device's **Hardware Model, Alias Name** and **Software Release.** It's possible that no **Alias Name** is available. There's a button to **Reset** the module and a toggle button to make the LED of the device blink for 10 seconds.

### OTX2 module

#### About

These are optical transmitters with 2 channels. Example devices: BOT2900.

#### Usage

The following pages are available:

- **Status**: Displays whether or not there are alarms, warnings or notifications. Some of these are not available through SNMP, so there might be some differences with the statuses visible in the web interface.
- **Parameters - Common**: Allows the monitoring of the supply voltages, **Input Voltage** and **Device Temperature**.
- **Parameters - Transmit 1&2**: Allows the monitoring of the **Activity, Laser Current, OMI, RF Input, RF Gain** and **Output Power.**
- **Settings - Transmit 1&2**: Allows the configuration of different modes and parameters (e.g. **AGC mode, desired output power,** .).
- **Limits - Common**: Allows the configuration of the alarming limits of the **Device Temperature** and **Input Voltage**.
- **Limits - Transmit 1&2**: Allows the configuration of the alarming limits of **RF Input, OMI, RF Gain and Output Power**. Hysteresis of the output power is not available.
- **Event Mask**: Handles the (de-)activation of alarms, warnings and notifications for both analog and discrete values. Changing these values might take some time, because some rather large table transformations are involved.

  Note that not all alarm activation parameters are supported, as it is not possible to program these parameters so that writable and non-writable parameters are separated.

- **Properties**: The **General Information** contains the device's **Hardware Model, Alias Name** and **Software Release.** It's possible that no **Alias Name** is available. There's a button to **Reset** the module and a toggle button to make the LED of the device blink for 10 seconds.

### OTXD module

#### About

These are direct modulated optical transmitters. Example devices: SSO### and BOT \#DW.

#### Usage

The following pages are available:

- **Status**: Displays whether or not there are alarms, warnings or notifications. Some of these are not available through SNMP, so there might be some differences with the statuses visible in the web interface.
- **Parameters**: Allows the monitoring of different parameters (e.g. **RF Input, RF Gain, TEC Current, Laser Temp. Offset**,.).
- **Voltages**: Allows the monitoring of the supply voltages and the **TEC voltage.**
- **Settings**: Allows settings of different modes and parameters (e.g. **Slope, RF Gain,.**). If **Redundancy Mode** is not supported, you cannot set to this mode. Setting **Desired Output Power** and **Laser Frequency** is not supported by the MIBs.
- **Limits 1**: Allows the configuration of alarming limits of the parameters on the **Parameters** page.
- **Limits 2**: Allows the configuration of the alarming of all parameters from the **Voltages** page.
- **Event Mask**: Handles the (de-)activation of alarms, warnings and notifications for both analog and discrete values. Changing these values might take some time, because some rather large table transformations are involved.

  Note that not all alarm activation parameters are supported, as it is not possible to program these parameters so that writable and non-writable parameters are separated.

- **Properties**: The **General Information** contains the device's **Hardware Model, Alias Name** and **Software Release.** It's possible that no **Alias Name** is available. There's a button to **Reset** the module and a toggle button to make the LED of the device blink for 10 seconds.

#### Notes

Most **Optical Modulation Index (OMI)** related parameters are provided in dB(m), since this is the way these parameters are returned by the device.

### OVA module

#### About

These are optical amplifiers. Example devices: SVO69#.

#### Usage

The following pages are available:

- **Status**: Displays whether or not there are alarms, warnings or notifications. Some of these are not available through SNMP, so there might be some differences with the statuses visible in the web interface.
- **Parameters**: Visualizes the **Input Power, Output Power** or the **Gain,** the supply voltages and the **Device Temperature.**
- **Laser(s)**: Displays the major laser parameters (e.g. **Pump Power, Current, Temperature,** ...).
- **Settings**: Allows the user to toggle the **Optical Power** (the laser(s)) on or off. The **Regulation Mode** can be used to switch the device mode to *Gain* or *Output Power*.
- **Limits 1**: Allows the configuration of the alarming of all parameters from the **Parameters** page.
- **Limits 2**: Allows the configuration of alarming limits of the supply voltages.
- **Event Mask**: Handles the (de-)activation of alarms, warnings and notifications for both analog and discrete values. Changing these values might take some time, because some rather large table transformations are involved.
  Note that not all alarm activation parameters are supported, as it is not possible to program these parameters so that writable and non-writable parameters are separated.
- **Properties**: The **General Information** contains the device's **Hardware Model, Alias Name** and **Software Release.** It is possible that no **Alias Name** is available. There is a button to **Reset** the module, a toggle button to make the LED of the device blink for 10 seconds and a button to start a **SBS Evaluation.**

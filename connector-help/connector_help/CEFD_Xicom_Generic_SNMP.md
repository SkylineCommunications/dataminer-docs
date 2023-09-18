---
uid: Connector_help_CEFD_Xicom_Generic_SNMP
---

# CEFD Xicom Generic SNMP

With this connector, information can be gathered and viewed from the amplifier **CEFD Xicom Generic SNMP**. The connector also makes it possible to set values on the device.

## About

This connector is used to interface with the **CEFD Xicom Generic SNMP** amplifier.

## Installation and configuration

### Creation

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays some general parameters from the **CEFD Xicom Generic SNMP** device:

- **Amplifier RF Attenuation Value** (configurable)
- **Amplifier IF Attenuation Value** (configurable)
- **Amplifier RF Band** (configurable)
- **Amplifier Sub Band** (configurable)
- **Amplifier Waveguide Switch Configuration** (configurable)
- **Amplifier Gain Balance** (configurable)
- **Amplifier Date and Time** (configurable)
- **Com1 Serial Port Settings (RS-232)** (configurable)
- **Com1 Serial Port Settings (RS-232)** (configurable)
- **RS-485 Serial Port Settings** (configurable)
- **Amplifier ID/Version**
- **Amplifier Sum Status**
- **Amplifier Fault Status**
- **Amplifier Alarm Status**
- **Forward RF Power Level**
- **Reverse RF Power Level**
- **Amplifier Temperature**
- **Smart Block-Up Converter Temperature**

This page also displays one button:

- **Settings:** opens the Settings page

**Note:** At startup, in order to get the maximum allowed attenuation values, a set to 99.9 is performed, immediatly after this the attenuation value is set to its initial read value.

### Settings Page

This page contains some configurable settings of the device:

- **Enter Transmit or Standby Mode**
- **Enable/Disable RF Inhibit**
- **Set Waveguide Switches**
- **Maintain Output Power Level**

This page also displays four buttons:

- **Clear all active Faults**
- **Test the Waveguide Arc Detector Circuit**
- **Test the Summary Fault Circuit**
- **Reset Amplifier**

### TWT Amplifier Page

### This page displays the TWT Amplifier's parameters from the CEFD Xicom Generic SNMP device:

- **TWT Beam Uptime**
- **TWT Heater Uptime**
- **Helix Voltage**
- **Helix Current**
- **Heater Voltage**
- **Heater Current**
- **Cathode Current**
- **Anode Voltage**

In case the amplifier is not of type TWT these parameters will display N/A (Not Available)

### SSP Amplifier Page

### This page displays the SSP Amplifier's parameters from the CEFD Xicom Generic SNMP device:

- **Time on Transmit Mode**
- **Amplifier Uptime**

In case the amplifier is not of type SSP these parameters will display N/A (Not Available)

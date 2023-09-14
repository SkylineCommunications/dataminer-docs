---
uid: Connector_help_Lawo_V_pro8
---

# Lawo V_pro8

This connector can be used to monitor and control Lawo V_pro8 devices. Lawo describes this device as the complete 8 channel video processing toolkit.

## About

All information is polled from the device over SNMP in connector range 1.x, or the smart-serial (Ember+) protocol in connector range 2.x.

The Ember+ version of the connector is much more extensive than the SNMP version. For example, it also contains matrix controls, that allows the operator to see and change crosspoints between inputs and outputs.

### Version Info

| **Range** | **Description**                                | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version based on SNMP                  | No                  | Yes                     |
| 2.0.0.x          | Initial version based on Ember+ (smart-serial) | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | unknown                     |
| 2.0.0.x          | unknown                     |

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: \[The polling IP or hostname of the device.\]
  - **IP port**: \[The IP port of the device. This is required.\]

### Configuration

No additional configuration is necessary after creating the element.

## Usage

### General

Displays general information of the device: product code, serial number, software version, role, .... Additionaly there is also a button that allows an operator to reboot the device.

### Status

Contains parameters that hold the status of the most important components of the system: **inputs, outputs, power supplies, fan, temperature**.

### Inputs

Contains tables with all inputs.

### Outputs

Contains tables with all ouputs.

### Video Matrix

This page displays the video matrix.

### Audio Matrix

This page displays the audio matrix.

### Quad Video Matrix

This page displays the quad video matrix.

### Quad Audio Matrix

This page displays the quad audio matrix.

### MADI

Contains a table with all Multichannel Audio Digital Interface (MADI) configuration settings.

Using the page buttons, you can access the setting of the inputs and outputs.

### Quad

Displays the Quadsplit multiviewer table. The integrated Quadsplit multiviewer provides a high-quality video and audio monitoring solution via the V_pro8's video output (BNC or DisplayPort), displaying up to four video sources at the same time.

### GPI

Contains a table with the general purpose input (GPI) registers. The user can assign a preset to each input, and press the trigger button to activate the linked preset.

### Preferences

Displays all preferences, such as the color schema that will be used on the front panel of the device.

### Web Interface

Displays the webinterface of the device. Note that the client machine has to be able to access the device, as otherwise it will no tbe possible to open the webinterface.

## Notes

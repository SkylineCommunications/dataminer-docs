---
uid: Connector_help_Teleste_HDO611_TSEMP_DVX
---

# Teleste HDO611 TSEMP DVX

HDO611 is a wideband amplifier. It is installed into an HDX installation frame and can be used as a general gain block in headend and hub systems.

## About

This connector is used to control and monitor the HDO611 module using the DVX bus.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the Moxa connected to the DVX Bus, e.g. *10.11.12.13.*
- **IP port**: The port of the Local TCP connection used by the Moxa, e.g. *4001.*
- **Bus address**: The bus address of the connected device, in the format: *X.Y* (where X = Rack Number, Y = Slot Number).

## Usage

### General page

On this page, you can find an overview of the module, along with statistic information (uptime, temperature, etc.).

Click the **Alarm Limits** page button to view or configure the analog and discrete alarm limits.

### RF

This page displays the **Attenuator** and **Equalizer** values.

Click the **Normalized Values** page button to configure the normalized value of the Attenuator and Equalizer. With the **Normalize (All)** button, you can copy the current values to the normalized parameters.

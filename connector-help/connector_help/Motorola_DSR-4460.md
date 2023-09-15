---
uid: Connector_help_Motorola_DSR-4460
---

# Motorola DSR-4460

The Motorola DSR-4460 connector is used to monitor and control the **Motorola DSR-4460** satellite receiver.

## About

This connector uses an SNMP connection to communicate with the device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public.*
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General page

This page contains basic information about the unit, such as the model, software versions, unit address, front panel, IP settings, etc.

### Audio page

This page contains the current audio status, together with several configuration parameters. It is also possible to activate an audio test pattern here.

### Video page

This page contains configuration parameters for video. It is also possible to activate the test pattern screen here.

### Demodulator page

This page displays information about the demodulator.

### Decoder page

This page displays information about the decoder.

### Input page

This page displays the acquisition status for the active input signal.

### Output page

On this page, the output settings can be configured.

### Alarms page

This page shows the current alarm condition. It is also possible to configure a trigger when the alarm should be raised.

### Web Interface page

The native web interface of the device. The client machine has to be able to access the device. If not, it will not be possible to open the web interface.

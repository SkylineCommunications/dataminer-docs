---
uid: Connector_help_Ericsson_EN8040
---

# Ericsson EN8040

This connector is used to monitor and configure the **EN8040** Encoder from **Ericsson**.

## About

This connector contains different pages with information and settings. More detailed information on these can be found in the **Usage** section of this document.

The connector uses the **SNMP** protocol to communicate with the device.

### Version Info

| **Range** | **Description**         | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------|---------------------|-------------------------|
| 1.0.1.x          | Added output selection. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | v5.1                        |
| 1.0.2.x          | v5.1                        |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port Number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information on the device, such as the **Summary Alarm, Temperature, Fan Status**, etc.

### Alarms

This page displays the state of the device, including the **PSU Sensor, Real Time Clock, Over Voltage (5V)**, etc.

### Service

This page contains service-related information, such as the **Network Name, Service Provider, Syntax**, etc.

### Video

This page contains video-related information, such as the **Video Input, Video Frame Rate, Video Bandwidth**, etc.

### Audio

This page contains tables with audio-related information, such as **Audio Termination, Audio Coding standard**, etc. The current and next settings can be configured.

### Data

This page displays information related to the serial ports (RS232 an RS422), for example **RS232 Baud Rate, RS232 Component Tag, RS422 Delay**, etc.

### IP Streamer

This page and its subpages contain parameters that are only available if an IP board is present in the device (Dual-IPNIC), for example **Output Bit Rate, IP protocol, TTL**, etc.

### MUX

This page contains MUX-related information, such as the **Mux Packet Length, Mux Bit Rate, Mux Clock**, etc.

### Output Selection

This page contains modulator-related information, for example **Hardware Release, Modulator Next time Date, Modulator Output Type**, etc.

### Encryption

This page contains encryption information, such as the **Mux CA Type, Mux Scrambling, Mux Scramble Code, BISS Session Word**, etc.

### Configuration

On this page, you can store and load configuration information.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.2.x** connector range of the **Ericsson EN8040** protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- SDI Input: in
- HD-SDI Input: in
- Composite Input: in
- L-Band Input: in
- ASI Input 1: in
- ASI Input 2: in
- IP Input: in
- ASI Output 1: out
- ASI Output 2: out
- ASI Output 3: out
- L-Band Output: out

Parameter **10601** defines the **video input source**. Parameter **10131** defines the **output mode**.

The **L-Band Input** is **always** connected to the **selected output**.

## Notes

After a value is set in the **Modulator Table**, the connector waits for 2 seconds before it polls the table again. This ensures that the Ericsson EN8040 returns the correct value and not the old one.

---
uid: Connector_help_Mitec_WTX-5964xx-70-ES-xx
---

# Mitec WTX - 5964xx-70-ES-xx

The Mitec WTX-5964xx-70-ES-xx connector can be used to read information from the High Power Transmitter Unit and to configure its settings. The communication between the protocol and the device is established using a serial connection.

## About

Using **serial** communication, the protocol retrieves settings, telemetry, and alarm information from the unit. Some of these parameters are: Temperature, L-Band Frequency (also called IF Frequency), Output Power, and Mute Status. The protocol also sets some of the parameters on the Mitec WTX-5964xx-70-ES-xx, for example the Device Address and IF Frequency.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3900040-00-Rxx              |

## Installation and configuration

### Creation

#### Serial main connection

This protocol uses serial communication to transmit commands and receive responses from the target devices. It requires the following input during element creation:

SERIAL CONNECTION

- **IP Address/Host**: The polling IP of the device, e.g. *10.255.110.xx*.
- **IP Port:** The device port location at the specified IP, e.g. *10.255.110.xx:15000*.

## Usage

### Main View

This page displays general information about the Mitec WTX-5964xx-70-ES-xx, organized into read-only parameters on the one hand and read-write parameters on the other hand. These are:

- **Booster Read-Only Parameters**: Software Version, Temperature \[deg C\], Sensor Voltage Temperature \[deg C\], Output Power \[dBm\], Gain \[dB\].
- **Booster Read-Write Parameters:** Mute Status, IF Frequency, Device Address.

### Booster Alarm

This page displays the three alarms that can be rendered by a device using this software version. These are:

- **System Alarms:** Over Temperature Alarm, Low Power Alarm, Summary Alarm.

## DataMiner Connectivity Framework

The Mitec WTX-5964xx-70-ES-xx protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Connections

#### Internal Connections

- Between input and output an internal connection is created with the following properties:

- **input** connection property of type **in**.
  - **output** connection property of type **out**.

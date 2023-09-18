---
uid: Connector_help_Newtec_2177
---

# Newtec 2177

The Newtec 2177 is a variable-rate DVB satellite modulator. This connector can be used to monitor and control this device.

## About

The Newtec 2177 is the successor of the well-established NTC/2077. It has been designed for both DVB and Skyplex contribution and distribution, as well as for the telco and IP world. It can be used where high product flexibility is required for interfacing with other equipment. One of the main applications is the use on medium to high data rate DVB broadcast transmissions for distribution (QPSK) and contribution (QPSK + 8PSK + 16QAM) and for DVB-IP satellite backbones with existing IF upconverters (70-140 MHz) and HPAs.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.1.36.x         | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.1.36.x         | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. (Default: *100*)

### Configuration

To ensure that the connector works correctly, make sure that the **RMCP version** on the device itself is set to **v2.0**. This can only be done via the web interface of the device.

## Usage

### General

This page contains all the general information related to this device, such as the **Hardware ID**, **Control**, **Operating** and **Device Mode**, **RMCP Version**, **Data Input**, **Address** and **Internal Temperature**.

It also contains several subpages with additional information: **Device Info**, **Display**, **Power Supply**, **Security**, **Ethernet**, **Serial**, **Outdoor**, **Internal**, **External**, **Config** and **Test**.

### Modulator

This page shows the **L-Band Monitor** and **Operational Output Frequency**, **Modulation Standard**, **FEC Rate** and **Modulation**, **Carrier Modulation**, **Symbol Rate**, **Interface Bitrate**, **Rate Priority**, **Transmit Clock** and **Status**, **Output Signal** and **Level**, **Offset**, **Gain Control State** and **Mode**.

It also contains several subpages with additional information: **NCR**, **Rate Adapter**, **PHLA**, **Additional**, **BER** and **BISS**.

### Alarms

This page illustrates all the system alarms, with the parameters **Actual** and **Memorized Alarm Status**, **Device Reset Flag**, **Self Test**, **Incompatibility**, **General Device**, **Interface**, **Reference Clock**, **Device Temperature**, **Power Supply Voltage**, **ASI Code Violation**, **LVDS Signal Detect**, **NCR Inserter GPS 1pps**, **Buffer Underflow and Overflow**, **Clock PLL**, **Synthesizer**, **Input Framing**, **Timebase Sync**, **RF Phase Lock DRO**, **BISS Summary**, **Internal M&C Module**, **Interface Module**, **Internal Modulator** and **Device Architecture**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.1.36.x** range of the **Newtec 2177** protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

Fixed interfaces

- **Input - DVB-SPI-LVDS IN** - A single fixed interface of type **input.**
- **Input** - **RS422-LVDS IN**  - A single fixed interface of type **input.**
- **Input** - **ASI-A IN**  - A single fixed interface of type **input.**
- **Input- ASI-B IN** - A single fixed interface of type **input.**
- **Output - Modulator Output OUT** - A single fixed interface of type **output**.
- **Output - Monitoring Output OUT** - A single fixed interface of type **output**.

### Connections

#### Internal Connections

- Between \[**DVB-SPI-LVDS IN** -\> **Modulator Output OUT**\] and \[**DVB-SPI-LVDS IN** -\> **Monitoring Output OUT**\]
- Between \[**RS422-LVDS IN** -\> **Modulator Output OUT**\] and \[**RS422-LVDS IN** -\> **Monitoring Output OUT**\]
- Between \[**ASI-A IN** -\> **Modulator Output OUT**\] and \[**ASI-A IN** -\> **Monitoring Output OUT**\]
- Between \[**ASI-B IN** -\> **Modulator Output OUT**\] and \[**ASI-B IN** -\> **Monitoring Output OUT**\]

### Notes

For this connector to be fully functional, the RMCP version needs to be v2.0. With version v1.0, several Missing Header errors such as err023 will be received.

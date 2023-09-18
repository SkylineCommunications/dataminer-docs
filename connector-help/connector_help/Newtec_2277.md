---
uid: Connector_help_Newtec_2277
---

# Newtec 2277

The Newtec 2277 is a variable-rate IF-band DVB-S2 satellite modulator. This connector can be used to monitor and control this device.

## About

Like its predecessor, the NTC/2177 DVB-S modulator, the Newtec 2277 is a member of the field-proven modular Azimuth series and is designed to packetize, encode and modulate one MPEG transport stream. At the output, the signal is converted to an IF band signal (50-180 MHz). There are two physical input interface positions available that can be fitted with a range of interface modules: a DVB (ASI, SPI, LVDS) and a TELCO (HSSI/G703) interface provide a standard data input for the modulator. An IP GbE interface is also available. This modulator handles symbol rates from 0.05 up to 68 Mbaud, using a QPSK, 8PSK, 16 APSK or 32 APSK modulation scheme. It is mainly used in satellite services such as broadcasting, distribution or contribution of digital TV signals, digital satellite news gathering, data content distribution, trunking and other professional applications.

### Version Info

| **Range** | **Description**                         | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------|---------------------|-------------------------|
| 1.5.9.x          | Initial Version                         | No                  | Yes                     |
| 1.6.2.x          | Software version 6.02                   | No                  | Yes                     |
| 2.2.11.x         | Software version 2.11, Software ID 2641 | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.5.9.x          | Software version: 5.09      |
| 1.6.2.x          | Software version: 6.02      |
| 2.2.11.x         | Software version: 2.11      |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

> - **Baudrate**: Can be changed on the Serial page.

- Interface connection:

> - **IP address/host**: The IP of the device.
> - **IP port**: Default value is *5933*.
> - **Bus address**: Default value is *100*.

## Usage

### General

This page contains general information regarding this device, including the **Hardware ID**, **Control**/**Operation**/**Device** **modes**, **RMCP Version**, **Data Input**, **Processing Mode Status** and **Internal Temperature**.

In addition, specific information can be displayed and set on multiple subpages: **Device Info**, **Display**, **Power Supply**, **Security**, **Ethernet**, **Serial**, **Outdoor**, **Internal**, **External**, **Config** and **Test**

### Modulator

This page contains more technical information: **L-Band Monitor**/**Operational output** **frequencies**, **Modulation Standard**, **FEC Rate** and **Modulation**, **Carrier Modulation**, **Symbol Rate**, **Current Rate Estimation**, **Interface Bitrate**, **Rate Priority**, **Transmit Status**, **Output Signal**, **Phase Error Deviation**, **Clock Loop State**, **Main Acquisition State**, **Measured Output Level**, **RF Gain** and **Gain Control (State /** **Mode)**.

Additional information can be displayed and set on multiple subpages: **NCR**, **BBFraming**, **PHLA**, **Additional**, **BER**, **BISS**, **Rate** **Adapter**, **Frames** and **Packets**.

### Alarms

This page contains information about alarms: **Actual**/**Memorized alarm status**, **Device Reset Flag**, **Self Test**, **Incompatibility**, **General Device**, **Interface**, **Reference Clock**, **Device Temperature**, **Power Supply Voltage**, **ASI Code Violations**, **ASI Optical Signal Detect**, **LVDS Signal Detect**, **NCR Inserter GPS**, **Buffer** (**Underflow**/**Overflow**), **Clock PPL**, **Synthesizer**, **Input Framing**, **Baseband Frame Sync**, **RF Phase Lock DRO**, **BISS Summary**, **Internal M&C**/**Interface module**, **Internal Modulator**, **Device Architecture**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

---
uid: Connector_help_Egatel_TE9000
---

# Egatel TE9000

The **Egatel TE9000-E6** is a digital transmitter. With its integrated modulator, it covers almost all of the TV systems (analog and digital). The Egatel TE9000 integrates the most up-to-date signal processing technology in order to transmit high quality and reliable signals. It can work in digital networks such as MFN (Multiple Frequency Networks) and SFN (Single Frequency Networks). Some of the key features are: compatibility with the DVB-T2 norm, MISO processing, PAPR reduction, digital pre-correction (linear and non-linear), etc.

## About

This connector was designed to work with the model **TE9000E6**. With it, you can monitor the state of the input and output of the transmitter and the GPS internal behavior. It displays the different parameters for the amplifiers and can be used to supervise the parameters configured for the DVB-T2, RF, QoS and pre-correction techniques.

### Version Info

| **Range** | **Description**                                  | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                  | No                  | No                      |
| 1.1.0.x          | New firmware for model E6 based on range 1.0.0.x | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | E5                          |
| 1.1.0.x          | v4.9                        |

## Installation and configuration

### Creation

#### Main connection

This connector uses a Simple Network Management Protocol (**SNMP**) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device. e.g. *10.10.12.3*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

Once created, the element can be used immediately. There are 11 pages available.

### General

This page contains general information, such as **Control Mode**, **Input Module**, **Test Mode**, the different **Firmware Versions**, **IP Addresses**, **GPS Module**, **Alarm Time**, etc.

### Input

On this page, information is displayed regarding the device itself, e.g. **Asynchronous Serial Interface Delays**, **Transport Stream over IP and RF Delays**, **Transport Stream Commutation**, **Input Impedance**, **Frequency**, **Lost Mute Time**, **Input Selection**.

### GPS

This page displays information about the **GPS Module**, such as **Reference Frequency**, **number of Satellites (including Minimum and Maximum)**, **Carrier-Noise Threshold**, **Cable Delay**.

### Output

On this page, you can configure the following parameters: the **Exciter Output Power**, **Output Frequency**, **Bandwidth**, **Output Power Attenuation**, **Transmitter Output Power**, **Reflected Output Power**, **Fault Power Threshold**, **Amplifier Nominal Power** and **Warning Power Threshold**.

### Amplifiers

This page displays parameters related to the different amplifiers in the **Amplifiers Table**. It is also possible to configure the **Temperature Threshold** for the different amplifiers in the table.

### Modulation

On this page, you can configure the **DVB Standard**, **Guard Interval**, **Modulation Engine**, **Code Rate**, **FFT Mode**, **Constellation**, **SFN/MFN Mode**, **Auto MIP**, **Time Offset**, **DVB FEC**, **DVB Interleaver**, **DVB Cell Identification**.

### DVBT2

This page contains the different settings for the **DVB-T2 standard**. The following parameters can be configured: **DVB-T2 Profile Preambulo**, **System ID SFN Synchronization**, **T2MI Input Selection**, **ATSC Buffer Size**, **T2MI Id**, **DVB-T2 Network ID**, **DVB-T2 Version**, **ATSC Adaptation Mode**, **DVB T2 PLP Allocation Status**, **DVB T2 PLP Buffer Overflow Status**, **DVB T2 Transport Stream FIFO Full Status**, **DVB T2MI Sync Status**.

Aside from these parameters, there are also three page buttons available:

- **DVB T2 Local**: Displays the following configurable parameters: **DVB T2MI Frequency**, **DVB T2 Local Frequency Enabled**, **DVB T2 Transmitter ID**, **DVB T2 Local MISO**, **DVB T2 PAPR**, **DVB T2 PAPR Gain Ace, DVB T2 PAPR Iteration TR.**
- **DVB T2 PLP**: Displays the **DVB T2 PLP Configuration Table**
- **DVB T2 Frame**: Allows the configuration of the **DVB T2 FFT**, **DVB T2 Guard Interval**, **DVB T2 Carrier Mode**, **DVB T2 Pilot Pattern**, **DVB T2 L1 Code Rate**, **DVB T2 Frames per Superframe**, **DVB T2 L1 Constellation**, **DVB T2 L1 Repetition Enabled**, **DVB T2 Auto Symbols** and **DVB T2 Auto Frames**.

### Pre-Correction

This page displays parameters such as **Non-Linear Pre-Correction System**, **Adaptive Status**, **Adaptive Reset**, **Non Linear Power Sample**, **Non Linear Power Status**, **Adaptive Filter Precorrection**, **Peak Average Power Reduction ON/OFF**, **Adaptive Mode**, **Adaptive Periodic Startup**, etc.

### RF

On this page, the following parameters can be configured: **RF Reception MER**, **RF Reception BER**, **RF Reception PER**, **RF QoS Frequency**, **RF QoS MER**, **RF QoS BER**, **RF QoS PER**, **RF QoS Level**, **RF QoS PER Threshold**, **RF QoS MER Threshold**, **RF QoS BER Threshold**, **RF PER Threshold**, **RF BER Threshold**, **RF MER Threshold**, etc.

### TSoIP

This page displays the following configurable parameters: **IP Addresses**, **Gateways**, **UDP Ports**, **Speed Modes**, **Latency Time**, **TS over IP Speed**, **MAC Addresses**.

### Notifications

This page displays different notification alarms, which can be enabled/disabled by means of the **Setup** page button in the lower right corner. These are for example:

- Exciter Output Power Failure
- Amplifier Output Power Failure
- Communication Failure
- Coolling Failure
- RF QoS Hardware Failure
- RF QoS PER Failure
- RF QoS MER Failure
- RF QoS BER Failure
- RF Reception PER Failure
- RF Reception BER Failure
- RF Reception MER Failure
- Amplifier\[1,2,3,4\] Temperature Failure
- Amplifier\[1,2,3,4\] Blowers Failure
- Amplifier\[1,2,3,4\] Communication Failure
- Amplifier\[1,2,3,4\] Supply Failure
- TSoIP \[1,2\] Latency Time Failure
- ATSC Buffer Overflow Failure

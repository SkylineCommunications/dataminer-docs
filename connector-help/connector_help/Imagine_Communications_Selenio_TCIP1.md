---
uid: Connector_help_Imagine_Communications_Selenio_TCIP1
---

# Imagine Communications Selenio TCIP1

The **Imagine Communications Selenio TCIP1** single-channel module for the Selenio MCP1 and MCP3 platform supports TICO Mezzanine Format for UHD over 3G-SDI and 10 Gig-E. TICO is low-latency, lightweight compression technology from IntoPIX.

This connector allows you to monitor the transmitters and receivers in the module.

## About

This connector provides access to various information on the device. Data is retrieved using SNMP. The connector can be configured to operate either as **Encoder** or **Decoder**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains the general **Encoder** or **Decoder** information, such as the **Name**, **Serial Number**, **Software Version** and **Board Temperature**.

If data is not being retrieved, for example after a reboot, it is possible to poll it using the **Update** button.

### Alarming

This page contains the **Alarms** table, which displays the **Name**, **Priority** and **Timestamp** of the current alarms. In the **Alarm Polling Speed** drop-down box, you can select the polling frequency (5, 15 or 30 seconds) for this table.

### Controller

This page displays the controller information and configuration for the encoder or decoder. The page also includes **PTP** data.

### Audio Sync

This page displays the following information:

- **Sample Rate Converters Status**: Reports if the audio sample rate converters are engaged (E) or bypassed (B), and if the left and right audio channels of an audio pair are either synchronized (*Engaged*) or not synchronized (*Bypassed*).
- **SRC (1 to 8) Control:** These controls determine the operation mode (*Engage*, *Auto* or *Bypass*) of the **Sample Rate Converters**.

### Audio Control Status

This page reports if there is a **Parity**, **ECC**, **DBN** or **Checksum Error** in the audio groups 1 to 4.

### Frequency

This page displays the frequency information, such as **Measured Frequency IIR**, **Frequency Adjust** and **Phase Gain**.

### AES67

This page allows you to configure the **AES67 Tx** and **Rx** data, including **Channels**, **Audio Bit Width** and **Packet Time**.

### SDI Input Status

This page displays the **Input Status, Input Skew** and **Payload** of the SDI 1 to 4. This page also contains the **EDH-CRC-SQM** table.

### SDI Input Control

This page allows you to configure the **Top Left**, **Top Right**, **Bottom Left** and **Bottom Right Quadrants**. This page also displays the **Bypass Misfit SDI 1** configuration.

### SDI Output

This page displays the **EXT SDI Output Status (3 to 8)** and allows you to configure the **Output Sources** for all the **Embedded Channels**.

### Video Status Sync

This page displays important status information regarding the content of the received 3G baseband signal, originating either from SDI input 1 or from the 2022-5/6/7 receiver.

### Video Output and Routing

This page allows you to select which signal is to be sent to the controller for thumbnail monitoring, as well as to specify the output format of the outgoing quad-link stream.

### SDI\<-IP De-Encapsulator

This page provides **Rx configuration**, such as **Buffer Mode**, **Playout Delay**, **RTP Timeout Debug** and **Seamless Max Path Differential**.

### SDI-\>IP Encapsulator

This page displays the **FEC** and the **IP Transmitter** configuration.

### HANC/VANC Data Mux

This page provides the controls and status information needed to steer the re-embedding of **HANC** data and **VANC** data back into the reconstructed **UHD** signal.

### WAN Configuration and Status

This page displays the number of packets for **Tx** and **Rx**.

**IP WAN table** and **SPF+** information is also available here.

### IP Configuration

This page allows you to configure the **IP Configuration**. The settings have both primary and secondary values.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

Available in range 1.0.0.x.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

- SDI Inputs: Reports the available interfaces **in** for the encoder or decoder.
- SDI Outputs: Reports the available interfaces **out** for the encoder or decoder.

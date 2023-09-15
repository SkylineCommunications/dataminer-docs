---
uid: Connector_help_Newtec_2137
---

# Newtec 2137

The Newtec 2137 is a Transport Stream ASI Concentrator-Deconcentrator. This connector can be used t monitor and control this device.

## About

As a successor of the NTC/2187, the NTC/2137 has now been fully integrated into the Azimuth series. This implies that the Concentrator and Deconcentrator have exactly the same features and specifications than the NTC/2187, and additionally have an Ethernet 10 Base-T connection with SNMP agent and MIB library. The NTC/2137 ASI-DVB Transport Stream Concentrator/ Deconcentrator is a stand-alone unit that can be configured (hardware configuration) according to specific DVB Concentrator Deconcentrator needs.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.1.31.x         | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.1.31.x         | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

Direct connection:

> - **Baudrate**: Can be changed on the Serial page.

- Interface connection:

> - **IP address/host**: The IP of the device.
> - **IP port**: Default value is *5933*.
> - **Bus address**: Default value is *100*.

## Usage

### General

This page contains general information regarding this device, including **Device Hardware ID**, **Control Mode**, **Operating Mode**, **Internal Temperature**, etc.

In addition, specific information can be displayed or set on multiple subpages: **Device Info**, **Display**, **Power Supply**, **Security**, **Ethernet**, **Serial** and **Config**.

### Deconcentrator

This page contains more technical information: **Input Signal Selection**, **Rx Framing Mode**, **Rx Framing State** and **Estimated Input Bitrate**.

Additional information can be displayed and set on multiple subpages: **Channels** and **Outputs**.

### Alarms

This page contains information about alarms: **Actual/Memorized Alarm Status**, **Device Reset Flag**, **Self Test**, **Incompatibility**, **General Device**, **Interface**, **Reference Clock**, **Device Temperature**, **Power Supply Voltage**, **Superframe Sync**, **Decon Tmd Too Low**, **Tx Queue Overflow**, **Tx Signal Loss**, **Internal M&C Module**, **Decon. 1 Module** and **Device Architecture**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

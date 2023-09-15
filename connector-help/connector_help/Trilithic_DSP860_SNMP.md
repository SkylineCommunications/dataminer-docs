---
uid: Connector_help_Trilithic_DSP860_SNMP
---

# Trilithic DSP860 SNMP

This connector monitors a portable cable analyzer and CATV meter with a built-in DOCSIS 3.0 modem for performing transmission and signal quality tests for analog and digital HSD and VoIP services.

## About

This connector displays a table with the different information on input level and on channel level. It also allows you to normalize the currently measured values, in order to base alarm thresholds on these normalized values. Finally, it also provides an overview in a tree structure.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Basic range     | No                  | Yes                     |
| 1.1.0.x          | Release version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 10.7.7.2                    |
| 1.1.0.x          | 10.7.7.2                    |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page includes general information about the device, such as the **Device Name** and **Application Versions**. It also contains a summary of the most important measured values, such as **Temperature**, **Main Bus Voltage**, etc.

Via the **Network Info** button, you can access a subpage with all relevant network information, such as **MAC Address**, **IP Address**, **Primary DNS**, etc.

### Inputs

This page contains information about the inputs of the device. The information is listed in a table, which contains parameters such as the **Channel Plan Name**, the **Minimal Analog Video Channel Level Limit**, the **MAX BER**, etc.

### Channels

This page includes information about the different channels that exist on the device. The information is listed in a table, which contains among others the **Audio Level**, **FM Deviation** and **C/N**.

The page also displays the **Video Frequency**, **Audio Frequency**, **Symbol Rate**, etc.

Via the **Normalize Channels** button, you can set the currently measured values of the channels as the normal values, so that alarms will be measured from this threshold.

### Overview

This page displays a graphical overview of the different inputs, including the channel information per input.

### Web Interface

This page displays the native web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

---
uid: Connector_help_NTT_Electronics_HVD9130
---

# NTT ELECTRONICS HVD9130

The **NTT ELECTRONICS HVD9130** connector uses SNMP to communicate with the high performance MPEG-2 decoder of the same name. It retrieves information about the status, video, programs and alarms reported by the device.

## About

With this connector, it is possible to both monitor the decoder and set parameters of the decoder.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.00                        |

## Installation and configuration

### Creation

*SNMP Main Connection*

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*

SNMP Settings:

- **Port number**: The UDP port, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

## Usage

### General Page

This page displays general device information (**Description**, **Version**, **System Uptime**, **Temperature**) as well as the status of the selected input, for video and audio separately.

There is a **Reset** button that can be used to perform a system-wide reset.

### Video Page

On this page, you can find additional information regarding the video status, such as **Bitrate**, **Format**, **Decoder Mode** and **Video Type**.

### Video Page

This page displays information related to the decoder programs, presented in table format.

### Transport Stream Page

This page displays the reported **PID** numbers for the video, audio, PCR, and PMT, as well as the calculated **TS Bitrate**.

### BISS Page

This page displays the reported BISS keys, mode and selection. You can also set up new values related with BISS here.

### Alarms Page

This page displays the alarms reported by the device in table format.

### Web Interface Page

On this page, you can access the web interface of the Imagine Communications frame.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

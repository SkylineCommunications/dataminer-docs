---
uid: Connector_help_Thomson_Video_Networks_MD6000
---

# Thomson Video Networks MD6000

The Thomson Video Networks MD6000 connector has been designed to monitor and manage a single Distribution Receiver Decoder MD6000 device. This device is used for terrestrial, cable, satellite, and IPTV headends to receive and decode feeds for local re-encoding, analog delivery, or confidence monitoring.

With this connector, the device can be managed directly. The connector uses **SNMP** to establish communication with the device. The timers for data retrieval can be customized on the **Polling Control** page, with a possible range of 60 seconds to 7 days in steps of 60 seconds. A value of 0 will stop the timer.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string needed to read from the device.
- **Set community string**: The community string needed to set to the device.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The connector contains different pages, divided into sections.

### General

This page contains general information about the connected device.

There are several page buttons on the page, which allow you to view information and settings for the **InBand, MPEG IP Card, MPEG IP NIC**, and **Power Supply**.

### Inputs

This page displays the **Transport Stream Input Source** table and **Input** table, where the input source can be configured.

A number of page buttons at the bottom provide access to information and configuration options for the Digital Video Broadcasting Satellite Second Generation (**DVB-S2 Input, DVB-S2 Input Status, DVB-S2 Advanced Features**, and **DVB-S2 SIS**) and other input (**MPEG IP Receive, ASI, VSB, Turbo PSK**).

### Conditional Access

This page contains a number of page buttons that provide detailed information and configuration options related to the **BISS Interface, BISS service, BISS Selected Service, BISS TS, CAM slot, CAM Selected PID, CAM Options** and **CAM Selected Services**.

### Services

The **Services** page displays four tables with information and settings for the **Service Selection, Selected Services, Selected Audio**, and **Selected SCTE 35**.

Also in the Services section, a number of other pages are available:

- **SI**: This page provides access to service information and management. Page buttons display tables with detailed information related to **SI Service, SI Program, SI Video, SI Audio, DVB Subtitles Information, DVB Subtitles, VBI, Other, TS, Service Lock, PID Lock, Audio PID Lock, Audio**, and **SCTE 35 PID Lock**.
- **Video & Audio**: This page provides access to video and audio information and management. Page buttons display tables with detailed information related to **Video, Video Output, Format, SD Aspect Ratio, HD Aspect Ratio, Overlay, Low Latency, Audio Service, Audio Service Discrete**,and **Audio Offset Table**.
- **ANC Decoder & Options**: This page provides access to ancillary information and management. Page buttons display tables with detailed information related to the **ANC Decoder, ANC Line Conflict, ANC Options**, and **SCTE 104** translator.
- **GEN Lock**: This page provides access to generator locking information and management. Page buttons display tables with detailed information related to **GEN Lock, HD GEN Lock, SD GEN Lock, Video Output Gen Lock**, and **OpenGear Genlock.**
- **SCTE 35 Services & Messages**: This page provides access to SCTE 35 broadcast standard information and management. Page buttons display tables with detailed information related to **Service, Message, ESAM, DPI Cue Trigger, Insertions**, and **Message Insertions**.

### TS Outputs

This page displays the **Transport Stream Outputs** table. You can access **MPEG IP TX** and **MPEG IP TX FEC** information and settings with the page buttons at the bottom.

The page also contains the **PID Filter Objects** page button at the bottom and **MPE Mac Table**, **MPE Table**, and **Output Source Table** buttons.

### Baseband Output

This page displays the **HD SDI** and **SD SDI** tables. The page buttons **Composite, SDI Audio, AES Audio, Analog Audio, HD Discrete 104, SD Discrete 104** and **SCTE 104 Messages** provide access to more information and settings.

### Polling Control

On this page, you can manage the customizable timers for each of the tables in the connector. You can select a polling time in a range between 60 seconds and 7 days, in steps of 60 seconds. When a polling time with value 0 is configured, the timer will be set as idle.

### Device Web Page

This page displays the web page of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

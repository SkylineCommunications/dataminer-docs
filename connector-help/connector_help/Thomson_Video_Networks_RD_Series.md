---
uid: Connector_help_Thomson_Video_Networks_RD_Series
---

# Thomson Video Networks RD Series

The **Thomson Video Networks RD Series** unit is an encoder for SD and HD signals. Its chassis features a plug-and-play structure that lets you add up to six interface boards. It supports a DVB-S Dual-Port Receiver, ASI Input/Output, COFDM Receiver, MPEG over IP with FEC, DVB-S2 Dual-Port Receiver and Audio Outputs.

## About

This connector is used to manage and monitor Thomson Video Networks RD2000 and RD5000 MPEG-4 Multi-Format Receiver devices via SNMP protocol.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 7.5.2                       |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information about the system: **Description**, **Up Time**, **Contact**, **Name** and **Location.**

### Unit

This page contains more specific information about the unit, such as the **Alias**, **Password**, **Serial Number**, **Model**, **Version** and **Fan Temperature**.

You can also configure settings on this page, and view the **Hardware** list table and **Event Log Settings** table via page buttons.

### Inputs

This page displays the transport stream input status and contains a number of basic settings, such as **Backup Mode**, **Primary Restore Mode** and **Switchover Interval**.

The **ASI/310 Input** and **DVB-S2 Tuner Input** status and settings are also available on this page. Further configuration options for the DVB-S/S2 tuner **Input A, B, C and D** are available via the corresponding page buttons.

Services

This page contains configuration options for **Decoders**: **Audio**, **Video**, **BISS** (Basic Interoperable Scrambling System) **and CI** (Common Interface). These parameters can be accessed via the corresponding page buttons.

In addition, the **Source ID** page button displays the **Current Station Name**, **Lookup Mode** and **Timeout**.

### Overlay

This page contains parameters that allow you to configure the **Overlay**.

### SDI/Analog Video

This page contains **Analog Video** configuration parameters for **HD** (High Definition) and **SD** (Standard Definition) formats.

### SD-SDI/Analog Video

This page contains **Analog Video** configuration parameters for the **SD** (Standard Definition) format.

### Analog/Digital Audio

This page contains **Analog** to **Digital Audio** configuration parameters.

### SDI Embedded Audio

This page can be used for the **Embedded Audio** source selection.

### SDI VANC Embedded

This page contains tables with **SDI VANC Embedded** information.

### PAT

This page displays the **Programs Association Tables** (PAT).

### PMT

This page displays the **Programs Map Tables** (PMT).

### MGT

This page contains the **Master Guide Tables** (MGT), with data pointers to other PSIP tables.

### TVCT

This page contains the **Terrestrial Virtual Channel Tables** (TVCT). It defines each virtual channel and makes it possible for EITs to be associated with the channel.

### EIT

This page contains **Event Information Tables** (EIT), containing titles and program guide data.

### STT

This page contains the **System Time Table** (SST), displaying the current time (transmitted at least once per second).

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

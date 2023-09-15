---
uid: Connector_help_Wellav_UMH160R-IP
---

# Wellav UMH160R-IP

The **UMH160** IRD is broadcast-quality MPEG-4 AVC video/audio decoder that performs real-time receiving and decoding of HDTV and SDTV over DVB and broadband IP networks.

## About

The UMH160R-IP connector was designed to monitor all the inputs and outputs of the device. It can also read all the channels running in the device and there is a special configuration page where you can configure the channels. The connector is based on the Wellav UMH 160 IP connector, but supports DCF and uses better, updated code.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *192.168.2.41*

SNMP Settings:

- **IP port**: The port of the connected device, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains status information for the device, including all general information related to the inputs, and the CL Status of the different slots.

### Programs

On this page, you can select the source with the **Source Select** parameter, as well as monitor all the programs currently running on the device.

The **Service Info Configuration** page button allows you to configure the programs, which will influence the DCF connections in the connector.

### Input Receiver

This page contains general parameters related to the frequency and rates for the input receiver.

### Input IP

This page displays the first two IP slots, and allows you to configure these. In addition, the IGMP can be configured via the **IGMP** page button.

### Output Decoder

On this page, you can check various parameters related to the **decoder, subtitles, teletext, audio and video**, and select the options you want from the drop-down menus.

### Output ASI

This page allows you to view and configure the **Constant Rate**.

### Output IP

On this page, you can configure **Output Channel 1** and **Output Channel 2**, including the IP address and port number.

### CA

This page contains **CAM-** and **BISS**-related parameters.

### System

This page displays among others the **Gateway**, **IP Address**, **Trap IP Address** and trap state.

### NTP

This page contains general parameters related to the **NTP Switch**.

### Alarms

This page displays the name of the alarms received via traps. The traps themselves are displayed on the Traps page.

### Traps

This page displays a table with all traps sent by the device, listing the **Time**, **Type**, **IP**, and **OID** for each trap.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface

## DataMiner Connectivity Framework

The version **1.0.0.x** of the Wellav UMH160R-IP supports the usage of DCF and can only be used on a DMA with **8.5.7** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed Interfaces

Physical fixed interfaces:

- **Turner:** Physical Turner Interface with type **in**.
- **IP**: Physical IP Interface with type **in**.
- **ASI IN**: Physical ASI Interface with type **in**.
- **SDI** **Decoder**: Physical SDI Interface with type **out**.

#### Dynamic Interfaces

The dynamic interfaces are created based on **Table 2000 (Service Info Table).**

**Table 2000** will contain all the *DCF output interfaces*.

- **ASI OUT\_***instance value*\_*Interface Type*: Dynamic Interface with type **out**
- **IP OUT\_***instance value*\_*Interface Type*: Dynamic Interface with type **out**.

### Connections

#### Internal Connections

The connections are made following these conditions:

Once the connector is running:

1. If **Decoder Input** is type **Turner**: **TURNER** **IN (ID:1)** --\> **SDI DECODER OUT (ID:5)**
1. If **Decoder Input** is type **ASI**: **ASI** **IN (ID:3)** --\> **SDI DECODER OUT (ID:5)**
1. If **Decoder Input** is type **IP**: **IP IN (ID:2)** **--\>** **SDI DECODER OUT (ID:5)**

If the **ASI Bypass** is **disabled**:

1. If **Decoder Input** is type **Turner**: **TURNER** **IN (ID:1)** **--\> ASI** **OUT (ID:4)**
1. If **Decoder Input** is type **ASI**: **ASI** **IN (ID:3)** **--\> ASI** **OUT (ID:4)**
1. If **Decoder Input** is type **IP**: **IP IN (ID:2)** **--\>** **ASI OUT (ID:4)**

If the **IP Bypass** is **disabled**:

1. If **Decoder Input** is type **Turner**: **TURNER** **IN (ID:1)** **--\> IP** **OUT (ID:6)**
1. If **Decoder Input** is type **ASI**: **ASI** **IN (ID:3)** **--\>** **IP** **OUT (ID:6)**
1. If **Decoder Input** is type **IP**: **IP IN (ID:2)** **--\>** **IP OUT (ID:6)**

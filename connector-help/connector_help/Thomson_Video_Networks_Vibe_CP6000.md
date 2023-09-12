---
uid: Connector_help_Thomson_Video_Networks_Vibe_CP6000
---

# Thomson Video Networks Vibe CP6000

The Vibe CP6000 is a contribution platform that enables users to transport up to eight acquisition-quality SD or HD services. It is a future-proof modular rack, with four hot-swappable slots. It is based on the ATCA telecom standard and offers the highest possible quality, flexibility, and reliability. Its MPEG modules embed audio and video patterns, providing flexible error management. The Vibe CP6000 encodes and decodes up to eight stereo channels and manages Dolby E and audio uncompressed passthrough.

## About

This connector is designed to monitor the state of the audio and video of both the CP6000 encoder and decoder module. It also monitors the values of the different parameters present in the input(s) and output(s) for both the encoder and the decoder, and it allows the user to manage the transport stream for both modules (encoder and decoder). The different parameters from the device are displayed on multiple pages grouped by function.

This connector will export different connectors based on the number of slots present in the device. The current list of exported connectors can be found in the section "Exported Connectors".

From version 1.0.1.5 onwards, the **DataMiner Connectivity Framework** has been implemented in the connector.

### Version Info

| **Range**            | **Description**                                                                                                             | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                                                            | No                  | No                      |
| 1.0.1.x              | New feature: translated table for multicast IP address and port + fixed problem with Alarm Table.                           | Yes                 | Yes                     |
| 1.0.2.x              | \- Changed layout. - Fixed linking between tables. - Alarm monitoring on PID bit rates returns a user-friendly description. | Yes                 | Yes                     |
| 1.0.3.x              | Table display keys changed to avoid duplicate naming.                                                                       | Yes                 | Yes                     |
| 1.0.4.x \[SLC Main\] | Reorganized the internal linking to accommodate the different functions that use the connector.                             | Yes                 | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.1.x   | CP6000 04.20.02        |

### Exported Connectors

| **Exported Protocol**                                                                                                  | **Description** |
|------------------------------------------------------------------------------------------------------------------------|-----------------|
| [Thomson Video Networks Vibe CP6000 Decoder](xref:Connector_help_Thomson_Video_Networks_Vibe_CP6000_Decoder) | Decoder modules |
| [Thomson Video Networks Vibe CP6000 Encoder](xref:Connector_help_Thomson_Video_Networks_Vibe_CP6000_Encoder) | Encoder modules |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device, by default value *public*.
- **Set community string:** The community string used when setting values on the device, by default value *private*.

## Usage

### General

This page contains general information, such as **Equipment Type**, **Equipment Serial Number**, **Part Number**, **Software Version**, **Configuration Version**, the total number of **Network Interfaces**, and the **Equipment Commercial Options.**

The following page buttons are available:

- **Settings**: This page displays various settings related to the device itself, such as **IP Address**, **Equipment Name**, **Time Servers**, **Read/Write Community Strings**, **Gateways**, and **Daylight Savings**.
- **Commercial Options**: This page displays commercial information.

### Modules

This page displays the different modules and slots, categorized according to function. Both of the tables on the page refer to the **DataMiner Virtual Element(s)** created by this connector.

### Configurations

This page displays a list of stored **configurations**. A configuration can be selected from the list and applied to the device.

### Components

This page contains information about the **modules** that are connected to the device and about the **software versioning**.

### Interfaces

This page contains a table with information about the **Ethernet** connections, such as the **port number**, **IP address**, **netmask**, **default gateway**, **speed**, **IGMP mode**, **state**, **bit rate**, **packet rate**, and **description**.

The following page buttons are available:

- **Interface Route**: Contains a table with information about the **router**.
- **Intf Modulator**: Contains a table with information about the **modulator**.
- **Interface ASI**: Contains a table with information about the **ASI**.
- **Interface Reference**: Contains a table with information about the **reference**.

### Overview

On this page, you can find the **Network Interfaces**, the **IP Addresses Table**, and the **Element Status Table**.

### Notifications

This page displays the **Active Alarms Table**. It also contains a page button that can be used to open the **Status Element Table**.

### Structure

This page shows information about the structure of the network.

The following page buttons are available:

- **PID Entry**: Contains a table with information on the **parameter IDs**.
- **Service Table**: Contains a table with information about the **services**.
- **SDI Table**: Contains a table with information about the **SDI**.
- **SDI Audio Table**: Contains a table with information on the **SDI audio**.

### Bit Rate

This page allows you to monitor the bitrate of the equipment through the following tables: **TS Bit Rate Table**, **PID Bit Rate Table**, and **Service Bit Rate Table**.

### Counters

This page contains a table with information about the **IP receiver**, with several counters.

### Front Panel Stats

This page displays several parameters, each representing a **LED**, **bar graph**, or **buzzer** from the real front panel.

### Decoding

On this page, you can configure the parameters for the **Video** and **Audio** **Decoding**.

### Service Config & Demultiplex

This page contains the **Input Service**, **Output** and **Ancillaries VBI** tables for the **decoder** module.

### Transport Translation

This page includes the **Transport Translation** **Table**, with a **destination name**, **IP address**, and **Port Number**.

### Transport Management

This page includes the **Transport** **Table** and **Transport IP Rx** **Table** for the **decoder** module.

### Decoder Slot Structure

This page contains a table with information about the **Decoder Slot Structure**.

### Decoder Interfaces

This page contains two tables with information about the different **Ethernet and SDI Interfaces** of the **decoder**.

### Redundancy

This page is the last one for the **decoder** module and contains the **Redundancy** **Table**.

### Encoding

On this page, you can configure the parameters for the **Video** and **Audio Encoding**.

### MPEG Service

This page displays the **Output Service**, **Multiplexing**, and **DPI** tables for the **encoder** module.

### Transport Stream

The page displays the **Encoder Transport Stream Constitution**, **Encoder** **Transport**, and **Encoder Transport IP Tx Tables**.

### MPEG Transport Stream

This page allows you to configure the **Encoder Transport Stream Table** for the encoder module.

### Input Stream with External Component

This page contains the **Encoder External Components** and **Encoder IN Transport Table** for the encoder module.

### Encoder Slot Structure

This page contains a table with information about the encoder slot structure.

### Encoder Interfaces

This page contains two tables with information about the different **Ethernet and SDI Interfaces** of the encoder.

There is one page button available, **MPTS Output**, which displays a table with information about the MPTS output.

### Profile

This page displays the **Encoder Profile** and **Profile Selection Table** for the encoder module.

### VBI & Ancillaries Management

This page contains the **Encoder VBI**, **Encoder** **Ancillaries**, and **Encoder VBI Line** tables for the encoder module.

### Descriptors

This page contains information on the **Subtitling Subscriptors**.

### Scrambling

This page contains information on the **Scrambling Profile**.

### Gateway

This page contains information on the **Input and Output Gateways**.

### Modulator

This page contains information on the **Modulator**.

### Config

This page contains a tree view of the encoder and decoder configuration.

### Monitoring

This page contains a tree view that illustrates the monitoring of the decoder's structure.

### Web page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

Version **1.1.0.5** of the Thomson Video Network Vibe CP6000 supports the usage of DCF and can be only used on a DMA with **8.5.7** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic Interfaces

The dynamic interfaces are created based on the number of rows in **Table 600 (DCF Input Interfaces)** and **Table 700 (DCF Output Interfaces)** for both the **decoder** and the **encoder.**

**Table 600** will contain all the DCF input interfaces for the **encoder** and **decoder**. The total number of rows depends on how many rows there are in **Table 6000 (Decoder Transport Table)** and **Table 19000 (Encoder TS Input Table)**.**
Table 700** will contain all the DCF output interfaces for the **encoder** and **decoder**. The total number of rows depends on the rows in **Table 5000 (Decoder Output Table)** and **Table 33000 (Encoder Transport Table).**

- **DEC_IN\_***instance value*\_*Interface Type*: Dynamic Interface with type **in**.
- **ENC_IN\_***instance value*\_*Interface Type*: Dynamic Interface with type **in.**
- **DEC_OUT\_***instance value*\_*Interface Type*: Dynamic Interface with type **out**
- **ENC_OUT\_***instance value*\_*Interface Type*: Dynamic Interface with type **out**.

### Connections

#### Internal Connections

The connections are made as follows:

- **DEC_IN\_***instance value*\_*Interface Type* **(ID: dynamic)** --\> **DEC_OUT\_***instance value*\_*Interface Type* **(ID: dynamic)**
- **ENC_IN\_***instance value*\_*Interface Type* **(ID: dynamic)** --\> **ENC_OUT\_***instance value*\_*Interface Type* **(ID: dynamic)**

## Notes

### Upgrading from 1.0.2.x to 1.0.3.x

If you want to upgrade from range 1.0.2.x to range 1.0.3.x, take the following display key changes in account:

- **Transport IP Decapsulator Table**: Index added to the display key.
- **TS Bit Rate Table**: INTF Element Index added to the display key.
- **Transport IP Rx Counters Table**: INTF Element Index added to the display key.
- **Transport IP Rx Structure Table:** INTF Element Index and Element Index added to the display key.
- **TS Structure Table**: INTF Element Index added to the display key.
- **Service Structure Table**: TS Element Index added to the display key.
- **SDI Audio Structure Table**: Element Index added to the display key.

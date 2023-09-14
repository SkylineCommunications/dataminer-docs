---
uid: Connector_help_2Wcom_Flex_DRS02+
---

# 2Wcom Flex DRS02+

The **2Wcom Flex DSR02+** is an integrated receiver-decoder (IRD). This connector allows the management of the 2Wcom Flex DSR02+ device using the **SNMP** protocol.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                   |
|-----------|------------------------------------------|
| 1.0.0.x   | ARM FW:04.78, DSP FW:3.62, FPGA FW: 2.16 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device default: *public.*
- **Set community string**: The community string used when setting values on the device default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### General

This page contains general parameters such as the **Hostname** and the general system information. In addition, three page buttons are available, which display more information about **SNTP**, **SNMP,** and **Service Info**.

There is a button that allows you to restart the device (**Restart Device**) and a button to refresh the data (**Refresh**).

### Interface

This page shows two tables with interface information.

It also contains the following audio-related parameters: Audio Low Pass 15kHz, Headphone Volume, and Headphone Audio Channel.

### Input Source

This page shows several table with information related to the input source. The **Switch Criteria** page button displays all the switch criteria parameters.

### State Overview

This page gives an overview of the state of the device, including the Internal Storage State, Internal Storage Free Memory, Case Temperature and Case Temperature Alarm Active.

The page contains six page buttons, which display the following subpages:

- **Audio Over IP**: Contains two tables with information about the audio over IP state.
- **TS State**: Contains a table with information about the TS state, as well as the parameters Network ID, Tuner Datarate, ASI Datarate, IP Datarate, Etr290 Conformity, and Etr290 Conformity Alarm Active.
- **Tuner State**: Displays parameters such as RF Power Value, C/N Value, CFO Error Value, AGC, State, CE State, SYM Time State, Carrier State, FEC Locked State, Locked State, Puncture Rate, Viterbi/LDPC BER Value, and RS/BCH BER Value.
- **Input Source**: Contains a table with information about the input source state.
- **DTE State**: Contains a table with information about the DTE state.
- **Audio State**: Contains a table with information about the audio state**.**

### Events

This page gives an overview of the event parameters related to the tuner (e.g. Tuner RF Power Event Value, Tuner RF TS Sync Event T1), ASI (e.g. ASI TS Sync Event T1) and IP TS (e.g. IP TS Sync Event T1).

Several page buttons are available, which show more detailed event information and settings. The **Other Events** page button shows settings for case temperature events and internal storage.

### Alarms

This page shows an overview of the alarms in the Tuner Alarm Table.

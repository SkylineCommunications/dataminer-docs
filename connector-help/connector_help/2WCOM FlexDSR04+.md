---
uid: Connector_help_2WCOM_FlexDSR04+
---

# 2WCOM FlexDSR04+

The **2WCOM Flex DRS04+** is an integrated receiver-decoder (IRD). This driver allows the management of the 2WCOM Flex DSR04+ device using the **SNMP** protocol.

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

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the data pages detailed below.

### General

This page contains general parameters such as the **Hostname**, the **System Description**, and **SNTP Information**. In addition, two page buttons are available, which allow you to retrieve more information about **Trap Settings** and **Service Info**.

There are also buttons that allow you to restart the device and refresh the data.

### Interface

This page displays the **DTE Interface Table**.

### Input Source

This page shows information in the following tables:

- **Audio Output1 Table**
- **Audio Output2 Table**
- **Audio Output3 Table**
- **Audio Output4 Table**
- **IP Output Table**

The **Switch Criteria** page button contains all the switch criteria parameters.

### State Overview

This page gives an overview of the state of the device, including the **Internal Storage State**, **Internal Storage Free Memory** and **Case Temperature**. It also displays the **Internal Storage Table** and **Remote Control Uploads** parameters.

The page contains six page buttons that display more detailed information:

- **Audio Over IP**: Displays two tables with information about the Audio Over IP (UDP Input Data Table and Icecast Input Data Table).
- **TS State**: Displays information about the TS state in the TS Sync Table and with the parameters Network ID, Tuner Datarate, ASI Datarate, IP Datarate, Etr290 Conformity, and Etr290 Conformity Alarm Active.
- **Tuner State**: Displays multiple parameters related to the tuner state.
- **Input Source**: Displays a table with information about the input source state.
- **DTE State**: Displays a table with information about the DTE state
- **Audio State**: Displays a table with information about the audio state.

### Events

This page gives an overview of the event parameters related to the tuner (e.g. Tuner RF Power Event Value, Tuner RF TS Sync Event T1), ASI (e.g. ASI TS Sync Event T1) and IP TS (e.g. IP TS Sync Event T1).

In addition, the following page buttons display more detailed event information:

- **Audio Event**: Displays a table with information about the audio event settings.
- **Icecast Event**: Displays settings in the Aoip Icecast Input Data Event Table.
- **UDP Event**: Displays settings in the Aoip UDP Input Data Event Table.
- **Flexsource Event**: Displays settings in the Flex Source Event Table.
- **DTE Event**: Displays settings in the DTE Event Table.
- **Audio Level Event**: Displays settings in the Audio Level Event Table.
- **Other Events**: Displays settings for case temperature events (e.g. Case Temperature Event Max Value) and internal storage (Internal Storage Event Enabled).

### Alarms

On this page, the **Tuner Alarm Table** displays an overview of the alarms.

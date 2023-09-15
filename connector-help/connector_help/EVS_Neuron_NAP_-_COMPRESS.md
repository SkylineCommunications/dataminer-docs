---
uid: Connector_help_EVS_Neuron_NAP_-_COMPRESS
---

# EVS Neuron NAP - COMPRESS

This connector is intended to be used with the Neuron COMPRESS, which provides the convert function of the EVS Neuron.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5.0.0                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (fixed value: 2072).

## How to Use

The connector does not have a polling timer. It only polls the data at element startup; however, there is also a button available that allows you to trigger the polling manually.

After element startup, the connector can also receive events (unsolicited messages).

### General

This page contains card information parameters, such as the **Card Name**, **Product Version**, and **Card Description**.

### General Settings

This page includes the **Gen Lock Settings**, **Input Stream Configuration**, and **De-Embedders** parameters as well as buttons for pop-up pages.

### Network Settings

This page contains network-related tables such as **MAC settings, MAC DNS Settings**, and **MAC Statistics.**

### IP Video I/O

This page contains tables for **Video Input/Output Streams** as well as **Video Output Backup Streams.**

### IP Audio I/O

This page contains tables for **Audio Input/Output Streams** as well as **Audio Output Backup Streams.**

### SDI I/O

This page contains tables for **SDI Static I/O** and **SDI Bidirectional I/O.**

### Audio Paths

This page contains tables for **De-Embedded Audio** and **IP Audio.**

### Video Paths

This page contains tables for **Video Formats, Video Paths**, and **Video Paths Color Correction.**

### Compress

This page displays **Compression Rate,** **Compression Ratio**, and **Quality Optimization.**

### Chassis

This page contains chassis information parameters, such as **Board**,** IO Board,** **Board Temperature**, and **SMARC**.

### Power Supply Unit

This page displays **Fan Control, Power Consumption**, and **Temperature** parameters, as well as the **Power Supply Units** table.

### Management Port

This page contains parameters related to **Ethernet** and **DNS**.

### Network interface Modules

This page contains **SQFP** and **SFP** tables.

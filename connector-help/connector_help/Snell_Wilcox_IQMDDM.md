---
uid: Connector_help_Snell_Wilcox_IQMDDM
---

# Snell Wilcox IQMDDM

The IQMDDM is an ASI 2 to 1 switch, distribution amplifier and transport stream monitor with up to 8 outputs in double width or 4 outputs in single width. The inputs are transformer coupled and equalized to \> 200 m of high quality cable. All outputs are re-clocked and transformer coupled. There is independent control of the input to be passed to the distribution amplifier outputs and the input to be passed to the transport stream monitor. The IQMDDM monitors the legality of the MPEG2 transport stream to ETR 290 Priority 1. In addition, some priority 2 and 3 parameters are also checked. On the double width module a GPI port is available which may be configured to any control or reporting parameter. All control and monitored parameters are available for access over the RollCall remote control network. The RollCall logging utility enables selected events to be logged on a remote server(s).

## About

The connector allows the management of the **Snell Wilcox IQMDDM** using a serial connection.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

## Usage

### General

This page contains info related with **Serial Number** and **Software Version**.

Additional information can be displayed and set on **Logging** subpage.

### Bitrate

Bitrate page display information on **Bitrate Status**, **Bitrate Current**, **Bitrate Maximum**, **Bitrate Minimum** and **Bitrate Continuous Update**.

### Errors

Errors page display information on **All Errors Status**, **Current I/P Status**, **Mon Input Status**, **RSV Status**, **Sync Status**, **ETR290 Status** and **Template Status**.

### GPI

GPI page display GPI 1 & 2 information, namely: **Mode**, **Output Trigger**, **Output Invert**, **Input Invert** and **Status**.

### Input

Input page displays technical information related with **Input (D/A)**, **Input (MON)**, **Input 1** and **Input 2**.

### Programs/Pmts

Programs/Pmts page aims to load and display the List of **Available Services**.

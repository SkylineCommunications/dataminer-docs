---
uid: Connector_help_Stagetec_Montone
---

# Stagetec Montone

The **Stagetec Montone** connector can be used to **display**, **configure** and **monitor** the in- and output streams.

## About

There are two **serial** connections that are used to retrieve the necessary information from the device.

The connector features **DCF** integration but does not use any internal DCF logic.

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

#### Serial IP Port 2 Connection

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

## Usage

### General

This page contains **general** information about the device and the **two interfaces**.

### Advanced

This page allows you to configure **advanced settings** on the device.

Two buttons at the bottom of the page open the **Network Settings** and the **PTP Clock Settings**, respectively.

### Statistics

This page contains the **Packet Lost** table, which displays the packet loss for each protocol.

### Inputs

This page displays the **Input Stream** table, which lists all 32 streams with all the relevant information.

### Outputs

This page contains the **Output Stream** table, which lists all 32 streams.

### Web Interface

This page provides access to the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

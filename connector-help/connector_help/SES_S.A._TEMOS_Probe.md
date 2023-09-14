---
uid: Connector_help_SES_S.A._TEMOS_Probe
---

# SES S.A. TEMOS Probe

TEMOS is a system at SES S.A. that is able to retrieve satellite telemetry data from a server named TLMCore. The TLMCore is a socket server that handles XML requests. This protocol allows users to observe the telemetry data in the form of a table of channels.

## About

This protocol uses a serial connection to obtain the telemetry data from the TLMCore server.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

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

## Usage

### General

This page displays the current connection status of the satellite probe. The satellite's specific channel and LRV information used for poling the TLMCore server are displayed in the **LRV Table**.

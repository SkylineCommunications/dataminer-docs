---
uid: Connector_help_SES_S.A._Global_Telemetry_System
---

# SES S.A. Global Telemetry System

The SES S.A. Global Telemetry System is a system at SES S.A. that provides telemetry data of specific satellites. This connector displays the telemetry data in a table.

## About

For each satellite available, one element must be created using an IP address and a specific port. Each port receives a continuous UDP stream with the relevant telemetry data of a specific satellite.

### Version Info

| **Range** | **Description**                                                          | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version (obsolete)                                               | No                  | Yes                     |
| 1.0.1.x          | \- Added RF Out Column to the Telemetry Table - Auto clear functionality | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |

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

The General page displays the **Telemetry** table, which contains the telemetry data of a single satellite.

This table contains the following columns:

- **Channel**: Concatenation of the satellite, transponder and tube name.

- **DateTime**: Timestamp of the last update of the channel.

- **Satellite**: Name of the satellite.

- **Transponder**: Name of the transponder.

- **Tube**: Name of the tube.

- **Sat I/P**: The satellite I/P in dBm.

- **Mode**: The mode of the channel.

- **Nominal ALC**: The nominal automatic level control of the channel in dBm.

- **Nominal FG**: The nominal fixed gain of the channel in dBm.

- **Tube Status**: The status of the tube.

- **High Voltage Status**: The high voltage status of the channel.

- **DCC Status**: The digital command control status of the channel.

- **RF Out**: The radio frequency out of the channel.

- **RF Status**: The radio frequency status of the channel.

- **FCA Status**: The flux control attenuator of the channel.

- **GCA Status**: The gain control attenuator of the channel.

- **Helix Status**: The helix of the channel in mA.

- **Nominal ALC Mode**: Mode that determines which nominal ALC value will be used to calculate the deviation (Custom/LRV).

- **Nominal ALC Mode**: Mode that determines which nominal FG value will be used to calculate the deviation (Custom/LRV)

- **Custom Nominal ALC**: Value for the nominal ALC defined by the user in dBm.

- **Custom Nominal FG**: Value for the nominal FG defined by the user in dBm.

- **Deviation**: Deviation of the channel in dBm. To calculate this value, the following values must be available:

- Mode
  - Sat I/P
  - Nominal ALC/FG
  - Nominal ALC/FG Mode
  - Custom Nominal ALC/FG

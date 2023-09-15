---
uid: Connector_help_ITNM_Systems_IDM100_General
---

# ITNM Systems IDM100 General

This connector is used to retrieve the **transport streams** and the **services** from the transport streams from the **ITNM Systems IDM100** analyzer, and to display information about the services. The connector uses a serial connection to send HTTP commands to the device.

## About

This connector sends HTTP commands to the IDM100 over a serial connection. The connector only polls the **transport streams** of the ITNM Systems IDM100.

### Version Info

| **Range** | **Description**                  | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------|---------------------|-------------------------|
| 2.0.0.x          | Integration of previous version. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main connection

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

This page displays general information about the device.

It also contains the **Polling Status**, including the status of the entire polling process, the number of sent and received **Stream Commands** and the number of sent and received **Service Commands**.

### Transport Streams

On this page, the **Transport Streams** table contains an entry for every transport stream in the system.

### Stream Services

This page displays general information about each transport stream, such as the **Stream Name**, **Stream Bandwidth**, etc.

### Stream PIDs

This page displays the **Transport Stream PIDs** table. This table has an entry for each PID in each transport stream.

### Service PIDs

This page displays the **Service PIDs** table. This table has an entry for each PID in each service available in the system.

### Audio / Video Service

This page displays 2 tables: **Audio PIDs** and **Video PIDs**. The audio PIDs from each service are displayed in the **Audio PIDs** table, while the video PIDs are displayed in the **Video PIDs** table.

### PCR / PTS / DTS Service

This page contains extra information about the errors and performance of the service.

It also contains the **General PCR / PTS / DTS Table**, which displays general information about each service.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

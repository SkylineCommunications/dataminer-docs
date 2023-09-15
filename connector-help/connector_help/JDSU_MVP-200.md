---
uid: Connector_help_JDSU_MVP-200
---

# JDSU MVP-200

The JDSU MVP-200 combines a a digital video monitoring probe with a full laboratory-grade Moving Picture Experts Group (MPEG) analyzer for troubleshooting.

## About

This connector uses a serial connection to manage and monitor the JDSU MVP-200.

### Version Info

| **Range** | **Description**                 | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------|---------------------|-------------------------|
| 1.1.3.x          | New Alarm Preset feature added. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.1.3.x          | 4.0.0.0                     |

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
  - **Bus address**: The bus address of the device. (Range: 2 - 1)

#### Serial Traps Connection

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
  - **Bus address**: The bus address of the device. (Range: 2 - 1)

## Usage

### Overview

This page displays a tree view with the element tables.

### General

This page contains module-specific hardware information and network statistics (**Bit-Rate**, **Stream**).

### Streams

This page contains tables related to the streams: **Streams**, **Streams Stats** and **Streams Alarm/Error Count**.

### Programs

This page contains tables related to the programs: **Programs**, **Programs Stats**, **Programs PTS Stats** and **Programs Alarm/Error count**.

### PIDs

This page contains tables related to the PIDs: **PIDs**, **PIDs Stats** and **PIDs PTS Stats**.

### Configuration

On this page, you can manage **configuration** **files**.

### Performance

This page contains information about the hardware performance, such as **Total Processor Load**, **Physical Memory**, **Virtual Memory**, etc.

### Disk Info

This page contains disk information, such as **Size**, **Free Space**, **Disk Usage**, **Read Rate**, **Write Rate**, etc.

### Task Manager

This page contains a table with the information from the Windows **Task Manager**.

### Alarm Presets

On this page, you can configure the **Alarm Presets** to be used in the **Streams**, **Programs** and **PIDs** tables. If a **File Directory** is defined, it is possible to **export** a file with the defined **alarms** and **import** the file later.

---
uid: Connector_help_Vertex_TLR-1S
---

# Vertex TRL-S1

The Vertex TRL-S1 connector will display information concerning the Vertex TRL-S1 device.

## About

The **Vertex TRL-S1** is a **tracking receiver** that provides a proportional DC tracking signal from any beacon frequency in the 950 to 1750MHz band for use with antenna control systems in satellite communications earth stations.

The connector for this device uses **serial** communication.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.1.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.1.0.x          | Unknown                     |

## Installation and configuration

### Creation

Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600.*
  - **Databits**: Databits specified in the manual of the device, e.g. *7.*
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1.*
  - **Parity**: Parity specified in the manual of the device, e.g. *No.*
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No.*

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

## Usage

### Main View

This page displays a summary of the most significant monitored parameters.

### General

This page displays the general parameters of the device.

### TBT Parameters

This page displays the **TBT types** and the **TBT status** parameters. There's also a list with editable parameters for **TBT configuration**.

### Communication

This page displays information about the **serial communication link**.

### Save Beacon & Load Beacon

On this page, you can save or load a beacon.

### Measurement

This page displays the different **tuning voltages** and the **temperature**.

### Normalize Alarms

On this page, you can normalize the tracking voltage.

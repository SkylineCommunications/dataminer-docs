---
uid: Connector_help_Xicom_Technology_XTD-2500KL
---

# Xicom Technology XTD-2500KL

The XTD-2500KL is a compact antenna-mounted high-power amplifier designed for applications requiring high transmit power levels.

## About

The Xicom Technology XTD-2500KL connector is based on the connector XTD-400K from the same vendor. The main difference between these connectors is that the Xicom Technology XTD-2500KL connector uses a single command to retrieve and display the Helix voltage and current for both amplifier tubes. It was also modified to have cleaner code and updated code for readability and usability.

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

- Interface connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device, by default *8*.
  - **Stopbits**: Stopbits specified in the manual of the device, by default *1*.
  - **Parity**: Parity specified in the manual of the device, by default *No*.
  - **FlowControl**: FlowControl specified in the manual of the device**.**
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device, by default *65*. Range: *255 - 64*.

## Usage

### General

This page displays general information related to the device: the **Model**, **Serial Numbers**, **Modes**, and **Firmware**.

### Amplifier

This page displays information regarding the **Output**, **FWD**, and **Reverse Power**, the **Helix Voltage** and **Currents**, and more. You can also set the **Constant Power** here.

### Fault Control

This page allows you to check and set the **Power High Trip, Power Low Trip** and **Reverse Power Trip** parameters. There is also a **Fault Reset** button.

### Alarm

This page shows which alarms are currently present on the device.

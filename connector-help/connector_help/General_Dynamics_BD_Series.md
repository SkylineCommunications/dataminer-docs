---
uid: Connector_help_General_Dynamics_BD_Series
---

# General Dynamics BD Series

With this connector, you can poll status data from and configure settings on **General Dynamics BD downconverters**.

## About

This connector uses **serial** communication. It allows the usage of ACK messages. The integrity of the messages is checked with a checksum.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.092                       |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. Required.
  - **Bus address**: The bus address of the device. Required. Default value: *01*. Range: *00* to *31*.

## Usage

### General

This page contains the **Product Type, Power Supply 1/2 Voltage, Firmware Mask Number,** **Firmware Version Number, Controller Fault** and **Local Lockout** parameters. You can also perform a number of special actions via the following buttons: **Self-Tests, Reset Latched Faults, Clear Service Request** and **Reset.**

### Status

On this page, different status parameters are displayed: **Unit 1, Unit 3, OSC External, Power Supply 2, Remote Mode, Switch 3 Position, ...**

### Faults

This page displays the **Latched/Active Switch Fault, Latched/Active Controller Fault, Latched/Active Unit Current Alarm, Latched/Active Power Supply Fault** and **Latched/Active OSC Fault.**

### Configuration/Control

This page displays the following parameters: **Priority Setting, Latched Faults, Remote Disables Local, Auto Disables Manual, Remote Forces Auto, System Configuration, System Type** and **Redundancy Mode**.

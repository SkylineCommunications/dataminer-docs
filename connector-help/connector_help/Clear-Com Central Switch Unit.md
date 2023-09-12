---
uid: Connector_help_Clear-Com_Central_Switch_Unit
---

# Clear-Com Central Switch Unit

The CSU is a matrix to enable push-to-talk communications between network operators and customers.

## About

This driver uses a **serial** connection to communicate with the device.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | HCI 2.0                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This driver uses a serial-over-IP connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage

### General

This page displays general-purpose information such as **Master Uptime** and **Reset Flags**.

### Panel

On this page, you can fill in the necessary information to manually send a **Key Panel Assignment** command. It contains parameters such as **Card Number**, **Port Number**, **Destination Port**, **Key Number**, **Panel Type** (unused) and **Destination Type**.

### Crosspoints

This page contains a 512x512 **matrix** that displays the current **crosspoints**.

### Configuration

On this page, you can configure the necessary information to send notifications to the manager element.

The most important parameters are **DMA Id**, **Element Id**, **Other Parameter Id** and a toggle button to **enable** or **disable notifications**.

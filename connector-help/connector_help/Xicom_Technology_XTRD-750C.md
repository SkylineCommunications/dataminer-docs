---
uid: Connector_help_Xicom_Technology_XTRD-750C
---

# Xicom Technology XTRD-750C

The **Xicom Technology XTRD-750C** connector can be used to display and configure information regarding the related controller.

## About

This protocol can be used to monitor and control the Xicom Technology XTRD-750C controller. A serial connection is used in order to successfully retrieve and configure the information of the device.

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

#### Serial connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: 1200 to 57900
  - **Databits**: 8
  - **Stopbits**: 1
  - **Parity**: No
  - **FlowControl**: No

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.
  - **IP port**: The port of the connected device, by default *161*.
  - **Bus address**: Range 64 to 255.

## Usage

This connector has three pages, **General**, **Amplifier** and **Alarm**, as well as one pop-up page, **Alarm Settings.**

### General

This page displays the controller's general information, such as the **Amplifier Model Number**, **Amplifier Serial Number**, **Firmware Version**, **Temperature**, etc.

### Amplifier

This page contains all amplifier-related readings and settings of the controller, such as the **Output Power**, **Attenuator**, etc.

### Alarm

This page contains the controller's alarm reading, with parameters such as **Summary Alarm**, **Current Alarm Status**, etc.

### Alarm Settings

This page contains the controller's alarm settings, with parameters such as **Min/Max/Reflected Power Alarm**, and **Min/Max/Reflected** **Power Fault**.

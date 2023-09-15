---
uid: Connector_help_SA_Redus_Switch
---

# SA Redus Switch

The **Redus source selector** is an intelligent ASI switch used in applications where one-to-one redundancy is required.

## About

The Redus Switch can be used as a standalone redundancy switch for third-party equipment or for the Cisco ROSA Network Management System (NMS). The connector for this device uses a **serial** connection to configure and monitor the switch.

### Version Info

| **Range** | **Description**                                                                          | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                                                         | No                  | Yes                     |
| 1.0.1.x          | Improvement of logic and UI - No support for multiple elements polling the same IP:Port. | No                  | Yes                     |
| 2.0.0.x          | Removed redundant polling - Now supports multiple elements polling the same IP:Port.     | No                  | Yes                     |
| 2.0.1.x          | Added DCF.                                                                               | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |
| 2.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device. Default: *8*.
  - **Stopbits**: Stopbits specified in the manual of the device. Default: *1*.
  - **Parity**: Parity specified in the manual of the device. Default: *no*.
  - **FlowControl**: FlowControl specified in the manual of the device. Default: *no*.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. Range: *126 - 0*.

#### Serial Secondary Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device, e.g. *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. Range: *126 - 0*.

## Usage

### Main View

This page shows the main parameters, such as **ASI Output Signal**, **Selected Source**, **Input Sync**, **Data Format**, **Bitrate** and **Bitrate Status**.

### General

On this page, **Device Info** is displayed. This information consists of the device **Name** and **Serial Number**, the **Internal Temperature**, the **State of Device**, the **Execute** and **Polling** statuses, and also the configurable **Date/Time**.

Via the **Hardware Info** page button, you can also view the **FPGA Type** and **Version**, as well as the **Hardware Version**.

### Settings

On this page, you can configure the device. The page consists of three main sections:

- **Input and Channel Settings:** Consists of the parameters **Source Selection**, **Priority**, **Switch Delay**, **Check on Stuffing**, **Stuffing Limit**, **Check on PAT**, **PAT Interval**, **Hard Contact Control** and **Restore Input 1**. Some of these parameters are mutually dependent, e.g. when HCC is enabled, Source Selection allows you to select the related option.
- **Input Toggling:** Allows input toggling via the toggle button **Selected Source**, which can only be used when **Toggling Input** is enabled.
- **Device Measurements**: Displays parameters such as the **Input Signal Status**, **Data Format**, **Lock Status**, **BitRate**, **BitRate Status** and **Stuffing BitRate**.

### Alarms

This page displays the critical **Device Messages** of the device, i.e. the **ASI Output Signal**, **Input Synchronization**, **Temperature**, **Main** **Power Supply**, **PAT** and **Stuffing** statuses.

## DataMiner Connectivity Framework

The **2.0.1.x** connector range of the **SA Redus Switch** protocol supports the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

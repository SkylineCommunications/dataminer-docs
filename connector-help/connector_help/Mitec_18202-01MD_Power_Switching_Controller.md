---
uid: Connector_help_Mitec_18202-01MD_Power_Switching_Controller
---

Mitec 18202-01MD Power Switching Controller

This protocol displays status and summary information of the **Mitec 18202-01MD Power Switching Controller**. It also allows the user to execute remote commands to change the configuration of the device.

The Mitec 18202-01MD Power Switching Controller can monitor and control 4 RF Switches.

## About

Serial commands are used to retrieve the device information and to execute the settings.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Device Firmware Version</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td><p>Software version 01</p>
<p>Model Number 18202</p></td>
</tr>
</tbody>
</table>

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: 9600
  - **Databits**: 7
  - **Stopbits**: 1
  - **Parity**: even
  - **FlowControl**: no

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. This is required. The default value is *14* *(8013)*.
  - **Bus address**: The bus address of the device. This is required. The default value is *31 (hex)*.

## Usage

### General

This page displays the **Model Number.**

### Status

This page displays the **Local/Remote** **Mode**, **Switch** **Summary** and **Power Supply Summary**, and finally also the **Switch 1, Switch 2, Switch 3, and Switch 4 settings.**

The **Switch 1, Switch 2, Switch 3 and Switch 4** can be configured by clicking the **Togglebutton** under each position.

There are two possible positions for each switch: **Position 1 and Position 2.**

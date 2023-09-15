---
uid: Connector_help_Mitec_18135-01MD_Switching_Control_Unit
---

# Mitec 18135-01MD Switching Control Unit

This protocol displays status and summary information of the **Mitec 18135-01MD Switching Control Unit**. It also allows the user to execute remote commands to change the configuration of the device.

The Mitec 18135-01MD Switching Control Unit can monitor and control 2 high power amplifiers (HPAs). It performs manual or automatic "switch-to-backup" operations of the system's HPAs.

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
<p>Model Number 216804MD Model Number 18135</p></td>
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

This page displays the **Model Number** and the **Software Version**.

### Status

This page displays the **Control Mode**, **Redundancy Mode** and **Operation Mode**, the **Switch Summary** and **Power Supply Summary**, and finally also the **Antenna 1** and **Antenna 2 HPA Summary** and **Antenna 1** and **Antenna 2 Settings.**

The page also contains settings that can be used to configure **Redundancy Mode** and **Operation Mode**, and a button to toggle **Alarm Acknowledge**.

The **Antenna 1** and **Antenna 2 Settings** can be configured by selecting a value in the **Antenna Settings** drop-down list.

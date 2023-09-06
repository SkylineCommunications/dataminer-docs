---
uid: Connector_help_Vertex_RSC-1200
---

# Vertex RSC-1200

The **Vertex RSC-1200** driver will display information related to the **Vertex RSC-1200** device.

## About

The **Vertex RSC-1200**allows monitoring of the **Vertex RSC-1200** SWO device.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | True                    |

### Supported firmware versions

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Driver Range</strong></td>
<td><strong>Device Firmware Version</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td><p>3.00</p>
<p>2.12</p></td>
</tr>
</tbody>
</table>

## Installation and configuration

### Creation

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device. (default: 8)
  - **Stopbits**: Stopbits specified in the manual of the device. (default: 1)
  - **Parity**: Parity specified in the manual of the device. (default: no)
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **Type of port**: TCP/IP
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus:** the bus address, in case of any (Range: 0 - 255)

## Usage

### General Page

This page contains general information about the device such as **Power Supply** and **Unit Current**. Here you can also find pagebuttons to the **Controller Alarms**, **Switch Control** and the **Event Log**.

### Configuration Page

This page displays configurable parameters such as **Redundancy Mode**, **Remote Control**, **Noise Diode...**

### Internal/External Input Alarms Page

This page displays the **Alarm Statuses** of the device.

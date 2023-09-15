---
uid: Connector_help_Miteq_U-9800
---

# Miteq U-9800

This protocol is used to monitor parameters of the **Miteq U-9800** frequency converter. It also allows the user to configure some parameters of the device.

The Miteq U-9800 provides transparent frequency conversion for video and data applications. Monitor and control functions support local and remote control. The device controls frequency and attenuation, and has 64 memory locations for each converter, where various setups can be stored and recalled. A continuously updated log of time-stamped records of activity is implemented.

## About

Serial commands are used to retrieve the device information.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

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
<td><p>172138</p>
<p>179861</p></td>
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
  - **Parity**: odd
  - **FlowControl**: no

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: This is required. The default value is *8008*.
  - **Bus address**: This is required. The default value is *70.* Range: from *64* to *95*.

## Usage

### General

This page displays general parameters of the device, such as the **Unit Name** and **Firmware,** as well as some status parameters, such as **Frequency**, **Attenuation**, **Band Frequencies**, etc.

The page contains several page buttons:

- **Alarms**: Displays alarm status parameters and the **Alarm Log Table**.
- **Band Frequencies**: Displays the **Input Low/High Frequency** and **Output Low/High Frequency**.
- **Ethernet**: Displays Ethernet data.

### Voltages

This page displays voltage parameters.

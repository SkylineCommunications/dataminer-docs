---
uid: Connector_help_TSL_PAM2-IP_AMU
---

# TSL PAM2-IP AMU

This device is an **Audio Monitoring Unit** (AMU) for precision audio, on IP networks. It supports Primary and Secondary Dante ports, SDI, AES and Analogue connections, so it can be used on traditional structures.

The protocol gets and sets data on the device through an HTTP API.

## About

### Version Info

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Key Features</strong></td>
<td><strong>Based on</strong></td>
<td><strong>System Impact</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x[SLC Main]</td>
<td><p>Audio Control</p>
<p>SFP Data</p></td>
<td>-</td>
<td>-</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: \[The IP port of the destination.\]
- **Device address**: \[The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.\]

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

### General

This page contains both the **audio configuration**, as well as the **SFP data**.

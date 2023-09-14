---
uid: Connector_help_Sony_Signal_Processing_Unit-NXLK-IP45F
---

# Sony Signal Processing Unit-NXLK-IP45F

The **Sony NXL-FR316** and **Sony NXL-FR318** is a Processing units (chassis), to which different cards can be attached:

- IP converter boards: Sony NXL-IP40F/41F/42F/45F/50Y

## About

This connector is designed to monitor the state of the IP Converter board that can be connected to a **Sony NXL-FR316** and **Sony NXL-FR318**, using **SNMP** communication.

This connector is exported by the parent connector **Sony Signal Processing Unit**, from version 1.0.0.x onwards.

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
<td>1.0.0.x [SLC Main]</td>
<td><ul>
<li>Initial Version</li>
</ul></td>
<td>-</td>
<td>-</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V1.00                  |



## Configuration

### Initialization

This connector is used by DVEs that are **automatically created** by the parent element. No user input is required.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### Status

This page displays detailed status information on the module, including the **Device ID**, **Manufacturer**, **Model**, **Destination**, **Serial Number**, **Category, Version**, **Model Suffix** and **Version Suffix**.

### Alarms

This page displays the **Error Statuses** connected to this module.

### NMI

This page allows you to connect this IP Board to the selected **NMI**. Note: only 1 NMI element can be connected to 1 IP Board Connected to this chassi. You can check which NMI element is connected to which IP Board via the **NMI** table on the main element.



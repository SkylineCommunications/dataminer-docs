---
uid: Connector_help_Skyline_Mediation_IRD
---

# Skyline Mediation IRD

This is a mediation driver for IRDs.

## About

This driver links to parameters in IRD elements, so that the parameters can be displayed in a uniform way.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### Version Info

<table>
<colgroup>
<col style="width: 20%" />
<col style="width: 20%" />
<col style="width: 20%" />
<col style="width: 20%" />
<col style="width: 20%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>DCF Integration</strong></td>
<td><strong>Cassandra Compliant</strong></td>
<td><strong>Linked Components</strong></td>
<td><strong>Exported Components</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td>No</td>
<td>Yes</td>
<td><ul>
<li>Ericsson RX8200</li>
<li>Harmonic Proview PVR8130</li>
<li>Ericsson RX8330</li>
<li>Ateme Kyrion DR5000</li>
<li>Scopus Network Technologies IRD-2900</li>
<li>Cisco D9800</li>
<li>Cisco D9854</li>
</ul></td>
<td>-</td>
</tr>
</tbody>
</table>

## Creation

It is not possible to create elements with a mediation driver. Instead, elements of supported drivers will have an extra menu item in the element card menu that allows you to see the mediation parameters instead of the default parameters.

Supported drivers are:

- Ericsson RX8200
- Tandberg RX1290
- Harmonic Proview PVR8130
- Ericsson RX8330
- Ateme Kyrion DR5000
- Scopus Network Technologies IRD-2900
- Cisco D9800
- Cisco D9854

## How to Use

To view the information from this driver, click to the hamburger button of the element card for one of the supported drivers and select **Mediation layer** \> **Skyline Mediation IRD**.

The card will then display the information from the mediation layer on the **General** page. This information consists of the following parameters:

- BER
- C/N
- Signal Level
- Margin

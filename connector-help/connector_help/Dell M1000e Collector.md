---
uid: Connector_help_Dell_M1000e_Collector
---

# Dell M1000e Collector - Dell M1000e Remote

The **Dell M1000e** **Collector** Protocol communicates with multiple external **Dell Poweredge** devices and collect basic device indicators.

## About

This driver communicates using SNMP Protocol version 2. It allows the monitor and trend of all statuses and readings from remote **Dell M1000e** devices. It can optionally export each Dell M1000e device as a virtual element.

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
<li>DVE</li>
</ul></td>
<td>-</td>
<td>-</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |



## Configuration

### Initialization

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

## How to use

On the **Configuration** page, set **File Import Path**, **Import** the csv file with all the Dell M1000e devices information and set **Polling Status** to Enabled.



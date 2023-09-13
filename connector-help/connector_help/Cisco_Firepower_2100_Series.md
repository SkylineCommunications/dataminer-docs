---
uid: Connector_help_Cisco_Firepower_2100_Series
---

# CISCO Firepower 2100 Series

This driver uses SNMP communication in order to monitor a CISCO device from the Cisco Firepower 2100 Series.

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
| 1.0.0.x   | N/A                    |



### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes/No                  | \-                    | \-                      |



## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: \[The IP port of the destination. (default: *161*)\]

SNMP Settings:

- **Get community string**: \[The community string used when reading values from the device. (default: *public*)\]
- **Set community string**: \[The community string used when setting values on the device. (default: *private*)\]

### Initialization

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

## How to use

This driver functions as a basic monitor tool. There are only a limited amount of setting that can be set trough this driver. The bulk of the tables are polled every hour. But the General Information is polled every 30s and the Interface and Interface X table are polled every 10s.

On the Interface Detailed paged you can find the interfaces, the standalone tables can be found via the "Raw Tables..." button ant the bottom of the page.

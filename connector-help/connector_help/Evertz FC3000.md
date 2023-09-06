---
uid: Connector_help_Evertz_FC3000
---

# Evertz FC3000

This driver monitors the **Evertz FC3000**, a controller card.

## About

The module provides a single point of access to communicate with the entire 3000MVP series of cards. All the monitoring and control information is retrieved via SNMP.

### Ranges of the driver

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Driver Range</strong></td>
<td><strong>Description</strong></td>
<td><strong>DCF Integration</strong></td>
<td><strong>Cassandra Compliant</strong></td>
</tr>
<tr class="even">
<td><p>1.0.0.x</p></td>
<td><p>Initial version</p>
<p>Extra parameters added</p></td>
<td>No</td>
<td>No</td>
</tr>
</tbody>
</table>

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | 2.8                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.150.3.3*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *public*.

## Usage

The driver contains only one page.

### General

This page contains two tables, two blocks of parameters and a page button.

The blocks of parameters display the **Software** and **Hardware** **Information** respectively.

The **Power Supply** page button displays four parameters: **Power Supply 1 Status**, **Power Supply 2 Status**, **Power Supply 1** and **Power Supply 2**.

The **Management Fault Table** contains the following fault information:

- **Fault Name**
- **Send Trap** (used to decide if a trap must be sent)
- **Fault Present**

The **Production Location Table** is indexed by product location instance and contains information on the insertion/removal counters, product name and the starting/ending slots.

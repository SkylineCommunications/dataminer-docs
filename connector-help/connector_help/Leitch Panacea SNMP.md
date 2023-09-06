---
uid: Connector_help_Leitch_Panacea_SNMP
---

# Leitch Panacea SNMP

This driver monitors the activity of the Leitch Panacea SNMP.

## About

The Panacea family of routers is available in 1RU and 2 RU frame sizes. They share a wide array of routing matrices and provide hooks for redundant power, control, and extended processing modules.

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
| 1.0.0.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: \[The IP port of the destination.\]
- **Bus address**: \[The bus address of the device.\]

SNMP Settings:

- **Get community string**: \[The community string used when reading values from the device. (default: *public*)\]
- **Set community string**: \[The community string used when setting values on the device. (default: *private*)\]

### Initialization

The device address needs to be configured in the element settings in order to work.

### Redundancy

There is no redundancy defined.

## How to use

## Main View

This page is the default page and shows the device **Matrix**.

## Status

The Status page displays information about the device in the **Physical Input Status**, **Physical Output Status** and **PSU Overview** tables.

## Matrix Configuration

In this page is possible to configure the size of the Matrix setting up the parameters **Number Of Inputs** and **Number Of Outputs**.

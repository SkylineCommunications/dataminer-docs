---
uid: Connector_help_Intorel_Visionic
---

# Intorel Visionic

Visionic is a complete monitoring and control platform solution for a wide range of Intorel products.

## About

This driver allows the user to monitor the parameters, status and alarms of the available instances.

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
<td>2.0.0.x [SLC Main]</td>
<td><ul>
<li>Displays information about the parameters, status and alarms of the available instances.</li>
<li>Manages traps</li>
</ul></td>
<td>-</td>
<td>-</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 2.0.0.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 2.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

- **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device, e.g. *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device.

#### SNMP Type1 Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to use

### Overview

This page displays a tree view with relevant information about the available instances.

### Structure

This page displays three tables that list the available instances, devices and types.

### Parameter Table

This page displays the Parameter Table. This table contains information such as the name and value of the monitored instance parameters.

### Status Table

This page displays the Status Table. This table contains information such as the status of the instances.

### Alarm Table

This page displays the Alarm Table. This table contains information such as the alarm state of the instances.

### Active Alarms

This page displays the Active Alarms Table.

### Events

This page displays the Events Table.

### Traps

This page displays the Trap Table.

### Config

On this page, you can configure the Status 1 and Status 2 parameters.

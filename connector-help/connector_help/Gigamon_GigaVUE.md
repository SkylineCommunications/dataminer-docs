---
uid: Connector_help_Gigamon_GigaVUE
---

# Gigamon GigaVUE

The Gigamon GigaVUE connector is used to monitor GigaVUE devices.

## About

The connector communicates with the device by using SNMP requests and it also allows incoming asynchronous data as trap notifications.

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
<td><strong>Description</strong></td>
<td><strong>DCF Integration</strong></td>
<td><strong>Cassandra Compliant</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x [Obsolete]</td>
<td>Initial Version</td>
<td>No</td>
<td>Yes</td>
</tr>
<tr class="odd">
<td>1.0.1.x [SLC Main]</td>
<td><p>Based on 1.0.0.x</p>
<p>Parameters listed in the Notes section were modified and some Pages were added, so please verify any references in DMS to these parameters.(Visio, Automation Scripts, DMS Filters, Reports ...)</p></td>
<td>No</td>
<td>Yes</td>
</tr>
</tbody>
</table>

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.0.0                       |
| 1.0.1.x          | 5.0.0                       |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device. By dafault 161.
- **Get community string**: The community string used when reading values from the device. (default: public)
- **Set community string**: The community string used when setting values on the device. (default: private)

## Usage

### General

This page contains general information of the device, as **Model, Name,** **Serial Number, Version** and **System Description**.

### Status

This page presents parameters with status of the system like **CPU Utilization**, **Temperature of Sensors** and **Memory Utilization**.

### Traps

This page contains a general **Traps Table** to store all the incoming trap notifications, as well as controls for enable/disable incoming traps and define the allowed amount of traps processed.

### Web Interface

This is a link to web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

Changes implemented in range 1.0.1.x :

\- Parameter Blade Serial Numbers was changed: from PID 108 to 240, as well as modified from type string to a table parameter.

\- Parameter Fans was changed: from PID 113 to 210, as well as modified from type string to a table parameter.

\- Parameter Power Supplies was changed: from PID 115 to 220, as well as modified from type string to a table parameter.

\- Some new parameters and pages were added.

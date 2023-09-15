---
uid: Connector_help_Server_Technology_CDU
---

# Server Technology CDU

The Switched Cabinet Distribution Units (CDU) family combines networked configuration and management with power distribution, power and environmental monitoring.

About

This connector is intended to get and set information in the device via an Element in a DataMiner System, using SNMP commands.

To get more detailed information <http://www.servertech.com/products/switched-pdus/>

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
<td>1.0.0.x</td>
<td>Initial version</td>
<td>No</td>
<td>No</td>
</tr>
<tr class="odd">
<td>1.1.0.x</td>
<td>New firmware based on 1.0.0.x</td>
<td>No</td>
<td>No</td>
</tr>
<tr class="even">
<td>2.0.0.x</td>
<td>Branch version based on 1.1.0.x</td>
<td>No</td>
<td>No</td>
</tr>
<tr class="odd">
<td>2.0.1.x</td>
<td>Branch version based on 2.0.0.x</td>
<td>No</td>
<td>Yes</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Device Firmware Version**          |
|------------------|--------------------------------------|
| 1.0.0.x          | Sentry Switched -48 VDC Version 7.0j |
| 1.1.0.x          | Sentry Switched -48 VDC Version 7.0j |
| 2.0.0.x          | Sentry Switched -48 VDC Version 7.0j |
| 2.0.1.x          | Sentry Switched -48 VDC Version 7.0j |

## Installation and configuration

### Creation

SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value if not overridden in the connector: *public*).
- **Set community string**: The community string used when setting values on the device (default value if not overridden in the connector: *private*).

## Usage

### General

Use this page to get general information about the device as well as information related to **Monitors** and **Towers** sensor status.

- **Firmware Version** - The firmware version of the system.
- **System Serial Number** - The serial number of the network interface card in the system.
- **Location** - The location of the system.
- **System Features** - The key-activated features enabled in the system.
- **System Area** - The area that the footprint of the system occupies. A non-zero non-negative value indicates the area in tenths of area units as selected by the systemAreaUnit object. A zero or negative value indicates that the area was not available.
- **System Power Factor** - The power factor used in power calculations performed by the system.
- **System Config Modified Count** - The total number of times the system configuration has changed.
- **Tower Count** - The number of towers in the system.
- **Environmental Monitors Count** - The number of environmental monitors in the system.
- **Total Power Consumption** - The total power consumption of all of the input feeds in the system. A non-negative value indicates the total power consumption in Watts. A negative value indicates that the total power consumption was not available.
- **System Watts Per Unit Area** - The system Watts per area unit. A non-negative value indicates the power consumption per area unit as selected by the System Area Unit object. A negative value indicates that the power consumption per area unit was not available.
- **System Outlet Seq Interval** - The power-on sequencing interval for all outlets.
- **System Outlet Reboot Delay** - The reboot delay for all outlets.
- **System Feature Key** - A valid feature key written to this object will enable a feature in the system. A valid feature key is in the form xxxx-xxxx-xxxx-xxxx. A read of this object returns an empty string.
- **Monitors** - A table of environmental monitors.
- **Towers** - The towers configuration Table is used for assignment and/or editing of tower's descriptive names, serial and model numbers and operation voltage types

### Power Control

This page includes information about the Input Feeds and also the Outlets.

- **Input Feeds** - Use this table to have access to absolute and descriptive name of the infeed, infeed status, input/branch phase load in amperes, input voltage and calculates power usage in watts.
- **Outlets** - Use this table to review and manipulate power control functions for all outlets.

### Environmental Status

Use this page to get the temperature/humidity sensor's descriptive names and sensor readings in degrees Celsius and percent relative humidity.

- **Temperature / Humidity** - The table of temperature/humidity sensors.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

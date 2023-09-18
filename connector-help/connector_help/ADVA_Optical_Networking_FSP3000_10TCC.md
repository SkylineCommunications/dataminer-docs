---
uid: Connector_help_ADVA_Optical_Networking_FSP3000_10TCC
---

# ADVA Optical Networking FSP3000 10TCC

The **ADVA Optical Networking FSP3000** is an optical data transport solution. This connector can be used to monitor and control a **10TCC** card.

## About

The **ADVA Optical Networking FSP3000** is an extensible chassis with multiple slots. Each slot can contain a different type of extension card. This connector is especially meant for the **10TCC** card.

This connector requires an element of protocol "**ADVA Optical Networking FSP3000**" with the same polling IP to function. The purpose of that element is to retrieve the entity IDs of the different components on this card, i.e. channels. The entity ID is used in the SNMP OID in order to successfully retrieve data from this card.

All information is retrieved using the SNMP protocol.

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
<td><p>Initial version</p>
<p>Deprecated</p></td>
<td>No</td>
<td>Yes</td>
</tr>
<tr class="odd">
<td>2.0.0.x</td>
<td><p>Changed element topology. A different element is now used to retrieve the entity table of all cards from the device.</p>
<p>To be used</p></td>
<td>No</td>
<td>Yes</td>
</tr>
</tbody>
</table>

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |
| 2.0.0.x          | All firmware versions       |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Required. Format: "\<chassis id\>.\<slot id\>", e.g. "1.19".

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value: *public*).
- **Set community string**: The community string used when setting values on the device (default value: *private*).

### Configuration

No additional configuration is necessary in the element.

## Usage

### General

This page contains general information of the device, such as the **name** and **temperature**. Additionally, the most important statuses of the different channels that are managed by this card are available on this page.

### Channel x page

The information of each channel is displayed on a separate page. Each channel contains at least the following parameters:

- **Admin State**
- **Operational State**
- **Secondary States**
- **Facility Type**

Some of the channels also display configuration parameters.

### Embedded Web Server

Displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

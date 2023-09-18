---
uid: Connector_help_Vertex_1230
---

# Vertex 1230

The Vertex 1230 connector is a **virtual** connector that can interact with **Ethernet remote I/O control** devices.

Note: Version 2.0.0.1 of the connector is designed to work with **Moxa ioLogic E1214**.

The Moxa ioLogic E1214 manages 6 digital input channels and 6 relay output channels supporting a 3k VDC isolation, supports Modbus/TCP protocol, and handles 2 Ethernet ports to be able to switch for daisy chain topologies.

## About

The connector has been designed to display information on and allow management of Ethernet remote I/O control devices.

Note: To be able to manage the configuration, you must make sure **Ambient temperature status** is set to *On*, and **Mode** is set to *Remote*.

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
<td>Initial version.</td>
<td>No</td>
<td>No</td>
</tr>
<tr class="odd">
<td>1.1.0.x</td>
<td>Alarm tag to Ref Stage Heat 2.</td>
<td>No</td>
<td>No</td>
</tr>
<tr class="even">
<td>2.0.0.x</td>
<td><p>Changed behavior of operational validation for:</p>
<ul>
<li>Ref Stage Heat 1 &amp; 2</li>
<li>Feed Sub</li>
<li>Control Mode</li>
</ul>
<p>Added Ambient Temperature Manual control.</p></td>
<td>No</td>
<td>No</td>
</tr>
</tbody>
</table>

## Installation and configuration

This connector uses a virtual connection.

Element connections between Ethernet remote I/O devices must be configured when the element is created in order to establish the input/output relationship between channels.

## Usage

### Main View page

This page displays the following general status parameters:

- **Power Status**
- **Ice Detection Status**
- **Ambient Temperature Status**
- **On Fault**
- **Reference Stage Heaters**
- **Feed/Sub Heat Status**
- **Mode**
- **Control Mode**

### General page

This page displays the following status values, which can also be configured:

- **Reference Stage Heaters**
- **Feed/Sub Heat**
- **Control Mod**
- **Ambient Temperature**

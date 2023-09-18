---
uid: Connector_help_Snell_Wilcox_IQADA00
---

# Snell Wilcox IQADA00

The IQADA00 is a single/dual-channel analog audio distribution amplifier. It provides dual analog inputs with up to five outputs per input, or a single analog input with up to ten outputs.

## About

This connector provides status data for input 1 and input 2. It is also possible to set certain control parameters.

### Version Info

| **Range** | **Description**                                                                                                                | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | This version treats the boards contained within the chassis as DVEs.                                                           | No                  | Yes                     |
| 2.0.0.x          | This version should be used to monitor each board separately (i.e. each board is represented by a single independent element). | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | 5.3. .6                     |

## Installation and configuration

### Creation

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Connections</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td><h4 id="snmp-main-connection">SNMP main connection</h4>
<p>This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>Device address</strong>: Not required.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>Port number</strong>: The port of the connected device, by default <em>161</em>.</li>
<li><strong>Get community string</strong>: The community string used to read from the device. The default value is <em>public</em>.</li>
<li><strong>Set community string</strong>: The community string used to write on the device. The default value is <em>private.</em></li>
</ul></td>
</tr>
<tr class="odd">
<td>2.0.0.x</td>
<td><h4 id="snmp-main-connection-1">SNMP main connection</h4>
<p>This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>Device address</strong>: The ID of the board to be monitored.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>Port number</strong>: The port of the connected device, by default <em>161</em>.</li>
<li><strong>Get community string</strong>: The community string used to read from the device. The default value is <em>public</em>.</li>
<li><strong>Set community string</strong>: The community string used to write on the device. The default value is <em>private.</em></li>
</ul></td>
</tr>
</tbody>
</table>

## Usage

### General

This page contains general parameters related to the device: **Serial Number**, **Software Version**, etc.

### Configuration

This page contains **gain** and **silence** parameters. There are also buttons to **preset** and **restart** the unit.

### Log

This page contains status and **control parameters** for input 1 and input 2.

### Roll Track

This page contains **roll track parameters** for index and index B.

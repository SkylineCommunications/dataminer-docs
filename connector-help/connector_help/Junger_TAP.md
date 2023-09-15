---
uid: Connector_help_Junger_TAP
---

# Junger TAP

The **Junger TAP** is a sophisticated audio processor, powered by Analog Devicesr Sharc DSPs. These DSPs provide the 10-channel audio processing and monitoring facility. They are surrounded by several I/O interfaces, audio delay lines and an optional Dolbyr decoder and encoder.

## About

This connector uses an **SNMP** connection (and a smart-serial connection for [Ember+](https://github.com/Lawo/ember-plus/wiki) in range 1.0.1.x) to communicate with the device.

### Version Info

| **Range** | **Description**                                                                                                                                                                                                                | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                                                                                                                                                | No                  | Yes                     |
| 1.0.1.x          | Based on 1.0.0.1 Added hotkeys and network triggers by creating a smart-serial connection for the [Ember+](https://github.com/Lawo/ember-plus/wiki) protocol. Element settings must be adjusted when updating to this version. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.0.40                      |
| 1.0.1.x          | 2.0.40                      |

## Installation and configuration

### Creation

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td>Version 1.0.0.x</td>
<td><h4 id="snmp-main-connection">SNMP Main Connection</h4>
<p>This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>IP port</strong>: The IP port of the device.</li>
<li><strong>Get community string</strong>: The community string used when reading values from the device, by default <em>public</em>.</li>
<li><strong>Set community string</strong>: The community string used when setting values on the device, by default <em>private</em>.</li>
</ul></td>
</tr>
<tr class="even">
<td>Version 1.0.1.x</td>
<td><strong>Note</strong>: When you update from version 1.0.0.x to 1.0.1.x, you must adjust the element settings.
<h4 id="smart-serial-main-connection">Smart-Serial Main Connection</h4>
<p>This connector uses a smart-serial connection to be able to use the <a href="https://github.com/Lawo/ember-plus/wiki">Ember Plus Protocol</a> for communication with the device.</p>
<p>SMART-SERIAL CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
</ul>
<p>SMART-SERIAL Settings:</p>
<ul>
<li><strong>IP Port:</strong> The port of the device. The default port for this serial connection is port <em>9000</em>.</li>
</ul>
<h4 id="snmp-second-connection">SNMP Second Connection</h4>
<p>This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>IP port</strong>: The IP port of the device.</li>
<li><strong>Get community string</strong>: The community string used when reading values from the device, by default <em>public</em>.</li>
<li><strong>Set community string</strong>: The community string used when setting values on the device, by default <em>private</em>.</li>
</ul></td>
</tr>
</tbody>
</table>

## Usage

### General

This page displays general information about the device, such as the **System description**, **System Uptime** and **General Status.**

### Status

This page displays status information, such as the **Temperature**, **Power** and **Fan Status**, **NTP** and **Number of Modules**.

### Module

This page provides information about the various module entries.

### Input

This page displays status information regarding the interface module.

### Process

This page displays information related to the **Processing Status** of each module.

### Session

This page shows the available **Sessions.**

### Hotkeys

From version 1.0.1.1 onwards, you can activate the hotkeys and network triggers by clicking the **Trigger** button.

Note that changing the label of a hotkey will also trigger the hotkey.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

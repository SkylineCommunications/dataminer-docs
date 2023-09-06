---
uid: Connector_help_Advantech_Wireless_Remote_Monitor_and_Control_Panel_1-2_Redundant_SSPB_(BUC)_System
---

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<tbody>
<tr class="odd">
<td><table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<tbody>
<tr class="odd">
<td><h1 id="advantech-wireless-remote-monitor-and-control-panel-1-2-redundant-sspb-buc-system">Advantech Wireless Remote Monitor and Control Panel 1-2 Redundant SSPB (BUC) System</h1>
<p>The Monitor and Control Panel is used for redundant high power units, monitoring the status of 2 SSPB units in a redundant system and 3 amplifiers in a 1 to 2 redundant phase-combined configuration and providing control to the RF units.</p>
<h2 id="about">About</h2>
<h3 id="version-info">Version Info</h3>
<table>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Key Features</strong></td>
<td><strong>Based on</strong></td>
<td><strong>System Impact</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x [SLC Main]</td>
<td>Initial version</td>
<td>-</td>
<td>-</td>
</tr>
</tbody>
</table>
<h3 id="product-info">Product Info</h3>
<table>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Supported Firmware</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td>Unknown</td>
</tr>
</tbody>
</table>
<h3 id="system-info">System Info</h3>
<table>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>DCF Integration</strong></td>
<td><strong>Cassandra Compliant</strong></td>
<td><strong>Linked Components</strong></td>
<td><strong>Exported Components</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td>No</td>
<td>Yes</td>
<td>-</td>
<td>-</td>
</tr>
</tbody>
</table>
<h2 id="configuration">Configuration</h2>
<h3 id="connections">Connections</h3>
<h4 id="snmp-connection---main">SNMP Connection - Main</h4>
<p>This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>Port number</strong>: The port of the connected device, by default <em>161</em>.</li>
<li><strong>Get community string</strong>: The community string used when reading values from the device, by default <em>public</em>.</li>
<li><strong>Set community string</strong>: The community string used when setting values on the device, by default <em>private</em>.</li>
</ul>
<h3 id="web-interface">Web Interface</h3>
<p>This page displays the web interface of the device. The web interface is only accessible when the client machine has network access to the product.</p>
<h2 id="how-to-use">How to Use</h2>
<p>This connector uses SNMP Parameters and tables to retrieve data from the device.</p></td>
</tr>
</tbody>
</table></td>
</tr>
</tbody>
</table>



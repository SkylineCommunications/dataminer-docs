---
uid: Connector_help_Quantum_ActiveScale_P100
---

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<tbody>
<tr class="odd">
<td><h1 id="quantum-activescale-p100">Quantum ActiveScale P100</h1>
<p>This DataMiner connector can be used to retrieve information and monitor data from a modular object storage system via SNMP.</p>
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
<h4 id="snmp-main-connection">SNMP Main Connection</h4>
<p>This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>Port number</strong>: The port of the connected device, by default <em>161</em>.</li>
<li><strong>Get community string</strong>: The community string used when reading values from the device(default value if not overridden in the driver: <em>public</em>).</li>
<li><strong>Set community string</strong>: [The community string used when setting values on the device(default value if not overridden in the driver: <em>private</em>).</li>
</ul>
<h3 id="general">General</h3>
<p>The <strong>General</strong> page displays the device information, capacity data, network traffic data as well as metrics data.</p>
<p>An extra <strong>Metrics</strong> page might be displayed depending on the value of the 'Poll Metrics' togglebutton.</p>
<h3 id="resources">Resources</h3>
<p>The <strong>Resources</strong>page displays the CPU and Memory data in tables.</p>
<h3 id="events">Events</h3>
<p>The <strong>Events</strong>page displays a table containing all the incoming traps.</p>
<h3 id="web-interface">Web Interface</h3>
<p>The web interface is only accessible when the client machine has network access to the product.</p></td>
</tr>
</tbody>
</table>

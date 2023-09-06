---
uid: Connector_help_Bridge_Technologies_VB440
---

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<tbody>
<tr class="odd">
<td><h1 id="bridge-technologies-vb440">Bridge Technologies VB440</h1>
<p>This connector allows you to monitor and control <strong>Bridge Technologies VB440 Series</strong> devices.</p>
<p>It uses the <strong>EII API (Enterprise Information Integration)</strong> provided by the vendor for regular polling of the probes over <strong>HTTP</strong>, as well as <strong>SNMP traps</strong> in order to get quick alarm updates.</p>
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
<td><strong>6.0.3</strong></td>
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
<td>Yes</td>
<td>Yes</td>
<td>-</td>
<td>-</td>
</tr>
</tbody>
</table>
<h2 id="configuration">Configuration</h2>
<h3 id="connections">Connections</h3>
<h4 id="http-main-connection">HTTP Main Connection</h4>
<p>This connector uses an HTTP connection and requires the following input during element creation:</p>
<p>HTTP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP or URL of the destination.</li>
<li><strong>IP port</strong>: The IP port of the destination (default value: <em>80</em>).</li>
<li><strong>Device address</strong>: The bus address of the device. If the proxy server has to be bypassed, specify <em>BypassProxy</em>.</li>
</ul>
<h4 id="snmp-traps-connection">SNMP Traps Connection</h4>
<p>This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP or URL of the destination.</li>
<li><strong>IP port</strong>: The IP port of the destination.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>Get community string</strong>: The community string used when reading values from the device (default: <em>public</em>).</li>
<li><strong>Set community string</strong>: The community string used when setting values on the device (default: <em>private</em>).</li>
</ul>
<h3 id="initialization">Initialization</h3>
<p>Once the element has been created in DataMiner, the <strong>Element Configuration</strong> page allows you to configure different aspects of the element behavior:</p>
<ul>
<li>Configuring credentials for <strong>HTTP Authentication</strong> (if HTTP authentication is enabled on the probe).</li>
<li>Configuring how to handle probe alarms.</li>
<li>Enable more verbose logging if needed</li>
</ul>
<h3 id="redundancy">Redundancy</h3>
<p>There is no redundancy defined.</p>
<h3 id="web-interface">Web Interface</h3>
<p>The web interface is only accessible when the client machine has network access to the product.</p>
<h2 id="how-to-use">How to use</h2>
<p>The <strong>Streams</strong> page holds tables regarding grouped stream data, while more detailed statistical information can be found on the <strong>Media Window</strong> page.</p>
<p>Various alarm and threshold information is found in and under the <strong>Alarms</strong> page.</p></td>
</tr>
</tbody>
</table>

---
uid: Connector_help_Kathrein_FSKMTS_10
---

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<tbody>
<tr class="odd">
<td><h1 id="kathrein-fskmts-10">Kathrein FSKMTS 10</h1>
<p>Kathrein FSKMTS 10 is an FSK Management Termination System used to send commands to amplifiers on the network that are only able to receive FSK commands. In order to be able send FSK command to the amplifiers, a prerequisite is to load a list of the amplifiers managed by the given HEC. This list is also called "nodelist". This connector can be used to import the nodelist into the device and show an overview of the nodes.</p>
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
<td>1.1</td>
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
<li><strong>Get community string</strong>: The community string used when reading values from the device (default: <em>public</em>).</li>
<li><strong>Set community string</strong>: The community string used when setting values on the device (default: <em>private</em>).</li>
</ul>
<h3 id="initialization">Initialization</h3>
<p>No extra configuration is needed.</p>
<h3 id="redundancy">Redundancy</h3>
<p>There is no redundancy defined.</p>
<h3 id="web-interface">Web Interface</h3>
<p>The web interface is only accessible when the client machine has network access to the product.</p>
<h2 id="how-to-use">How to Use</h2>
<p>The <strong>General</strong> page of this connector displays information about the modules.</p>
<p>The <strong>RMTS Information</strong> page enables you to configure device settings.</p>
<p>On the <strong>Import Configuration</strong> page, you can manually import a nodelist and configure the settings for automatically importing the nodelist from a directory. Importing from both local directories and network locations is supported. When importing from a network location, it is important to specify the Network Username, Network Password and Network Domain.</p>
<p>The <strong>Nodes</strong> page contains all information about the nodes and can be used to add, edit or delete nodes. Note that when adding a node, it's possible that the Hardware Type or Alias may not be immediately shown correct in the table because the device needs a bit of time to process this.</p></td>
</tr>
</tbody>
</table>

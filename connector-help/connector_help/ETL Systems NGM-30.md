---
uid: Connector_help_ETL_Systems_NGM-30
---

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<tbody>
<tr class="odd">
<td><h1 id="etl-systems-ngm-30">ETL Systems NGM-30</h1>
<p>The L-band matrix is used to provide flexibility in the routing of antennas to receivers or modems, also to allow remote routing to satellite signals and to optimise the use of receiving capacity.</p>
<h2 id="about">About</h2>
<p>This driver uses two interfaces, <strong>SNMP</strong> and <strong>Serial</strong>, to communicate with the <strong>NGM-30</strong> device.</p>
<h3 id="ranges-of-the-driver">Ranges of the driver</h3>
<table>
<tbody>
<tr class="odd">
<td><strong>Driver Range</strong></td>
<td><strong>Description</strong></td>
<td><strong>DCF Integration</strong></td>
<td><strong>Cassandra Compliant</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x [SLC Main]</td>
<td>Initial version</td>
<td>No</td>
<td>Yes</td>
</tr>
</tbody>
</table>
<h3 id="supported-firmware-versions">Supported firmware versions</h3>
<table>
<tbody>
<tr class="odd">
<td><strong>Driver Range</strong></td>
<td><strong>Device Firmware Version</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td>2.15</td>
</tr>
</tbody>
</table>
<h2 id="installation-and-configuration">Installation and configuration</h2>
<h3 id="creation">Creation</h3>
<p>This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.<br />
</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>Port number</strong>: The port of the connected device, by default <em>161</em>.<br />
</li>
<li><strong>Get community string</strong>: The community string used when reading values from the device. The default value is <em>public</em>.<br />
</li>
<li><strong>Set community string</strong>: The community string used when setting values on the device. The default value is <em>private</em>.<br />
</li>
</ul>
<p>This driver also uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li>Direct connection:</li>
<li><ul>
<li><strong>Baudrate</strong>: [Baudrate specified in the manual of the device, e.g. <em>9600.</em>]</li>
<li><strong>Databits</strong>: [Databits specified in the manual of the device, e.g. <em>7.</em>]</li>
<li><strong>Stopbits</strong>: [Stopbits specified in the manual of the device, e.g. <em>1.</em>]</li>
<li><strong>Parity</strong>: [Parity specified in the manual of the device, e.g. <em>No.</em>]</li>
<li><strong>FlowControl</strong>: [FlowControl specified in the manual of the device, e.g. <em>No.</em>]</li>
</ul></li>
<li>Interface connection:</li>
<li><ul>
<li><strong>IP address/host</strong>: [The polling IP of the device.]</li>
<li><strong>IP port</strong>: [The IP port of the device. Indicate if required or not. If so, specify default value and range.]</li>
<li><strong>Bus address</strong>: [The bus address of the device. Indicate if required or not. If so, specify default value, range and format.]<br />
</li>
</ul></li>
</ul>
<h2 id="usage">Usage</h2>
<h3 id="main-view">Main View</h3>
<p>This page contains the device Matrix.<br />
</p>
<h3 id="general">General</h3>
<p>This page displays generic parameters, such as:</p>
<ul>
<li><strong>Version</strong></li>
<li><strong>Number of Inputs</strong></li>
<li><strong>Number of Outputs</strong></li>
<li><strong>Matrix Size</strong></li>
<li><strong>DHCP Status</strong></li>
<li><strong>Module IP Address</strong><br />
</li>
</ul>
StatusThis pages displays two tables: <strong>Input</strong> <strong>Card</strong> <strong>Status</strong> and <strong>Output Card Status</strong>. These tables displays the monitoring informations about each of the RF cards in the module.<br />
AlarmThis page displays the device status, such as <strong>Temperatures</strong>, <strong>Fan</strong> <strong>Speeds</strong>, and <strong>Communication</strong> <strong>Status</strong>.<br />
<br />
ConfigurationThis page is used to configure the Matrix size, number of inputs and outputs.<br />
Web InterfaceNote that the client machine has to be able to access the device, as otherwise it will not be possible to open the Web Interface.<br />
</td>
</tr>
</tbody>
</table>



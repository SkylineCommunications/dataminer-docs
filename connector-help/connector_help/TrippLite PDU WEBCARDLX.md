---
uid: Connector_help_TrippLite_PDU_WEBCARDLX
---

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<tbody>
<tr class="odd">
<td>TrippLite PDU WEBCARDLXThe PDU line of devices from TrippLite allow for the use of multiple outlets, but does not guard against surge or line noise protection for connected equipment.
<h2 id="about">About</h2>
<p>The TrippLite PDU WEBCARDLX driver allows for configuration and monitoring of several PDU and EnviroSense devices.</p>
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
<td>1.0.0.1</td>
<td>Initial Version</td>
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
<td>1.0.0.x [SLC Main]</td>
<td>15.02</td>
</tr>
</tbody>
</table>
<h2 id="installation-and-configuration">Installation and configuration</h2>
<h3 id="creation">Creation</h3>
<h4 id="snmp-main-connection">SNMP main connection</h4>
<p>This driver uses a Simple Network Management Protocol (SNMP) version 3 connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>Port number</strong>: The port of the connected device, by default <em>161</em>.</li>
<li><strong>Security level and protocol</strong>: The level of security used for the SNMPv3 communication, either no authroization or privacy (noAuthNoPriv), authorization but no privacy (authNoPriv), or authorization and privacy (authPriv).</li>
<li><strong>User name</strong>: The user name used for the connection with the device.</li>
<li><strong>Authentication password:</strong> The password used during the authorization process.</li>
<li><strong>Encryption password:</strong> The password used for decryption private information</li>
<li><strong>Authentication algorithm:</strong> The algorithm used for the authentication.</li>
<li><strong>Encryption algorithm:</strong> The algorithm used for the encryption.</li>
</ul>
<h2 id="usage">Usage</h2>
<h3 id="general-page">General Page</h3>
<p>This page displays all the generic information of the connected devices, including the number of <strong>PDU Devices</strong> and <strong>EnviroSense Devices</strong>.</p>
<p>The <strong>Devices</strong> table allows for monitoring of the different devices and configuration of the <strong>Name, ID, Location,</strong> and <strong>Region</strong>.</p>
<h3 id="pdu-page">PDU Page</h3>
<p>All of the information regarding the PDU devices can be found using this page.</p>
<p>The <strong>PDU</strong> <strong>Device Info</strong> table contains mostly the status of the PDU device but also allows for commanding the <strong>Main Load</strong> and the configuration of the <strong>Power On</strong> <strong>Delay</strong>.</p>
<p>The <strong>PDU Display Info</strong> table allows for configuration of the PDU <strong>Scheme, Orientation, Auto Scrolling, Intensity,</strong> and <strong>Units.</strong></p>
<p>The <strong>PDU Identity Info</strong> table displays the amount of connections to the PDU, including the <strong>Inputs, Ouputs</strong> and <strong>Outlets</strong>.</p>
<p>Using pagebuttons, the following can be accessed:</p>
<ul>
<li><strong>Outlets:</strong> contains information on the PDU outlets in the <strong>Outlets</strong> and <strong>Outlet Groups</strong> tables.</li>
<li><strong>Inputs:</strong> contains information on the PDU inputs in the <strong>Inputs</strong> and <strong>Input Phase Info</strong> tables.</li>
<li><strong>Outputs:</strong> displays the <strong>Outputs</strong> table with data on the outputs of the PDUs.</li>
<li><strong>Breakers</strong>: displays the <strong>Breakers</strong> table with data on the breakers of the PDUs.</li>
<li><strong>Heak Sinks:</strong> displays the <strong>Heat Sinks</strong> table with data on the heat sinks of the PDUs.</li>
<li><strong>Circuits:</strong> displays the <strong>Circuits</strong> table with data on the circuits on the PDUs.</li>
<li><strong>Supports:</strong> displays the <strong>PDU Supports</strong> table with the various supported functions of a PDU.</li>
<li><strong>Configuration:</strong> the <strong>Controls</strong> and <strong>Configuration</strong> tables allows the user to perform commands and changes on the PDU.</li>
</ul>
<h3 id="envirosense-page">EnviroSense Page</h3>
<p>All of the information regarding the EnviroSense devices can be found using this page. Polling of the EnviroSense information can be enabled or disabled using the <strong>Poll EnviroSense Info</strong> togglebutton.</p>
<p>The <strong>EnviroSense Identity Info</strong> table displays if the <strong>Temperature</strong> and <strong>Humidity</strong> is supported and the number of <strong>Input</strong> and <strong>Ouput Contacts.</strong></p>
<p>The <strong>EnviroSense Configuration</strong> table allows for configuration of the <strong>Temperature</strong> and <strong>Humidity Limits.</strong></p>
<p>Using pagebuttons, the following can be accessed:</p>
<ul>
<li><strong>Contacts:</strong> contains the <strong>Input</strong> and <strong>Output Contacts</strong> table.</li>
<li><strong>Temperature:</strong> the temperature status of the EnviroSense device is displayed in the <strong>Temperature Info</strong> table.</li>
<li><strong>Humidity:</strong> the humidity status of the EnviroSense device is displayed in the <strong>Humidity Info</strong> table.</li>
</ul>
<h3 id="web-interface-page">Web Interface Page</h3>
<p>This page displays the web interface of the device.</p>
<p>Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.</p></td>
</tr>
</tbody>
</table>

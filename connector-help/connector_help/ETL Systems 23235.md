---
uid: Connector_help_ETL_Systems_23235
---

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<tbody>
<tr class="odd">
<td>ETL Systems 23235
<p>The Model 23235 L band switch operates with signals in the L band range of frequencies from 50-2150MHz and is designed to provide automatic MAIN/STANDBY switching functions typically for 2:1 redundancy switching.</p>
<h2 id="about">About</h2>
<p>The ETL Systems 23235 driver allows for configuration of the switching functionality and monitoring of the power supply status and temperature.</p>
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
<td>V1.0 e396</td>
</tr>
</tbody>
</table>
<h2 id="installation-and-configuration">Installation and configuration</h2>
<h3 id="creation">Creation</h3>
<h4 id="snmp-main-connection">SNMP main connection</h4>
<p>This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
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
<h2 id="usage">Usage</h2>
<h3 id="general-page">General Page</h3>
<p>This page displays <strong>Temperature</strong> of the device, the <strong>Configuration</strong> and the <strong>Power Supply Status</strong> tables.</p>
<p>The <strong>Configuration</strong> tableallows for configuration of the <strong>Boot Mode, Operating Mode, Online Path,</strong> and <strong>Standby Latch.</strong></p>
<h3 id="rf-limits-page">RF Limits Page</h3>
<p>Two tables containing information for the device RF limits are displayed on this page: the <strong>RF Limits</strong> table and the <strong>Limits Status</strong> table.</p>
<p>Both of these tables contain information for the main and standby RF signals.</p>
<h3 id="ip-settings-page">IP Settings Page</h3>
<p>The <strong>IP Settings</strong> table on this page allows the user to configure the device <strong>DHCP</strong> and <strong>IP,</strong> or the <strong>NET BIOS Name</strong>.</p>
<h3 id="trap-receivers-page">Trap Receivers Page</h3>
<p>The trap receivers of the device are displayed and configurable in the <strong>Trap Receivers</strong> table displayed on this page.</p>
<h3 id="web-interface-page">Web Interface Page</h3>
<p>This page displays the web interface of the device.</p>
<p>Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.</p></td>
</tr>
</tbody>
</table>

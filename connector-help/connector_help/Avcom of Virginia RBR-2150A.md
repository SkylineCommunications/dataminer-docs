---
uid: Connector_help_Avcom_of_Virginia_RBR-2150A
---

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<tbody>
<tr class="odd">
<td><h1 id="avcom-of-virginia-rbr-2150a">Avcom of Virginia RBR-2150A</h1>
<p>The RBR Series is a Beacon Receiver based on the high-performing single-board Spectrum Analyzers and Beacon Receiver (SBS) products.</p>
<p>This protocol is used to monitor and configure a <strong>Beacon Receiver</strong>.</p>
<h2 id="about">About</h2>
<p>The communication between the device and DataMiner Element is done via a <strong>Serial</strong> connection.</p>
<p>This protocol use an API to retrieve data from the device. The API is written in C and the protocol use a dll to have access those methods.</p>
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
<td><p>1.10rc3</p></td>
</tr>
</tbody>
</table>
<h2 id="installation-and-configuration">Installation and configuration</h2>
<h3 id="creation">Creation</h3>
<p>SERIAL CONNECTION:</p>
<ul>
<li><strong>Type of Port:</strong> TCP/IP</li>
<li><strong>IP address/host</strong>: The polling IP of the device. e.g: 10.10.10.10</li>
<li><strong>IP port</strong>: The IP port of the device. e.g: 2880</li>
</ul>
<h2 id="usage">Usage</h2>
<p>To use this protocol, the dll file "aovsbs2.dll" has to be added to "C:\Skyline DataMiner\ProtocolScripts\".</p>
<p>The protocol has two pages, the <strong>General</strong> page where the user can see general information about the device and the <strong>Beacon Receiver</strong> page where the user can configure the <strong>Beacon Receiver</strong>.</p>
<h3 id="general">General</h3>
<p>On General page the user can see general information like Firmware Version, Build DateTime also he can configure the Network Details. The Network Details has these parameters:</p>
<ul>
<li>Hostname</li>
<li>IP Mode (Manual or DHCP)</li>
<li>IP Address</li>
<li>Subnet mask</li>
<li>Default Gateway</li>
<li>TCP Port</li>
</ul>
Also the user can reboot the device clicking on Reboot button.
<h3 id="beacon-receiver">Beacon Receiver</h3>
<p>On this page the user can configure the <strong>Beacon Receiver</strong> also he can see the measurnment values like:</p>
<ul>
<li>Measured Frequency</li>
<li>Frequency Drift</li>
<li>Frequency at Lock</li>
<li>Current C/N0</li>
<li>...</li>
</ul>
He has the option to Start and Stop the <strong>Beacon Receiver</strong>.</td>
</tr>
</tbody>
</table>

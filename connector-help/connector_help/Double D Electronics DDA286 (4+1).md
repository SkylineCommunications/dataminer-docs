---
uid: Connector_help_Double_D_Electronics_DDA286_(4+1)
---

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<tbody>
<tr class="odd">
<td><h1 id="double-d-electronics-dda286-41">Double D Electronics DDA286 (4+1)</h1>
<p>The driver monitors the activity of the <strong>Double D Electronics DDA286 (4+1)</strong> controller.</p>
<h2 id="about">About</h2>
<p>The driver has a serial communication to the <strong>Double D Electronics <strong><strong>DDA286 (4+1)</strong></strong></strong> and allows the end user to control and monitor the switche configuration.</p>
<p>In addition to the previous, the driver uses two timers: one polling every 10 seconds that retrieves general information from the device and its switches and one that polls every hour for slowly varying information.</p>
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
<td>1.0.0.x</td>
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
<td>DDA286 V1.15</td>
</tr>
</tbody>
</table>
<h2 id="installation-and-configuration">Installation and configuration</h2>
<h3 id="creation">Creation</h3>
<p>Serial Main connection</p>
<p>This driver uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li>Direct connection:</li>
<li><ul>
<li><strong>Baudrate</strong>: Baudrate specified in the manual of the device, e.g. <em>9600.</em></li>
<li><strong>Databits</strong>: Databits specified in the manual of the device, e.g. <em>7.</em></li>
<li><strong>Stopbits</strong>: Stopbits specified in the manual of the device, e.g. <em>1.</em></li>
<li><strong>Parity</strong>: Parity specified in the manual of the device, e.g. <em>No.</em></li>
<li><strong>FlowControl</strong>: FlowControl specified in the manual of the device, e.g. <em>No.</em></li>
</ul></li>
<li>Interface connection:</li>
<li><ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: The IP port of the device.</li>
<li><strong>Bus address</strong>: The bus address of the device.</li>
</ul></li>
</ul>
<h2 id="usage">Usage</h2>
<h3 id="general-page">General Page</h3>
<p>On the general page, the user can observe some general information from the device on the left such asthe <strong>Software Version;</strong> the <strong>Device</strong> <strong>Name</strong>;the <strong>Maximum</strong> <strong>Number of Supported Switches</strong> and the <strong><strong>Maximum</strong> <strong>Number of Supported Chains</strong>.</strong></p>
<p>In addition to the previous, the user can define the device's mode (<strong>Global Device Mode</strong>) and its respective <strong>Control Mode</strong>.</p>
<p>At the right of the page the user can observe if there's any existing alarms regarding: <strong>Active Alarms; Unacknowledged Alarms; PSU 1</strong> and <strong>PSU 2 Alarm.</strong></p>
<h3 id="switches">Switches</h3>
<p>On this page, the <strong>Status of Switch 1</strong> can be viewed. The user can also configure the <strong>Switches 1 - 4</strong> to Primary or Backup Mode and the <strong>Chains 1 - 4</strong> to Antenna or Load.</p>
<h3 id="chain-1---2">Chain 1 - 2</h3>
<p>On this page, the <strong>Status of Chain 1</strong> and <strong>2</strong> can be viewed, such as the <strong>HPA</strong> <strong>status</strong>, the fault of the <strong>HPA</strong> <strong>Comms</strong>, <strong>HPA</strong> <strong>Low</strong> <strong>Power</strong>, <strong>Up</strong> <strong>Converter</strong> <strong>Comms</strong>, the alarms of the <strong>HPA</strong> <strong>Input</strong>, <strong>Chain</strong> <strong>Summary</strong>, <strong>Auxiliary</strong>, <strong>Equaliser</strong> and <strong>Up</strong> <strong>Converter</strong>. The user can also monitor if the chain is <strong>muted</strong> or in <strong>maintenance</strong>.</p>
<h3 id="chain-3---4">Chain 3 - 4</h3>
<p>On this page, the <strong>Status of Chain 3</strong> and <strong>4</strong> can be viewed, such as the <strong>HPA</strong> <strong>status</strong>, the fault of the <strong>HPA</strong> <strong>Comms</strong>, <strong>HPA</strong> <strong>Low</strong> <strong>Power</strong>, <strong>Up</strong> <strong>Converter</strong> <strong>Comms</strong>, the alarms of the <strong>HPA</strong> <strong>Input</strong>, <strong>Chain</strong> <strong>Summary</strong>, <strong>Auxiliary</strong>, <strong>Equaliser</strong> and <strong>Up</strong> <strong>Converter</strong>. The user can also monitor if the chain is <strong>muted</strong> or in <strong>maintenance</strong>.</p>
<h3 id="chain-standby">Chain Standby</h3>
<p>On this page, the <strong>Status of the Standby Chain</strong> can be viewed, such as the <strong>HPA</strong> <strong>status</strong>, the fault of the <strong>HPA</strong> <strong>Comms</strong>, <strong>HPA</strong> <strong>Low</strong> <strong>Power</strong>, <strong>Up</strong> <strong>Converter</strong> <strong>Comms</strong>, the alarms of the <strong>HPA</strong> <strong>Input</strong>, <strong>Chain</strong> <strong>Summary</strong>, <strong>Auxiliary</strong>, <strong>Equaliser</strong> and <strong>Up</strong> <strong>Converter</strong>. The user can also monitor if the chain is <strong>muted</strong> or in <strong>maintenance</strong>.</p></td>
</tr>
</tbody>
</table>

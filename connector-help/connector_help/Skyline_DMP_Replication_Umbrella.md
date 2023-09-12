---
uid: Connector_help_Skyline_DMP_Replication_Umbrella
---

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<tbody>
<tr class="odd">
<td><h1 id="skyline-dmp-replication-umbrella">Skyline DMP Replication Umbrella</h1>
<p>With the <strong>Skyline DMP Replication Umbrella</strong> driver, you can monitor multiple DMPs (DataMiner Probe) information located on different remote agents and define a set of parameters on each system that you want to follow. All statuses, retrieved values and counters can be monitored and trended.</p>
<p>This element is intended to hold a summary of all important data and info from the different probes. Replicating all the probe elements on a remote agent will create one central point to view all data over multiple probes.</p>
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
<h4 id="virtual-main-connection">Virtual Main Connection</h4>
<p>This driver uses a <strong>virtual connection</strong> and does not require any input during element creation.</p>
<h3 id="initialization">Initialization</h3>
<p>As the element retrieves data from the Microsoft Platform element, make sure the latter is running and has trending enabled on <strong>Total Processor Load</strong> and <strong>Total Commit Charge</strong>.</p>
<p>At startup, the driver collects all the different DMP elements using the Skyline Replication DMP driver. A table with the columns Element Name and State is displayed in the Configuration sub-tab under the General page. By default, the state of each element is set to 'Disabled'.</p>
<h3 id="general">General</h3>
<p>This page displays general information from the DMPs, such as <strong>Total Amount of Elements, Total Amount of Active Elements</strong>, and multiple alarm counters.</p>
<p>A 'Configuration' pagebutton is also displayed and it may be used to enable/disable which probe the driver should retrieve information from.</p>
<p>A 'Polling Time' button indicates how often the driver should poll DMP information of elements, active alarms, services and views.</p>
<h3 id="dmp-elements">DMP Elements</h3>
<p>This page displays a table containing all the elements defined in the system with their <strong>ID</strong>, <strong>Name,</strong> <strong>Overall State, Communication State</strong> and <strong>Element State.</strong></p>
<h3 id="dmp-active-alarms">DMP Active Alarms</h3>
<p>This page displays one table listing all the current active alarms, similar to the list displayed in the Active Alarms tab in the DataMiner Cube Alarm Console. There are 5 dynamic columns available in the table. These are custom properties that can be defined on each probe (Skyline DMP replication protocol).</p>
<h3 id="dmp-services">DMP Services</h3>
<p>This page displays one table containing all the services from the DMP with the <strong>Service Name</strong>, <strong>Overall State</strong> and <strong>Communication State</strong>. There are 5 dynamic columns available in the table. These are custom properties that can be defined on each probe (Skyline DMP replication protocol).</p>
<h3 id="dmp-views">DMP Views</h3>
<p>This page displays one table containing all the views from the DMP with the <strong>View Name</strong>, <strong>Parent View</strong>, <strong>Overall State</strong> and <strong>Communication State</strong>. There are 5 dynamic columns available in the table. These are custom properties that can be defined on each probe (Skyline DMP replication protocol).</p></td>
</tr>
</tbody>
</table>

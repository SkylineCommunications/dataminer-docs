---
uid: Connector_help_Mellanox_Technologies_MLNX-OS_Manager
---

# Mellanox Technologies MLNX-OS Manager

This connector is used to monitor the **Mellanox Equipment** running on **MLNX-OS**.

## About

The information on tables and parameters is retrieved via SNMP polling. Specific range versions provide additional information in accordance with the API device documentation.

### Version Info

| **Range**     | **Description**                                  | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                                  | No                  | Yes                     |
| 1.1.0.x \[SLC Main\] | Based on version 1.0.0.1. Added HTTP connection. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | \-                          |
| 1.1.0.x          | API 3.6.5000                |

## Installation and configuration

### Creation

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Connections</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td><h4 id="snmp-main-connection">SNMP Main Connection</h4>
<p>This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>IP port</strong>: The IP port of the device.</li>
<li><strong>Get community string</strong>: The community string used when reading values from the device, by default <em>public</em>.</li>
<li><strong>Set community string</strong>: The community string used when setting values on the device, by default <em>private</em>.</li>
</ul></td>
</tr>
<tr class="odd">
<td>1.1.0.x</td>
<td><h4 id="snmp-main-connection-1">SNMP Main Connection</h4>
<p>This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>IP port</strong>: The IP port of the device.</li>
<li><strong>Get community string</strong>: The community string used when reading values from the device, by default <em>public</em>.</li>
<li><strong>Set community string</strong>: The community string used when setting values on the device, by default <em>private</em>.</li>
</ul>
<h4 id="http-connection">HTTP Connection</h4>
<p>This connector uses an HTTP connection and requires the following input during element creation:</p>
<p>HTTP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: The IP port of the device, by default <em>80</em>.</li>
</ul></td>
</tr>
</tbody>
</table>

## Usage (all ranges except 1.1.0.x)

### General

This page displays the following general information: **System Name**, **System Description**, **System Location**, **System Contact**, **System Up Time** and other general parameters.

On this page, you can also enable the polling of tables.

### Detailed Interface Info

This page displays the **Detailed Interface Info** table. In this table, the columns **Tx/Rx Bitrate daily, weekly and monthly** display the amount of data.

The **Rx/Tx errors rate** can be retrieved within a defined **interval of time**.

All counters can be reset using the **Reset All Counters** button and this can be rolled back with the **Undo** button.

### Detailed Interface Info - Rx

This page displays the **Detailed Interface Info - Rx** table.

### Detailed Interface Info - Tx

This page displays the **Detailed Interface Info - Tx** table.

### IP Routing Info

This page displays the **IP Routing and ARP** tables.

## Usage (1.1.0.x only)

### General

This page displays the following general information: **System Name, System Description, System Location, System Contact, System Up Time** and other general parameters.

On this page, you can also enable the polling of tables.

### Detailed Interface Info

This page displays the **Detailed Interface Info** table. In this table, the columns **Tx/Rx Bitrate daily, weekly and monthly** contain the amount of data.

The **Rx/Tx errors rate** can be retrieved within a defined **interval of time**.

### Detailed Interface Info - RX

This page displays the **Detailed Interface Info - Rx** table.

### Detailed Interface Info - TX

This page displays the **Interface Info - Tx** table.

### Chassis

This page displays information related to the chassis status of the device. This includes **Spanning Tree Protocol**, **OSPF**, **Routing** and **LACP**.

Via page buttons, information is also available on the **Fans**, **Modules**, **Clusters** and **Temperature**.

### Management Interface

This page displays the **Management Interface** device information in a table.

### IP Routing Info

This page displays the **IP Routing and ARP** tables.

### Physical Entities

This page displays the **Physical Entities** device information in a table.

### VLAN Info

This page displays the list of the existing VLANs currently configured on the device.

### IGMP

This page displays the list of the existing VLANs that have IGMP-enabled options.

### VRF

This page displays the **VRF (Virtual Routing and Forwarding)** table.

### PTP

This page displays the **PTP information**.

### Explorer

This page allows you to send commands to the device.

### Web Interface

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

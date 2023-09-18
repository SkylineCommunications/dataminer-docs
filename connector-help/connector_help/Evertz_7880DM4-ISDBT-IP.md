---
uid: Connector_help_Evertz_7880DM4-ISDBT-IP
---

# Evertz 7880DM4-ISDBT-IP

This connector is used to monitor and control the **Evertz 7880DM4-ISDBT-IP** card. The Evertz 7880DM4-ISDBT-IP is used to demodulate digital terrestrial ATSC/8VSB/ISDB-Tb, QAM/ DVBC/ DVB-C2 cable signals, DTV signals or digital DVB-S/S2 satellite signals.

An **SNMP** connection is used in order to successfully retrieve and configure the information of the device. There are also different possibilities available for **alarm monitoring** and **trending**.

## About

### Version Info

| **Range**            | **Key Features**                            | **Based on** | **System Impact** |
|----------------------|---------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                            | \-           | \-                |
| 1.0.1.x              | Changed the DVE and tree view distribution. | 1.0.0.3      | \-                |
| 1.0.2.x \[SLC Main\] | Added HTTP connection.                      | 1.0.1.2      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.1.60                 |
| 1.0.1.x   | 1.1.60                 |
| 1.0.2.x   | 1.1.60                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                          |
|-----------|---------------------|-------------------------|-----------------------|--------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | [Evertz 7880DM4-ISDBT-IP - Decoder](xref:Connector_help_Evertz_7880DM4-ISDBT-IP_-_Decoder) |
| 1.0.1.x   | No                  | Yes                     | \-                    | [Evertz 7880DM4-ISDBT-IP - Decoder](xref:Connector_help_Evertz_7880DM4-ISDBT-IP_-_Decoder) |
| 1.0.2.x   | No                  | Yes                     | \-                    | [Evertz 7880DM4-ISDBT-IP - Decoder](xref:Connector_help_Evertz_7880DM4-ISDBT-IP_-_Decoder) |

## Configuration

### Connections

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
<td>All ranges</td>
<td><h4 id="snmp-main-connection">SNMP Main Connection</h4>
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
</ul></td>
</tr>
<tr class="odd">
<td>1.0.2.x</td>
<td><h4 id="http-main-connection">HTTP Main Connection</h4>
<p>This connector uses an HTTP connection and requires the following input during element creation:</p>
<p>HTTP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP or URL of the destination.</li>
<li><strong>IP port</strong>: The IP port of the destination.</li>
</ul></td>
</tr>
</tbody>
</table>

## How to use

Depending on the connector range, the element created with this connector consists of the data pages detailed below.

### General

This page contains the general information about the device, such as the **Data Port**, **System** and **System Preset** information.

### IP Input

This page contains a **tree view** that allows you to navigate through and efficiently manage information from the Demodulator Control Table, the Demodulator Table and other standalone parameters from different tables.

### Input

This page contains the **Demodulator Table**, which allows you to manage and control parameters such as the **Frequency** and **Bandwidth**.

It also contains the **Demodulator Control Table**, which controls the status of the DVEs.

### IP Input Control

This page provides access to the **IP Input Controls**. It allows you to enable or disable the **Stream**, as well as set the **Receive Mode**, **Multicast** **IP**, **UDP Port**, **RTP Protocol**, **Clear Status** and **IGMPV3 Mode**.

### TS Path

This page contains the **TS Input Table**, which allows you to monitor parameters such as the **Bitrate** and to configure the **Main** and **Backup Source**.

From version **1.0.1.2** onwards, this page also contains the **ASI Configuration Table.**

### Output

This page contains two tables that are linked. The first is the **IP Output Stream Table**, which provides the controls for each specific output. Each output has a corresponding stream, for which all related controls can be found in the table. This same functionality can be found in the other table, **TS Output**.

### Output Service

This page contains three tables that are related with the IP Output Stream Table of the previous page: **Service Filter Control Table, Service Filter Program Table** and **Service Filter PID Table.**

### Output Tree

From version **1.0.1.2** onwards, this page contains a tree view that allows you to efficiently navigate through the information from the previous two pages. Each node has a user-friendly description.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

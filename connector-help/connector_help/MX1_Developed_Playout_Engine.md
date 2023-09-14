---
uid: Connector_help_MX1_Developed_Playout_Engine
---

# MX1 Developed Playout Engine

The MX1 Developed Playout Engine is a connector used to **monitor the operations of Channel Playout Servers**.

These servers are called **hosts** and can be of three different types, according to their function in the playout scheme:

- **Playout Hosts**: Monitor the operational status of the playout channels.
- **Ingest Hosts**: Monitor the media ingest channels.
- **TS Monitoring**: Monitor the overall state of the media transport streams.

## About

The MX1 Developed Playout Engine connector uses SNMP communication to poll the different host DNS/host IPs.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |

### System Info

<table>
<colgroup>
<col style="width: 20%" />
<col style="width: 20%" />
<col style="width: 20%" />
<col style="width: 20%" />
<col style="width: 20%" />
</colgroup>
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
<td><ul>
<li>MX1 Developed Playout Engine - Playout</li>
<li>MX1 Developed Playout Engine - Ingest</li>
<li>MX1 Developed Playout Engine - TS Monitoring</li>
</ul></td>
</tr>
</tbody>
</table>

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

Even though the connection settings above are required by DataMiner, the SNMP communication settings for each host are defined in the three tables on the General page of the main element.

## How to use

On the General page, you can add **new host entries** to the relevant type table by using the context menu available by right-clicking the table.
When you add such a new entry, you will need to specify the host name and the DNS/host IP:port. By default, the polling of the added host will first be disabled.

For each added host, a new **virtual element** (Playout, Ingest or TS Monitoring DVE, depending on the host type) will be created and the polled information will be exported.

The connector will try to execute a new polling cycle (each host type has an independent cycle) every minute. A new cycle will only start if the previous one is finished.

For the transport streams, you can find an overview of the available information via the tree control of the **TS Monitoring** page.

The **Buffer Timeout** parameter at the top of the General page is used to restart the polling cycles of the hosts, in case these are interrupted because of an issue in DataMiner.
The restart will be triggered if the time when the last successful try happened is longer ago than the amount of time defined in this parameter.

## Notes

A web interface page is not available.

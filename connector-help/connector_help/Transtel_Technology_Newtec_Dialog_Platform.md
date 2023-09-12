---
uid: Connector_help_Transtel_Technology_Newtec_Dialog_Platform
---

# Transtel Technology Newtec Dialog Platform

This driver is designed to retrieve information from a DMA set up by Newtec and exports drivers made by Newtec.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.1.3                  |

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
<li><a href="/Driver%20Help/Transtel%20Technology%20Newtec%20Dialog%20Platform%20-%20Modulator.aspx">Transtel Technology Newtec Dialog Platform - Modulator</a></li>
<li><a href="/Driver%20Help/Transtel%20Technology%20Newtec%20Dialog%20Platform%20-%20MDC6000.aspx">Transtel Technology Newtec Dialog Platform - MDC6000</a></li>
<li><a href="/Driver%20Help/Transtel%20Technology%20Newtec%20Dialog%20Platform%20-%20MDC6000%20HCR.aspx">Transtel Technology Newtec Dialog Platform - MDC6000 HCR</a></li>
<li><a href="/Driver%20Help/Transtel%20Technology%20Newtec%20Dialog%20Platform%20-%20MDC7000%204CPM.aspx">Transtel Technology Newtec Dialog Platform - MDC7000 4CPM</a></li>
<li><a href="/Driver%20Help/Transtel%20Technology%20Newtec%20Dialog%20Platform%20-%20General%20Switch.aspx">Transtel Technology Newtec Dialog Platform - General Switch</a></li>
<li><a href="/Driver%20Help/Transtel%20Technology%20Newtec%20Dialog%20Platform%20-%20AZ212%20and%20AZ202%20Redundancy%20Switch.aspx">Transtel Technology Newtec Dialog Platform - AZ212 and AZ202 Redundancy Switch</a></li>
</ul></td>
</tr>
</tbody>
</table>

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The IP of the Newtec DMA.
- **IP port**: 80
- **Device address**: BypassProxy

#### Virtual connection

This driver uses a virtual connection, for which no input is required during element creation.

### Initialization

This driver is designed to poll one DMA. In case of a cluster consisting of multiple DMAs, one element will be needed for each DMA in the cluster.

To set up the element, you need to specify the DMA ID of the Agent you want to poll and the credentials.

On the **Polling Config** page, you can enable what should be polled. Once this has been configured, the element should start retrieving info from the DMA.

### Redundancy

There is no redundancy defined.

## How to use

This driver retrieves all the **elements** and **protocols** on the specified DMA, as well as particular **tables** and **parameters** from elements, and displays these.

It is possible to create DVEs for some of these DataMiner elements. These can be enabled in the exported protocol overview table.

---
uid: Connector_help_Ateme_AMS
---

# Ateme AMS

The Ateme AMS driver get the data of a remote DataMiner System through the HTTP soap API.

The driver supports polling of a limited number of external drivers in order to create DVE elements.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V1                     |

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
<li><a href="/Driver%20Help/Ateme%20AMS%20-%20Ateme%20Titan%20Live.aspx">Ateme AMS - Ateme Titan Live</a></li>
<li><a href="/Driver%20Help/Ateme%20AMS%20-%20Ateme%20Titan%20Mux.aspx">Ateme AMS - Ateme Titan Mux</a></li>
<li><a href="/Driver%20Help/Ateme%20AMS%20-%20CISCO%20Manager.aspx">Ateme AMS - CISCO Manager</a></li>
<li><a href="/Driver%20Help/Ateme%20AMS%20-%20Microsoft%20Platform.aspx">Ateme AMS - Microsoft Platform</a></li>
<li><a href="/Driver%20Help/Ateme%20AMS%20-%20QBIT%20Q561.aspx">Ateme AMS - QBIT Q561</a></li>
<li><a href="/Driver%20Help/Ateme%20AMS%20-%20T-Vips%20CP541.aspx">Ateme AMS - T-Vips CP541</a></li>
</ul></td>
</tr>
</tbody>
</table>

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: IP address of the DMS
- **IP port**: 80

### Initialization

Fill in the username and password of a user of the remote DMS.

## How to use

The first time using the driver it's important to check the Protocols page to see which protocols and version are supported.

The Elements page is also something you have to check to see if the DVEs are created for the elements that you want, here you can also disable DVEs for elements that you are less interested in.

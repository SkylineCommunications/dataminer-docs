---
uid: Connector_help_Ateme_Titan_Edge
---

# Ateme Titan Edge

The Ateme Titan Edge device is an advanced media platform that can have multiple modules like encoders, decoders and gateways.

## About

### Version Info

| **Range**            | **Key Features**                                                                               | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                                                               | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Implemented firmware version 2.11.1. Primary key changes for Video Input Configuration tables. | 1.0.0.4      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | API v0.1               |
| 1.0.1.x   | 2.11.1                 |

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
<li>Ateme Titan Edge - Encoder</li>
<li>Ateme Titan Edge - Decoder</li>
<li>Ateme Titan Edge - Gateway</li>
</ul></td>
</tr>
<tr class="odd">
<td>1.0.1.x</td>
<td>No</td>
<td>Yes</td>
<td>-</td>
<td><ul>
<li>Ateme Titan Edge - Encoder</li>
<li>Ateme Titan Edge - Decoder</li>
<li>Ateme Titan Edge - Gateway</li>
</ul></td>
</tr>
</tbody>
</table>

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector has the following data pages:

- **General**: Displays general information about the device and lists the current **modules** connected to the device in a table.
- **Alarms**: Lists the current **Active Alarms** on the device.
- **DVE**: Allows you to check the DVE configuration and status for the supported modules.
- **Decoder**: Displays the decoder information.
- **Encoder**: Displays the encoder information.
- **Gateway**: Displays the gateway information.

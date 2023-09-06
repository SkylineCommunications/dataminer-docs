---
uid: Connector_help_ATT_Channel_Manager
---

# ATT Channel Manager

In order to manage channels in the **ATT DFW** ecosystem, a DataMiner solution is required which can ingest and store channel data, and automatically initiates the generation of monitoring objects for those channels, known as DataMiner services.

## About

The channel manager solution comes in the form of a single instance of a DataMiner Application that comunicates with the **ATT AVCM API** to retrieve the channel information.

### Version Info

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Key Features</strong></td>
<td><strong>Based on</strong></td>
<td><strong>System Impact</strong></td>
</tr>
<tr class="even">
<td>3.0.0.x[SLC Main]</td>
<td><ul>
<li>AVCM Channels retrieved</li>
<li>AVCM Channels Validation</li>
<li>HTTP Status counter</li>
</ul></td>
<td>-</td>
<td>-</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 3.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 3.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: \[The IP port of the destination. (default: *443*)\]
- **Device address**: \[The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.\]

### Initialization

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

\- **AVCM Pods Mapping** table allows you to either manually set the **Compression Element** or automatically which would look into the **Protocols** table and find the element doing a mapping between the **Pod Service** column and the **Pod Name** property.

\- **Custom Channels** table can be imported using a csv file with the proper format.

\- **Protocols** table allows you to manually enter **Compression Element** protocols.

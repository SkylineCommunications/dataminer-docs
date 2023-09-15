---
uid: Connector_help_Grass_Valley_Morpheus_Panoplay_On_Air
---

# Grass Valley Morpheus Panoplay On Air

This device manages channel redundancy, and whether said channels are on air, or offline. The redundancy is provided through configurable channel synchronization across multiple redundant systems.

## About

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
<td>1.0.0.x [SLC Main]</td>
<td><ul>
<li>Obtains the status for system channels</li>
<li>Allows configuration of which channels to obtain</li>
</ul></td>
<td>-</td>
<td>-</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General Page

The general page displays a **Channel Status and Configuration** table where the configured system and channels will be displayed, as well as their current status. To configure a new system/channel, go into the **Add New Channel** page, accessible through the page button at the bottom of the general page.

In there, fill in the two required parameters, and press the **Add New Row** button. This will add a new channel configuration to the table.

## Notes

A custom Visio file will be available for this protocol.

---
uid: Connector_help_Red_Bee_Media_Aggregation_Matrix
---

# Red Bee Media Aggregation Matrix

This protocol works with the Generic Matrix Virtualization connector and the Grass Valley Convergent. It is capable of routing signals through one of the Convergent devices, which is connected to the Generic Matric Virtualization element, and over the different layers of the Convergent.

## About

### Version Info

| **Range**            | **Key Features**                                                                            | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- Routing signals on multiple layers in 1 matrix.- Output path calculation for all layers. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

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
<td><p>Visio drawings:</p>
<ul>
<li>Generic vMatrix - RBM Aggregation Matrix - Main</li>
<li>Generic vMatrix - RBM Aggregation Matrix - RouterControl</li>
</ul></td>
<td>-</td>
</tr>
</tbody>
</table>

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

All Grass Valley Convergent source matrices need to be created with version 1.0.3.1 or higher. They must be set to *All Levels Take* and layer "All", and connected to a Generic Matrix Virtualization element that is fully configured, using version 4.0.0.17 or higher.

Two element connections then need to be created:

- From the **Generic Matrix Virtualization** element, parameter: "Generic Matrix Virtualization - Info", to the **Aggregation matrix**, parameter: "Vmatrix Configuration String (write)".
- From the **Grass Valley Convergent** element, parameter: "Convergent Layer Status String", to the **Aggregation matrix**, parameter: "Convergent Layer Status String (write)".

For more information on element connections, see [Virtual elements](https://help.dataminer.services/dataminer/#t=DataMinerUserGuide/part_2/elements/Virtual_elements.htm) in the DataMiner Help.

### Redundancy

There is no redundancy defined.

## How to use

This driver is intended to be used in the background to support the Red Bee Media Visual Overview pages (See "Linked Components" above).

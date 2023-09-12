---
uid: Connector_help_Generic_DCF_Waveguide_Switch
---

# Generic DCF Waveguide Switch

This virtual connector can be used to represent a waveguide switch. The connector displays a **Position** parameter with two possible values: *Position A* and *Position B.* Operators can switch between the two positions by clicking the **Toggle Position** button.

This connector does not actually poll any data from a device. Instead it connects to an already existing element using the **Element Connections** module of DataMiner.

Multiple ranges of the connector exist in parallel to support the different position values.

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
<td>Initial version. Position values:
<ul>
<li>Read/Write</li>
<li><ul>
<li>Position A = A</li>
<li>Position B = B</li>
</ul></li>
</ul></td>
<td>-</td>
<td>-</td>
</tr>
<tr class="odd">
<td>1.1.0.x [SLC Main]</td>
<td>Position values:
<ul>
<li>Read/Write</li>
<li><ul>
<li>Position A = 1</li>
<li>Position B = 3</li>
</ul></li>
</ul></td>
<td>1.0.0.1</td>
<td>-</td>
</tr>
<tr class="even">
<td>1.2.0.x [SLC Main]</td>
<td>Position values:
<ul>
<li>Read/Write</li>
<li><ul>
<li>Position A = 2</li>
<li>Position B = 3</li>
</ul></li>
</ul></td>
<td>1.0.0.1</td>
<td>-</td>
</tr>
<tr class="odd">
<td>1.3.0.x [SLC Main]</td>
<td>Position values:
<ul>
<li>Read/Write</li>
<li><ul>
<li>Position A = 1</li>
<li>Position B = 2</li>
</ul></li>
</ul></td>
<td>1.0.0.1</td>
<td>-</td>
</tr>
<tr class="even">
<td>1.4.0.x [SLC Main]</td>
<td>Position values:
<ul>
<li>Read/Write</li>
<li><ul>
<li>Position A = 0</li>
<li>Position B = 1</li>
</ul></li>
</ul></td>
<td>1.0.0.1</td>
<td>-</td>
</tr>
<tr class="odd">
<td>1.5.0.x [SLC Main]</td>
<td>Position values:
<ul>
<li>Read</li>
<li><ul>
<li>Position A = 0</li>
<li>Position B = 1</li>
</ul></li>
<li>Write</li>
<li><ul>
<li>Position A = 31</li>
<li>Position B = 32</li>
</ul></li>
</ul></td>
<td>1.0.0.1</td>
<td>-</td>
</tr>
<tr class="even">
<td>1.6.0.x [SLC Main]</td>
<td>Position values:
<ul>
<li>Read</li>
<li><ul>
<li>Position A = 0</li>
<li>Position B = 1</li>
</ul></li>
<li>Write</li>
<li><ul>
<li>Position A = A</li>
<li>Position B = B</li>
</ul></li>
</ul></td>
<td>1.0.0.1</td>
<td>-</td>
</tr>
</tbody>
</table>

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.1.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.2.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.3.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.4.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.5.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.6.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## How to Use

This connector is a switch controller connector. The correct connections with the actual element (the element to be managed) have to be configured in the **Element Connections** module of DataMiner.

The connector displays a **Position** parameter with two possible values: *Position A* and *Position B.* The operator can switch between the two positions by clicking the **Toggle Position** button.

## DataMiner Connectivity Framework

All ranges of the **Generic DCF Waveguide Switch** connector supports the usage of DCF and can only be used on a DMA with **8.0.0** as the minimum version.

### Interfaces

#### Fixed interfaces

Virtual fixed interfaces:

- **In_1_A**: is created to parameter **In_1_A** and interface type is **in**.
- **In_1_B**: is created to parameter **In_1_B** and interface type is **in**.
- **Out_1_A**: is created to parameter **Out_1_A** and interface type is **out**.
- **Out_1_B**: is created to parameter **Out_1_B** and interface type is **out**.

### Connections

#### Internal Connections

The connector has the following possible internal connections:

- between interface In_1_A and Out_1_A
- between interface In_1_A and Out_1_B
- between interface In_1_B and Out_1_A
- between interface In_1_B and Out_1_B

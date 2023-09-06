---
uid: Connector_help_Axon_ACP_2HS10
---

# Axon ACP 2HS10

The 2HS10 is a dual channel ultra high-quality down converter.

The **Axon ACP 2HS10** driver is used to configure and monitor the 2HS10 card.

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
<td>1.0.0.x[SLC Main]</td>
<td><ul>
<li>Initial Version</li>
</ul></td>
<td>-</td>
<td>-</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3130                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

Interface connection:

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: \[The IP port of the destination. (fixed value: *2071*)\]
- **Bus address**: \[The bus address or slot number/position of the card in the frame.\]

#### Serial Broadcast Connection

This driver uses a smart-serial connection and requires the following input during element creation:

SMART SERIAL CONNECTION:

Interface connection:

- **IP address/host**: \[The polling IP or URL of the destination. Specify "any".\]
- **IP port**: \[The IP port of the destination. (fixed value: *2071*)\]
- **Bus address**: \[The bus address of the device.\]

### Initialization

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

## How to use

The element has the following pages:

- **General**: Displays information about the identity of the card and other general information: **Card Name**, **Card Description**, **SW Revision**, **HW Revision**, etc.
- **I/O:** Contains the input and output settings and status information.
- **Down** **Converter A**: Contains down conversion setting parameters of Channel A.
- **Down** **Converter B**: Contains down conversion setting parameters of Channel B.
- **Alarm Priority:** Displays the event messages of the card, i.e. special messages generated asynchronously on the card.

**Note**: If the setting of a parameter depends on another parameter, when the user tries to set the second parameter before the first parameter is set, a pop up window will be displayed indicating what to do first. In this case, the user must set the first parameter according to the information in the pop up window before setting the second parameter. Example: In order to set Coring Level (on the Down Converter pages), the Coring has to be set to Level_dep.

## Dataminer Connectivity Framework

The **1.0.0.x** driver range of the Axon ACP 2HS10 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third Party protocols (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **SDI Input** **A:** A single fixed interface of type **in**
- **SDI Input B**: A single fixed interface of type **in**.
- **SDI HD/SD Output A**: A single fixed interface of type **out**.
- **SDI Output A**: A single fixed interface of type **out**.
- **SDI HD/SD Output B**: A single fixed interface of type **out**.
- **SDI Output B**: A single fixed interface of type **out**.

### Connections

#### Internal Connections

- **SDI Input A -\> HD/SD SDI Output A**
- **SDI Input A -\> SDI Output A**
- **SDI Input B -\> HD/SD SDI Output B**
- **SDI Input B -\> SDI Output B**

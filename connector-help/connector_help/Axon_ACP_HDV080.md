---
uid: Connector_help_Axon_ACP_HDV080
---

# Axon ACP HDV080

The HDV080 card is 3Gb/s - HD - SD SDI distribution amplifier with a built-in 3Gb/s, HD SDI to SD SDI or composite down converter.

The **Axon ACP HDV080** driver is used to configure and monitor the HDV080 card.

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
| 1.0.0.x   | 1010                   |

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

  - **IP address/host**: The polling IP or URL of the destination.
- **IP port**: \[The IP port of the destination. (fixed value: *2071*)\]
- **Bus address**: \[The bus address or slot number/position of the card in the frame.\]

#### Serial Broadcast Connection

This driver uses a smart-serial connection and requires the following input during element creation:

SMART SERIAL CONNECTION:

Interface connection:

  - **IP address/host**: \[The polling IP or URL of the destination. Specify "any"\]
- **IP port**: \[The IP port of the destination. (fixed value: *2071*)\]
- **Bus address**: \[The bus address or slot number/position of the card in the frame.\]

### Initialization

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

## How to use

The element has the following pages:

> **General:** Displays information about the identity of the card and other general information: Card Name, Card Description, SW Revision, HW Revision, etc.
>
> **I/O:** Contains the input and output settings and status information.
>
> **Preset:** Contains the **Presets** and **Aspect Ratio** parameters.
>
> **Video Processing:** Contains the **Gain**, **Black**, and **Filters** parameters.
>
> **Inserter:** Contains the **WSS**, **Timecode**, and **Video Index** parameters.
>
> **Alarm Priority:** Displays the event messages of the card, i.e. special messages generated asynchronously on the card.

**Note**: If the setting of a parameter depends on another parameter, when the user tries to set the second parameter before the first parameter is set, a pop up window will be displayed indicating what to do first. In this case, the user must set the first parameter according to the information in the pop up window before setting the second parameter. Example: In order to set Active Preset (on the Preset page), the Preset Control has to be set to Manual mode.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the Axon ACP HDV080 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **HDV080 SDI Input:** A single fixed interface of type **in**.
- **HDV080 HD/SD SDI Output 1:** A single fixed interface of type **out**.
- **HDV080 HD/SD SDI Output 2:** A single fixed interface of type **out**.
- **HDV080 HD/SD SDI Output 3:** A single fixed interface of type **out**.
- **HDV080 HD/SD SDI Output 4:** A single fixed interface of type **out**.
- **HDV080 SDI/CVBS Output 1:** A single fixed interface of type **out**.
- **HDV080 SDI/CVBS Output 2:** A single fixed interface of type **out**.
- **HDV080 SDI/CVBS Output 3:** A single fixed interface of type **out**.
- **HDV080 SDI/CVBS Output 4:** A single fixed interface of type **out**.

### Connections

#### Internal Connections

- **SDI Input -\> HD/SD SDI Output 1**
- **SDI Input -\> HD/SD SDI Output 2**
- **SDI Input -\> HD/SD SDI Output 3**
- **SDI Input -\> HD/SD SDI Output 4**
- **SDI Input -\> SDI/CVBS Output 1**
- **SDI Input -\> SDI/CVBS Output 2**
- **SDI Input -\> SDI/CVBS Output 3**
- **SDI Input -\> SDI/CVBS Output 4**

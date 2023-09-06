---
uid: Connector_help_Snell_Wilcox_Alchemist_Ph.C_-_HD
---

# Snell Wilcox Alchemist Ph.C - HD

This protocol can be used to monitor and manipulate the Snell Wilcox Alchemist Ph.C - HD device. It uses SNMP to request data from the device.

The device converts high-definition video signals with a PH.C motion measurement technology.

## About

### Version Info

| **Range** | **Key Features**        | **Based on** | **System Impact** |
|-----------|-------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version.        | \-           | \-                |
| 2.0.0.x   | New firmware supported. | \-           | \-                |
| 2.0.1.x   | External DCF added.     | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 2.0.0.x   | \-                     |
| 2.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 2.0.0.x   | No                  | No                      | \-                    | \-                      |
| 2.0.1.x   | Yes                 | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when reading values from the device. The default value is *private.*

## How to use

The element consists of the data pages detailed below.

### Quick Config Page

Contains input and output configuration parameters, as well as Noise Reduction, Audio AES and Embedded Input Status, Ph.C and Loss Mode.

Page buttons provide access the **Input,** **Output A Standard**, and **Memory** subpages.

### General Page

Contains general parameters related to memory and audio, as well as the Input Cadence Str.

### Input Page

Contains parameters for **Blanking** (Left, Right, Top and Bottom) as well as other input parameters.

A page button provides access to the **Input Standard** subpage, where you can set the input standard. You can enable auto assignment or configure a custom setting for a certain frequency.

### Output A/B Pages

These pages contain parameters for Blanking, Colorimetry, Border, VANC, Close Caption and more. On the **Output A Standard** subpage, you can set the output A standard. You can enable auto assignment or configure a custom setting for a certain frequency.

### ProcAmps Page

Contains parameters related to the Enhancer and the Alias Suppression.

### Conversion Page

Contains conversion-related parameters. On the **Active Areas** subpage, the status of each active area (1 to 5) can be set.

### Display Page

Contains size, ASP, pan and tilt parameters for channel A and B.

The following page buttons are available:

- **Transition**: Contains settings related to the transition slew
- **Control**: Contains display control parameters.

### Noise Reduction Page

Displays settings related to noise reduction.

### Utils Page

Contains different parameters for channel A and B. You can among others enable or disable mono on the channel, configure patterns, enable or disable cut to black, etc.

### Reference Page

Contains settings related to horizontal and vertical references.

### Audio Pages

These pages contain numerous settings related to the output A and B embedders and the output AES, as well as the Headphone level, Headphone Source and Global Audio Delay.

### Dolby Encoder Page

Contains settings related to the two Dolby encoders.

### System Page

Contains system-related parameters. On the Memory subpage you can select and rename a memory, and store or recall it.

### SNMP Page

Contains SNMP-related parameters. The **SNMP Traps** subpage contains a table with traps information.

### Filmtools Page

Contains film and blur settings. Page buttons are available to the following subpages:

- **Detection**: Contains settings for the detection of film tools.
- **Input/Output Cadence**: Contains settings related to input/output cadence.

### Timecode Page

Contains parameters related to time code and synchronization. You can among others enable/disable the overlay on the input, output A and output B. On the Timecode Conversion subpage, you can find parameters related to conversion of the time code.

### Alarm Page

Displays the status of the input and output parameters.

## DataMiner Connectivity Framework

The 2.0.1.x range of this protocol supports the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third Party protocols (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **SDI A Input**: Physical SDI interface with type **in**.
- **SDI B Input**: Physical SDI interface with type **in.**
- **A Output**: Physical SDI interface with type **out**.
- **B Output**: Physical SDI interface with type **out**.

## Notes

When upgrading from driver version 2.0.0.2 to 2.0.1.1, check if all Visio drawings and Automation scripts are still fully functional, as errors may occur with certain implementations.

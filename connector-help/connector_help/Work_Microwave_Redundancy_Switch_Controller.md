---
uid: Connector_help_Work_Microwave_Redundancy_Switch_Controller
---

# Work Microwave Redundancy Switch Controller

The Redundancy Switches from WORK Microwave are utilized to provide redundant configurations with automatic or manual switchover for subsystem using Upconverters, Downconverters, or Modulator-Upconverters from WORK Microwave or similar equipment.

## About

With this connector, it is possible to monitor and configure **Work Microwave Redundancy Switch Controller** devices and the connected **converters** with a **serial** connection.

The different parameters from the device are displayed on multiple pages. Specific parameters for the converters are displayed by the converter connector.

#### Serial connection:

This connector uses a **Serial** connection and requires the following input during element creation:

- **IP address/host**: The IP address of the device, e.g. *192.168.10.2.*
- **IP port**: The port of the connected device, by default *22*.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          |                             |

## Installation and configuration

### Creation

When creating the element the **device IP address,** the **port and** the **bus address** should be filled in. The default bus address is 66.

## Usage

### General

This page displays **general System Information** and the **Overall Status** of the device and the connected converters.

With the page button, It is possible to change some general configuration.

### Events

This page displays the **Events History** stored on the device (maximum 99). The "**clear Event History**" button clears the event history on the device.

### Uplink Power Control

This page allows the user to view and change settings about the UPC module such as:

- **Clear Sky Calibration**
- **Deep Fade Settings**

### Device Configuration

This page displays the **System Date** and **Time** and allows the user to modify the **RF- and IF Relay pulse time.**

This page allows the user as well to **Save**, **Load** and **Clear** configurations on the device. There are 16 (0 - 15) slots to store configurations, slot 0 is loaded at startup.

The "**Factory Reset**" button allows the user to reset the device configuration.^

## DataMiner Connectivity Framework

The Work Microwave supports the usage of DCF from version 1.0.0.2 onwards and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

Device inputs:

- Input 1 A (in)
- Input 1 B (in)
- Input 2 A (in)
- Input 2 B (in)
- Output 1 A (in)
- Output 1 B (in)
- Output 2 A (in)
- Output 2 B (in)
- Output 3 A (in)
- Output 3 B (in)
- Output 4 A (in)
- Output 4 B (in)

Device outputs:

- Input 1 A Out(out)
- Input 1 B Out (out)
- Input 2 A Out (out)
- Input 2 B Out (out)
- Output 1 A Out (out)
- Output 1 B Out (out)
- Output 2 A Out (out)
- Output 2 B Out (out)
- Output 3 A Out (out)
- Output 3 B Out (out)
- Output 4 A Out (out)
- Output 4 B Out (out)

### Connections

#### Internal Connections

- Fixed: Input 1 B out (out) - Input 2 B (in)
- Fixed: Output 3 B out (out) - Output 1 B (in)
- Fixed: Output 4 B out (out) - Output 2 B (in)

- Input 1 A (in) - Input 1 A/B Out (out)
- Input 1 B (in) - Input 1 A/B Out (out)
- Input 2 A (in) - Input 1 A/B Out (out)
- Input 2 B (in) - Input 1 A/B Out (out)

- Output 1 A (in) - Output 1 A/B Out (out)
- Output 1 B (in) - Output 1 A/B Out (out)
- Output 2 A (in) - Output 1 A/B Out (out)
- Output 2 B (in) - Output 1 A/B Out (out)

- Output 3 A (in) - Output 3 A/B Out (out)
- Output 3 B (in) - Output 3 A/B Out (out)
- Output 4 A (in) - Output 4 A/B Out (out)
- Output 4 B (in) - Output 4 A/B Out (out)

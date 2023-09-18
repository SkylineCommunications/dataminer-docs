---
uid: Connector_help_Axon_ACP_ERS11
---

# Axon ACP ERS11

The **Axon ACP ERS11** connector can be used to display information and configure settings of the related device.

## About

A **serial** connection is used in order to retrieve information from the device and to configure the device.

In addition, there are different possibilities for alarm monitoring and trending of the supported Axon card types.

### Version Info

| **Range** | **Description**      | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version      | No                  | No                      |
| 2.0.0.x          | Override DVE timeout | No                  | No                      |

### Product Info

This connector supports multiple firmware versions for multiple card types.

An overview of the supported card types can be found in the "Exported connectors" section below.

The implemented firmware versions for each supported card type are described in the "Supported firmware versions" sections of the connector help pages of these cards.

### Exported connectors

| **Exported Connector**  | **Description**                                                                                                                |
|------------------------|--------------------------------------------------------------------------------------------------------------------------------|
| Axon ACP ERS11 - 2IX08 | Dual-channel basic signal integrity monitor with switch-over function.                                                         |
| Axon ACP ERS11 - 2IX11 | Dual-channel high performance SDI video and embedded audio probe with clean switch-over function.                              |
| Axon ACP ERS11 - 2TG10 | Dual-channel test pattern generator.                                                                                           |
| Axon ACP ERS11 - ASI10 | Dual-channel ASI/DVB integrity checker with 2x2 output switch.                                                                 |
| Axon ACP ERS11 - DAD08 | Digital audio distribution amplifier that distributes a single input to eight outputs.                                         |
| Axon ACP ERS11 - DAD26 | Dual AES/EBU channel digital audio distribution amplifier.                                                                     |
| Axon ACP ERS11 - DIO48 | Conversion of asynchronous AES/EBU digital audio into synchronous AES/EBU.                                                     |
| Axon ACP ERS11 - ERS11 | Central controller of the Synapse system.                                                                                      |
| Axon ACP ERS11 - GDR26 | Dual-channel 3GB/s, HD, SD SDI reclocking distribution amplifier.                                                              |
| Axon ACP ERS11 - GPI16 | Universal Synapse GPI I/O (Input/Output) card.                                                                                 |
| Axon ACP ERS11 - HAF90 | Embedder, shuffler, framesync with AES/EBU digital audio inputs.                                                               |
| Axon ACP ERS11 - HDB05 | HD SDI and SD SDI digital audio de-embedder.                                                                                   |
| Axon ACP ERS11 - HDR07 | HD/SD SDI reclocking distribution amplifier.                                                                                   |
| Axon ACP ERS11 - HDR09 | Dual-channel HD/SD SDI reclocking distribution amplifier.                                                                      |
| Axon ACP ERS11 - HDS05 | Premium quality downconverter.                                                                                                 |
| Axon ACP ERS11 - HEB05 | HD SDI and SD SDI digital audio embedder.                                                                                      |
| Axon ACP ERS11 - HIX01 | Dual-channel high-performance 3GB/s, HD and SD SDI basic video and embedded audio probe with clean video switch-over function. |
| Axon ACP ERS11 - SAV08 | SDI to composite, component and Y/C converter with a built-in SDI distribution amplifier.                                      |
| Axon ACP ERS11 - SDR07 | Triple channel reclocking distribution amplifier compatible with ASI/DVB.                                                      |
| Axon ACP ERS11 - SDR08 | Card that reclocks the input signal and has 1 to 8 distribution amplifiers compatible with AES/DVB.                            |
| Axon ACP ERS11 - SDR09 | Card that reclocks the input signal and has 1 to 3 and 1 to 4 distribution amplifiers compatible with AES/DVB.                 |
| Axon ACP ERS11 - SLI10 | SD-only logo inserter with a preset base logo recall function.                                                                 |

## Installation and configuration

### Creation

#### Serial Main Connection

The connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

- **Baudrate:** Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits:** Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits:** Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity:** Parity specified in the manual of the device, e.g. *No*.
  - **FlowControl:** FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

  - **IP address/host:** The polling IP of the device.
  - **IP port:**\[The IP port of the device. Default value: *2071*.

## Usage

### Main Controller

This page displays an overview of the status and settings of the main controller (chassis).

### Module Overview

This page provides an overview of which card type and version is inserted in which slot.

In addition, you can also configure several settings related to the DVE element names, such as the **Element Prefix**, **Element Postfix**, etc.

### Cards

This page provides an overview of the supported card types.

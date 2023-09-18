---
uid: Connector_help_Axon_ACP_ERS10
---

# Axon ACP ERS10

The **Axon ACP ERS10** connector can be used to display and configure information of the Axon ERS10 central controller and the attached card types located in its different slots.

## About

A **serial** connection is used in order to retrieve and configure the device's information.

In addition, the connector offers several possibilities for **alarm monitoring** and **trending** of the supported Axon card types.

### Version Info

| **Range** | **Description**                                                                                                 | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                                 | No                  | No                      |
| 1.1.0.x          | No automatic DVE removal, except for unsupported card types (Based on 1.0.0.2)                                  | No                  | No                      |
| 1.2.0.x          | Supported chassis revision 108. No automatic DVE removal, except for unsupported card types (Based ond 1.0.0.2) | No                  | No                      |
| 2.1.0.x          | Override DVE Timeout (Based on 1.1.0.1)                                                                         | No                  | No                      |
| 2.2.0.x          | Override DVE Timeout (Based on 1.2.0.1)                                                                         | No                  | No                      |

### Product Info

The Axon ACP ERS10 supports multiple firmware versions for multiple card types.

An overview of the supported card types can be found in the "Exported connectors" section.

The implemented firmware versions for each supported card type are described in the connector help's "Supported firmware versions" section of the related card.

### Exported Connectors

| **Exported Connector**  | **Description**                                                                                                |
|------------------------|----------------------------------------------------------------------------------------------------------------|
| Axon ACP ERS10 - 2IX08 | Dual channel basic signal integrity monitor with switch-over function.                                         |
| Axon ACP ERS10 - 2IX11 | Dual channel high-performance SDI video and embedded audio probe with clean switch-over function.              |
| Axon ACP ERS10 - 2TG10 | Dual channel test pattern generator.                                                                           |
| Axon ACP ERS10 - ASI10 | Dual channel ASI/DVB integrity checker with 2x2 output switch.                                                 |
| Axon ACP ERS10 - DAD08 | Digital audio distribution amplifier that distributes a single input to eight outputs.                         |
| Axon ACP ERS10 - DAD26 | Dual AES/EBU channel digital audio distribution amplifier.                                                     |
| Axon ACP ERS10 - DIO48 | Conversion of asynchronous AES/EBU digital audio into synchronous AES/EBU.                                     |
| Axon ACP ERS10 - ERS10 | Central controller of the Synapse system.                                                                      |
| Axon ACP ERS10 - GDR26 | Dual channel 3GB/s, HD, SD SDI reclocking distribution amplifier.                                              |
| Axon ACP ERS10 - GPI16 | Universal Synapse GPI I/O (Input/Output) card.                                                                 |
| Axon ACP ERS10 - HAF90 | Embedder, shuffler, framesync with AES/EBU digital audio inputs.                                               |
| Axon ACP ERS10 - HDB05 | HD SDI and SD SDI digital audio de-embedder.                                                                   |
| Axon ACP ERS10 - HDR07 | HD/SD SDI reclocking distribution amplifier.                                                                   |
| Axon ACP ERS10 - HDR09 | Dual channel HD/SD SDI reclocking distribution amplifier.                                                      |
| Axon ACP ERS10 - HDS05 | Premium quality downconverter.                                                                                 |
| Axon ACP ERS10 - HEB05 | HD SDI and SD SDI digital audio embedder.                                                                      |
| Axon ACP ERS10 - SAV08 | SDI to composite, component and Y/C converter with a built-in SDI distribution amplifier.                      |
| Axon ACP ERS10 - SDR07 | Triple channel reclocking distribution amplifier compatible with ASI/DVB.                                      |
| Axon ACP ERS10 - SDR08 | Card that reclocks the input signal and has 1 to 8 distribution amplifiers compatible with AES/DVB.            |
| Axon ACP ERS10 - SDR09 | Card that reclocks the input signal and has 1 to 3 and 1 to 4 distribution amplifiers compatible with AES/DVB. |
| Axon ACP ERS10 - SLI10 | SD-only logo inserter with a preset base logo recall function.                                                 |

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
  - **IP port:** The IP port of the device, by default *2071*.

## Usage

### Main Controller

This page displays an overview of the status and settings of the main controller (chassis).

### Module Overview

This page provides an overview of which card type and version is inserted in which slot.

In addition, you can configure settings related to the DVE element name, such as the **Element Prefix**, **Element Postfix**, etc.

### Cards

This pages provides an overview of the supported card types.

---
uid: Connector_help_LYNX_Technik_AG_Series_5000
---

# LYNX Technik AG Series 5000

This connector monitors the activity of the Lynx Technik AG Series 5000 device. Series 5000 is a rack-based terminal equipment solution that can be user-configured with any combination of card modules from an extensive range of available solutions. This includes audio distribution, conversion and processing, as well as video distribution, conversion, embedding and de-embedding, frame synchronization, test generators, downconverters and video processors.

## About

This connector polls data from the device using a **smart-serial** connection. For each of the card modules, a DVE is generated.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version | **Serial Protocol Version** |
|------------------|-----------------------------|-----------------------------|
| 1.0.0.x          | 8.8.1                       | 1.9                         |

### Exported connectors

| **Exported Connector**                    | **Description**                                           |
|------------------------------------------|-----------------------------------------------------------|
| LYNX Technik AG Series 5000 - RCT 5023-G | Rack Controller                                           |
| LYNX Technik AG Series 5000 - DVD 5820   | Switching and Distribution Unit                           |
| LYNX Technik AG Series 5000 - PDM 5380   | Audio Embedder                                            |
| LYNX Technik AG Series 5000 - PVD 5802   | Frame Synchronizer                                        |
| LYNX Technik AG Series 5000 - DVA 5718-L | Analog Video Distribution Amplifier with RollCall Control |
| LYNX Technik AG Series 5000 - CDX 5624   | Downconverter                                             |
| LYNX Technik AG Series 5000 - PVD 5810   | Frame Synchronizer                                        |
| LYNX Technik AG Series 5000 - PVD 5840-D | Frame Synchronizer                                        |
| LYNX Technik AG Series 5000 - PMX 5364   | Audio Embedder                                            |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. The default IP port is *2306.*

### Configuration

To make sure the connector works correctly, on the **General** page, set the **Child Completion State** parameter to *Enabled.*

## Usage

### General

This page displays information about the **Stacks**, **Controllers** and **Cards** available in the device.

It is also possible to view the **Serial Protocol Version** of the device here and to enable or disable the **Child Completion State**.

The parameter **Time Since Last Pushed Data** displays the time in seconds since the device and the element comunicated with each other.

### Overview

On this page, a **tree view** displays the current modules of the device grouped by **Stacks**, **Controllers** and **Cards**.

### DVE

Each module table on this page displays the DVEs created by the main element. If a card is not available in the device, you can delete the corresponding DVE child element by pressing the **Remove** button.

You can also enable an **Automatic Removal** option or **Remove All** DVEs of the cards that are not available in the device.

## Note

On the General page, the **Child Completion State** must be *Enabled* in order for the connector to work.

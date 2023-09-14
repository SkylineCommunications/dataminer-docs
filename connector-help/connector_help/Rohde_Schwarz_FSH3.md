---
uid: Connector_help_Rohde_Schwarz_FSH3
---

# Rohde Schwarz FSH3

The Rohde Schwarz FSH3 is a remote spectrum analyzer. The frequency ranges from100 kHz to 3 GHz.

## About

### Version Info

| **Range**            | **Key Features**                                        | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                        | \-           | \-                |
| 2.0.0.x \[Obsolete\] | \-                                                      | \-           |                   |
| 2.1.0.x \[SLC Main\] | Driver logic review. No major changes were implemented. | 2.0.0.2      | Logic review.     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 2.0.0.x   | \-                     |
| 2.1.0.x   | V13.14                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | no                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *4001*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the data pages described below.

### Spectrum Analyzer Page

This page contains the Spectrum Analysis user interface.

On the left, a graphical view of the incoming signal is displayed. On the right, multiple settings are available that allow you to configure the displayed view and the spectrum analyzer.

For more information, refer to the DMS Spectrum Analysis section of the DataMiner Help.

### General Page

This page displays general information about the analyzer: **Manufacturer**, **Model**, **Serial Number** and **Firmware Version**.

The page also contains the following general configuration parameters: device baud rate, trace detection mode, display configuration and sweep mode.

Note: Changing the baud rate value can cause the loss of communication with the device.

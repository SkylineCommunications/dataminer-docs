---
uid: Connector_help_Grass_Valley_Biometrics_AP
---

# Grass Valley Biometrics AP

The Grass Valley Biometrics AP is part of GV's Media Assurance platform, using Media Biometrics. There is a device in the network that generates Biometric data for a piece of media that the AP (Assurance Point) will then use to compare with the media. This device communicates asynchronously using the Rollcall protocol.

## About

### Version Info

| **Range**            | **Key Features**                    | **Based on** | **System Impact**                                                                                                                                                                                                                                  |
|----------------------|-------------------------------------|--------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version                     | \-           | \-                                                                                                                                                                                                                                                 |
| 1.0.1.x \[SLC Main\] | Long string commands are supported. | 1.0.0.2      | The parameters are polled via one single command definition, which is initialized by a QAction. The other redundant command definitions and their building blocks (parameters) are removed. The data parameters of each driver page are untouched. |

### Product Info

| **Range** | **Supported Firmware**                                                                |
|-----------|---------------------------------------------------------------------------------------|
| 1.0.0.x   | 2.9.2.r1.588                                                                          |
| 1.0.1.x   | 2.9.2.r1.588 Please note that the device must be able to provide the service LongStr. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.

  - **IP port**: The IP port of the destination (default: *2050*).

  - **Bus address**: The bus address of the device.

  - - Range 1.0.0.x: The format is equal to *UU.PP*, where UU is the unit address and PP is the unit port. For example: *01.01*.
    - Range 1.0.1.x: The format is equal to *NNNN.UU.PP*, where NNNN is the unit network address, UU is the unit address and PP is the unit port. For example: *1160.01.01*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element has two main functions: **configuration** and **logging**.

You can configure the general audio and device settings, the audio mapping, thresholds, and licenses associated with the device.

Logging is available for the device, audio, video and captions.

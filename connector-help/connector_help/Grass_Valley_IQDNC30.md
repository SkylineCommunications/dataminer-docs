---
uid: Connector_help_Grass_Valley_IQDNC30
---

# Grass Valley IQDNC30

This connector uses the RollCall community library package to communicate with the device. It is able to retrieve, set and monitor information regarding audio channel routing, delay adjustment and level controls, as well as video metadata such as timecode, closed captions and teletext captions.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                   |
|-----------|------------------------------------------|
| 1.0.0.x   | V5.7.9 \| RollCall Library Version 3.0.9 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **Bus address**: The bus address of the device. Specify the bus address in the format **UU.PP**, with UU being the RollNet address and PP being the slot number (chassis is 00). Example: *10.01*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver has the following data pages:

- **General**: Allows you to check the polling state and enable/disable debug mode.
- **Input**: Displays the summary of the input state and statistics.
- **Output:** Allows you to apply various settings and adjustments to the video output signal for each video processing channel.
- **Video:** Allows you to view and set various types of signal processing to the signal that is being converted, and includes **Proc Amp**, **Nonlinear Enhancer** controls.
- **ARC & Sidebar Keyer:** Allows you to control the aspect ratio of a picture with a range of options, and to adjust the size and position of the picture manually.
- **Audio Routing:** Allows you to route any available audio input pair to any process pair.
- **Audio Shuffle:**
- **Genlock**
- **Timecode**
- **Setup:** Displays basic information about the unit, such as the serial number and software version**.**

## Notes

In the initial version of this connector, only a subset of the information available in the device is implemented.

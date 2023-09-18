---
uid: Connector_help_Axon_ACP_UXU510
---

# Axon ACP UXU510

The UXU500-510/GXG500-510 is a high-end up-/down-/cross-converter. With high-end quality deinterlacers and extensively computer-optimized scaling and filter algorithms, the 500 series of up-/down-/cross-converters ensures quality video conversion from any standard to any standard within the same frame rate. The card allows you to simulcast any output standard in any format from any source standard.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2304                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination. Fixed value: *2071*.
  - **Bus address**: The bus address or slot number/position of the card in the frame.

#### Serial IP Connection - Events Connection

This connector uses a smart-serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination. Fixed value: *2071*.
  - **Bus address**: The bus address or slot number/position of the card in the frame.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to Use

The setting of some parameters depends on other parameters' current value. For example, on the Network page, in order to set the Preferred IP Address, you need to make sure the IP Configuration is set to *Manual* mode.

When such a parameter is not set to the correct value, a message box will be displayed. Follow the instructions in the message box and set the required parameter to the appropriate value before setting the other parameter.

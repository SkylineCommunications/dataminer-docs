---
uid: Connector_help_Sky_UK_MagiQ_STB_Automation
---

# Sky UK MagiQ STB Automation

The Sky UK MagiQ STB Automation driver is used to monitor different set-top boxes.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | API revision 20        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### WebSocket Connection

This driver uses a WebSocket connection and requires the following input during element creation:

WEBSOCKET CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The **Automation Control** table is used to control and monitor the STB boxes.

Before you send commands using the **Send** button in the **Send Command** column, make sure to enter a valid remote control command sequence in the **Command Sequence** field. If no command data is provided or if it is not provided in the correct JSON format, a pop-up message will be displayed.

The **Check Motion/Audio** button can be used to check if there is **video** and **audio** in the selected stream. Note that to capture correct video/audio detection data, the threshold and coordinate parameters need to be configured properly.

For some DataMiner versions, the **Capture** button in the **Screen Grab** column might not properly save the images in the designated folder.

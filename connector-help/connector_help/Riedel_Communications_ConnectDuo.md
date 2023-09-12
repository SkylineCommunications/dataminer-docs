---
uid: Connector_help_Riedel_Communications_ConnectDuo
---

# Riedel Communications ConnectDuo

This driver retrieves information from an ISDN & POTS Audio Codec via serial communication and makes it possible to configure certain settings.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

- **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device, e.g. *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

<!-- -->

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver consists of the following data pages:

- **General**: Displays important information such as the Processor Load, Temperature, and Login Status of the device.
- **Audio**: Displays the Audio Mode, Requested Audio Mode, Audio Decoder Mode and Audio Encoder Mode for line 1 and line 2 of the device.
- **Call Control**: Displays the Connection State, Caller ID, and Last Caller ID of line 1 and line 2 of the device. You can also set **Auto Answer** to *On* or *Off*, **disconnect** the connection to line 1 or line 2, **redial** the last caller ID, and call a **new configurable telephone number**.
- **Audio Settings**: Allows you to configure the Audio Input Level (dBu), Audio Output Level (dBu) and Audio Mode for line 1 and line 2 of the device.
- **Auto Answer Settings**: Allows you to set Auto Answer to *On* or *Off,* and configure the **Auto Answer Delay**.
- **ISDN Settings**: Allows you to configure the ISDN Protocol, disable incoming calls and define Permanent ISDN Layer 2.

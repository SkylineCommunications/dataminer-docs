---
uid: Connector_help_AppearTV_Encoder_-_Transcoder
---

# AppearTV Encoder - Transcoder

This connector can be used to configure an AppearTV transcoder module with an automation script or manager connector.

## About

Only the the transcoder configuration parameters of AppearTV card are implemented in this connector.

All communication with the device is done via the HTTP protocol.

Note:

- Individual configuration sets are not implemented. It's only possible to configure all settings at once.
- This connector is intended to be used in combination with an automation script or a manager connector.
- The element bus address is used to specify the scope of this element: Slot -\> Block -\> Channel (port)

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Software version 3.22       |

## Installation and configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.

- **IP port**: The IP port of the destination. Default: *80*.

- **Bus address**: Semicolon separated value, format: "*bypassproxy;\<slot id\>.\<block id\>.\<port id\>*"

  - If the proxy server has to be bypassed, specify *bypassproxy.*

  - Scope of the element: *\<slot id\>.\<block id\>.\<port id\>*. Block ID is optional.

### Configuration

No additional configuration is necessary in the element.

## Usage

### General

Displays the scope of this element: **Slot**, **Block** and **Port**. See the installation and configuration section for more information on how this is configured in the bus address of the element.

- **Logos** subpage: table with all available logo images.

### Input Services

Contains a table with all available input services that are available on the AppearTV chassis. These services can be used as input for the transcoder.

### Source

Displays the selected input service, for main and backup.

### Video

Displays the video configuration.

- **Video Preprocessing** subpage: video preprocessing configuration
- **Video Extended** subpage: exteded video configuration
- **H.264** subpage: H.264 codec configuration
- **MPEG-2** subpage: MPEG-2 codec configuration

### Audio

Displays a table with the audio encoders configuration.

### Logo

Displays the logo insertion configuration.

### Manager

Contains read/write parameters that can be used by an automation script or manager connector, to get/set the complete configuration of the transcoder in one action.

The "**Buffer Transcoder XML**" write parameter expects XML data in the same format as the corresponding read parameter.

### Web Interface

Displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

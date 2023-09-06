---
uid: Connector_help_VideoLAN_-_VLC_Media_Player_Control
---

# VideoLAN - VLC Media Player Control

VLC media player is a free and open-source, portable, cross-platform media player software and streaming media server developed by the VideoLAN project.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.0.x                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *8080*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To start communication with the VLC, enter the password on the **Configuration** page of the element.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **General** page of this connector, you can monitor the **Current Media** being played in the VLC. You can also enable or disable the looping functionality, as well as play, pause, and stop the current media.

The **Playlist** and the **Media Library** pages contain the tables with all the playlist/media library items. You can start playing the playlist by clicking the play button for any of the playlist/media library items.

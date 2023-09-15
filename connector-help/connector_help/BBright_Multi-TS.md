---
uid: Connector_help_BBright_Multi-TS
---

# BBright Multi-TS

**Multi-TS** is an easy-to-use and cost-effective compressed video playout server for professional broadcast or streaming applications such as for satellite, terrestrial, cable networks, telco IPTV operators and playout facilities. **Multi-TS** supports H.265/H.264/MPEG-2 TS files, for PIP, SD, HD, full-HD or UHD channels. Video and audio PIDs can be selected and remapped for multiple SPTS over UDP or RTP multicast streaming.

The connector polls data from the device by using its **REST API**. The connector can only be used to view information on the device, not to configure the device.

## About

The connector monitors the alarms, channels and playlists of the device, by polling the data using an **HTTP** connection.

A list of all the alarms, channels or playlists can be retrieved with a single device query. In order to get the details for each of these properties, they need to be queried one at a time.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0.2.0                     |

## Installation and configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *192.168.1.2*.
- **IP port**: The IP port of the device, by default *5000*.
- **Bus address**: If the proxy server needs to be bypassed, make sure the default value *bypassproxy* is specified.

## Usage

### General

This page contains an overview of the current status of the alarms and channels.

The information is displayed in two tables:

- **Alarm Status**
- **Channel Status**

### System

This page contains the current status of the system alarms and corresponding configuration.

The information is displayed in two tables:

- **System Alarms**
- **System Alarms Configuration**

### Network

This page contains the current status of the network alarms and corresponding configuration.

The information is displayed in two tables:

- **Network Alarms**
- **Network Alarms Configuration**

### Channels

This page contains the current status of the channels and corresponding output configuration.

The information is displayed in two tables:

- **Channel Status**
- **Channel Output Configuration**

The channel names must be unique, as having multiple channels with the same name would cause issues with the display key.

If there are multiple channels with the same name, a suffix is added, with the number of channels with the same name already identified inside parentheses.

For example, if there are 3 channels named *Channel*, when the table with the names of the channels is created, these will be renamed to *Channel*, *Channel (1)* and *Channel (2)*.

### Overview

This page displays information on the contents of the channels.

The information is displayed in a tree control. For each channel, the first level is the channel configuration, the second is the asset type (audio or subtitles), and the third is the audio or subtitle tracks existing in the channel.

### Playlists

This page displays information on the contents of the playlists.

The information is displayed in a tree control. For each playlist, the first level details the main properties, the second displays the files, the third displays the asset type (audio or subtitles), and the fourth displays the audio or subtitle tracks existing for the file.

The playlist names must be unique, as having multiple playlists with the same name would cause issues with the display key.

If there are multiple playlists with the same name, a suffix is added, with the number of playlists with the same name already identified inside parentheses.

For example, if there are 3 playlists named *Playlist*, when the table with the names of the playlists is created, these will be renamed to *Playlist*, *Playlist (1)* and *Playlist (2)*.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

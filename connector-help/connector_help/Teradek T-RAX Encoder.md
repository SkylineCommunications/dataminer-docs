---
uid: Connector_help_Teradek_T-RAX_Encoder
---

# Teradek T-RAX Encoder

The Teradek T-RAX encoder/decoder consists of a controller board with slots for encoder and decoder cards. Aside from its webpage, the controller board does not expose any northbound interface. It acts as a proxy for the encoder and decoder card API. Despite sharing the same API, each card has specific responses and is in fact an individual unit. As such, a different connector is available for the encoder and the decoder.

The Teradek T-RAX encoder card is designed for use in the T-RAX Rack Base System. It shares many essential features with the Teradek Cube 105 encoder. It has an HD-SDI input, encodes HD-SDI video in up to 1080p30/i60, and streams it out to optional T-RAX decoder cards in the T-RAX Rack Base System.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 7.3.16r32575           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

## How to Use

The device information is retrieved from an API that is based on the REST software architecture. All the API calls are done using simple HTTP GET and POST requests. Any device can communicate with a Teradek unit using any programming language that can communicate over HTTP. The API provides various methods or commands that can be performed on resources. Resources are the representation of the state of the firmware. The state is determined by configuration settings that a user can change. The Teradek API expects all data to be UTF-8- and URL-encoded. There are several different data formats that can be used interchangeably including REST-RPC, JSON, and XML-RPC.

Teradek uses a specific naming convention for the resources. The resources are grouped in a hierarchical format. Each resource is a string containing dotted group names followed by the name of the resource. For example: *VideoEncoder.Configuration.inputformat*.

Each resource has a permission attached to it, which determines if a user can read, write, or apply a resource. Some resources are read-only and some do not allow the apply command.

More information about the main data pages of the connector is mentioned below.

### General

On the **General** page of the connector, you can find an overview of parameters for the encoder.

On the **Login** subpage, you can configure the username, password, and card number to access the device.

### Stream

The **Stream** page contains the primary stream and quickview stream mode.

This page has multiple subpages with basic information about each mode that can be edited.

- **RTMP**: RTMP mode allows T-RAX encoders to stream to other video platforms, CDNs, and streaming servers that are not natively integrated. RTMP is supported by most video streaming platforms.
  You will need to obtain a URL and stream key/name from the service you choose to stream to.
- **MPEG Transport Stream**: In MPEG Transport Stream mode, the encoder card sends video via UDP or TCP to a specified unicast or multicast address.
  To enable MPEG Transport Stream, select MPEG Transport Stream as the primary stream mode, choose the streaming protocol, destination IP address, port, and other relevant settings on the subpage, and select Apply.
- **Teradek Streaming**: TDS is specifically optimized for local streaming with minimum latency between Teradek devices.
- **Wowza**
- **Zixi**
- **RTP/RTSP**: T-RAX encoder cards are configured to stream via RTSP by default. RTSP is used for local streaming to computers and Teradek decoders. The URL for a standard RTSP stream is *rtsp://ip.address:port/stream1*, where *ip.address* is T-RAX's Ethernet IP address. Port is 255x, where x corresponds to the T-RAX card slot.
- **RTP Push**
- **RTSP Announce**
- **Live Internet Streaming**: T-RAX features native integration with some of the most popular streaming platforms, i.e. Facebook, Twitch, Ustream, New Livestream, YouTube Live, and Livestream (Original).
- **Live:Air**: Live:Air is a video production suite that can receive feeds from any of T-RAX's encoder cards for real-time video mixing, switching, and even transitions.
  Once you've configured an encoder card to stream to Live:Air, you can manage it from the Live:Air app.

### Encoder

On the **Encoder** page, T-RAX allows you to control various characteristics of the network video stream. This page contains all the configurable parameters for encoder settings, rate control options, and advanced encoder options.

Keep the following things in mind when configuring the encoder settings:

- Encoder settings will vary based on the bandwidth available and the platform used.
- Always select a video bitrate that is less than 70% of the total upload bandwidth available on the internet connection (e.g. if 5 Mbps is available, set the video to 3.5 Mbps or lower).
- Some platforms (e.g. YouTube) will automatically generate lower-quality streams from a high-quality input (transcoding), so the highest possible quality can be used. If the streaming platform does not transcode the video, keep in mind that your viewers must have the available download bandwidth to view the stream.

### Input

The **Input** page consists of the video and audio input settings, some of which are configurable.

### Stats

The **Stats** page has all the monitored parameters relevant to the encoder status and codec status of the encoder.

### Time and Version

The **Time and Version** page of the connector contains the time settings, NTP server settings, and other static version information.

## Notes

Every page with at least one editable parameter has an **Apply button** at the bottom. To send an update request to the API, you must click this button. Just setting a parameter to a different value without clicking the button will not initiate an API POST call.

The update request status can be tracked both in Stream Viewer and in the information events. For example:

- "Processing MPEG Transport Stream Update Request. Url" indicates that an update request is initiated.
- "Processed MPEG Transport Stream Update Response" indicates that an update request is completed.

When the element is not connected to the device, only selected parameters have a default value. This is in alignment with the default values provided in the API documentation. For example, T-RAX encoder cards are configured to stream via RTSP by default.

When you enter values to be updated on each page, there is a rare possibility that the page gets refreshed before the Apply button is clicked.

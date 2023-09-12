---
uid: Connector_help_Digicast_DMB-8804
---

# Digicast DMB-8804

The Digicast DMB-8804 is a multichannel video encoder.

## About

This device supports audio and video collection by 4-Ch HD HDMI input. For HDMI input, each channel of HDMI input supports output 4 groups IP streams with four different resolution (up to 1080p) and four different bitrates to meet different size screen and different bandwidth condition. Each group of IP stream supports kinds of main protocols output (HLS, RTMP, HTTP, RTSP, UDP), this enable Encoder to deliver H.264 IP streams by independent IP output to various servers for IPTV & OTT application.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V8.22.1                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: \[The IP port of the destination.\]
- **Bus address**: N/A

### Initialization

No extra configuration is needed.

### Redundancy

No redundancy defined.



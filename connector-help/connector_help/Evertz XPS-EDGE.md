---
uid: Connector_help_Evertz_XPS-EDGE
---

# Evertz XPS-EDGE

XPS is Evertz' real-time high-quality and low-latency video streaming platform. It provides broadcast-quality video encoding at ultra-low latencies, supporting simultaneous 1080p50/60 HD video encoding and decoding up to four times. The XPS series supports up to 2x 2160p50/60 4K UHD video resolutions in case the 4K app is installed, containing 16x audio channels with support for different compression standards such as HEVC or H.264 over any IP network.

## Connections and IP/SDI Ports

- **SDI ports:** To connect I/O devices to be encoded/decoded.

- 4K options:

  - - Encoder/decoder (1E1D)
    - 2 encoders (2E)
    - 2 decoders (2D)

  - 3G options:

  - - Dual encoder/decoder (2E2D)
    - 4 encoders (4E)
    - 4 decoders (4D)

- **Control ports**: For system configuration and transferring, SRT, Zixi, RIST, HLS, RTMP/RTMPS streams.

- **Data ports 1-2**: Dedicated to UDP in/out.

### Version Info

| **Range**            | **Key Features**               | **Based on** | **System Impact** |
|----------------------|--------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Supports all 4K and 3G options | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                            |
|-----------|-------------------------------------------------------------------|
| 1.0.0.x   | **M:** V211B20220420-1499-F-2E2D **S:** V211B20220420-1499-F-2E2D |

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
- **IP port**: The IP port of the destination (default: *80*).

## How to use

The communication method of this connector is HTTP. It uses GET requests to retrieve or modify device information.

There are four different sections in this connector, which can be used for monitoring and remote orchestration.

- **General**: Displays **product** information
- **System**: Displays **network, management, monitoring,** and **security** information.
- **Encoder**: Displays the encoder **input**, **output**,and **control** information.
- **Decoder**: Displays the decoder **input**, **output**,and **control** information, as well as **monitor** data for errors and **notifications** for faults.

## Notes

All the encoder/decoder information is summarized on the **Encoders/Decoders Overview** page.

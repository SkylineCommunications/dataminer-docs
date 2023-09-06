---
uid: Connector_help_Grass_Valley_UHD1200
---

# Grass Valley UHD1200

Developed for Kudos Pro UHD units, this connector allows you to monitor and manage the linear motion-adaptive up/down format and frame rate conversions of such device. In this context, the connector integrates features such as the HD programming into UHDTV productions, the provision of HD simultaneous transmissions alongside UHDTV services, and the mixed usage of four quadrant square-division and pixel-interleaved UHDTV content.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.2.c.2                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The connectors features are divided over the following pages:

- **Input/Output:** Allows input sources and output destinations to be selected, with configuration for the input (SDI, UHD or SFP), UHS interface, colometry, output and 2SI mode.
- **Video Processing:** Contains settings for different types of signal processing for the signal that is being converted, as well as controls to correct video inconsistencies (contrast, saturation, etc.).
- **Convert Processing:** Contains settings to optimize the conversion of film-originated content. Film-originated content can be transported by standards supporting the original film frame rate and can be packed into interlaced standards using a rule-based method to map source frames to interlaced fields. For high-quality conversion of film-originated content, the cadence must be identified and used to adapt the interpolation process. Film mode also permits the synthesis of film cadence in the output.
- **ARC:** The ARC (Aspect Ratio Control) page allows you to specify the aspect ratio of a picture from a range of options, or to adjust the size and position of the picture manually.
- **Audio Routing:** Provides control of audio routing, where source audio (input pairs or channels) refers to audio associated with the incoming source material, which could be embedded audio, balanced AES (audio option only) or analog audio (audio option only). To select the audio source to be passed to each audio processor, select the process channel from the list of process pairs (1 to 8), and select the source audio to assign to the selected channel.
- **Audio AES and Analog:** Offers 8 bi-directional ports, each of which can be configured as either an input or an output.
- **Audio Shuffle:** Allows routing from each process pair to the output. It is possible to invert audio phase and insert tone or silence.
- **Audio Control:** Allows audio adjustment on each processing channel.
- **Genlock:** Provides control over system interaction with timing references. The Genlock locks the output video clock to the genlock source (input or reference), regardless of the video standard. If the genlock source and the video output are the same frame rate, the Genlock locks the output to the vertical phase of the genlock source, giving consistent and repeatable delay. If the video output frame rate differs from the genlock source frame rate, the output will "clock lock" to the genlock source. Clock lock ensures that the output audio 48 kHz clock remains locked to the genlock source. When attempting to pass non-PCM audio (other than Dolby-E), ensure that Genlock is enabled. If an external reference is used, it must be clock-locked to the input video.
- **Timecode:** Allows the setup and control of the unit's timecode options for VITC (Vertical Interval Timecode), LTC (Linear Timecode), and ATC (Ancillary Timecode). In the HD domain, both embedded VITC and embedded LTC are supported. In the SD domain, VITC, ATC LTC and ATC VITC are supported.
- **Metadata:** The unit can pass World System Teletext (WST) for SD and RDD-08 teletext for HD. On this page, you can enable/disable the output and specify the input and output lines.

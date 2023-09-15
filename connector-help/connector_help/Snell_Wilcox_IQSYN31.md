---
uid: Connector_help_Snell_Wilcox_IQSYN31
---

# Snell Wilcox IQSYN31

The IQSYN31 provides frame synchronization for HD-SDI at 3 Gbit/s or 1.5 Gbit/s, or SD-SDI 270 Mbit/s with 16-channel embedded audio processing.

Using an SNMP connection, the Snell Wilcox IQSYN31 protocol can retrieve, set, and monitor information regarding inputs, standards, output, genlock, video, and audio delays of this device.

## About

### Version Info

| **Range** | **Key Features**             | **Based on** | **System Impact** |
|-----------|------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version \[SLC Main\] | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**           |
|-----------|----------------------------------|
| 1.0.0.x   | Device firmware version V5.18.14 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *192.168.56.201*.
- **IP port**: The IP port of the device, e.g. *161*.

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

The element created with this connector has the following data pages:

- **General**: Displays basic information about the device and licenses, and information on default settings.
- **Misc. Logging**: Displays the system uptime and the hardware and firmware versions.
- **Audio/Video Input and Output pages**: Allows you to enable/disable input standards, and to check and change the audio pairs, video input resolutions, and audio and video configuration.
- **Genlock**: Allows you to configure the genlock adjustment for timing any SDI signal.
- **Procamps**: Contains additional video configuration settings for each channel.
- **Pattern and Caption**: These settings enable you to specify a caption, turn the caption on and off and specify and enable pattern generation. The controls are duplicated for Process 1 and Process 2.
- **Embedder pages**: Allows you to verify and change the processing for 16 channels of embedded audio present on each incoming SDI stream. The embedded audio may be passed unchanged, processed, or blanked. For each of the two processing groups (1 and 2), there are four embedder groups. Each embedder group comprises two stereo audio pairs, each of which has a left and right channel.

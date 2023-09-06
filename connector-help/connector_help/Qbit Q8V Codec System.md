---
uid: Connector_help_Qbit_Q8V_Codec_System
---

# Qbit Q8V Codec System

The **Q866 SMB Internet Radio Transcoder** is typically used by small and medium operators to include streamed web radio stations into OTT and cable networks. It converts 4 to 6 internet radio streams (Icecast/Shoutcast) into a DVB-compliant MPEG-2 transport stream. The signals are available via IP (Ethernet).

The **Qbit Q8V Codec System** connector shows status information for the device and can be used to configure the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact**                                                                                   |
|----------------------|------------------|--------------|-----------------------------------------------------------------------------------------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | Minimum required DataMiner version is **10.0.0.0 - 9118** because of SLManagedScripting C#7 syntax. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.11-vf+25b5b4d2       |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).

### Initialization

To be able to access the device, specify a correct username and password on the **General** page.

## How to use

The following pages are available:

- The **General** page contains authentication and system parameters.
- On the **Versions** page, you can find the current image and software versions.
- The **Interfaces**page shows a list of all available interfaces.
- The **Inputs** page contains a table with different types of inputs. Two types, **Web Streams** and **Transport Streams**, are supported and can be configured on the corresponding subpages.
- The **Input Selectors** page contains a table with all input selectors.
- The **Encoders** page contains two tables, one for monitoring and one for configuring encoders. An encoder must have a reference to either an input selector (Input Selectorstable) or an audio source (Inputstable).
- The **MPEG-2 TS** page contains a table with transport streams. Each transport stream can have multiple destinations and services*,* which can be managed on the **Destinations** and **Services** pages*.*
- The **File Manager** page lists the available files.

Most of the tables have a right-click menu available that offers extra functionality such as adding, editing or deleting an entry.

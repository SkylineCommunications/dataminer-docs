---
uid: Connector_help_Haivision_Makito_X_Encoder
---

# Haivision Makito X Encoder

The Haivision Makito X encoder transports secure low-latency HD video over any network at extremely low bitrates. This encoder is typically used by broadcasters and defense organizations for live, interactive, and bandwidth-constrained backhaul and distribution applications.

The Makito X encoder allows highly flexible configurations for remote installations or headends. It is available either as an ultra-compact appliance with optional internal or removable storage for dual-channel requirements or within a 1RU (6 blades) or 4RU (21 blades) chassis.

## About

### Version Info

| **Range**            | **Key Features**       | **Based on** | **System Impact** |
|----------------------|------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.       | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Polling control added. | 1.0.0.2      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.2.2-1                |
| 1.0.1.x   | 2.6.0-2                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Initialization

The device must be properly configured to allow SNMP polling. You can do this via an SSH connection, using the nmcfg utility.

A simple example for SNMPv2:

- *nmcfg community permit admin rw any*
- *nmcfg community permit public ro any*
- *service snmp restart*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### General

This page displays general information on the Makito X Encoder, such as the **Serial Number**, **Firmware Version**, **Firmware Date**, **Card and System Status, Temperature**, and **Session New ID**.

### Streams

This page contains detailed information about streams, such as **Statistics** (bitrates), **Content**, and **Programs**.

In the right-click menu, the **Add Row** option is available. Information about possible dependencies can be found in the tooltip for each parameter.

### Still Image

This page displays the list of **still images** that have been uploaded for the encoder.

### Configuration

This page contains a table listing information for each **configuration file of the system**, whether it was created by management operations or not.

There is also a **Reboot** button available, which can be used to reboot the device.

### Video

This page displays tables with video information for the **Input**, **Encoders**,and **Decoders**.

### Audio

This page displays information on the **Audio Encoders**, such as the related **statistics**. There is also a subpage available with information on the **Talkback Channels.**

### Services

This page displays the current status of the **network services**.

### Logo

This page contains an entry for each **logo file** present in the system, as well as a **logo overlay** entry for each video input.

### Snapshot

This page allows you to **take a snapshot** of the current video input and save it to either **JPEG** or **YUV** image format.

Via the **Setup** subpage, JPEG snapshots can be configured.

### Network

This page allows you to modify the network interface settings for the encoder, including **Ethernet** and **IP Address**.

Two page buttons also provide access to subpages with information about **DNS** (Domain Name Space) and **NTP** (Network Time Protocol).

### Polling Control

This page allows to define which tables the connector should retrieve from the device.

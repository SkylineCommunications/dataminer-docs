---
uid: Connector_help_Ateme_Kyrion_CM3101
---

# Ateme Kyrion CM3101

With this connector, you can monitor and configure an **Ateme Kyrion CM3101** encoder via SNMP.

## About

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial range   | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.3.0.1                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the main device, e.g. *10.11.12.13*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General Page

This page displays general information regarding both devices:

- Temperature
- System info
- Network Interface Table

### TS Overview Page

This page displays a tree view that shows the current services with their audio and video streams.

### Status Page

This page contains the table with the device messages. It is similar to the **Status** tab on the web interface.

### Input Page

This page contains the information about the video and audio input. It is similar to the **Input** tab on the web interface.

### Service Page

This page contains the information about the video, audio and data connected used by the Service. It is similar to the **Service** tab on the web interface.

### Filters Page

This page contains the information about the video and audio filters configurations. It is similar to the **Filters** tab on the web interface.

### Encoders Page

This page contains the information about the video and audio encoders. It is similar to the **Encoders** tab on the web interface.

### Muxer Page

This page contains the information about the video and audio multiplexers. It is similar to the **Muxers** tab on the web interface.

### Output Page

This page contains the information about the output targets. It is similar to the **Output** tab on the web interface.

### Licenses Page

This page contains the information about the License status of the device features. It is similar to the **Licenses** tab on the web interface.

### Web Interface Page

This page links to the device Web Interface.

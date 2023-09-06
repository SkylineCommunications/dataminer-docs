---
uid: Connector_help_Aperi_H264_Encoder
---

# Aperi H264 Encoder

The Aperi H264 Encoder is an encoder that supports up to four channels of SD, HD, 3G high-quality H.264 4:2:0/4:2:2 and an ST 2022-1/2 IP encapsulator. The encoder app is high profile and can also be configured for main and baseline profiles through the user API.

Using the **HTTP API**, this connector both collects information from the device and sets parameters on the device.

## About

### Version Info

| **Range**            | **Key Features**                                               | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                               | \-           | \-                |
| 1.0.1.x              | Streamlined all Aperi connectors.                              | \-           | \-                |
| 1.0.2.x              | Transport stream statistics cleaned up.                        | \-           | \-                |
| 1.1.0.x \[SLC Main\] | Support added for new parameters. Obsolete parameters removed. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                  |
|-----------|-------------------------------------------------------------------------|
| 1.0.0.x   | 2.0.20                                                                  |
| 1.0.1.x   | 2.0.20                                                                  |
| 1.0.2.x   | 2.0.20                                                                  |
| 1.1.0.x   | app-h264-enc-10b - 2.6.41 app-h264-enc-8b - 2.5.45 app-h264-dec - 2.3.3 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.

HTTP Settings:

- **IP Port**: The port of the connected device, by default *443*.
- **Bus Address**: The card bus address. Range: *1* - *5*. The default is *1*.

### Initialization

After element creation, specify a valid **User Name** and **Password** to start polling data from the device. To do so, go to the **Security Settings** subpage of the **General** page.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### General

This page displays the **System Information**, **Main Board Info**, **System Configuration**, **Resources Info** and **System Utilization**. It includes information about **System Time**, **System Description**, **System Location**, **System Contact**, **System Up Time** and other general parameters.

This page contains the following page buttons:

- **Security Settings**: Allows you to define the **Username** and **Password** to connect to the device. This subpage also displays the status of the connection.
- **Messanine Board Info**: Displays information about all the parameters related to the Messanine board.

### Video

This page displays all video interface error info in the **Video Input** tables.

### Audio

This page displays all channel **Embedded Audio** tables.

### SFPs

This page contains information about the installation status of SFPs in the four channels.

### IP Flows

This page allows you to configure the IP flow for each available channel. It has three subpages:

- **Flow Management**: Used to configure the main IP flow parameters.
- **MGT Statistics**: Shows the port statistics.
- **FEC Config**: Used to configure the FEC parameters.

### Ethernet

This page displays the status of the Ethernet ports 0 and 1 in the **Ethernet** table.

### Transport Stream

This page allows you to configure the transport stream of each channel. For example, you can configure the **TS Max**, **TS Padding**, **PMT**, **PCR**, etc.

The page also shows **TS Rate** and **Video Rate** information.

### H264 Config

This page allows you to configure the H264 parameters of each channel. For example, you can configure **Profile**, **Level**, **Chroma**, etc.

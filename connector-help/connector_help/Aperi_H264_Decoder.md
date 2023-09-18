---
uid: Connector_help_Aperi_H264_Decoder
---

# Aperi H264 Decoder

The Aperi H264 Decoder supports up to three channels of SD, HD and 3G. The app de-encapsulates a stream from ST 2022-1/2 IP. The decoder app automatically senses and decodes to either 4:2:0 or 4:2:2.

## About

Using the **HTTP API**, this connector both collects information from the device and sets parameters on the device.

### Version Info

| **Range**         | **Description**                                      | **DCF Integration** | **Cassandra Compliant** |
|--------------------------|------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x                  | Initial version.                                     | No                  | Yes                     |
| 1.0.1.x                  | Streamlined all Aperi connectors.                       | No                  | Yes                     |
| 1.0.2.x                  | Transport table overhauled to show correct bitrates. | No                  | Yes                     |
| 1.0.3.x **\[SLC Main\]** | Extra parameters added to the IP flow table.         | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.0.27                      |
| 1.0.1.x          | 2.0.27                      |
| 1.0.2.x          | 2.0.27                      |
| 1.0.3.x          | 2.0.27                      |

## Installation and configuration

### Creation

#### HTTP Main Connection

This device uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.

HTTP Settings:

- **IP Port**: The port of the connected device, by default *443*.
- **Bus Address**: The card bus address. Range: *1 - 5*. The default is *1*.

### Configuration

After element creation, specify a valid **User Name** and **Password** to start polling data from the device. To do so, go to the **Security Settings** subpage of the **General** page.

## Usage

### General Page

This page displays the **System Information**, **Main Board Info**, **System Configuration**, **Resources Info** and **System Utilization**. It includes information about **System Time**, **System Description**, **System Location**, **System Contact**, **System Up Time** and other general parameters.

This page contains the following page buttons:

- **Security Settings**: Allows you to define the **Username** and **Password** to connect to the device. This subpage also displays the status of the connection.
- **Messanine Board Info**: Displays information about all the parameters related to the Messanine board.

### Video

This page displays all video interface error info in the **Video Output** tables.

### Audio

This page displays all channel **Embedded Audio** tables.

### IP Flows

On this page, you can configure the IP flow for each available channel.

The following subpages are available:

- **Flow Management**: Allows you to configure the main IP flow parameters.
- **MGT Statistics**: Displays the port statistics.
- **FEC Config**: Allows you to configure the FEC parameters.
- **IP RX Status:** Displays the number of dropped packets and recovered packets of each channel.
- **IP Filter**: Allows you to configure what the IP receiver should filter on.

### Transport Stream

This page allows you to configure the transport stream of each channel. For example, you can configure the **TS Max**, **TS Padding**, **PMT**, **PCR**, etc.

The page shows **TS Rate** and **Video Rate** information.

### H264 Config

This page contains all relevant parameters related to the decoder, such as the encoding **Profile**, the **Aspect Ratio** and the **Bitrate**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

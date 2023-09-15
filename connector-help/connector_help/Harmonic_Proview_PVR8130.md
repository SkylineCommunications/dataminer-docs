---
uid: Connector_help_Harmonic_Proview_PVR8130
---

# Harmonic Proview PVR8130

The **Harmonic Proview PVR8130** is an advanced Integrated Receiver Decoder (IRD) platform that optimizes primary distribution of video content over satellite or IP delivery networks.

## About

The connector is used to control and monitor the Harmonic Proview PVR8000.

### Version Info

| **Range**     | **Description**                                                  | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                 | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Combine DVB-S2 port receiver and carrier parameters into a table | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x 1.0.1.x  | Unknown                     |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device (default: *bypassproxy*).

## Usage

### Inputs page

This page displays the primary and backup input information. This page also contains the **DVB-S/S2** settings and the DVB-S/S2 Ports Table, the **GbE Socket Input** **Table**, the **LNB Port Table** and the **ASI** **Table**.

### Services page

This page provides an overview of all the services. It also contains list of the current programs in the program table.

The following page buttons are available:

- **Video**: Displays parameters related to the video PID and decoding.
- **Audio**: Displays parameters related to audio 1 and audio 2 PID and decoding.
- **PCR**: Displays the PCR-related parameters.
- **DPI**: Displays the DPI PID-related parameters.
- **OSD**: Displays parameters related to OSD positioning and SD and HD outputs.
- **PIDS**: Displays information about all the PIDS.

### VBI page

This page contains multiple parameters for the **VBI**. It also includes several page buttons that lead to parameters related to **VBI AMOL, VBI CC, TV Guide, Teletext**, etc.

### Decryption page

This page displays information about the **CAM** and **BISS** properties and the associated programs.

### Output page

This page provides an overview of the **Video Audio Outputs and TS Properties**.

The page also contains a page button that provides access to the **Embedded Audio** table and **Gbe Sockets Outputs** table.

### General

This page allows you to configure the **HTTP Login**, i.e. the username and password that will be used in HTTP requests. Please note that in order to use the **HTTP API**, these parameters must be filled in.

This page also contains the general device information and the **Active alarms** and **Alarm Log** table.

### Web Interface page

This page allows the user to access the original web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

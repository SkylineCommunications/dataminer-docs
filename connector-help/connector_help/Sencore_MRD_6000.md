---
uid: Connector_help_Sencore_MRD_6000
---

# Sencore MRD 6000

The MRD 6000 decodes and outputs 4K/UHD video with dual audio and includes core features required in professional video delivery networks such as MPEG/IP I/O, DVB-S/S2/S2X satellite inputs, QAM/VSB RF receiver, DVB-T/T2, C/C2, ISDB-T inputs, BISS descrambling, and dual DVB-CI CAM slot options.

This connector allows you to monitor and configure several aspects of the device: the inputs, the descrambling, the service or PIDs selection for decoding, and the outputs.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x              | Initial version  | \-           | \-                |
| 1.1.0.x \[SLC Main\] | New firmware     | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.1.0                  |
| 1.1.0.x   | 4.2.0.RC4              |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the pages listed below.

### General

On this page, you can find general information about the device, including **License Options**, **Sensor** information, and **Power Supply** information.

### Input

On this page, the available input sources are listed in the **TS Input Source Table**.

The page also displays the **Input Table**, which contains the selected **Primary** and **Backup Input Source**. To configure these two parameters, you must enter the **ID** of the input sources in the **Primary Source** and **Backup Source columns** of the table. (The **ID** is available in the **TS Input Source Table**). Also in the Input Table, you can make the device switch between the **Backup** or **Primary** input by pressing the **Switch** button.

### Conditional Access

This page allows you to view the status and configure the **BISS** descrambling engine and the **CAM**.

### Decoding

On the decoding page, you can configure the PIDs or service of the MRD 6000 decoding.

### Baseband Processing Video

This page contains the **Video Output Table**, where you can for example configure the format of the video. To do so, change the **Format Mode** to *Manual* and then enter the **ID** of the format you want in the **Manual Format** column. The **IDs** of the formats are listed in the **Format Table** on this same page.

It is also possible to configure the **Aspect Ratio** and **Overlay** here.

### Baseband Processing Audio

This page displays the **Audio Service Table**, where you can for example configure the **Operating Mode**, **Processing Mode**, and **Downmix** of the audio.

### Baseband Output Video

On this page, you can configure the **HD-SDI**, **SD-SDI**, **UHS-SDI**, and **Composite** output formats of the MRD 6000.

Note that the **composite** video output is only active if the **output video format** is **SD** (720x480i, 720x576i). For the other selected formats, there is no output from the composite video BNC jack. The video format selection determines which of the SDI output jacks is actively outputting.

### Baseband Output Audio

On this page, you can configure the SDI, AES, and analog outputs of the MRD 6000.

### Output

This page contains the **TS Output Source Table**, which lists the available outputs. The state of each output can be configured in the table.

### MPEG/IP

On this page, you can configure relevant information about the **MPEG/IP** input and output.

### DVB-S2

On this page, you can configure settings related to the **DVB-S2** input.

### ASI

On this page, you can configure settings related to the **ASI** input and output.

### VSB

On this page, you can configure settings related to the **VSB** input.

### Turbo PSK

On this page, you can configure settings related to the **Turbo PSK** input.

### DVB-T2 and ISDB-T

On this page and its subpages, you can configure settings related to the **DVB-T/DVB-T2/DVB-C/DVB-C2/ISDB-T** inputs.

### DVB-S2X

On this page, you can configure settings related to the **DVB-S2X** input.

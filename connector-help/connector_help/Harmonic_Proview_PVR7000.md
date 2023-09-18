---
uid: Connector_help_Harmonic_Proview_PVR7000
---

# Harmonic Proview PVR7000

The **Harmonic Proview PVR7000** is a single-rack-unit scalable receiver, DVB descrambler, multi-format video decoder/transcoder, and MPEG stream processor.

This connector can be used to control and monitor the Harmonic Proview PVR7000.

## About

### Version info

| **Range**            | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                           | **DCF Integration** | **Cassandra Compliant** |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version. Uses SNMP to retrieve alarm and input information.                                                                                                                                                                                                                                                                                                                                                                                                       | No                  | No                      |
| 1.1.0.x              | Based on 1.0.0.5. New MIB and HTTP connection.                                                                                                                                                                                                                                                                                                                                                                                                                            | No                  | Yes                     |
| 2.0.0.x              | Uses Telnet to monitor all inputs and settings.                                                                                                                                                                                                                                                                                                                                                                                                                           | No                  | No                      |
| 3.0.0.x              | v2.0.0.x. SNMP is used for the alarm information.                                                                                                                                                                                                                                                                                                                                                                                                                         | No                  | No                      |
| 4.0.0.x              | SSH interface (requires firmware v3.x.x.x; modulation parameters available from firmware v3.3.x.x).                                                                                                                                                                                                                                                                                                                                                                       | No                  | No                      |
| 4.0.1.x              | DCF Implemented.                                                                                                                                                                                                                                                                                                                                                                                                                                                          | Yes                 | Yes                     |
| 4.1.0.x              | HTTP API (requires firmware v4.x.x.x).                                                                                                                                                                                                                                                                                                                                                                                                                                    | No                  | No                      |
| 4.2.0.x              | \- Serial connection replaced by HTTP (requires firmware v4.x.x.x). - Port changes due to device firmware: manual changes needed to element configuration. - Internal methods to compose the display keys (used in template filters and Alarm Console) changed, causing the loss of existing trend and alarm history, but increasing efficiency and enabling support for Cassandra. - Support added for the video and audio decoding information available on the device. | No                  | Yes                     |
| 4.2.1.x              | Supports HTTP only. Alarm information is no longer retrieved via SNMP, but instead via HTTP.                                                                                                                                                                                                                                                                                                                                                                              | No                  | Yes                     |
| 4.2.2.x              | Naming value change for table GbeSocketOutTable (PID 5500).                                                                                                                                                                                                                                                                                                                                                                                                               | No                  | Yes                     |
| 4.2.3.x \[SLC Main\] | DCF connections added.                                                                                                                                                                                                                                                                                                                                                                                                                                                    | Yes                 | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   |                        |
| 1.1.0.x   | 4.3.3.0.52             |
| 2.0.0.x   |                        |
| 3.0.0.x   | v2.0.0.x               |
| 4.0.0.x   | v3.x.x.x               |
| 4.0.1.x   | v3.x.x.x               |
| 4.1.0.x   | v4.x.x.x               |
| 4.2.0.x   | v4.x.x.x.x             |
| 4.2.1.x   | v4.x.x.x.x             |
| 4.2.2.x   | v4.x.x.x.x             |
| 4.2.3.x   | v4.x.x.x.x             |

## Configuration

### Connections

This connector uses an **SNMP** and/or **serial** and/or **HTTP** connection, depending on the version. It requires the following input during element creation:

#### SNMP connection (versions up to 4.2.0.x)

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: the community string in order to set to the device. The default value is *private*.

#### Serial connection (no longer available from version 4.2.0.x onwards)

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: 23 (telnet) or 22 (SSH)

#### HTTP connection (available from version 4.1.0.1 onwards)

HTTP CONNECTION:

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13.*
- **Port number:** The port of the connected device, by default *80*.
- **Bus address:** If the proxy server has to be bypassed, by default *bypassproxy*.

## Usage

### General page

This page displays general information about the device. It also contains the **Login Status** and the **Login** page button. To start the communication, click the **Login** page button, fill in the username and password to access the device and click the **Login** button. The **Login Status** will then show if the login succeeded or failed.

With the **Enable Multiplex Retrieval** toggle button, you can disable/enable the retrieval of multiplex data.

The **Device Info** page button shows all the connected hardware. Depending on the connected hardware, different information is retrieved.

Via the page button **HTTP Login**, you can define the username and password that will be used in HTTP requests. Please note that in order to use the **HTTP API**, these parameters must be filled in.

### Alarm page

This page displays a table with the **active alarms** on the device. In addition, a toggle button at the top of the page allows you to enable or disable the **Alarm Polling (SNMP)**. However, note that SNMP alarm polling is no longer used in the connector from version 4.2.1.x onwards.

### Physical Inputs page (from version 4.2.0.x onwards)

This page displays the **DVB-S/S2 Status Table**, with the reception status of the DVB-S/S2 input port properties, the **GbE Socket In** **Table**, and the **ASI Ports Input** **Table**. You can access the configuration table for the DVB-S/S2 via a page button.

### Input Transport Streams page (from version 4.2.0.x onwards)

This page contains the **Input Transport Stream Table** and **Input TS Services Table**.

### Output Transport Streams page (from version 4.2.0.x onwards)

This page is similar to the Input Transport Streams page, except that it shows the **Output Transport Streams Tables**.

### Physical Outputs page (from version 4.2.0.x onwards)

Similar to the Physical Inputs page, this page contains the **GbE Socket Out Table** and **ASI Ports Output Table**.

### Demodulator Status and Demodulator Config page (prior to version 4.2.0.x)

With the **Demodulator Port Selection**, you can select a port to display all the relevant info on the same page. The **Demodulator Status/Config Table** buttons display information about all the available ports.

### CAM page (prior to version 4.2.0.x)

This page displays information about the **CAM** and **BISS** properties and the associated programs. In the **CAM Table**, the **Reboot CAM** column allows you to reboot a specific CAM module**.**

### CAM page (from version 4.2.0.x onwards)

This page displays information about the **CAM BISS** parameters in two separate tables. It also contains the **Create BissKey** page button.

### Multiplex page

This page displays information on the **Multiplex** input ports and their **Services**.

Prior to version 4.2.0.x, at the bottom of the page, you can find the **Normalize Multiplex** and **Normalize PIDs** buttons. These will normalize the values for the respective tables. The normalized values then become available via the page button **Normalized Values**.

### DSR page (prior to version 4.2.0.x)

This page displays information about the **DSR** configuration.

### XC page (prior to version 4.2.0.x)

This page contains the tables **Current Program XC**, **Current Program XC** **Additional Info** and **Current TS XC**, which shows detailed information regarding the XC programs that are running on the device.

### Decoder page

This page contains the **Decoding Services** table and **Decoder Settings** table. It also contains the page buttons **Descramble Program** and **Decode Program**.

From Version 4.2.1.2 onwards, it also contains the **Selected Service ID** and **Service Hunt** parameters.

### Video page (prior to version 4.2.0.x)

On this page, you can view and configure parameters related to the **Video** decoder. The page also contains the page buttons **Advanced** and **More**, which display more advanced video features.

### Video page (from version 4.2.0.x onwards)

On this page, you can view and configure parameters related to the video decoder:

- **Video PID Selection Table**: This table contains information related to the video program ID selection, including **Mode**, **Input PID** and **Cfg Input PID**.
- **Video Settings page button**: Displays all configuration and status parameters related to the video decoding, including **HD Resolution/Frame Rate**, **Aspect Ratio** and **Video Display Format**.

### Audio1 page (prior to version 4.2.0.x)

On this page, you can view and configure parameters related to the **Audio 1** decoder. For more advanced information, click the page button **Advanced Audio 1**.

### Audio2 page (prior to version 4.2.0.x)

On this page, you can view and configure parameters related to the **Audio 2** decoder. For more advanced information, click the page button **Advanced Audio 2**.

### Audio page (version 4.2.0.x)

On this page, you can view and configure parameters related to the audio decoder. This includes the **Audio PID Selection Table** and **Audio Decoder Configuration Table**. Via a page button, you can access the **Embedded Audio Table**.

### Ethernet Input page (prior to version 4.2.0.x)

This page displays information regarding **Ethernet Input Sockets** settings.

### Output page (prior to version 4.2.0.x)

This page provides an overview of the **Physical** and **Socket Outputs** in the **Interfaces** **Table** and **Ethernet Output Sockets Table**, respectively.

### PCR page (version 4.2.0.x)

On this page, you can view and configure parameters related to the PCR decoder, such as **Audio-Video Sync**, **Generator Lock Input**, **Frame Sync Horizontal Delay**, etc.

### VBI page (version 4.2.0.x)

This page contains multiple parameters related to the VBI. There are also several page buttons, including **VBI AMOL**, **VBI CC**, **TV Guide**, **Teletext**, etc.

### DPI page (version 4.2.0.x)

This page contains multiple parameters related to the DPI, such as **DPI Pre Roll**, **DPI AS Index**, etc.

### OSD page (version 4.2.0.x)

This page contains parameters related to the OSD decoder, such as **Subs PID Selection Mode**, **OSD DVB Subtitles Mode**, etc. Via page buttons, you can access more information about DVB and TTX.

### Web Interface page

This page provides access to the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

In version 4.0.1.x, a timeout issue can occur where the device responses are not fully received. To solve this, edit the element and change the timeout of a single command (ms) to a higher value, e.g. 30000 instead of the typical 10000.

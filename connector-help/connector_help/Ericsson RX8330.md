---
uid: Connector_help_Ericsson_RX8330
---

# Ericsson RX8330

This is an SNMP connector that shows the status of the different parameters of an Ericsson RX8330 IRD (Integrated Receiver Decoder).

The Ericsson RX8330 is a very versatile piece of equipment. It comes in many different configurations, with input options varying between satellite and ASI, and output options including ASI, satellite and IP.

## About

### Version Info

| **Range** | **Key Features**                                                                | **Based on** | **System Impact**                                               |
|-----------|---------------------------------------------------------------------------------|--------------|-----------------------------------------------------------------|
| 1.0.0.x   | Initial version (SNMP only).                                                    | \-           | \-                                                              |
| 1.0.1.x   | Evolution from the 1.0.0.x range (extra parameters polled).                     | 1.0.0.x      | \-                                                              |
| 2.0.0.x   | Reworked version of the 1.0.1.x range, compatible with later firmware versions. | 1.0.1.x      | \-                                                              |
| 2.0.1.x   | Added XPO interface.                                                            | \-           | \-                                                              |
| 2.0.2.x   | Changed naming, added SNMP traps.                                               | \-           | Elements need to be recreated when you upgrade to this version. |
| 2.0.3.x   | Implemented DCF.                                                                | \-           | \-                                                              |
| 2.0.4.x   | Changed index of Service Control Table.                                         | \-           | \-                                                              |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Under 5.0.0            |
| 1.0.1.x   | Under 5.0.0            |
| 2.0.0.x   | 5.0.0 onwards          |
| 2.0.1.x   | 5.0.0 onwards          |
| 2.0.2.x   | 5.0.0 onwards          |
| 2.0.3.x   | 5.0.0 onwards          |
| 2.0.4.x   | 5.0.0 onwards          |

Version Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | --                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.2.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.3.x   | Yes                 | Yes                     | \-                    | \-                      |
| 2.0.4.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not needed.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

#### HTTP connection

Ranges 2.0.1.x and 2.0.2.x use a second, TCP/IP connection. This requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Web Interface

In case the web interface requires a username and password, these should be entered on the **Device Info** \> **Credentials** page.

The web interface is only accessible when the client machine has network access to the product

## Usage

### Device Info

This page contains general status information, such as the **Video Status**, the **IP Address** and the **Audio 1 Status**. There is a button that allows you to **reboot the unit**.

The page contains page buttons to the following subpages:

- **Environment**: Contains information about the temperature and fans, with parameters such as **Temperature** and **Fan Speed**.
- **Network Settings**: Contains information about the **IP** configuration, such as the **Subnet** or the **Gateway**.
- **Build**: Contains information about the **software** and **hardware** version, including the **SW Version** and **HW Version**.
- **Credentials**: Allows you to enter a **Username** and **Password** for the HTTP Connection.

### Current Alarms

This page contains a table with the **Current Alarms** and their status. It contains columns such as **Port**, **Alarm Text** and **Severity Level**.

### Alarms Config

On this page, you can configure how traps will be removed from the Current Alarms table, using parameters such as **Automatic Removal of Cleared Alarms**, **Maximum Number of Alarms** and **Alarms** **Clean Up Method**.

### Alarm Settings

This page defines which errors will cause an alarm, and for some of them a threshold value can be set. It contains parameters such as **C/N margin (Min Value)**, **No Primary Input Lock**, and **Audio 2 Not Running**.

This page only exists in connector ranges 2.0.1.x and 2.0.2.x.

### Customization

This page shows the **Licenses** installed for this device, listing each **Feature** and **License State**. It also contains additional information such as the **Serial Number**.

### CA

This page contains all parameters for use with the Conditional Access Module or CA descrambling in software, including **Over Air Control**, **Over Air Message** and **CI Module Status**.

### Input

This page contains information about the input parameters and allows you to set several parameters values. It includes among others the parameters **Card Type, Input Source, Primary Input**, etc.

The page contains page buttons to the following subpages:

- **Sat Input**: Displays parameters related to **Satellite input**, such as **Selected Input Channel**, **Signal Status**, **Signal Strength, C/N** and **C/N Margin.**
- **Configuration**: Allows you to set the parameters **LNB Frequency**, **Satellite Frequency**, **L-Band Frequency**, **Symbol Rate**, **Modulation Type**, **Roll Off**, **Spectrum Sense**, **Search Range**, **LNB Power Output**, **LNB Power Level** and **LNB 22Khz**.

### Service Plus

This page contains a table with **Service Control** parameters, where several parameter values can be set. This includes among others the parameters **Encryption**, **Decrypt**, **Decode**, **Remap**, etc.

This page is only available from version 2.0.1.x onwards.

### Decode

This page contains parameters related to the decoding of the TS, including **Service**, **PCR**, **PCR Status**, **Color Type**, etc.

The page contains page buttons to the following subpages:

- **Splice**: Displays splice-related parameters, such as **Current Splice**, **User PID**, **Status** and **Event ID**.
- **Subtitles**: Displays the status of subtitles and allows you to configure several parameters. The parameters on this subpage include **Current Subtitles**, **User Subtitles PID**, **Subtitle State**, **Subtitle Status**, **Subtitle Language**, **Subtitles Control**, etc.
- **Teletext**: Displays the Teletext status and allows you to configure several related parameters. The parameters on this subpage include **Current Teletext**, **User Teletext PID**, **Stream**, etc.
- **Advanced**: Displays several parameters such as **Service Hunt**, **Service Drop** and **Major Minor Tracking**.
- **Advanced Video**: Displays parameters related to video, such as **Test Pattern Type**, **User Video PID**, **Composite 625 Modes**, **VGA Embedded Sync**, etc.
- **Decode Audio**: Only available from version 2.0.1x onwards. Displays parameters related to audio, such as **Audio PID**, **Audio Display**, **Primary Language**, etc.

### Service Split

This page contains the **Service Split Table**, which contains both information and configurable settings for service splitting, including **Service ID**, **Service Name**, **Ethernet Port \#1**, **Bitrate Type**, etc.

This page is only available from version 2.0.1.x onwards.

### Output

This page contains all parameters for the output, such as **TS Output**, **Output 1**, **IP Output Ports Configuration Table**, **Bitrate Type**, **Service Splitting**, etc.

### Load/Save

On this page, you can import and export several configuration parameters of the device, such as **presets** and **general configuration**.

### Web Interface

This page contains a link to the webpage of the actual device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

**When the Input Source, Primary Input or Secondary Input is changed, a wait time of 1.5 seconds is implemented**, to ensure that the related parameters are up to date on the device.

Because of the versatility of the equipment, not all parameters will be filled in. If, for instance, your device is only IP-based, the Sat options will not be filled in.

---
uid: Connector_help_Adtec_EN_Manager
---

# Adtec EN Manager

The Adtec EN Manager is an MPEG 4 DSNG Encoder. This connector can be used to monitor and control this device.

## About

The base unit comes with Mpeg4 4:2:0 SD encoding, and optional high definition and Mpeg4 4:2:2. The standard audio encoder includes 4 stereo pairs (8 mono) of MPEG 1 layer 2 with an optional upper 4 stereo pairs (8 stereo pairs or 16 mono channels), 2 Dolby E Passthru via AES or SDI embedded. Standard VBI support includes captions, Teletext, AFD, and VITC (608 waveform, H/VANC for 708, OP47, SMPTE 2016/2031 with built-in VBI analyzer). BISS 1/E encryption included. Transport via 3X mirrored ASI and GigE with SMPTE-2022 FEC. Hardware configuration I/O includes composite, SDI, and SFP slot for SFP optical modules, and analog, AES and SDI audio inputs. Includes redundant AC power supplies.

This connector uses **SNMP** to retrieve the entity IDs of the different components of the device.

### Version Info

| **Range**           | **Description**                                                                                                                  | **DCF Integration** | **Cassandra Compliant** |
|----------------------------|----------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\]       | Initial version.                                                                                                                 | No                  | Yes                     |
| 1.0.1.x (based on 1.0.0.3) | Added support for profiles by adding a new serial connection (Telnet). For more information, refer to the "Notes" section below. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### Serial Connection

This connector uses a serial connection to set/retrieve profile information and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.

## Usage

### General

This page contains general information about the device, such as the **name**, **type** and **version**. You can also find the **Encoder Transport Table**, **Power Supply Table** and **Fan Table** on this page.

### Encoder

This page displays product information such as the **Type**, **Name** and **Version**. It also displays the **Power Supplies Status**, the **Fan Table**, and the **Encoder Temperature**, **State**, **Frames**, **Horizontal** and **Vertical Sizes**, **Bit Rate** and **Encoding Time.**

### Service

This page contains the **IP Transport Table**, the **Audio Color Bars Tone Table**, and the **Bars Tones Status**, **Type** and **Status OSD**. It also displays the **NIT Services Tables** as standalone parameters.

### Video

This page contains parameters related to the **Video Encoder**, such as **Video Input**, **Video Detected**, **SDI Video Mode**, **Chromatype**, **Video Auto Fill**, **Video Bit Rate**, **Codec Mode**, **Source Contrast**, **Brightness**, etc.

### Audio

This page displays the **Audio Inputs Table**, **Global Audio Sampling Frequency**, **SDI Clock Source**, **ECC** and **3G-SDI Level B Source**. Via page buttons, you can also access **Dolby 1** and **2** parameters.

### VBI

This page contains the **Teletext Processing Mode**, **Lin En** and **Language Description**. It also shows the **Teletext Descriptor 1** and **2 Type**, **Magazine Number** and **Page Number**, and the **Encoder Temperature**, **VBI Source** and **Closed Caption.**

### PID

This page displays the **PID PMT**, **Video**, **Transport Stream ID**, **PCR**, **Teletext**, **AMOL**, **VITC**, **Splice**, **VITC Mode** and **Splice PID Active**. It also displays some of these parameters as hex numbers.

### CAS

This page contains the **BISS Mode**, **One Key CSW**, **E Key ESW**, **E Key Injected ID One**, and **E Key Injected ID Two.**

### Profiles (Range 1.0.1.x)

This page contains the **Profiles Table**, which lists all the available profiles along with a button to load each profile.

The **Profiles Last Update** parameter indicates when the Profiles table was last updated. To refresh the table, click the **Refresh Profiles** button.

### Telnet Credentials (Range 1.0.1.x)

On this page, you can specify the credentials for the Telnet communication in the **Username** and **Password** fields.

### Embedded Web Server

This page displays the web interface of the device. Note that the client machine has to be able to access the HTTP server of the device, as otherwise it will not be possible to open the web interface.

## Notes

When you move to range 1.0.1.x, existing elements need to be recreated before the new connection will be used. This is because connection changes (adding or removing a connection) do not take effect when you upgrade an already existing element to the new protocol version. The connections are only created when the element is created.

**Actions to be taken**: DMS element reconfiguration.

**Advised Method**: Bulk configuration can be performed using export/import functionality.

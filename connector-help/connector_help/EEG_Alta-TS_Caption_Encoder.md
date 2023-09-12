---
uid: Connector_help_EEG_Alta-TS_Caption_Encoder
---

# EEG Alta-TS Caption Encoder

This driver is designed to monitor the EEG Alta-TS for use with MPEG Transport Streams as the input and output format. The iCap Alta software is packaged on a virtual machine for placement inside a customer video facility. The virtual machine "guest" operating system is 64-bit Debian 8 Linux. The VM can be hosted on VirtualBox, Cisco, or Microsoft HyperV controllers. The default distribution format is an "OVA" file, though alternative disk image formats can often be provided on request. Once the iCap Alta virtual machine is running and reachable on a local network, all interaction with the software can be performed over HTTP on the network, as a web service or in a browser.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The **General** page of this driver contains the username and password to access the device.

The **Instance Settings** page contains a table with basic information about the existing instances, as well as logs for every instance. This page has multiple subpages, which can among others be used to add new instances or edit existing ones:

- **New Instance Settings**: Allows you to create a new instance with the necessary basic information.

- **Stream Settings**: Allows you to edit the stream settings for existing instances.

- **Name**: This is the name that will be displayed in the instance list for this channel of settings.

  - **Primary**: This parameter indicates the source for the IP video input stream. The setting can have the following values:

  - - *3000*: Listen for RTP unicast on port 3000. The sending device will need to send to the virtual machine IP address on port 3000.
    - *udp://0.0.0.0:7000*: Listen for UDP unicasts on port 7000, from any source, headed to the VM interface.
    - *udp://239.120.200.101:5000*: Listen for UDP multicast on multicast address 239.120.200.101, on port 5000. The multicast request will be registered with your router, which will then forward multicasts on this address to the VM interface.

  - **Source:** This parameter is optional and permits an additional input stream, which will be used for caption bridging (in caption bridging, caption data from the "Source" stream will be transferred to the "Primary" stream). The same address formats permitted for the primary stream are permitted for the source stream.

  - **Output:** This parameter sets the destination address and port for the output video stream. The destination can be either unicast or multicast. All output data is sent in RTP format.

  - **iCap Reference:** This parameter is optional and permits an additional input stream, which will be used as the audio source to a remote transcriber connecting through iCap. The stream may be audio-only, or may also contain a video elementary stream, which will be used to send reduced frame rate picture reference data. The same address formats permitted for the primary stream are permitted for the iCap reference stream.

  - **Multicast Interface:** This parameter is optional, and is recommended only for setups where the virtual machine is connected to multiple NIC interfaces and networks, and where IP multicast is used for the input/output streams. In these cases, you should specify the IP address of one of the interfaces that sits on the network where all multicast input and output traffic will be directed. (It is not currently possible with the Alta VM to subscribe to different multicasts on multiple interfaces within the same instance.)

- **iCap Settings**: Allows you to edit the iCap settings for existing instances.

- **iCap Company, Username, and Password:** iCap account information will be provided to you by EEG with your purchase or demo, or will be accessible from your company's admin account at [https://www.eegicap.com](https://www.eegicap.com/). Each iCap account has a company namespace, a username and a password. This account will be used to allow unique identification of your stream by your contracted real-time captioner over iCap, so you must use a different username for each simultaneously operating Alta encoder instance. You do not need an iCap account to perform certain non-cloud functions such as caption bridging between input sources or SCTE-35 cue insertion.
  - **iCap Reference PIDs:** When connected to iCap, the Alta instance will send an audio reference signal for transcription to authorized captioners connected across iCap. Separate audio programs can be transmitted for up to 6 languages of transcription simultaneously. The Audio PID field can be used to list PIDs from the input stream to be sent over iCap. If you list multiple PIDs, they will be associated with numbered language services on iCap in the order they are specified. If this field is left blank, the Alta instance will send audio only for one language, and will auto-detect the first listed audio PID in your transport stream. Each Alta instance can send only one video reference program to captioners. If more than one video PID is present in your stream, you can use the Video PID field to specify which one is the source of the feedback.

- **SCTE-35 Settings**: Allows you to edit the SCTE-35 settings for existing instances.

- **SCTE-104 Command Listen Address:** This parameter is optional and can be used to open a local port on the VM to accept SCTE-104 commands from an external automation controller, which will be used to generate SCTE-35 splicing and segmentation data in this instance's output stream. The parameter can be a port number only in a VM with a single network interface, or should include a local IP address and a port number in a multi-homed configuration. The default port specified for communication in the SCTE-104 standard is 5167, however please note that if you are running multiple Alta instances on a single VM, you must have a different IP address/port number combination for each instance that accepts SCTE-104 commands. When this parameter is specified, SCTE-35 data will be announced in the output stream PMT on a default PID of 0x1f2. Splices will be injected based on the SCTE-104 commands received from the Automation System over the specified port. SCTE-104 command receipt will be logged in the system log as well.
  - **SCTE-35 PIDs:** Up to eight PIDs may be allocated for SCTE-35 data from the Alta instance. If multiple PIDs are specified, the SCTE-104 controller uses the DPI_PID_index field in the incoming SCTE-104 messages to direct Alta which PID each message is for. Do not specify a PID for SCTE-35 service that may already contain upstream data of any type.

- **Telnet Settings**: Allows you to edit the Telnet settings for existing instances.

- The Telnet Settings menu provides functionality to clone "CTRL+A" style caption data from the iCap connection over to a legacy SDI closed captioning encoder or other similar devices/systems. The IP address and port number of the receiving device must be provided, and if the receiving device requires a username and password to open a connection, fill in these fields as well. This is the sole output mode of the "Alta Bridge" license option.

- **Other Settings:** Allows you to edit the following other settings for existing instances:

- **warnlevel:** This parameter sets the verbosity of logging for the Alta instance. We recommend the "0" setting when troubleshooting; otherwise, leave the parameter blank. Once each setting is configured and the Alta instance has started up, you should begin to see an output stream arriving at the destination that matches the "primary" input stream.
  - **Caption Output Format:** This setting controls the format used to write captioning data into the output transport stream. Alta supports ATSC CEA-708 in MPEG-2 or H264, SMPTE RDD-11 CEA-708, DVB Text (teletext) or DVB Subtitles (bitmap). Note that the ASTC user data setting is not compatible with the Alta "low latency mode", and requires a processing delay of approximately one complete video GOP.
  - **DVB Text Config:** Use only with the DVB Text Caption Output format. Specifies how many languages of DVB text data to output, and provides a language identifier and Teletext magazine and page for each.
  - **DVB Bitmap Config:** Use only with the DVB Bitmap Caption Output format. Specifies how many languages of DVB subtitle data to output, and provides a language identifier and page identifier for each.
  - **Transport Rate:** This parameter is optional and can be used to constrain a fixed transport rate on the output stream. If the parameter is not specified or set to 0, the input transport rate will be auto-detected from the stream's PCR data and bitrate, and will be replicated on the output. If a specific transport rate is desired, it is often preferable to use this setting to avoid the possibility that temporary data loss/corruption on the input could lead to a change of transport rate on the output as well. This feature can also be used to increase the output transport rate above the input rate to accommodate additional data insertion by Alta. This could be necessary if the input transport stream has insufficient null packets to replace with timely insertion of captions, subtitles, or SCTE-35 trigger data. A fixed transport rate separate from the input rate cannot be used in "Low Latency Mode".
  - **Low Latency Mode:** This check box can be used to disable detailed de-multiplexing of the transport stream passing from the master input to the master output. Certain Alta product features such as ATSC format captioning in user data or SEI require data insertion in video picture display order, and therefore an additional buffer delay of approximately one Group of Pictures (GoP) is introduced. In low latency mode, this additional delay passing through Alta is not incurred. SCTE-35 injection can still be used, along with captioning in formats that do not embed in the video elementary stream, such as SMPTE-2038 or DVB Subtitles. For full control of input-to-output latency in Low Latency mode, also see "UDP Buffer Size" in "Other Settings".
  - **UDP Buffer Size:** This parameter is optional and allows finer control over the output buffer size used between Alta's internal transport stream processing and the network output buffer. Higher values provide greater resistance to output hits when the underlying computer or network is busy. Lower values reduce the input-to-output delay of the stream passing through the Alta system. It may also be necessary to use higher values to maintain low output jitter when a stream is being used in the standard re-multiplex mode (not Low Latency Mode), which has significant variation in the size in bytes of successive GoPs.
  - **Test Captions:** This option begins outputting a stream of scrolling test captions on Language 1 whenever the Alta instance is started. The stream of test captions will continue until a live iCap captioner first sends data to the encoder. After this occurs, the test captions will not resume again unless the instance is stopped and restarted.

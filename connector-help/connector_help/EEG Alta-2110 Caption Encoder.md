---
uid: Connector_help_EEG_Alta-2110_Caption_Encoder
---

# EEG Alta-2110 Caption Encoder

This connector is designed to monitor the EEG Alta-2110 for use with the SMPTE 2110 suite of standards. The iCap Alta software is packaged on a virtual machine for placement inside a customer video facility. The virtual machine "guest" operating system is 64-bit Debian 8 Linux. The VM can be hosted on VirtualBox, Cisco, or Microsoft HyperV controllers. The default distribution format is an "OVA" file, though alternative disk image formats can often be provided on request. Once the iCap Alta virtual machine is running and reachable on a local network, all interaction with the software can be performed over HTTP on the network, as a web service, or in a browser.

## About

### Version Info

| **Range**            | **Key Features**                                       | **Based on** | **System Impact** |
|----------------------|--------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                       | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Changed NamingFormat/display key to retrieved columns. | 1.0.0.5      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The **General** page of this connector contains the username and password to access the device.

The **Instance Settings** pagecontains a table with basic information about the existing instances, as well as specific logs for every instance. This page has multiple subpages, which can among others be used to add new instances or edit existing instances:

- **New Instance Settings**: Allows you to create a new instance with the necessary basic information.

- **Stream Settings:** Allows you to edit the stream settings for existing instances.

- **Device Label:** The name to be used for this instance within the Alta interface and as a device label in NMOS registration.
  - **Use NMOS IS-05:** Select this option to make this device responsive to changes in the input and output parameters made by NMOS IS-05 HTTP requests.
  - **ANC Multicast Destination:** The UDP unicast or multicast address and port to be used for the 2110-40 output transmissions. This parameter may be changed from its initial value by NMOS IS-05 once the device is active.
  - **Audio Multicast Source:** The UDP port to listen to or the multicast address and port to receive a 2110-30 audio stream for iCap reference. This parameter may be changed from its initial value by NMOS IS-05 once the device is active.
  - **Audio Sample Frequency, Sample Size, and Number of Channels:** Required information (as from an SDP file) on the sample rate and the number of channels expected from the audio input stream. These parameters may be changed from their initial value by NMOS IS-05 once the device is active.
  - **ANC Multicast Source:** The UDP port to listen to or the multicast address and port to receive a 2110-40 ancillary stream as a source of upstream captioning. Upstream captioning from this stream will be multiplexed with any new captioning that is locally inserted according to priority rules as documented in EEG Smart Encoder protocol documentation. This parameter may be changed from its initial value by NMOS IS-05 once the device is active.
  - **Media Network Interface:** If multiple NICs are available on the Alta VM, specify one of the NIC IP addresses in this field to control which interface is used to send and listen for media multicasts associated with this instance.

- **iCap Settings**:Allows you to edit the iCap settings for existing instances.

- **iCap Company, Username, and Password:** iCap account information will be provided to you by EEG with your purchase or demo or will be accessible from your company's admin account at [https://www.eegicap.com](https://www.eegicap.com/). Each iCap account has a company namespace, a username, and a password. This account will be used to allow unique identification of your stream by your contracted real-time captioner over iCap, so you must use a different username for each simultaneously operating Alta encoder instance. You do not need an iCap account to perform certain non-cloud functions such as caption bridging between input sources or SCTE-35 cue insertion.

- **Telnet Settings**: Allows you to edit the Telnet settings for existing instances.

- The Telnet Settings menu provides functionality to clone "CTRL+A" style caption data from the iCap connection over to a legacy SDI closed captioning encoder or other similar devices/systems. The IP address and port number of the receiving device must be provided, and if the receiving device requires a username and password to open a connection, fill in these fields as well. This is the sole output mode of the "Alta Bridge" license option.

- **Other Settings:** Allows you to edit the following other settings for existing instances:

- **Warnlevel:** This value can be set from 0-5 to control how much information is sent to the logs for this instance. Lower number settings may be more useful when debugging a problem but can make logs harder to read and increase resource usage per stream.
  - **Caption Output Format:** Choose between SMPTE 334 CEA-708 VANC packets (DID/SDID 6101) and OP 47 EBU Teletext packets (DID/SDID 4302).
  - **DVB Text Config:** If OP 47 Teletext output is used, specify how many languages to include by listing the language code and Teletext magazine and page number desired for each service. Up to 6 language services are supported.
  - **Video Frame Rate:** This option allows you to force the selection of a specific frame rate for the interpretation of input and output 2110-40 ancillary streams. The default option relies on data from the SMPTE 2059 TLV transmitted by the current PTP grandmaster to obtain this information.
  - **Send VITC:** Select this option to add VITC packets in DID/SDID 6060 into the output 2110-40 stream. The VITC time code is derived from the PTP grandmaster's signals as described in SMPTE 2059.
  - **Test Captions:** Select this option to have a looping test message of single language scrolling captions created on the 2110-40 output, beginning when the instance is activated, and ending when a live captioner begins sending data to the instance. After a live captioner connects, the test caption message will not resume unless the instance is stopped and then restarted.

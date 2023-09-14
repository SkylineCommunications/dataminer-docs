---
uid: Connector_help_Bridge_Technologies_RDP
---

# Bridge Technologies RDP

This connector can be used to configure a Bridge Technologies probe to take a stream, that is available on the video network, and do Relay over IP through the operations network using the RTP protocol or record it.

## About

This is a small connector with only the Return Data Path (RDP) feature impemented for Bridgetech probes. This feature makes it possible to configure a probe to forward a specific stream to a specific destination. This functionality is available in probes with software version 4.2 and higher. From version 5.0 and higher, it is also possible to make the probe record locally via the Eii.

If the requested stream is not already monitored by the probe, a temporary stream called RTP_STREAM is created provided all 260 probe slots are not used already.

All communication with the device is done via the HTTP protocol.

Note:

- This connector is intended to be used in combination with an automation script or a manager connector.
- There are two RDP engines in each probe. The element bus address is used to specify the engine to use.
- Only the RDP Status parameter is being polled from the device. The configuration parameters can only be used to perform sets and are not being retrieved from the probe.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                             |
|------------------|-------------------------------------------------------------------------|
| 1.0.0.x          | Software version 4.2 and higher. For recording: version 5.0 and higher. |

## Installation and configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. Default: *80*.
- **Bus address**: Specifies which of the available RDP engines this element refers to. If the proxy server has to be bypassed, specify *bypassproxy*. Format: "*bypassproxy;\<engine id\>*"

### Configuration

No additional configuration is necessary in the element.

## Usage

### General

Displays the configured engine ID. See the installation and configuration section for more information.

### RDP

Contains the parameters that allow to configure RDP on the probe.

- **Return Data Path**: Used to activate or de-activate RDP.

- **Mode**: Choose between forwarding and local recording.

- **Recording Timeout**: Timeout for recording.

- **Recording Size**: File size for recording.

- **Protect**: How many seconds to protect recording from being overwritten.

- **Source IP Address**: The IP address of the stream to forward.

- **Source Port**: The UDP port of the stream to forward.

- **Source Stream Address**: The source address of the stream to forward (not required unless using source specific multicasting).

- **Source VLAN ID**: The VLAN of the stream.

- **Source Interface**: Specifies which Ethernet input stream is present on.

- **Destination IP Address**: The IP address to forward to.

- **Destination Port**: The UDP port to forward to.

- **Destination Interface**: The interface to forward over. Needed if forwarding as a multicast.

The **RDP Status** parameter indicates if the probe is currently Idle, Streaming or Recording.

Click on the "**Configure**" button to apply the configuration on the device. The result of the operation is displayed on the status parameters.

### Manager

Contains a parameter that can be set by an automation script or manager protocol, do configure RDP in one action.

Format: *engine=1&dst_ipa=10:0:30:216&src_ipa=239:255:0:4&src_port=5500&src_ssm=0:0:0:0&protocol=eth&dst_ipa=10:0:30:21&dst_iface=data&enable=false*

| **Argument** | **Description**                                                                                                         |
|--------------|-------------------------------------------------------------------------------------------------------------------------|
| dst_ipa      | The IP address to forward to.                                                                                           |
| dst_port     | The UDP port to forward to.                                                                                             |
| dst_iface    | The interface to forward over. Values: "data" (default), "data2" and "management". Needed if forwarding as a multicast. |
| src_ipa      | The IP address of the stream to forward.                                                                                |
| src_port     | The UDP port of the stream to forward.                                                                                  |
| src_ssm      | The source address of the stream to forward (not required unless using source specific multicasting).                   |
| src_vlan_id  | The VLAN of the stream, or -1.                                                                                          |
| src_iface_id | Specifies which Ethernet input stream is present on. Values: "0" is DATA and "1" is DATA2                               |
| input        | The input interface. Values: "Ethernet", "SAT1", "SAT2"                                                                 |
| protocol     | Must be "eth" for forwarding or "rec" for local recording.                                                              |
| timeout      | Timeout for recording.                                                                                                  |
| size         | File size for recording.                                                                                                |
| protect      | How many seconds to protect recording from being overwritten. If the value is -1, it will never be overwritten.         |

### Web Interface

Displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

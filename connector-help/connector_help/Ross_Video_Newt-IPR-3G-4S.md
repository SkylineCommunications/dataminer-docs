---
uid: Connector_help_Ross_Video_Newt-IPR-3G-4S
---

# Ross Video NEWT IPR-3G-4S

This connector can be used to manage and control the Ross Video Newt IPR-3G-4S.

The connector only supports the Newt IPR-3G-4S IP to 4 SDI output configuration mode. Other Newt configuration modes require a separate connector.

## About

The user interface of this connector is similar to that of the Ross Video dashboard.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

## Installation and configuration

#### HTTP CommandAPI connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage

### General

This page displays general information about the device, such as the Device Name, Current Firmware Version, Product, FPGA Version and more.

There are also buttons available that allow you to trigger a **Reboot** and to reset the device to the **Factory Defaults**.

### Ethernet I/O

This page displays information and controls for the two Ethernet interfaces, **NET 1** and **NET 2**, including mode, IP, subnet mask, gateway, and status parameters such as the **Temperature**, the **Wavelength**, and the **Part** **Number**.

There are is also a page button that provides access to the **Control RJ-45 Configuration** subpage, which contains controls for **Mode**, **IP**, **Subnet Mask** and **Gateway**. However, note that if an interface is configured for **DHCP**, it will not be possible to modify **Mode**, **Static** **IP**, **Subnet** and **Gateway**.

Currently, Interface RX and TX Bandwidth is not supported in the JSON API.

### Timing

This page contains various **PTP**-related parameters, such as the **Role Status**, **Sync Interval**, **Announce Interval**, **Announce Receipt Timeout** and more. It also contains configuration parameters such as the **PTP Profile**, **Domain**, **Priority 1** and **Priority 2.**

### Receivers

This page contains the **Receivers** table, which displays **Video** and **Audio Streams** as they are added as connections.

It also includes the **Network Stream Groups** table, which adds a group for every network stream added, for re-adding at a later time.

Via the **Add Stream** page button, you can access the **Add Network Stream** subpage, where you can configure and send a stream via the **Stream Configuration** table, and configure the additional group parameters. When a stream is added, it is also added to the **Network Stream Groups Table**. There are two ways to send a stream: via this subpage or via the **Network Stream Groups** table.

- Note that to add a stream, you must fill in all of the individual parameters as well as the stream configuration columns for the stream you want to add (except for Video Format for audio streams and Number of Audio Streams (1 or 2 groups of 8 channels)).
- This connector only supports assignment of Audio Streams in 8 channel blocks.

### PattGen

This page allows you to add a pattern. The information for added patterns is displayed in the **Patterns** table.

### Discovery

This page displays general information about the current control protocols of the device, such as the **Interface** and the **Port Number**. It currently supports **Ravenna**, **RTSP**, **Ember**, and **NMOS**

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

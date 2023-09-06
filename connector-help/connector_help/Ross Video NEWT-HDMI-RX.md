---
uid: Connector_help_Ross_Video_NEWT-HDMI-RX
---

# Ross Video HDMI-RX

This driver manages and controls the Ross Video Newt HDMI-RX. The driver only supports the Newt UHD-over-IP to HDMI 2.0 Gateway configuration mode. Other Newt configuration modes require a separate driver.

The user interface of this driver is similar to that of the Ross Video dashboard.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP CommandAPI connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the data pages detailed below.

### General

This page displays general information about the device, such as the Device Name, Current Firmware Version, Product, FPGA Version and more.

There are also buttons available that allow you to trigger a **Reboot** and to reset the device to the **Factory Defaults**.

### Discovery

This page displays general information about the current control protocols of the device, such as the **Interface** and the **Port Number**. It currently supports **Ravenna**, **RTSP**, **Ember**, and **NMOS**

### Ethernet I/O

This page contains information and settings for the two Ethernet interfaces, **NET 1** and **NET 2**, including mode, IP, subnet mask, gateway, and status parameters such as the **Temperature**, the **Wavelength**, and the **Part** **Number**.

There is also a page button that provides access to the **Control RJ-45 Configuration** subpage, which contains controls for **Mode**, **IP**, **Subnet Mask** and **Gateway**. However, note that if an interface is configured for **DHCP**, it will not be possible to modify **Mode**, **Static** **IP**, **Subnet** and **Gateway**.

Currently, interface RX and TX bandwidth is not supported in the JSON API.

### Timing

This page contains various **PTP**-related parameters, such as the **Role Status**, **Sync Interval**, **Announce Interval**, **Announce Receipt Timeout** and more. It also contains configuration parameters such as the **PTP Profile**, **Domain**, **Priority 1** and **Priority 2.**

### Receivers

This page contains the **Receivers** table, which displays **Video** and **Audio Streams** as they are added as connections.

It also includes the **Network Stream Groups** table, which adds a group for every network stream added, for re-adding at a later time.

Via the **Add Stream** page button, you can access the **Add Network Stream** subpage, where you can configure and send a stream via the **Stream Configuration** table, and configure the additional group parameters. When a stream is added, it is also added to the **Network Stream Groups Table**. There are two ways to send a stream: via this subpage or via the **Network Stream Groups** table. You can also update an existing stream from the **Receivers Table** by selecting a session/stream to modify in the drop-down lists.

Note:

- To add a stream, you must fill in all of the individual parameters as well as the stream configuration columns for the stream you want to add (except for Video Format for audio streams and Number of Audio Streams (1 or 2 groups of 8 channels)).
- This driver only supports assignment of Audio Streams in 8 channel blocks.

Via the **X-Connect** page button, you can access the **X-Connect** subpage, where you can view the cross-connection matrix.

### PattGen

This page allows you to add a pattern. The information for added patterns is displayed in the **Patterns** table.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

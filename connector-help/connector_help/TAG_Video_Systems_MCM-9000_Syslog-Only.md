---
uid: Connector_help_TAG_Video_Systems_MCM-9000_Syslog-Only
---

# TAG Video Systems MCM-9000 Syslog-Only

The MCM-9000 family of products enables real-time live monitoring of MPEG-2 and H.264 video sources, both in SD quality and HD quality. The purpose of this driver is to receive and display Syslog messages sent from the device.

## About

This driver uses a smart-serial connection to poll data from the MCM-9000 device. If the system is a "stacked" system, all data will be polled through the main MCM-9000 device.

The driver can receive traps to update the channel and system events in real time.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.1.7                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Smart-Serial Main Connection

This driver uses a smart-serial connection to receive syslog messages:

SMART-SERIAL CONNECTION:

- **IP address/host**: The IP of the syslog proxy.
- **Type of port:** UDP/IP
- **IP port:** 514 (the default syslog port).

## How to use

The element created with this driver consists of the data pages detailed below.

### Channel Status

On this page, you can view a table of all the channels. If the status for a row is *Inactive*, the **Delete Channel** button for that row becomes available. When you click this button, the corresponding channel and all events associated with it are deleted. Alternatively, you can delete all inactive channels at the same time using the **Delete All** button.

You can also set an inactive time, which is how long the system will wait to receive another KeepAlive message before the channel is declared inactive.

### Channel Events

On this page, you can view a table of all **Channel Events**. Like with the table on the previous page, you can delete a row if the status is *Inactive*, or you can delete all inactive rows at the same time using the **Delete All** button.

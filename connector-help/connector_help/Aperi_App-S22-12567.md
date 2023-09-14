---
uid: Connector_help_Aperi_App-S22-12567
---

# Aperi App-S22-12567

This connector is used to monitor and configure Aperi's APP-S22-12567 (SDI) module. Using the **HTTP API**, the connector collects information from the device.

## About

### Version Info

| **Range**            | **Key Features**                                                 | **Based on** | **System Impact**                                                                                                                                                     |
|----------------------|------------------------------------------------------------------|--------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version                                                  | \-           | \-                                                                                                                                                                    |
| 1.0.0.x \[SLC Main\] | Changed parameter descriptions of parameters with 2010 and 2013. | 1.0.0.2      | All statistical data will be lost for parameters 2010 and 2013 when upgrading from the previous version. Visio drawings for the 1.0.0.x branch might be incompatible. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.6.64                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. (default: *443*)
- **Bus address**: The app slot number

### Initialization

After element creation, it is required to specify a valid **Username** and **Password** to start polling data from the device.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### General Page

This page mainly displays **system information**. This includes information about the **Device Name**, **Vendor** and **Version**.

On this page, you can also define the **Username** and **Password** to connect to the device. This must be done to be able to retrieve any data with the connector.

Pressing the **Login** button will force a refresh of the element's data.

### Manage Devices

This page allows you to **create new devices** (new rules) in the system.

To create a device, you should always specify the following information: the sender and receiver **Source IP Address**, **Source Port**, **Destination IP Address** and **Destination Port**, a **Network Port**, and **Bit Rate**. Other data is optional.

On the **RTP Alarming**, **Payload Alarming** and **Protect** tab pages, additional configuration options are available.

NOTE: To interact with the tables, use the table context menus. Also note that it is currently not possible to configure both merging and mirroring, as both features require the use of the backplane ports.

### Devices

This page contains device information for both **Senders** and **Receivers** of the devices, including the devices' IPs, ports, and generic network configuration. A device can be deleted from the device table.

A page button provides access to the **Alarm Configuration** subpage, where the alarm configuration for each device is displayed. Depending on the selected encapsulation, the information for each device can be shown in different tables.

### Ports

This page contains the network information separated in two tables **BP Ports** and **SFP Ports** which diplays info for the hardware ports/interfaces of the device, separated into receivers and senders. Typically, the device contains four ports: two on the front plane and two on the back plane. However, there is hardware support for two extra back plane ports. The information available on this page is all network related. It includes **Packet** information, **Bit Rates** and **Bytes**.

### Interfaces

This page displays **Ethernet statistics** for device **Senders** and **Receivers**. This includes **ARP**, **ICMP** and **IGMP** **statistics**.

### Encapsulation

This page contains statistical information for SMPTE-2022-6 encapsulation. The focus for SMPTE-2022-6 is on **video** and **audio** statistics.

### RTP

This page contains **RTP statistics** for both **Senders** and **Receivers**, including **packets**, **uptime**, **bit rates** and **status and error** information.

### PDV

This page displays the **Packet Data Variation** statistics for both **Senders** and **Receivers**. Average values are shown for several timespans.

### FEC

This page displays the **Forward Error Correction** statistics for both **Senders** and **Receivers**, including the **FEC mode** and the **dropped** and **recovered** packets.



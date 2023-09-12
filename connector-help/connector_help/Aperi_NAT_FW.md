---
uid: Connector_help_Aperi_NAT_FW
---

# Aperi NAT FW

This driver is used to monitor Aperi's Network Address Translator (NAT) Firewall (FW) module. Using the **HTTP API**, the driver collects information from the device. Setting the information is not possible in version 1.0.0.1.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                                       | **Based on** | **System Impact**                                                                                                                                                     |
|----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                                                                                                                                                                                       | \-           | \-                                                                                                                                                                    |
| 2.0.0.x              | Driver re-write for SRM. New API.                                                                                                                                                                                      | \-           | All statistical data will be lost when you upgrade from the previous version. Visio drawings for the 1.0.0.x branch are incompatible with this branch.                |
| 2.0.1.x \[Obsolete\] | Redesign of Manage Device pages. Included device table and changed FK relation to map this.                                                                                                                            | 2.0.0.7      | Automation needs to be configured to use the right parameter IDs. Function resources have changed.                                                                    |
| 2.0.2.x \[Obsolete\] | Changed parameter descriptions of parameters 2010 and 2013. Added new table columns on Senders and Create Device Table.                                                                                                | 2.0.1.5      | All statistical data will be lost for parameters 2010 and 2013 when you upgrade from the previous version. Visio drawings for the 2.0.1.x branch may be incompatible. |
| 2.0.3.x \[SLC Main\] | Added exception values to parameters 638 and 639. Changed parameter description of parameter 2803. Added new table columns + changed display order of the tables 430, 460, 610, 630, 650, 670, 690, 840, 860 and 1250. | 2.0.2.4      | Visio drawings and Automation scripts for the 2.0.2.x branch (and previous) may be incompatible.                                                                      |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588A102-1     |
| 2.0.0.x   | 0.6.6                  |
| 2.0.1.x   | 2.6.64                 |
| 2.0.2.x   | 2.6.64                 |
| 2.0.3.x   | 2.6.64                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.2.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.3.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

After element creation, specify a valid **User Name** and **Password** to start polling data from the device. To do so, in version 1.0.0.x, go to the **Security Settings** subpage of the **General** page. In version 2.0.0.x, these settings are available directly on the **General** page.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use - 1.0.0.x

### General Page

This page mainly displays **system information**. This includes information about the **Device Name**, **Vendor**, **Version** and **Image ID**.

Via the **Security Settings** page button, you can define the **Username** and **Password** to connect to the device.

### Ethernet

This page displays a table with information related to the Ethernet port.

### TX Interfaces

This page displays the tables relates to the TX interfaces, i.e. **TX Interfaces VLANS** and **TX Interfaces Host**.

This page has a subpage called **Statistics**, which contains information related to **TX Interface Statistics**, including **TX Session**, **TX PDV Statistics**, **TX Session Payload** and **TX Session Monitored PIDs**.

### RX Interfaces

This page displays the tables related to the RX interfaces, i.e. **RX Interfaces VLANS** and **RX Interfaces Host**.

This page has a subpage called **Statistics**, which contains information related to **RX Interface Statistics**, including **RX Session**, **RX PDV Statistics**, **RX Session Payload** and **RX Session Monitored PIDs**.

### TX Policy

This page displays details about the TX policy.

This page has a subpage called **Payload**, which contains TX payload information, including **TX Payload SDI, TX Policy Payload TS** and **TX Policy Monitored PIDs**.

### RX Policy

This page displays details about the RX policy.

This page has a subpage called **Payload**, which contains RX payload information, including **RX Payload SDI, RX Policy Payload TS** and **RX Policy Monitored PIDs**.

## How to use - 2.0.1.x / 2.0.2.x

### General Page

This page mainly displays **system information**. This includes information about the **Device Name**, **Vendor**, **Version** and **Image ID**.

On this page, you can also define the **Username** and **Password** to connect to the device. This must be done in order to be able to retrieve any data with the driver.

Pressing the **Login** button will force a refresh of the element's data.

### Manage Devices

This page allows you to **create new devices** (new rules) in the system.

To create a device, you should always specify the following information: the sender and receiver **Source IP Address**, **Source Port**, **Destination IP Address** and **Destination Port**, a **Network Port**, and the definition of the **Encapsulation** and **Bit Rate**. Other data is optional.

On the **RTP Alarming**, **Payload Alarming** and **Protect** tab pages, additional configuration options are available.

NOTE: To interact with the tables, use the table context menus. Also note that it is currently not possible to configure both merging and mirroring, as both features require the use of the backplane ports.

### Devices

This page contains device information for both **senders** **and** **receivers** of the devices, including the devices' IPs, ports, and generic network configuration. A device can be deleted from the device table.

A page button provides access to the **Alarm Configuration** subpage, where the alarm configuration for each device is displayed. Depending on the selected encapsulation, the information for each device can be shown in different tables.

On the **Device Resources** page, you can map a device to a resource.

### Ports

This page contains the network information for the hardware ports/interfaces of the device, separated into receivers and senders. Typically, the device contains four ports: two on the frontplane and two on the backplane. However, there is hardware support for two extra backplane ports. The information available on this page is all network-related. It includes **Packet** information, **Bit Rates** and **Bytes**.

### Interfaces

This page displays **Ethernet statistics** for device **senders** **and** **receivers**. This includes **ARP**, **ICMP** and **IGMP** **statistics**.

### Encapsulation

This page contains statistical information for SMPTE-2022-2 and SMPTE-2022-6 encapsulation. The focus for SMPTE-2022-2 is on **Program** tables and **PIDs**; for SMPTE-2022-6 it is on **video** and **audio** statistics.

### RTP

This page contains **RTP statistics** for both **senders** **and** **receivers**, including **packets**, **uptime**, **bit rates** and **status and error** information.

### PDV

This page displays the **Packet Data Variation** statistics for both **senders and receivers**. Average values are shown for several timespans.

### FEC

This page displays the **Forward Error Correction** statistics for both **senders and receivers**, including the **FEC mode** and the **dropped** and **recovered** packets.

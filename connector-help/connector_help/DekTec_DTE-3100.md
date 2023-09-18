---
uid: Connector_help_DekTec_DTE-3100
---

# DekTec DTE-3100

**DekTec DTE-3100** is a **Transport Stream over IP to ASI Gateway (Receiver)**. The unit accepts unicast and multicast streams over its Gigabit-Ethernet port, and de-encapsulate the TSoIP streams to an ASI output. Key features include de-encapsulation of UDP or RTP, accurate timing reconstruction using innovative algorithms to overcome IP jitter, as well as error correction according to SMPTE 2022-1. The connector can be used to view real-time parameters from the device and to configure parameters of the device.

## About

The connector is intended to work with the **DTE-3100**. SNMP communication is used to monitor the different Parameters in the device.

### Version Info

| **Range** | **Description**       | **DCF Integration** | **Cassandra Complaint** |
|------------------|-----------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version. SNMP | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 16                          |

## Installation and configuration

Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device. (default: public)
- **Set community string**: The community string used when setting values on the device. (default: private)

## Usage

### General

This Page Displays General Information (***Name**, **Serial Number**, **Firmware version**, etc*.) Additionally shows information about **Watchdog**, **Power Cycle counters** in Popup page: **Counters**.

### Status

The page shows the different values for two set of settings: *Transcoding* (**Packet Size**, **Transport Stream Rate**, **Operational Status**, **Addressing Method**, **IP Port** and **IP Jitter Tolerance**) and *SMPTE* *Protocol* (**Protocol**, **Transport Packets per IP**, **FEC Rows** and **Columns**, **IP Lost Before** and **After FEC**).

### Network

The following Parameters can be configured in this Page: **Multicast Adddress**, **IP Source Multicast**, **Generate Trap**, **Trap Community**, **Trap Port** and **Trap Destination**.

### SMPTE Settings

The page contains this Parameters: **FEC Reconstruction**, **Output Delay**, **Transport Stream Rate**, **Transport Stream Packet Size**, **Transport Stream Estimation Mode**, **IP Jitter Error Counter**, **FEC Delay**, **Delay Factor**, etc.

### Web Page

On this page, users can access the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

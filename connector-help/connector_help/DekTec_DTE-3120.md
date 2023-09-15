---
uid: Connector_help_DekTec_DTE-3120
---

# DekTec DTE-3120

**DekTec DTE-3120** is a **Networked DVB-ASI Input Adapter (Transmitter)**. DekTec's standalone power-over-ethernet enabled ASI to IP Converter, allowing zero-jitter transmission of Transport Streams to IP networks. The connector can be used to view real-time parameters from the device and to configure parameters of the device.

## About

The connector is intended to work with the **DTE-3120**. SNMP communication is used to monitor the different Parameters in the device.

### Version Info

| **Range** | **Description**       | **DCF Integration** | **Cassandra Complaint** |
|------------------|-----------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version. SNMP | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 15                          |

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

This Page Displays General Information (***Name**, **Serial Number**, **Firmware version**, etc*.) Additionally shows information about **Bytes Received**, **ASI Code Violations** in Popup page: **More**.

### Status

The page shows the different values for two set of settings: *Transcoding* **(IP Address Status**, **Input Status**, **Channel Status**, **Transport Stream Rate**, **IP Port** and **Time to Life, Type of Service**) and *SMPTE* *Protocol* (**Protocol**, **Transport Packets per IP**, **FEC Rows** and **Columns**, **IP Lost Before** and **After FEC, Transport Stream Packet Size**).

### Network

The following Parameters can be configured in this Page: **IP Address**, **IP Source Multicast**, **Channel**, **Physical Port**, **Generate Trap**, **Trap Community**, **Trap Port** and **Trap Destination**.

### Web Page

On this page, users can access the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

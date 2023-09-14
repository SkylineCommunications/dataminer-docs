---
uid: Connector_help_NTT_Electronics_HVD9100
---

# NTT Electronics HVD9100

This connector is used to monitor and configure the **HVD9100** decoder from **NTT Electronics**.

## About

This connector uses the **SNMP** protocol to communicate with the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | \-                          |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.

## Usage

### General

This page contains general information about the device, such as the **Decoder State**, **System Description**, **System Version**, **MIB Version** and **System Up Time**.

### Status

This page displays information about the state of the device, including the **Video Input State**, **Audio Input State**, **System Alarm**, **System Warning, Voltage**, **Temperature** and **Fan Status**.

### Audio

This page displays information about the **Mode**, **Rate** and **Output** of the **4 Audio Channels**.

### Video

This page displays information about **Video Type**, **Format**, **Chroma**, **Profile**, **Mode** and more.

### Transport Stream

This page allows you to configure the **Program Mode** and **Input** and also displays information about the transport stream, such as the **TS Bitrate**.

### Ancillary

This page displays information about the ancillary, such as the **Ancillary Rate**, **Ancillary PID** and **Received Data**.

### Alarm

This page allows you to view all the incoming alarms, with information about the **Probable Cause**, **Alarm Type**, **Specific Problem** and **Time**.

### Configuration

This page allows you to view and configure the **Decoder Input**, **IP Configuration**, **Optional IP Settings**, **BISS**, **Ancillary**, **Gen Lock** and **Audio Channels**.

The **Reset Device Button** allows you to reset the device.

### Trap Information

This page allows you to configure the **Trap IP Addresses** and **Community Strings**.

### Web Interface

This page shows the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

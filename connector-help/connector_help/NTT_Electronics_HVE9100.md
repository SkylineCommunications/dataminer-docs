---
uid: Connector_help_NTT_Electronics_HVE9100
---

# NTT Electronics HVE9100

This connector is used to monitor and configure the **HVE9100** encoder from **NTT Electronics**.

## About

This connector uses the **SNMP** protocol to communicate with the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 07.00/Rev.F./01.50/Rev.C    |

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

This page contains general information about the device, such as the **Encoder State**, **System Description**, **System** **Version**, **MIB Version** and **System Up Time**.

### Status

This page displays information about the state of the device, including the **Video Input State**, **Audio Input State**, **System Alarm**, **System Warning, Voltage**, **Temperature** and **Fan Status.**

### Audio

This page displays information about the **Mode**, **Rate** and **Input** of the **4 Audio Channels**.

### Video

This page allows you to configure the **Video Mode**, **Bitrate**, **Format**, **Size**, **Latency**, **Filter** and **Stream Type**.

### Transport Stream

This page allows you to configure the **Program Number**, the **TS Bitrate** and a range of **ID Parameters**.

### Ancillary

This page displays information about the ancillary, such as the **Ancillary Rate** and **Ancillary PIDs**.

### Alarm

This page allows you to view all the incoming alarms, with information about the **Probable Cause**, **Alarm Type**, **Specific Problem** and **Time**.

### Configuration

This page allows you to view and configure the **Encoder**, **IP Configuration**, **Optional IP Settings**, **BISS**, **PSI** and **Test Parameters**.

The **Reset Device Button** allows you to reset the device.

The **Configuration File page button** opens a new window where you can:

- Recall a preset.
- Save or delete the current preset.
- Upload or download a configuration.

### Trap Information

This page allows you to configure the **Trap IP Addresses** and **Community Strings**.

### Web Interface

This page shows the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

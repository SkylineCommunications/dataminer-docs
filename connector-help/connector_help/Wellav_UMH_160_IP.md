---
uid: Connector_help_Wellav_UMH_160_IP
---

# Wellav UMH 160 IP

This connector can be used to display information from a **Wellav UMH 160 IP** device.

## About

This protocol is used to monitor Wellav UMH 160 **IP** devices. WellAV UMH 160 **T2** devices are monitored by a **separate protocol**.

An **SNMP** connection is used to successfully retrieve information from the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *public*.

## Usage

### Status

This page displays all status information for the **Input Tuner**, **Input ASI**, **Input IP**, **Decoder**, **Output ASI**, **Output IPs** and **CI Slots**.

### Programs

The page contains the **Program Table**, with the **Program Names** and **Program PIDs**. Two buttons allow you to **Scan TS** for **DVB** and **ATSC**.

The **Source Select**, **T2MI** and **Bypass Whole Stream** for ASI and IP can also be set on this page.

### Input Receiver

This page displays the **Satellite Frequency**, **Symbol Rate** and **LNB Frequency**, **Power Supply** and **22KHz**.

### Input IP

This page displays the following local connection and channel information:

- **Local IP Address**
- **Local Subnet Mask**
- **Local Gateway**
- **Local Speed Mode**
- **Local Mac**
- **Channel**
- **Source IP Address**
- **Source Port**
- **Protocol**

A page button opens the **IGMP** page, which displays the **IGMP** **Version**, **Auto** **Report**, **Filter** and **IP** **Address**.

### Output Decoder

This page displays information related to the **decoder**, **video**, **audio**, **subtitle** and **teletext**. The related tables display the indexes, names and PID.

### Output ASI

This page displays the **Constant Rate.**

### Output IP

This page provides the following IP information for the three channels:

- **Enable**
- **Protocol**
- **Destination IP Address**
- **Destination Port**
- **Contstant Rate**
- **Destination MAC Enable**
- **Destination MAC**

### CA

This page shows the **CAM Max Bitrate** and BISS-related parameters: **Mode**, the **BISS-1** and **BISS-E** **Keys** and the **BISS-E ID.**

### System

This page displays system information such as the **IP Address**, **Subnet Mask** and **Gateway**, as well as some **Trap** information. This page also contains a **Reboot** and a **Factory Set** button.

### Alarm

This page displays a number of alarms: **LNB Connection Short, Signal Unlock, CAM 1** and **CAM 2 Communication Error** and **Descrambling**.

### Web Interface

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

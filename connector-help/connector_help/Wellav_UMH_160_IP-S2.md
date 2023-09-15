---
uid: Connector_help_Wellav_UMH_160_IP-S2
---

# Wellav UMH 160 IP-S2

The **Wellav UMH 160 IP-S2** connector can be used to display information of any related device.

## About

This protocol can be used to monitor the Wellav UMH 160 S2 and WellAV UMH 160 IP devices. WellAV UMH 160 T2 devices are monitored by a separate protocol.

An **SNMP** connection is used to successfully retrieve the device's information.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

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

The connector contains 10 pages.

### Status

This page displays all status information for the **Input Tuner**, **Input ASI**, **Input IP**, **Decoder**, **Output ASI**, **Output IPs** and **CI Slots**.

### Programs

The page contains the **Program Table** with the **Program Names** and **Program PIDs**. Two buttons allow to **Scan TS** for **DVB** and **ATSC**.

The **Source Select**, the **T2MI** and **Bypass Whole Stream** for ASI and IP can also be set on this page.

### Input Receiver

This page displays the **Satellite Frequency**, **Symbol Rate** and **LNB Frequency**, **Power Supply** and **22KHz**.

### Input IP

This page displays the following local connection and channel information.

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

This page provides the **GbE Port-Setting** for the **Main** and **Backup** and the following IP information for the three channels:

- **Enable**
- **Protocol**
- **IP Address**
- **Port**
- **Backup IP Address**
- **Backup Port**

### CA

This page shows the **CAM Max Bitrate** and BISS related parameters: **Mode**, the **BISS-1** and **BISS-E** **Keys** and the **BISS-E ID.**

### System

This page displays system information such as the **IP Address**, **Subnet Mask** and **Gateway**, as well as some **Trap** information. This page also contains a **Reboot** and a **FactorySet** button.

### Alarm

This page displays six alarms: **LNB Connection Short, Signal Unlock, CAM 1** and **CAM 2 Communication Error** and **Descrambling**.

### Web Interface

On this page, you can view the web interface of the device. However, the client machine has to be able to access the device. Otherwise, it will not be possible to open the web interface.

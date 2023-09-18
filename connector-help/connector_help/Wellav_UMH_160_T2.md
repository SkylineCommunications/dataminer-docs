---
uid: Connector_help_Wellav_UMH_160_T2
---

# Wellav UMH 160 T2

The **Wellav UMH 160 T2** connector can be used to display information of any related device.

## About

This protocol can be used to monitor the Wellav UMH 160 T2 devices. WellAV UMH 160 S2 and WellAV UMH 160 IP devices are monitored by their own protocol. A **SNMP** connection is used to successfully retrieve the device's information.

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

This page displays all status information for the **Input Tuner**, **Input ASI**, **Input IP**, **Output ASI**, **Output IPs** and **CI Slots**.

### Input Receiver

This page displays tuner-related information. There are parameters for both Tuner 1 and 2.

- **Enable**
- **Mode**
- **Frequency**
- **Bandwith**
- **PLP Mode**
- **TS Standard**
- **ScanTS**

### Input ASI

This page displays **ASI** **1**, **ASI** **2** and the **TS** **Standard** for both ASI 1 and 2. There is also a **ScanTS** button for both ASI 1 and 2.

### Input IP

This page displays the following local connection and channel information for channel 1 and channel 2.

- **Local IP Address**
- **Local Subnet Mask**
- **Local Gateway**
- **Local Speed Mode**
- **Local Mac**
- **Channel**
- **Source IP Address**
- **Source Port**
- **Protocol**
- **Enable Col Port Matching**
- **Enable Row Port Matching**
- **TS Standard**

A page button opens the **IGMP** pages for Channel 1 and Channel 2. They display the **IGMP** **Version**, **Auto** **Report**, **Filter** and **IP** **Address**.

### Backup Setting

Here the **Main** and **Backup** **Input** **StreamBackup** **Settings** can be set, both for **Stream** **1** and **Stream2**.

### Output Decoder

This page displays information related to the **decoder**, **video**, **audio**, **subtitle** and **teletext**. The related tables display the indexes, names and PID.

### Output ASI

This page displays the **TS Source** for ASI 1 and 2**.**

### Output IP

This page provides the **GbE Port Setting** for the **Main** and **Backup** and the following IP information for two channels:

- **Enable**
- **TS Source**
- **Protocol**
- **IP Address**
- **Port**
- **MAC**
- **Backup IP Address**
- **Backup Port**
- **Backup MAC**

A button can be used to **set the Backup Port** the same as the Main Port.

### CA

This page shows the **CAM Max Bitrate** and BISS related parameters: **Mode,** the **BISS-1** and **BISS-E** **Keys** and the **BISS-E ID.** The **TS** **Sources** are also displayed for both CAs.

### Program Mux Setting

This page displays information related to the **Mux 1, Mux 2, Tuner 1, Tuner 2, ASI 1, ASI 2, IP 1** and **IP 2**. The related tables display the indexes, names and PID.

### System

This page displays system information such as the **IP Address, Subnet Mask, Gateway** as well as some **Trap** information. This page also contains a **Reboot** and a **FactorySet** button.

### Alarm

This page displays six alarms: **LNB Connection Short, Signal Unlock, CAM 1** and **CAM 2 Communication Error** and **Descrambling**.

### Web Interface

On this page, you can view the web interface of the device. However, the client machine has to be able to access the device. Otherwise, it will not be possible to open the web interface.

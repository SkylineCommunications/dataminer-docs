---
uid: Connector_help_ND_Satcom_SKYWAN
---

# ND Satcom SKYWAN

The **ND Satcom SKYWAN** is a bidirectional MF-TDMA modem system that supports voice, video and data applications, with built-in IP routing, frame relay switching and support for multicast transmissions. The platform enables star, mesh, multi-star or hybrid topologies.

## About

This is an **SNMP-based connector** for the ND Satcom Skywan.

### Version Info

| **Range** | **Description**                | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                | No                  | Yes                     |
| 1.1.0.x          | Firmware update to version 1.3 | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                        |
|------------------|--------------------------------------------------------------------|
| 1.0.0.x          | IDU7000 (hardware version) / 7.200.73 (software version)           |
| 1.1.0.x          | Release 5G-IDU-1.3x / 1.3.83.85-full-1502181226 (software version) |

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage: Range 1.0.0.x

### General

This page contains information regarding the device itself, such as the **System Description**, **Uptime**, **Contact**, **Name**, **Location**, **Hardware** and **Software Version**.

It also displays the **Module** and **Licenses** tables.

### TDMA - Main

This page displays the **Es/No Reference**, **Es/No Target**, **Es/No Own** and **Circular Grade** values as analog graphs.

It contains information regarding the **Rx Lock**, **Frame** and **Slot Sync States**, **TPC**, **UFC**, **RTT**, **CRC Errors**, **TDMA** **Channel Input Power** and **Tx/Rx Frequency Offset**.

### TDMA - Advanced

This page contains data about the **TPC**, **SLL Address**, **Master State**, **UFC L-Band Frequency**, **10MHz Ref Signal Mode**, **Frame Plan CRC Errors** and **Missed Consecutive**, **Es/No Min**, **Es/No Mod** and **Es/No Max**.

It also contains the **Station Attenuation** table and the **Demodulator Measurement** page button, which displays the **Demodulator Measurement** table.

### Stats

This page shows the **TPC Stations Below Min**, **Above Mod** and **Above Max**.

It contains 7 page buttons:

- QOS Stats: Displays the **QOS Stats** table.
- QOS Configuration: Displays the **QOS Configuration** table.
- Satellite Tx Queue: Displays the **Satellite Tx Queue** table.
- Satellite Rx Queue: Displays the **Satellite Rx Queue** table.
- Internal Queue: Displays the **Internal Queue** table.
- TDMA Stats: Displays the following tables: **Frame Utilization**, **Total Assignment Own**, **Stream Assignment Own**, **Available Stream** and **Available Stream Max.**
- Interface Table: Displays the generic **Interface Table**, which includes the **Usage of Last Day** and **Current Day** for both **Rx and Tx**.

## Usage: Range 1.1.0.x

### General

This page contains information regarding the device itself, such as the **System Description**, **Uptime**, **Contact**, **Name**, **Location**, **Node Type**, **Node Name**, **Software Version**, **Serial Number** and **Key Validity**.

It also displays the **Licenses** table.

### TDMA - Main

This page displays the **Es/No Reference**, **Es/No** **Target**, **Es/No** **Own** and **Circular Grade** values as analog graphs.

It contains information regarding the **Station State**, **Frame Sync State**, **Circular State**, **Circular Grade**, **TPC Compression State**, **TPC Mode**, **RTT Confidence**, **Tx Frequency Offset**, and **Rx Frequency Offset**.

It also displays the **Demodulator Components**, **Demodulator Network Nodes** and **TDMA Station Tx Power** tables.

### TDMA - Advanced

This page contains data about the **TPC Ref Interval**, **TPC Beacon Status**, **SLL Address**, **UFC L-Band Frequency Offset Ref**, **Frame Plan CRC Errors**, **Frame Plans Missed Consecutive** and **Es/No Min, Mod and Max**.

It also contains two page buttons for the **Access Demodulators** and the **Calc Derived Channels.**

### Access Demodulators

This page displays the TDMA Channel Access Demodulators table, which contains information related to each channel, such as the **Component ID**, **Slot Synchronization State**, **Header CRC Error**, **Burst ID Errors**, **Rx Burst Buffer Overflows**, **Rx PLL Lock Alarms**, **Other Rx Pipe Errors**, **Slot synchronization Lost Count** and **Slot Synchronization Lost Time**.

### Calc Derived Channels

This page contains information about the **Base Slot Time**, **Frame Time** and **Frame Length** of the derived channels, as well as the **Calc Derived Channels** table, which contains specific information per channel.

### ODU

This page contains data about the **BUC** and **LNB**, including the **Local Oscillator Frequency**, the **Power Supply State** and reference signals.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

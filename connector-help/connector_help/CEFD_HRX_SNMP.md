---
uid: Connector_help_CEFD_HRX_SNMP
---

# CEFD HRX SNMP

The CEFD HRX SNMP connector is an SNMP connector intended to communicate with the Multi-Receiver Router devices named CEFD HRX, from Comtech.

## About

CEFD HRX devices are integrated in the Heights (CEFD H, HRX and HTO) Networking Platform, which is designed to enhance service **processing power**, **efficiency** and **intelligence**.

The most important features of the **Heights Networking Platform** are the following:

- Header and payload **compression engines** to maximize net efficiency while maintaining information integrity.
- **WAN** (Wide Area Network) **optimization** for internet traffic and **GTP** (GPRS Tunneling Protocol) **optimization** for mobile traffic, both designed to generate higher throughput and faster response time.
- **Multi-tier Quality of Service** (QoS) to ensure that the most important services and business applications are uninterrupted and continue to function properly.
- **Bandwidth and** **Power dynamic management.**
- **Bi-directional ACM** (Adapting Code and Modulation), enabling throughput maximization depending on traffic-affecting conditions and the required SLAs (Service Level Agreements).
- **QoE** (Quality of Experience) **maximization** by providing different layers of intelligence through network design tools and powerful analytics.

### Version Info

| **Range**         | **Description**                                                                                                                             | **DCF Integration** | **Cassandra Compliant** |
|--------------------------|---------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x                  | Initial Comtech Netvue-specific branch.                                                                                                     | No                  | Yes                     |
| 1.1.0.x                  | Comtech Netvue: Branched from 1.0.0.14 - supports firmware 3.1.x.                                                                           | No                  | Yes                     |
| 1.1.1.x                  | Comtech Netvue: Branched from 1.1.0.6 - updated parameter descriptions.                                                                     | No                  | Yes                     |
| 1.2.0.x                  | Comtech Netvue: Branched from 1.1.1.3 - supports firmware 3.2.x.                                                                            | No                  | Yes                     |
| 1.3.0.x                  | Comtech NetVue: Branched from 1.2.0.7 - updated mechanism to sync element data over multiple VMSs when element is in timeout after startup. | No                  | Yes                     |
| 2.0.0.x                  | Branched from 1.0.0.16 - removed Netvue-specific functionality in order to let the connector function outside a Netvue environment.            | No                  | Yes                     |
| 2.0.1.x **\[SLC Main\]** | Initial generic customer branch.                                                                                                            | No                  | Yes                     |

Supported firmware versions

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.1.0.x          | 3.1.x                       |
| 1.1.1.x          | 3.1.x                       |
| 1.2.0.x          | 3.2.x                       |
| 2.0.0.x          | 3.1.x                       |
| 2.0.1.x          | 3.1.x                       |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set Community string**: The community string used when setting values on the device. The default value is *private*.

## Usage \[Range 2.0.1.x\]

### General

This page displays general information about the device: **system information**, **contact information** and **device status parameters**. These parameters include the **Unit Alarms Status** and the **Device Working Mode** configuration.

### Admin

This page displays the state of several **device features**, such as Tx/Rx header/payload compression.

On the right side of the page, the **SNMP Trap Destination IP Address** and the **Auto Logout** feature can be configured.

The following page buttons are also available:

- **VMS**: Contains **configuration** (Network ID, Management Base Port and Multicast IP) and **status** parameters (VMS IP Address, Registration Status and VMS Version) related to the **Vipersat Management System**, which is used for dynamic bandwidth management.
- **Firmware**: Displays **Firmware Boot configuration** parameters and a **Firmware Table**, which shows the firmware state information related to the different slots.

### Configuration - Interface

This page displays the **Interface Table**, which contains information on the network interfaces present in the unit.

### Configuration - WAN - Demodulator

At the top of this page, the **global demodulator settings** can be configured, such as the **Local Oscillator Mix type** and **frequency**.

At the bottom of the page, the **Demodulator Configuration Table** lists configuration values of the tuners available in the demodulator unit.

### Configuration - WAN - ACM

This page contains the **configuration** table associated with the **ACM (Adapting Code and Modulation) reception**.

It also contains the **Rx ACM Events** page button, which displays a table that registers the Rx ACM events, if polling is enabled for the table.

### Configuration - WAN - LNB

This page allows you to configure the **Low-Noise Block Downconverter (LNB)** control parameters and to display the related status parameters.

### Configuration - Network

On this page, the **Routing Table** displays network topology information and the **ARP Table** can be used for network mapping.

The page contains several page buttons:

- Below the Routing Table, the **Add New Route** page button allows you to preconfigure the parameters for a new entry in the **Routing Table** and then add the entry by clicking the **Create** button.
- Below the **ARP Table**, the **Add Static ARP** page button allows you to preconfigure the parameters for a new entry in the **ARP Table** and then add the entry by clicking the **Create** button.
- The **Other Configs** page button displays settings related to **other network configurations** (e.g. Associated CEFD HTO static and dynamic IPs, etc.).

### Configuration - ECM

This page contains the following tables:

- The **ECM** **Channel Table**, which contains the configuration parameters of each ECM (**Ethernet Control Module**) channel (e.g. state, type, etc.).
- The **ECM Remotes Table**, which displays status information regarding the remote units connected to the hub.

A page button at the top allows you to set the **ECM Hub configuration** parameters (e.g. ECM Multicast IP, ECM Guard Band, etc.).

### Status - Statistics - Ethernet

This page contains tables with **statistical information** on the **Ethernet** traffic. This includes **global** statistics, such as the Bytes Received, Bytes Transmitted and Total Received Errors, and detailed **Rx/Tx** statistics such as the Total Packets Rx/Tx.

### Status - Statistics - Demodulator

This page contains the following tables:

- **Demodulator Status**: Displays status information for each Rx tuner, such as Lock State, BER, Signal Level, etc.
- **Demodulator Statistics**: Contains demodulator radio link statistics, including the Total/Unicast/Multicast Packets Received.

### Status - Statistics - Router

This page contains various **statistical data** regarding the **router operation**, such as the total, WAN and LAN received packets, packet errors and Rx/Tx management packets.

### Status - Statistics - Managed Switch

This page displays the **Managed Switch Rx/Tx** packet statistics.

### Status - Monitor - Alarms

This page displays the state of several **monitoring alarms**, such as Unit Alarms and Assigned HTO-1 IP Alarms.

Below this, the **Rx Alarms Table** logs the alarm events related to the Rx operation of the device.

The page also contains the following page buttons:

- **Unit Alarms**: Allows you to consult several unit alarm statuses and to configure the unit alarm masking.
- **Demodulator Alarms**: Displays two tables with entries related to the alarm states for each demodulator channel (**Demodulator Alarm State**) and the relevant mask configuration (**Demodulator Alarm Mask**).

### Status - Monitor - Events

This page displays a table that logs the **Unit Events**, if polling is enabled for the table.

### Utility

On the left side of this page, you can configure general settings for the **modem**, such as the Unit Name, Date/Time, Circuit ID, Warm Up Delay, etc.

On the right side of the page, the **Save/Load Configuration** section allows you to save and load modem configurations.

The page also contains the **Diagnostic** page button, which displays statistical information on the **Memory Usage** of the system, such as Free/Allocated Blocks, Free/Total Buffer Block Bytes, etc.

### Utility - BERT

This page displays the BERT (**Bit Error Rate Test**) **settings** and **monitoring** parameters.

### Traps

This page contains a table that is used to **log** **Trap Events**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage \[Other ranges than 2.0.1.x\]

### General

This page displays general information about the device: **system information**, **contact information** and **device status parameters** such as the **Unit Alarms Status** and the **Device Working Mode** configuration.

### Admin

This page displays the state of several **device features**, such as Tx/Rx header/payload compression, etc.

On the right side of the page, the **SNMP Trap Destination IP Address** and the **Auto Logout** feature can be configured.

The following two page buttons are also available:

- **VMS**: Contains **configuration** (Network ID, Management Base Port and Multicast IP) and status parameters (VMS IP Address, Registration Status and VMS Version) related to the **Vipersat Management System**, which is used for dynamic bandwidth management.
- **Firmware**: Displays **Firmware Boot configuration** parameters and a **Firmware Table**, which shows the firmware state information for the different machine slots.

### Configuration - Interface

This page displays the **Interface Table**, which contains information on the network interfaces present in the unit.

### Configuration - WAN - Demod

This page displays the **Demodulator Configuration Table**, containing the configuration values of the available tuners in the demodulator unit.

At the bottom of the page, the **global demodulator settings** can be configured (e.g. **Local Oscillator Mix type** and **frequency**).

### Configuration - WAN - ACM

This page contains two tables: the **configuration** table associated with the **ACM (Adapting Code and Modulation) reception** and a table that registers the **Rx ACM Events**, when polling for the table is enabled.

### Configuration - WAN - LNB

This page allows you to configure the **Low-Noise Block** **Downconverter (LNB)** control parameters and to display the related status parameters.

### Configuration - Network

On the right side of this page, you can find several parameters related to the HTO-1 and Working Mode configuration and parameters related to **other network configurations** (e.g. associated CEFD HTO static and dynamic IPs).

On the left side of the page, you can find the **ARP Table**, which is used for network mapping.

Below the ARP Table, the **Add Static ARP** page button allows you to preconfigure the parameters for a new entry in the **ARP Table** and then add it by clicking the **Create** button.

### Configuration - Network - Routing

This page displays the **Routing Table**, which contains network topology information.

Below the table, the **Add New Route** page button allows you to preconfigure the parameters for a new entry in the **Routing Table** and then add it by clicking the **Create** button.

### Configuration - ECM

This page contains the following tables:

- **ECM** **Channel Table**: Contains configuration parameters for each ECM (**Ethernet Control Module**) channel, such as the state, type, etc.
- **ECM Remotes Table**: Displays status information regarding the remote units connected to the hub.

In the top left corner of the page, you can also set **ECM Hub configuration** parameters, such as ECM Multicast IP, ECM Guard Band, etc.

### Status - Stats - Traffic

This page displays **statistical information** on the **Ethernet** traffic. This includes **global** statistics, such as the Bytes Received, Bytes Transmitted and Total Received Errors, and detailed **Rx/Tx** statistics, such as Total Packets Rx/Tx, etc.

### Status - Stats - Demod

This page contains the following tables:

- **Demodulator Status**: Displays status information for each Rx tuner, such as Lock State, BER, Signal Level, etc.
- **Demodulator Statistics**: Contains demodulator radio link statistics, including the Total/Unicast/Multicast Packets Received.

### Status - Stats - Router

This page contains various **statistical data** regarding the **router operation**, such as the total, WAN and LAN received packets, packet errors and Rx/Tx management packets.

### Status - Stats - Managed Switch

This page displays the **Managed Switch Rx/Tx** packet statistics.

### Status - Monitor - Alarms

This page displays the state of several **monitoring alarms**, such as Unit Alarms and Assigned HTO-1 IP Alarms.

Below this, the **Rx Alarms Table** logs the alarm events related to the Rx operation of the device.

The page also contains the following page buttons:

- **Unit Alarms**: Allows you to consult several unit alarm statuses and to configure the unit alarm masking.
- **Demodulator Alarms**: Displays two tables with entries related to the alarm states for each demodulator channel (**Demodulator Alarm State**) and the relevant mask configuration (**Demodulator Alarm Mask**).
- **BPM Alarms**: Allows you to consult the associated HTO-1 device alarm and mask status.

### Status - Monitor - Events

This page contains a table that logs the **Unit Events**, if polling is enabled for the table.

### Utility

On the left side of this page, you can configure general settings for the **modem**, such as the Unit Name, Date/Time, Circuit ID, Warm Up Delay, etc.

On the right side of the page, the **Save/Load Configuration** section allows you to save and load modem configurations.

The page also contains the following page buttons:

- **Diagnostic**: Contains statistical data on the **Memory Usage** of the system, such as Free/Allocated Blocks, Free/Total Buffer Block Bytes, etc.
- **Time Synchronization (Not present in range 2.0.0.x)**: Allows you to perform time synchronization in the system and configure synchronization settings.

### Utility - BERT

On this page, you can view the BERT (**Bit Error Rate Test**) **settings** and **monitoring** parameters.

### Traps

This page contains a table used to **log Trap Events**.

### FTP (Not present in range 2.0.0.x)

This page allows you to configure and execute FTP (**File Transfer Protocol**) **settings** related to the different network elements, such as Device IP, Device FTP Username/Password, Local Directory Path, FTP Action, etc.

Via the **Device Settings** page button, you can configure the device **FTP Username and Password**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

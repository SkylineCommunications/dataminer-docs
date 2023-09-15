---
uid: Connector_help_CEFD_HTO_SNMP
---

# CEFD HTO SNMP

The CEFD HTO SNMP connector is an SNMP connector intended to communicate with the Traffic Optimization Gateway Router devices named CEFD HTO, from Comtech.

## About

CEFD HTO devices are integrated in the Heights (CEFD H, HRX and HTO) Networking Platform, which is designed to enhance service **processing power**, **efficiency** and **intelligence**.

The most important features of the **Heights Networking Platform** are the following:

- Header and payload **compression engines** to maximize net efficiency while maintaining information integrity.
- **WAN** (Wide Area Network) **optimization** for internet traffic and **GTP** (GPRS Tunneling Protocol) **optimization** for mobile traffic, both designed to generate higher throughput and faster response time.
- **Multi-tier Quality of Service** (QoS) to ensure that the most important services and business applications are uninterrupted and continue to function properly.
- **Bandwidth and power dynamic management.**
- **Bi-directional ACM** (Adapting Code and Modulation), enabling throughput maximization depending on traffic-affecting conditions and the required SLAs (Service Level Agreements).
- **QoE** (Quality of Experience) **maximization** by providing different layers of intelligence through network design tools and powerful analytics.

### Version Info

| **Range**         | **Description**                                                                                                                  | **DCF Integration** | **Cassandra Compliant** |
|--------------------------|----------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x                  | Initial Comtech Netvue-specific branch.                                                                                          | No                  | Yes                     |
| 1.1.0.x                  | Comtech Netvue: Branched from 1.0.0.16 - supports firmware 2.4.1.                                                                | No                  | Yes                     |
| 1.2.0.x                  | Comtech Netvue: Branched from 1.1.0.13 - supports firmware 2.6.1.                                                                | No                  | Yes                     |
| 1.3.0.x                  | Comtech Netvue: Branched from 1.2.0.1 - supports firmware 3.x.                                                                   | No                  | Yes                     |
| 1.3.1.x                  | Comtech Netvue: Branched from 1.3.0.10 - layout + SNMP type tags fix.                                                            | No                  | Yes                     |
| 1.4.0.x                  | Comtech Netvue: Branched from 1.3.1.5 - rearranged Netvue IDs functionality.                                                     | No                  | Yes                     |
| 1.5.0.x                  | Comtech NetVue: Branched from 1.4.0.15 - updated mechanism to sync element data over multiple VMSs.                              | No                  | Yes                     |
| 1.5.1.x                  | Comtech NetVue: Support for Mobility/PICO.                                                                                       | No                  | Yes                     |
| 1.5.2.x **\[SLC Main\]** | Comtech NetVue: Branched from 1.5.1.14 - supports MODCOD changes.                                                                | No                  | Yes                     |
| 1.6.0.x                  | Comtech NetVue: Support for new architecture - not currently released.                                                           | No                  | Yes                     |
| 2.0.0.x                  | Branched from 1.1.0.15 - removed Netvue-specific functionality in order to let the connector function outside a Netvue environment. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.x.x.x          | Unknown                     |
| 1.1.0.x          | 2.4.1                       |
| 1.2.0.x          | 2.6.1                       |
| 1.3.0.x          | 3.x                         |
| 1.3.1.x          | 3.x                         |
| 1.4.0.x          | 3.x                         |
| 1.5.0.x          | 4.x                         |
| 1.5.1.x          | 4.3.x                       |
| 1.5.2.x          | 4.3.x                       |
| 1.6.0.x          | 4.3.x                       |
| 2.0.0.x          | 3.x                         |

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

## Usage \[Range 2.0.0.x\]

### General

This page displays general information about the device: **system information**, **contact information** and several **device status parameters.**

These status parameters include **status alarms** (e.g. Tx/Rx Alarms) and **signal quality** parameters (Es/No, BER). In addition, the device **Working Mode**, **WAN Operational State** and **Encryption Feature** can be configured.

### Admin

This page displays the state of several **device features**, such as Tx/Rx header/payload compression and Quality of Service options.

On the right side of the page, the **SNMP Trap Destination IP Address** and the **Auto Logout** feature can be configured.

The following page buttons are also available:

- **VMS**: Contains **configuration** (Network ID, Management Base Port and Multicast IP) and **status** parameters (VMS IP Address, Registration Status and VMS Version) related to the **Vipersat Management System**, which is used for dynamic bandwidth management.
- **Firmware**: Displays **Firmware Boot configuration** parameters and two **Firmware tables**, which show the firmware state and firmware packages for the different slots.

### Configuration - Interface

This page displays the **Interface Table**, which contains information on the network interfaces present in the unit.

### Config - WAN - Mod

This page contains **modulator** **configuration** parameters, such as Data Rate, FEC Type, Roll-off, Transmitter RF Frequency, etc.

On the right side of the page, you can also find the beacon configuration and status parameters.

### Config - WAN - QoS - Capacity Group

This page contains the **QoS Capacity Group** **Table**. A QoS capacity group is the highest level of QoS that allows the outbound carrier to be subdivided.

### Config - WAN - QoS - QoS Group

This page contains the following tables:

- **QoS Group** **Table:** A QoS group is a QoS level that represents a reservation of bandwidth within a QoS capacity group.
- **QoS Rules Table**
- **DiffServ Table**

The page also contains the following page buttons:

- **QoS Group Attribute**: Displays the **QoS Group VLAN Table** and **QoS Group Subnet Table.**
- **QoS Group Site**: Displays the **QoS Remote Site Table**.

### Config - WAN - Compression

This page allows you to enable or disable **header/payload compression** and configure the respective refresh rates.

### Config - WAN - Encryption

This page allows you to enable or disable the **Encryption Feature** and select the active key option.

Via the **Encryption/Decryption Keys** page button, you can preconfigure the encryption keys.

### Config - WAN - Remote Sites

This page contains the following tables:

- The **Remote Site List table**, which contains information on the device communication with the associated remote sites (e.g. Remote Site IP Address, currently assigned MODCOD, last Es/No, etc.).
- The **ACM Events log table**.

### Config - WAN - BUC

This page allows you to configure the **Block Upconverter (BUC)** control parameters and to display the related status parameters.

### Config - Network

On the left side of this page, you can find the **ARP Table**, which is used for network mapping. On the right side, you can find several **PTP** (Precision Time Protocol) and **Working Mode** configuration parameters.

Below the ARP Table, the **Add Entry** page button allows you to preconfigure the parameters for a new entry in the **ARP Table** and then add the entry by clicking the **Create** button.

### Config - Network - Routing

At the top of this page, you can **enable/disable** the **RIP** (Routing Information Protocol), the **CDRP** (Comtech Dynamic Routing Protocol) and the respective header and payload **dynamic compression**.

Below this, the **Routing Table** displays network topology information.

Finally, at the bottom of the page, the **Add Entry** page button allows you to preconfigure the parameters for a new entry in the **Route Table** and then add the entry by clicking the **Create** button.

### Status - Statistics - Traffic

This page contains tables with **statistical information** on the **Ethernet** traffic. This includes **global** statistics, such as the Bytes Received, Bytes Transmitted and Total Received Errors, and detailed **Rx/Tx** statistics, such as the Total Packets Rx/Tx.

### Status - Statistics - Network

This page displays general statistics related to the network, such as the **LAN/WAN Interface Rx/Tx Packets** count, the **Router Received/Routed Packets** and **Error** count, the total **Management Rx/Tx Packets** and the number of **Rx/Tx** **Satellite Frames**.

The page contains the following page buttons:

- **DNS**: Displays DNS (**Domain Name System**) statistics (DNS Requests and Cache Hits count and percentage).
- **PTP**: Displays both **LAN** and **WAN** PTP (Precision Time Protocol) packet statistics.
- **Managed Switch**: Displays WAN and LAN Rx/Tx packet statistics for the managed switch.

### Status - Statistics - Compression

This page displays general, header and payload **compression**/**decompression** statistics.

### Status - Statistics - QoS - Capacity Group

This page contains the **QoS Capacity Group Stats table** and other statistical information on the QoS capacity group communication, such as Data and Packet Rates, Transmitted/Dropped Packets, etc.

### Status - Statistics - QoS - QoS Group

This page contains the **QoS Group Stats table** and other statistical information on the QoS group communication, such as Data and Packet Rates, Transmitted/Dropped Packets, etc.

### Status - Statistics - Outbound

This page displays statistical info on the **outbound MODCOD communications**, such as Current Throughput, Management System Frames Sent, etc.

### Status - Statistics - Remote Sites

This page displays the **Remote Site Stats Table**, which contains statistics related to the communication with the remote sites, such as the Remote Site Transmission Current Rate.

### Status - Monitor - Events

This page contains a table that logs the **Unit Events**, if polling is enabled for the table.

### Status - Monitor - Alarms

This page displays the state of the **HTX-450, HTO-1, BUC and PTP Monitoring Alarms**.

The **Masks** page button allows you to configure the HTX-450 and HTO-1 unit alarm masking, as well as the BUC and PTP alarm masking.

### Utility

On the left side of this page, you can configure general settings for the **modem**, such as the Unit Name, Date/Time, Circuit ID, Warm Up Delay, etc.

On the right side of the page, the **Save/Load Configuration** section allows you to save and load modem configurations. In the **Geographical Log Information** section, you can fill in various fields and then click the Add button in order to add GPS log info into the system.

The table also contains the **Diagnostic** page button, which displays statistical information on the **Memory Usage** of the system, such as Free/Allocated Blocks, Free/Total Buffer Block Bytes, etc.

### Traffic

This page displays the **Interfaces table**, which contains **traffic statistics** related to the different interfaces of the device.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

---
uid: Connector_help_CEFD_H_SNMP
---

# CEFD H SNMP

The CEFD H SNMP connector is an SNMP connector intended to communicate with the Advanced VSAT Series Remote Router devices named CEFD H, from Comtech.

## About

CEFD H devices are integrated in the Heights (CEFD H, HRX & HTO) Networking Platform, which is designed to enhance service **processing power**, **efficiency** and **intelligence**.

The most important features of the **Heights Networking Platform** are:

- Header and payload **compression engines** to maximize net efficiency while maintaining information integrity.
- **WAN** (Wide Area Network) **optimization** for internet traffic and **GTP** (GPRS Tunneling Protocol) **optimization** for mobile traffic, both designed to generate higher throughput and faster response time.
- **Multi-tier Quality of Service** (QoS) to ensure that the most important services and business applications are not interrupted and continue to function properly.
- **Bandwidth and power dynamic management**.
- **Bi-directional ACM** (Adapting Code and Modulation), enabling throughput maximization depending on traffic-affecting conditions and the required SLAs (Service Level Agreements).
- **QoE** (Quality of Experience) **maximization** by providing different layers of intelligence through network design tools and powerful analytics.

### Version Info

| **Range**         | **Description**                                                                                                                | **DCF Integration** | **Cassandra Compliant** |
|--------------------------|--------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x                  | Initial Comtech Netvue-specific branch                                                                                         | No                  | Yes                     |
| 1.1.0.x                  | Comtech Netvue: Branched from 1.0.0.13 - supports firmware 2.4.1                                                               | No                  | Yes                     |
| 1.2.0.x                  | Comtech Netvue: Branched from 1.1.0.7 - supports firmware 2.6.1                                                                | No                  | Yes                     |
| 1.3.0.x                  | Comtech NetVue: Branched from 1.2.0.2 - supports firmware 3.x                                                                  | No                  | Yes                     |
| 1.3.1.x                  | General changes: Parameters descriptions, text and subtext.                                                                    | No                  | Yes                     |
| 1.4.0.x                  | General changes. NetVue 3.2.                                                                                                   | No                  | Yes                     |
| 1.4.1.x                  | Pico.                                                                                                                          | No                  | Yes                     |
| 1.5.0.x                  | General changes. NetVue 4.0.x.                                                                                                 | No                  | Yes                     |
| 1.5.1.x                  | Mobility/PICO changes for NV 4.3.x                                                                                             | No                  | Yes                     |
| 2.0.0.x                  | Branched from 1.2.0.2: Removed Netvue-specific functionality in order to let the connector function outside a Netvue environment. | No                  | Yes                     |
| 2.0.1.x **\[SLC Main\]** | Initial generic customer branch.                                                                                               | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.1.0.x          | 2.4.1                       |
| 1.2.0.x          | 2.6.1                       |
| 1.3.0.x          | 3.x                         |
| 1.4.0.x          | 3.2.x                       |
| 1.4.1.x          | 3.2.x                       |
| 1.5.0.x          | 4.0.x                       |
| 1.5.1.x          | 4.3.x                       |
| 2.0.0.x          | 2.6.1                       |
| 2.0.1.x          | 2.6.1                       |

### Exported connectors

| **Exported Connector**                                              | **Description**           |
|--------------------------------------------------------------------|---------------------------|
| [CEFD H SNMP - FSK](xref:Connector_help_CEFD_H_SNMP_-_FSK) | FSK Functionality Module. |

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

This page displays general information about the device: **system information**, **contact information** and several **device status parameters**.

These status parameters include **status alarms** (e.g. Tx/Rx Alarms) and **signal quality** parameters (Es/No, BER). In addition, the device **Working Mode**, **WAN Operational State** and **Encryption Feature** can be configured.

### Admin

This page displays the state of several **device features**, such as Tx/Rx header/payload compression and Quality of Service options.

On the right side of the page, the **SNMP Trap Destination IP Address** and the **Auto Logout** feature can be configured.

The following page buttons are also available:

- **VMS:** Contains **configuration** (Network ID, Management Base Port and Multicast IP) and **status** parameters (VMS IP Address, Registration Status and VMS Version) related to the **Vipersat Management System**, which is used for dynamic bandwidth management.
- **Firmware**: Displays **Firmware Boot configuration** parameters and a **Firmware Table**, which shows the operating status for the firmware versions loaded into the different slots.

### Configuration - Interface

This page displays the following tables:

- **Interface Table:** Displays the network interfaces present in the unit.
- **Ethernet Port Configuration Table:** Displays link state information and the configuration of the Ethernet switch per port.

### Configuration - WAN - Demodulator

At the top of this page, you can find the **Demodulator Configuration Table**, containing the configuration values for the (Active and Alternate) tuners in the demodulator unit. **Switch configuration** and **Receive WAN Labels** parameters are also available.

The page also contains the **Rx ACM** page button, which displays the configuration and status parameters related to the **active reception tuner ACM** (Adapting Code & Modulation).

### Configuration - WAN - Modulator

On the left side of this page, you can find **configuration** parameters for the **Modulator** unit, such as Data Rate, FEC Type, Roll-off, etc.

The right side of the page contains the **RTI** (Receive Transmit Inhibit) configuration, and the **VMS status** parameters, such as VMS state, MODCOD, Symbol Rate, etc.

The page also contains the following page buttons:

- **Tx ACM**: Displays the configuration and status parameters related to the **transmission ACM** (Adapting Code and Modulation).
- **Tx ACM Events**: Displays a table that registers the **Tx ACM Events**, if polling is enabled for the table.
- **DPC**: Displays the DPC (**Dynamic Power Control**) configuration and status parameters.

### Configuration - WAN - QoS

This page displays the **QoS Groups** (QoS levels that represent a reservation of bandwidth) and the **QoS Rules tables**. These tables allow you to configure the different QoS groups (including the Priority Mechanism, CIR, MIR, etc.) and QoS rules (including Source/Destination IP/Mask, Port Info, Min/Max Bandwidth, Priority, Network Scheduler Discipline, etc.).

The page also contains the following page buttons:

- **Create New Entry (below QoS Rules and Group tables)**: These two subpages allow you to preconfigure the parameters for a new entry in the **QoS Rules table** and in the **QoS Group table**, respectively, and to add this configuration by clicking the **Create** button.
- **QoS Group Attribute**: Displays the **QoS Group VLANs** and **QoS Group Subnets tables**, which list the different VLANs and subnets configured in the system.
- **DiffServ**: Displays a table used for the configuration of the **DiffServ** (Differentiated Services) architecture, when available.

### Configuration - WAN - Compression

This page can be used to enable or disable **Header/Payload Compression** and to configure the respective refresh rates.

You can also enable or disable the **Encryption Feature** and select the active key option.

Via the **Encryption/Decryption Keys** page button, the encryption keys can be preconfigured.

### Configuration - WAN - BUC

On this page, you can configure the **Block Upconverter (BUC)** control parameters and display the related status parameters.

### Configuration - WAN - LNB

On this page, you can configure the **Low-Noise Block** **Downconverter (LNB)** control parameters and display the related status parameters.

### Configuration - Network

At the top of this page, you can set the **Working Mode Configuration** and the **DNS Caching State** parameters.

Two tables are displayed below this: the **Routing Table** displays network topology information and the **ARP Table** can be used for network mapping.

The page contains the following page buttons:

- **Add New Route** (below the Routing Table): Allows you to preconfigure the parameters for a new entry in the **Routing Table** and add the entry by clicking the **Create** button.
- **Add Static ARP** (below the ARP Table): Allows you to preconfigure the parameters for a new entry in the **ARP Table** and add the entry by clicking the **Create** button.
- **DHCP**: Displays the DHCP (Dynamic Host Configuration Protocol) configuration parameters (Feature State and Relay Address).
- **IGMP**: Displays the IGMP (Internet Group Management Protocol) configuration parameters (e.g. IGMP Version, Query/Response Interval, etc.) and the IGMP Multicast Table, which displays information regarding the currently established multicast membership groups.

### Configuration - ECM

This page contains the ECM (**Ethernet Control Module**) status and configuration parameters, such as ECM Multicast IP and ECM Power.

The page also contains the **ECM Rid** page button, which displays the ECM Rid status parameters.

### Configuration - dSCPC

This page contains dSCPC (**Dynamic Single Channel per Carrier**) system configuration parameters, based on **Load Switching** (e.g. Load Switching State, Excess Capacity, etc.) and **ToS (Type of Service) Switching**, used to dynamically resize the carrier based on the amount of data sent over the link.

At the bottom of the page, the **ToS Switch Table** displays information regarding the different service types.

The page also contains the **Create New Entry** page button, which allows you to preconfigure the parameters for a new entry in the **ToS Switch Table** and add the entry by clicking the **Create** button.

### Configuration - MEO

This page contains the **configuration** parameters for the **antenna handover** process, such as the Antenna Handover Partner IP and Mode, etc.

### Configuration - Roaming

On the left side of this page, you can find the **Roaming Status** and **operational configuration** parameters, such as Roaming State, Service Area ID, Service Area Handoff ID, etc.

The right side of the page displays the ACU (**Antenna Control Unit**) status and configuration parameters, such as ACU Config Protocol, IP, Frequency Band, ACU Total Poll Count, etc.

### Configuration - Roaming Service

This page contains two tables with roaming service information. The first table lists the specifications of the different **Roaming Service Areas** (e.g. Frequency, Bandwidth, etc.), the second contains the **Roaming Service Bound** info (Beam Offset, ID, Area ID).

### Status - Statistics - Network

This page contains general statistical data related to the network, such as the **LAN/WAN Interface Rx/Tx Packets** count, the **Router Received/Routed Packets** and **Error** count, the total **Management Rx/Tx Packets** and the number of **Rx/Tx** **Satellite Frames**.

The page also contains the following page buttons:

- **DNS**: Displays DNS (**Domain Name System**) statistics (DNS Requests and Cache Hits count and percentage).
- **PTP**: Displays both **LAN** and **WAN** PTP (Precision Time Protocol) packet statistics.
- **Managed Switch**: Displays WAN and LAN Rx/Tx packet statistics for the managed switch.

### Status - Statistics - WAN Operation

This page contains **statistical data** on the WAN (**Wide Area Networks**) operation of the device, such as WAN Operation Bytes Processed, LAN/WAN Connections, etc.

### Status - Statistics - Ethernet

This page contains tables with **statistical information** on the **Ethernet** traffic. This includes **global** **statistics**, such as the Bytes Received, Bytes Transmitted and Total Received Errors, and detailed **Rx/Tx** statistics such as the Total Packets Rx/Tx.

### Status - Statistics - Mod/Demod

This page contains the following tables:

- **Modulator Statistics**: Contains modulator radio link statistics, including the Total/Unicast/Multicast Packets Transmitted.
- **Demodulator Status:** Displays status info for each Rx tuner, such as Lock State, BER, Signal Level, etc.
- **Demodulator Statistics**: Contains demodulator radio link statistics, including the Total/Unicast/Multicast Packets Received.

### Status - Statistics - Compression

This page displays general, header and payload **compression**/**decompression** statistics.

### Status - Statistics - QoS

This page displays **statistics** regarding both the implemented **QoS Rules** (e.g. Rule Tx/Dropped Packets, etc.) and **QoS Groups** (e.g. Group Total Dropped Packets, Committed/Maximum Information Rate and Tx Data Rate, etc.).

### Status - Monitor

This page contains information on the **Unit Temperature** and on the different **Alarm Statuses** (e.g. Unit Alarm, Ethernet Traffic Alarm, etc.).

### Status - Monitor - Events

This page contains a table that logs the **Unit Events**, if polling is enabled for the table.

### Status - Monitor - Alarms

This page displays the state of the **Unit**, **Rx**, **Demodulator**, **BUC**, **LNB**, **Ethernet**, **PTP**, **FPGA** and **Tx/Rx FPGA Monitoring Alarms**.

The page contains the following page buttons:

- **Unit Alarm Masks**: Allows you to configure unit alarm masking.
- **BUC Alarm Masks**: Allows you to configure BUC alarm masking.
- **LNB Masks**: Allows you to configure LNB alarm masking.
- **Ethernet Masks**: Allows you to configure Ethernet alarm masking.
- **PTP Masks**: Allows you to configure PTP alarm masking.
- **Frequency Offset Masks**: Allows you to configure modulator frequency offset alarm masking.
- **FPGA Load Alarm Masks**: Allows you to configure FPGA alarm masking.
- **Rx Masks**: Allows you to configure demodulator alarm masking.
- **Tx/Rx FPGA Masks**: Allows you to configure Tx/Rx FPGA alarm masking.

### Utility

On the left side of this page, you can configure general settings for the **modem**, such as the Unit Name, Date/Time, Circuit ID, Warm Up Delay, etc.

On the right side of the page, the **Save/Load Configuration** section allows you to save and load modem configurations. In the **Geographical Log Information** section, you can fill in various fields and then click the Add button in order to add GPS log info to the system.

The page also contains the **Diagnostic** page button, which displays statistical information on the **Memory Usage** of the system, such as Free/Allocated Blocks, Free/Total Buffer Block Bytes, etc.

### Utility - BERT / Redundancy

On this page, you can view the BERT (**Bit Error Rate Test**) monitoring parameters and configure BERT-related settings. You can also configure settings used for the **System Redundancy**, **Console Configuration** and **Satellite Delay**.

### Traps

This page contains a table used to **log trap events**.

### FSK

This page provides access to FSK functionality and is used for the creation of virtual elements. It contains the following parameters:

- **FSK Enabled**: Allows you to enable or disable the FSK functionality.
- **FSK Element Name:** Allows you to set the name used to represent the element.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage \[All ranges except 2.0.1.x\]

### General

This page displays general information about the device: **system information**, **contact information** and several **device status parameters.**

These status parameters include **status alarms** (e.g. Tx/Rx Alarms) and **signal quality** parameters (Es/No, BER). In addition, the device **Working Mode**, **WAN Operational State** and **Encryption Feature** can be configured.

### Admin

This page displays the state of several **device features**, such as Tx/Rx header/payload compression and Quality of Service options.

On the right side of the page, the **SNMP Trap Destination IP Address** and the **Auto Logout** feature can be configured.

The following page buttons are also available:

- **VMS**: Contains **configuration** (Network ID, Management Base Port and Multicast IP) and **status** parameters (VMS IP Address, Registration Status and VMS Version) related to the **Vipersat Management System**, which is used for dynamic bandwidth management.
- **Firmware**: Displays **Firmware Boot configuration** parameters and a **Firmware Table**, which shows the operating status for the firmware versions loaded into the different slots.

### Configuration - Interface

This page displays the following tables:

- **Interface Table:** Displays the network interfaces present in the unit.
- **Ethernet Port Configuration Table:** Displays link state information and the configuration of the Ethernet switch per port.

### Configuration - WAN - Demod

At the top of this page, you can find the **Demodulator Table**, containing the configuration values for the (Active and Alternate) tuners in the demodulator unit. **Switch configuration** and **Receive WAN Labels** parameters are also available.

The page also contains the **Rx ACM** page button, which displays the configuration and status parameters related to the **active reception tuner ACM** (Adapting Code & Modulation).

### Configuration - WAN - Mod

On the left side of this page, you can find **configuration** parameters for the **Modulator** unit, such as Data Rate, FEC Type, Roll-off, etc.

The right side of the page contains the **RTI** (Receive Transmit Inhibit) configuration, and the **VMS status** parameters, such as VMS state, MODCOD, Symbol Rate, etc.

The page also contains the following page buttons:

- **Tx ACM**: Contains the configuration and status parameters related to the **transmission ACM** (Adapting Code and Modulation). The subpage includes the **Tx** **ACM Table**, with status info on each available transmitter, and the **TW ACM Events** table, which registers Tx ACM events, if polling is enabled for the table.
- **DPC**: Displays the DPC (**Dynamic Power Control**) configuration and status parameters.

### Configuration - WAN - QoS

This page displays the **QoS Groups** (QoS levels that represent a reservation of bandwidth) and the **QoS Rules tables**. These tables allow you to configure the different QoS Groups (including the Priority Mechanism, CIR, MIR, etc.) and QoS Rules (including Source/Destination IP/Mask, Port Info, Min/Max Bandwidth, Priority, Network Scheduler Discipline, etc.).

The table also contains the following page buttons:

- **Create New Entry (below QoS Rules and Group tables)**: These two subpages allow you to preconfigure the parameters for a new entry in the **QoS Rules Table** and in the **QoS Group Table**, respectively, and to add this configuration by clicking the **Create** button.
- **QoS Group Attribute**: Displays the **QoS Group VLAN Table** and **QoS Group Subnet Table**, which list the different VLANs and subnets configured in the system.
- **DiffServ**: Displays a table used for configuration of the **DiffServ** (Differentiated Services) architecture, when available.

### Configuration - WAN - Compression

This page can be used to enable or disable **Header/Payload Compression** and to configure the respective refresh rates.

You can also enable or disable the **Encryption Feature** and select the active key option.

Via the **Encryption/Decryption Keys** page button, the encryption keys can be preconfigured.

### Configuration - WAN - BUC/LNB

On this page, you can configure the **Block Upconverter (BUC)** and the **Low-Noise Block** **Downconverter (LNB)** control parameters and display the related status parameters.

### Configuration - WAN - WANOp

This page allows you to enable or disable the device WAN operation.

### Configuration - Network

On the right side of this page, you can set the **Working Mode Configuration** and **DNS Caching State** parameters.

Two tables are displayed on the left side: the **Routing Table** displays network topology information and the **ARP Table** can be used for network mapping.

The page contains the following page buttons:

- **Add New Route** (below the Routing Table): Allows you to preconfigure the parameters for a new entry in the **Routing Table** and add the entry by clicking the **Create** button.
- **Add Static ARP** (below the ARP Table): Allows you to preconfigure the parameters for a new entry in the **ARP Table** and add the entry by clicking the **Create** button.
- **DHCP**: Contains the DHCP (Dynamic Host Configuration Protocol) configuration parameters (Feature State and Relay Address).
- **IGMP**: Contains the IGMP (Internet Group Management Protocol) configuration parameters (e.g. IGMP Version, Query/Response Interval, etc.) and the IGMP Multicast Table, which displays information regarding the currently established multicast membership groups.

### Configuration - ECM

This page contains the ECM (**Ethernet Control Module**) status and configuration parameters, such as ECM Multicast IP and ECM Power.

The page also contains the **ECM Rid** page button, which displays the ECM Rid status parameters.

### Configuration - dSCPC

This page contains dSCPC (**Dynamic Single Channel per Carrier**) system configuration parameters, based on **Load Switching** (e.g. Load Switching State, Excess Capacity, etc.) and **ToS (Type of Service) Switching**, used to dynamically resize the carrier based on the amount of data sent over the link.

At the bottom of the page, the **ToS Switch Table** displays information regarding the different service types.

The page also contains the **Create New Entry** page button, which allows you to preconfigure the parameters for a new entry in the **ToS Switch Table** and add the entry by clicking on the **Create** button.

### Configuration - MEO

This page contains the **configuration** parameters for the **antenna handover** process, such as Antenna Handover Partner IP and Mode, etc.

### Configuration - Roaming

On the left side of this page, you can find the **Roaming Status** and **operational configuration** parameters, such as Roaming State, Service Area ID, Service Area Handoff ID, etc.

The right side of the page displays the ACU (**Antenna Control Unit**) status and configuration parameters, such as ACU Config Protocol, IP, Frequency Band, ACU Total Poll Count, etc.

### Configuration - Roaming Service

This page contains two tables with roaming service information. The first table lists the specifications of the different **Roaming Service Areas** (e.g. Frequency, Bandwidth, etc.), the second contains the **Roaming Service Bound** info (e.g. Beam Offset, ID, Area ID).

### Status - Stats - Traffic

This page contains tables with **statistical information** on the **Ethernet** traffic. This includes **global** statistics, such as the Bytes Received, Bytes Transmitted and Total Received Errors, and detailed **Rx/Tx** statistics, such as the Total Packets Rx/Tx.

In addition, you can also find the following **statistical information** here:

- **Modulator** Radio link statistics: Total/Unicast/Multicast Packets Transmitted, etc.
- **Demodulator** Radio link statistics: Total/Unicast/Multicast Packets Received, etc.
- Statistics related to the WAN (**Wide Area Networks**) operation of the device: WAN Operation Bytes Processed, LAN/WAN Connections, etc.

### Status - Stats - Demod

This page displays the **Demodulator Status** Table, which contains status info on each Rx tuner, such as Lock State, BER, Signal Level, etc.

### Status - Stats - Network

This page displays general statistical data related to the network, such as the **LAN/WAN Interface Rx/Tx Packets** count, the **Router Received/Routed Packets** and **Error** count, the total **Management Rx/Tx Packets** and the number of **Rx/Tx** **Satellite Frames**.

The page also contains the following page buttons:

- **DNS**: Displays DNS (**Domain Name System**) statistics (DNS Requests and Cache Hits count and percentage).
- **PTP**: Displays both **LAN** and **WAN** PTP (Precision Time Protocol) packet statistics.
- **Managed Switch**: Displays WAN and LAN LAN Rx/Tx packet statistics for the managed switch.

### Status - Stats - Compression

This page displays general, header and payload **compression**/**decompression** statistics.

### Status - Stats - QoS

This page displays **statistics** regarding both the implemented **QoS Rules** (e.g. Rule Tx/Dropped Packets, etc.) and **QoS Groups** (e.g. Group Total Dropped Packets, Committed/Maximum Information Rate and Tx Data Rate, etc.).

### Status - Monitor

This page contains information on the **Unit Temperature** and on the different **Alarm Statuses** (e.g. Unit Alarm, Ethernet Traffic Alarm, etc.).

### Status - Monitor - Events

This page contains a table that logs the **Unit Events**, if polling is enabled for the table.

### Status - Monitor - Alarms

This page displays the state of the **Unit**, **Rx**, **Demodulator**, **BUC**, **LNB**, **Ethernet**, **PTP**, **FPGA** and **Tx/Rx FPGA Monitoring Alarms**.

The page contains the following page buttons:

- **Unit Alarm Masks**: Allows you to configure unit alarm masking.
- **BUC Alarm Masks**: Allows you to configure BUC alarm masking.
- **LNB Masks**: Allows you to configure LNB alarm masking.
- **Ethernet Masks**: Allows you to configure Ethernet alarm masking.
- **PTP Masks**: Allows you to configure PTP alarm masking.
- **Frequency Offset Masks**: Allows you to configure modulator frequency offset alarm masking.
- **FPGA Load Alarm Masks**: Allows you to configure FPGA alarm masking.
- **Rx Masks**: Allows you to configure demodulator alarm masking.
- **Tx/Rx FPGA Masks**: Allows you to configure Tx/Rx FPGA alarm masking.

### Utility

On the left side of this page, you can configure general settings for the **modem**, such as the Unit Name, Date/Time, Circuit ID, Warm Up Delay, etc.

On the right side of the page, the **Save/Load Configuration** section allows you to save and load modem configurations. In the **Geographical Log Information** section, you can fill in various fields and then click the Add button in order to add GPS log info to the system.

The page also contains the following page buttons:

- **Diagnostic**: Displays statistical data on the **Memory Usage** of the system, such as Free/Allocated Blocks, Free/Total Buffer Block Bytes, etc.
- **Time Synchronization** (not present in range 2.0.0.x): Allows you to perform time synchronization in the system and configure synchronization settings.

### Utility - BERT / Redundancy

On this page, you can view the BERT (**Bit Error Rate Test**) monitoring parameters and configure BERT-related settings. You can also configure settings used for the **System Redundancy**, **Console Configuration** and **Satellite Delay**.

### Traps

This page contains a table used to **log trap events**.

### FTP (Not present in range 2.0.0.x)

This page allows you to configure and execute FTP (**File Transfer Protocol**) **settings** related to the different network elements, such as Device IP, Device FTP Username/Password, Local Directory Path, FTP Action, etc.

### FSK

This page provides access to FSK functionality and is used for the creation of virtual elements. It contains the following parameters:

- **FSK Enabled**: Allows you to enable or disable the FSK functionality.
- **FSK Element Name**: Allows you to set the name used to represent the element.

### External Requests (Not present in range 2.0.0.x)

This page contains information related to the external request messages sent to the protocol.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

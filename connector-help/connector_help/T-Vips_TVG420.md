---
uid: Connector_help_T-Vips_TVG420
---

# T-Vips TVG420

The **T-Vips TVG420** connector is an SNMP-based connector used to monitor and configure the **T-Vips TVG420**. The device settings can be monitored and changed using the **TVG420** connector.

## About

The **TVG420** provides a monitoring interface to the **T-Vips TVG420** IP Video Gateway device.

### Product Info

Firmware version 3.26.12 has been tested to return the majority of the parameters implemented in the below versions of the protocol.

Other firmware versions, such as 1.4.0 and 3.6.38, may also be used but will only return a limited number of parameters.

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.26.12                     |
| 1.1.0.x          | 3.26.12                     |
| 2.1.1.x          | 3.26.12                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General

In **General Page** you can find the **Port Configuration Table** which represt the **Direction** the **Port** is running on, either *IP -\> ASI* or *ASI -\> IP*. Also, there is a **Production Information** panel with the general information about the device.

### Ethernet

The **Interface Table** is found here with **IP Address**, **Speed**, and **MAC Address**. Another table found is the **Address Translation Table** with **MAC Address** and **IP Address**.

### IP Tx

There are two Configuration tables and two status tables. The **TX Input Configuration Table** let's you see the **Input** *state* and the **Keep 204 Bytes** *state*, as well as changing the **Name** of the row. the **TX IP Transmission Table** let's you see the **Transmission** *state*, **Destination IP**, **Protocol** (*UDP* or *RDP*), and also some information about the transmission. On the status side, the **TX Input Status Table** will show you the **Sync** *state*, **Packet length**, **ASI Total Bit Rate**, and **ASI Effective Bit Rate**. The **TX IP Status Table** will show you **IP Resolved** *state*, **MAC Address**, **Ethernet Total Rate,** and **FEC Mode**. You can also find three page buttons that represent **VLAN,** **RIP-2,** and **FEC**.

### IP Rx

First thing you will see on this page is the **IGMP Version**. Next, the page has a similar structure as the **IP TX Page.** The **RX Output Configuration Table** will let you change the **Name** and **Output** *state*, as well as see the **Packet Length**. The **RX IP Parameters Table** shows the **Receive Port**, **Multi Cast Mode**, **Multi Cast IP**, and the **Multi Cast Source IP**. On the status side, the **RX Output Status Table** comes with the **IP Total Rate** and the **ASI Effective Rate**. Last table is the **RX IP Status Table** that comes with **Locked** *state*, **Buffer Usage**, **Latency**, **Protocol** *status*, **Packets per Frame**, **Sequence Errors**, and **Lost IP Frames**. There are also two page buttons on this page to represent **IP RX Extra**, and IP **RX Status**.

### Alarms

This page contains **Alarm Status** information for the device, and to pick some more examples, there are things like **Data Loss Alarm,** **Lock Alarm**, **Sync Alarm**, **Temperature alarm**, among others.

### Trap Destinations

This page displays the **Trap Destination** and the **Trap Status.** You can also **Add SNMP Tram Destination**.

### Web Interface

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to display the web interface.

## Usage (2.1.1.x)

### General

In **General Page** you can find the **Port Configuration Table** which represt the **Direction** the **Port** is running on, either *IP -\> ASI* or *ASI -\> IP*. Also, there is a **Production Information** panel with the general information about the device.

### Ethernet

The **Interface Table** is found here with **IP Address**, **Speed**, and **MAC Address**.

### IP Tx

There are two Configuration tables and two status tables. The **TX Input Configuration Table** let's you see the **Input** *state* and the **Keep 204 Bytes** *state*, as well as changing the **Name** of the row. the **TX IP Transmission Table** let's you see the **Transmission** *state*, **Destination IP**, **Protocol** (*UDP* or *RDP*), and also some information about the transmission. On the status side, the **TX Input Status Table** will show you the **Sync** *state*, **Packet length**, **ASI Total Bit Rate**, and **ASI Effective Bit Rate**. The **TX IP Status Table** will show you **IP Resolved** *state*, **MAC Address**, **Ethernet Total Rate,** and **FEC Mode**. You can also find three page buttons that represent **VLAN,** **RIP-2,** and **FEC**.

### IP Rx

First thing you will see on this page is the **IGMP Version**. Next, the page has a similar structure as the **IP TX Page.** The **RX Output Configuration Table** will let you change the **Name** and **Output** *state*, as well as see the **Packet Length**. The **RX IP Parameters Table** shows the **Receive Port**, **Multi Cast Mode**, **Multi Cast IP**, and the **Multi Cast Source IP**. On the status side, the **RX Output Status Table** comes with the **IP Total Rate** and the **ASI Effective Rate**. Last table is the **RX IP Status Table** that comes with **Locked** *state*, **Buffer Usage**, **Latency**, **Protocol** *status*, **Packets per Frame**, **Sequence Errors**, and **Lost IP Frames**. There are also two page buttons on this page to represent **IP RX Extra**, and **IP** **RX Status**.

### System Alarms

This page contains **Alarm Status** information for the device. The system alarms are pulled from the Current Alarm Table and device traps. Some examples include: **SNTP Server Unreachable, Defective Fan,** and **Power Failed.**

### Trap Destinations

This page displays the **Trap Destination** and the **Trap Status.** You can also **Add SNMP Tram Destination**.

### Web Interface

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to display the web interface.

## Dateminer Connectivity Framework

The version **2.1.1.x** of the Wellav UMH160R-IP supports the usage of DCF and can only be used on a DMA with **8.5.7** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic Interfaces

The dynamic interfaces are created based on **Table 3600 (Port Configuration Table).**

**Table 3600** will contain all the *DCF output interfaces*.

- **ASI IN\_***instance value*\_*Interface Type*: Dynamic Interface with type **inout.**
- **ASI OUT\_***instance value*\_*Interface Type*: Dynamic Interface with type **inout**
- **IP IN\_***instance value*\_*Interface Type*: Dynamic Interface with type **inout.**
- **IP OUT\_***instance value*\_*Interface Type*: Dynamic Interface with type **inout**.

### Connections

#### Internal Connections

The connections are made following these conditions:

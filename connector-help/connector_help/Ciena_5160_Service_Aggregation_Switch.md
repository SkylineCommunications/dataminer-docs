---
uid: Connector_help_Ciena_5160_Service_Aggregation_Switch
---

# Ciena 5160 Service Aggregation Switch

The 5160 provides exceptional 10GE density in a small 1RU form factor, with the added flexibility of supporting 1G SFPs in addition to 10GE SFP+ transceivers for easy migration as end-user demand grows. Its industry-leading feature set allows operators a cost-effective entry point into premium Ethernet business services or 3G/4G mobile backhaul applications.

## About

This connector is used to establish communication between Skyline's DataMiner Software and the Ciena 5160 Service Aggregation Switch.

The communication with this device is established via SNMPv2.

This connector supports features across all device layers.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | True                    |

### Product Info

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Device Firmware Version</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td><p>Hardware Version: 1705160830/003</p>
<p>Parameter Version: 7</p></td>
</tr>
</tbody>
</table>

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device (default: 161);
- **Read Community**: The Read community string to read data from the device (default: public);
- **Write Community**: The Write community string to write data to the device. (default: private).

## Usage

This device usage is in all similar to the Ciena CN6500 Platform where the user may dynamically assign polling for each page, and respective sub-pages a polling time, whether fast or slow.

In all main pages a Refresh button is available to make it possible for the user to reload the data from the current page and all sub-pages underneath the current page.

### General

The General page provides **general information** about the device. In this page a **Polling Configuration** sub page is available so that the user may configure the polling refresh rate for all pages and corresponding sub-pages.

In order to start polling please verify if the Read community are configured accordingly and the **Polling State** is set to Enabled. The user should a

### Blade

The Blade page is used to display information regarding the **Blade-MIB** where the user shall find detailed information about the Present Blades such as serial number, board revision number and also the Reboot command.

### Chassis

The Chassis page displays information about the device's **Chassis**, **Temperature**, **Fan**, **Power Supply**, **features** and **resources**.

### Dataplane

The Dataplane page implements the wwpLeos Dataplane MIB, which provides a set of functionalities related with **Class of Service, DSCP, Congestion Avoidance, Port Queues,** **Group Queues** and **Port Forwarding**.

### System

In the System page the user may find information regarding the **system configuration**, **guardian** features and **services state**.

In addition a sub set of pages where made available to allow the user to view information regarding the device's **telnet service**, **CPU usage**, **Memory Status**, **File Transfer Protocol** setup and **File System** characteristics.

### Interfaces

In the interfaces page a table containing all **interfaces** are available to display and to configure.

### Ethernet Port

The **Ethernet Port** page provides a complete set of tools in order to configure an ethernet port and enable/disable most of all available features.

A sub set of pages where created in order to group this functionalities such as **Layer 2 Control**, **Link Flap**, **CoS** (Class of Service), **Port Mirror** and **Statistics**.

### LAG

The **Link Aggregation** page provides all configuration and status of the ports configured in Link Aggregation Mode.

A sub set of pages where created in order to provide additional configuration features for each **LAG Port** and to display the **LAG Ports Statistics**.

### Flow

The **Flow** page allows a user to check and configure information related with **Flow Services,** **Flow Mac Learning,** **CPU Rate Limiting** and **CPU Rate Statistics**.

### MPLS

The **Multi Protocol Layer Switching** pages provide information regarding the MPLS protocol.

### Port Access Control

The Port Access Control page allows a user to check and configure data related with the 802.1 X IEEE Standard.

The user may configure the **802.1 X Ports state**, **Ports Port Access Control Authentication** methods troubleshoot via the **Diagnostics** sub-page and also check **802.1X Statistics**.

RAPS

The Ring Auto Protection Switching allows a user to check generic information regarding the RAPS protocol.

### Traffic Profile

This page displays information regarding the Traffic Profiles and assign a traffic profile configuration to a specific Port.

### VLANs

The **Virtual Local Area Network** page displays all the configured **VLANs** as well as the **VLAN EPR Group Access**.

### VPLS

The Virtual Private Local Area Network Switch displays information regarding the configured **Virtual Circuits.**

### IP

This page provides information regarding the **Internet Protocol setup,** **routes,** **IPv4 and IPv6 Interfaces** and **IP Statistics**.

### ICMP

This page allows a user to check **ICMP statistics.**

### ISIS

This page allows a user to verify and setup the ISIS configurations for this device. The user may find information regarding the **ISIS Router, ISIS LSP Summary, ISIS LSP TLV and ISIS System Statistics.**

### OSPF

This page allows a user to verify and setup the OSPF configurations for this device. The user may two tables related with the configured **OSPF Interfaces** and the configured **OSPF Areas**.

### RSVP-TE

This page displays information regarding the **Resource Reservation Protocol - Traffic Engineering**.

### CFM

The Connectivity Fault Management page provides a subset group of pages that allow to user to view, configure and access data related with the **Connectivity Fault Management** protocol.

### SNMP

The SNMP Data allows the user to analyze and configure SNMP data present on the equipment.

This page contains 5 pages:

- **SNMP USM**
- **SNMP View Based Data**
- **SNMP Notify**
- **SNMP Targets**
- **SNMP Community**
- **SNMP Statistics**

### TCP

This page displays all information regarding **Transmission Control Protocol** and all configured connections

### UDP

This page displays all information regarding **User Datagram Protocol** and all configured connections

### Management Configuration

This page displays information regarding the **management interfaces**.

### Alarms

This page contains tables regarding alarm data. namely, **Active Alarm** **data** and **Cleared Alarm data.**

---
uid: Connector_help_CISCO_WLC_Platform
---

# CISCO WLC Platform

This connector is a generic connector that can be used to **monitor** and **control** the different types (series) of **CISCO Wireless Controllers**.

## About

The CISCO WLC Platform connector uses **SNMP** to retrieve the data from the CISCO Wireless Controller.

### Version Info

| **Range** | **Description**                               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                               | No                  | Yes                     |
| 1.0.1.x          | This range supports SNMPv3 (based on 1.0.0.1) | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 8.0                         |
| 1.0.1.x          | 8.0                         |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

- **Security level and protocol**: Only applicable for **1.1.0.x.**
- **User name**: Only applicable for **1.1.0.x.**
- **Authentication password**: Only applicable for **1.0.1.x** and if "Security level and protocol" is not *noAuthNoPriv.*
- **Encryption password**: Only applicable for **1.0.1.x** and if "Security level and protocol" is not *authPriv.*
- **Authentication algorithm**: Only applicable for **1.0.1.x** and if "Security level and protocol" is not *noAuthNoPriv.*
- **Encryption algorithm**: Only applicable for **1.0.1.x** and if "Security level and protocol" is not *authPriv.*

## Usage

### General

This page contains general information about the controller.

Via the **Polling** page button, you can access the **Table Polling** page, which contains toggle buttons that allow you to *enable* or *disable* the polling for each **SNMP table** in the connector. Note that such a toggle button is also available above each of these tables on the same page as the table itself.

### Configuration

This connector contains many configuration parameters. On this page, you can find the **general** **configuration** parameters for the **controller**.

### Ping Function

This page displays information about the **Ping Queries**, such as **Ping Status**, **Average** **Success**, **Average** **RTT**, **Availability** and **Percentage of Packet Loss**. It also contains a toggle button to enable or disable **Ping Queries**, and other editable properties of the queries, such as **Cycle**, **Timeout**, **Requests** **per** **Cycle** and **Requests** **History**.

### Interfaces

This page contains the **Interface** **Configuration** table, which can be used to configure each interface in the controller.

### Multicast

This page contains the multicast configuration parameters.

### Mobility

This page contains both **mobility** **configuration** parameters and **statistics** regarding the mobility of the controller.

### Ports

This page contains the **Port Configuration** table, where each controller port can be configured, and the **Port Statistics** tables, where the statistics can be monitored.

### NTP

This page can be used to configure and check the NTP servers in the **NTP Servers** table.

### CDP

This page contains **configuration** and **statistics** parameters for the **Cisco Discovery Protocol (CDP)**.

### IPv6

This page contains **configuration** and **statistics** parameters for the **IPv6** settings.

### mDNS

This page can be used to **configure** the **mDNS** **settings** of the controller.

### DHCP

This page contains the controller's **DHCP configuration** parameters.

### Access Points

This page contains the **Access Points** table, which can be used to configure the access points in the controller.

This page also contains **page buttons** that provide access to additional pages with **configuration** and **statistics** parameters for the controller **access points**.

### 802.11 Radios

This page contains tables for the **configuration** and **statistics** of the **802.11 radios** in the **access points** of the controller.

At the bottom of the page, you can also find **page buttons** that provide access to additional configuration and information parameters for these radios.

### AP Configuration

This page contains additional settings for the controller's access points.

### AP Statistics

This page contains extra **statistics** parameters for the **access points** and the **WLANs** in the controller.

### WLANs

This page contains the **WLAN Configuration** table, which can be used to configure the different WLANs in the controller.

**Page buttons** at the bottom of the page provide access to additional **configuration** and **information** parameters for the **WLANs**.

### AP Groups

This page contains the **Access Points Groups** table, which displays information about the **access point groups**.

**Page buttons** at the bottom of the page provide access to additional **configuration** parameters for the AP groups.

### Wireless

This page contains **wireless** **configuration** parameters.

### Mesh

This page contains **mesh** **configuration** parameters.

### RF Profiles

This page contains **RF profile configuration** parameters.

### 802.11a/n/ac

This page contains configuration parameters for the **802.11a radios** in the controller.

### 802.11b/g/n

This page contains configuration parameters for the **802.11b radios** in the controller.

### RRM

This page contains **RRM** **configuration** parameters.

### AAA

This page contains **general security configuration** parameters for the controller.

The **page buttons** provide access to subpages with more **detailed security settings** and **statistics**.

### EAP

This page contains **EAP** **security** **settings**.

### Certificate

This page contains the **certificate detail parameters** of the controller.

### Wireless Protection Policies

This page contains parameters related to the wireless protection policy.

### Web Auth

This page contains configuration parameters for the **web interface** of the controller.

### SNMP

This page contains details related to the **SNMP configuration** of the controller.

A page button at the bottom of the page provides access to the **Trap Logs**.

### Telnet-SSH

This page contains details related to the **telnet** and **SSH configurations** of the controller.

### Serial Port

This page contains configuration settings for the **serial port** of the **controller**.

### Logs

This page contains **syslog** settings.

### Software Activation

This page contains the **Licenses** table, which has an entry for each controller **license**.

### Download/Upload File

On this page, you can **download** and **upload** configuration files.

### Dump

This page contains configuration parameters for the **core** and **packet** dump settings.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, otherwise it will not be possible to open the web interface.

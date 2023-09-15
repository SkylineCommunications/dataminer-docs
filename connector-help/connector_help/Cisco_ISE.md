---
uid: Connector_help_Cisco_ISE
---

# CISCO ISE

This connector is used to monitor and configure CISCO ISE devices via SNMP.

## About

The CISCO ISE is a **security management platform** used to provide **secure policy-based access** to network resources.

The platform provides the following features:

- System access control using a combination of authentication, authorization, accounting (AAA), posture and profiler on appliance.
- Support for discovery, profiling, policy-based placement and monitoring of end-point devices on the network.
- Support for a consistent policy in centralized and distributed deployments.
- Support for scalability on a number of deployment scenarios.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address.

SNMP Settings:

- **Username**: The SNMPv3 username.
- **Security level**: The SNMPv3 security level.
- **Authentication type**: The SNMPv3 authentication type.
- **Authentication password**: The SNMPv3 authentication password.
- **Privacy type**: The SNMPv3 privacy type.
- **Privacy password**: The SNMPv3 privacy password.

## Usage

### General

This page contains general system parameters, such as the device IP address and the system name.

### Interface Info

This page displays the system **interfaces** **status** and **configurations**.

### Cisco Discovery Protocol

This page contains the CDP (Cisco Discovery Protocol) table, which displays information on directly connected Cisco equipment, including the operating system version and IP address.

### ARP

This page displays the ARP (Address Resolution Protocol) table, containing the data link layer addresses in the network.

### VLAN

This page contains the following tables:

- **VLAN table**: lists the name and states of the existing VLANs in the network.
- **VLAN Port table**: Shows to which VLAN each port belongs.

### STP Forwarding

This page displays the STP (Spanning Tree Protocol) database, which contains **loop-free logical topology** in the network.

### Lightweight Access Point Protocol

This page contains tables related to the usage of the LWAPP (Lightweight Access Point Protocol), used to control multiple Wi-Fi Wireless APs (Access Points) in the network:

- **LWAPP Access Point** **table**: Contains **status** and **configuration** info related to the network Wi-Fi APs.
- **LWAPP Client** **table**: Displays **client profile** and status information.

### Authentication Services

At the top of this page, you can find the **Cisco Authentication Framework** table, which displays authentication status data.

Below this, you can find the **IEEE 802.1X Port-Based Authentication** table, which is used to provide port-based authentication mechanisms for devices to attach to a LAN or WLAN.

### Host Resources Device

This page contains the Host Resources Device table, which displays status information on the devices attached to the host.

### LLDP

This page contains information related to the LLDP (Link Layer Discovery Protocol).

The **LLDP Remote** table has information about the **remote devices** known to the host physical network and about the **system capabilities** supported by those devices.

### Ping Function

This page displays information about the **Ping Queries**, such as **Ping Status**, **Average Success**, **Average RTT**, **Availability** and **Percentage of Packet Loss**.

It also contains a toggle button to enable or disable **Ping Queries** and other editable properties of the queries, such as **Cycle**, **Timeout**, **Requests per Cycle** and **Requests History**.

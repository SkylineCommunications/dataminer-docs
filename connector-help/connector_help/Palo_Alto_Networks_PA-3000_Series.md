---
uid: Connector_help_Palo_Alto_Networks_PA-3000_Series
---

# Palo Alto Networks PA-3000 Series

The Palo Alto Networks PA-3000 series of next-generation firewall appliances comprises the PA-3060, PA-3050 and PA-3020, all of which are targeted at high-speed internet gateway deployments. The PA-3000 series manages network traffic flows using dedicated processing and memory for networking, security, threat prevention and management.

## About

The controlling element of the PA-3000 series is PAN-OS, a security-specific operating system that natively classifies all traffic, inclusive of applications, threats and content, and then ties that traffic to the user, regardless of location or device type.

This connector uses an SNMPv3 connection.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Old range (\*). | No                  | Yes                     |

**(\*) NOTE:** Connectors for all Palo Alto Networks firewall products will continue to be developed in the **1.0.0.x [Palo Alto Networks Firewall Series](xref:Connector_help_Palo_Alto_Networks_Firewall_Series) range**.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 7.\*, 8.0.0 & 8.0.7         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Username**: The SNMPv3 username.
- **Security level**: The SNMPv3 security level, e.g. *authPriv*.
- **Authentication type**: The SNMPv3 authentication type, e.g. *HMAC-SHA*.
- **Authentication password**: The SNMPv3 authentication password.
- **Privacy type**: The SNMPv3 privacy type, e.g. *AES-128*.
- **Privacy password**: The SNMPv3 privacy password.

## Usage

### General Settings

This page displays general information regarding the system, such as the **Device Name**, **System Uptime**, **System Resources**, etc.

It also contains a page button that allows you to set the polling state (*Enabled/Disabled*) of all SNMP tables.

### Device Settings

This page displays information about the device, such as **Device Settings** (**Software Version**, **Hardware Version**, **VPN Client Version**, etc.), **Global Protect**, **URL Filtering**, **Wildfire**, **Chassis**, **High Availability** and **Panorama**.

### Physical Interfaces

This page displays a table with information regarding the different **Interfaces** of the system.

### Ping Function

On this page, you can find the system ping functionality, which can be used to **test** the system **connection** and to retrieve **connectivity statistics**.

### Counters

This page contains the **Global Counters** of the system.

There are several page buttons, which lead to pages with more information about others counters, such as **TCP State**, **IP Fragmentation**, **Drop** and **DOS**.

### Session

This page contains information about **Session Utilization** and **Active Sessions** for **UDP**, **TCP**, **ICMP** and **SSL Proxy.**

It also displays a table with all the session information for **Virtual Systems** (**VSYS**).

### Interfaces

This table displays a table with information regarding the **Bit Rate, Bandwidth, Type** and **Administrator Status**.

### Sensors

This table displays a table with information regarding the **Precision, Operational Status, Type** and **Update Rate**.

### Hosts

This page displays the **Hosts** information of the system.

Several page buttons are available**:**

- **Host Storage**
- **Host Device**
- **Host Processor**

### LLDPs

This page displays the **LLDP** Information of the system. There is one page button, i.e. **LLDP Port**.

### Web Interface

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

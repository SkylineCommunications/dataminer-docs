---
uid: Connector_help_Palo_Alto_Networks_Firewall_Series
---

# Palo Alto Networks Firewall Series

The Palo Alto Networks Firewall Series connector targets all Palo Alto Networks firewall devices, which are used for high-speed internet gateway deployments.

## About

This device manages network traffic flows using dedicated processing and memory for networking, security, threat prevention and management.

This connector uses an SNMPv3 connection.

### Version Info

| **Range** | **Description**                                                               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial range, based on the Palo Alto Networks PA-3000 series range 1.0.0.x. | No                  | Yes                     |

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

It also contains a **page button** that allows you to set the **polling state** (*Enabled/Disabled*) of all **SNMP tables**.

### Device Settings

This page displays information about the device, such as **Device Settings** (**Software Version**, **Hardware Version**, **VPN Client Version**, etc.), **Global Protect**, **URL Filtering**, **Wildfire**, **Chassis**, **High Availability** and **Panorama**.

### Physical Interfaces

This page displays a table with information regarding the different **interfaces** of the system.

### Ping Function

This page contains the system ping functionality, which can be used to **test** the system **connection** and to retrieve **connectivity statistics**.

### Counters

This page contains the **global counters** of the system.

There are several page buttons, which lead to pages that offer more information about other counters, such as **TCP State**, **IP Fragmentation**, **Drop** and **DOS**.

### Session

This page contains information about **Session Utilization** and **Active Sessions** for **UDP**, **TCP**, **ICMP** and **SSL Proxy.**

It also displays a table with all the session information for **Virtual Systems** (**VSYS**).

### Interfaces

This table displays a table with information regarding the **Bit Rate, Bandwidth, Type** and **Administrator Status**.

Via the **Measurement Configuration** page button, you can configure which interfaces are monitored/measured.

### Sensors

This page displays a table with information regarding the **Precision, Operational Status, Type** and **Update Rate**.

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

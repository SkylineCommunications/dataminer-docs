---
uid: Connector_help_CISCO_ASA_Software
---

# CISCO ASA Software

This DataMiner connector is used to interact with CISCO ASA Software devices.

## About

Cisco Adaptive Security Appliance (ASA) Software is the core operating system for the Cisco ASA family. It delivers enterprise-class firewall capabilities for ASA devices in an array of form factors - standalone appliances, blades, and virtual appliances - for any distributed network environment. The CISCO ASA Software DataMiner protocol can be used to retrieve information and configure CISCO ASA Software devices using the SNMP interface.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 9.6(2)22                    |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information on the device, such as the **Name**, **Location**, **Uptime**, **Sessions**, etc.

The page also displays four page buttons that provide access to the following subpages:

- **Entities**: Displays information about the device physical and logical entities, such as **Name**, **Model**, **Manufacturer**, **Hardware**, **Firmware** and **Software Revision**, etc.
- **Interfaces**: Displays information about the device interfaces, such as **Type**, **Description**, **MTU**, **Speed**, **Throughput**, etc.
- **SNMP**: Displays statistics for the SNMP interface, such as **In Packets**, **Out Packets**, number of **Traps** and **Errors**, etc.
- **Ethernet**: Displays the **IP Address Table** and allows you to enable or disable the **IP Forwarding** feature.

### Firewall

This page displays statistics related to the **Firewall** functionality. It includes three main tables: **Hardware Status**, **Connection Statistics** and **Buffer Statistics**.

Via the **Events** page button, you can access a subpage with the tables **Basic Events** and **Network Events**. The polling of these tables can be enabled or disabled via a toggle button on the subpage.

### Unified Firewall

This page displays the **Unified Firewall** information. This includes statistics such as the number of **Active Connections**, **Average Requests**, **Average Denied Requests**, **Average Dropped Requests**, etc.

### Remote Access

This page displays **Remote Access** information. This includes statistics such as the **Maximum Sessions**, **Users** and **Groups**, the number of **Current Sessions**, **Crypto Accelerators**, **Active Users** and **Groups**, etc.

### Crypto Accelerators

This page displays information about the cryptographic accelerator modules, such as the number of **Crypto Accelerators**, the **Crypto Accelerators Throughput**, **Status** and **Type**, etc.

### IPsec

This page displays information about **IPsec** phase 1 and 2, such as the number of **Tunnels**, **Input** and **Output Packets** and **Failures**.

### Memory Pool

This page displays information about the system memory modules, such as the **Memory Name** and **Used** and **Free** capacity.

### CPU

This page displays information about the CPU modules, such as the **Physical Index** and different **Usage** statistics.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Revision History

DATE VERSION AUTHOR COMMENTS

02/10/2018 1.0.0.1 AIG, Skyline initial version Initial version.

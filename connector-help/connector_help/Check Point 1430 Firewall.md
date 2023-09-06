---
uid: Connector_help_Check_Point_1430_Firewall
---

# Check Point 1430 Firewall

The Check Point 1430 Firewall is a security gateway of high-performance, integrated devices offering firewall, VPN, antivirus, application visibility and control, URL filtering, email security and SandBlast Zero-Day Protection, all in compact form factors that are simple to configure and manage.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | R77.20.86 (990172855)  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP main connection

This driver uses an SNMPv2 connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMPv2 Settings (1.0.0.x):

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use (1.0.0.x)

The element created with this driver consists of the following data pages:

- **General**: Displays general **system information** as well as the **System OR** table, which lists the capabilities of the local SNMP applications acting as a command responder with respect to various MIB modules.
- **Secure Virtual Network**: Provides an overview of the **Secure Virtual Network**, **OS information**, **SVN Appliance** and **SVN Routing Modification** details. Also contains three page buttons that provide access to more details about **SVN Performance, SVN Network Interfaces** and **VS Routing.**
- **High Availability**: Provides information on the High Availability product**.**
- **Firewall**: Displays the firewall status, with details related to the firewall **Network Interfaces.**
- **Firewall Statistics**: Contains several page buttons that display information related to various firewall statistics, e.g. **SMTP**, **FTP**, **HTTP**, **Cookies**, **AV Total**, etc.
- **Policy Statistics**: Contains information related to policy statistics.
- **Interface Statistics**: This page contains the Interfaces table.
- **LS Connectivity**: This page contains information related to LS connectivity.
- **VPN**: Provides an overview of the **Check Point VPN (CPV)**. Also contains several page buttons that provide detailed information such as **IKE**, **FWZ**, **Accelerator**, **IPSec NIC** and **IPSec**.
- **SNMP Traps**: Contains the SNMP Traps table.
- **Web Interface**: Displays the web interface of the polling IP address.

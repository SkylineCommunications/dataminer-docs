---
uid: Connector_help_Xiplink_XA30K
---

# Xiplink XA30K

XA appliances deliver advanced satellite and wireless optimization in easy-to-install appliances.

This connector uses 2 connections, **SNMP** and **HTTP**. It mainly uses HTTP.

## About

### Version Info

| **Range**      | **Description**                                                         | **DCF Integration** | **Cassandra Compliant** |
|----------------|-------------------------------------------------------------------------|---------------------|-------------------------|
| 1.1.0.x        | New connector version compatible with Xiplink v5.0.                     | No                  | No                      |
| 1.2.0.x        | Token-based authentication is available as well as processing of traps. | No                  | Yes                     |
| 1.3.0.x (Main) | Removed credential authentication.                                      | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.1.0.x   | v5.0                   |
| 1.2.0.x   | v5.12.3-39             |
| 1.3.0.x   | v5.13.7-41             |

## Configuration

### Connections

#### SNMP connection - SNMP

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### HTTP connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address (default: *ByPassProxy*).

### Configuration of Login

To access the device, on the **System Info** page, click the **Login** page button and fill in the **Username** and **Password**.

From range **1.2.0.x** onwards, the login subpage offers **token-based authentication**, where each user can use a specific token to access the device.

## Usage

### General

This is the default page of the connector. It displays general data such as the **Device Name**, **Version**, **Uptime**, etc.

In the **Optimization Monitoring** section of the page, you can find some important performance optimization parameters, on which trending can be enabled, i.e. **CPU Load, Memory Usage, Optimized TCP Connections** and **Up/Downlink Savings**.

A page button is available that provides access to the **Login** subpage, where you can log in and connect to the device. For more information, refer to the "Configuration of Login" section above.

### Networking

This page contains three main sections: Mode, Redundancy and Interfaces.

- The **Mode** section contains among others the **Node Type** and **NAT**.
- In the **Redundancy section**, you can find settings such as **Clustering**, **Preferred Master**, etc.
- In the **Interfaces** section, you can find the settings **Wireless Interface**, **Routed Interface**, etc.

The page also contains the following page buttons:

- **Interfaces**: Displays the **Logical Interfaces** table and the **Physical Interfaces** table.
- **Routes**: Displays the **IPv4** **Routes** table with the **Default** **Gateway**. From version 1.2.0.2 onwards, this subpage also displays the **Static IPv4 Routes**, **IPv6 Routes**, and **Static IPv6 Routes.**

### Optimization

In the **General** section, this page contains general parameters such as **Optimization Enabled**, **Optimized TCP Connections** (with history trending data), **Use Compression**, **Packet** **Overhead**, etc.

In the **Compression** section, you can find the **HTTP Compression**, **XiPix**, **JPEG Quality**,etc.

- **TTCP**: Displays the **TTCP** **Ports** table, with an option to enable it.
- **SCPS-TP**: Displays the **Selective Negative ACKs**, **PPA**, etc.
- **Service Assignment**: Displays the **Service Assignment Table**.
- **Traffic Assignment**: Displays the **Traffic Assignment Table**, with the options to **add or remove a rule** in the table.
- **Tunnels**: Displays the **Coalesce Table.**

### Statistics

This page contains parameters related to connections, uplink, and downlink.

- In the **Connections** section, you can among others find the parameters **Connection Attempts**, **Connects**, **Fast Accepts**, **Short Snacks Received**.
- The **Uplink** section displays the **Uplink LAN In**, **Uplink Savings**, etc.
- The **Downlink** section displays the **Downlink LAN Out**, **Downlink Wi In**, etc.

The page also contains the following page buttons:

- **QoS Table**: This page contains the **QoS Table**.
- **QoS Statistics**: Here you find the **QoS Statistics** table.

### Product Alarms

On this page, you will find the**Faults Overview** table and the **Trap Notifications** table, which display incoming traps from the device.

There is one page button, **Auto Clear**, which displays a page with options that specify whether traps should be processed, how many traps should be displayed in the Trap Notifications table, and for how long the notifications should be displayed.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

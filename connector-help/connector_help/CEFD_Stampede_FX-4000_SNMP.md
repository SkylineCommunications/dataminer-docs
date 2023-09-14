---
uid: Connector_help_CEFD_Stampede_FX-4000_SNMP
---

# CEFD Stampede FX-4000 SNMP

The **CEFD Stampede FX-4000 SNMP** combines one-sided application delivery and two-sided WAN optimization into a single platform.

## About

This connector uses SNMP commands to display information and set the settings on the device. SNMP traps can be retrieved when this is enabled.

Further information can be found on the following website: <http://www.comtechefdata.com/products/ran-wan-optimization/stampede-fx-series>

### Version Info

| **Range**     | **Description**                                                    | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                   | No                  | No                      |
| 1.1.0.x              | Firmware change.                                                   | No                  | Yes                     |
| 1.1.1.x              | Fixes requested by customer.                                       | No                  | Yes                     |
| 1.2.0.x              | New MIB and new design document provided by customer.              | No                  | Yes                     |
| 1.2.1.x \[SLC Main\] | New document provided by customer. Required removal of parameters. | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                     |
|------------------|-----------------------------------------------------------------|
| 1.0.0.x          | Firmware: 6.3.0aD-201512032235E4-3.10.62-FX30 EN MIB: Rev 6.2.3 |
| 1.1.0.x          | Firmware updated. taken from 1.0.0.3 MIB: REV 7.1               |
| 1.1.1.x          | MIB: REV 7.1                                                    |
| 1.2.0.x          | MIB: REV 7.2.8                                                  |
| 1.2.1.x          | MIB: REV 7.2                                                    |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

This page displays device information: **Serial Number**, **Firmware Version**, **Up Time**, **Current Time** and **License Info**. It also displays the **Service Contact** information.

### Admin

This page contains system information, including the **Host Name**, **Domain**, **DNS Server**, **Time**, **Time Zone**, and **SNMP** **Community String**, as well as the **Subnet**, **Trap State**, and **Trap Destination**.

It also contains a Web Management Interface Settings section, where you can enable or disable the **Use SSL** option, and specify the browser port used for the web interface.

### Admin Networking

On the left side of this page, you can find parameters for the **Management Interface (eth0)**: DHCP, IP Address, Mask, Gateway, Speed/Duplex MTU. On the right side, there are similar parameters for the **Auxiliary Interface (eth1)**.

The page also contains two tables: the **Static Routes** table, where you can add a route via the **Add Route** button, and the **Hosts** table, where you can also add rows.

### WANOP

This page contains the **WAN Link Settings**: TX Rate, RX Rates and Latency.

There are also parameters related to the **LAN(eth2)/WAN(eth3) Data Interfaces**: LAN Speed/Duplex, WAN Speed Duplex and LAN/WAN MTU.

### Redundancy

This page displays the **Redundancy State**, as well as the **Primary Appliance**, **Secondary Appliance** and **Authentication Key**. You can also enable or disable the parameter **Automatically Synchronize Configuration Changes**. Finally, a button is also available to synchronize the configuration, i.e. the **Sync Config** button.

### Advanced - Path Redundancy

This section contains the **Path Redundancy State** parameter, which can be enabled or disabled.

### Advanced - Links

This page contains the **QOS Links** table, which among others displays the **Name**, **State**, **Poll Satellite Modem**, and others columns.

### Advanced - Groups

On this page, you can find the **QOS Groups** table and the QOS Group Filters table. In both tables you can add and delete entries. The **QOS Group Filters** table also contains two buttons to **Promote** or **Demote** group filters.

### Advanced - Queues

This page is similar to the "Advanced - Groups" page, but contains the **QOS Queues** and the **QOS Queue Filters** tables.

### Status - Overview

This page consists of the following sections:

- **Device Status - Overview**: Displays the CPU Usage, Memory Usage, Temperature, Uptime, and Current Time.
- **System Status - Overview**: Displays the Acceleration Status, Redundancy Status, Current Active LAN Port and Admin Bypass Mode.
- **Network** **Status - Overview**: Contains the Ethernet Interface Status table.

### Statistics - WANOP

This page consists of the following sections:

- **Device Status - WANOP**: Displays the **Acceleration** **Status**, **Uptime**, **Current Time**, and **Acceleration Up Since** parameter.
- **Connections - WANOP**: Displays the **Current** **Users** and **Max Users**, as well as the connections and passthrough connections for both **LAN** and **WAN**.
- **WAN Traffic - WANOP**: Displays the **Total Throughput**, the number of packets received by the WAN and the number of packets sent by the WAN.

At the bottom of the page, a button allows you to **Clear Statistics**.

### Statistics - Networking

This page contains the **LAN Interfaces** table, which among others displays the **States** of the interfaces, **Speed**, **MTU**, etc.

### Statistics - QoS

This page displays average statistics for a selected time period. In the **Queue Status** table, you can find the **Name** and **State** of the queues, with their **Priority**, **CIR**, **MIR**, etc.

### Statistics - Redundancy

This page contains redundancy information: Host Name, Primary Appliance, Secondary Appliance, Redundancy State, Redundancy Status and Current Active LAN Port.

### Operations

At the top of this page, you can enable or disable **Admin Bypass Mode**. The page also contains buttons to execute various actions: **Reboot Device**, **Restart Acceleration**, **Clear Statistics** and **Factory Reset**.

### Operations - Manage Licenses

This page contains the **FAST** information.

### Traps

This page contains traps information, including **Max Traps**, and the **Traps Received** table.

### Web Interface

This page displays the web Interface of the device. The port number is a parameter used in the device.

Note that the web interface is only accessible when the client machine has network access to the product.

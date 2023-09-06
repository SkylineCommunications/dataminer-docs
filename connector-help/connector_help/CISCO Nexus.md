---
uid: Connector_help_CISCO_Nexus
---

# CISCO Nexus

The Cisco Nexus switches are modular and fixed port network switches designed for data centers. This connector can be used to monitor such a device.

## About

The connector uses an **SNMP** connection and **DCF** integration to monitor Cisco Nexus devices. This help page only applies from range **1.0.2.x onwards**, except the section on the IGMP page, which was included in range 1.0.4.x.

### Version Info

| **Range**                          | **Description**                                                                                 | **DCF Integration** | **Cassandra Compliant** |
|------------------------------------|-------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.2.x                            | SNMPv2 - complete review.                                                                       | Yes                 | Yes                     |
| 1.0.3.x                            | SNMPv3 version.                                                                                 | Yes                 | Yes                     |
| 1.0.4.x                            | SNMPv2 version - Advance display key.                                                           | Yes                 | Yes                     |
| 3.0.0.x \[Obsolete - see 3.0.1.x\] | SNMPv2 version - Advance display key.                                                           | Yes                 | Yes                     |
| 3.0.1.x \[Obsolete - see 3.0.2.x\] | Removed duplicate Interfaces table introduced in 3.0.0.24.                                      | Yes                 | Yes                     |
| 3.0.2.x \[Obsolete - see 3.0.3.x\] | Changed display key of interface tables. Changed API polling table to a complete polling table. | Yes                 | Yes                     |
| 3.0.3.x \[Obsolete - see 3.0.4.x\] | Reworked VTP VLAN table to support both SNMP and NX API polling.                                | Yes                 | Yes                     |
| 3.0.4.x \[SLC Main\]               | Improved display keys of RTP Flow and RTP Flow Errors tables.                                   | Yes                 | Yes                     |
| 4.0.0.x                            | SNMPv3 version (based on version 1.0.0.9).                                                      | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.2.x   | 7.0.3.I3.1             |
| 1.0.3.x   | Unknown                |
| 1.0.4.x   | 7.0(8)N1(1)            |
| 3.0.0.x   | 7.0(8)N1(1)            |
| 3.0.1.x   | 7.0(8)N1(1)            |
| 3.0.2.x   | 7.0(8)N1(1)            |
| 3.0.3.x   | 7.0(8)N1(1)            |
| 3.0.4.x   | 7.0(8)N1(1)            |
| 4.0.0.x   | 7.0(8)N1(1)            |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

<!-- -->

- SNMPv2 settings:

- **Port number**: The port of the connected device, e.g. *161.*
  - **Get community string**: The community string used when reading values from the device, e.g. *public.*
  - **Set community string**: The community string used when setting values on the device, e.g. *private*.

<!-- -->

- SNMPv3 settings:

- **Username**: The SNMPv3 username.
  - **Security level**: The SNMPv3 security level.
  - **Authentication type**: The SNMPv3 authentication type.
  - **Authentication password**: The SNMPv3 authentication password.
  - **Privacy type**: The SNMPv3 privacy type.
  - **Privacy password**: The SNMPv3 privacy password.

### External Components

From version **3.0.0.3 onwards**, this connector uses an external DLL, **Renci.SshNet.dll**, to be able to communicate via SSH.

## Usage

### General

This page displays general information about the device, such as the **Name**, **Location**, **CPU Usage**, and **Memory Usage**.

It also contains the following buttons:

- **Reset Device**: Resets the Cisco Nexus device.
- **Copy Configuration**: Displays a page that allows you to generate a CISCO configuration copy.
- **ICMP**: Displays a page with all ICMP statistics.
- **TCP/UDP Statistics**: Displays a page with all TCP and UDP statistics.
- **System Services**: Displays a page listing the state of the services of each OSI layer.

### OpenConfig

In version 3.0.4.X, there is support for **OpenConfig**. It is possible to update some columns from the **Detailed Interface**, **Rx Interface** and **Tx Interface** tables.

When used, the data from SNMP will be removed in those tables and filled in with the values from OpenConfig.

To configure OpenConfig, fill in all values on the **OpenConfig Settings** page:

- Data Source IP Address
- Data Source Port
- Data Source User Name
- Data Source Password
- Client Certificate (optional)

### Sensor

This page contains the **Sensor** **table**, which lists the type, scale, and the present value of each sensor.

### System Health

This page contains the following tables:

- **Fan**: Displays the operational status of all the fans.
- **Power Status**: Lists the power-related administrative status and operational status of the manageable components in the system.
- **CPU Memory Pool:** Displays overall CPU statistics.
- **NV Memory Pool**: Displays information regarding the RAM.

### CLI

With the Command Line Interface (CLI), commands can be sent through SSH or via the NX API (from version 3.0.0.4 onwards).

This page contains the following parameters:

- **CLI Communication Type**: Allows you to select either *CLI (SSH)* or *NX API*. Based on the selection, the CLI commands will be sent via SSH or via HTTPS.
- **User Name**: The SSH user name.
- **Password**: The SSH password.
- **NX API Version**: Currently the version is by default set to 1.0. However, this could change after firmware updates.
- **Command Timeout Time:** Allows you to set the maximum wait time (in milliseconds) for a command response.
- **Command Entries to Keep**: Allows you to set the maximum number of rows visible in the Command History table.
- **Add Command**: Adds a new command to be executed.
- **Command History**: Table containing all the recently executed commands and their output.
- **Total Communication Issues:** The total number of detected communication issues present in the Command History table.
- **Clear Command History**: Clears the Command History table entries.

### PTP

The Precision Time Protocol (PTP) pages display information regarding this functionality (from version 3.0.0.10 onwards). The PTP credentials must be filled in for this functionality to be activated.

This page contains the following subpages:

- **PTP Clock**: Displays parameters regarding the clock.
- **PTP Interfaces**: Displays the Foreign Master Records and PTP Interfaces tables.
- **PTP Grandmaster**: Displays parameters related to the grandmaster clock.
- **PTP Time Sync**: Displays parameters related to the time sync.
- **PTP VLAN:** Displays the VLAN table.
- **PTP Corrections**: Displays the PTP Corrections table.

### Interface Detailed

This page contains the **Detailed Interface** **table**. This table provides general information about each interface.

From version **1.0.3.7 onwards**, the polling period of the **Detailed Interface table** (as well as the **Interface Rx table** and **Interface Tx table**)can be configured using the **Detailed Interface Polling Interval** parameter. The default value of this parameter is *2 minutes*. Its possible values range between 30 seconds and 1 hour.

From version **3.0.3.1 onwards**, you can add or delete VLANs from an interface via the right-click menu.

### Interface Rx

This page contains the **Interface Rx table**. This contains the input statistics of each interface.

### Interface Tx

This page contains the **Interface Tx** **table**. This contains the output statistics of each interface.

### L2 L3 Interface

This page contains the **L2 L3 Interface** **table**. The table shows the administratively requested and actual operating configuration for switch port interfaces.

### PoE

This page displays the **PoE** **table**. This table contains information about power Ethernet ports on a Powered Sourcing Equipment (PSE) device. Some settings can be configured in this table, such as the maximum amount of power that the PSE will make available for the power device.

### BGP

This page displays the **BGP Peer** **table**. This table contains information about the connections with BGP peers. Some settings can be configured in this table, such as the time intervals for the ConnectRetry and KeepAlive timer.

### HSRP

This page contains the **HSRP** **Group** **table**, which displays information about each HSRP group for each interface.

### OSPF

This page contains general information regarding the Open Shortest Path First protocol.

The page also contains the following buttons:

- **Area-Stub Area**: Displays a page containing the **Area and Stub Area table**. The Area table displays the configured parameters and cumulative statistics of the attached areas of the router. The Stub Area table contains the set of metrics that is advertised by a default Area Border Router in a stub area.
- **LSDB**: Displays the **LSDB table**, which displays information about the Link State Database of the OSPF process.
- **Interface**: Displays a page containing the **Interface**, **Interface Metric,** **and** **Virtual Interface** **tables**.
- **Host**: Displays a page containing the **Host** **table**, which displays the metrics of the hosts, which the router will advertise as host routes.
- **Neighbor**: Displays a page with the **Virtual Neighbor** **and** **Non Virtual Neighbor** **tables**.

### IP

This page displays general IP statistics such as **requests**, **discards**,and **fragment fails**.

The page also contains the following buttons:

- **IP Route**: Displays a page containing the **IP** **Route** **table**.
- **IP Statistics**: Displays a page with the **IP System Statistic Input** and **IP System Statistic Output** **tables**.
- **ARP**: Displays a page containing the **ARP** **table**.
- **IP Multicast**: Displays a page containing the **IP Multicast Interface** and **IP Multicast SSM Range** **table**. The first table can be used to manage the multicast protocol active on an interface. The second table can be used to create and manage the range(s) of group addresses to which SSM semantics should be applied.

### IGMP

This page contains two tables, the **IGMP Interface** and **IGMP Cache Table**. Both tables display the interface description in the index column.

### NBM

This page contains the **NBM Interfaces Bandwidth** table.

### VTP VLAN

This page displays the **VTP VLAN** and **VTP** **Internal VLAN tables**.

The page also contains the following buttons:

- **VTP Authentication**: Displays a page containing the **VTP Authentication** **table**. The table shows the authentication information of VTP for the local system.
- **VTP Management Domain**: Displays a page containing the **VTP VLAN Management Domain table**.This table shows information on the management domains for the local system.
- **VTP Statistics**: Displays a page with the **VTP Statistics** **table**.
- **VTP Edit Control**: Displays a page that contains the **VTP Edit Control** **table**. This table allows you to control the editing of the VLANs for a particular management domain.
- **VTP VLAN Membership:** Displays a page with the **VLAN Membership** **table**.
- **VTP VLAN Status**: Displays a page with general VTP information such as the **VTP Version** and **VTP Maximum VLAN Storage**.
- **VTP VLAN Trunk Port:** Displays a page that contains the **VLAN Trunk Port** **table**. This table shows information on the VLAN trunk ports of the local system.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

From version **1.0.2.1** of the connector onwards, DCF is supported, requiring a DMA with **8.5.4** as the minimum version.

### Interfaces

The dynamic interfaces are created based on the number of rows in the **tables 2800 Interfaces and 7400 VLANs (DCF Interfaces).**

- **Interfaces\_***instance value*\_*Interface Type*: Dynamic interface with type **inout**.
- **VLANs\_***instance value*\_*Interface Type*: Dynamic interface with type **inout.**

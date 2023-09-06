---
uid: Connector_help_Juniper_Networks_Manager
---

# Juniper Networks Manager

This is an SNMP-based connector used to monitor and configure the Juniper Networks Manager. With this connector, the device settings can be monitored and changed.

The connector also uses an SSH connection, in order to change the interface state of some ports.

Some devices have huge tables, so in order to limit polling, polling can be disabled for some tables.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                            | **Based on** | **System Impact**                                                                                                                                                                                                                                 |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version (SNMPv2).                                                                                                                                                   | \-           | \-                                                                                                                                                                                                                                                |
| 1.0.1.x \[Obsolete\] | SNMPv2 + SSH.                                                                                                                                                               | 1.0.0.27     | Unknown                                                                                                                                                                                                                                           |
| 1.0.2.x \[Obsolete\] | SNMPv2 + SSH: Configurable polling rate and measured interfaces.                                                                                                            | 1.0.0.30     | Unknown                                                                                                                                                                                                                                           |
| 1.0.3.x \[Obsolete\] | SNMPv3 + traps + SSH.                                                                                                                                                       | 1.0.0.30     | Unknown                                                                                                                                                                                                                                           |
| 1.0.4.x              | SNMPv2 + SSH: Configurable polling rate and measured interfaces.                                                                                                            | 1.0.2.15     | Possible loss of alarm/trend information. Version range is now Cassandra-compliant.                                                                                                                                                               |
| 1.0.5.x \[Obsolete\] | Implemented DCF (interfaces).                                                                                                                                               | 1.0.4.1      | Increased load on system.                                                                                                                                                                                                                         |
| 1.0.6.x              | Display key and table fixes.                                                                                                                                                | 1.0.5.3      | Possible loss of alarm/trend information for the Queued Interface Stats Table and the Digital Optical Monitoring Table.                                                                                                                           |
| 1.0.7.x \[Obsolete\] | Bit rate calculations for iftable/ifxtable based on counters.Changed units from bps to Mbps on interface details table.Fixed display key on FC Output Queue stat.           | 1.0.6.3      | Trending affected by units change.The display key change for table FC Output Queue stat may affect DataMiner alarm filters, Automation scripts, Visio drawings, reports and web API.                                                              |
| 1.0.8.x \[Obsolete\] | Added IF MTU column to Interface Stats table.                                                                                                                               | 1.0.7.2      | Possible loss of alarm/trend information on the Interface Stats table.                                                                                                                                                                            |
| 1.0.9.x \[SLC Main\] | Added additional SNMP columns to Intermediate Systems Adjacencies (ISIS) table.Fixed issue on Interface Additional Objects table to resolve a conflict between bps and Bps. | 1.0.8.1      | Possible loss of alarm/trend information on the Intermediate Systems Adjacencies table.Filters, scripts, Visio drawings, reports, or API calls that refer to columns in the Interface Additional Objects table (PIDs 8003, 8006) may be affected. |
| 2.0.0.x              | SNMPv3 + traps + SSH.Bitrate parameter units changed to Mbps.                                                                                                               | 1.0.3.21     |                                                                                                                                                                                                                                                   |
| 3.0.0.x              | SNMPv3 + traps + SSH.                                                                                                                                                       | 1.0.3.24     | None.                                                                                                                                                                                                                                             |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |
| 1.0.1.x   | kernel JUNOS 12.3R11.2 |
| 1.0.2.x   | Unknown                |
| 1.0.3.x   | kernel JUNOS 12.3R11.2 |
| 1.0.4.x   | Unknown                |
| 1.0.5.x   | Unknown                |
| 1.0.6.x   | Unknown                |
| 1.0.7.x   | Unknown                |
| 1.0.8.x   | Unknown                |
| 1.0.9.x   | Unknown                |
| 2.0.0.x   | kernel JUNOS 12.3R11.2 |
| 3.0.0.x   | kernel JUNOS 12.3R11.2 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.0.1.x   | No                  | No                      | \-                    | \-                      |
| 1.0.2.x   | No                  | No                      | \-                    | \-                      |
| 1.0.3.x   | No                  | No                      | \-                    | \-                      |
| 1.0.4.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.5.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.6.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.7.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.8.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.9.x   | Yes                 | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | No                      | \-                    | \-                      |
| 3.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

This is an SNMP and SSH connector. The IP has to be configured during creation of the element.

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

SSH settings:

- **IP address:** The polling IP of the device, e.g. *10.11.12.13*.
- **Port number**: The SSH port of the connected device, by default *23* or *22* (version 1.0.3.x).

### Initialization

For the **SSH** communication, a **user name** and **password** need to be set. To do so, go to the **General** page and click the **Credentials** page button on the right-hand side page.

By default, all tables in this connector are polled. However, in order to reduce the amount of polling, the polling of some tables can be stopped, and some tables have a number of columns for which polling can be disabled and enabled:

- On the **General page**,there is a page button to get to the **Redundancy** **Table**, and there you can find a button **Poll Redundancy Table**. This button can be set to *Disabled* to stop the polling of this table.
- On the **General page**,there is a page button to get to the **Operating** **Table**, and there you can find a button **Poll Operating Table**. This button can be set to *Disabled* to stop the polling of this table.
- On the **Interface Stats page**,there is a button **Poll Optional Interface Stats**. This button can be set to *Disabled* to stop the polling of some of the columns of the Interface Stats table.

Version range 1.0.2.x has some extra features:

- **Polling Config** (on the General page): This page contains a **Polling Configuration Table**, which can be used to configure the polling speed for each table. If you set the **PCT - Polling Time** to *disabled (-1)*, no polling is done for these parameters. With the **Refresh** button, you can poll the parameters manually.

- **Measurement Config** (on the Interfaces page):

- **Manually**: Disable interfaces in the **Measurement Configuration Table** by toggling the **MCT - Measure Port** column. A disabled interface is no longer polled and is removed from the different interface tables. This is useful to reduce the load in case of huge interface tables. By setting the **Enable/Disable Interface \[Description Filter\]** with a string value, you can enable/disable all interfaces that contain the string value. With the buttons **Disable All**, **Enable All**,and **Enable Oper. Up** you can disable all interfaces, enable all interfaces, or enable all operational interfaces.
  - **MCT - Filter Table**: Adding a filter description in this table (by selecting Add in the right-click menu) will enable all interfaces containing part of the filter and disable all other interfaces. Each entry in this table can be activated/deactivated. Only when this table is empty, can the **Measurement Configuration Table** be changed manually.

- **LSP-MPLS**: This page displays a table with information regarding the list of configured **Label Switched Paths (LSP)**.

- New **traps** have been added in order to update the parameters directly or to trigger the polling for the affected parameters based on the bindings in the trap.

Version range 3.0.0.x has additional features:

- **Polling Configuration Table** (on the Polling Config subpage of the General page):

- Contains an additional **Lock State** column, which can contain the value *Locked or Unlocked*. When a row is **locked**, no change can be performed to the **Polling Time** and **Polling State** parameters, and the **Refresh** button is disabled. A locked row will contain a letter in a dark grey color to indicate the locked state. The **right-click menu** of the table can be used to lock or unlocka row or multiple selected rows.
  - When the **Real-Time Performance Monitoring: Ping Results** row is disabled, no action will be performed on the row, and a message will be displayed if some of its dependent tables are enabled (see "RPM Metrics Page \[1.0.3.x\]" below). When such dependent tables are enabled, Real-Time Performance Monitoring: Ping Results will become *enabled* if it was set to *disabled* and a message will be displayed.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General Page

This page displays general information regarding the system, such as the **System Name**, **System Uptime**, **CPU Usage**, **Memory Usage**, etc.

There are several page buttons, which lead to pages that display more information about **Services**, **Redundancy**, the **Operating Table**, **TCP/UDP Stats**, **ICMP Stats**, **IP Stats**, and **SSH Security Settings**:

- The **Credentials** subpage allows you to change the **User Name** and **Password** for the connector's SSH connection, which will also be used for the **Backup**, **Restore**,and **Firmware Upgrade** procedure.
- The **Redundancy Table** subpage displays the status of the redundancy. The polling of this table can be disabled.
- The **Services** subpage displays the status of the different layers of the OSI model: **Physical Layer**, **Network Layer**, etc.
- The **Operating Table** subpage displays more information about the hardware in the device. The polling of this table can be disabled.
- The **Conditional Monitoring** subpage contains parameters that can be used to import and export files.
- The **Storage Table** subpage displays the information regarding the **Storage** that is being used.
- The **TCP/UDP Stats** subpage displays more information about the TCP and UDP statistics, such as **TCP Timeout Minimum** and **UDP Number of Ports**. It also contains a **TCP Connection Table** and **UDP Listener Information**.
- The **ICMP** **Stats** subpage displays more information about ICMP statistics, such as **ICMP Received Messages**, **ICMP Sent Echo Reply**,etc.
- The **IP Stats** subpage displays more information about IP statistics, such as **IP Forwarding**, **IP Datagrams Received**, etc.

Prior to range 1.0.2.x of the connector, input fields are available in the lower right corner, which allow you to import or export the current values to a file.

### Hardware Page

This page displays the **Operating Table**, which contains operating information on the system, along with controls to **Automatically Remove Deleted Rows** and **Remove Deleted Rows**.

### Interfaces Page

This page displays a table with information regarding **Device Interfaces**.

### Interface Stats Page

This page displays information regarding **Interface Statistics**.There is an **IF State Custom Change** column, so that you can force the state of an interface of the ge or xe type to *up* or *down*. These settings are applied when the **Commit IF Changes** button is clicked.

If you set **Poll Optional Interface Stats** to *Disabled*, the polling of the following columns of the Interface Stats table will be disabled: **IF Type**, **IF Protocol Error**, **IF Discontinuity**, **IF Link Traps**, **IF Promiscuous Mode**, **IF Connector**, and **IF Speed**.

Via the **More Stats** page button, you can access additional statistics.

On the **More Interface Stats** page, there are 2 tables: More IN Interface Stats, and More Interface Stats OUT. The **More IN Interface Stats** table shows more input information, such as **IN Octets**, **IN Ucast Pck 32**, etc. The **More Interface Stats OUT** table shows more output information, such as **OUT Errors 32**, **Out Mcast Pck**, etc. Polling can be disabled for one or both of the tables.

Finally, if you are using connector range 1.0.3.x, you can also find the **Measurement Configuration** page button on this page, which can be used to enable or disable the displaying and calculation of the interface communication KPIs.

### Interface Queue Page

This page displays information regarding **Queued Interface Statistics**, such as the **IFQ Forwarding Class**, **IFQ Red Drop Packets**, etc.

### Interfaces Connections Page

This page displays a table with information regarding **Interface Connections**, such as **Port**, **Node**, **Remote Interface**, etc.

### Aggregation Page

This page displays tables with information regarding **Aggregation Ports** and **Aggregation Statistics**.

### BFD Page

This page displays tables with information regarding **Client BGP** and **Client OSPF Routing Information**.

### BGP Page

This page displays tables with information regarding **Border Gateway Protocol Statistics**.

### OSPF Page

This page displays the **OSPF Interfaces Table** and **OSPF Neighbor Table**.

### LDP Page

This page displays the **LDP Session Table**.

### LSP-MPLS Page

This page displays the **LSP-MPLS Statistics Table**.

### RSVP-MPLS Page

This page displays the **RSVP Session Table**, along with three separate parameters concerning **Active LSP Ingress**, **Transit**, and **Egress**.

### L2Circuit Page

This page displays the **VPN Pseudo-Wire Distant** and **Local Tables.**

### IPv4 Page

This page displays the **IPv4 Addresses Table**.

### IPv6 Page

This page displays information regarding **IPv6 Statistics**.

### Multicast \[1.0.2.x\]

This page displays the **Multicast Table**, which contains information such as the **Source**, **Interface**,and **Bitrate** of each multicast.

### Multicast Next Hop \[1.0.2.x\]

This page displays the **Multicast Next Hop Table**, which contains information such as the **Source**, **Group**, and **Protocol**.

### Configuration Page

This page displays information regarding **Device Configurations**.

### Alarms Page

This page displays information regarding the **Alarm Status**.

### RPF Page

This page displays a table with information regarding **Reverse Path Forwarding**.

### DOM Page

This page displays a table with information regarding **Digital Optical Monitoring**.

Range 1.0.6.x of the connector converts the digital optical monitoring power data to the appropriate units (mA, dBm).

### BGPv4 Page

This page displays a table with information regarding **BGP Prefix Counters**.

### Firewall Page

This page displays tables with information about **Firewalls** and **Firewall Filter Counters**.

### RPM Metrics Page \[1.0.3.x\]

This page and its subpages contain a group of tables containing RPM (**Real-Time Performance Monitoring**) metrics, which can be used to evaluate network efficiency.

Examples of these metrics are the **RTT** (minimum, maximum, average, and standard deviation round-trip time) and the number and percentage of **sent/received probes** between network nodes.

Note: In all tables displayed on the pages **RPM Metrics**, **Ping Probe**, and **RPM History**, the **Description** column is based on the **Ping Results Table** (ID 24000 in Ping Probe).

### Traps

This page displays tables with the received traps regarding **SNMP**, **Chassis**, **Configuration Management**, **Flow Control Services**, **User AAA**,and **VCCP** events.

### Ping Function Page

This page displays standalone parameters that can be used to configure the **Ping Functionality** and to retrieve statistics regarding this functionality.

### Backup / Restore

Backup procedure: The **Backup File Name** is copied via **SCP** command from the **Backup Device Directory** to the **Backup Remote Directory**. For instance:

- The *juniper.conf.gz* file will be copied via the SCP command (example below) from the */config/* backup device directory to the *10.10.132.18:~/* backup remote directory.
- Command: scp /config/juniper.gz user@10.10.132:~/juniper.conf.gz

Restore procedure: The **Restore File Name** is copied via **SCP** command from the **Restore Remote Directory** to the **Restore Device Directory**. Once the file is copied to the device, it is **committed** to the device. For instance:

- The *juniper.conf.gz* file will be copied via the SCP command (example below) from the *10.10.132.18:~/* restore remote directory to the */tmp/* restore device directory.
- Command: scp user@10.10.132.18:~/juniper.conf.gz /tmp/juniper.conf.gz

The **Restore Timeout** parameter can be used to configure how long it will take before the **Restore Commit command** is considered to have timed out.

### Firmware Upgrade

The **Upgrade File Name** is copied via **SCP** command from the **Upgrade Remote Directory** to the **Upgrade Device Directory**. Once the file is copied to the device, there will be a **load override** with added validation. In case no issues occur, the file will be **committed**,after which a system **reboot** will take place in order to complete the firmware upgrade.

For instance:

- The *jinstall-xxx.nnn-domestic-signed.tgz* file will be copied via the SCP command (example below) from the *192.168.10.1:~/* upgrade remote directory to the */tmp/* upgrade device directory.
- Command: scp user@192.168.10.1:~/jinstall-xxx.nnn-domestic-signed.tgz /tmp/

The **Upgrade Timeout** parameter can be used to configure how long it will take before the **Upgrade** is considered to have timed out.

From version 1.0.3.7 onwards, a **Software Rollback** button is available.

### Web Interface

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

---
uid: Connector_help_Arista_Manager
---

# Arista Manager

The Arista Manager connector can monitor Arista switches of type **7010T** and **7050SX:**

- **7010 series**: 1U low power (52 W) line-rate 1 Gb top-of-rack switch, with 4x10 Gb uplinks.
- **7050 series**: 1U low-latency cut-through line-rate 10 Gb and 40 Gb switches. Higher port density than the 7100 series, with a minimum of 52 x 10 GbE ports but slightly increased latency (1.2 æs or less).

## About

This connector can be used to monitor **Rx and Tx Interfaces**. Statistics are available for **TCP/UDP**, **ICMP**, and **IP**. Some settings can be configured for **sFlow** and **OSPF**. **Environment Control** parameters are available for **Cooling**, **Power**, **Temperature**, and **Hardware**. On the **Explorer** page, you can fill in one or more API commands and immediately view the response.

- **SNMP** is used to retrieve device information (e.g. **System Name**, **System Description**, **Detailed Interface Info tables**, etc.) and to receive the **traps**.
- **HTTP** is used to retrieve information that is available in the Arista Command API.
- **Smart-serial** communication is used to receive the **Syslog Messages**.

### Version Info

| **Range** | **Description**                                                                                                                                                                                                                          | **DCF Integration** | **Cassandra Compliant** |
|-----------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x   | Initial version.                                                                                                                                                                                                                         | Yes                 | Yes                     |
| 1.0.1.x   | Extra "smart-serial" interface for SyslogMessages.                                                                                                                                                                                       | Yes                 | Yes                     |
| 1.0.3.x   | Adapted to work with custom-made Truck Application.                                                                                                                                                                                      | Yes                 | Yes                     |
| 2.0.2.x   | Adapted to work with custom-made Truck Application.                                                                                                                                                                                      | Yes                 | Yes                     |
| 2.0.3.x   | Key of "Monitor IGMP Snooping" table adapted.                                                                                                                                                                                            | Yes                 | Yes                     |
| 2.0.4.x   | Current VLAN Table replaced by VLAN Port Overview.                                                                                                                                                                                       | Yes                 | Yes                     |
| 2.0.5.x   | Version merge.                                                                                                                                                                                                                           | Yes                 | Yes                     |
| 2.0.6.x   | Added polling table. Reverted display keys for SRM purposes.                                                                                                                                                                             | Yes                 | Yes                     |
| 2.0.7.x   | Fixed typos in PTP Interfaces table.                                                                                                                                                                                                     | Yes                 | Yes                     |
| 2.0.9.x   | Credential Manager with the latest implementation.                                                                                                                                                                                       | Yes                 | Yes                     |
| 2.0.10.x  | Changed the way the polling is executed to get a more consistent result.                                                                                                                                                                 | Yes                 | Yes                     |
| 2.0.11.x  | Changed the key of the IP multicast routing table.                                                                                                                                                                                       | Yes                 | Yes                     |
| 2.0.12.x  | \- Removed Section Table and added SNMP polling commands to the polling table to avoid confusion. - Trunk Table has been converted to SwitchPort Table. It now shows more extended information. - Fixed various incorrect "Interpretes". | Yes                 | Yes                     |

### Product Info

| **Range**             | **Supported Firmware**          |
|-----------------------|---------------------------------|
| 1.0.0.x               | 4.15.2F                         |
| 1.0.1.x               | 4.15.2F                         |
| 1.0.3.x               | 4.15.2F                         |
| 2.0.2.x \[Obsolete\]  | 4.15.2F                         |
| 2.0.3.x \[Obsolete\]  | 4.15.2F 4.20.5F                 |
| 2.0.4.x               | 4.15.2F 4.20.5F                 |
| 2.0.5.x               | 4.15.2F 4.20.5F                 |
| 2.0.6.x               | 4.15.2F 4.20.5F 4.21.1F         |
| 2.0.7.x               | 4.15.2F 4.20.5F 4.21.1F         |
| 2.0.9.x               | 4.15.2F 4.20.5F 4.21.1F         |
| 2.0.10.x              | 4.15.2F 4.20.5F 4.21.1F 4.25.2F |
| 2.0.11.x              | 4.15.2F 4.20.5F 4.21.1F 4.25.2F |
| 2.0.12.x \[SLC Main\] | 4.15.2F 4.20.5F 4.21.1F 4.25.2F |

## Configuration

### Connections

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: This is not required.

SNMP Settings:

- **Port number**: *161*
- **Get community string**: *public*
- **Set community string**: *private*

#### HTTP CommandAPI connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: *80*
- **Bus address**: *ByPassProxy*
- **Timeout on a single command (ms)**: *45000* (avoids timeouts in slow responses)

Serial SyslogMessages connection

This connector uses a serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The IP of the DMA where the Syslog Messages are sent.

  > [!IMPORTANT]
  > Starting from version **1.0.1.7 (and only within this range)**, the keyword ***any*** should be specified instead of the IP of the DMA where the Syslog Messages are sent. This is necessary for compatibility when a DMS is operating in a Failover setup. When this is the case, the device only needs to send the messages to the virtual IP, and the main and backup elements will process them accordingly.

  > [!NOTE]
  > For a **standalone DMA** without Failover setup, in order to receive syslog messages, use the **IP of the server** instead of "any".

  - **IP port**: 514

  - **Bus address**: Not required.

### Configuration of credentials for HTTP communication

On the **General** page, fill in the **Credentials** (**Username** and **Password**) to establish HTTP communication.

## Usage

### General

This page displays system parameters (**System Name**, **System Description**, etc.) and statistics.

The page contains page buttons for **TCP/UDP Stats**, **ICMP Stats**, **IP Stats**, **IP ARP**, **IP Interfaces**, **CPU**, and **PTP**.

Up to version 2.0.5.x, the page button **Enable Polling** allows you to enable or disable SNMP polling for these subpages. From version 2.0.6.x onwards, the **Configure Polling** page button can be used for this. This subpage also allows you to configure the polling state and rate of the HTTP commands.

The **Credentials** page button opens a subpage where you can fill in the **Username** and **Password** to establish HTTP communication. The **Credential Manager Module** can be found at the bottom of the page. This credential manager is used to update the username and password automatically. It interacts with a separate connector, the [Generic HTTP Credential Manager](xref:Connector_help_Generic_HTTP_Credential_Manager), where you can manage the credentials for this connector as well as other connectors.

The **Save Run. Config.** button can be used to save the current operating configuration to the startup config file.

The **Copy Run Start** button can be used to save the content of the running config virtual file to the startup config file.

### Explorer

On this page, you can execute a command through the command API. This includes configuration commands. To do so, fill in the command in the **Commands** box and click the **Submit** button.

You can execute multiple commands with one call, e.g. by filling in *sflow run;show sflow*.

The result will be displayed in the **Response Viewer** box.

### Detailed Interface Info, Detailed Interface Info - Rx, Detailed Interface Info - Tx, Detailed Interfaces Queue Info

These pages display detailed information regarding the interfaces.

The **Detailed Interface Info** table contains a column with the **Uptime** of the interface. The **VLAN** column shows a comma-separated list of VLANs that are tagged on a specific interface.

The **Detailed Interface Info - Rx** table contains Rx parameters: **Rx (Non) Unicast Packets**, **Rx (Non) Unicast Rate**, **Rx Errors**, **Rx Errors Rate**, etc. Similarly, the **Detailed Interface Info - Tx** table contains Tx parameters: **Tx (Non) Unicast Packets**, **Tx (Non) Unicast Rate**, **Tx Errors**, **Tx Errors Rate**, etc.

From version 2.0.5.2 of the connector onwards, the **Detailed Interface Queue Info** table contains the result of the "get interfaces counters queue" command. It includes the **Interface Queue Interfaces** text box, which allows you to specify which interfaces you would like to queue. To specify multiple interfaces, use a comma as separator, e.g. "1,2,3" for interfaces 1, 2 and 3. Click the **Submit If Request** button to send the request so that the table is filled up.

You can disable/enable interfaces to show in the **Measurement Configuration** table, which can be opened from the **Detailed Interface Queue Info page**. When the measure port parameter is disabled, the interface will not be shown in the **detailed interface info** and **detailed interface info - Rx/Tx** tables.

### Monitor Sessions

This page displays the **monitor sessions** and their **target** and **source** interfaces. Monitor sessions are sessions where traffic from one interface is **mirrored** by another interface.

### DCF Config

This page displays the **DCF IF** table.

### Interfaces Transceiver

This page displays the **Interfaces Transceiver** table.

### SFlow

This page displays several SFlow parameters, such as **Hardware Sample Rate** and **Sampling State**. There are also a number of configurable parameters, such as **Sample Rate**, **Polling Interval**, and **SFlow Status**.

SFlow is a sampling technology that monitors application-level traffic flow.

The **SFlow Collectors** table provides an overview of the collectors (receivers). It is possible to add a collector and to enable or disable a collector. Disabling a collector removes the collector from the SFlow configuration, but the row will still be available in the SFlow Collectors table. Deleting a collector will remove the row of a disabled collector.

### DirectFlow

This page displays the **Flows** table, which provides an overview of the relative priority of the flows and defines idle/hard timeouts for the flows. DirectFlow **Matches** and **Actions** are also available, and there are columns for the **Rates** for **Match Packets** and **Match Bytes**.

### Openflow (version 2.0.4.8)

This page displays the **Openflow Statistics**, **Openflow Queues**, **Openflow Ports**, and **Openflow** tables.

The page button **Openflow Profile** provides access to all the details related to the Openflow Profile parameters.

### BGP

This page displays BGP parameters: **BGP Version**, **BGP Local Autonomous System Number**, and **BGP Identifier**.

The page also displays the **BGP Peer** table. The **BGP BRF Name** allows you to enter a VRF name to make the command more dynamic.

### OSPF

This page displays OSPF parameters.

### IGMP

This page displays IGMP parameters.

The **IGMP Static Group** table contains the IP IGMP static groups data.

The **IGMP Snooping** table displays the IP IGMP snooping groups.

The **Monitor IGMP** page button displays the **Monitor IGMP Snooping** table. To add an entry to this table, specify the group in the **Multicast Group to Add** parameter, specify the VLAN in the **VLAN to Add** parameter, and click the **Add VLAN/Group** button.

### QoS

This page displays the tables **Class Map**, **Class Map Match**, **Service Policy**, **QoS Statistics**, **Policy Map**, **Policy Map Class**, and **Policy Map Action**.

### ACL

This page displays the tables related to the access control lists: **IP ACLs** and **IPv6 ACLs**.

An ACL is an ordered list of rules that defines access restrictions for entities (interface or control plane) to which it is applied.

### Tap Aggregation

This page contains tables with information about the **tap aggregation configuration**. Note that this information is only available if the switch is in **tap aggregation mode**.

The **tap interfaces**, **aggregation groups**, and **tool interfaces** are all displayed in a dedicated table. The other tables on this page display the **connections** between these different items.

Note that configuration of the **timestamp mode** and **truncation size** will only work correctly from software version **4.20.5F** onwards.

### VLAN Info

This page displays several VLAN parameters (Version Number, Number of VLANs, etc.) and VLAN tables (VLAN Port Overview, VLAN Static, and Port VLAN).

A virtual local area network (VLAN) allows a group of devices to communicate as if they were in the same network regardless of their physical location.

### Trunk Info

This page displays the **Trunk** table.

Trunking extends multiple VLANs beyond the switch through a common interface or port channel.

### IP Routes

This page displays the **IP Route** and the **IP Software Routes** table, as well as several **IPv4** and **IPv6** parameters.

### Environment Control

This page displays status parameters such as the **Cooling Status** and **Temperature Status**.

It also contains a number of page buttons:

- **Cooling**: Displays the **Fan Tray Slots** table, the **Fans** table, and several parameters related to cooling, such as the **Cooling Mode**.
- **Power**: Displays the **Power Supply** table, with an overview of the available power supplies and their state.
- **Temperature**: Displays the **Temperature Sensor** table, with an overview of the temperature sensors and their **Hardware Status**.
- **Hardware**: Displays the parameters **Port Count**, **Switched Port Count**, etc.

### LLDP

This page displays the **LLDP Neighbors Detail** table.

### LLDP Receiver (from range 1.0.3.x onwards)

This page displays information related to a custom notification mechanism implemented as part of the custom-made Truck Application. The page contains among others the **LLDP Notification Settings** and **LLDP Notification Receiver**.

When an entry changes in the **LLDP Neighbors Detail** table (on the LLDP page), the connector will send a notification with relevant information about the change to all the elements included in the table **LLDP Notification Receiver**. The notification will happen in the form of a set to the specified **Parameter ID**.

### Traps

This page displays the **Traps** table. The traps are also stored in a (hidden) traps logger table. It is possible to execute a query to request traps from that logger table.
To do so, fill in a string in the format "*GUID;maximum number of results;starttime;endtime*" in the parameter **Trap Advanced Query**. The results of the query will be displayed in the **Traps Advanced Search** table.

### Syslog

This page displays the **Syslog Messages** table. The syslog messages are also stored in a (hidden) syslog messages logger table. It is possible to execute a query to request syslog messages from that logger table.
To do so, fill in a string in the format "*GUID;maximum number of results;starttime;endtime*" in the parameter **Syslog Advanced Query**. The results of the query will be displayed in the **Syslog Advanced Search Messages** table.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.1.6** range of the Arista Manager connector supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- **DCF IF Table**: Physical interfaces are filtered from the **Detailed Interface Info** table, type inout.
- **VLAN Current Table**: Physical interfaces, type inout.

### Connections

#### Internal Connections

- Between interfaces and VLANs tagged on the specific interface, an internal connection is created with the following properties:

- **VLAN ID** connection property with as its value the VLAN Filtering Database ID.

---
uid: Connector_help_Talari_Networks_T5200
---

# Talari Networks T5200

Designed to bring network reliability and increased capacity to enterprise offices and data centers, the 2U rack-mountable Talari Networks T5200 delivers up to 3 Gbps across eight WAN Links and connects up to 256 sites.

## About

This device uses an SNMP connection to set information on and get information from the device. SNMP traps can be retrieved when this is enabled on the device.

More information about the device can be found on the following website: <http://www.talari.com/products/appliances/t5200>.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                               |
|------------------|-----------------------------------------------------------|
| 1.0.0.x          | Software version: R6_1_GA_P2_H1_03012017; OS Version: 4.4 |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device.
- **Set community string**: The community string used when setting values on the device.

## Usage

### General

This page displays general information about the device.

The **System Description** section contains the following parameters:

- **Device Description:** A textual description of the entity.
- **Network Uptime:** The time since the network management section of the system was last re-initialized.
- **Device Uptime:** The amount of time since this host was last initialized.
- **Contact:** The contact person for this management node.
- **Device Name:** The name assigned to the managed node.
- **Location:** The physical location of this node.
- **Device Type:** The vendor's identification of the network management subsystem.
- **IP Address:** The IP address used to connect to this device.

The **Appliances Info/Statistics** section shows general information on the appliance:

- **Name**: The name of the appliance.
- **Model**: The OID for the model of this appliance.
- **Model Name**: The model of the appliance.
- **Bytes Sent:** Number of bytes sent for the appliance since the last time the Talari service was started.
- **Packets Sent:** Number of packets sent for the appliance since the last time the Talari service was started.
- **Bytes Received:** Number of bytes received for the appliance since the last time the Talari service was started.
- **Packets Received:** Number of packets received for the appliance since the last time the Talari service was started.
- **Bytes Dropped:** Number of bytes dropped for the appliance since the last time the Talari service was started.
- **Packets Dropped:** Number of packets dropped for the appliance since the last time the Talari service was started.
- **State**: Indicates whether the appliance is enabled or disabled.
- **HA State**: Indicates whether this is the currently active appliance or the standby appliance.
- **Serial Number**: The serial number of the appliance.
- **OS Version**: The OS version of the appliance.
- **Software Version**: The version of the software running on the appliance.
- **Config Created On**: The day and time when the Talari configuration was created.

The **Polling** page button displays a list of toggle buttons that can be used to enable or disable the polling for each SNMP table in the connector. At the top of the list, buttons are available that immediately enable or disable polling for all tables.

### Network

This page contains two tables, **Ethernet Interfaces** and **WAN Links**, that contain statistics for all Ethernet Interfaces and all WAN links in the system, respectively. Counter data in these tables is updated once a minute, and is based on a cumulative count since the last time the Talari service was started.

The page also contains the following parameters:

- **Number of Ethernet Interfaces** / **Number of WAN Links**: Display the total number of Ethernet interfaces and WAN links.
- **Polling of Ethernet Interfaces** / **Polling of WAN Links**: Allow you to enable/disable the retrieval of data for the relevant table.
- **Last Polling of Ethernet Interfaces** / **Last Polling of WAN Links**: Indicate when the data in the relevant table was last updated.

### Passthrough

This page contains statistics about the passthrough service, i.e. the **Bytes Sent**, **Packets Sent**, **Bytes Received**, **Packets Received**, **Bytes Dropped** and **Packets Dropped**.

### Routes

This page contains two tables, **Routes** and **Routes V2**, which contain statistics for route objects. Counter data in these tables is updated once a minute, and is based on a cumulative count since the last time the Talari service was started.

The page also contains the following parameters

- **Polling of Routes** / **Polling of Routes V2**: Allow you to enable/disable the retrieval of data for the relevant table.
- **Last Polling of Routes** / **Last Polling of Routes V2**: Indicates when the data in the relevant table was last updated.
- **Number of Routes V2**: Displays the total number of objects.

### Rules

This page displays statistics for all the rules in the system, in the **Rules** table. Counter data in this table is updated once a minute and is measured over the past active minute.

The page also contains the following parameters:

- **Number of Rules**: Displays the total number of rules.
- **Polling of Rules**: Allows you to enable/disable the retrieval of data for the Rules table.
- **Last Polling of Rules**: Indicates when the data in the table was last updated.

### Conduits

This page displays two tables, with statistics for **Conduits** and **Dynamic Conduits**. Counter data in these tables is updated once a minute and is based on a cumulative count since the last time the Talari service was started. Dynamic conduits can be added and removed using device management.

The page also contains the following parameters.

- **Number of Conduits** / **Number of Dynamic Conduits**: Display the total number of conduits and dynamic conduits.
- **Polling of Conduits** / **Polling of Dynamic Conduits**: Allow you to enable/disable the retrieval of data for the relevant table.
- **Last Polling of Conduits** / **Last Polling of Dynamic Conduits**: Indicate when the data in the relevant table was last updated.

For both conduits and dynamic conduits, more data is available on subpages. For each of those subpages, you can toggle to enable or disable retrieval of data. They also all contain an indication of when the data on the page was last updated. The following subpages are available:

- **Paths:** Displays statistics for all (dynamic) conduit paths in the system. Counter data in the table is updated once a minute and is based on a cumulative count since the last time the Talari service was started. The number of paths in the table is the sum of the number of paths for each conduit (displayed in the **Number of Paths** column in the (Dynamic) Conduits table).
- **Classes:** Displays statistics for all (dynamic) conduit classes in the system. Counter data in the table is updated once a minute and is based on a cumulative count since the last time the Talari service was started. The number of conduits used by the table is displayed by the **Number of (Dynamic) Conduits** parameter and the number of classes for each conduit is always 17.
- **Rules:** Displays statistics for all (dynamic) conduit rules in the system. Counter data in the table is updated once a minute and is measured over the past active minute. The number of rules in the table is the sum of the number of rules for each conduit (available in the **Number of Rules** column in the (Dynamic) Conduits table).

### Internet

This page displays statistics regarding the Internet service, i.e. the **Bytes Sent**, **Packets Sent**, **Bytes Received**, **Packets Received**, **Bytes Dropped** and **Packets Dropped**.

The page also contains statistics for rules associated with the Internet service, specifically in the **Internet Rules** table. The counter data in this table is updated once a minute and is measured over the past active minute.

The following parameters are also available:

- **Number of Internet Rules**: Displays the total number of Internet rules.
- **Polling of** **Internet Rules**: Allows you to enable/disable the retrieval of data for the Internet Rules table.
- **Last Polling of** **Internet Rules**: Indicates when the data in this table was last updated.

### Intranet

This page displays statistics for the intranet services on this site in the **Intranet Services** table. Counter data in this table is updated once a minute and is based on a cumulative count since the last time the Talari service was started.

The following parameters are also available:

- **Number of Intranet Services**: Displays the total number of intranet services.
- **Polling of** **Intranet Services**: Allows you to enable/disable the retrieval of data for the Intranet Services table.
- **Last Polling of** **Intranet Services**: Indicates when the data in this table was last updated.

The **Rules** page button displays statistics for rules associated with the intranet service:

- **Number of Intranet Rules**: Displays the total number of intranet rules.
- **Polling of** **Intranet Rules**: Allows you to enable/disable the retrieval of data for the Intranet Rules table.
- **Last Polling of** **Intranet Rules**: Indicates when the data in the Intranet Rules table was last updated.
- **Intranet Rules** table: Counter data in this table is updated once a minute and is measured over the past active minute. The number of rules in this table is the sum of the number of rules for each intranet service (available in the **Number of Rules** column in the Intranet Service table).

### ARP

This page displays statistics for ARP entry objects.

- **Number of ARP Entries:** Displays the total number of ARP entries.
- **Polling of** **ARP Entries:** Allows you to enable/disable the retrieval of data for the ARP table.
- **Last Polling of ARP Entries:** Indicates when the data in the ARP table was last updated.
- **ARP** table: Contains statistics counts for all the ARP entries in the system. Counter data in the table is updated once a minute.

### LAN GRE Tunnels

This page displays statistics for LAN GRE Tunnel objects.

- **Number of LAN GRE Tunnels:** Displays the total number of objects.
- **Polling of LAN GRE Tunnels:** Allows you to enable/disable the retrieval of data for this table.
- **Last Polling of LAN GRE Tunnels:** Indicates when the data in the LAN GRE Tunnels table was last updated.
- **LAN GRE Tunnels** table: Displays the state and statistics for all the LAN-side GRE tunnels in the system. Counter data in the table is updated once a minute and is based on a cumulative count since the last time the Talari service was started.

### Event Traps

This page contains the **Event Traps** table, which displays the received events that were generated as SNMP traps by the Talari system. The page also displays the total number of received events with the **Number of Received Event Traps** parameter.

The **Force Cleanup** button can be used to clean up the received event traps immediately, which is otherwise done automatically every 15 minutes.

The **Trap Cleanup Configuration** page, available via the **Cleanup Config** page button, provides access to settings that can be used to avoid an endlessly growing table:

- **Trap Clean Up Method**: The method used to clean up the Event Traps table (checked every 15 minutes). The following methods can be selected:

- *Row Count*: Based on the number of rows.
  - *Trap Age*: Based on how long the trap exists.
  - *Both*: Based on a combination of the number of rows and the trap age. The row count check is done first.

- **Max Traps**: Maximum number of received traps that will be kept.

- **Max Age Traps**: Maximum age of received traps that will be kept.

- **Trap Clean Up Amount**: Latest number of traps removed from the Event Traps table when a cleanup was executed.

### Events

This page contains the **System Events** table, which displays the latest set of events generated by the Talari system.

- **Number of System Events:** Displays the total number of events.
- **Polling of System Events:** Allows you to enable/disable the retrieval of data for this table.
- **Last Polling of System Events:** Indicates when the data in this table was last updated.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

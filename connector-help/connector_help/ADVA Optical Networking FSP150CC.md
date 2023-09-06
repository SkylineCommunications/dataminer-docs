---
uid: Connector_help_ADVA_Optical_Networking_FSP150CC
---

# ADVA Optical Networking FSP150CC

This is an **SNMP** driver that is used to monitor and configure the **ADVA Optical Networking FSP150CC** equipment.

## About

The information on tables and parameters is retrieved via SNMP polling.

The current traps implemented in version 1.0.2.6 and above are LinkUp, LinkDown, CmSysAlmTrap, CmNetworkElementAlarmTrap, CmNetworkElementEvent and CmSysEvent. These traps update the Interface, System Event and Network Element Event tables.

### Version Info

| **Range**            | **Key Features**                                                                                                 | **Based on** | **System Impact**                                                                                                                                                                                                                                        |
|----------------------|------------------------------------------------------------------------------------------------------------------|--------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version                                                                                                  | \-           |                                                                                                                                                                                                                                                          |
| 1.0.2.x              | Support for SNMP polling from backup IP                                                                          | \-           |                                                                                                                                                                                                                                                          |
| 2.0.0.x \[Obsolete\] | SNMPv3                                                                                                           | \-           |                                                                                                                                                                                                                                                          |
| 2.0.1.x              | \- Table 42000 ethernetPBWanStatsTable adapted- Display key added- SNMP columns hidden- Retrieved columns added  | 2.0.2.4      | \- Display key impact on iDMS filters, DMS Automation scripts, Visio files, DMS reports and DMS WebAPI usage.- Alarm and trending info removed from params 42002, 42003 and 42004. Trending and alarm monitoring now enabled for 42005, 42006 and 42007. |
| 2.0.2.x \[Obsolete\] | DCF support added                                                                                                | 2.0.1.1      |                                                                                                                                                                                                                                                          |
| 2.0.3.x              | \- Discard rates added for Interfaces Table- Red/Yellow discard rates added to Ethernet Flow Policer Stats table | 2.0.2.3      | Impact on custom reports or scripts calling Ethernet Flow Policer Statistics table indices directly.                                                                                                                                                     |

### Product Info

| **Range** | **Supported Firmware**                       |
|-----------|----------------------------------------------|
| 1.0.0.x   | Backplane revision: 1.0                      |
| 1.0.2.x   | Unconfirmed                                  |
| 2.0.0.x   | Backplane revision: 1.04 \[to be confirmed\] |
| 2.0.1.x   | Same as 2.0.0.X                              |
| 2.0.2.x   | Same as 2.0.1.X                              |
| 2.0.3.x   | Same as 2.0.2.x                              |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |
| 2.0.3.x   | Yes                 | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, default *private*.

## Usage

### General

This page displays the following general information: **System Name, System Description, System Location, System Contact, CLI Prefix,** **System Up Time** and **Polling IP**.

In addition, it also displays the status of the following parameters: **CLI Security Prompt, FTP, HTTP, HTTPS, SCP, Serial Port, Serial Port Auto Log Off, SFTP, TFTP, SSH** and **Telnet**.

### Interfaces

This page displays the **Interfaces** table, which lists the **Interface** entries.

### Ethernet Management Port

This page displays the **Ethernet Ports Management** table, which allows you to configure multiple settings for the **Ethernet Management Port Facilities**, for instance **Administrative State**, **Configuration Speed** and **MDIX Type**.

### Ethernet Access Port Statistics

This page displays the **Ethernet Access Ports Statistics** table. These statistics include the **Laser Bias Current**, **Optical Power Transmit/Received**, **Temperature** and multiple types of **Bit Rate** statistics.

### Ethernet Access Port Statistics History

This page displays the **Ethernet Access Ports History** table, with the history data of the **Ethernet Access Ports Statistics** table.

### Ethernet Network Port Statistics

This page displays the **Ethernet Network Ports Statistics** table. These statistics include **Optical Power Transmit/Received**, **Average Bit Rate Received/Transmitted**, **SFP Temperature** and **Unavailable Seconds**

### Ethernet Network Port Statistics History

This page displays the **Ethernet WAN Statistics** table.

### Ethernet WAN

This page displays the **Ethernet Network Ports History** table, with the history data of the Ethernet Network Ports Statistics table

### Access Control List

This page displays the **Access Control List** table, which lists the entries corresponding to the **Access Control IP Network Addresses**. You can also configure multiple settings, for instance **IP Version, IP v4/v6 Address, Network Mask, Prefix** and **Control**.

### Priority Map

This page displays the **Priority Map** table, which lists the entries corresponding to **Ethernet Priority Mappings** in the multi **Class of Service** mode. You can also configure multiple settings, for instance **In Priority**, **X-Tag Control** and **Priority**, **Class of Service** and **Inner/Outer Tag Priority**.

### Probe

This page displays the **Probes** table, which allows you to configure multiple settings on ESA Probes entries, such as **Alias**, **Direction**, **Protocol**, **Source/Destination IP Address**, multiple **VLAN** configurations, the number of **History Bins**, the **History Interval**, the **Storage Type**, and more.

### Probe Statistics

This page displays the **Probes Statistics** and **Probes OAM Statistics** tables. These tables include statistics related to the **ESA Probe** and **ESA Probe MEF 35**.

### Probe Statistics History

This page displays the **Probes Statistics History** table, with the history data of the **Probes Statistics** table.

### Flow

This page displays the **Flow** table. This table allows you to configure multiple settings for the **Ethernet Flows** entries, for instance **Index, Circuit Name, Administrative State, Type, Multiple Class of Service, Access to Network CIR/EIR, Network to Access CIR/EIR**, **Storage Type**, **Status** and more.

### Flow QoS Shaper

This page displays the **Flow QoS Shapers** table. This table allows you to configure multiple settings for the **Ethernet Quality of Service Shaper** entries, for instance **Network Port QoS, Administrative State, Status, CIR/EIR, CIR/EIR High, SOAM CIR/EIR High, CBS, EBS, Buffer Size** and more.

### Flow QoS Policer

This page displays the **Flow QoS Flow Policers** table. This table allows you to configure multiple settings for the **Ethernet Quality of Service Policer** entries, for instance **Network Port QoS, Administrative State, Direction, CIR Low/High, EIR Low/High, Color Mode, Color Marking Flag, Storage Type, Status** and more.

### FlowPoint

This page displays the **FlowPoint** and **FlowPoint Statistics** tables:

- The **FlowPoint** table displays the **Admin** (configurable) and **Operational State** of its entries.
- The **FlowPoint Statistics** include multiple **Average/Instantaneous Bit Rates**, **Frames Marked Green/Yellow/Red**, **Frames Dropped** and more.

### FlowPoint History

This page displays the **FlowPoint Statistics History** table, with history data of the **FlowPoint Statistics** table.

### FlowPoint QoS Shaper

This page displays the **FlowPoint QoS Shaper** **Statistics** table. These statistics include **Bytes Transmitted**, **Bytes Tail Dropped**, **Frames Dequeued**, **Frames Tail Dropped**, **Average Bit Rate Limited, Bytes** and **Frames** **Random Early Discarded Dropped**

### FlowPoint QoS Shaper History

This page displays the **FlowPoint QoS Shaper Statistics History** table, with history data of the **FlowPoint QoS Shaper Statistics** table.

### FlowPoint QoS Policer

This page displays the **FlowPoint QoS Policer Statistics** table. These statistics include **Frames Marked Green/Yellow/Red and Discarded**, **Bytes In/Out** , **Average Bit Rate**, and **Discard rate for Frames Marked Yellow/Red**.

### FlowPoint QoS Policer History

This page displays the **FlowPoint QoS Policer Statistics History** table, with history data of the **FlowPoint QoS Policer Statistics** table

### Power Supply Unit

This page displays the **Power Supply Units** table, which monitors the **PSU Type**, **Operational** and **Secondary** **State**, **Output Voltage** and **Current**, and **Temperature.** It also allows you to configure the **Administrative State**, **Storage Type** and **PSU Status**.

### Fan

This page displays the **Fans** table, which describes the **Operation** and **Secondary State**. It also allows you to configure the **Administrative State, Storage Type** and **Fan Status**.

### Shelf

This page displays the **Shelves** table, which describes the **Shelf Type**, **Operational**, **Administrative** and **Secondary State**, **Manufacturer Site** and more.

### Slot

This page displays the **Slots** table, which describes the **Slot Type**, **Card Type**, **Unit Name**, **CLEI code, Manufacturer Name** and **Site**, **Part Number** and more.

### Software

This page displays the **Software** and **Software Version** tables.

- The **Software** table displays the **Type** and **Version** of its entries.
- The **Software Version** displays the **Active/Inactive Application Software** and **Active/Inactive Operating Software** of the unit/module.

### Time Zone

This page displays the time zone parameters for the device. This includes the **UTC offset**, **DST Control Enabled**, **Start** and **End DST Month, Day** and **Time**.

### Target Addresses

This page displays the IP where traps are sent, along with information related to this. It contains the **Target Addresses** table, which displays the **Transport Address**, **Domain**, **Timeout** **Time**, and **Retry Count**.

### NTP

This page displays all parameters related to **Network Time Protocol** info and configuration, for instance the **System Time of Day**, the **NTP Mode** and **Type**, the **NTP Primary** and **Secondary Server IP address** and **version**, the **Audio Provisioning Mode**, the **Polling Interval**, etc.

### IP

This page displays the **IP Address** table, which contains all IPs related to the device, a customizable user-friendly **Description**, the **Network Mask**, and the **Re-Assemble Max Size** for each entry.

### Network Element

This page displays the **Network Elements** table, which allows you to view and configure the **Name**, **Type**, **Contact**, **Location**, **Storage Type**, **Status**, **Fine Grained Interval**, etc. of its entries.

### System Alarms

This page displays the **System Event Table.**

It also contains a button, **Poll System Event Table**, which can be used to manually poll this table when necessary. Otherwise, the table is only polled every 24 hours because it is linked to the **System Alarm/Event traps**, which perform the update of the data as alarms/events are raised or cleared.

### NE Alarms

This page displays information about the **Network Element Event Table**. It also features a button, **Poll NE Event Table**,for similar reasons as explained in the System Alarms section above.

This page also displays extra information, such as **Last State Change** and **Event Counter**, and possible actions that can be applied to the element alarm settings, for example with the **Test Entity ID** and **Test Action buttons**, which are a combination of test parameters. Test Entity ID is the OID of the test object, e.g. the Network Interface OID. Test Action will raise or clear the test alarm on the object specified in Test Entity ID.

Finally, the **Trap File Size** parameter allows you to control the size of the log file, and the **Log Traps** parameter allows you to enable or disable the logging of the traps.

### Other Alarms

This page displays the **Alarm Severity Assignment Table** and the corresponding polling button.

On this page, the **IP Info** group displays the **Polling**, **Main** and **Backup** IPs with their respective **Status**.You can select the IP for the SNMP polling from the drop-down options of the **Polling** parameter.

### IP

This page displays the **IP Address**, **IP Interface** and **IP Management** tables. A page button in the lower right corner displays the information from the **IP Info** group, with the **Switchback Delay** and **Switch Mode** parameters.

The **Switchback Delay** is the amount of time the driver should wait before switching back to the main IP in case polling is currently done from the backup IP.

The **Switch Mode** is the parameter that enables or disables the switchback delay. If the value of this parameter is *Automatic,* the driver will check if the main IP is stable for the amount of time specified in the Switchback Delay before switching to the main IP. To keep polling from the backup IP, you first need to disable the Switch Mode parameter, as otherwise the driver will switch back to the main IP after the delay.

Finally, the page also contains the **Static Route** table, with information such as the **Destination**, **Subnet Mask**, **Gateway**, type of **Interface** and **Metric**.

### Flow Statistics

This page displays the **Flow Statistics** table. These statistics include multiple kinds of **A2N/N2A Bit Rates**, **Unavailable/Errored/Severely Errored Seconds**, **A2N/N2A Bytes Received/Transmitted** and various statistics related to the **A2N/N2A Frames** count.

### Flow Statistics History

This page displays the **Flow Statistics** **History** table, with the history data of the **Flow Statistics** table.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

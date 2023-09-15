---
uid: Connector_help_Arris_ME-7000
---

# Arris ME-7000

The **Arris ME-7000** is a compression platform that provides multi-codec support with SD, HD encoding and transcoding plus multi-screen delivery for IPTV, cable and satellite applications.

## About

This connector (SNMP-based in range 1.0.0.x and HTTP-based in range 1.1.0.x) monitors the Arris ME-7000 device.

### Version Info

| **Range** | **Description**                | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.               | No                  | No                      |
| 1.1.0.x          | HTTP connection. Tree control. | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**    |
|------------------|--------------------------------|
| 1.0.0.x          | me7k.1.0.0.42.150313 (CCBuild) |
| 1.1.0.x          | me7k.2.2.0                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

Range **1.0.0.x** of this connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

HTTP Main Connection

Range **1.1.0.x** of this connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. (*Default: 443*)

## Usage: Range 1.0.0.x

### General

This page displays the system's general information parameters, such as **System Contact, System Name, Device Status** etc.

It also displays 4 buttons that allow you to **Restore Configuration**, **Back up Configuration**, **Shut down** the device or **Reboot** it.

### Network

This page displays the **Network Interfaces Table** with parameters such as:

- **Interface Description**
- **Interface Type**
- **Interface MPEG Output**
- Etc.

### Disk

This page displays the **Disk Table** and **Load Average** **Table**.

The **Disk Table** displays parameters such as:

- **Disk Path**
- **Disk Total**
- **Disk Used**
- Etc.

The **Load Average Table** displays the following information:

- **Load Average Name**
- **Load**
- **Load in Percentage**

### Physical Units

This page displays the **Physical Units Table** and the **Temperature Sensors** **Table**.

The **Physical Units Table** displays parameters such as:

- **Unit Description**
- **Serial Number**
- **Model Name**
- Etc.

The **Temperature Sensors Table** displays the following information:

- **Temperature Device**
- **Temperature Sensor Value**

### Output Multiplex

This page displays the **Output Multiplex Table** with parameters such as:

- **Mux ID**
- **Network Interface**
- **Mux MPEG Output**
- Etc.

### Device Redundancy

This page displays parameters such as the **Device Redundancy Mode**, **Device Redundancy State** and **Force Redundancy State**. It also displays the **Device Redundancy Primary Definition Table** with the following parameters:

- **Host Address**
- **Enabled**

### Alarms

This page displays alarm parameters triggered by incoming traps such as the **Agent State**, **Service Interruption Reason** and **Force Redundancy State**. It also displays the **Alarms** table with the following parameters:

- **Severity**
- **Alarm Description**
- **Occurred Date/Time**
- Etc.

### Webpage

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage: Range 1.1.0.x

### General

This page displays the device's general information parameters, such as **Software Version**, **ME Protocol Version**, **ME Platform Name**, etc. It also includes a table that lists the system **Users** and their **Roles**.

The page has two subpages:

- **Add User**: Allows you to add new users to the system.
- **Change Password**: Allows you to change a password. To do so, select a username first.

On this page, you also need to configure the **Protocol Version** before logging in. This is the version number assigned to the XML API protocol. The default value of this parameter is *2.2*.

### System

This page displays system information parameters such as **Name, Mode, Version, Model, Memory Utilization, Time Format, Time Zone** and **Reset Filter Time Remaining**. It also also allows you to configure the **SDT Path.**

On the **NTP Settings** subpage, you can find the **NTP Server Table** and the **Current NTP Server**. This page also allows you to add **NTP servers**, and contains the **NTP Sync** and **Reboot Device** buttons.

### Network

This page displays the **GigE Interface Port Configuration Table**, which allows you to configure parameters such as MPEG Status, Port Status, Block Management Traffic, Virtual IP Address, Virtual Netmask, DSCP, Routing Protocol, MPEG Output, etc.

The page has two subpages:

- **Port Analyzer**: On this page, you can configure the parameters **Direction (In or Out)**, **Analyzer** **Source**, **Analyzer Destination**, **Auto Negotation**, **Speed** and **Port Analyzer** in order to enable the **Port Analyzer** in the selected source-destination combination. When the port analyzer is enabled, the parameter configuration can no longer be changed and the **PAN Configuration Edit Mode** is changed from *Read/Write Mode* to *Read Only*. You can cancel the settings and enter new values as long as the **Apply** button has not been pressed yet.
- **Static Routes**: This page contains the **Static Routes Table**. With the **IP Address**, **Subnet Mask**, **Port ID**, **Network** and **Gateway** parameters, you can add a new static route entry to the table. With the **Delete** **All** button, you can remove all entries from the table. You can also delete a static route manually using the button in the table.

### SNMP

This page contains the System Name, SNMP Agent Status, Agent Version, Contact, Location, Read and Read Write Community Tables, Trap Listeners Table, NMS Hosts Table, SNMPv3 Settings Table and the SNMP Security Level.

Note:

- If the **SNMP Version** is changed from *version 2* to *version 3* and the **SNMP User Settings Table** does not have any user entries, the user will be forced to enter at least one **SNMPv3 User** first. If the **SNMP Version** is changed from *version 2* to *version 3* and there is at least one entry in the **SNMPv3 User Settings Table**, the change will be implemented without any need for additional configuration.

- If you change the **SNMP Security Level**, the **SNMPv3 User Settings Table** will be deleted and you will need to enter at least one SNMPv3 user with the new security level.
  It is important that there are three **security levels**:

- *No Authorization No Privacy*: No authorization or privacy password need to be specified.
  - *Authorization No Privacy*: An authorization password must be specified, but no privacy password is needed.
  - *Authorization and Privacy*: Both an authorization and a privacy password must be specified.

> If for some reason you do not configure these settings, a pop-up message will inform you that the corresponding action cannot be completed.

- If **Accept All Hosts** is enabled, it is not possible to add an NMS host.

### Hardware

This page displays the **Hardware Profile Table** and the **SFP Information Table.**

### Security

This page contains the RADIUS Status, Local Fallback, Number of Retries, Authentication Servers Table and Accounting Servers Table.

Via a page button, you can add a server, using the following parameters:

- **Security Server Type**
- **Sercurity Server IP**
- **Security Server Timeout**
- **Security Shared Secret**
- **Confirm Security Shared Secret**

**IMPORTANT**: It is very important that before you add a server using the **Add** button, you first test the connection using the **Test** button. There is a parameter that will display the result of this test.

### Sessions

This page displays the **Sessions** **Table**.

### Sotware Updates

This page contains the **Software Updates Table**, as well as parameters that allow you to execute a software update:

- **Update Via:** Remote Server or File System on PC.
- **Server Communication:** SCP (Default) or TFTP
- **Server IP Address** (IP Addres sof the Remote Server)
- **Build**
- **Remote Username**
- **Remote Password**
- **Local Folder**

### Redundancy

This page contains parameters related to the chassis redundancy: Mode, Backup Device IP Address, Backup Device Name, Auto Fail Back, Checking Frequency, Check Frequency Type, Start Checking on, Checking Duration, Backup Table and Primary Device IP Address to Backup.

Wiht four buttons at the bottom of the page, you can execute the following actions: **Cancel** or **Apply** the Cred Failback settings, or trigger a **Failback** or **Failover**. You can also add a **Primary Device IP** **Address** to the **Backup Table**.

### Tools

This page displays the **License Status Table** and the **License Options**, i.e. *Generate License Request*, *Apply License File* or *Revoke License File.*

### Alarms

This page displays a table listing the alarms on the platform. With the **Maximum History Entries** and **Maximum History Days** parameters, you can configure when entries are cleaned from the table.

On the Alarm Settings table subpage, you can find the **Alarms Settings Table**.

### Status

This page contains various status parameters: Total Critical/Major/Minor Alarms, Total Configured Rate, Total Active/Inactive Input Multiplex, Total Groomed Program, Chassis Redundancy Status, Device Data Time, Software Started Since, Database Status, Write Pending, Last Write, Last Failed Write and Failed Write Reason.

### Files

This page contains the Files Configuration Table.

It also contains page buttons to the following subpages:

- **Audio**: Contains the **Custom Audio Files Table** and **Audio Files Table**.
- **Video**: Contains the **Video Files Table** and **Custom Video Files Table**.

### Backup & Restore

On this page, you can configure the **Backup File Path** and **Restore Options**. A button is available that allows you to execute a **Backup**.

### BNC Inputs

This page displays five tables:

- **Input BNC Lines Table**: Includes the Name, Description, Mode, Video Format, Status, etc.
- **SDI** **Input** **Multiplex** **Table**: Includes the Video Format, Audio Mode, Closed Caption Format, Audio Channels, etc.
- **SDI Input Programs Table:** Includes the Name, Description, Number, etc.
- **SDI Input Program Streams Table**: Includes the Stream Name, Description, Content, Maximum Bitrate, etc.
- **ARIB Input Channels Table**: Includes the Code, Description, Channels, etc.

In addition, on the **Add SDI Multiplex** subpage, you can add new SDI Multiplex entries to the system.

### GigE Inputs

This page displays five tables:

- **GigE Intarfaces Port Configuration Table**: Includes the Name, Link, IP Address, MPEG Status, etc.
- **GigE Input Multiplex Table**: Includes the Name, Description, UDP Connection, UDP Port, Mux Type, etc.
- **GigE Tables Table**: Includes the Name, Table ID, Table Extension, etc.
- **GigE Input Mux Programs Table**: Includes the Name, Program Number, PMT PID, PCR PID, Service, etc.
- **GigE Inputs Stream Table**: Includes the Stream Name, Type, Content, Maximum Bit Rate, etc.

In addition, on the **Add GigE Input Multiplex** subpage, you can add new GigE Multiplex entries to the system.

### Input Tree

This page displays a tree control that allows easy navigation through the different inputs.

### Outputs

This page displays four tables:

- **GigE Output Multiplex Table**: Includes the Name, Line, Group, Role, Destination, Type, Mode, Bit Rate, etc.
- **GigE Output Programs Table**: Includes the Name, Program Number, PMT ID, PCR ID, etc.
- **GigE Output Tables Table**: Includes the Name, Table ID, PID, Extended Table ID, etc.
- **GigE Output Program Streams Table**: Includes the Stream Type, Content, Description, Bit Rate, etc.

On the **Add CBR Group** subpage, you can add new CBR groups to the system.

On the **CVCT & TVCT** subpage, you can edit the **Cable Virtual Channel Table (CVCT)** parameters, including the Program Number, Name, Major Channel, Minor Channel, etc. This subpage also contains the **Terrestrial Virtual Channel Table (TVCT)** parameters, including the Program Number, Name, Major Channel, Minor Channel, etc.

### PSIP

This page displays the **PSIP Table**, including GPS UTC, Daylight Saving, Start Date, End Date, Intervals, etc.

### TOT

This page displays the **Time Offset Table**, including the Country Code, Country Region, Polarity, Local Time, Date of Change, etc.

The **TOT Settings** subpage allows you to add new entries to the Time Offset Table.

### Network Descriptors

This page displays the following tables: Network Information Table, Network Name Descriptor Table, Linkage Descriptor Table, Multilingual Network Name Descriptor Table, Private Descriptors Table and Stuffing Descriptor Table.

### NIT Transport Streams

This page displays the following tables: Transport Streams Table, Transport Stream Services List Descriptors Table, Satellite Delivery System Descriptor Table, Cable Delivery System Descriptor Table, Terrestrial Delivery System Descriptor Table, Logical Channel Number Descriptors Table, Transport Stream Stuffing Descriptor Table and Transport Stream Private Descriptor Table.

### Output Tree

This page displays a tree control that allows easy navigation through the different outputs.

### Grooming

This page contains the **Input Grooming Table**, **Output Programs Grooming Table** and **Files Grooming Table**. At the bottom of the page, you can find the **Create Groom** and **Refresh** buttons. Clicking the Refresh button will refresh the inputs.

On the Grooming Settings subpage, you can configure the **Priority**, **Maximum** and **Minimum** **Bit Rate** for the grooming.

Note: You can only configure one program at a time in the tables.

### Processing

This page displays the following tables: Output Programs Processing Table, Grooming Output Programs Table, Backup 2 Output Programs Table, STATMUX Processing Table and MBR Processing Table.

### Encoding Configuration

This page contains the following tables: Encoder Video Properties Table, Encoder Audio Properties Table, Encoding SCTE-35 Configuration Table, Encoder OP-47 Configuration Table, Teletext Configuration Table and Encoder WSS Configuration Table.

### Metadata

This page contains the **Audio Metadata Table**.

### Thumbnails

This page contains the **Thumbnails Table**, which displays the **Name**, **Group**, **Multiplexer** and **URL**.

### Webpage

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

---
uid: Connector_help_Symmetricom_SSU
---

# Symmetricom SSU

The aim of this connector is the control of a management system.

## About

This is an **SNMP** connector that retrieves simple SNMP parameters and SNMP tables, for which alarms can be generated. It also allows you to set new values for certain parameters.

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device, e.g. *127.0.0.1*.

SNMP Settings:

- **Port number:** The port of the connected device, e.g. *161*.
- **Get community string:** The community string used when reading values from the device, e.g. *public*.
- **Set community string:** The community string used when setting values on the device, e.g. *private*.

## Usage

### System Management

This page displays general information about the system, such as the **System Description**, **System Name**, **System Location**, etc.

The **SNMP Info** page button displays several counters: **SNMP Incoming Packets**, **SNMP Incoming Bad Values**, **SNMP Outgoing Set Requests**, **SNMP Outgoing Traps**, etc.

### IP Management

This page displays counters related to IP management: **IP Incoming Receives**, **IP Frag OKs**, **IP Frag Creates**, etc.

### ICMP Management

This page contains data related to ICMP messages: **ICMP Incoming Errors**, **ICMP Incoming Redirects**, **ICMP Incoming Addr Masks**, **ICMP Outgoing Redirects**, etc.

### TCP Management

This page contains parameters related to the TCP layer: **TCP Retrans Timeout Algorithm**, **TCP Max Conn**, **TCP Established Resets**, **TCP Incoming Segs**, etc.

### UDP Management

This page displays parameters such as **UDP Incoming Datagrams** and **UDP Incoming Errors**.

It also contains the **UDP Table**, which indicates the **UDP Local Address** and the **UDP Local Port** for each UDP listener**.**

### EGP Management

This page contains the following parameters: **EGP Incoming Msgs**, **EGP Incoming Errors**, **EGP Outgoing Msgs**, **EGP Outgoing Errors** and **EGP AS.**

### Inventory

This page displays the following tables:

- **Inventory Table**: Contains the **Inventory Name, Inventory Serial, Inventory SW Revision, Inventory Shelf Part**, etc. for each slot in each chassis.
- **Inventory** **Feature Table**: Indicates if one of the **NTP** and **SNMP** features is enabled**.**

### Module Status

This page contains numerous page buttons that provide access to information about the **Clock Status**, **GPS Status**, **DS1/E1 Input Status**, **CC Input Status**, **Output Status**, **LRM Status**, **Sine Input Status**, **JCC Input Status** and **LRM E1 Status.**

### Module Setup

This page contains the parameters **Set COM ID**, **Set COM Info**, **Set COM Version** and **Set COM Name.**

There are also several page buttons that provide access to additional parameters: **Clock Setup, GPS Setup, DS1/E1 Input Setup, CC Input Setup, DS 1 Output Setup, E1 Output Setup,** **2048 Output Setup, CC Output Setup,** **RS422 Output Setup, E1/2048 Output Setup, LRM Setup, Sine Out Setup, Sine in Setup, JCC Out Setup, JCC in Setup** and **LRM E1 Setup.**

### General

This page contains the **Info Table**, which displays the **Gl Sys Time**, **Gl Elevation** (module elevation time), **Gl Setup** (*Save, User* or *Factory*) and **Gl Restart**.

### Event

This page displays all events in the **Event Table.** For each event, the following information is provided: **Ev ID**, **Ev M Hex Code**, **Ev Timestamp**, **Ev Chassis**, **Ev Slot**, **Ev Port**, **Ev Alm Code**, **Ev Notif Code**, **Ev Elevated** and **Ev Description**.

### Alarm

On this page, the **Alarm Table** displays information concerning the alarms, including the **Alarm Level** and the **Alarm Elevate.**

In addition, the **Set Alarm Table** allows you to adjust the alarm level and the alarm hardware indication delay with the columns **Sal Level** and **Sal Delay.**

### Reference

This page contains all reference parameters: **Reference Clock** (e.g. *Clock A*), **Reference Input**, **Reference Bypass**, **Reference Clock Switch**, **Reference Input Switch** and **Reference Input Selection.**

### Phase

This page contains general parameters about the phase: **Phase History Input Location**, **Phase History Time Average**, **Phase History Clock** and **Phase History Count**.

Two page buttons show the **Phase Table** and the **Phase History Table.** The Phase Table shows the **Ph A/B (100/1000/10000) Timestamp/Value.** The **Phase History Table** shows the **Ph Hist Timestamp** and the **Ph Hist Value** for each port, at each slot and for each chassis.

### Frequency

This page displays the **Frequency Table**, which contains the **Frequency A Timestamp**, **Frequency A Value**, **Frequency B Timestamp** and **Frequency B Value**.

### NTP

On this page, you can edit NTP configuration settings: **NTP Add Client**, **NTP Add Broadcast**, **NTP Add Broadcast Client**, **NTP Delete Peer**, etc.

Two page buttons display more details concerning **Peer Statistics** and **NTP Peer**.

### Time

This page shows the **Current Time** and the **Local Offset**, which are both editable.

### PQL

This page contains the **PQL DS1 Table** and the **PQL E1 Table**, which allow you to edit the **SSM** and the **Description.**

### IO Name

This page contains a table where you can edit the **IO Name** for each input/output in the system.

### Communication

This page contains the following tables:

- **RS232 Table**: Allows you to edit the **COM Mode**, the **COM Echo**, the **COM EOL** (*CR, LF, CRLF)*, and the **COM Baud**.
- **COM Parameter Table**: Allows you to define a **COM Timeout** in seconds for each **COM Type**.

### SNMP Manager

This page contains the parameters **SNMP Manager Initialize** (*Init v2, Init v3*), **SNMP Manager Trap** (*Alarm, All*)*,* **SNMP Notification** *(V2, V3, All)* and **SNMP Enable** *(V2 Enable, V2 Disable).*

The page buttons **SNMPv2** and **SNMPv3** display the following information: the **SNMPv2 Manager Table**, **SNMPv2 User Table**, **SNMPv3 User Table** and **SNMPv3 Manager Table**.

### System

This page contains the parameters **System PBO**, **System Reset Clock**, **System Operational Mode**, **System TL1 Format**, **System Event Login** and **System ACO.**

It also contains the **Sys Keep Alive Table**, which provides the **Sys Alive Time** (*trap period*) for each **Sys Alive Type** (*TL1 session* or *SNMP session*).

### Users

This page contains the **User Table**, which shows the **User Level** and the **Username** for each user**.**

### Who

On this page, the **Who Table** displays which port (**Who Port**) is used in the currently active connections, and the associated user names (**Who Name**).

### MTIE

This page contains the parameters **MTIE Input Location, MTIE From Time, MTIE to Time, MTIE History Input Location, MTIE History Clock** and **MTIE History Count** (the number of days of MTIE history to report).

The **MTIE Table** and **MTIE History Table** can be accessed via page buttons.

### Time Deviation

This page displays information similar to that on the MTIE page, but here the information is related to the time deviation.

### Module Traps

This page contains general information about the traps, such as **Tp Tag**, **Tp Timestamp**, **Tp Description**, etc.

Via the **Traps** page button, you can view the **Traps Table**, which shows the history of all the received traps with all their bindings.

### Interfaces

This page summarizes the most important counters concerning the modules: **S IF Clock Number**, **S IF GPS Number**, **S IF Input E1 Number**, **S IF Input CC Number**, etc.

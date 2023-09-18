---
uid: Connector_help_Riverbed_Cascade_Shark_Appliance
---

# Riverbed Cascade Shark Appliance

The purpose of the Cascade Shark device is to capture, store and analyze network packets. It can manage several terabytes of data for later analysis. It can also forward micro-flow settings to a Cascade Profiler through MNMP.

## About

This connector uses SNMP to retrieve information about capture jobs and resource consumption. It also manages traps that report different kinds of status information.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of the device.
- **Device address:** Not required.

**SNMP Settings:**

- **Port number:** The port of the connected device, e.g. *161*.
- **Get community string:** The community string used when reading values from the device, e.g. *public*.
- **Set community string:** The community string used when setting values on the device, e.g. *private*.

### Configuration of traps

To ensure that traps will be managed, configure them in the web interface to be of type **SNMPv2**.

## Usage

### General

This page displays general information: **System Name**, **System Up Time**, **System Location**, etc.

### Status

On this page, several tables provide information about capture jobs.

- The **Capture Jobs** table displays the **job names**, their **status**, the associated **capture packet sizes**, etc. DVEs based on this table contain more detailed information about the capture jobs (see section "Capture Jobs").
- The **Profiler Configured For Export** table indicates **IP addresses** of associated profilers and their **export status**.
- Information about exported statistics is also displayed in the **Profiler Export Statistics** table: **total exported flows over last minute**, **peak of the rejected flows the last week**, etc.
- The **File System** table shows the disk resources usage by the Operating System.
- The **Packet Storage Table** indicates the disk space used by the packet storage process.

**Main memory** usage and **CPU Load** are also reported in individual parameters.

### Capture Jobs

Various kinds of information can be found on this page: **Job Name, Job Status, Interface name, Maximum Packet Size for Capture, Job Status Packet Start Time**, etc.

The **Data Retention** page button displays information about the packet retention limits: the **size, number of packets** or **time duration. Size Limit** and **Time Limit** criteria are also shown for the **Microflow Index**.

The **Start/Stop Settings** page button displays information on the optionally configured **Requested Start/End Times** as well as on the optional **stop rules**, which can depend on the **packet size**, **packet amount** or **time duration**.

Finally, the **Enclosure Disk Table** displays the **status** of disks, their **model** and their **serial number**.

### Interfaces

This page displays the **Interfaces Table**, which contains traffic statistics for all the network interfaces of the device: **RX/TX Octets, RX/TX Unicast Packets, RX Packets in Error**, etc.

### Notifications

On this page, several event tables are shown that contain notification events sent by traps: **Packet Storage Failure Table**, **Reboot Event Table**, **View Killed Table**, **Disk Pressure Events Table**, etc.

Alarms are also received with the traps depending on their associated severities. Buttons are available to clear the tables when needed.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

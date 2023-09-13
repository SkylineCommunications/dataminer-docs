---
uid: Connector_help_Motorola_SE-6501
---

# Motorola SE-6501

The **Motorola SE-6501** is an **Encoder**.

## About

This driver communicates using **SNMP Protocol.**



Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.1          | Initial version | No                  | No                      |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.1          | 3.3-9                       |

## Installation and configuration

### Creation



SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: \[Indicate if required or not. If it is, specify default value and range.\]

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: \[The community string used when reading values from the device
  (default value if not overridden in the driver: *public*).
  Note: If you have specified a default value in the driver, then specify that custom value.\]
- **Set community string**: \[The community string used when setting values on the device
  (default value if not overridden in the driver: *private*).
  Note: If you have specified a default value in the driver, then specify that custom value.\]

## Usage



### System Monitor

This page contains monitoring information about the system.

It allows the user to set: **Operational State, Alarm Status** and **System State.**

It displays: **Encoder Version, IP Bonding Info** and **Video/Audio/Mux/Transport** **Current Bitrate.**

It also displays the table: **Input Mpts Table.**



### Network Settings

This page allows the user configure the network settings on the device.

It allows the user to set: **Host Name, NTP Server IP Address, System TTL, Backup NTP Server Address** and **TS1/TS2:** **Current Destination Address, Current Format, Current Interface, Current Destination UDP Port, Current Destination Physical Address.**

It displays: **Encoder IP Address, Equipment Type, Gateway IP, Subnet Mask** and **Eth0/Eth1/Eth2/Eth3: IP Address, Subnet Mask, Gateway IP Address.**

It also contains a pagebutton to: **TS and Virtual IF Tables**.



### System Configuration

This page contains configuration parameters for the system.

It allows the user to set: **Local Or Control, Redundancy Role, Restore Defaults, Toa Clock, Toa Clock Time, Session Number, Session Status, Current Primary ID, Current Preset Extra Row Offset, Current Preset Extra Row Count, Current Conf Num.**

as well as: **Current Conf Name, Save Conf, Name, Redundancy Group ID,** and **Redundancy Group Name.**

It displays: **UTC Date and Time, Config Filename List, Current Conf Count,** and **Current Conf DB Out of Sync.**

It contains a pagebutton to: **Auto Restore Config**.



### Service Provision

This page contains tables which hold information about the services provisioned.

It also allows the user to set: **ASI Program Number** and **Internal Source Image Number.**

It displays: **Service Table, VBI Table, DPI Table, Stat Mux Table, Input Tuner Table, Ancillary Data Table** and **Internal Source Table.**

**
**

### Mux Provision Statistics

This page contains various tables relating to Mux provision.

It displays the following tables for **Stat Mux**: **Pool Table, Group Table, Encoder Table, Pid Remap Table** and **FEC Error Table.**



### Identity

This page contains identity information about the device.

It allows the user to set: **Iventory Code, Location Area, Location Shelf, Command** and **Description.**

it displays: **Serial Number, Chassis Number, IF Index, Hardware Features, Software Version, MIB Version, Agent Version, Unit Model, License Feature list** and **License Version.**

It contains a pagebutton to: **IF Extension**



### State

This page contains information about the state of the device

It allows the user to set: **Administrative State, Procedural Status, Control Status, Unkown Status, Fault Log Entry Number** and **Fault Log Clear.**

It displays: **Operational State, Usage State, Alarm Status, Availability Status, Standby Status, Log Max Num Entries** and **Fault Log Data.**

It contains a pagebutton to: **Alarm Page** and **Traps Page**



### Components

This page contains information about the components in the device.

It displays the tables: **Platform Table, Module Table, Port Table** and **Mod Channel Table.**



### Chassis

This page contains information about the chassis.

It displays the table: **Chassis Power Supply Table.**



### Web Interface

This page directly displays the devices Web Interface.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

---
uid: Connector_help_Motorola_SE-5100
---

# Motorola SE-5100

The **Motorola SE-5100** is an **Encoder**.

## About

This connector communicates using **SNMP Protocol.**

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.3-9                       |

## Installation and configuration

### Creation

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default: *public*.
- **Set community string**: The community string used when setting values on the device, by default: *private*.

## Usage

### System Monitor

This page contains monitoring information about the system.

It allows the user to set: **Operational State, Alarm Status** and **System State.**

It displays: **Encoder Version, IP Bonding Info** and **Video/Audio/Mux/Transport** Current Bitrate.

### Network Settings

This page allows the user configure the network settings on the device.

It allows the user to set: **Host Name, NTP Server IP Address, System TTL, Backup NTP Server Address** and **TS1/TS2:** **Current Destination Address, Current Format, Current Interface, Current Destination UDP Port, Current Destination Physical Address.**

It displays: **Encoder IP Address, Equipment Type, Gateway IP, Subnet Mask** and **Eth0/Eth1/Eth2/Eth3: IP Address, Subnet Mask, Gateway IP Address.**

It also contains a page button to: **TS and Virtual IF Tables**.

### System Configuration

This page contains configuration parameters for the system.

It allows the user to set: **Local Or Control, Redundancy Role, Restore Defaults, Toa Clock, Toa Clock Time, Session Number, Session Status, Current Primary ID, Current Preset Extra Row Offset, Current Preset Extra Row Count, Current Conf Num.**

as well as: **Current Conf Name, Save Conf, Name, Redundancy Group ID,** and **Redundancy Group Name.**

It displays: **UTC Date and Time, Config Filename List, Current Conf Count,** and **Current Conf DB Out of Sync.**

It contains a page button to: **Auto Restore Config**.

### Service Provision

This page contains tables which hold information about the services provisioned.

It also allows the user to set: **ASI Program Number** and **Internal Source Image Number.**

It displays: **Service Table, VBI Table, DPI Table, Stat Mux Table, Input Tuner Table, Ancillary Data Table** and **Internal Source Table.**

### Identity

This page contains identity information about the device.

It allows the user to set: **Inventory Code, Location Area, Location Shelf, Command** and **Description.**

it displays: **Serial Number, Chassis Number, IF Index, Hardware Features, Software Version, MIB Version, Agent Version, Unit Model, License Feature list** and **License Version.**

It contains a page button to: **IF Extension**

### State

This page contains information about the state of the device

It allows the user to set: **Administrative State, Procedural Status, Control Status, Unknown Status, Fault Log Entry Number** and **Fault Log Clear.**

It displays: **Operational State, Usage State, Alarm Status, Availability Status, Standby Status, Log Max Num Entries** and **Fault Log Data.**

It contains a page button to: **Alarm Page.**

### Components

This page contains information about the components in the device.

It displays the tables: **Platform Table, Module Table, Port Table** and **Mod Channel Table.**

### Chassis

This page contains information about the chassis.

It displays the table: **Chassis Power Supply Table.**

### Web Interface

This page directly displays the devices Web Interface.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

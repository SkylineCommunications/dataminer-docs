---
uid: Connector_help_CEFD_Memotec_NetPerformer_SDM9220-9230
---

# Memotec NetPerformer SDM9220-9230

The Memotec Netperformer SDM9220-9230 version is an SNMP connector intended to communicate with SDM9220-9230 Netperformer devices.

## About

This connector implements the available parameters present in the device's MIB. The connector layout is implemented as much as possible like the device's web interface. There are menus that are not 100% coincident.
A **SNMP** connection is used in order to successfully retrieve and configure the device's information.

## Installation and configuration

### Creation

**SNMP Connection:**

- **IP Address/host:** \[*The polling IP of the device.*\]

**SNMP Settings:**

- **Port Number:** \[*The port of the connection device (default: 161).*\]
- **Get community string:** \[*The community string used when reading values from the device (default value is not overridden in the connector: public).*\]
- **Set community string:** \[*The community string used when setting values on the device (*default value is not overridden in the connector: private*).*\]

## Usage

In this section of the connector help, some general info is available about the usage of the Memotec NetPerformer connector.

### Main Menu

- **Unit Information**, including **Unit Name** and the **Location** of the unit to which you are connected.
- **Unit Day**, **Date** and **Time** are available here. Use the **Time Sync** page button to have access to Time Sync options.

### Configuration - Global

All the global parameters available for configuration are shown here. Also, the following pages are provided with extra settings:

- **Extra ...**
- **Rackmount Chassis ...**

### Configuration - Advanced

All parameters which are redundancy related are available on the following pages:

- **Redundancy Criteria ...**
- **Redundancy Remote ...**
- **Redundancy Switch ...**

### Configuration - Others

This page provides an overview of some general configurations of the NetPerformer unit.

### Configuration - IP

This page provides access to all the different configuration profiles available on the NetPerformer unit for **IP configuration**:

- **BOOTP ...**
- **DNS ...**
- **Global IP...**
- **NAT ...**
- **OSPF ...**
- **RADIUS ...**
- **SNMP ...**
- **Source-Static ...**
- **Static ...**
- **TimeP ...**
- **Interfaces ...**

### Configuration - Slots Link

The Configuration - Slots Link page gives an overview of all defined links on the NetPerformer unit.

### Configuration - Slots Channels

- **VCE/WAN Table** provides an overview of all available **Slots Channels** on the NetPerformer unit and its configured **Protocol** and **Timeslot**.
- For each available protocol, there's a page available which provides an overview of all related slots channels.

### Configuration - Ports

This page provides the NetPerformer base unit ports. In **Port CSL** and **Port 1** page buttons after selecting which protocol should be used you must go to the respective protocol page button. Some parameters will be only available if the respective option is active. Otherwise the parameter will be assigned with Not-Configured.

### Configuration - PVC

- **PVC Table** provides an overview of all available **Modes** on the NetPerformer unit.
- For each available mode, there's a page available which provides an overview.

### Alarms

The **Alarms** menu shows all current alarms. **Clear Alarms** and **Clear Error LEDs** buttons are available to clear them.

### Counters

The **Counters** menu provides access to a selection of counters for the current unit. The **Reset Counters** button resets all counters.

### Errors

The **Errors** page lets you have access to various types of errors.

### States

This page provides an overview of all various types of states:

- **States Redundancy ...**
- **States Voice ...**
- **States LDC ...**
- **States System ...**
- **States Port Eth ...**
- **States Port CSL ...**
- **States Port 1-304 ...**

### Routing Table

The NetPerformer Routing provides access to various **Routing Table** selections.

### Web Interface

Use this page to have access to the **Web Interface** provided by the device's web server. Only in a LAN environment it's possible to have access to this page.

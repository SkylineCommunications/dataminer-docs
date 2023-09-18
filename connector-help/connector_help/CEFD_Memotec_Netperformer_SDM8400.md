---
uid: Connector_help_CEFD_Memotec_Netperformer_SDM8400
---

# CEFD Memotec Netperformer SDM8400

The Memotec Netperformer SDM8400 version is an SNMP connector intended to communicate with SDM8400 Netperformer devices.

## About

A SNMP connection is used in order to successfully retrieve and configure the device's information.

## Installation and configuration

### Creation

**SNMP Connection:**

- **IP Address/host:** \[*The polling IP of the device.*\]

**SNMP Settings:**

- **Port Number:** \[*The port of the connection device (default: 161).*\]
- **Get community string:** \[*The community string used when reading values from the device (default value is not overridden in the connector: public).*\]
- **Set community string:** \[*The community string used when setting values on the device (*default value is not overridden in the connector: public*).*\]

## Usage

In this section of the connector help, some general info is available about the usage of the Memotec Netperformer connector.

### Main Menu

Here is some general info about the unit.

### Configuration - Global

All the global parameters available for configuration are shown here. Also, the following pages are provided with extra settings:

- **Extra...**
- **Rackmount Chassis...**

### Configuration - Advanced

All parameters which are redundancy related are available on the following pages:

- **Redundancy Criteria...**
- **Redundancy Remote...**
- **Redundancy Switch...**

### Configuration - Others

This page provides an overview of some general configurations of the Netperformer unit.

### Configuration - IP

This page provides access to all the different configuration profiles available on the Netperformer unit for **IP Configuration**:

- **BOOTP...**
- **DNS...**
- **Global IP...**
- **NAT...**
- **OSPF...**
- **RADIUS...**
- **SNMP...**
- **Source-Static...**
- **Static...**
- **TimeP...**
- **Interfaces...**

### Configuration - Slots Link

The Configuration - Slots Link page gives an overview of all defined links on te Netperformer unit.

### Configuration - Slots Channels

- **VCE/WAN Table** provides an overview of all available **Slots Channels** on the Netperformer unit and it's configured **Protocol** and **Timeslot**.
- For each available protocol, there's a page available which provides an overview of all related slots channels.

### Configuration - Ports

This page provides the Netperformer base unit ports. In **Port** **CSL** and **Port** **1** page buttons after selecting which protocol should be used you must go to the respective protocol page button. Some parameters will be only available if the respective option is active. Otherwise the parameter will be assigned with Not-Configured.

### Configuration - PVC

- **PVC** **Table** provides an overview of all available **Modes** on the Netperformer unit.
- For each available mode, there's a page available which provides an overview.

### Alarms

The **Alarms** menu shows all current alarms. **Clear Alarms** and **Clear Error LEDs** buttons are available to clear them.

### Counters

The **Counters** menu provides access to a selection of counters for the current unit. The **Reset Counters** button resets all counters.

### Errors

The **Errors** page lets you have access to various types of errors.

### States

This page provides an overview of all various types of states:

- **States LDC...**
- **States Redundancy...**
- **States Port Eth...**
- **States Port CSL...**
- **States Port 1-304...**

### Routing Table

The Netperformer Routing provides access to various Routing Table selections.

### Web Interface

Use this page to have access to the **Web Interface** provided by the device's web server. Only in a LAN environment it is possible to have access to this page.

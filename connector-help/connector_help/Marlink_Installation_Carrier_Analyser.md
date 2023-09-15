---
uid: Connector_help_Marlink_Installation_Carrier_Analyser
---

# Marlink Installation Carrier Analyser

## About

This connector will query the routing table of the main router that is responsible of establishing connection with all the remote carriers used by the installation.
This way we're able to analyze which installations are using which carriers.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string needed to read from the device. The default value is *public*.
- **Set community string:** The community string needed to set to the device. The default value is *private*.

## Usage

### Installations

Installation table: user can add/delete rows and modify each value.

- Installation IP has to be filled in
- Subnet mask: only used when filled in.
- Installation name: identifying name chosen by the user.

Installation Carrier Table: results from the installation table, displays all carriers for the installations. PE routers are hardcoded added as \`VSAT' carriers.

### Routing Table

Source IP, Gateway, subnet mask and Interface Description (default polling : 2 min)

### Interface

Interface description overview: Refresh button: refresh the interface table (default polling : 10 min)

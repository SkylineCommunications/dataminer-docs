---
uid: Connector_help_VOO_Ad_Hoc_Polling
---

# VOO Ad Hoc Polling

This connector allows VOO to poll a list of MTA's independently from the **CPE** (Seram) system.

## About

The goal of this connector is to poll KPI's from a list of MTA's independently of the **CPE** (Seram) system. Multithreaded polling is used to retrieve information from the CMTS using **SNMP** and **SSH**, and from the MTA using **SNMP**.

CMTS elements are automatically detected on the DMS, but the user can add custom entries too (to enable polling of MTA's, even if the CMTS element is not present). The user can maintain a list of MTA's (add and remove) which have to be polled. The user defines for each MTA: MAC, Description, CMTS (dropdown), Type.

The **IP addresses** of the MTAs are updated periodically with information from the CMTS.

## Installation and configuration

### Creation

This connector uses two Simple Network Management Protocol (**SNMP**) and a **SSH** connection and needs following user information:

**SNMP CONNECTION (MTA)**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*
- **Device address**: not needed

SNMP Settings:

- **Port number**: the port of the connected device, default *161*
- **Get community string**: the community string in order to read from the device. The default value is *public*.
- **Set community string**: the community string in order to set to the device. The default value is *private.*

**SNMP CONNECTION (CMTS)**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*
- **Device address**: not needed

SNMP Settings:

- **Port number**: the port of the connected device, default *161*
- **Get community string**: the community string in order to read from the device. The default value is *CADMIUM*.
- **Set community string**: the community string in order to set to the device. The default value is *private.*

**SERIAL CONNECTION (CMTS)**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*
- **IP port**: the port of the connected device. Default is 22.
- **Bus address**: not needed.

### Configuration

Please specify the SSH credentials of the CMTS on the **configuration** page.

## Usage

### General page

Contains a treeview with all the CMTS collectors and MTA's.

### CMTS Collectors page

This page provides a table containing all the CMTS collectors that must be polled by this connector. All CMTS collector elements on the DMS are automatically added, but it's possible to manually add entries with the context menu.

CMTS US Channels Table

Table containing all upstream channels on the CMTS. This table is used to link SSH information with SNMP.

### MTA Page

This page provides a table containing all the MTA's that must be polled by this connector. New devices should be added with the context menu.

### MTA Channels page

This page contains a table with upstream channels, and a table with downstream channels, and their information.

### Configuration page

Holds all configuration parameters used by this element.

### System Overview page

Displays information about the threadpools used to poll the devices.

## Notes

There is a Visio available to make the interaction with the user easier.

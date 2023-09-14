---
uid: Connector_help_HP_Fibre_Channel_Switch
---

# HP Fibre Channel Switch

The **HP Fibre Channel Switch** is used to share the capacity of fiber channel storage devices among multiple servers.

## About

This connector allows the user to monitor and configure the HP Fibre Channel Switch.

## Installation and Configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### General Page

This page displays general information, such as:

- **System Description**
- **System Up Time**
- **Firmware Version**
- **Operational Status**

### System Page

This page displays the **IP address** of the HP Fibre Channel Switch, the **Serial Number** and several other system parameters.

### Sensors Page

This page displays all sensors of the HP Fibre Channel Switch. There are three **sensor types**:

- **Temperature**
- **Fan**
- **Power supply**

### Community Page

This page displays the **community strings for SNMP**. You can also add trap recipients on this page.

### Ports Page

This page displays all **statistics** for the available ports. In addition, it is possible to configure certain settings, such as **Port State** and **Port Speed**.

### Local Name Server Page

This page displays all **local name server** entries.

### Events Page

This page displays all events that have occurred, with their severity.

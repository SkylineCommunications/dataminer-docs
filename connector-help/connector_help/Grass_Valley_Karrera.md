---
uid: Connector_help_Grass_Valley_Karrera
---

# Grass Valley Karrera

The Grass Valley Karrera is a modular video production center/switcher.

## About

With this connector, it is possible to monitor **Grass Valley Karrera** devices with SNMP.

The different parameters from the device are displayed on multiple pages according to the subject of the parameters.

The connector implements all traps to update the corresponding values and to generate alarms immediately.

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

### General Page

This page displays some general information such as:

- **Model Name**
- **Software Rev**
- **State**
- **Installed Modules**

There are also two page buttons on this page:

- IP Config...

- Shows the IP interfaces of the frame with the subnet mask and the default gateway.

- Trap Settings...

- Shows the SNMP trap information.

### Video Page

This page displays some video timing information such as:

- **Line Rate**
- **Frame Rate**
- **Detection of external references**
- **State**

### Environmental Status Page

This page displays environmental parameters of the frame such as:

- **Fan information**
- **Temperature information**
- **Power supply information**
